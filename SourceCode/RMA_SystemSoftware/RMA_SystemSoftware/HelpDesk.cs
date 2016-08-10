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
    public partial class HelpDesk : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        GrabData grab = new GrabData();
        Notes notes = new Notes();
        History histry = new History();
        WO_Details details = new WO_Details();
        Split_RMA split = new Split_RMA();
        Tech_Open techopen = new Tech_Open();
        Supervisor sup = new Supervisor();
        string ID, req_type,enteredtxt="",desp="",res="",stat="",comm="";
        string found = null;
        int cat;
        string rmaNumber = "";
        public string u_id { get; set; }

        public HelpDesk()
        {
            InitializeComponent();
            comboBox_updateStatus.Items.Add("Open");//Can be omitted!
            comboBox_updateStatus.Items.Add("Received");
            comboBox_updateStatus.Items.Add("Wait");
            comboBox_updateStatus.Items.Add("Waiting to be assigned");
            comboBox_updateStatus.Items.Add("Assigned");
            comboBox_updateStatus.Items.Add("Hold");
            comboBox_updateStatus.Items.Add("Refund");
            comboBox_updateStatus.Items.Add("Complete");
            comboBox_updateStatus.Items.Add("Close");
        }

        private void HelpDesk_Load(object sender, EventArgs e)
        {
            try
            {
                //  groupBox_UpdateDetails.Enabled = false;
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                label_helloEmp.Text = grab.getEmployeeName(u_id);
                con.Close();

                con.Open();
                cmd = new SqlCommand("select firstName from Employee where usertype IN('Technician','Help Desk')", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox_TechName.Items.Add(reader["firstName"]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public void AuthorizedUser()
        {
            //groupBox_UpdateDetails.Enabled = true;
        }

        private void linkLabel_logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void linkLabel_help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void textBox_rmaNo_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == (char)Keys.Enter)
            {

                textBox_statusUpdates.Clear();
                textBox_comments.Clear();
                textBox_descrption.Clear();
                textBox_resolution.Clear();

                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    found = grab.serachRMA(textBox_rmaNo.Text);
                    con.Close();
                    if (found.Equals("0")) MessageBox.Show("RMA not found. Please enter a valid RMA#.");
                    else
                    {
                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM RMA R, Notes N WHERE R.rma_no =N.RMA_no AND r.rma_no='" + textBox_rmaNo.Text + "'", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            label_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                            label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                            textBox_descrption.Text = reader.GetString(reader.GetOrdinal("description"));
                            textBox_comments.Text = reader.GetString(reader.GetOrdinal("comments"));
                            textBox_resolution.Text = reader.GetString(reader.GetOrdinal("resolution"));
                            textBox_statusUpdates.Text = reader.GetString(reader.GetOrdinal("statusUpdates"));
                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConfirmTechChangeButton_Click(object sender, EventArgs e)
        {
            string id = null;
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            id = grab.getEmployeeID(comboBox_TechName.Text);
            con.Close();

            con.Open();
            cmd = new SqlCommand("update RMA set userID='" + id + "' where rma_no='" + textBox_update_rmaNo.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Technician Re-Assigned!");
            con.Close();
        }

        private void textBox_update_rmaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            string found = null;
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    found = grab.serachRMA(textBox_update_rmaNo.Text);
                    con.Close();
                    if (found.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#.");
                    else
                    {
                        grab.autofill(textBox_update_rmaNo.Text, ref textBox_update_rmaNo, ref label_status, ref comboBox_updateStatus, ref req_type, ref cat, ref radioB_repair, ref radioB_replace, ref radioB_refund, ref radioB_CAT1, ref radioB_CAT2, ref radioB_CAT3, ref radioB_CAT4, ref label_TechName, ref textBox_update_statusUpdate);                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
      

        private void updateRecordButton_Click(object sender, EventArgs e)
        {
            string rmaNum = textBox_update_rmaNo.Text.ToString();
            if (textBox_update_rmaNo.Text != "")
            {
                if ((radioB_refund.Checked == true || radioB_repair.Checked == true || radioB_replace.Checked == true) && (radioB_CAT1.Checked == true || radioB_CAT2.Checked == true || radioB_CAT3.Checked == true || radioB_CAT4.Checked == true))
                {
                     grab.updateDB(rmaNum, ref comboBox_updateStatus, ref req_type, ref cat);
                    notes.updateField("statusUpdates", enteredtxt, rmaNum);
                    MessageBox.Show("Changes Saved!!! ","Success");
                }
                else
                {
                    MessageBox.Show("Please choose Type of request/Category!");
                }
            }
            else
            {
                MessageBox.Show("Please Enter RMA!", "Empty Field");
            }
        }

        private void openRecordButton_Click(object sender, EventArgs e)
        {
            techopen.rma_no = textBox_update_rmaNo.Text;
            if (textBox_update_rmaNo.Text != "")
            {
                techopen.Show();

            }

            else MessageBox.Show("Please Enter RMA#", "Empty Field");
        }

        private void UpdateInfoButton_Click(object sender, EventArgs e)
        {
            notes.updateField(textBox_rmaNo.Text, desp, res, stat, comm);                       
                textBox_statusUpdates.Clear();
                textBox_comments.Clear();
                textBox_descrption.Clear();
                textBox_resolution.Clear();
                label_currentStatus.Text = "";
                label_rmaNo.Text = "";
          
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            // this.Hide();
            sup.fill_grid();
        }



        private void SplitRMAButton_Click(object sender, EventArgs e)
        {
            split.rma_no = textBox_update_rmaNo.Text;
            if (textBox_update_rmaNo.Text != "")
            {
                split.Show();
            }
            else
                MessageBox.Show("Enter RMA No.", " Empty Field");
        }
       
        private void textBox_update_rmaNo_TextChanged(object sender, EventArgs e)
        {
            rmaNumber = textBox_update_rmaNo.Text;
        }
        private void textBox_update_statusUpdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_update_statusUpdate.Clear();
        }

        private void textBox_update_statusUpdate_TextChanged(object sender, EventArgs e)
        {
            enteredtxt = textBox_update_statusUpdate.Text;
        }
        private void radioB_repair_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Repair";
        }

        private void radioB_replace_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Replace";
        }

        private void radioB_refund_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Refund";
        }
       
        private void radioB_CAT1_CheckedChanged(object sender, EventArgs e)
        {
            cat = 1;
        }

        private void radioB_CAT2_CheckedChanged(object sender, EventArgs e)
        {
            cat = 2;
        }
        
        private void radioB_CAT3_CheckedChanged(object sender, EventArgs e)
        {
            cat = 3;
        }      

        private void radioB_CAT4_CheckedChanged(object sender, EventArgs e)
        {
            cat = 4;
        }

        private void textBox_descrption_TextChanged(object sender, EventArgs e)
        {
            desp = textBox_descrption.Text;
        }
        private void textBox_resolution_TextChanged(object sender, EventArgs e)
        {
            res = textBox_resolution.Text;
        }

        private void ViewHistoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_rmaNo.Text == "")
                    MessageBox.Show("Please enter RMA#", "Empty Field!!");
                else
                {
                    found = grab.serachRMA(textBox_rmaNo.Text);
                    if (found.Equals("1"))
                    {
                        histry.rma.rma_no = textBox_rmaNo.Text;
                        histry.ShowDialog();
                    }
                    else if (found.Equals("0"))
                        MessageBox.Show("RMA not found.Please enter a valid RMA#", "Invalid Entry!!");
                }

            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_statusUpdates_TextChanged(object sender, EventArgs e)
        {
            stat = textBox_statusUpdates.Text;
        }

        private void textBox_comments_TextChanged(object sender, EventArgs e)
        {
            comm = textBox_comments.Text;
        }
        private void textBox_descrption_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_descrption.Clear();
        }
        private void textBox_resolution_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_resolution.Clear();
        }

        private void textBox_statusUpdates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_statusUpdates.Clear();
        }

        private void textBox_comments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_comments.Clear();
        }
    }
}
