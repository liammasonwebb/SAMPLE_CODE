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
    //Name: Alfredo Puche Lozoya
    //Student ID: 10009723

    public partial class LoginPage : Form
    {
        //List of options for the selection of the user type in a combobox.
        //This is because we have the users divided in three tables instead of one.
        List<string> comboBoxList = new List<string>() { "Clients", "Instructors", "Admins" };
        
        //This is the first method called when the program form loads.
        public LoginPage()
        {
            InitializeComponent();
            textBoxUserName.MaxLength = 32;         //max textbox character count
            //This line of code allows us to obscure the password visually and limit the max chars in textbox
            textBoxPassword.PasswordChar = '*';     //password character to hide password characters
            textBoxPassword.MaxLength = 16;         //max textbox character count
            //It loads the User Type Combobox. We need this to look for the user in the proper table
            loadComboBox(comboBoxUserType, comboBoxList);
            //It selects by default the Clients option to make it easier for them
            comboBoxUserType.Text = comboBoxList[0];
        }


        // Clicked when user decides they are ready to log in, 
        // Will get username and password, use that to query database and check that username and password are correct.
        // A message box will be used to state whether or not we logged in successfully
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = "", password = "";

            //It checks that the text boxes has something typed in it using a method
            bool hasText = checkTextBoxes();
            if (!hasText)
            {
                MessageBox.Show("Please make sure all fields have data.");
                comboBoxUserType.Focus();
                return;
            }

            //(1) GET the username and password from the text boxes, is good to put them in a try catch
            try
            {
                username = textBoxUserName.Text.Trim();
                password = textBoxPassword.Text.Trim();
            }
            catch
            {
                //Error message, more useful when you are storing numbers etc. into the database.
                MessageBox.Show("Username or Password given is in an incorrect format.");
                return;
            }

            //(2) SELECT statement getting all data from users, i.e. SELECT * FROM Users
            //(3) IF it returns some data, THEN check each username and password combination, ELSE There are no registered users
            string message = checkLogin(username, password, comboBoxUserType.Text.Trim());
            MessageBox.Show($"{message}");
            if (message.Substring(0,7)=="Success")
            {
                Hide();
                //Depending on the user type opens one or other form
                switch (comboBoxUserType.Text)
                {
                    case "Admins":
                        //InstructorsSchedulePage InstructorSchedule1 = new InstructorsSchedulePage(username, "Admins");
                        //InstructorSchedule1.ShowDialog();
                        //CarAssignationPage CarAssignationPage = new CarAssignationPage();
                        //CarAssignationPage.ShowDialog();
                        AdminConsole WeekResourceAvailability = new AdminConsole();
                        WeekResourceAvailability.ShowDialog();
                        break;
                    case "Clients":
                        ClientConsole CustomerAppointment = new ClientConsole(username);
                        CustomerAppointment.ShowDialog();
                        break;
                    case "Instructors":
                        InstructorConsole InstructorSchedule2 = new InstructorConsole(username);
                        InstructorSchedule2.ShowDialog();
                        break;
                    default:
                        break;
                }
                Close();
            }

            //initialiseTextControls();
        }

        // Changes the color of the controls to white when clicked
        private void comboBoxUserType_Click(object sender, EventArgs e)
        {
            comboBoxUserType.BackColor = Color.White;
        }

        private void textBoxUserName_Click(object sender, EventArgs e)
        {
            textBoxUserName.BackColor = Color.White;
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.BackColor = Color.White;
        }

        // When clicked on switch page to the register page
        private void labelRegister_Click(object sender, EventArgs e)
        {
            //Hides the login page form from user
            this.Hide();
            //Create a Register Page object to change to
            RegisterPage register = new RegisterPage();
            //show the register page
            register.ShowDialog();
            //close the login page we are currently on
            this.Close();
        }

        // Clears the text boxes on the page focuses on top one
        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            initialiseTextControls();
        }

        // Initialises all textboxes to blank text
        private void initialiseTextControls()
        {
            //goes through and clears all of the textboxes and comboboxes
            foreach (Control c in this.Controls)
            {
                //if the it is a textbox
                if (c is TextBox)
                {
                    //clear the text box
                    (c as TextBox).Clear();
                    c.BackColor = Color.White;
                }
                else if (c is ComboBox)
                {
                    //clear the text box
                    (c as ComboBox).SelectedIndex = -1;
                    c.BackColor = Color.White;
                }
            }
            //focus on first text box
            comboBoxUserType.Focus();
        }

        // When the mouse hovers over the top of the register button
        private void labelRegister_MouseHover(object sender, EventArgs e)
        {
            //Changes the colour of the label
            labelRegister.ForeColor = Color.Blue;
        }
        private void labelRegister_MouseLeave(object sender, EventArgs e)
        {
            //Changes the colour of the label
            labelRegister.ForeColor = Color.Black;
        }

        // Takes us to the browse session page
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            //you have seen this plenty of times, I hope it is self explainatory now
            Hide();
            InstructorConsole InstructorSchedule2 = new InstructorConsole("cfrisby");
            InstructorSchedule2.ShowDialog();
            //WeekResourcesAvailabilityPage WeekResourceAvailability = new WeekResourcesAvailabilityPage();
            //WeekResourceAvailability.ShowDialog();
            //CustomerAppointmentsPage CustomerAppointment = new CustomerAppointmentsPage();
            //CustomerAppointment.ShowDialog();
            //CarAssignationPage CarAssignationPage = new CarAssignationPage();
            //CarAssignationPage.ShowDialog();
            Close();
        }

        // Checks if they text controls have data in them
        private bool checkTextBoxes()
        {
            bool holdsData = true;
            //go through all of the controls
            foreach (Control c in this.Controls)
            {
                //if its a textbox or a combobox
                if (c is TextBox || c is ComboBox)
                {
                    //If it is not the case that it is empty
                    //if ("".Equals((c as TextBox).Text.Trim()))
                    if ("".Equals(c.Text.Trim()))
                    {
                        //set boolean to false because on control is empty
                        holdsData = false;
                        c.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        c.BackColor = Color.White;
                    }
                }
            }
            //returns true or false based on if data is in all text boxes or not
            return holdsData;
        }

        // It loads a combobox with the list supplied
        private void loadComboBox(ComboBox myCombo, List<string> myList)
        {
            myCombo.Text = "";
            myCombo.Items.Clear();
            int i = 0;
            while (i<myList.Count)
            {
                myCombo.Items.Add(myList[i].ToString());
                i++;
            }
        }

        // It compares the username and password with the data of a table and returns a message
        private string checkLogin(string username, string password, string table)
        {
            string message = "Login attempt unsuccessful! Please check details";
            string loginQuery = $"SELECT * FROM {table}" ;
            //gets data from database
            SQL.selectQuery(loginQuery);
            //Check that there is something to write brah
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    if (username.Equals(SQL.read[0].ToString()) && password.Equals(SQL.read[1].ToString()))
                    {
                        message = $"Successfully logged in as: {SQL.read[2].ToString()} {SQL.read[3].ToString()}";
                        //user sessionUser = new user();
                        //sessionUser.userFirstName = SQL.read[2].ToString();
                        //sessionUser.userLastName = SQL.read[3].ToString();
                        break;
                    }
                }
            }
            else
            {
                message="No users have been registered yet";
            }
            return message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            statshome register = new statshome();

            register.ShowDialog();

            this.Close();
        }
    }
}
