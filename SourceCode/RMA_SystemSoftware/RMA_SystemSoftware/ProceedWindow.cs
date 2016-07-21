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
    public partial class ProceedWindow : Form
    {
        delegateMessageBox mesg_box = new delegateMessageBox();
        public string rma_no { get; set; }

        public ProceedWindow()
        {
            InitializeComponent();
        }

        private void ProceedWindow_Load(object sender, EventArgs e)
        {

        }

        private void delegateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mesg_box.RMA = rma_no;
            mesg_box.Show();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RMA request added to your WO Queue", "WO Updated!");
            this.Close();
        }
    }
}
