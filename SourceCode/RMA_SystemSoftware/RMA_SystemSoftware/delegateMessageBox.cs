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
        SqlCommand cmd;
        int result;

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
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
              

             // SqlParameter out_total = new SqlParameter("@total", SqlDbType.Int) { Direction = ParameterDirection.Output };
             //   con.Open();
             //   cmd = new SqlCommand(" sp_recordsInNotes", con);
             //   cmd.CommandType = CommandType.StoredProcedure;
             //   cmd.Parameters.Add(new SqlParameter("@rma", RMA));
                
             //   cmd.Parameters.Add(out_total);

             //String result= out_total.Value; //Not sure what to use here

                

            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
           
          
        }

        
    }
}
