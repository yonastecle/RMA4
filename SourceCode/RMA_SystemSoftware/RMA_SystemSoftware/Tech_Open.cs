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
        public string rma_no { get; set; }
       public string u_type { get; set; }
        public Tech_Open()
        {
            InitializeComponent();
        }
           
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
           // if(u_type.ToLower().Equals("supervisor"))
           // {
           //     Supervisor sup = new Supervisor();
           //     sup.Show();
           // }
           //else if(u_type.ToLower().Equals("technician"))
           //{
           //     Technician Tech = new Technician();
           //     Tech.Show();
           // }
           // else if(u_type.ToLower().Equals("help desk"))
           // {
           //     HelpDesk hdsk = new HelpDesk();
           //     hdsk.Show();
           // }
                      

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
