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
        //Autofilling the fields in Receiving Tab on selection of RMA# from the listbox
        public string autofill(  TextBox txtbox, ref Label lbl, ref  ComboBox cmbBox,  ref RadioButton repair, ref RadioButton replace, ref RadioButton refund)
        {
            Console.WriteLine(" Function entered");
            string type = "";
            refund.Checked = false;
            repair.Checked = false;
            replace.Checked = false;

            if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" +txtbox.Text + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
                txtbox.Text = read.GetString(read.GetOrdinal("rma_no"));
            Console.WriteLine(" hello" + txtbox.Text + "While read");

            //    read = cmd.ExecuteReader();
            
                //while (read.Read())
                //{
                //    Console.WriteLine(" Enter While Loop");
                //    txtbox.Text = read.GetString(read.GetOrdinal("rma_no"));
                //    lbl.Text = read.GetString(read.GetOrdinal("Status"));
                //    cmbBox.Text = read.GetString(read.GetOrdinal("Status"));
                //    type = read.GetString(read.GetOrdinal("type"));
                //    Console.WriteLine("YES IT HAPPENED");
                //}

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
            con.Close();
            return type;                      
        }
       


        //updating fields
        public string updateField(string field, string rmaNum)
        {
            string oldData = null;

            return oldData;
        }
        //public getNotes(string rmaNum)
        //{
        //    string notes;

        //    return notes;
        //}
    }
}
