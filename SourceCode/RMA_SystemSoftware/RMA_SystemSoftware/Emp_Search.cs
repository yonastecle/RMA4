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
    public partial class Emp_Search : Form
    {
        public string empID { get; set; }
        public string empName { get; set; }
        String id, name;

        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
                
        public Emp_Search()
        {
            InitializeComponent();
        }
        public void save_param_values()
        {
          
            id = empID;
            name = empName;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Supervisor sup = new Supervisor();
            sup.Show();
        }

        private void Emp_Search_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand(" select * from Employee  where UserID='" + id + "' or firstName='" + name + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label_userId.Text = id;
                    //Find the error
                    /*
                    textBox_password.Text = dr.GetString("password");
                    comboBox_usertype.Text = dr.GetString("userType");
                    comboBox_usertag.Text = dr.GetString("userTag");
                    textBox_fname.Text = dr.GetString("firstName");
                    textBox_lname.Text = dr.GetString("lastName");
                    textBox_email.Text = dr.GetString("email");
                    textBox_ext.Text = dr.GetString("Ext");
                    textBox_Fax.Text = dr.GetString("Fax");*/
                              
              
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
