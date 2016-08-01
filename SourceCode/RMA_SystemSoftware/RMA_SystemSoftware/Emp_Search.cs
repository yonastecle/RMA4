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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand("Delete Employee where UserID='" + label_userId.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                System.Windows.Forms.MessageBox.Show("Employee Record Deleted!");
                label_userId.Text = null;
                textBox_password.Clear();
                comboBox_usertag.SelectedIndex = -1;
                comboBox_usertype.SelectedIndex = -1;
                textBox_fname.Clear();
                textBox_lname.Clear();
                textBox_email.Clear();
                textBox_ext.Clear();
                textBox_Fax.Clear();          
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox_password.Text != "" && comboBox_usertype.SelectedIndex != -1 && textBox_fname.Text != "" && comboBox_usertag.SelectedIndex != -1 && (textBox_email.Text.Contains("@cnbcomputers.com")))
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    cmd = new SqlCommand("Update Employee set password='" + textBox_password.Text + "',userType='" + comboBox_usertype.Text + "',userTag='" + comboBox_usertag.Text + "',firstName='" + textBox_fname.Text + "',lastName='" + textBox_lname.Text + "',email='" + textBox_email.Text + "',Ext='" + textBox_ext.Text + "',Fax='" + textBox_Fax.Text + "'where UserID='" + label_userId.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    System.Windows.Forms.MessageBox.Show("Database Updated!", "Success");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Review the highlighted sections.\n Enter the appropriate details!", "Error");

                    if (textBox_password.Text == "") label4.ForeColor = Color.Red;
                    if (comboBox_usertype.SelectedIndex == -1) label5.ForeColor = Color.Red;
                    if (textBox_fname.Text == "") label6.ForeColor = Color.Red;
                    if (comboBox_usertag.SelectedIndex == -1) label12.ForeColor = Color.Red;
                    if (!(textBox_email.Text.Contains("@cnbcomputers.com"))) label8.ForeColor = Color.Red;
                }

                       
                                                                                       
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        

        private void Emp_Search_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (id == null)
                {
                    cmd = new SqlCommand(" select * from Employee  where firstName='" + name + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label_userId.Text = dr.GetString(dr.GetOrdinal("UserID"));
                        textBox_password.Text = dr.GetString(dr.GetOrdinal("password"));
                        comboBox_usertype.Text = dr.GetString(dr.GetOrdinal("userType"));
                        comboBox_usertag.Text = dr.GetString(dr.GetOrdinal("userTag"));
                       // textBox_fname.Text = Convert.ToString(name);
                        textBox_fname.Text = dr.GetString(dr.GetOrdinal("firstName"));
                        textBox_lname.Text = dr.GetString(dr.GetOrdinal("lastName"));
                        textBox_email.Text = dr.GetString(dr.GetOrdinal("email"));
                        textBox_Fax.Text = dr.GetString(dr.GetOrdinal("Fax"));
                        textBox_ext.Text = Convert.ToString(dr["Ext"]);

                    }
                }
                else
                {
                    cmd = new SqlCommand(" select * from Employee  where UserID='" + id + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label_userId.Text = dr.GetString(dr.GetOrdinal("UserID"));
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
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
        }
       
    }
}
