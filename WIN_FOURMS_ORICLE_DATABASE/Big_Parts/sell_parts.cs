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
    public partial class sell_parts : Form
    {
        public sell_parts()
        {
            InitializeComponent();
            combobox_load();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            ADD_PART();


        }



        private void sell_parts_Load(object sender, EventArgs e)
        {

        }
        private void ADD_PART()
        {
            string SELLID = "", DESC = "", CAT = "", MAKE = "", MODEL = "";

            SELLID = textBox5.Text;
            DESC = textBox1.Text;
            CAT = comboBox1.Text;
            MAKE = textBox3.Text;
            MODEL = textBox2.Text;


            {
                try
                {
                    string ConString = "Data Source=XE;User Id=WINFOURMS;Password=Welcome1*;";
                    OracleConnection conn = new OracleConnection(ConString);
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;

                    // Perform insert using parameters (bind variables)
                    cmd.CommandText = "INSERT INTO PARTS (MAKE,MODEL,DESCR,CAT_NAME,seller_uname) VALUES ('" + MAKE + "','" + MODEL + "','" + DESC + "','" + CAT + "','" + SELLID + "')";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Dispose();



                }

                catch
                {
                    MessageBox.Show("ERROR2");

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void combobox_load()
        {


            string ConString = "Data Source=XE;User Id=SYSTEM;Password=Welcome1*;";

            using (OracleConnection con = new OracleConnection(ConString))

            {
                try
                {

                    OracleCommand cmd = new OracleCommand("", con);

                    OracleDataAdapter oda = new OracleDataAdapter(cmd);

                    cmd.CommandText = "SELECT * FROM WINFOURMS.CATAGORYS";

                    con.Open();

                    OracleDataReader ded = cmd.ExecuteReader();

                    while (ded.Read())
                    {
                        comboBox1.Items.Add(ded["CAT_NAME"].ToString());

                    }
                }

                catch
                {
                    MessageBox.Show("ERROR");

                }
            }
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
