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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("select userType from Employee where UserID='" + textBox1.Text + "' and password='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {


                    if (dt.Rows[0][0].ToString().ToLower() == "supervisor")
                    {
                        this.Hide();
                        Supervisor sup = new Supervisor();
                        sup.u_id = textBox1.Text;
                        sup.Show();
                    }
                    else if (dt.Rows[0][0].ToString().ToLower() == "technician") 
                    {
                        this.Hide();
                        Technician tech = new Technician();
                        tech.u_id = textBox1.Text;
                        tech.Show();
                    }
                    else if (dt.Rows[0][0].ToString().ToLower() == "help desk ")
                    {
                        this.Hide();
                        HelpDesk hdesk = new HelpDesk();
                        hdesk.u_id = textBox1.Text;
                        hdesk.Show();
                    }
                    else if (dt.Rows[0][0].ToString().ToLower() == "receiving ")
                    {
                        this.Hide();
                        Receiving recv = new Receiving();
                        recv.u_id = textBox1.Text;
                        recv.Show();
                    }

                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Invalid User ID and Password !! Please check your credentials ");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

      
    }
  }

