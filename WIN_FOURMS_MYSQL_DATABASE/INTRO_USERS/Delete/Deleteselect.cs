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
    public partial class Delete_select : Form
    {
        public Delete_select()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
                          
            AdminConsole login = new AdminConsole();
            
            login.ShowDialog();
            
            this.Close();
        }

        private void Delete_select_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();

            DeleteAdmin login = new DeleteAdmin();

            login.ShowDialog();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();

            DeleteClient login = new DeleteClient();

            login.ShowDialog();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();

            Deleteins login = new Deleteins();

            login.ShowDialog();

            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
