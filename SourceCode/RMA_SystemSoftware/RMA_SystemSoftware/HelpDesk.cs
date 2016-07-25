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
        WO_Details details = new WO_Details();
        Split_RMA split = new Split_RMA();
        Tech_Open techopen = new Tech_Open();
        Supervisor sup = new Supervisor();
        string ID, req_type;
        int cat;
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
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                cmd = new SqlCommand("select firstName,userType from Employee where UserID ='"+u_id+"'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label_helloEmp.Text = reader.GetString(reader.GetOrdinal("firstName"));
                   details.u_type= techopen.u_type = reader.GetString(reader.GetOrdinal("userType"));
                }
                   
                reader.Close();
                cmd = new SqlCommand("select firstName from Employee where usertype IN('Technician','Help Desk')", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox_TechName.Items.Add(reader["firstName"]);
                }
                reader.Close();
                con.Close();

            }
            catch(Exception ex)
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
            string found = null;
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
                    cmd = new SqlCommand("Select count(rma_no) found from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        found = String.Format("{0}", reader["found"]);
                    con.Close();
                    if (found.Equals("0")) MessageBox.Show("RMA not found. Please enter a valid RMA#.");
                    else
                    {
                        //label_rmaNo.Text = textBox_rmaNo.Text;
                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM RMA R, Notes N WHERE R.rma_no =N.RMA_no AND r.rma_no='" + textBox_rmaNo.Text + "'", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            label_rmaNo.Text =  reader.GetString(reader.GetOrdinal("rma_no"));
                            label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                            textBox_descrption.Text = reader.GetString(reader.GetOrdinal("description"));
                            textBox_comments.Text = reader.GetString(reader.GetOrdinal("comments"));
                            textBox_resolution.Text = reader.GetString(reader.GetOrdinal("resolution"));
                            textBox_statusUpdates.Text = reader.GetString(reader.GetOrdinal("statusUpdates"));
                        }
                        con.Close();
                    }
                }
                catch(Exception ex)
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
            cmd = new SqlCommand("Select UserID ID from Employee where firstName='" + comboBox_TechName.Text + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                id = reader["ID"].ToString();
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
                //textBox_update_rmaNo.Clear();
                //comboBox_updateStatus.SelectedIndex = -1;
                //label_status.Text = "";
                //textBox_update_statusUpdate.Clear();
                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    cmd = new SqlCommand("Select count(rma_no) found from RMA where rma_no='" + textBox_update_rmaNo.Text + "'", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                        found = String.Format("{0}", reader["found"]);
                    reader.Close();
                    if (found.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#.");
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM RMA R, Notes N WHERE R.rma_no =N.RMA_no AND r.rma_no='"+ textBox_update_rmaNo.Text + "'", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox_update_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                            comboBox_updateStatus.Text = label_status.Text = reader.GetString(reader.GetOrdinal("Status"));                          
                            ID = reader.GetString(reader.GetOrdinal("userID"));
                            //Enable radio buttons
                            req_type = reader.GetString(reader.GetOrdinal("type"));
                            cat = reader.GetInt16(reader.GetOrdinal("category"));
                            textBox_update_statusUpdate.Text = reader.GetString(reader.GetOrdinal("statusUpdates"));

                        }
                        reader.Close();
                        if(req_type.ToLower().Contains("replace"))
                        {
                            radioB_replace.Checked = true;
                        }
                        else if( req_type.ToLower().Contains("repair"))
                        {
                            radioB_repair.Checked = true;
                        }
                        else if(req_type.ToLower().Contains("refund"))
                        {
                            radioB_refund.Checked = true;
                        }
                        if(cat==1)
                        {
                            radioB_CAT1.Checked = true;
                        }
                        else if (cat==2)
                        {
                            radioB_CAT2.Checked = true;
                        }
                        else if(cat==3)
                        {
                            radioB_CAT3.Checked = true;
                        }
                        else if (cat==4)
                        {
                            radioB_CAT4.Checked = true;
                        }
                        else
                        {
                            radioB_CAT1.Checked = false;
                            radioB_CAT2.Checked = false;
                            radioB_CAT3.Checked = false;
                            radioB_CAT4.Checked = false;

                        }
                        cmd = new SqlCommand("select firstName from Employee where UserID='" + ID + "'", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read()) label_TechName.Text = reader.GetString(reader.GetOrdinal("firstName"));
                        reader.Close();

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateButtonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("update Notes set description=' "+textBox_descrption.Text+"', statusUpdates='"+textBox_statusUpdates.Text+"', comments='"+textBox_comments.Text+"',resolution='"+textBox_resolution.Text+"' from RMA R, Notes N where R.rma_no=N.RMA_no and R.rma_no='"+textBox_rmaNo.Text+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Database Updated");
                textBox_rmaNo.Clear();
                textBox_statusUpdates.Clear();
                textBox_comments.Clear();
                textBox_descrption.Clear();
                textBox_resolution.Clear();
                label_currentStatus.Text = "";
                label_rmaNo.Text = "";                   
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void updateRecordButton_Click(object sender, EventArgs e)
        {
            try
            { 

                if (textBox_update_rmaNo.Text != "")
                {
                    if ((radioB_refund.Checked == true || radioB_repair.Checked == true || radioB_replace.Checked == true) && (radioB_CAT1.Checked == true || radioB_CAT2.Checked == true || radioB_CAT3.Checked == true || radioB_CAT4.Checked == true))
                    {
                       // if (con.State == ConnectionState.Open) con.Close();
                        con.Open();
                        Console.WriteLine("database updated!"+ comboBox_updateStatus.Text + "',type='" + req_type + "',category='" + cat + "'where rma_no='" + textBox_update_rmaNo.Text);
                        cmd = new SqlCommand("update RMA set Status='" + comboBox_updateStatus.Text + "',type='" + req_type + "',category='" + cat + "'where rma_no='" + textBox_update_rmaNo.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        cmd = new SqlCommand("update Notes set Notes.statusUpdates='" + textBox_update_statusUpdate.Text + "'from RMA R, Notes N where R.rma_no=N.RMA_no and R.rma_no=' " + textBox_update_rmaNo.Text + "'", con);
                        cmd.ExecuteNonQuery();
                      
                        con.Close();
                        MessageBox.Show("Changes Saved!!");
                       // showUpdatedDetails();
                    }
                    else
                    {
                        MessageBox.Show("Please choose Type of request/Category!");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter RMA!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openRecordButton_Click(object sender, EventArgs e)
        {
            techopen.rma_no = textBox_update_rmaNo.Text;
            if (textBox_update_rmaNo.Text != "")
            {
                techopen.Show();
                
            }
               
            else MessageBox.Show("Please Enter RMA#");
        }

        private void UpdateInfoButton_Click(object sender, EventArgs e)
        {
              try
                {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("update Notes set description=' " + textBox_descrption.Text + "', statusUpdates='" + textBox_statusUpdates.Text + "', comments='" + textBox_comments.Text + "',resolution='" + textBox_resolution.Text + "' from RMA R, Notes N where R.rma_no=N.RMA_no and R.rma_no='" + textBox_rmaNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Database Updated");
                textBox_rmaNo.Clear();
                textBox_statusUpdates.Clear();
                textBox_comments.Clear();
                textBox_descrption.Clear();
                textBox_resolution.Clear();
                label_currentStatus.Text = "";
                label_rmaNo.Text = "";                    
                }
               catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

     
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                MessageBox.Show("Enter RMA No.");
        }
        public void showUpdatedDetails()
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            cmd = new SqlCommand("Select * from RMA where rma_no='" + textBox_update_rmaNo.Text + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox_update_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                label_status.Text = reader.GetString(reader.GetOrdinal("Status"));
                comboBox_updateStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                ID = reader.GetString(reader.GetOrdinal("userID"));
                //Enable radio Buttons
            }
            con.Close();
            con.Open();
            cmd = new SqlCommand("select firstName from Employee where UserID='" + ID + "'", con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                label_TechName.Text = reader.GetString(reader.GetOrdinal("firstName"));
            comboBox_TechName.SelectedIndex = -1;
            con.Close();
        }
    }
}
