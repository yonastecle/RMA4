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
    public partial class Tech_Open : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        GrabData grab = new GrabData();
        Notes notes = new Notes();
        string req_type, desp = "", res = "", stat = "";
        int cat;
        public string rma_no { get; set; }
        public string u_type { get; set; }       

        public Tech_Open(string EmpName)
        {
            InitializeComponent();
            comboBox_status.Items.Add("Hold");
            comboBox_status.Items.Add("Complete");
            comboBox_status.Items.Add("Refund");
            comboBox_status.Items.Add("Assigned");//Disable it for Technician
            label_helloEmp.Text = EmpName.ToString();
            
        }
           
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();                            
        }

        private void HelpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void Tech_Open_Load(object sender, EventArgs e)
        {
            label_rmaNo.Text = rma_no;
            grab.autofill(rma_no,ref label_currentStatus, ref comboBox_status, ref req_type, ref cat,ref textBox_desp, ref textBox_res, ref textBox_statusUpadate);
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            notes.updateField(label_rmaNo.Text, desp, res, stat,label_helloEmp.Text);
            grab.autofill(rma_no, ref label_currentStatus, ref comboBox_status, ref req_type, ref cat,  ref textBox_desp, ref textBox_res, ref textBox_statusUpadate);
            
        }

        private void textBox_desp_TextChanged(object sender, EventArgs e)
        {
            desp = textBox_desp.Text;
        }

        private void textBox_res_TextChanged(object sender, EventArgs e)
        {
            res = textBox_res.Text;
        }

        private void textBox_statusUpadate_TextChanged(object sender, EventArgs e)
        {
            stat = textBox_statusUpadate.Text;
        }

        private void textBox_desp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_desp.Clear();
        }

        private void textBox_res_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_res.Clear();
        }

        private void textBox_statusUpadate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_statusUpadate.Clear();               
        }
        
        private void button_Update_Click(object sender, EventArgs e)
        {
            //update arguments
            grab.updateDB(rma_no, ref comboBox_type, ref comboBox_cat, ref comboBox_status);
       
        }             
    }
}
