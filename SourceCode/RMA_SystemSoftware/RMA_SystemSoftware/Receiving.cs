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
    public partial class Receiving : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter da;
        DataSet ds;
        WO_Details details = new WO_Details();
        Supervisor sup = new Supervisor();
        string req_type;
        public string u_id { get; set; }
        string result = null;
     
        public Receiving()
        {
            InitializeComponent();
            comboBox_Status.Items.Add("Received");
            comboBox_Status.Items.Add("Wait");
            comboBox_Status.Items.Add("Close");
            comboBox_Status.Items.Add("Refund");
            comboBox_Status.Items.Add("Waiting to be assigned");//Disable for Receiving staff
            comboBox_Status.Items.Add("Open");//to be removed, Receiving Staff can't change the status to Open

        }
        
        private void Receiving_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select FirstName,userType from Employee where UserID='"+u_id+"'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label_helloEmp.Text = reader.GetString(reader.GetOrdinal("firstName"));
                   
                        
                }
                   
                con.Close();
                fill_listbox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        
        private void button_refresh_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) con.Close();
            listBox_Open.Items.Clear();
            listBox_Received.Items.Clear();
            listBox_Wait.Items.Clear();
            textBox_rmaNo.Clear();
            Receiving_Load(this, null);
            fill_grid(); 

        }

        public void fill_listbox()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Open'", con);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_Open.Items.Add(rma_no);
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Received'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_Received.Items.Add(rma_no);
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Wait'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_Wait.Items.Add(rma_no);
                }
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void listBox_Open_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioB_refund.Checked = false;
            RadioB_repair.Checked = false;
            RadioB_replace.Checked = false;

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + listBox_Open.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  
                    textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                    label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                    comboBox_Status.Text = reader.GetString(reader.GetOrdinal("Status"));
                    req_type = reader.GetString(reader.GetOrdinal("type"));

                }
            
                if (req_type.ToLower().Contains("replace"))
                {
                   RadioB_replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                   RadioB_refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    RadioB_repair.Checked = true;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox_Received_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioB_refund.Checked = false;
            RadioB_repair.Checked = false;
            RadioB_replace.Checked = false;
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + listBox_Received.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                    label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                    comboBox_Status.Text = reader.GetString(reader.GetOrdinal("Status"));
                    req_type = reader.GetString(reader.GetOrdinal("type"));
                }
                    if (req_type.ToLower().Contains("replace"))
                    {
                        RadioB_replace.Checked = true;
                    }
                    else if (req_type.ToLower().Contains("refund"))
                    {
                        RadioB_refund.Checked = true;
                    }
                    else if (req_type.ToLower().Contains("repair"))
                    {
                        RadioB_repair.Checked = true;
                    }
                   
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void listBox_Wait_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioB_refund.Checked = false;
            RadioB_repair.Checked = false;
            RadioB_replace.Checked = false;
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + listBox_Wait.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                    label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                    comboBox_Status.Text = reader.GetString(reader.GetOrdinal("Status"));
                    req_type = reader.GetString(reader.GetOrdinal("type"));
                }   
                    if (req_type.ToLower().Contains("replace"))
                    {
                        RadioB_replace.Checked = true;
                    }
                    else if (req_type.ToLower().Contains("refund"))
                    {
                        RadioB_refund.Checked = true;
                    }
                    else if (req_type.ToLower().Contains("repair"))
                    {
                        RadioB_repair.Checked = true;
                    }
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                if (RadioB_replace.Checked == true || RadioB_repair.Checked == true || RadioB_refund.Checked == true)
                {
                    cmd = new SqlCommand("update RMA set Status ='" + comboBox_Status.Text + "',type ='" + req_type + "'where rma_no='" + textBox_rmaNo.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Changes Saved..Press Refresh! ");
                }
                else
                    MessageBox.Show("Please choose type of request!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioB_repair_CheckedChanged(object sender, EventArgs e)
        {
            req_type = " Repair";
        }

        private void RadioB_replace_CheckedChanged(object sender, EventArgs e)
        {
            req_type = " Replace";
        }

        private void RadioB_refund_CheckedChanged(object sender, EventArgs e)
        {
            req_type = " Refund";
        }

        private void button_verified_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("update RMA set Status = 'Waiting to be assigned' where rma_no='" + textBox_rmaNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Request Added to Queue for Technician Assignment!! Press Refresh. ");
                con.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

               
    
        public void fill_grid()
        {
            da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA", con);
            ds = new DataSet();
            da.Fill(ds, "RMA");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    fill_grid();
                    con.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_rmaNo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label_currentStatus.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox_Status.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            req_type = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            if (req_type.ToLower().Contains("replace"))
            {
                RadioB_replace.Checked = true;
            }
            else if (req_type.ToLower().Contains("refund"))
            {
                RadioB_refund.Checked = true;
            }
            else if (req_type.ToLower().Contains("repair"))
            {
                RadioB_repair.Checked = true;
            }
        }

        private void button_Show_Click(object sender, EventArgs e)
        {
            if (textBox_rmaNo.Text != "")
            {
                con.Open();
               
                da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
                ds = new DataSet();
                da.Fill(ds, "Single Record");
                dataGridView1.DataSource = ds.Tables["Single Record"];

                con.Close();
            }
            else
                MessageBox.Show("Please Enter RMA No. ");
        }

        private void textBox_rmaNo_KeyDown(object sender, KeyEventArgs e)
        {
          
            RadioB_refund.Checked = false;
            RadioB_repair.Checked = false;
            RadioB_replace.Checked = false;
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    cmd = new SqlCommand("select count(rma_no) found from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result = String.Format("{0}", reader["found"]);
                    }
                    con.Close();


                    if (result.Equals("1"))
                    {
                        con.Open();
                        cmd = new SqlCommand("Select * from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                            label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                            comboBox_Status.Text = reader.GetString(reader.GetOrdinal("Status"));
                            req_type = reader.GetString(reader.GetOrdinal("type"));
                        }

                        if (req_type.ToLower().Contains("replace"))
                        {
                            RadioB_replace.Checked = true;
                        }
                        else if (req_type.ToLower().Contains("refund"))
                        {
                            RadioB_refund.Checked = true;
                        }
                        else if (req_type.ToLower().Contains("repair"))
                        {
                            RadioB_repair.Checked = true;
                        }
                        con.Close();
                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#.");
                }
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

       
    }
}
