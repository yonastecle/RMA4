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
    public partial class delegateMessageBox : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        public string RMA { get; set; }
        public string result { get; set; }
        public void setdata()
        {
            label_RMA_No.Text = RMA;
        }

        public delegateMessageBox()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Technician tech = new Technician();
            tech.Show();
        }

        private void DelegateButton_Click(object sender, EventArgs e)
        {
            
            
            try
            { 
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("update Notes set statusUpdates='" + textBox_delg_reason.Text + "' where RMA_no = '" + RMA + "'", con);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update RMA set Status= 'Hold' where RMA_no = '" + RMA + "'", con);
                cmd.ExecuteNonQuery(); 
                con.Close();
                MessageBox.Show(" Request put on hold. Email notification sent to Supervisor for approval!");
                //Pending :Add functionality to send email notification to the Supervisor          
                this.Close();
                Technician tech = new Technician();
                tech.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
    }
}

