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
    public partial class ClientConsole : Form
    {
        const string slotAvailable = "available";
        const string slotReserved = "reserved";
        List<String> instructorsUserNames = new List<string>();
        List<String> timesOfDate = new List<string>();
        List<List<string>> clientAppointments = new List<List<string>>();
        DateTime selectedDate;
        string appointmentTime="";
        string instructor="";
        string userName;

        public ClientConsole(string clientUsername)
        {
            InitializeComponent();
            //It loads the client user name variable
            userName = clientUsername;
            //It loads the Instructor User Names
            instructorsUserNames = DBData.getInstructorsUsernames();
            labelUserName.Text = userName;
            //It loads the Appointments for the Client
            clientAppointments = getClientAppointments(userName, DateTime.Today);
            //It creates the Appointments ListView
            listViewAppointments.Items.Clear();
            createListViewAppointmentsReport();
        }


        //********************************************* Event Methods  *****************************************************************

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            //It loads the Times of the selected Date
            selectedDate = dateTimePickerDate.Value;
            timesOfDate = DBData.getTimesOfDay(selectedDate);

            //It makes the ListViews visibles
            listViewAppointmentSelection.Visible = true;
            listViewAppointments.Visible = true;
            //It creates the Appointment Selection ListView
            ControlFunctions.clearListViewReport(listViewAppointmentSelection);
            createListViewAppointmentSelectionReport();

            //It loads the Appointments for the Client
            clientAppointments=getClientAppointments(userName, DateTime.Today);
        }

        //It obtains the desired Appointment from the ListView 
        private void listViewAppointmentSelection_MouseDown(object sender, MouseEventArgs e)
        {
            var info = listViewAppointmentSelection.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                var row = info.Item.Index;
                var col = info.Item.SubItems.IndexOf(info.SubItem);
                if (info.SubItem != null)
                {
                    var value = info.Item.SubItems[col].Text;
                    if (col > 0)
                    {
                        switch (value)
                        {
                            case slotAvailable:
                                appointmentTime = listViewAppointmentSelection.Items[row].Text;
                                instructor = listViewAppointmentSelection.Columns[col].Text;
                                if (checkAppointmentDuplicity())
                                {
                                    MessageBox.Show("There is already an Appointment that day at that time with another Instructor. Please delete the Appointment first.");
                                }
                                else
                                {
                                    if (checkReservationDuplicity())
                                    {
                                        MessageBox.Show("You cannot book two Appointments at once. Click in other reserved Appointment to free it first.");
                                    }
                                    else
                                    {
                                        ControlFunctions.changeListViewSubItemValue(listViewAppointmentSelection, row, col, slotReserved);
                                        labelAppointmentSelected.Text = $"{selectedDate.ToString("d")} at {appointmentTime} with {instructor}";
                                    }
                                }
                                break;
                            case slotReserved:
                                appointmentTime = "";
                                instructor = "";
                                ControlFunctions.changeListViewSubItemValue(listViewAppointmentSelection, row, col, slotAvailable);
                                labelAppointmentSelected.Text = "No appointment selected";
                                break;
                        }
                    }
                }
            }
        }

        //It saves the Appointment
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //It updates the DB
            if (instructor!="" && appointmentTime!="")
            {
                bookAppointment();
                //It loads the Appointments for the Client
                clientAppointments = getClientAppointments(userName, DateTime.Today);
                //It refreshes the Appointments ListView
                listViewAppointments.Items.Clear();
                createListViewAppointmentsReport();
                //It refreshes the Appointment Selection ListView
                ControlFunctions.clearListViewReport(listViewAppointmentSelection);
                createListViewAppointmentSelectionReport();
                labelAppointmentSelected.Text = "No appointment selected";
                appointmentTime = "";
                MessageBox.Show("Appointment booked successfully.");
            }
            else
            {
                MessageBox.Show("Please select a slot first.");
            }
        }

        //It deletes the Appointment
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listViewAppointments.SelectedItems.Count>0)
            {
                DialogResult clientDecision = MessageBox.Show("Are you sure you want to delete that Appointment?", "Appointment Deletion", MessageBoxButtons.YesNo);
                switch (clientDecision)
                {
                    case DialogResult.Yes:
                        var myDate = listViewAppointments.SelectedItems[0].Text;
                        var myTime = listViewAppointments.SelectedItems[0].SubItems[1].Text;
                        var myInstructor = listViewAppointments.SelectedItems[0].SubItems[2].Text;
                        //It updates the DB freing the client
                        freeClientAppointment(myDate, myTime, myInstructor);
                        //It loads the Appointments for the Client
                        clientAppointments = getClientAppointments(userName, DateTime.Today);
                        //It refreshes the Appointments ListView
                        listViewAppointments.Items.Clear();
                        createListViewAppointmentsReport();
                        //It refreshes the Appointment Selection ListView
                        ControlFunctions.clearListViewReport(listViewAppointmentSelection);
                        createListViewAppointmentSelectionReport();
                        MessageBox.Show("Appointment deleted successfully.");
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select an Appointment first.");
            }
        }


        //********************************************* Methods ************************************************************************

        //It checks if here is any other reserved in the ListView
        private bool checkReservationDuplicity()
        {
            //It obtains the new schedule from the Day ListView
            string[][] LVData = ControlFunctions.obtainDataFromListView(listViewAppointmentSelection);
            bool duplicity=false;
            //It checks the data from the matrix coming from the ListView
            for (int i = 1; i < LVData.Length; i++)
            {
                for (int j = 0; j < LVData[0].Length; j++)
                {
                    if(LVData[i][j]== slotReserved)
                    {
                        duplicity = true;
                        break;
                    }
                }
            }
            return duplicity;
        }

        //It checks that there is no other Appointment reserved for that Client the same day at the same time
        private bool checkAppointmentDuplicity()
        {
            bool duplicity = false;

            for (int i = 0; i < clientAppointments[0].Count; i++)
            {
                if (DateTime.Parse(clientAppointments[0][i]).ToString("d")==selectedDate.ToString("d") && clientAppointments[1][i] == appointmentTime)
                {
                    duplicity = true;
                }
            }
            return duplicity;
        }

        //It creates the ListView Report for the Week
        private void createListViewAppointmentsReport()
        {
            //It fills in the ListView existing Columns with the data obtained from the DB
            for (int i = 0; i < clientAppointments[0].Count;i++)
            {
                listViewAppointments.Items.Add(DateTime.Parse(clientAppointments[0][i]).ToString("d"));
                listViewAppointments.Items[i].SubItems.Add(clientAppointments[1][i]);
                listViewAppointments.Items[i].SubItems.Add(clientAppointments[2][i]);
            }
            listViewAppointments.Refresh();
        }

        //It creates the ListView Report for the Week
        private void createListViewAppointmentSelectionReport()
        {
            //It gets the usernames of the Instructors and creates the columns of the ListView
            ControlFunctions.createListViewColumns(listViewAppointmentSelection, "Time", instructorsUserNames, "", 60, 65, 0);
            //It creates the ListView Items
            ControlFunctions.createListViewItems(listViewAppointmentSelection, timesOfDate);

            //It creates the array of arrays of hours scheduled per Time and Instructor
            string[][] hoursScheduledMatrix = new string[timesOfDate.Count][];
            for (int j = 0; j < timesOfDate.Count; j++)
            {
                hoursScheduledMatrix[j] = new string[instructorsUserNames.Count];
            }
            //It initializes the arrays to zeros
            for (int j = 0; j < instructorsUserNames.Count; j++)
            {
                for (int i = 0; i < timesOfDate.Count; i++)
                {
                    hoursScheduledMatrix[i][j] = "";
                }
            }
            //It fills in the arrays
            for (int j = 0; j < instructorsUserNames.Count; j++)
            {
                List<string> timeScheduled = new List<string>();
                //It gets the Schedule for each Instructor for the selected Date excluding already existing Appointments
                timeScheduled = DBData.getInstructorFreeScheduleForDate(instructorsUserNames[j], selectedDate);
                for (int i = 0; i < timesOfDate.Count; i++)
                {
                    foreach (string time in timeScheduled)
                    {
                        if (timesOfDate[i] == time)
                        {
                            hoursScheduledMatrix[i][j] = "available";
                            break;
                        }
                        else
                        {
                            hoursScheduledMatrix[i][j] = "";
                        }
                    }
                }
            }
            //It copies all the data to the listView in the Subitems
            ControlFunctions.createListViewSubitems(listViewAppointmentSelection, hoursScheduledMatrix);
        }


        //********************************************* Methods interacting with the Database *******************************************
        
       
        //It deletes an Appointment
        private void freeClientAppointment(string myDate, string myTime, string myInstructor)
        {
            string deleteQuery = $"UPDATE Appointments SET usernameClient=NULL WHERE usernameInstructor='{myInstructor}' AND slotDate='{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate))}' AND slotTime='{myTime}'";
            SQL.executeQuery(deleteQuery);
        }

        //It inserts the Appointment Data in the DB
        private void bookAppointment()
        {
            string updateQuery = $"UPDATE Appointments SET usernameClient='{userName}' WHERE usernameInstructor='{instructor}' AND slotDate='{ControlFunctions.formatToSQLDate(selectedDate)}' AND slotTime='{appointmentTime}'";
            SQL.executeQuery(updateQuery);
        }

        //It gets the Appointments of the Client from today
        private List<List<string>> getClientAppointments( string userName, DateTime myDate)
        {
            //It creates a List for the Appointments
            List<List<string>> clientAppointmentsList = new List<List<string>>();
            //It creates three lists for each of the interesting fields to extract from the DB
            List<String> clientAppointmentDatesList = new List<string>();
            List<String> clientAppointmentTimesList = new List<string>();
            List<String> clientAppointmentInstructorsList = new List<string>();

            //It obtains the data from the DB
            string clientAppointmentsQuery = $"SELECT slotDate, slotTime, usernameInstructor FROM Appointments WHERE usernameClient='{userName}' AND slotDate >= '{ControlFunctions.formatToSQLDate(myDate)}' ORDER BY slotDate, slotTime";
            SQL.selectQuery(clientAppointmentsQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    //It saves the data into a List
                    clientAppointmentDatesList.Add(SQL.read[0].ToString());
                    clientAppointmentTimesList.Add(SQL.read[1].ToString());
                    clientAppointmentInstructorsList.Add(SQL.read[2].ToString());
                }
            }
            //It adds the sublists to the Appointments List
            clientAppointmentsList.Add(clientAppointmentDatesList);
            clientAppointmentsList.Add(clientAppointmentTimesList);
            clientAppointmentsList.Add(clientAppointmentInstructorsList);

            return clientAppointmentsList;
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
