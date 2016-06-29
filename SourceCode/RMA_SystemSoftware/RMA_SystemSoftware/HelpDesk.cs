using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMA_SystemSoftware
{
    public partial class HelpDesk : Form
    {
        public HelpDesk()
        {
            InitializeComponent();
        }

            private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void HelpDesk_Load(object sender, EventArgs e)
        {
            groupBox_UpdateDetails.Enabled = false;
           
        }
        public void AuthorizedUser()
        {
            groupBox_UpdateDetails.Enabled = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        
    }
}
