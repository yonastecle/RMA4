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
        string id, name;

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
                    textBox_password.Text = dr.GetString(dr.GetOrdinal("password"));
                    comboBox_usertype.Text = dr.GetString(dr.GetOrdinal("userType"));
                    comboBox_usertag.Text = dr.GetString(dr.GetOrdinal("userTag"));
                    textBox_fname.Text = dr.GetString(dr.GetOrdinal("firstName"));
                    textBox_lname.Text = dr.GetString(dr.GetOrdinal("lastName"));
                    textBox_email.Text = dr.GetString(dr.GetOrdinal("email"));
                    textBox_Fax.Text = dr.GetString(dr.GetOrdinal("Fax"));
                    textBox_ext.Text = Convert.ToString(dr["Ext"]);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
