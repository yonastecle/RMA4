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
    public partial class ReportGeneration : Form
    {
        public string client { get; set; }
        public string status { get; set; }
        public ReportGeneration()
        {
            InitializeComponent();
        }

        private void ReportGeneration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.RMA' table. You can move, or remove it, as needed.
            this.RMATableAdapter.Fill(this.DataSet1.RMA,client);

            this.reportViewer1.RefreshReport();
        }
    }
}
