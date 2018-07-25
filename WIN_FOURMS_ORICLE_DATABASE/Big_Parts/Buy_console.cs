using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            combobox_load();


        }

        private void LoadData()

        {
            string CAT = "";

            CAT = comboBox1.Text;

            string ConString = "Data Source=XE;User Id=BIGGER;Password=Welcome1*;";

            using (OracleConnection con = new OracleConnection(ConString))

            {

                OracleCommand cmd = new OracleCommand("SELECT * FROM BIGGER.PARTS WHERE CAT_NAME = '" + CAT + "'", con);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);

                cmd.CommandText = "SELECT * FROM BIGGER.PARTS WHERE CAT_NAME = '" + CAT + "'";

                con.Open();

                OracleDataReader ded = cmd.ExecuteReader();

                while (ded.Read())
                {
                    listView1.View = View.Details;
                    listView1.GridLines = true;
                    listView1.FullRowSelect = true;

                    listView1.Columns.Add("ID", 100);
                    listView1.Columns.Add("MAKE", 100);
                    listView1.Columns.Add("MODEL", 100);
                    listView1.Columns.Add("DESCR", 300);
                    listView1.Columns.Add("CATAGORY", 300);


                    string[] arr = new string[5];
                    ListViewItem itm;
                    arr[1] = (ded["MAKE"].ToString());
                    arr[2] = (ded["MODEL"].ToString());
                    arr[0] = (ded["PART_ID"].ToString());
                    arr[3] = (ded["DESCR"].ToString());
                    arr[4] = (ded["CAT_NAME"].ToString());

                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);


                }

            }
        }
        private void combobox_load()
        {


            string ConString = "Data Source=XE;User Id=BIGGER;Password=Welcome1*;";

            using (OracleConnection con = new OracleConnection(ConString))

            {
                try
                {

                    OracleCommand cmd = new OracleCommand("SELECT * FROM BIGGER.CATAGORYS", con);

                    OracleDataAdapter oda = new OracleDataAdapter(cmd);

                    cmd.CommandText = "SELECT * FROM BIGGER.CATAGORYS";

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

        private void SOLD()
        {
            string USERID = "", PARTID = "";

            USERID = textBox2.Text;
            PARTID = textBox1.Text;


            {
                try
                {
                    string ConString = "Data Source=XE;User Id=WINFOURMS;Password=Welcome1*;";
                    OracleConnection conn = new OracleConnection(ConString);
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;

                    // Perform insert using parameters (bind variables)
                    cmd.CommandText = "INSERT INTO BIGGER.TRANSACTIONS (PART_ID, BUY_UNAME)VALUES ('" + PARTID + "', '" + USERID + "')";
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




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)

        {


            string ConString = "Data Source=XE;User Id=BIGGER;Password=Welcome1*;";

            

            {
                string USERID = "", PARTID = "";

                USERID = textBox2.Text;
                PARTID = textBox1.Text;

                

                try
                {

                    SOLD();

                    
                    OracleConnection conn = new OracleConnection(ConString);
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;

                    // Perform insert using parameters (bind variables)
                    cmd.CommandText = "UPDATE BIGGER.PARTS SET CAT_NAME = 'SOLD_ITEMS' WHERE PART_ID = '" + PARTID + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Dispose();

                    MessageBox.Show("DONE");
                }
                catch
                {
                    MessageBox.Show("ERROR1");
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
