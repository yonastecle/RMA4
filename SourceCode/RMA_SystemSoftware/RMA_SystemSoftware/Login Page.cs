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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select userType from Employee where UserID='"+textBox1.Text+"' and password='"+textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
               

                if (dt.Rows[0][0].ToString() == "Supervisor")
                {
                    this.Hide();
                    Supervisor sup = new Supervisor();
                    sup.Show();
                }
                else if (dt.Rows[0][0].ToString() == "technician")
                {
                    this.Hide();
                    Technician tech = new Technician();
                    tech.Show();
                }
                else if (dt.Rows[0][0].ToString() == "help desk ")
                {
                    this.Hide();
                    HelpDesk hdesk = new HelpDesk();
                    hdesk.Show();
                }
                else if (dt.Rows[0][0].ToString() == "receiving ")
                {
                    this.Hide();
                    Receiving recv = new Receiving();
                    recv.Show();
                }
               
            }
            else
            {
                MessageBox.Show("Invalid User ID and Password !! Please check your credentials ");
               
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

