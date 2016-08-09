using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMA_SystemSoftware
{
    public partial class Tech_Open : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
       // SqlCommand cmd;
        //SqlDataReader reader;
        GrabData grab = new GrabData();
        Notes notes = new Notes();
        public string ID, req_type, desp = "", res = "", stat = "", comm = "";
        public string rma_no { get; set; }
        public string u_type { get; set; }
        public Tech_Open()
        {
            InitializeComponent();
        }
           
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();                            

        }

        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void Tech_Open_Load(object sender, EventArgs e)
        {
            label_rmaNo.Text = rma_no;
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            //call function in Notes
        }
    }
}
