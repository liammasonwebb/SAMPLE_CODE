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
    public partial class InstructorConsole : Form
    {
        const int daysOfWeek = 7;
        List<String> timesOfDate = new List<string>();
        DateTime firstDayOfWeek;
        DateTime lastDayOfWeek;
        string instructorUserName;

        public InstructorConsole(string username)
        {
            InitializeComponent();
            instructorUserName = username;
            comboBoxInstructor.Items.Add(instructorUserName);
            comboBoxInstructor.Text = instructorUserName;
        }


        //********************************************* Event Methods  *****************************************************************

        //It creates the ListView for the instructor to create his Schedule
        private void dateTimePickerWeek_ValueChanged(object sender, EventArgs e)
        {
            listViewWeek.Visible = true;
            //clearVariables();
            //It loads the Times of the selected Date
            timesOfDate = DBData.getTimesOfDay(dateTimePickerWeek.Value);
            //It creates the Day ListView
            ControlFunctions.clearListViewReport(listViewWeek);
            createlistViewWeekReport(dateTimePickerWeek.Value);

        }

        //It obtains the slot clicked and activates or desactivates it
        private void listViewWeek_MouseDown(object sender, MouseEventArgs e)
        {
            var info = listViewWeek.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                var row = info.Item.Index;
                var col = info.Item.SubItems.IndexOf(info.SubItem);
                if (info.SubItem != null)
                {
                    var value = info.Item.SubItems[col].Text;
                    if (col > 0 && col < daysOfWeek+1 && row < timesOfDate.Count-1)
                    {
                        if (value == "0")
                        {
                            //It checks that there are Slots available for the Instructor to assign his availability
                            if (DBData.checkExistingsStlots(DateTime.Parse(listViewWeek.Columns[col].Text),listViewWeek.Items[row].Text))
                            {
                                //It checks that the Instructor has not selected more than 8 hours per Day and 40 per Week
                                if (int.Parse(listViewWeek.Items[listViewWeek.Items.Count - 1].SubItems[col].Text)<8 && int.Parse(listViewWeek.Items[listViewWeek.Items.Count-1].SubItems[listViewWeek.Columns.Count-1].Text) < 40)
                                {
                                    ControlFunctions.changeListViewSubItemValue(listViewWeek, row, col, "1");
                                    ControlFunctions.recalculateTotal(listViewWeek, row, col, 1);
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
                            //It checks if the Appointment is already booked by a Client
                            if (DBData.checkAppointmentConfirmedByAdmin(listViewWeek.Columns[col].Text, listViewWeek.Items[row].Text, instructorUserName))
                            {
                                ControlFunctions.changeListViewSubItemValue(listViewWeek, row, col, "0");
                                ControlFunctions.recalculateTotal(listViewWeek, row, col, 0);
                            }
                            else
                            {
                                MessageBox.Show("That Slot cannot be changed because it was confirmed by the Administrator.");
                            }
                        }
                    }
                }
            }
        }

        //It saves the Schedule for the Week************************************take care with the confirmed ones from the Admin, dont delete them and dont write them again
        private void buttonSaveSchedule_Click(object sender, EventArgs e)
        {
            if (listViewWeek.Items.Count>0)
            {
                //It obtains the new schedule from the Day ListView
                string[][] LVData = ControlFunctions.obtainDataFromListView(listViewWeek);
                //It deletes the schedules for that Date and Instructor in the DB
                DBData.deleteExistingSchedulesForInstructorAndDates(instructorUserName, firstDayOfWeek.ToString("d"), lastDayOfWeek.ToString("d"));
                //It inserts the new Schedules for that Date and instructor in the DB
                insertNewSchedulesForInstructor(instructorUserName, LVData);
                //It actualizes the Week ListView
                ControlFunctions.clearListViewReport(listViewWeek);
                createlistViewWeekReport(dateTimePickerWeek.Value);
            }
            else
            {
                MessageBox.Show("Please select first a date and plan a Schedule.");
            }
        }

        //It cancels the Schedule for the Week and retrieves the data from the DB
        private void buttonCancelSchedule_Click(object sender, EventArgs e)
        {
            //It actualizes the Week ListView
            ControlFunctions.clearListViewReport(listViewWeek);
            createlistViewWeekReport(dateTimePickerWeek.Value);
        }

        
        //********************************************* Methods ************************************************************************

        //It creates the list with the days of the week as per day selected in the DateTime Picker
        private List<string> createDaysOfWeekList()
        {
            //It calculates the first and last date of the week
            int dayOfWeekSelected = (int)dateTimePickerWeek.Value.DayOfWeek;
            firstDayOfWeek = dateTimePickerWeek.Value.Date.AddDays(-dayOfWeekSelected + 1);
            lastDayOfWeek = firstDayOfWeek.Date.AddDays(daysOfWeek-1);

            //It creates a list of the dates of the week
            List<String> datesList = new List<string>();
            for (int j = 0; j < daysOfWeek; j++)
            {
                datesList.Add(firstDayOfWeek.AddDays(j).ToString("d"));
            }
            return datesList;
        }

        //It creates the ListView Report for the Week
        private void createlistViewWeekReport(DateTime myDate)
        {
            //It creates a list of the dates of the week
            List<String> weekDatesList = new List<string>(createDaysOfWeekList());
            //It gets the usernames of the Instructors and creates the columns of the ListView
            ControlFunctions.createListViewColumns(listViewWeek, "Time", weekDatesList, "Total", 60, 75, 55);
            //It gets the times of the day and creates the Items of the ListView
            timesOfDate = DBData.getTimesOfDay(dateTimePickerWeek.Value);
            //It adds the total per Instructor
            timesOfDate.Add("Total");
            //It creates the ListView Items
            ControlFunctions.createListViewItems(listViewWeek, timesOfDate);

            //It creates the array of arrays of hours scheduled per Time and Instructor plus one for the Totals
            string[][] hoursScheduledMatrix = new string[timesOfDate.Count][];
            for (int j = 0; j < timesOfDate.Count; j++)
            {
                hoursScheduledMatrix[j] = new string[weekDatesList.Count + 1];
            }
            //It initializes the arrays to zeros
            for (int j = 0; j < weekDatesList.Count; j++)
            {
                for (int i = 0; i < timesOfDate.Count; i++)
                {
                    hoursScheduledMatrix[i][j] = "0";
                }
            }
            //It fills in the arrays
            for (int j = 0; j < weekDatesList.Count-1; j++)
            {
                List<string> timesScheduled = new List<string>();
                //It gets the Schedule for each Instructor for the selected Date
                timesScheduled = DBData.getInstructorScheduleForDate(instructorUserName, DateTime.Parse(weekDatesList[j]));
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
                hoursScheduledMatrix[i][weekDatesList.Count] = "0";
                for (int j = 0; j < weekDatesList.Count; j++)
                {
                    hoursScheduledMatrix[i][weekDatesList.Count] = (int.Parse(hoursScheduledMatrix[i][weekDatesList.Count]) + int.Parse(hoursScheduledMatrix[i][j])).ToString();
                }
            }
            //It adds the Totals per Day
            for (int j = 0; j < weekDatesList.Count; j++)
            {
                hoursScheduledMatrix[timesOfDate.Count - 1][j] = "0";
                for (int i = 0; i < timesOfDate.Count - 1; i++)
                {
                    hoursScheduledMatrix[timesOfDate.Count - 1][j] = (int.Parse(hoursScheduledMatrix[timesOfDate.Count - 1][j]) + int.Parse(hoursScheduledMatrix[i][j])).ToString();
                }
            }
            //It adds the Total per Week
            hoursScheduledMatrix[timesOfDate.Count-1][weekDatesList.Count] = "0";
            for (int i = 0; i < timesOfDate.Count-1; i++)
            {
                hoursScheduledMatrix[timesOfDate.Count-1][weekDatesList.Count] = (int.Parse(hoursScheduledMatrix[timesOfDate.Count-1][weekDatesList.Count]) + int.Parse(hoursScheduledMatrix[i][weekDatesList.Count])).ToString();
            }

            //It copies all the data to the listView in the Subitems
            ControlFunctions.createListViewSubitems(listViewWeek, hoursScheduledMatrix);
        }


        //********************************************* Methods interacting with the Database *******************************************

        //It inserts the new Schedules for the selected Date and all the Instructors
        private void insertNewSchedulesForInstructor(string instructor, string[][] schedules)
        {
            //It checks the data from the matrix coming from the ListView
            for (int i = 1; i < schedules.Length - 1; i++)  //days
            {
                string myDate = listViewWeek.Columns[i].Text;
                for (int j = 0; j < schedules[0].Length - 1; j++)   //hours
                {
                    //The information to proceed with the INSERT query
                    string myTime = timesOfDate[j];
                    string value = schedules[i][j];
                    int slotId = 1;
                    //IT checks that value=1
                    if (value != "0")
                    {
                        if (!DBData.checkExistingAppointment(instructor,myDate, myTime))
                        {
                            var insertQuery = $"INSERT INTO Appointments (usernameInstructor, idTimeSlot, slotDate, slotTime) VALUES('{instructor}', {slotId}, '{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate))}', '{myTime}')";
                            SQL.executeQuery(insertQuery);
                        }
                    }
                }
            }
            MessageBox.Show("Instructors Schedules saved successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginPage register = new LoginPage();

            register.ShowDialog();

            this.Close();
        }
    }
}
