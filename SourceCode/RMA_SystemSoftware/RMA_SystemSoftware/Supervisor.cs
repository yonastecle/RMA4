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
    public partial class Supervisor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        string s;
        

        public Supervisor()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        //Split RMA button
        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            Split_RMA split = new Split_RMA();
            split.Show();

        }
        //Logout
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
        //Help
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
        //Add new emp Button
        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
            Add_emp add_emp = new Add_emp();
            add_emp.Show();
        }
        //View All employee details button
        private void ViewAllbutton_Click(object sender, EventArgs e)
        {
            this.Close();
            EmpInfo info = new EmpInfo();
            info.Show();
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox_EmpID.Text != "" || textBox_EmpName.Text != "")
                {
                    s = "Select * from Employee where UserID ='" + textBox_EmpID.Text + "' or firstName ='" + textBox_EmpName.Text + "'";
                    con.Open();
                    cmd = new SqlCommand(s, con);
                    read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        Emp_Search search = new Emp_Search();
                        if (textBox_EmpID.Text == "")
                        {
                            search.empID = null;
                            search.empName = textBox_EmpName.Text;
                            search.save_param_values();
                        }
                        else if (textBox_EmpName.Text == "")
                        {
                            search.empName = null;
                            search.empID = textBox_EmpID.Text;
                            search.save_param_values();
                        }
                        else
                        {

                            search.empID = textBox_EmpID.Text;
                            search.empName = textBox_EmpName.Text;
                            search.save_param_values();
                        }
                        this.Close();
                        search.Show();

                    }
                    else
                    {
                        MessageBox.Show("No Record found!");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter ID or Name of the Employee.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //read.Close();
                con.Close();

            }
        }
    }
}
