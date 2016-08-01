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
        string del_record;


        public EmpInfo()
        {
            InitializeComponent();
        }

        private void EmpInfo_Load(object sender, EventArgs e)
        {
            if(con.State== ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            try
            {
                fill_grid();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void fill_grid()
        {
            da = new SqlDataAdapter("Select UserID, userType AS 'User Type', userTag AS Tag,firstName AS 'First Name' ,lastName AS 'Last Name' ,email AS 'Email Address' ,Ext,Fax from Employee", con);
            ds = new DataSet();
            da.Fill(ds, "Details of all Employees");
            dataGridView1.DataSource = ds.Tables[0];
        }
            
         
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbdl = new SqlCommandBuilder(da);
                da.Update(ds, "Details of all Employees");
                System.Windows.Forms.MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            try
            {
                fill_grid();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Supervisor sup = new Supervisor();
            sup.Show();
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //  da = new SqlDataAdapter("Delete from Employee where UserID='" + del_record + "'", con);
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Employee where UserID='" + del_record + "'";
                cmd.ExecuteNonQuery();
                fill_grid();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                del_record = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }

        }

        
    }
}
