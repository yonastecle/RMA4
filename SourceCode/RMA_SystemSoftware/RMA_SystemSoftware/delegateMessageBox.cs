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
    public partial class delegateMessageBox : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");

        public string RMA { get; set; }
        public void setdata()
        {
            label_RMA_No.Text = RMA;
        }
       
        public delegateMessageBox()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Technician tech = new Technician();
            tech.Show();
        }

        private void DelegateButton_Click(object sender, EventArgs e)
        {
            string result = null;
           // label3.Text = "RAMAAJJ";

            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            string queryString = "Select count (1) total from Notes where RMA_no = @ID";
            SqlCommand command = new SqlCommand(queryString, con);
            command.Parameters.AddWithValue("@ID", RMA);
            SqlDataReader reader = command.ExecuteReader();
            
                while (reader.Read())
                {
                    result = String.Format("{0})",reader["total"]);
                }

            textBox_delg_reason.Text = result + "" + RMA;
            
           

            //Console.WriteLine("Tanmeet Kaur Rekhi");
            //            MessageBox.Show("The calculations are complete", "My Application",
            //MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            //            label3.Text = result +" "+RMA;
            // SqlParameter out_total = new SqlParameter("@total", SqlDbType.Int) { Direction = ParameterDirection.Output };
            //   con.Open();
            //   cmd = new SqlCommand(" sp_recordsInNotes", con);
            //   cmd.CommandType = CommandType.StoredProcedure;
            //   cmd.Parameters.Add(new SqlParameter("@rma", RMA));

            //   cmd.Parameters.Add(out_total);

            //String result= out_total.Value; //Not sure what to use here



        }
            //catch ( Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
                                          
        }
            
    }

