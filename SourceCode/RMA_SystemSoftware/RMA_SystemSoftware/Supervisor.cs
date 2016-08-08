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
using RMA_SystemSoftware.DataSet1TableAdapters;

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
        Tech_Open techopen = new Tech_Open();
        Emp_Search search = new Emp_Search();
        Split_RMA split = new Split_RMA();
        GrabData grab = new GrabData();
        string s, req_type, result = null,rmaNumber ="";
        int cat;
        public string u_id { get; set; }       


        public Supervisor()
        {
            InitializeComponent();
            comboBox_status.Items.Add("Open");
            comboBox_status.Items.Add("Received");
            comboBox_status.Items.Add("Wait");
            comboBox_status.Items.Add("Waiting to be assigned");
            comboBox_status.Items.Add("Assigned");
            comboBox_status.Items.Add("Hold");
            comboBox_status.Items.Add("Refund");
            comboBox_status.Items.Add("Complete");
            comboBox_status.Items.Add("Close");
            comboBox_updateStatus.Items.Add("Open");//Can be omitted!
            comboBox_updateStatus.Items.Add("Received");
            comboBox_updateStatus.Items.Add("Wait");
            comboBox_updateStatus.Items.Add("Waiting to be assigned");
            comboBox_updateStatus.Items.Add("Assigned");
            comboBox_updateStatus.Items.Add("Hold");
            comboBox_updateStatus.Items.Add("Refund");
            comboBox_updateStatus.Items.Add("Complete");
            comboBox_updateStatus.Items.Add("Close");
        }
        private void SplitRMAButton_Click(object sender, EventArgs e)
        {
            split.rma_no = textBox_rmaNo.Text;
            if (textBox_rmaNo.Text != "")
            {
                this.Hide();
                split.Show();
            }
            else
              MessageBox.Show("Enter RMA No.");
        }

        private void LogoutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }
        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }
        private void AddNewEmpButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Add_emp add_emp = new Add_emp();
            add_emp.Show();
        }
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
                      MessageBox.Show("No Employee Record found!","Not Found!!");
                        textBox_EmpID.Clear();
                        textBox_EmpName.Clear();

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
                con.Close();

            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) con.Close();
            listBox_newRequests.Items.Clear();
            listBox_refundRequest.Items.Clear();
            listBox_requestOnHold.Items.Clear();
            fill_listbox();
            if (textBox_rmaNo.Text != "")
            {
                textBox_rmaNo.Clear();
                radioButton_CAT1.Checked = radioButton_CAT2.Checked = radioButton_CAT3.Checked = radioButton_CAT4.Checked = radioB_repair.Checked = radioB_replace.Checked = radioB_refund.Checked = false;
                comboBox_updateStatus.SelectedIndex = comboBox_TechName.SelectedIndex = -1;
                textBox_StatusUpdates.Clear();
            }
                
        }

    

        public void fill_listbox()
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Open'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string rma_no = read.GetString(read.GetOrdinal("rma_no"));
                    listBox_newRequests.Items.Add(rma_no);
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Hold'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string rma_no = read.GetString(read.GetOrdinal("rma_no"));
                    listBox_requestOnHold .Items.Add(rma_no);
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where type= 'Refund'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    string rma_no = read.GetString(read.GetOrdinal("rma_no"));
                    listBox_refundRequest.Items.Add(rma_no);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Supervisor_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                label_helloEmp.Text = grab.getEmployeeName(u_id);                
                con.Close();

                fill_listbox();
              
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
                cmd = new SqlCommand("select firstName from Employee where usertype IN('Technician','Help Desk')", con);
                read = cmd.ExecuteReader();
                while(read.Read())
                {
                    comboBox_TechName.Items.Add(read["firstName"]);
                }
                read.Close();
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
               
        private void ViewAllWOButton_Click(object sender, EventArgs e)
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
                    result = grab.serachRMA(textBox_View_RmaNo.Text);                  
                    con.Close();
                    if (result.Equals("1"))
                    {
                        if (con.State == ConnectionState.Open) con.Close();
                        con.Open();
                        da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA where rma_no='" + textBox_View_RmaNo.Text + "'", con);
                        ds = new DataSet();
                        da.Fill(ds, "Single RMA Details");
                        details.dataGridView_WODetails.DataSource = ds.Tables["Single RMA Details"];
                       
                        details.ShowDialog();
                        con.Close();
                    }
                    else if(result.Equals("0"))
                    MessageBox.Show("RMA not found. Please enter a valid RMA#","Not Found");

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
            try
            {                
                ReportGeneration report = new ReportGeneration();
                Console.WriteLine(" CrystalReport rep = new CrystalReport()");
                CrystalReport rep = new CrystalReport();
                Console.WriteLine(" DataSet1 ds = new DataSet1();");
                DataSet1 ds = new DataSet1();
                Console.WriteLine(" DataTable1TableAdapter adp = new DataTable1TableAdapter();");
                DataTable1TableAdapter adp = new DataTable1TableAdapter();
                
                adp.Fill(ds.DataTable1);
                Console.WriteLine(" adp.Fill(ds.DataTable1);");
               
                rep.SetDataSource(ds);
                Console.WriteLine(" rep.SetDataSource(ds);");

                rep.SetParameterValue("StatusParam", comboBox_status.Text);
                Console.WriteLine(" report.crystalReportViewer1.ReportSource = rep;");
                report.crystalReportViewer1.ReportSource = rep;
                report.Show();
            }
            catch(Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }

        }

        private void RMASearchButton_Click(object sender, EventArgs e)
        {           
            fill_grid();
        }
        public void fill_grid()
        {

            da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,category as 'CAT',ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA", con);
            ds = new DataSet();
            da.Fill(ds, "All WO Details");
            details.dataGridView_WODetails.DataSource = ds.Tables[0];
            details.ShowDialog();
        }

        private void listBox_newRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_newRequests.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref req_type, ref cat, ref radioB_repair, ref radioB_replace, ref radioB_refund, ref radioButton_CAT1, ref radioButton_CAT2, ref radioButton_CAT3, ref radioButton_CAT4, ref label_TechName, ref textBox_StatusUpdates);            
        }
        private void listBox_requestOnHold_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_requestOnHold.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref req_type, ref cat, ref radioB_repair, ref radioB_replace, ref radioB_refund, ref radioButton_CAT1, ref radioButton_CAT2, ref radioButton_CAT3, ref radioButton_CAT4, ref label_TechName, ref textBox_StatusUpdates);
        }
        private void listBox_refundRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_refundRequest.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref req_type, ref cat, ref radioB_repair, ref radioB_replace, ref radioB_refund, ref radioButton_CAT1, ref radioButton_CAT2, ref radioButton_CAT3, ref radioButton_CAT4, ref label_TechName, ref textBox_StatusUpdates);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (textBox_rmaNo.Text != "")
            {           
                techopen.rma_no = textBox_rmaNo.Text;
                techopen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter RMA#.","Empty Field");
            }           
        }       

        private void ConfirmTechChangeButton_Click(object sender, EventArgs e)
        {
            grab.techChange(textBox_rmaNo.Text, ref comboBox_TechName);
         }
      
        private void updateButton_Click(object sender, EventArgs e)
        {
            string found = null;
            string updateStatus = comboBox_updateStatus.Text.ToString();
            string rmaNum = textBox_rmaNo.Text.ToString();

            Console.WriteLine("Update Status after Update Button Click: " + updateStatus);
            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                Console.WriteLine("textBox_rmaNo.Text != " + textBox_rmaNo.Text.ToString() + " Before if");
                if (textBox_rmaNo.Text.ToString() != "")
                {
                    Console.WriteLine("radioB_replace Checked: " + radioB_replace.Checked.ToString() + " ~ radioB_repair Checked: " + radioB_repair.Checked.ToString() );
                    if ((radioB_replace.Checked == true || radioB_repair.Checked == true || radioB_refund.Checked == true) && (radioButton_CAT1.Checked == true || radioButton_CAT2.Checked == true || radioButton_CAT3.Checked == true || radioButton_CAT4.Checked == true))
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE RMA SET Status ='" + updateStatus + "', type ='" + req_type + "', category='" + cat + "'WHERE rma_no='" + rmaNumber + "'", con);
                        cmd.ExecuteNonQuery();
                        //Adding RMA to Notes Table, if RMA not found in the Notes Table.(Additionally need to work on adding RMA# to the Notes table as and when a new RMA request comes into the DB)
                        found = grab.serachRMA(rmaNumber);
                        con.Close();
                        con.Open();
                        if (found.Equals("0"))
                        {
                          // adding dummy value to Description. LINK IT TO THE CSM DB to fetch the description.
                           cmd = new SqlCommand("INSERT INTO Notes (RMA_no, description,statusUpdates) Values ('"+rmaNumber+"','Dummy','"+textBox_StatusUpdates.Text+"')", con);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("UPDATE  Notes  SET Notes.statusUpdates = '" + textBox_StatusUpdates.Text + "'FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no = '" + rmaNumber + "'", con);
                            cmd.ExecuteNonQuery();
                        }

                        con.Close();
                         MessageBox.Show("Changes Saved..Press Refresh! ");
                    }

                    else
                        MessageBox.Show("Please choose Type of request/Category!");
                }
                else
                    MessageBox.Show("Please enter the RMA#!","Empty Field");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        private void textBox_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                con.Open();
                textBox_EmpID.Text = grab.getEmployeeID(textBox_EmpName.Text);
                con.Close();
            }              
        }

        private void textBox_EmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                con.Open();
                textBox_EmpName.Text = grab.getEmployeeName(textBox_EmpID.Text);
                con.Close();
            }
        }

       
        private void textBox_rmaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            try
            {
                if(e.KeyChar == (char) Keys.Enter)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    con.Close();

                    if (result.Equals("1"))
                    {
                        grab.autofill(textBox_rmaNo.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref req_type, ref cat, ref radioB_repair, ref radioB_replace, ref radioB_refund, ref radioButton_CAT1, ref radioButton_CAT2, ref radioButton_CAT3, ref radioButton_CAT4, ref label_TechName, ref textBox_StatusUpdates);                        
                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#","Not found!");
                 }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void textBox_rmaNo_TextChanged(object sender, EventArgs e)
        {
            rmaNumber = textBox_rmaNo.Text;
        }
        private void radioB_repair_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Repair";
        }

        private void radioB_replace_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Replace";
        }

        private void radioB_refund_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Refund";
        }

        private void radioButton_CAT1_CheckedChanged(object sender, EventArgs e)
        {
            cat = 1;
        }

        private void radioButton_CAT2_CheckedChanged(object sender, EventArgs e)
        {
            cat = 2;
        }

        private void radioButton_CAT3_CheckedChanged(object sender, EventArgs e)
        {
            cat = 3;
        }

        private void radioButton_CAT4_CheckedChanged(object sender, EventArgs e)
        {
            cat = 4;
        }
    }
}

