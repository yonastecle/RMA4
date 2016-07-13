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

        public string u_id;
        public string passid
        {
            get { return u_id; }
            set { u_id = value; }
        }
        public HelpDesk()
        {
            InitializeComponent();
        }

        private void HelpDesk_Load(object sender, EventArgs e)
        {
            try
            {
                groupBox_UpdateDetails.Enabled = false;
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                cmd = new SqlCommand("select firstName from Employee where UserID ='"+u_id+"'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    label_helloEmp.Text = reader.GetString(reader.GetOrdinal("firstName"));
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public void AuthorizedUser()
        {
            groupBox_UpdateDetails.Enabled = true;
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

        private void UpdateButton_Click(object sender, EventArgs e)
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
    }
}
