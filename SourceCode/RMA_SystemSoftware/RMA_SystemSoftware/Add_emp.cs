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
        Supervisor sup = new Supervisor();

        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        public Add_emp()
        {
            InitializeComponent();
           
        }
        
        private void Add_emp_Load(object sender, EventArgs e)
        {
            command.Connection = con;
            generateAutoID();
            buttonNewEmp.Enabled = false;
        }  

        public void generateAutoID()
        {
            try
            {
                string empId = generateEmployeeID();
                label_UserID.Text = empId;                                       
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public String generateEmployeeID()
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();
            command.Connection = con;
            command.CommandText = "Select NEXT VALUE for dbo.ID ";
            int uniqueNumber= -1;
         
            uniqueNumber = Convert.ToInt32( command.ExecuteScalar());
            
            con.Close();
            return "RMA" + uniqueNumber;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            
                this.Close();
               // sup.Show();
        
            
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox_passwrd.Text != ""&& comboBox_userType.SelectedIndex!= -1 && textBox_fName.Text !=""&& comboBox_userTag.SelectedIndex!=-1)
                {
                    con.Open();
                    command.CommandText = "Insert into Employee(UserID,password,userType,userTag,firstName,lastName,email,Ext,Fax) values ('" + label_UserID.Text + "','" + textBox_passwrd.Text + "','" + comboBox_userType.Text + "','" + comboBox_userTag.Text + "','" + textBox_fName.Text + "','" + textBox_lName.Text + "','" + textBox_email.Text + "','" + textBox_ext.Text + "','" + textBox_fax.Text + "')";
                    command.ExecuteNonQuery();
                    con.Close();
                    System.Windows.Forms.MessageBox.Show(" New Employee added to Records!!");

                    buttonNewEmp.Enabled = true;

                    label_UserID.Text = "";
                    textBox_passwrd.Clear();
                    comboBox_userType.SelectedIndex = -1;
                    comboBox_userTag.SelectedIndex = -1;
                    textBox_fName.Clear();
                    textBox_lName.Clear();
                    textBox_email.Clear();
                    textBox_ext.Clear();
                    textBox_fax.Clear();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Fill in the Mandatory Fields", "Error");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }


        }
        private void buttonNewEmp_Click(object sender, EventArgs e)
        {
            generateAutoID();
        }

        //Validations
        private void textBox_passwrd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_passwrd.Text))
            { /*e.Cancel = true;*/ errorProvider1.SetError(textBox_passwrd, "*Mandatory Field"); }
            else { /*e.Cancel = false; */errorProvider1.SetError(textBox_passwrd, ""); }
        }
        private void comboBox_userType_Validating(object sender, CancelEventArgs e)
        {
            int flag = comboBox_userType.SelectedIndex;
            if (flag == -1)
            { /*e.Cancel = true;*/ errorProvider1.SetError(comboBox_userType, "*Mandatory Field"); }
            else {/* e.Cancel = false;*/errorProvider1.SetError(comboBox_userType, ""); }
        }
        private void textBox_fName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_fName.Text))
            { /*e.Cancel = true; */errorProvider1.SetError(textBox_fName, "*Mandatory Field"); }
            else { /*e.Cancel = false;*/ errorProvider1.SetError(textBox_fName, ""); }
        }
        private void comboBox_userTag_Validating(object sender, CancelEventArgs e)
        {
            int flag = comboBox_userTag.SelectedIndex;
            if(flag==-1)
            {
                errorProvider1.SetError(comboBox_userTag, "*Mandatory Field");
            }
            else
            {
                errorProvider1.SetError(comboBox_userTag, "");
            }

        }

        //character validation 
        private void textBox_fName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox_lName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox_email_Validating(object sender, CancelEventArgs e)
        {
            if (!(textBox_email.Text.Contains("@cnbcomputers.com")))
                errorProvider1.SetError(textBox_email, "* Invalid Format");
            else
                errorProvider1.SetError(textBox_email, "");
        }

        private void textBox_ext_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void textBox_fax_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '-' || e.KeyChar == '(' || e.KeyChar == ')' ? false : true;
        }
    }
}
