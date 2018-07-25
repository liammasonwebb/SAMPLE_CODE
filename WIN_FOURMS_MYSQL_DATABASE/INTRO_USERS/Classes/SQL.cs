using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace INTRO_USERS
{
    //Name:
    //Student ID:
    class SQL
    {
        //generates the connection to the database       
        //Make sure that in the Database connection you put your Database connection here:
        //public static SqlConnection con = new SqlConnection(@"Data Source=localhost\.;Database=DrivingAcademy;Integrated Security=True");
        public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C720GG2\LMW;Database=D4_9982900;Integrated Security=True");
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataReader read;

        // This excecutres the query, used mainly for 
        // insert/delete/update statements etc. where we don't need
        // to read from what we are doing.
        public static void executeQuery(string query)
        {
            //try catch to catch any unforseen errors gracefully
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                MessageBox.Show($"The error {ex} has occurred. Please contact Administrator.");
                return;
            }
        }

        // Generates an SQL query based on the input
        // query e.g. "SELECT * FROM staff"
        public static void selectQuery(string query)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                read = cmd.ExecuteReader();
            }
            catch (Exception )
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                return;
            }
        }

        // Prints out the ID  based on the query givin into a combo box
        public static void editComboBoxItems(ComboBox comboBox, string query)
        {
            bool clear = true;

            //gets data from database
            SQL.selectQuery(query);
            //Check that there is something to write brah
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    if (comboBox.Text == SQL.read[0].ToString())
                    {
                        clear = false;
                    }
                }
            }

            //gets data from database
            SQL.selectQuery(query);
            //if nothing in the comboBox then we need to clear it
            if (clear)
            {
                comboBox.Text = "";
                comboBox.Items.Clear();
            }

            // this will print whatever is in the database to the combobox
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    comboBox.Items.Add(SQL.read[0].ToString());
                }
            }
        }

    }
}
