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
        Technician tech = new Technician();
        public string RMA { get; set; }
        public string result { get; set; }
        //public void setdata()
        //{
        //    
        //}

        public delegateMessageBox()
        {
            InitializeComponent();
        }

        private void delegateMessageBox_Load(object sender, EventArgs e)
        {
            label_RMA_No.Text = RMA;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            
            //tech.Show();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            try
            {
                if(textBox_delg_reason.Text !="")
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    cmd = new SqlCommand("update RMA set Status= 'Hold' where RMA_no = '" + RMA + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("update Notes set comments='" + textBox_delg_reason.Text + "' FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no ='" + RMA + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show(" Request put on hold. Email notification sent to Supervisor for approval!");
                    //Pending :Add functionality to send email notification to the Supervisor          
                    this.Close();
                    //tech.Show();
                }
                else
                {
                    MessageBox.Show("Enter the reason for delegation!!");
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}

