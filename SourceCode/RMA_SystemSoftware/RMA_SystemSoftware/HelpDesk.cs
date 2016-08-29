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
    public partial class HelpDesk : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;        
        SqlDataReader reader;
        Tech_Open techopen;
        GrabData grab = new GrabData();
        Notes notes = new Notes();
        History histry = new History();
        WO_Details details = new WO_Details();
        Split_RMA split = new Split_RMA();            
        Supervisor sup = new Supervisor();

        string enteredtxt="",desp="",res="",stat="", reportParam = "", found = null;        
        public string u_id { get; set; }

        public HelpDesk()
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
        }

        private void HelpDesk_Load(object sender, EventArgs e)
        {
            try
            {              
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                label_helloEmp.Text = grab.getEmployeeName(u_id);
                con.Close();

                con.Open();
                cmd = new SqlCommand("Select Company from Client ", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox_clientName.Items.Add(reader["Company"]);
                }
                reader.Close();

                cmd = new SqlCommand("select firstName from Employee where usertype IN('Technician','Help Desk')", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox_TechName.Items.Add(reader["firstName"]);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
     
        private void textBox_rmaNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox_statusUpdates.Clear();
                textBox_descrption.Clear();
                textBox_resolution.Clear();               
                grab.autofill(ref textBox_rmaNo,ref label_rmaNo,ref label_type, ref label_currentStatus, ref label_techName, ref comboBox_TechName, ref comboBox_updateStatus, ref comboBox_type, ref comboBox_cat, ref textBox_descrption, ref textBox_resolution, ref textBox_statusUpdates);
            }
               
         }
          
        private void ConfirmTechChangeButton_Click(object sender, EventArgs e)
        {
            string id = null;
            if (con.State == ConnectionState.Open) con.Close();
           
            id = grab.getEmployeeID(comboBox_TechName.Text);
            grab.changeTech(id, label_rmaNo.Text);
           
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            //string rmaNum = label_rmaNo.Text.ToString();
           
                grab.updateDB(label_rmaNo.Text, ref comboBox_type, ref comboBox_cat, ref comboBox_updateStatus);            
        }       

        private void openRecordButton_Click(object sender, EventArgs e)
        {
           techopen = new Tech_Open(label_helloEmp.Text);
            techopen.rma_no = label_rmaNo.Text;
            if (label_rmaNo.Text != "")
            {
                techopen.Show();

            }

            else MessageBox.Show("Please Enter RMA#", "Empty Field");
        }        

        private void SearchButton_Click(object sender, EventArgs e)
        {
            grab.fill_grid();
        }
        private void SplitRMAButton_Click(object sender, EventArgs e)
        {
            split.rma_no = label_rmaNo.Text;
            if (label_rmaNo.Text != "")
            {
                split.Show();
            }
            else
                MessageBox.Show("Enter RMA No.", " Empty Field");
        }
        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox_update_statusUpdate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_update_statusUpdate.Clear();
        }

        private void textBox_update_statusUpdate_TextChanged(object sender, EventArgs e)
        {
            enteredtxt = textBox_update_statusUpdate.Text;
        }               

        private void textBox_descrption_TextChanged(object sender, EventArgs e)
        {
            desp = textBox_descrption.Text;
        }
        private void textBox_resolution_TextChanged(object sender, EventArgs e)
        {
            res = textBox_resolution.Text;
        }

        private void ViewHistoryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_rmaNo.Text == "")
                    MessageBox.Show("Please enter RMA#", "Empty Field!!");
                else
                {
                    found = grab.serachRMA(textBox_rmaNo.Text);
                    if (found.Equals("1"))
                    {
                        histry.rma.rma_no = textBox_rmaNo.Text;
                        histry.ShowDialog();
                    }
                    else if (found.Equals("0"))
                        MessageBox.Show("RMA not found.Please enter a valid RMA#", "Invalid Entry!!");
                }

            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            grab.createReport(ref comboBox_clientName, ref comboBox_status, ref dateTimePicker1, ref dateTimePicker2, ref reportParam);
            comboBox_clientName.SelectedIndex = -1;
            comboBox_status.SelectedIndex = -1;
            dateTimePicker1.Checked = false;
            dateTimePicker2.Checked = false;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }

        private void comboBox_clientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }

        private void comboBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            grab.HideComboBoxes(ref radioButton_date, ref radioButton_clientName, ref radioButton_status, ref dateTimePicker1, ref dateTimePicker2, ref comboBox_clientName, ref comboBox_status, ref generateReportButton);
        }
          

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

      

        private void textBox_statusUpdates_TextChanged(object sender, EventArgs e)
        {
            stat = textBox_statusUpdates.Text;
        }        

        private void textBox_descrption_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_descrption.Clear();
        }
        private void textBox_resolution_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_resolution.Clear();
        }

        private void textBox_statusUpdates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_statusUpdates.Clear();
        }
        private void linkLabel_logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void linkLabel_help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

    }
}
