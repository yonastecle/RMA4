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
    public partial class EmpInfo : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommandBuilder cmdbdl;


        public EmpInfo()
        {
            InitializeComponent();
        }

        private void EmpInfo_Load(object sender, EventArgs e)
        {


            try
            {
                con.Open();
                da = new SqlDataAdapter("Select UserID,userTag AS Tag,firstName AS 'First Name' ,lastName AS 'Last Name' ,email AS 'Email Address' ,Ext,Fax from Employee", con);
                ds = new DataSet();
                da.Fill(ds, "Details of all Employees");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbdl = new SqlCommandBuilder(da);
                da.Update(ds, "Details of all Employees");
                MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
