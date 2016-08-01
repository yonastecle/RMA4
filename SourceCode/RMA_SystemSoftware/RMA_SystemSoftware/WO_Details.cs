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
    public partial class WO_Details : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        
        public WO_Details()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();     
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                
               if (textBox_rmaNo.Text != "")
                {
                    string result = null;
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    cmd = new SqlCommand("Select count(1) found from RMA where rma_no=@RMA", con);
                    cmd.Parameters.AddWithValue("@RMA", textBox_rmaNo.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        result = String.Format("{0}", reader["found"]);
                    con.Close();
                    if (result.Equals("0"))
                        System.Windows.Forms.MessageBox.Show("RMA not found. Enter a Valid RMA#");
                    else
                    {
                        con.Open();
                        da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
                        ds = new DataSet();
                        da.Fill(ds, "Searched Record");
                        dataGridView_WODetails.DataSource = ds.Tables["Searched Record"];
                        con.Close();
                    }
                }
                else
                    System.Windows.Forms.MessageBox.Show("Please Enter RMA No. ");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        
    }
}
