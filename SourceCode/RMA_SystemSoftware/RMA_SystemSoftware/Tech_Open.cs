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
        SqlConnection con = new SqlConnection(@"Data Source=SHANTANUNBK;Initial Catalog=RMA_System;Integrated Security=True");     
        GrabData grab = new GrabData();
        Notes notes = new Notes();
        string req_type, desp = "", res = "", stat = "", comm = "";
        int cat;
        public string rma_no { get; set; }
        public string u_type { get; set; }       

        public Tech_Open()
        {
            InitializeComponent();
            comboBox_status.Items.Add("Hold");
            comboBox_status.Items.Add("Complete");
            comboBox_status.Items.Add("Refund");
            comboBox_status.Items.Add("Assigned");//Disable it for Technician
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
            grab.autofill(rma_no,ref label_currentStatus, ref comboBox_status, ref req_type, ref cat, ref radioButton_repair, ref radioButton_replace, ref radioButton_refund, ref radioB_CAT1, ref radioB_CAT2, ref radioB_CAT3, ref radioB_CAT4,ref textBox_desp, ref textBox_res, ref textBox_statusUpadate, ref textBox_comments);
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            notes.updateField(label_rmaNo.Text, desp, res, stat, comm);
            grab.autofill(rma_no, ref label_currentStatus, ref comboBox_status, ref req_type, ref cat, ref radioButton_repair, ref radioButton_replace, ref radioButton_refund, ref radioB_CAT1, ref radioB_CAT2, ref radioB_CAT3, ref radioB_CAT4, ref textBox_desp, ref textBox_res, ref textBox_statusUpadate, ref textBox_comments);
            
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

        private void textBox_comments_TextChanged(object sender, EventArgs e)
        {
            comm = textBox_comments.Text;
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

        private void textBox_comments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox_comments.Clear();
        }
        private void radioB_CAT1_CheckedChanged(object sender, EventArgs e)
        {
            cat = 1;
        }

        private void radioB_CAT2_CheckedChanged(object sender, EventArgs e)
        {
            cat = 2;
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            grab.updateDB(rma_no, ref comboBox_status, ref req_type, ref cat);
        }

        private void radioB_CAT3_CheckedChanged(object sender, EventArgs e)
        {
            cat = 3;
        }

        private void radioB_CAT4_CheckedChanged(object sender, EventArgs e)
        {
            cat = 4;
        }

        private void radioButton_repair_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Repair";
        }

        private void radioButton_replace_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Replace";
        }

        private void radioButton_refund_CheckedChanged(object sender, EventArgs e)
        {
            req_type = "Refund";
        }
    }
}
