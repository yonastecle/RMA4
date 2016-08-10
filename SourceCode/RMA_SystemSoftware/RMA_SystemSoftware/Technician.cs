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
    public partial class Technician : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter da;
        DataSet ds;
        DialogBox msg_box;
        History histry = new History();
        GrabData grab = new GrabData();
        WO_Details details = new WO_Details();
        Tech_Open techopen = new Tech_Open();
        Supervisor sup = new Supervisor();
        string req_type, result=null;
        public string u_id { get; set; }
      
        public Technician()
        {
            InitializeComponent();
            comboBox_status.Items.Add("Hold");
            comboBox_status.Items.Add("Complete");
            comboBox_status.Items.Add("Refund");
            comboBox_status.Items.Add("Assigned");//Disable it for Technician
           
        }
        public void Technician_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                label_helloEmp.Text = grab.getEmployeeName(u_id);                            
                con.Close();
                fill_listbox();
                showTech_WOQueue();
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
            
        }
        private void OpenButton_Click(object sender, EventArgs e)
        {
            if(textBox_rmaNo.Text!="")
            {
                //this.Hide();
                techopen.rma_no = textBox_rmaNo.Text;
                techopen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter RMA#.");
            }
           
        }
       
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }
        public void fill_listbox()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status='waiting to be assigned' and userID='"+u_id+"'", con);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_newRequest.Items.Add(rma_no);
                }
                con.Close();
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        private void listBox_newRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            req_type = grab.autofill(listBox_newRequest.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_status, ref radioButton_repair, ref radioButton_replace, ref radioButton_refund);
        }

        private void delegateButton_Click(object sender, EventArgs e)
        {
            msg_box = new DialogBox();
            if (textBox_rmaNo.Text != "")
            {
                string result = null;
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select count (1) total from Notes where RMA_no = @ID", con);
                cmd.Parameters.AddWithValue("@ID", textBox_rmaNo.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                result = String.Format("{0}", reader["total"]);
  
                
                if (result.Equals("0"))
                    MessageBox.Show("RMA record not found","Invalid RMA#");
                else
                {
                    msg_box.RMA = textBox_rmaNo.Text;
                    msg_box.stat_type = "hold";
                    msg_box.ShowDialog();
                }
               
            }
            else
            {
                MessageBox.Show(" Please enter RMA #","Empty Text Field");
            }                          
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
             
                if (textBox_rmaNo.Text != "")
                {
                    if (radioButton_repair.Checked == true || radioButton_replace.Checked == true || radioButton_refund.Checked == true)
                    {

                        con.Open();
                        //Console.WriteLine("Enters Update!!"+ textBox_rmaNo.Text);
                        cmd = new SqlCommand("update RMA set Status='" + comboBox_status.Text + "',type='" + req_type + "'where rma_no='"+textBox_rmaNo.Text+ "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        //Console.WriteLine("Exits Update!!"+comboBox_status.Text);
                      MessageBox.Show("Changes Updated... Press Refresh !");
                }
                else
                {
                        MessageBox.Show("Please Choose the Type of Request");
                }
            }
                else
                    MessageBox.Show("Please enter RMA#!");
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void radioButton_repair_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Repair";
        }

        private void radioButton_replace_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "replace";
        }

        private void radioButton_refund_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Refund";
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            listBox_newRequest.Items.Clear();
            fill_listbox();
            showTech_WOQueue();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            string result = null;
            try
            {
                if (textBox_rmaNo.Text != "")
                {
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    if (result.Equals("1"))
                    {
                        con.Open();
                        da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,category,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
                        ds = new DataSet();
                        da.Fill(ds, "Details");
                        dataGrid_ShowDetails.DataSource = ds.Tables["Details"];
                        con.Close();
                    }
                    else if (result.Equals("0"))
                   MessageBox.Show("RMA# not found.Please enter a valid RMA#");
                }
                else
                   MessageBox.Show("Please enter RMA#!");
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            sup.fill_grid();
        }

        private void listBox_newRequest_DoubleClick(object sender, EventArgs e)
        {
            ProceedWindow prcd = new ProceedWindow();
            prcd.rma_no = listBox_newRequest.Text;
            prcd.Show();
           
        }

        private void textBox_rmaNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    if (result.Equals("1"))
                    {
                        req_type = grab.autofill(textBox_rmaNo.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_status, ref radioButton_repair, ref radioButton_replace, ref radioButton_refund);
                    }
                    else if (result.Equals("0"))
                  MessageBox.Show("RMA not found.Please enter a valid RMA#.");
                }
            }
            catch (Exception ex)
            {
             MessageBox.Show(ex.Message);
            }
        }

        private void dataGrid_Tech_WOQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGrid_Tech_WOQueue.Rows[e.RowIndex];

                textBox_rmaNo.Text = row.Cells[0].Value.ToString();
                comboBox_status.Text = label_currentStatus.Text = row.Cells[3].Value.ToString();
                req_type = row.Cells[2].Value.ToString();
                if (req_type.ToLower().Contains("replace"))
                {
                    radioButton_replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                    radioButton_refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    radioButton_repair.Checked = true;
                }


            }
        }

        private void comboBox_status_SelectionChangeCommitted(object sender, EventArgs e)
        {
            msg_box = new DialogBox();

            if (textBox_rmaNo.Text != "")
            {
                msg_box.stat_type = comboBox_status.Text.ToLower();
                msg_box.RMA = textBox_rmaNo.Text;
                if (msg_box.stat_type.Contains("hold"))
                {
                    //MessageBox.Show("Call the screen for hold, update status");
                    msg_box.ShowDialog();
                }

                else if (msg_box.stat_type.Contains("complete"))
                {
                    msg_box.ShowDialog();
                    //  MessageBox.Show("update resolution,add radio button", "Completed");
                }
                else
                {
                  
                }

            }
        }

        private void ViewHistoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_rmaNo.Text == "")
                    MessageBox.Show("Please enter RMA#", "Empty Field!!");
                else
                {
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    if (result.Equals("1"))
                    {
                        histry.rma.rma_no = textBox_rmaNo.Text;
                        histry.ShowDialog();
                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found.Please enter a valid RMA#","Invalid Entry!!");                  
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void showTech_WOQueue()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                da = new SqlDataAdapter("select rma_no as 'RMA#', date_assigned as 'Date Assigned',type as 'Type',Status, quantity as 'Quantity',invoiceNo as' Invoice No.' from RMA where userID='" + u_id + "'and Status NOT IN('waiting to be assigned','Complete')", con);
                ds = new DataSet();
                da.Fill(ds, "Tech WO Queue");
                dataGrid_Tech_WOQueue.DataSource = ds.Tables["Tech WO Queue"];
                con.Close();
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }        
    }
}
