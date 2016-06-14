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
    public partial class Add_emp : Form
    {
        public Add_emp()
        {
            InitializeComponent();
            /*ComboBox type = new ComboBox();
            ComboBox tag = new ComboBox();
            type.Items.Add("Supervisor");
            type.Items.Add("Help Desk");
            type.Items.Add("Receiving");
            type.Items.Add("Technician");

            tag.Items.Add("NA");
            tag.Items.Add("Laptop");
            tag.Items.Add("Desktop");
            tag.Items.Add("Laptop & Desktop");*/
        }

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
    }
}
