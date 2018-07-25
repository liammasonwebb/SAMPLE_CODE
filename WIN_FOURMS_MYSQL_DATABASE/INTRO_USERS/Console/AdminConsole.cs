using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INTRO_USERS
{
    public partial class AdminConsole : Form
    {
        const int daysOfWeek = 7;
       
        List<String> instructorsUserNames = new List<string>();
        List<String> timesOfDate = new List<string>();
        DateTime firstDayOfWeek;
        DateTime lastDayOfWeek;

        public AdminConsole()
        {
            InitializeComponent();
           
            instructorsUserNames = DBData.getInstructorsUsernames();
            ControlFunctions.populateCombo(comboBoxInstructor, instructorsUserNames);
            listViewDay.Visible = false;
            listViewWeek.Visible = false;
            listViewCarsAssigned.Visible = false;
        }


      
        private void dateTimePickerWeek_ValueChanged(object sender, EventArgs e)
        {
            listViewDay.Visible = true;
            listViewWeek.Visible = true;
            listViewCarsAssigned.Visible = true;
            
            comboBoxInstructor.SelectedItem = -1;
            comboBoxInstructor.Text = "";
            comboBoxCar.SelectedItem = -1;
            comboBoxCar.Text = "";
            populateCarCombo();
            
            timesOfDate = DBData.getTimesOfDay(dateTimePickerWeek.Value);
            ControlFunctions.clearListViewReport(listViewWeek);
            createListViewWeekReport();
            ControlFunctions.clearListViewReport(listViewCarsAssigned);
            createListViewAssignedCarsReport();
            labelDate.Text = dateTimePickerWeek.Value.ToString("d");
            ControlFunctions.clearListViewReport(listViewDay);
            createListViewDayReport(dateTimePickerWeek.Value);
        }

      
        private void buttonSaveSchedule_Click(object sender, EventArgs e)
        {
            if (listViewWeek.Items.Count > 0)
            {
                string[][] LVData = ControlFunctions.obtainDataFromListView(listViewDay);
                DBData.deleteExistingSchedulesForInstructorsAndDate(labelDate.Text);
                insertNewSchedules(labelDate.Text, LVData);
                ControlFunctions.clearListViewReport(listViewWeek);
                createListViewWeekReport();
            }
            else
            {
                MessageBox.Show("Please select first a date and plan a Schedule.");
            }
        }

        private void buttonCancelSchedule_Click(object sender, EventArgs e)
        {
            ControlFunctions.clearListViewReport(listViewDay);
            createListViewDayReport(DateTime.Parse(labelDate.Text));
        }

        private void comboBoxInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCar.SelectedItem = -1;
            comboBoxCar.Text = "";
            populateCarCombo();
        }

        private void comboBoxCar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonSaveCar_Click(object sender, EventArgs e)
        {
            if (comboBoxInstructor.SelectedIndex != -1 && comboBoxCar.SelectedIndex != -1)
            {
            if (checkInstructorScheduled(comboBoxInstructor.Text))
                {
                    DBData.updateCarAssignation(comboBoxCar.Text, comboBoxInstructor.Text, firstDayOfWeek, lastDayOfWeek);
                    ControlFunctions.clearListViewReport(listViewCarsAssigned);
                    createListViewAssignedCarsReport();
                    populateCarCombo();
                }
            else
                {
                    MessageBox.Show($"You have to select a week with scheduled slots for {comboBoxInstructor.Text}.");
                }
            }
            else
            {
                MessageBox.Show("Please select an Instructor and assing a Car with the Comboboxes below.");
            }
        }

        private void listViewDay_MouseDown(object sender, MouseEventArgs e)
        {
            var info = listViewDay.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                var row = info.Item.Index;
                var col = info.Item.SubItems.IndexOf(info.SubItem);
                if (info.SubItem != null)
                {
                    var value = info.Item.SubItems[col].Text;
                    if (col > 0 && col < instructorsUserNames.Count + 1 && row < timesOfDate.Count)
                    {
                        if (value == "0")
                        {
                         
                            if (DBData.checkExistingsStlots(DateTime.Parse(labelDate.Text), listViewDay.Items[row].Text))
                            {
                           
                                int weekHours = DBData.getHoursAssignedPerWeek(firstDayOfWeek, lastDayOfWeek, listViewDay.Columns[col].Text);
                                int DayHours = DBData.getHoursAssignedPerDay(DateTime.Parse(labelDate.Text), listViewDay.Columns[col].Text);
                                int newDayHours = int.Parse(listViewDay.Items[listViewDay.Items.Count - 1].SubItems[col].Text) + 1;
                                int newWeekHours = weekHours - DayHours + newDayHours;
                                if (int.Parse(listViewDay.Items[listViewDay.Items.Count - 1].SubItems[col].Text) < 8 && newWeekHours <= 40)
                                {

                                    ControlFunctions.changeListViewSubItemValue(listViewDay, row, col, "1");
                                    ControlFunctions.recalculateTotal(listViewDay, row, col, 1);
                                }
                                else
                                {
                                    MessageBox.Show("You cannot assign more than 8hours/day and 40hours/week.");
                                }

                            }
                            else
                            {
                                MessageBox.Show("There are no slots available for that Date and Time. Please select another one.");
                            }
                        }
                        else
                        {
                            if (DBData.checkAppointmentOccupiedByClient(labelDate.Text, listViewDay.Items[row].Text, instructorsUserNames[col - 1]))
                            {
                                ControlFunctions.changeListViewSubItemValue(listViewDay, row, col, "0");
                                ControlFunctions.recalculateTotal(listViewDay, row, col, 0);
                            }
                            else
                            {
                                MessageBox.Show("That Slot cannot be changed because there is already an Appointment with a Client.");
                            }
                        }
                    }
                }
            }
        }

        private void listViewWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewWeek.SelectedIndices.Count != 0)
            {
                var myIndex = listViewWeek.SelectedIndices[0];
                var dateSelected = listViewWeek.Items[myIndex].Text;
                if (myIndex < daysOfWeek)
                {
                    labelDate.Text = dateSelected;
                    ControlFunctions.clearListViewReport(listViewDay);
                    createListViewDayReport(DateTime.Parse(dateSelected));
                }
            }
        }



        private bool checkInstructorScheduled(string instructor)
        {
            bool existSchedules = false;
            for (int i = 0; i < listViewWeek.Columns.Count; i++)
            {
                if (listViewWeek.Columns[i].Text == instructor)
                {
                    if (int.Parse(listViewWeek.Items[listViewWeek.Items.Count - 1].SubItems[i].Text) > 0)
                    {
                        existSchedules = true;
                    }
                }
            }
            return existSchedules;
        }

        private void recalculateTotal(ListView myListView, int row, int col, int value)
        {
            if (value == 0)
            {
                int newColumnTotal = int.Parse(myListView.Items[timesOfDate.Count - 1].SubItems[col].Text) - 1;
                myListView.Items[timesOfDate.Count - 1].SubItems[col].Text = newColumnTotal.ToString();
                int newTimeTotal = int.Parse(myListView.Items[row].SubItems[instructorsUserNames.Count + 1].Text) - 1;
                myListView.Items[row].SubItems[instructorsUserNames.Count + 1].Text = newTimeTotal.ToString();
            }
            else
            {
                int newColumnTotal = int.Parse(myListView.Items[timesOfDate.Count - 1].SubItems[col].Text) + 1;
                myListView.Items[timesOfDate.Count - 1].SubItems[col].Text = newColumnTotal.ToString();
                int newTimeTotal = int.Parse(myListView.Items[row].SubItems[instructorsUserNames.Count + 1].Text) + 1;
                myListView.Items[row].SubItems[instructorsUserNames.Count + 1].Text = newTimeTotal.ToString();
            }
        }

        private void createListViewAssignedCarsReport()
        {
            //It creates the columns of the ListView
            ControlFunctions.createListViewColumns(listViewCarsAssigned, "Instructor", instructorsUserNames, "", 80, 68, 0);
            //It creates the items of the ListView
            List<string> carsTitle = new List<string>();
            carsTitle.Add("Assigned");
            ControlFunctions.createListViewItems(listViewCarsAssigned, carsTitle);
            //It creates the Subitems of the ListView
            //It creates the array of arrays of hours scheduled per day and instructor and one more for the totals
            string[][] carsAssigned = new string[1][];
            carsAssigned[0] = new string[instructorsUserNames.Count];

            //List<string> carsAssigned = new List<string>();
            for (int i=0; i<instructorsUserNames.Count; i++)
            {
                carsAssigned[0][i]=getCarsAssignedToInstructor(instructorsUserNames[i], firstDayOfWeek, lastDayOfWeek);
            }
            //It copies all the data to the listView creating the Subitems
            ControlFunctions.createListViewSubitems(listViewCarsAssigned, carsAssigned);
        }

        //It creates the ListView Report for the Week
        private void createListViewWeekReport()
        {
            //It creates the columns of the ListView
            ControlFunctions.createListViewColumns(listViewWeek, "Date", instructorsUserNames, "", 80, 68, 0);
            //It calculates the first and last date of the week
            int dayOfWeekSelected = (int)dateTimePickerWeek.Value.DayOfWeek;
            firstDayOfWeek = dateTimePickerWeek.Value.Date.AddDays(-dayOfWeekSelected + 1);
            lastDayOfWeek = firstDayOfWeek.Date.AddDays(daysOfWeek - 1);

            //It creates a list of the dates of the week
            List<String> datesList = new List<string>();
            for (int j = 0; j < daysOfWeek; j++)
            {
                datesList.Add(firstDayOfWeek.AddDays(j).ToString("d"));
            }
            //It adds the total per Instructor
            datesList.Add("Total");
            //It creates the items of the ListView
            ControlFunctions.createListViewItems(listViewWeek, datesList);

            //It creates the array of arrays of hours scheduled per day and instructor and one more for the totals
            string[][] hoursScheduledMatrix = new string[daysOfWeek + 1][];
            for (int j = 0; j < daysOfWeek + 1; j++)
            {
                hoursScheduledMatrix[j] = new string[instructorsUserNames.Count];
            }
            //It fills in the arrays
            for (int i = 0; i < daysOfWeek; i++)
            {
                for (int j = 0; j < instructorsUserNames.Count; j++)
                {
                    //It obtains the list of hours scheduled for the Instructors and Dates
                    hoursScheduledMatrix[i][j] = DBData.getInstructorHoursScheduledForDate(instructorsUserNames[j], firstDayOfWeek.AddDays(i));
                }
            }
            //It adds the total per Instructor and week summing all the days
            for (int j = 0; j < instructorsUserNames.Count; j++)
            {
                hoursScheduledMatrix[daysOfWeek][j] = "0";
                for (int i = 0; i < daysOfWeek; i++)
                {
                    hoursScheduledMatrix[daysOfWeek][j] = (int.Parse(hoursScheduledMatrix[daysOfWeek][j]) + int.Parse(hoursScheduledMatrix[i][j])).ToString();
                }
            }
            //It copies all the data to the listView creating the Subitems
            ControlFunctions.createListViewSubitems(listViewWeek, hoursScheduledMatrix);
        }

        private void populateCarCombo()
        {
            //It gets the cars assigned for each Instructor. There should be only one per week
            List<string> assignedCarsToInstructors = new List<string>();
            foreach (string instructor in instructorsUserNames)
            {
                //It gets the data from the DataBase
                assignedCarsToInstructors.Add(getCarsAssignedToInstructor(instructor, firstDayOfWeek, lastDayOfWeek));
            }
            //It gets the available cars for the week
            List<String> availableCars = new List<string>(getAvailableCars(firstDayOfWeek, lastDayOfWeek));

            //It clears the items of the ComboBox first
            comboBoxCar.Items.Clear();
            //comboBoxCar.SelectedItem = -1;
            //It adds the cars to the combobox. First the Assigned
            if (assignedCarsToInstructors.Count > 0)
            {
                for (int j=0; j<instructorsUserNames.Count;j++)
                { 
                    if (instructorsUserNames[j]==comboBoxInstructor.Text && assignedCarsToInstructors[j]!="")
                    {
                        comboBoxCar.Items.Add(assignedCarsToInstructors[j]);
                        comboBoxCar.Text = assignedCarsToInstructors[j];
                    }
                }
            }
            else
            {
                comboBoxCar.SelectedItem = -1;
                comboBoxCar.Text = "";
            }
            //It adds the available cars to the ComboBox
            if (availableCars.Count > 0)
            {
                for (int i = 0; i < availableCars.Count; i++)
                {
                    comboBoxCar.Items.Add(availableCars[i]);
                }
            }
        }

        //It creates the ListView Report for the Week
        private void createListViewDayReport(DateTime myDate)
        {
            //It gets the usernames of the Instructors and creates the columns of the ListView
            ControlFunctions.createListViewColumns(listViewDay, "Time", instructorsUserNames, "Total", 60, 65, 55);
            //It gets the times of the day and creates the Items of the ListView
            timesOfDate = DBData.getTimesOfDay(dateTimePickerWeek.Value);
            //It adds the total per Instructor
            timesOfDate.Add("Total");
            //It creates the ListView Items
            ControlFunctions.createListViewItems(listViewDay, timesOfDate);

            //It creates the array of arrays of hours scheduled per Time and Instructor plus one for the Totals
            string[][] hoursScheduledMatrix = new string[timesOfDate.Count][];
            for (int j = 0; j < timesOfDate.Count; j++)
            {
                hoursScheduledMatrix[j] = new string[instructorsUserNames.Count + 1];
            }
            //It initializes the arrays to zeros
            for (int j = 0; j < instructorsUserNames.Count; j++)
            {
                for (int i = 0; i < timesOfDate.Count; i++)
                {
                    hoursScheduledMatrix[i][j] = "0";
                }
            }
            //It fills in the arrays
            for (int j = 0; j < instructorsUserNames.Count; j++)
            {
                List<string> timesScheduled = new List<string>();
                //It gets the Schedule for each Instructor for the selected Date
                timesScheduled = DBData.getInstructorScheduleForDate(instructorsUserNames[j], myDate);
                for (int i = 0; i < timesOfDate.Count; i++)
                {
                    foreach (string time in timesScheduled)
                    {
                        if (timesOfDate[i] == time)
                        {
                            hoursScheduledMatrix[i][j] = "1";
                            break;
                        }
                        else
                        {
                            hoursScheduledMatrix[i][j] = "0";
                        }
                    }
                }
            }
            //It adds the Totals per Time
            for (int i = 0; i < timesOfDate.Count; i++)
            {
                hoursScheduledMatrix[i][instructorsUserNames.Count] = "0";
                for (int j = 0; j < instructorsUserNames.Count; j++)
                {
                    hoursScheduledMatrix[i][instructorsUserNames.Count] = (int.Parse(hoursScheduledMatrix[i][instructorsUserNames.Count]) + int.Parse(hoursScheduledMatrix[i][j])).ToString();
                }
            }
            //It adds the Totals per Instructor
            for (int j = 0; j < instructorsUserNames.Count; j++)
            {
                hoursScheduledMatrix[timesOfDate.Count - 1][j] = "0";
                for (int i = 0; i < timesOfDate.Count - 1; i++)
                {
                    hoursScheduledMatrix[timesOfDate.Count - 1][j] = (int.Parse(hoursScheduledMatrix[timesOfDate.Count - 1][j]) + int.Parse(hoursScheduledMatrix[i][j])).ToString();
                }
            }
            //It copies all the data to the listView in the Subitems
            ControlFunctions.createListViewSubitems(listViewDay, hoursScheduledMatrix);
        }


        //********************************************* Methods interacting with the Database *******************************************

        //It gets the car assigned for a Instructor in a week
        private string getCarsAssignedToInstructor(string instructor, DateTime myDate1, DateTime myDate2)
        {
            String carsAssigned = "";

            string carAssignedQuery = $"SELECT DISTINCT carLicense FROM Appointments WHERE usernameInstructor = '{instructor}' AND slotDate >= '{ControlFunctions.formatToSQLDate(myDate1)}' AND slotDate <= '{ControlFunctions.formatToSQLDate(myDate2)}' AND carLicense IS NOT null";
            SQL.selectQuery(carAssignedQuery);
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    //It saves the data into a list
                    carsAssigned=SQL.read[0].ToString();
                }
            }
            return carsAssigned;
        }

        //It gets the available cars for the week
        private List<string> getAvailableCars(DateTime myDate1, DateTime myDate2)
        {
            List<String> availableCarsList = new List<string>();

            //It creates the rows as per slot times
            string availableCarsQuery = $"SELECT license FROM Cars WHERE license NOT IN (SELECT DISTINCT carLicense FROM Appointments WHERE slotDate >= '{ControlFunctions.formatToSQLDate(myDate1)}' AND slotDate <= '{ControlFunctions.formatToSQLDate(myDate2)}' AND carLicense IS NOT null)";
            //It gets data from database
            SQL.selectQuery(availableCarsQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    //It saves the data into a list
                    availableCarsList.Add(SQL.read[0].ToString());
                }
            }
            return availableCarsList;
        }

        //It inserts the new Schedules for the selected Date and all the Instructors confirming the Schedules
        private void insertNewSchedules(string myDate, string[][] schedules)
        {
            //It checks the data from the matrix coming from the ListView
            for (int i = 1; i < schedules.Length - 1; i++)
            {
                for (int j = 0; j < schedules[0].Length - 1; j++)
                {
                    //The information to proceed with the INSERT query
                    string instructor = instructorsUserNames[i - 1];
                    string carAssignedForWeek = getCarsAssignedToInstructor(instructor, firstDayOfWeek, lastDayOfWeek);
                    //string carLicense = cars[i - 1];
                    string myTime = timesOfDate[j];
                    string value = schedules[i][j];
                    int slotId = 1;
                    //IT checks that value=1
                    if (value != "0")
                    {
                        if (!DBData.checkExistingAppointment(instructor, myDate, myTime))
                        {
                            var insertQuery = "";
                            if (carAssignedForWeek=="")
                            {
                                insertQuery = $"INSERT INTO Appointments (usernameInstructor, idTimeSlot, slotDate, slotTime, confirmed) VALUES('{instructor}', {slotId}, '{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate))}', '{myTime}', 1)";
                            }
                            else
                            {
                                insertQuery = $"INSERT INTO Appointments (usernameInstructor, idTimeSlot, slotDate, slotTime, carLicense, confirmed) VALUES('{instructor}', {slotId}, '{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate))}', '{myTime}', '{carAssignedForWeek}', 1)";
                            }
                            SQL.executeQuery(insertQuery);
                        }
                    }
                }
            }
            MessageBox.Show("Instructors Schedules saved successfully. Now assign a car to the required Instructors.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();

            Delete_select login = new Delete_select();

            login.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();

            LoginPage login = new LoginPage();

            login.ShowDialog();

            this.Close();
        }
    }
}
