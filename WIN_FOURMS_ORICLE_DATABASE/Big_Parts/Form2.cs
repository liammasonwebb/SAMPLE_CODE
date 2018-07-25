using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;


namespace Big_Parts
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            LoadData();
        }




        private void LoadData()

        {


            string ConString = "Data Source=XE;User Id=SYSTEM;Password=Welcome1*;";

                using (OracleConnection con = new OracleConnection(ConString))

                {

                    OracleCommand cmd = new OracleCommand("SELECT * FROM WINFOURMS.PARTS", con);

                    OracleDataAdapter oda = new OracleDataAdapter(cmd);

                    cmd.CommandText = "SELECT * FROM WINFOURMS.PARTS";

                    con.Open();

                    OracleDataReader ded = cmd.ExecuteReader();

                    while (ded.Read())
                    {
                    listView1.View = View.Details;
                    listView1.GridLines = true;
                    listView1.FullRowSelect = true;

                    listView1.Columns.Add("MAKE", 100);
                    listView1.Columns.Add("MODEL", 100);
                    listView1.Columns.Add("ID", 100);
                    string[] arr = new string[4];
                    ListViewItem itm;
                    arr[0] = (ded["MAKE"].ToString());
                    arr[1] = (ded["MODEL"].ToString());
                    arr[3] = (ded["PART_ID"].ToString());
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);

                   
                }

                }
            }
         }
    }