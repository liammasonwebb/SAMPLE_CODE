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

    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
            //It prepares and limites the different text controls
            comboBoxUserType.Items.Add("Clients");
            comboBoxUserType.Items.Add("Instructors");
            comboBoxUserType.Items.Add("Admins");
            textBoxUserName.MaxLength = 32;
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.MaxLength = 16;
            textBoxPassword2.PasswordChar = '*';
            textBoxPassword2.MaxLength = 16;
            textBoxFirst.MaxLength = 24;
            textBoxLast.MaxLength = 24;
            textBoxEmail.MaxLength = 64;
            textBoxPhone.MaxLength = 10;
            //It loads the Client Type Combobox
            string clientTypeQuery = "SELECT name FROM ClientTypes";
            SQL.editComboBoxItems(comboBoxClientType, clientTypeQuery);
        }

        // It registers the new user as long as all controls hold text
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //variables to be used
            string username = "", password = "", password2 = "", firstname = "", lastname = "", email = "", clientType = "", userType="";
            Int32 phone = 0;

            //It checks that the text and combo boxes have something typed in them
            bool hasText = checkTextControls();
            if (!hasText)
            {
                MessageBox.Show("Please make sure all fields have data.");
                comboBoxUserType.Focus();
                return;
            }

            //It checks that the username doesn't exist yet in the DB
            bool userOK = checkUsername(textBoxUserName.Text.Trim(), comboBoxUserType.Text);
            if (!userOK)
            {
                MessageBox.Show("This user already exists in the Data Base, please try another one.");
                textBoxUserName.BackColor = Color.LightCoral;
                textBoxUserName.Focus();
                return;
            }
            //It checks that the password==password2
            bool passOK = checkPassword(textBoxPassword.Text.Trim(), textBoxPassword2.Text.Trim());
            if (!passOK)
            {
                MessageBox.Show("Please make sure the password in both password fields is the same.");
                textBoxPassword.BackColor = Color.LightCoral;
                textBoxPassword2.BackColor = Color.LightCoral;
                textBoxPassword.Focus();
                return;
            }
            //It checks that the email is a proper one
            bool emailOK = checkEmail(textBoxEmail.Text.Trim());
            if (!emailOK)
            {
                MessageBox.Show("Please insert a proper email in the field.");
                textBoxEmail.BackColor = Color.LightCoral;
                textBoxEmail.Focus();
                return;
            }
            //It checks that the phone number introduced is numbers if the control is enabled
            if (textBoxPhone.Enabled==true)
            {
                bool phoneOK = int.TryParse(textBoxPhone.Text.Trim(), out phone);
                if (!phoneOK)
                {
                    MessageBox.Show("You can only write numbers in the phone field.");
                    textBoxPhone.BackColor = Color.LightCoral;
                    textBoxPhone.Focus();
                    return;
                }
            }

            //(1) GET the data from the textboxes and store into variables created above, good to put in a try catch with error message
            try
            {
                userType = comboBoxUserType.Text;
                username = textBoxUserName.Text.Trim();
                password = textBoxPassword.Text.Trim();
                password2 = textBoxPassword2.Text.Trim();
                firstname = textBoxFirst.Text.Trim();
                lastname = textBoxLast.Text.Trim();
                email = textBoxEmail.Text.Trim();
                switch (userType)
                {
                    case "Admins":
                        break;
                    case "Clients":
                        phone = int.Parse(textBoxPhone.Text.Trim());
                        clientType = comboBoxClientType.Text.Trim();
                        break;
                    case "Instructors":
                        phone = int.Parse(textBoxPhone.Text.Trim());
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                //Error message, more useful when you are storing numbers etc. into the database.
                MessageBox.Show("Please make sure your data is in correct format.");
                return;
            }

            //(2) Execute the INSERT statement, making sure all quotes and commas are in the correct places.
            try
            {
                var insertClientQuery = "";
                //It sends a different insert statement depending on the User Type Selection
                switch (userType)
                {
                    case "Admins":
                        insertClientQuery = $"INSERT INTO {userType} VALUES('{username}', '{password}', '{firstname}', '{lastname}', '{email}')";
                        break;
                    case "Clients":
                        insertClientQuery = $"INSERT INTO {userType} VALUES('{username}', '{password}', '{firstname}', '{lastname}', '{email}', {phone}, '{clientType}')";
                        break;
                    case "Instructors":
                        insertClientQuery = $"INSERT INTO {userType} VALUES('{username}', '{password}', '{firstname}', '{lastname}', '{email}', {phone})";
                        break;
                    default:
                        break;
                }
                SQL.executeQuery(insertClientQuery);
            }
            catch (Exception )
            {
                MessageBox.Show("Register attempt unsuccessful.  Check insert statement.  Could be a Username conflict too.");
                return;
            }



            //success message for the user to know it worked
            MessageBox.Show("Successfully Registered as " + userType + ": " + firstname + " " + lastname + ". Your username is: " + username);

            //Go back to the login page since we registered successfully to let the user log in
            Hide();                                 //hides the register form
            LoginPage login = new LoginPage();      //creates the login page as an object
            login.ShowDialog();                     //shows the new login page form
            this.Close();                           //closes the register form that was hidden
        }

        //It enables or disables the required controls depending on the User Type selection
        private void comboBoxUserType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBoxUserType.Text)
            {
                case "Admins":
                    comboBoxClientType.Enabled = false;
                    textBoxPhone.Enabled = false;
                    break;
                case "Clients":
                    comboBoxClientType.Enabled = true;
                    textBoxPhone.Enabled = true;
                    break;
                case "Instructors":
                    comboBoxClientType.Enabled = false;
                    textBoxPhone.Enabled = true;
                    break;
                default:
                    comboBoxClientType.Enabled = false;
                    textBoxPhone.Enabled = false;
                    break;
            }
        }
        //It changes the color of the controls to white when clicked
        private void textBoxUserName_Click(object sender, EventArgs e)
        {
            textBoxUserName.BackColor = Color.White;
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.BackColor = Color.White;
        }

        private void textBoxPassword2_Click(object sender, EventArgs e)
        {
            textBoxPassword2.BackColor = Color.White;
        }

        private void textBoxFirst_Click(object sender, EventArgs e)
        {
            textBoxFirst.BackColor = Color.White;
        }

        private void textBoxLast_Click(object sender, EventArgs e)
        {
            textBoxLast.BackColor = Color.White;
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            textBoxEmail.BackColor = Color.White;
        }

        private void textBoxPhone_Click(object sender, EventArgs e)
        {
            textBoxPhone.BackColor = Color.White;
        }

        private void comboBoxClientType_Click(object sender, EventArgs e)
        {
            comboBoxClientType.BackColor = Color.White;
        }

        private void comboBoxUserType_Click(object sender, EventArgs e)
        {
            comboBoxUserType.BackColor = Color.White;
        }

        //It clears all text boxes
        private void buttonClear_Click(object sender, EventArgs e)
        {
            initialiseTextControls();
        }

        //It takes us back to the login screen
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //It hides this form currently on
            Hide();
            //is the login page as a new object               
            LoginPage login = new LoginPage();
            //It shows the login page window
            login.ShowDialog();
            //It closes the current open windows so its only the new one showing
            this.Close();
        }

        // It checks if they username doesn't exist in the DB already
        private bool checkUsername(string username, string myTable)
        {
            bool usernameOK = true;
            //It loads the Client Type Combobox
            //string usernameQuery = "SELECT username FROM Clients";
            string usernameQuery = "SELECT username FROM " + myTable;
            //It gets data from database
            SQL.selectQuery(usernameQuery);
            //It checks that there is something to write brah
            if (SQL.read.HasRows)
            {
                while (SQL.read.Read())
                {
                    if (username.Equals(SQL.read[0].ToString()))
                    {
                        usernameOK = false;
                        break;
                    }
                }
            }
            return usernameOK;
        }

        // It checks if they password textboxes have the same password
        private bool checkPassword(string pass1, string pass2)
        {
            bool passwordOK = true;
            if (pass1 != pass2)
            {
                passwordOK = false;
            }
            //It returns true or false based on if data is in the password text boxes are the same
            return passwordOK;
        }

        // It checks if they password textboxes have the same password
        private bool checkEmail(string email)
        {
            bool emailOK = true;
            if (email.IndexOf("@") == -1 || email.IndexOf("@") == 0 || email.IndexOf("@") == email.Length-1)
            {
                emailOK = false;
            }
            //It returns true or false based on if data is in the password text boxes are the same
            return emailOK;
        }

        //It checks if they text controls have data in them
        private bool checkTextControls()
        {
            bool holdsData = true;
            //It goes through all of the controls
            foreach (Control c in this.Controls)
            {
                //if its a textbox or a combobox
                if (c is TextBox || c is ComboBox)
                {
                    //It checks if the control is enabled due to the User Type selection
                    if (c.Enabled==true)
                    {
                        //If it is not the case that it is empty
                        //if ("".Equals((c as TextBox).Text.Trim()))
                        if ("".Equals(c.Text.Trim()))
                        {
                            //It sets boolean to false because on control is empty
                            holdsData = false;
                            c.BackColor = Color.LightCoral;
                        }
                        else
                        {
                            c.BackColor = Color.White;
                        }
                    }
                }
            }
            //It returns true or false based on if data is in all text boxes or not
            return holdsData;
        }

        // It initialises all text controls to blank text
        private void initialiseTextControls()
        {
            //It goes through and clears all of the textboxes
            foreach (Control c in this.Controls)
            {
                //if the it is a textbox
                if (c is TextBox)
                {
                    //it clears the text box
                    (c as TextBox).Clear();
                    c.BackColor = Color.White;
                }
                else if (c is ComboBox)
                {
                    //It clears the text box
                    (c as ComboBox).SelectedIndex = -1;
                    c.BackColor = Color.White;
                }
            }
            //It focuses on the User Type ComboBox
            comboBoxUserType.Focus();
        }
    }
}
