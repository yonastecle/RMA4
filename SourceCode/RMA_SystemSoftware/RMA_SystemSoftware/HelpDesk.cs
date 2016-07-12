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

            private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        
    }
}
