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
            notes.History(this.rma, ref textBox_Notes, ref lbl_rmaNum, ref lbl_status, ref lbl_type, ref lbl_invoice, ref lbl_order, ref lbl_serial);
        }
    }
}
