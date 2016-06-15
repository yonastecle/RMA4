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
            con.Open();
            command.Connection = con;
            command.CommandText = "Insert into Employee(UserID,password,userType,userTag,firstName,lastName,email,Ext,Fax) values ('"+textBox7.Text+"','"+textBox1.Text+"','"+ comboBox1.Text+"','"+ comboBox2.Text +"','"+textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text+"')";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" New Employee added to Records!!");
        }
    }
}
