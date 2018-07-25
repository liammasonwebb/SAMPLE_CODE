﻿using Oracle.DataAccess.Client;
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
    public partial class SELLERTRANS : Form
    {
        public SELLERTRANS()
        {
            InitializeComponent();
        }
        
        private void LoadData()

        {
            string CAT = "";

            CAT = textBox2.Text;

            string ConString = "Data Source=XE;User Id=SYSTEM;Password=Welcome1*;";

            using (OracleConnection con = new OracleConnection(ConString))

            {

                OracleCommand cmd = new OracleCommand("SELECT * FROM WINFOURMS.PARTS WHERE seller_uname = '" + CAT + "' AND CAT_NAME = 'SOLD_ITEMS'", con);

                OracleDataAdapter oda = new OracleDataAdapter(cmd);

                cmd.CommandText = "SELECT * FROM WINFOURMS.PARTS WHERE seller_uname = '" + CAT + "' AND CAT_NAME = 'SOLD_ITEMS'";

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

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
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
