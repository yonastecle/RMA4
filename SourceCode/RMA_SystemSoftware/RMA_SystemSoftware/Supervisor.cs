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
using RMA_SystemSoftware.RMA_SystemDataSetTableAdapters;
 

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
        Tech_Open techopen;
        Notes notes = new Notes();
        History histry = new History();
        Emp_Search search = new Emp_Search();
        Split_RMA split = new Split_RMA();
        GrabData grab = new GrabData();
        string s, result = null, rmaNumber = "", enteredTxt = "", reportParam="";
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
            comboBox_type.Items.Add("Repair");
            comboBox_type.Items.Add("Replace");
            comboBox_type.Items.Add("Refund");
            comboBox_cat.Items.Add("CAT1 (1-2 pieces");
            comboBox_cat.Items.Add("CAT2(3-4 pieces) ");
            comboBox_cat.Items.Add("CAT3(5-10 pieces) ");
            comboBox_cat.Items.Add("CAT4(10+ pieces) ");
            comboBox_cat.Items.Add("CAT5(Others)");
            comboBox_updateStatus.Items.Add("Open");//Can be omitted!
            comboBox_updateStatus.Items.Add("Received");
            comboBox_updateStatus.Items.Add("Wait");
            comboBox_updateStatus.Items.Add("Waiting to be assigned");
            comboBox_updateStatus.Items.Add("Assigned");
            comboBox_updateStatus.Items.Add("Hold");
            comboBox_updateStatus.Items.Add("Refund");
            comboBox_updateStatus.Items.Add("Complete");
            comboBox_updateStatus.Items.Add("Close");          
            comboBox_status.SelectedIndex = -1;
            comboBox_clientName.SelectedIndex = -1;
            dateTimePicker1.Checked = false;
            dateTimePicker2.Checked = false;
           
           
        }
        private void Supervisor_Load(object sender, EventArgs e)
        {

            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                label_helloEmp.Text = grab.getEmployeeName(u_id);
                con.Close();

                grab.fill_listbox(ref listBox_newRequests, ref listBox_requestOnHold, ref listBox_refundRequest, ref listBox_waitingToBeAssigned, ref listBox_requestsAssigned);            
                con.Open();
                cmd = new SqlCommand("Select Company from Client ", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    comboBox_clientName.Items.Add(read["Company"]);
                }
                read.Close();
                cmd = new SqlCommand("select firstName from Employee where usertype IN('Technician','Help Desk')", con);
                read = cmd.ExecuteReader();
                while (read.Read())
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

        private void listBox_newRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_newRequests.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref label_TechName, ref textBox_StatusUpdates);
        }

        private void listBox_requestOnHold_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_requestOnHold.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref label_TechName, ref textBox_StatusUpdates);
        }

        private void listBox_refundRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_refundRequest.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref label_TechName, ref textBox_StatusUpdates);
        }
        private void listBox_waitingToBeAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_waitingToBeAssigned.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref label_TechName, ref textBox_StatusUpdates);
        }

        private void listBox_requestsAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.autofill(listBox_requestsAssigned.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref label_TechName, ref textBox_StatusUpdates);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open) con.Close();
            listBox_newRequests.Items.Clear();
            listBox_refundRequest.Items.Clear();
            listBox_requestOnHold.Items.Clear();
            listBox_waitingToBeAssigned.Items.Clear();
            listBox_requestsAssigned.Items.Clear();

            grab.fill_listbox(ref listBox_newRequests, ref listBox_requestOnHold, ref listBox_refundRequest, ref listBox_waitingToBeAssigned, ref listBox_requestsAssigned);
            if (textBox_rmaNo.Text != "")
            {
                textBox_rmaNo.Clear();
                comboBox_updateStatus.SelectedIndex = comboBox_TechName.SelectedIndex = comboBox_cat.SelectedIndex = comboBox_type.SelectedIndex = -1;
                textBox_StatusUpdates.Clear();
                label_currentStatus.Text = "";
                label_TechName.Text = "";
            }
        }
               
    //Manage Staff Section
    private void AddNewEmpButton_Click(object sender, EventArgs e)
        {
            Add_emp add_emp = new Add_emp();
            add_emp.ShowDialog();
        }

        private void ViewAllbutton_Click(object sender, EventArgs e)
        {
            EmpInfo info = new EmpInfo();
            info.ShowDialog();
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
        private void textBox_EmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                con.Open();
                textBox_EmpID.Text = grab.getEmployeeID(textBox_EmpName.Text);
                con.Close();
            }
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
                        search.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("No Employee Record found!", "Not Found!!");                      
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Employee ID or Name.");
                }
                textBox_EmpID.Clear();
                textBox_EmpName.Clear();
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
        private void button_checkTechs_Click(object sender, EventArgs e)
        {

        }

        //Track & Update Section                 
        private void SplitRMAButton_Click(object sender, EventArgs e)
        {

            split.rma_no = textBox_rmaNo.Text;
            if (textBox_rmaNo.Text != "")
            {
                split.ShowDialog();
            }
            else
                MessageBox.Show("Enter RMA No.");
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            techopen = new Tech_Open(label_helloEmp.Text);
            if (textBox_rmaNo.Text != "")
            {
                techopen.rma_no = textBox_rmaNo.Text;
                techopen.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter RMA#.", "Empty Field");
            }

        }

        private void ConfirmTechChangeButton_Click(object sender, EventArgs e)
        {
            string id = null;
            if (con.State == ConnectionState.Open) con.Close();
          
            id = grab.getEmployeeID(comboBox_TechName.Text);
            grab.changeTech(id, textBox_rmaNo.Text);
            
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            
           // string rmaNum = textBox_rmaNo.Text.ToString();

            if (textBox_rmaNo.Text.ToString() != "")
            {
                grab.updateDB(textBox_rmaNo.Text, ref comboBox_type,ref comboBox_cat, ref comboBox_updateStatus);
                
            }
            else
                MessageBox.Show("Please enter the RMA#!", "Empty Field");
            refreshButton_Click(this, null);
        }

        private void textBox_rmaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    con.Close();

                    if (result.Equals("1"))
                    {
                        grab.autofill(textBox_rmaNo.Text, ref textBox_rmaNo, ref label_currentStatus, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref label_TechName, ref textBox_StatusUpdates);
                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#", "Not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //View Details
        private void ViewAllWOButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                grab.fill_grid();
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
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#", "Not Found");

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
            Console.WriteLine("generateReportButton_Click comboBox_clientName: " + comboBox_clientName.Text.ToString() + " ~~ comboBox_status: " + comboBox_status.Text.ToString() + " Date1: " + dateTimePicker1.Text.ToString() + " Date2: " + dateTimePicker2.Text.ToString() + " reportParam: " + reportParam);
            grab.createReport(ref comboBox_clientName, ref comboBox_status, ref dateTimePicker1, ref dateTimePicker2, ref reportParam);
            comboBox_clientName.SelectedIndex = -1;
            comboBox_status.SelectedIndex = -1;
            dateTimePicker1.Checked = false;
            dateTimePicker2.Checked = false;
        }
       
        private void RMASearchButton_Click(object sender, EventArgs e)
        {           
            grab.fill_grid();
        }               
                          
        private void textBox_rmaNo_TextChanged(object sender, EventArgs e)
        {
            rmaNumber = textBox_rmaNo.Text;
        }   

        private void textBox_StatusUpdates_TextChanged(object sender, EventArgs e)
        {
            enteredTxt = textBox_StatusUpdates.Text;        
        }

        private void ViewHistoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_View_RmaNo.Text == "")
                    MessageBox.Show("Please enter RMA#", "Empty Field!!");
                else
                {
                    result = grab.serachRMA(textBox_View_RmaNo.Text);
                    if (result.Equals("1"))
                    {
                        histry.rma.rma_no = textBox_View_RmaNo.Text;
                        histry.ShowDialog();
                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found.Please enter a valid RMA#", "Invalid Entry!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        private void radioButton_date_CheckedChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
            reportParam = "date";
        }

        private void radioButton_clientName_CheckedChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
            reportParam = "client";
        }

        private void radioButton_status_CheckedChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
            reportParam = "status";
        }

        private void comboBox_clientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }      

        private void comboBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }     

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }

        private void textBox_StatusUpdates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_StatusUpdates.Clear();
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
    }
}

