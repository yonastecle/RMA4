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
        string req_type;

        public Receiving()
        {
            InitializeComponent();
            comboBox_Status.Items.Add("Received");
            comboBox_Status.Items.Add("Wait");
            comboBox_Status.Items.Add("Close");
            comboBox_Status.Items.Add("Waiting to be assigned");
            comboBox_Status.Items.Add("Open");//to be removed, Receiving Staff can't change the status to Open

        }
        
        private void Receiving_Load(object sender, EventArgs e)
        {
            fill_listbox();
        }
        
        private void button_refresh_Click(object sender, EventArgs e)
        {
            listBox_Open.Items.Clear();
            listBox_Received.Items.Clear();
            Receiving_Load(this, null);

        }

        public void fill_listbox()
        {
            try
            {
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
            try
            {
                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + listBox_Open.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                    label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                    comboBox_Status.Text = reader.GetString(reader.GetOrdinal("Status"));
                    req_type = reader.GetString(reader.GetOrdinal("type"));

                    // Enabling the radio button-Not working
                    if (req_type == "Repair")
                        RadioB_repair.Enabled=true;
                    else if (req_type == "Refund")
                        RadioB_refund.Enabled=true;
                    else
                        RadioB_replace.Enabled=true;
                    
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
            
            try
            {
                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + listBox_Received.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                    label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                    comboBox_Status.Text = reader.GetString(reader.GetOrdinal("Status"));
                    
                    // Enabling the radio button-Not working- Not working 
                   
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
    }
}
