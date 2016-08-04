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
            string empName = "Tanmeet";
            con.Open();
            cmd = new SqlCommand("select firstName from Employee where UserID='" + id + "'", con);
            read = cmd.ExecuteReader();
            while (read.Read())
                empName = read.GetString(read.GetOrdinal("firstName"));
            read.Close();
            con.Close();
            return empName;
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
