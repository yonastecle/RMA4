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
  
    public class Notes
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;

        public string RMA_no { get; set; }
        public string description { get; set; }
        public string statusUpdates { get; set; }
        public string comments { get; set; }
        public string resolution { get; set; }

        //updating fields-Notes
        public void updateField(string type,string txt, string rmaNum)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                string oldData = null;
                
                con.Open();
                cmd = new SqlCommand(" Select * from Notes where RMA_no='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    oldData = read.GetString(read.GetOrdinal(type));
                }
                con.Close();
              
                con.Open();
                //- not executing
                //cmd = new SqlCommand("UPDATE  Notes  SET' "+type+"'='" + DateTime.Now.ToShortDateString()+"' : '"  + txt + System.Environment.NewLine + oldData + "'FROM Notes WHERE RMA_no = '" + rmaNum + "'", con);
            
               cmd = new SqlCommand("UPDATE  Notes  SET Notes.statusUpdates ='" + DateTime.Now.ToShortDateString() + " : " +txt+System.Environment.NewLine+ oldData + "'FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no = '" + rmaNum + "'", con);                            
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
