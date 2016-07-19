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
        Split_RMA split = new Split_RMA();
        Tech_Open open = new Tech_Open();
        string s, ID, req_type;
        int cat;
        public string u_id;
        public string passid
        {
            get { return u_id; }
            set { u_id = value; }
        }


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

      
        //Split RMA button
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
        
        //Logout
        private void LogoutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();

        }
        //Help
        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }
        
        //Add new emp Button
        private void AddNewEmpButton_Click(object sender, EventArgs e)
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

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) con.Close();
            listBox_newRequests.Items.Clear();
            listBox_refundRequest.Items.Clear();
            listBox_requestOnHold.Items.Clear();
            fill_listbox();
            if (textBox_rmaNo.Text != "") showUpdatedDetails();
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
                cmd = new SqlCommand("select FirstName from Employee where UserID='" + u_id + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                label_helloEmp.Text = read.GetString(read.GetOrdinal("firstName"));
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

        public void fill_grid()
        {

            da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,category as 'CAT',ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA", con);
            ds = new DataSet();
            da.Fill(ds, "All WO Details");
            details.dataGridView_WODetails.DataSource = ds.Tables[0];
            this.Close();
            details.Show();
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

        private void RMASerachButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            fill_grid();
          
        }

        private void listBox_newRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioB_refund.Checked = false;
            radioB_repair.Checked = false;
            radioB_replace.Checked = false;
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no ='" + listBox_newRequests.Text + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox_rmaNo.Text = read.GetString(read.GetOrdinal("rma_no"));
                    label_currentStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    comboBox_updateStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    ID = read.GetString(read.GetOrdinal("userID"));
                    req_type = read.GetString(read.GetOrdinal("type"));
                    cat = read.GetInt16(read.GetOrdinal("category")); 
                  
                }
                con.Close();
                if (req_type.ToLower().Contains("replace"))
                {
                    radioB_replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                    radioB_refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    radioB_repair.Checked = true;
                }
                if (cat==1)
                {
                    radioButton_CAT1.Checked = true;
                }
                else if (cat==2)
                {
                    radioButton_CAT2.Checked = true;
                }
                else if (cat==3)
                {
                    radioButton_CAT3.Checked = true;
                }
                else if(cat==4)
                {
                    radioButton_CAT4.Checked = true;
                }
                else
                {

                    radioButton_CAT1.Checked = false;
                    radioButton_CAT2.Checked = false;
                    radioButton_CAT3.Checked = false;
                    radioButton_CAT4.Checked = false;
                }
                con.Open();
                cmd = new SqlCommand("select firstName from Employee where UserID='" + ID + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                label_TechName.Text = read.GetString(read.GetOrdinal("firstName"));
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            open.Show();
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

        private void ConfirmTechChangeButton_Click(object sender, EventArgs e)
        {
            string id = null;
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            cmd = new SqlCommand("Select UserID ID from Employee where firstName='" + comboBox_TechName.Text + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
                id = read["ID"].ToString();
            con.Close();

            con.Open();
            cmd = new SqlCommand("update RMA set userID='" + id + "' where rma_no='" + textBox_rmaNo.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Technician Re-Assigned!");
            con.Close();
         }

        private void listBox_requestOnHold_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioB_refund.Checked = false;
            radioB_repair.Checked = false;
            radioB_replace.Checked = false;
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no ='" + listBox_requestOnHold.Text + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox_rmaNo.Text = read.GetString(read.GetOrdinal("rma_no"));
                    label_currentStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    comboBox_updateStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    ID = read.GetString(read.GetOrdinal("userID"));
                    req_type = read.GetString(read.GetOrdinal("type"));
                    cat = read.GetInt16(read.GetOrdinal("category"));

                }
                con.Close();
                if (req_type.ToLower().Contains("replace"))
                {
                    radioB_replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                    radioB_refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    radioB_repair.Checked = true;
                }
                if (cat == 1)
                {
                    radioButton_CAT1.Checked = true;
                }
                else if (cat == 2)
                {
                    radioButton_CAT2.Checked = true;
                }
                else if (cat == 3)
                {
                    radioButton_CAT3.Checked = true;
                }
                else if (cat == 4)
                {
                    radioButton_CAT4.Checked = true;
                }
                else
                {

                    radioButton_CAT1.Checked = false;
                    radioButton_CAT2.Checked = false;
                    radioButton_CAT3.Checked = false;
                    radioButton_CAT4.Checked = false;
                }
                con.Open();
                cmd = new SqlCommand("select firstName from Employee where UserID='" + ID + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                    label_TechName.Text = read.GetString(read.GetOrdinal("firstName"));
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
        //Enable/Disable the View History Button: How???
        //private void textBox_View_RmaNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string stat = null;
        //    try
        //    {
        //        if (con.State == ConnectionState.Open) con.Close();
        //        con.Open();
        //        cmd = new SqlCommand("select Status stat from RMA where rma_no='" + textBox_View_RmaNo.Text + "'", con);
        //        read = cmd.ExecuteReader();
        //        while (read.Read())
        //            stat = read.GetString(read.GetOrdinal("Status"));
        //        con.Close();

        //        if (stat.Equals("Close"))
        //            ViewHistoryButton.Enabled = true;
        //        else
        //            ViewHistoryButton.Enabled = false;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void updateButton_Click(object sender, EventArgs e)
        {
            string found = null;
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
              
                if (textBox_rmaNo.Text != "")
                {
                    if ((radioB_replace.Checked == true || radioB_repair.Checked == true || radioB_refund.Checked == true) && (radioButton_CAT1.Checked == true || radioButton_CAT2.Checked == true || radioButton_CAT3.Checked == true || radioButton_CAT4.Checked == true))
                    {
                        con.Open();
                        cmd = new SqlCommand("UPDATE RMA SET Status ='" + comboBox_updateStatus.Text + "', type ='" + req_type + "', category='" + cat + "'WHERE rma_no='" + textBox_rmaNo.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        //Adding RMA to Notes Table, if RMA not found in the Notes Table.(Additionally need to work on adding RMA# to the Notes table as and when a new RMA request comes into the DB)
                        cmd = new SqlCommand("Select count(RMA_no)found from Notes where RMA_no='" + textBox_rmaNo.Text + "'", con);
                        read = cmd.ExecuteReader();
                        while (read.Read())
                        found = String.Format("{0}", read["found"]);
                        con.Close();
                        con.Open();
                        if (found.Equals("0"))
                        {
                          // adding dummy value to Description. LINK IT TO THE CSM DB to fetch the description.
                           cmd = new SqlCommand("INSERT INTO Notes (RMA_no, description,statusUpdates) Values ('"+textBox_rmaNo.Text+"','Dummy','"+textBox_StatusUpdates.Text+"')", con);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            cmd = new SqlCommand("UPDATE  Notes  SET Notes.statusUpdates = '" + textBox_StatusUpdates.Text + "'FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no = '" + textBox_rmaNo.Text + "'", con);
                            cmd.ExecuteNonQuery();
                        }

                        con.Close();
                        MessageBox.Show("Changes Saved..Press Refresh! ");
                    }

                    else
                        MessageBox.Show("Please choose Type of request/Category!");
                }
                else
                    MessageBox.Show("Please enter the RMA#!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox_refundRequest_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no ='" + listBox_refundRequest.Text + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    textBox_rmaNo.Text = read.GetString(read.GetOrdinal("rma_no"));
                    label_currentStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    comboBox_updateStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    ID = read.GetString(read.GetOrdinal("userID"));

                    req_type = read.GetString(read.GetOrdinal("type"));
                    cat = read.GetInt16(read.GetOrdinal("category"));

                }
                con.Close();
                if (req_type.ToLower().Contains("replace"))
                {
                    radioB_replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                    radioB_refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    radioB_repair.Checked = true;
                }
                if (cat == 1)
                {
                    radioButton_CAT1.Checked = true;
                }
                else if (cat == 2)
                {
                    radioButton_CAT2.Checked = true;
                }
                else if (cat == 3)
                {
                    radioButton_CAT3.Checked = true;
                }
                else if (cat == 4)
                {
                    radioButton_CAT4.Checked = true;
                }
                else
                {

                    radioButton_CAT1.Checked = false;
                    radioButton_CAT2.Checked = false;
                    radioButton_CAT3.Checked = false;
                    radioButton_CAT4.Checked = false;
                }

                con.Open();
                cmd = new SqlCommand("select firstName from Employee where UserID='" + ID + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                    label_TechName.Text = read.GetString(read.GetOrdinal("firstName"));
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void showUpdatedDetails()
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            cmd = new SqlCommand("Select * from RMA where rma_no='" + textBox_rmaNo.Text + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                textBox_rmaNo.Text = read.GetString(read.GetOrdinal("rma_no"));
                label_currentStatus.Text = read.GetString(read.GetOrdinal("Status"));
                comboBox_updateStatus.Text = read.GetString(read.GetOrdinal("Status"));
                ID = read.GetString(read.GetOrdinal("userID"));
                req_type = read.GetString(read.GetOrdinal("type"));
                cat = read.GetInt16(read.GetOrdinal("category"));

            }
            con.Close();
            if (req_type.ToLower().Contains("replace"))
            {
                radioB_replace.Checked = true;
            }
            else if (req_type.ToLower().Contains("refund"))
            {
                radioB_refund.Checked = true;
            }
            else if (req_type.ToLower().Contains("repair"))
            {
                radioB_repair.Checked = true;
            }
            if (cat == 1)
            {
                radioButton_CAT1.Checked = true;
            }
            else if (cat == 2)
            {
                radioButton_CAT2.Checked = true;
            }
            else if (cat == 3)
            {
                radioButton_CAT3.Checked = true;
            }
            else if (cat == 4)
            {
                radioButton_CAT4.Checked = true;
            }
            else
            {

                radioButton_CAT1.Checked = false;
                radioButton_CAT2.Checked = false;
                radioButton_CAT3.Checked = false;
                radioButton_CAT4.Checked = false;
            }
      
            con.Open();
            cmd = new SqlCommand("select firstName from Employee where UserID='" + ID + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
                label_TechName.Text = read.GetString(read.GetOrdinal("firstName"));
            comboBox_TechName.SelectedIndex = -1;
            con.Close();
        }
        
    }
}

