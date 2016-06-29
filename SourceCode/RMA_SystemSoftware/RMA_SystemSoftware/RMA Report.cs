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
    public partial class RMA_Report : Form
    {
        public RMA_Report()
        {
            InitializeComponent();
        }

        private void RMA_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.RMA' table. You can move, or remove it, as needed.
            this.RMATableAdapter.Fill(this.DataSet1.RMA);

            this.reportViewer1.RefreshReport();
        }
    }
}
