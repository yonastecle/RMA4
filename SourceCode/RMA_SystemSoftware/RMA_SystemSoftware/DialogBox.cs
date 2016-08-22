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
    public partial class DialogBox : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        DialogBox msg_box;
        Technician tech = new Technician();
        Utilities util = new Utilities();
        public string RMA { get; set; }
        public string stat_type { get; set; }
       

        public DialogBox()
        {
            InitializeComponent();
        }

        private void delegateMessageBox_Load(object sender, EventArgs e)
        {
            label_RMA_No.Text = RMA;
            if (stat_type.Contains("hold")) label_statusType.Text = " Why are you putting it on hold ?";
            else if (stat_type.Contains("complete")) label_statusType.Text = "Were you able to fix it? If yes..How ?";
            else
                label_statusType.Text = "Reason for Delegation";
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            try
            {
                if(textBox_reason.Text !="")
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();

                    if (stat_type.Contains("hold"))
                    {
                        cmd = new SqlCommand("update RMA set Status= 'Hold' where RMA_no = '" + RMA + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("update Notes set statusUpdates='" + textBox_reason.Text + "' FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no ='" + RMA + "'", con);
                        cmd.ExecuteNonQuery();
                        util.SendEmail(RMA, textBox_reason.Text, stat_type);
                        MessageBox.Show(" Request put on hold. Email notification sent to Supervisor!", "RMA on Hold");
                    }
                    else if(stat_type.Contains("complete"))
                    {
                        cmd = new SqlCommand("update RMA set Status= 'Completed ' where RMA_no = '" + RMA + "'", con);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("update Notes set resolution='" + textBox_reason.Text + "' FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no ='" + RMA + "'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(" Notified Supervisor!", "RMA Completed!");                       
                    }                   

                    con.Close();
                    this.Close();
                    //Pending :Add functionality to send email notification to the Supervisor          


                }
                else
                {
                  MessageBox.Show("Please fill in the Reason for status change!!","Can't be left blank");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
    }
}

