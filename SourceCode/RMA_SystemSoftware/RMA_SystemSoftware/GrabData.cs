using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
