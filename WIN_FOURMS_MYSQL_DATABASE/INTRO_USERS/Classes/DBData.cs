using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace INTRO_USERS
{
    class DBData
    {

        //It checks that the Instructor has not assigned more than 8 hours per Day
        public static int getHoursAssignedPerDay(DateTime myDate, string instructor)
        {
            //bool hoursLower8 = true;
            int hours = 0;
            string slotNumberQuery = $"SELECT COUNT(id) FROM Appointments WHERE usernameInstructor = '{instructor}' AND slotDate = '{ControlFunctions.formatToSQLDate(myDate)}'";
            SQL.selectQuery(slotNumberQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())

                {
                    hours = int.Parse(SQL.read[0].ToString());
                    //if (int.Parse(SQL.read[0].ToString())>8)
                    //{
                    //    hoursLower8 = false;
                    //}
                }
            }
            return hours;
            //return hoursLower8;
        }

        //It checks that the Instructor has not assigned more than 40 hours per Week *******************Not used
        public static int getHoursAssignedPerWeek(DateTime myDate1, DateTime myDate2,string instructor)
        {
            //bool hoursLower40 = true;
            int hours = 0;
            string slotNumberQuery = $"SELECT COUNT(id) FROM Appointments WHERE usernameInstructor = '{instructor}' AND slotDate >= '{ControlFunctions.formatToSQLDate(myDate1)}' AND slotDate <= '{ControlFunctions.formatToSQLDate(myDate2)}'";
            SQL.selectQuery(slotNumberQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    hours = int.Parse(SQL.read[0].ToString());
                    //if (int.Parse(SQL.read[0].ToString()) > 40)
                    //{
                    //    hoursLower40 = false;
                    //}
                }
            }
            return hours;
            //return hoursLower40;
        }

        //It updates the Car assignations
        public static void updateCarAssignation(string car, string instructor, DateTime myDate1, DateTime myDate2)
        {
            try
            {
                string updateQuery = $"UPDATE Appointments SET carLicense='{car}' WHERE usernameInstructor='{instructor}' AND slotDate>= '{ControlFunctions.formatToSQLDate(myDate1)}' AND slotDate<= '{ControlFunctions.formatToSQLDate(myDate2)}'";
                SQL.executeQuery(updateQuery);
                MessageBox.Show("Car Assignations saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was a problem when updating the Car assignations: {ex}.");

            }
        }

        //It deletes the existing Schedules for a Instructor and between the Dates that don't have an Appointment with a Client nor have been confirmed by Admin
        public static void deleteExistingSchedulesForInstructorAndDates(string instructor, string myDate1, string myDate2)
        {
            var deleteQuery = $"DELETE FROM Appointments WHERE usernameInstructor='{instructor}' AND slotDate>='{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate1))}' AND slotDate<='{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate2))}' AND usernameClient IS null AND confirmed is null";
            SQL.executeQuery(deleteQuery);
        }

        //It deletes the existing Schedules for all the Instructors and the Date that don't have an Appointment with a Client
        public static void deleteExistingSchedulesForInstructorsAndDate(string myDate)
        {
            var deleteQuery = $"DELETE FROM Appointments WHERE slotDate='{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate))}' AND usernameClient IS null";
            SQL.executeQuery(deleteQuery);
        }

        //It checks if the Schedule was alredy confirmed by the Admin not to delete it
        public static bool checkAppointmentConfirmedByAdmin(string myDate, string myTime, string instructor)
        {
            List<string> timesScheduled = new List<string>();
            timesScheduled = DBData.getInstructorConfirmedScheduleForDate(instructor, DateTime.Parse(myDate));
            bool okToRemove = true;
            foreach (string time in timesScheduled)
            {
                if (myTime == time)
                {
                    okToRemove = false;
                }
            }
            return okToRemove;
        }

        //It checks if there is already an Appointment made with a customer not to delete it
        public static bool checkAppointmentOccupiedByClient(string myDate, string myTime, string instructor)
        {
            List<string> timesScheduled = new List<string>();
            timesScheduled = DBData.getInstructorOccupiedScheduleForDate(instructor, DateTime.Parse(myDate));
            bool okToRemove = true;
            foreach (string time in timesScheduled)
            {
                if (myTime == time)
                {
                    okToRemove = false;
                }
            }
            return okToRemove;
        }

        //It checks if that Date and Time exist Slots available
        public static bool checkExistingsStlots(DateTime myDate, string myTime)
        {
            bool existSlots = false;

            string slotTimeQuery = $"SELECT slotTime FROM TimeSlots WHERE slotDate = '{ControlFunctions.formatToSQLDate(myDate)}' AND slotTime = '{myTime}'";
            //It gets data from database
            SQL.selectQuery(slotTimeQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                existSlots = true;
            }
            return existSlots;
        }

        //It gets the FREE times scheduled for an instructor in a date
        public static List<string> getInstructorFreeScheduleForDate(string instructor, DateTime myDate)
        {
            List<String> instructorSchedule = new List<string>();

            string slotTimeQuery = "SELECT slotTime FROM Appointments WHERE usernameInstructor= '" + instructor + "' AND slotDate = '" + ControlFunctions.formatToSQLDate(myDate) + "' AND usernameClient IS null AND confirmed=1";
            //It gets data from database
            SQL.selectQuery(slotTimeQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    instructorSchedule.Add(SQL.read[0].ToString());
                }
            }
            return instructorSchedule;
        }

        //It gets the OCCUPIED times scheduled for an instructor in a date
        public static List<string> getInstructorConfirmedScheduleForDate(string instructor, DateTime myDate)
        {
            List<String> instructorSchedule = new List<string>();

            string slotTimeQuery = "SELECT slotTime FROM Appointments WHERE usernameInstructor= '" + instructor + "' AND slotDate = '" + ControlFunctions.formatToSQLDate(myDate) + "' AND confirmed=1";
            //It gets data from database
            SQL.selectQuery(slotTimeQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    instructorSchedule.Add(SQL.read[0].ToString());
                }
            }
            return instructorSchedule;
        }

        //It gets the OCCUPIED times scheduled for an instructor in a date
        public static List<string> getInstructorOccupiedScheduleForDate(string instructor, DateTime myDate)
        {
            List<String> instructorSchedule = new List<string>();

            string slotTimeQuery = "SELECT slotTime FROM Appointments WHERE usernameInstructor= '" + instructor + "' AND slotDate = '" + ControlFunctions.formatToSQLDate(myDate) + "' AND usernameClient IS NOT null";
            //It gets data from database
            SQL.selectQuery(slotTimeQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    instructorSchedule.Add(SQL.read[0].ToString());
                }
            }
            return instructorSchedule;
        }

        //It gets the times scheduled for an instructor in a date
        public static List<string> getInstructorScheduleForDate(string instructor, DateTime myDate)
        {
            List<String> instructorSchedule = new List<string>();

            string slotTimeQuery = "SELECT slotTime FROM Appointments WHERE usernameInstructor= '" + instructor + "' AND slotDate = '" + ControlFunctions.formatToSQLDate(myDate) + "'";
            //It gets data from database
            SQL.selectQuery(slotTimeQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    instructorSchedule.Add(SQL.read[0].ToString());
                }
            }
            return instructorSchedule;
        }

        //It gets the number of hours scheduled in a day for an instructor
        public static string getInstructorHoursScheduledForDate(string instructor, DateTime myDate)
        {
            string hoursScheduled;
            //It creates the rows as per slot times
            string hoursQuery = $"SELECT COUNT(id) FROM Appointments WHERE usernameInstructor='{instructor}' AND slotDate='{ControlFunctions.formatToSQLDate(myDate)}'";
            //It gets data from database
            SQL.selectQuery(hoursQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                SQL.read.Read();
                hoursScheduled = SQL.read[0].ToString();
            }
            else
            {
                hoursScheduled = "";
            }
            return hoursScheduled;
        }
        
        //It gets the usernames of the Instructors
        public static List<string> getInstructorsUsernames()
        {
            List<String> instructorsUserNamesList = new List<string>();

            //It creates the rows as per slot times
            string instructorsQuery = "SELECT username FROM Instructors";
            //It gets data from database
            SQL.selectQuery(instructorsQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    //It saves the data into a list
                    instructorsUserNamesList.Add(SQL.read[0].ToString());
                }
            }
            return instructorsUserNamesList;
        }

        //It gets the usernames of the Instructors
        public static List<string> getTimesOfDay(DateTime myDate1)
        {
            List<String> timesList = new List<string>();

            //It creates the rows as per slot times
            string slotTimesQuery = "SELECT DISTINCT slotTime FROM TimeSlots WHERE slotDate= '" + ControlFunctions.formatToSQLDate(myDate1) + "'";
            //It gets data from database
            SQL.selectQuery(slotTimesQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    //It saves the data into a list
                    timesList.Add(SQL.read[0].ToString());
                }
            }
            return timesList;
        }

        //It checks if there is already an Appointment in the DB for the Instructor, Date and Time
        public static bool checkExistingAppointment(string instructor, string myDate, string myTime)
        {
            bool existAppointment = false;
            string slotTimeQuery = $"SELECT slotTime FROM Appointments WHERE usernameInstructor= '{instructor}' AND slotDate = '{ControlFunctions.formatToSQLDate(DateTime.Parse(myDate))}' AND slotTime='{myTime}'";
            //It gets data from database
            SQL.selectQuery(slotTimeQuery);
            //It checks that there is something to write
            if (SQL.read.HasRows)
            {
                existAppointment = true;
            }
            return existAppointment;
        }

    }
}
