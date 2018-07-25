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
    public partial class WELCOME : Form
    {
        public WELCOME()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 viwme = new Form1();
            viwme.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            user_add viwme = new user_add();
            viwme.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            SELLERADD viwme = new SELLERADD();
            viwme.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            sell_parts viwme = new sell_parts();
            viwme.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            SELLERTRANS viwme = new SELLERTRANS();
            viwme.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            BUYERTRANS viwme = new BUYERTRANS();
            viwme.ShowDialog();
            this.Close();
        }
    }
}
