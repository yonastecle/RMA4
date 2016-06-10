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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="R" || textBox1.Text == "r")
                {
                this.Hide();
                Receiving Recv = new Receiving();
                Recv.Show();

            }
            else if(textBox1.Text=="T" || textBox1.Text=="t")
            {
                this.Hide();
                Technician Tech = new Technician();
                Tech.Show();
            }
            else if(textBox1.Text == "H" || textBox1.Text == "h")
            {
                this.Hide();
                HelpDesk hdesk = new HelpDesk();
                hdesk.Show();
            }
            else
            {
                this.Hide();
                Supervisor sup = new Supervisor();
                sup.Show();
            }
        }
    }
}
