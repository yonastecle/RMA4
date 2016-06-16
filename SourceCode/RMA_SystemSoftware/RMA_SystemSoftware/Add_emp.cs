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
    public partial class Add_emp : Form
    {
        public Add_emp()
        {
            InitializeComponent();
           
        }
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        SqlDataReader dataRead;
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Supervisor sup = new Supervisor();
            sup.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                con.Open();
                command.CommandText = "Insert into Employee(UserID,password,userType,userTag,firstName,lastName,email,Ext,Fax) values ('" + textBox7.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox_Fax.Text + "')";
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" New Employee added to Records!!");
                textBox7.Clear();
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox_Fax.Clear();
            }
           
          }

        private void Add_emp_Load(object sender, EventArgs e)
        {
            command.Connection = con;
        }
        //UserID
        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBox7.Text))
            { e.Cancel = true; errorProvider1.SetError(textBox7, "*Mandatory Field"); }
            else { e.Cancel = false;  errorProvider1.SetError(textBox7, ""); }
        }
        //Password
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            { e.Cancel = true; errorProvider1.SetError(textBox1, "*Mandatory Field"); }
            else { e.Cancel = false; errorProvider1.SetError(textBox1, ""); }
        }
        //User Type
        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            int flag = comboBox1.SelectedIndex;
            if (flag == -1)
            { e.Cancel = true; errorProvider1.SetError(comboBox1, "*Mandatory Field"); }
            else { e.Cancel = false;errorProvider1.SetError(comboBox1,"");}
        }
        //First Name
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            { e.Cancel = true; errorProvider1.SetError(textBox2, "*Mandatory Field"); }
            else { e.Cancel = false; errorProvider1.SetError(textBox2, ""); }
        }
        //Number validation for Extension
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }
        //character validation for firstname and last name
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }
    }
}
