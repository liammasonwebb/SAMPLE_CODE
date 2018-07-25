using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INTRO_USERS
{
    public partial class statshome : Form
    {
        public statshome()
        {
            InitializeComponent();
            SQL.editComboBoxItems(comboBox1, "SELECT COUNT(*) FROM Clients");
            SQL.editComboBoxItems(comboBox4, "SELECT COUNT(*) FROM Instructors");
            SQL.editComboBoxItems(comboBox6, "SELECT COUNT(*) FROM Appointments");
            SQL.editComboBoxItems(comboBox5, "SELECT COUNT(*) FROM Clients Where clientType = 'experienced' ");
            SQL.editComboBoxItems(comboBox2, "SELECT COUNT(*) FROM Clients Where clientType = 'new' ");
            SQL.editComboBoxItems(comboBox3, "SELECT COUNT(*) FROM Appointments");

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void statshome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();

            LoginPage login = new LoginPage();

            login.ShowDialog();

            this.Close();
        }
    }
}
