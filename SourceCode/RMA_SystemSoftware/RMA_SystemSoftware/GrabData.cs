using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMA_SystemSoftware
{
    class GrabData
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        SqlDataAdapter da;
        DataSet ds;
        WO_Details details = new WO_Details();

        public string getEmployeeName(string id)
        {
            string empName = null;
            con.Open();
            cmd = new SqlCommand("select firstName from Employee where UserID='" + id + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
                empName = read.GetString(read.GetOrdinal("firstName"));
            con.Close();
            return empName;
        }

        public string getEmployeeID(string name)
        {
            string empID = null;
            con.Open();
            cmd = new SqlCommand("Select UserID ID from Employee where firstName='" + name + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
                empID = read["ID"].ToString();
            con.Close();

            return empID;
        }

        public string serachRMA(string rmaNum)
        {
            string result = null;
            con.Open();
            cmd = new SqlCommand("select count(rma_no) found from RMA where rma_no='" + rmaNum + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                result = String.Format("{0}", read["found"]);
            }
            con.Close();
            return result;
        }
        //Receiving: Update and Verify Button
        public void updateDB(string rmaNum, string stat, ref ComboBox cmbBox, ref string req_type)
        {


            try
            {
                con.Open();
                if (stat.Contains("verify"))
                {
                    cmd = new SqlCommand("update RMA set Status = 'Waiting to be assigned' where rma_no='" + rmaNum + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Request Added to Queue for Technician Assignment!! Press Refresh. ", "Received");
                }
                else
                {
                    cmd = new SqlCommand("update RMA set Status ='" + cmbBox.Text + "',type ='" + req_type + "'where rma_no='" + rmaNum + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Changes Saved..Press Refresh! ");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Supervisor+HelpDesk Update
        public void updateDB(string rmaNum, ref ComboBox cmbBox, ref string req_type, ref int cat)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE RMA SET Status ='" + cmbBox.Text + "', type ='" + req_type + "', category='" + cat + "'WHERE rma_no='" + rmaNum + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }

        //Receiving+Technician:Autofilling the fields on selection of RMA# from the listbox or keypress
        public string autofill(string rmaNum, ref TextBox txtbox, ref Label lbl, ref ComboBox cmbBox, ref RadioButton repair, ref RadioButton replace, ref RadioButton refund)
        {
            string type = "";
            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    txtbox.Text = read.GetString(read.GetOrdinal("rma_no"));
                    lbl.Text = read.GetString(read.GetOrdinal("Status"));
                    cmbBox.Text = read.GetString(read.GetOrdinal("Status"));
                    type = read.GetString(read.GetOrdinal("type"));
                }
                con.Close();

                if (type.ToLower().Contains("replace"))
                {
                    replace.Checked = true;
                }
                else if (type.ToLower().Contains("refund"))
                {
                    refund.Checked = true;
                }
                else if (type.ToLower().Contains("repair"))
                {
                    repair.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return type;
        }
        //Supervisor+Helpdesk:Autofilling the fields on selection of RMA# from the listbox or Keypress
        public void autofill(string rmaNum, ref TextBox txtboxRmaNum, ref Label lblStatus, ref ComboBox cmbBox, ref string req_type, ref int cat, ref RadioButton repair, ref RadioButton replace, ref RadioButton refund, ref RadioButton cat1, ref RadioButton cat2, ref RadioButton cat3, ref RadioButton cat4, ref Label lblTech, ref TextBox txtboxStatUpdate)
        {
            string ID = "";
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no ='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    txtboxRmaNum.Text = read.GetString(read.GetOrdinal("rma_no"));
                    lblStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    cmbBox.Text = read.GetString(read.GetOrdinal("Status"));
                    ID = read.GetString(read.GetOrdinal("userID"));
                    req_type = read.GetString(read.GetOrdinal("type"));
                    cat = read.GetInt16(read.GetOrdinal("category"));

                }
                con.Close();
                if (req_type.ToLower().Contains("replace"))
                {
                    replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                    refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    repair.Checked = true;
                }
                if (cat == 1)
                {
                    cat1.Checked = true;
                }
                else if (cat == 2)
                {
                    cat2.Checked = true;
                }
                else if (cat == 3)
                {
                    cat3.Checked = true;
                }
                else if (cat == 4)
                {
                    cat4.Checked = true;
                }
                else
                {

                    cat1.Checked = false;
                    cat2.Checked = false;
                    cat3.Checked = false;
                    cat4.Checked = false;
                }
                lblTech.Text = getEmployeeName(ID);

                con.Open();
                cmd = new SqlCommand("select statusUpdates from Notes where RMA_no='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();
                txtboxStatUpdate.Clear();
                while (read.Read())
                {
                    txtboxStatUpdate.Text = read.GetString(read.GetOrdinal("statusUpdates"));
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //autofill techOpen
        public void autofill(string rmaNum, ref Label lblStatus, ref ComboBox cmbBox, ref string req_type, ref int cat, ref RadioButton repair, ref RadioButton replace, ref RadioButton refund, ref RadioButton cat1, ref RadioButton cat2, ref RadioButton cat3, ref RadioButton cat4, ref TextBox desp, ref TextBox res, ref TextBox stat, ref TextBox comm)
        {
            string ID = "";
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no ='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {

                    lblStatus.Text = read.GetString(read.GetOrdinal("Status"));
                    cmbBox.Text = read.GetString(read.GetOrdinal("Status"));
                    ID = read.GetString(read.GetOrdinal("userID"));
                    req_type = read.GetString(read.GetOrdinal("type"));
                    cat = read.GetInt16(read.GetOrdinal("category"));

                }
                con.Close();
                if (req_type.ToLower().Contains("replace"))
                {
                    replace.Checked = true;
                }
                else if (req_type.ToLower().Contains("refund"))
                {
                    refund.Checked = true;
                }
                else if (req_type.ToLower().Contains("repair"))
                {
                    repair.Checked = true;
                }
                if (cat == 1)
                {
                    cat1.Checked = true;
                }
                else if (cat == 2)
                {
                    cat2.Checked = true;
                }
                else if (cat == 3)
                {
                    cat3.Checked = true;
                }
                else if (cat == 4)
                {
                    cat4.Checked = true;
                }
                else
                {

                    cat1.Checked = false;
                    cat2.Checked = false;
                    cat3.Checked = false;
                    cat4.Checked = false;
                }
                con.Open();
                cmd = new SqlCommand("SELECT * FROM RMA R, Notes N WHERE R.rma_no =N.RMA_no AND r.rma_no='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    desp.Text = read.GetString(read.GetOrdinal("description"));
                    comm.Text = read.GetString(read.GetOrdinal("comments"));
                    res.Text = read.GetString(read.GetOrdinal("resolution"));
                    stat.Text = read.GetString(read.GetOrdinal("statusUpdates"));
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Report Generation
        public void createReport(ref ComboBox client, ref ComboBox status, ref DateTimePicker startDate, ref DateTimePicker endDate, ref string reportParam)
        {
            ReportGeneration report = new ReportGeneration();
            CrystalReport rep = new CrystalReport();
            DataSet1 ds = new DataSet1();
            DataSet1TableAdapters.DataTable1TableAdapter adp = new DataSet1TableAdapters.DataTable1TableAdapter();
            Console.WriteLine("Report Parameter: " + reportParam.ToString());

            try
            {
                if (reportParam.Contains("date"))
                {
                    MessageBox.Show("date");
                }
                else if (reportParam.Contains("status"))
                {
                    adp.Fill(ds.DataTable1);
                    rep.SetDataSource(ds);
                    rep.SetParameterValue("SearchParam", status.Text);
                    report.crystalReportViewer1.ReportSource = rep;
                    report.ShowDialog();

                }
                else if (reportParam.Contains("client"))
                {
                    adp.Fill(ds.DataTable1);
                    rep.SetDataSource(ds);
                    rep.SetParameterValue("SearchParam", client.Text);
                    report.crystalReportViewer1.ReportSource = rep;
                    report.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Report Section 
        public void HideComboBoxes(ref RadioButton RB_date, ref RadioButton RB_client, ref RadioButton RB_status, ref DateTimePicker date1, ref DateTimePicker date2, ref ComboBox CB_client, ref ComboBox CB_status, ref Button genReprt)
        {
            if (RB_date.Checked)
            {
                date1.Enabled = true;
                date2.Enabled = true;
            }
            else if (!RB_date.Checked)
            {
                date1.Enabled = false;
                date2.Enabled = false;
            }

            if (RB_status.Checked)
            {
                CB_status.Enabled = true;
            }
            else if (!RB_status.Checked)
            {
                CB_status.Enabled = false;
            }

            if (RB_client.Checked)
            {
                CB_client.Enabled = true;
            }
            else if (!RB_client.Checked)
            {
                CB_client.Enabled = false;
            }

            if ((CB_client.SelectedIndex != -1 && RB_client.Enabled) || (CB_status.SelectedIndex != -1 && RB_status.Checked) || (RB_date.Checked && date1.Checked) || (RB_date.Checked && date2.Checked))
            {
                genReprt.Enabled = true;
            }
            else { genReprt.Enabled = false; }
        }
        public void fill_grid()
        {

            da = new SqlDataAdapter("Select rma_no as 'RMA #',customer as 'Client Name',userID as ' Tech Assigned',invoiceNo as 'Invoice No.',Status as 'Current Status',type as' Request Type',quantity,category as 'CAT',ups as 'UPS#',mar as 'MAR',orderNo,serialNo,date_received as ' Received On',date_assigned as'Assigned On',date_hold as 'Put on Hold since',date_wait as ' Waiting since',date_completed as ' Completed On',date_closed as 'closed on' from RMA", con);
            ds = new DataSet();
            da.Fill(ds, "All WO Details");
            details.dataGridView_WODetails.DataSource = ds.Tables[0];
            details.ShowDialog();
        }
    }
}

