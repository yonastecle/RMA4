using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMA_SystemSoftware
{
    public partial class Supervisor : Form
    {
        public Supervisor()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Hide();
            Split_RMA split = new Split_RMA();
            split.Show();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
            Add_emp add_emp = new Add_emp();
            add_emp.Show();
        }
    }
}
