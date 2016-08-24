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
    public partial class History : Form
    {
        public RMA rma = new RMA();
        Notes notes = new Notes();    
     
        public History()
        {
            InitializeComponent();                        
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void History_Load(object sender, EventArgs e)
        {
            richTextBox_Notes.Clear();
            lbl_invoice.Text = "";
            lbl_order.Text = "";
            lbl_rmaNum.Text = "";
            lbl_serial.Text = "";
            lbl_status.Text = "";
            lbl_type.Text = "";
            notes.History(this.rma, ref richTextBox_Notes, ref lbl_rmaNum, ref lbl_status, ref lbl_type,ref label_tech, ref lbl_invoice, ref lbl_order, ref lbl_serial);
        }

        
    }
}
