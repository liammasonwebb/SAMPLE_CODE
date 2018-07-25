using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big_Parts
{
    public partial class SELLERADD : Form
    {
        public SELLERADD()
        {
            InitializeComponent();
        }
        private void ADD_PART()
        {
            string SELLID = "", DESC = "", CAT = "", MAKE = "", MODEL = "";

            SELLID = textBox5.Text; //uname
            DESC = textBox1.Text; //email
            CAT = textBox4.Text; //pword
            MAKE = textBox3.Text; //fname
            MODEL = textBox2.Text; //lname


            {
                try
                {
                    string ConString = "Data Source=XE;User Id=WINFOURMS;Password=Welcome1*;";
                    OracleConnection conn = new OracleConnection(ConString);
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;

                    // Perform insert using parameters (bind variables)
                    cmd.CommandText = "INSERT INTO SUPPLY (uname, fname, lname, pword, email)VALUES ('" + SELLID + "', '" + MAKE + "', '" + MODEL + "', '" + CAT + "', '" + DESC + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Dispose();

                    MessageBox.Show("USER ADDED");



                }

                catch
                {
                    MessageBox.Show("PLEASE USE ANOTHER USERNAME");

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD_PART();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            WELCOME viwme = new WELCOME();
            viwme.ShowDialog();
            this.Close();
        }
    }
}
