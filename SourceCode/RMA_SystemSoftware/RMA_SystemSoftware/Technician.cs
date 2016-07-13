﻿using System;
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
        string req_type;
        public string u_id;
        public string passid
        {
            get { return u_id; }
            set { u_id = value; }
        }

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
                cmd = new SqlCommand("select FirstName from Employee where UserID='" + u_id + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                label_helloEmp.Text = reader.GetString(reader.GetOrdinal("firstName"));
                con.Close();
                fill_listbox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tech_Open t_open = new Tech_Open();
            t_open.Show();
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
                cmd = new SqlCommand("Select rma_no from RMA where Status='Assigned'", con);
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
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no='" + listBox_newRequest.Text + "'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    textBox_rmaNo.Text = reader.GetString(reader.GetOrdinal("rma_no"));
                    label_currentStatus.Text = reader.GetString(reader.GetOrdinal("Status"));
                    comboBox_status.Text = reader.GetString(reader.GetOrdinal("Status"));
                }
                //Enable radio button
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delegateButton_Click(object sender, EventArgs e)
        {
          
            delegateMessageBox mesg_box = new delegateMessageBox();
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
                mesg_box.result = result;
                
                if (result.Equals("0"))
                    MessageBox.Show("RMA record not found");
                else
                {
                    mesg_box.RMA = textBox_rmaNo.Text;
                    mesg_box.setdata();
                    this.Hide();
                    mesg_box.Show();
                }
               
            }
            else
            {
                MessageBox.Show(" Please enter a valid RMA #");
            }
            
                
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
             
                if (textBox_rmaNo.Text != "")
                {
                    if(radioButton_repair.Checked== true|| radioButton_replace.Checked== true||radioButton_refund.Checked== true)
                    {
                        con.Open();
                        cmd = new SqlCommand("update RMA set Status='" + comboBox_status.Text + "',type='" + req_type + "'where rma_no='"+textBox_rmaNo.Text+ "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
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
        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }
    }
}
