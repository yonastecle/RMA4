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
            fill_listbox();
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
                mesg_box.RMA = textBox_rmaNo.Text;
                mesg_box.setdata();
                this.Hide();
                mesg_box.Show();
            }
            else
                MessageBox.Show(" Please enter RMA #");

        
              
               /* if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                //data should be updated later, after the request for delegation is sent via message box
                cmd = new SqlCommand("update RMA set Status='Hold' where rma_no='" + textBox_rmaNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                //Ask for approval from Supervisor and update status tab
                MessageBox.Show()            */   
          
        }
    }
}
