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
    public partial class DeleteAdmin : Form
    {
        public DeleteAdmin()
        {
            InitializeComponent();
            SQL.editComboBoxItems(comboBox1, "SELECT username FROM Admins");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var updateQuery = $"DELETE FROM Admins  WHERE username = '{comboBox1.Text}' ";
                SQL.executeQuery(updateQuery);
                MessageBox.Show("Account Deleted.");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Could not delete account. Please Try Again.");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Delete_select register = new Delete_select();

            register.ShowDialog();

            this.Close();
        }
    }
}
