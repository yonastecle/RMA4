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
    public partial class Receiving : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter da;
        DataSet ds;
        RMA rma = new RMA();
        History histry = new History();
        GrabData grab = new GrabData();
        WO_Details details = new WO_Details();
        Split_RMA split = new Split_RMA();
        Supervisor sup = new Supervisor();           
        public string u_id { get; set; }
        string result = null;

        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
            button_refresh_Click(this, null);
        }

        public Receiving()
        {       
            InitializeComponent();
            comboBox_Status.Items.Add("Received");
            comboBox_Status.Items.Add("Wait");
            comboBox_Status.Items.Add("Waiting to be assigned");
            //comboBox_Status.Items.Add("Close");
            comboBox_Status.Items.Add("Refund");      // should we tag 'Refund' as status ?   
            comboBox_Status.Items.Add("Open");//to be removed, Receiving Staff can't change the status to Open
            timer_AutoRefresh.Start();
        }
        
        private void Receiving_Load(object sender, EventArgs e)
        {           
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                label_helloEmp.Text = grab.getEmployeeName(u_id);                
                con.Close();
                fill_listbox();             
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message);
            }            
        }
        
        public void button_refresh_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) con.Close();
            listBox_Open.Items.Clear();
            listBox_Received.Items.Clear();
            listBox_Wait.Items.Clear();
            textBox_rmaNo.Clear();
            textBox_reason.Clear();
            textbox_desp.Clear();
            label_customerName.Text = " Customer Name";
            label_currentStatus.Text = "Request Status";
            label_requestType.Text = " Request Type";
            comboBox_Status.SelectedIndex = -1;
            Receiving_Load(this, null);
            fill_grid(); 
        }
  
        public void fill_listbox()
        {
            string rma_no;
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Open'", con);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                   rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_Open.Items.Add(rma_no);
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Received'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_Received.Items.Add(rma_no);
                }
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select rma_no from RMA where Status= 'Wait'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rma_no = reader.GetString(reader.GetOrdinal("rma_no"));
                    listBox_Wait.Items.Add(rma_no);
                }
                con.Close();

            }
            catch(Exception ex)
            {
             MessageBox.Show(ex.Message);
            }
        }
       
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"G:\RMA Software_project\Test_user guide.pdf");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void listBox_Open_SelectedIndexChanged(object sender, EventArgs e)
        {
           grab.autofill(listBox_Open.Text,ref textBox_rmaNo, ref  label_customerName,ref label_currentStatus,ref comboBox_Status, ref label_quantity, ref label_requestType, ref dataGridView1);
        }

        private void listBox_Received_SelectedIndexChanged(object sender, EventArgs e)
        {
           grab.autofill(listBox_Received.Text, ref textBox_rmaNo, ref label_customerName, ref label_currentStatus, ref comboBox_Status, ref label_quantity, ref label_requestType, ref dataGridView1);
            
        }
        private void listBox_Wait_SelectedIndexChanged(object sender, EventArgs e)
        {
           grab.autofill(listBox_Wait.Text, ref textBox_rmaNo, ref label_customerName, ref label_currentStatus, ref comboBox_Status, ref label_quantity, ref label_requestType, ref dataGridView1);
            
        }                    
        private void button_Update_Click(object sender, EventArgs e)
        {
            string rmaNum = textBox_rmaNo.Text;
           
                grab.updateDB(rmaNum, ref comboBox_Status);                
                button_refresh_Click(this, null);           
        }

        public void fill_grid()
        {
            da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA", con);
            ds = new DataSet();
            da.Fill(ds, "RMA");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void ViewAllButton_Click(object sender, EventArgs e)
        {
            try
            {                
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    con.Open();
                    fill_grid();
                    con.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_rmaNo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            label_customerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            label_quantity.Text = "X " + dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            label_currentStatus.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox_Status.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            label_requestType.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();                       
        }

        private void textBox_rmaNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (con.State == ConnectionState.Open) con.Close();
                    con.Open();
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    con.Close();
                    if (result.Equals("1"))
                    {
                        grab.autofill(textBox_rmaNo.Text, ref textBox_rmaNo, ref label_customerName, ref label_currentStatus, ref comboBox_Status, ref label_quantity, ref label_requestType, ref dataGridView1);

                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found. Please enter a valid RMA#.", "Invalid RMA#");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_viewHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_rmaNo.Text == "")
                    MessageBox.Show("Please enter RMA#", "Empty Field!!");
                else
                {
                    result = grab.serachRMA(textBox_rmaNo.Text);
                    if (result.Equals("1"))
                    {
                        histry.rma.rma_no = textBox_rmaNo.Text;
                        histry.ShowDialog();
                    }
                    else if (result.Equals("0"))
                        MessageBox.Show("RMA not found.Please enter a valid RMA#", "Invalid Entry!!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void button_splitRma_Click(object sender, EventArgs e)
        {
            if (textBox_rmaNo.Text != "")
            {
                split.ShowDialog();
            }
            else
                MessageBox.Show("Enter RMA No.");
        }
    }
}
