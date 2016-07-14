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
    public partial class Tech_Open : Form
    {
        public string rma_no;
        public string PassNo
        {
            get { return rma_no; }
            set { rma_no = value; }
        }
        public Tech_Open()
        {
            InitializeComponent();
        }
           
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Technician Tech = new Technician();
           // Supervisor sup = new Supervisor();
            Tech.Show();
          

        }

        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void Tech_Open_Load(object sender, EventArgs e)
        {
            label_rmaNo.Text = rma_no;
        }
    }
}
