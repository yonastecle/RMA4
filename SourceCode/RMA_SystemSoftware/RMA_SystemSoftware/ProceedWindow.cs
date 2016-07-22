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
    public partial class ProceedWindow : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        delegateMessageBox mesg_box = new delegateMessageBox();
        Technician tech = new Technician();
        public string rma_no { get; set; }

        public ProceedWindow()
        {
            InitializeComponent();
        }

        private void ProceedWindow_Load(object sender, EventArgs e)
        {

        }

        private void delegateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mesg_box.RMA = rma_no;
            mesg_box.Show();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("update RMA set Status = 'Assigned' where rma_no='"+ rma_no +"'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("RMA request added to your WO Quene", " Request Assigned!!");
                this.Close();
                tech.showTech_WOQueue();
                con.Close();
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
