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
        string Rtype;

        public Receiving()
        {
            InitializeComponent();
            comboBox_Status.Items.Add("Received");
            comboBox_Status.Items.Add("Wait");
            comboBox_Status.Items.Add("Close");
         
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
                    Rtype = reader.GetString(reader.GetOrdinal("type"));

                  
                    if (Rtype == "Repair")//||Rtype=="Replace"|| Rtype=="Repair/Replace")
                    {
                        repair.Enabled = true;
                    }
                    else //if (Rtype== "Refund")
                    {
                        refund.Enabled = true;
                    }
                    /*else
                    {
                        repair.Enabled = false;
                        refund.Enabled = false;
                    }*/
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
                    Rtype = reader.GetString(reader.GetOrdinal("type"));
                    if(Rtype=="Repair" )//||Rtype=="Replace"|| Rtype=="Repair/Replace")
                    {
                        repair.Enabled = true;
                    }
                    else //if (Rtype== "Refund")
                           {
                        refund.Enabled = true;
                           }
                    /*else
                    {
                        repair.Enabled = false;
                        refund.Enabled = false;
                    }*/

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
