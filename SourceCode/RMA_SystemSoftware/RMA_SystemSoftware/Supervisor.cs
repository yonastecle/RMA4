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
        SqlDataAdapter da;
        DataSet ds;
        WO_Details details = new WO_Details();

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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Supervisor_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select firstName from Employee where userType = 'Help Desk'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    combobox_AuthorizeUser.Items.Add(read["firstName"]);
                }
                read.Close();
                cmd = new SqlCommand("Select Company from Client ", con);
                read = cmd.ExecuteReader();
                while(read.Read())
                {
                    comboBox_clientName.Items.Add(read["Company"]);
                }
                read.Close();
                read.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void authorizeButton_Click(object sender, EventArgs e)
        {


        }

        public void fill_grid()
        {

            da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA", con);
            ds = new DataSet();
            da.Fill(ds, "All WO Details");
            details.dataGridView_WODetails.DataSource = ds.Tables[0];
            this.Close();
            details.Show();
        }
        private void VielAllButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                fill_grid();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowDeatilsButton_Click(object sender, EventArgs e)
        {
            string result = null;
            if (textBox_View_RmaNo.Text != "")
            {
                try
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    cmd = new SqlCommand("Select count(rma_no) found from RMA where rma_no = '" + textBox_View_RmaNo.Text + "'", con);
                    read = cmd.ExecuteReader();
                    while (read.Read())
                        result = String.Format("{0}", read["found"]);
                    con.Close();
                    if (result.Equals("1"))
                    {
                        if (con.State == ConnectionState.Open) con.Close();
                        con.Open();
                        da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA where rma_no='" + textBox_View_RmaNo.Text + "'", con);
                        ds = new DataSet();
                        da.Fill(ds, "Single RMA Details");
                        details.dataGridView_WODetails.DataSource = ds.Tables["Single RMA Details"];
                        this.Close();
                        details.Show();
                        con.Close();
                    }
                    else if(result.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
                MessageBox.Show("Please enter RMA# !");

       }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            this.Close();
            RMA_Report report = new RMA_Report();
            report.Show();
        }
    }
}

