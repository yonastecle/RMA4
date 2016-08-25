﻿using System;
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
        GrabData grab = new GrabData();

        public string RMA_no { get; set; }
        public string description { get; set; }
        public string statusUpdates { get; set; }
        public string comments { get; set; }
        public string resolution { get; set; }

        //updating fields-Notes
        public void updateField(string type,string txt, string rmaNum, string techname)
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
                //- not working: If below works , the following function can be omitted!
                //cmd = new SqlCommand("UPDATE  Notes  SET' "+type+"'='" + DateTime.Now.ToShortDateString()+"': '"  + txt+ "'"+ System.Environment.NewLine +"'"+ oldData + "'FROM Notes WHERE RMA_no = '" + rmaNum + "'", con);
                cmd = new SqlCommand("UPDATE  Notes  SET Notes.statusUpdates ='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " +techname.ToString() + ": "+txt+System.Environment.NewLine+ oldData + "'FROM RMA R, Notes N WHERE R.rma_no = N.RMA_no AND R.rma_no = '" + rmaNum + "'", con);                            
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Updating Notes: Helpdesk Screen+ Tech open
        public void updateField(string rmaNum,string desp,string res,string stat, string techname)
        {
            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                string oldDesp="", oldRes="", oldStat="";

                con.Open();
                cmd = new SqlCommand("Select * from Notes where RMA_No='" + rmaNum + "'", con);
                read = cmd.ExecuteReader();
                while(read.Read())
                {
                    oldDesp = read.GetString(read.GetOrdinal("description"));                  
                    oldRes = read.GetString(read.GetOrdinal("resolution"));
                    oldStat = read.GetString(read.GetOrdinal("statusUpdates"));              
                }
                con.Close();

                con.Open();
                cmd = new SqlCommand("update Notes set description=' " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + techname.ToString() + " : " +desp+System.Environment.NewLine+ oldDesp + "', statusUpdates='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + techname.ToString() + " : " + stat + "',resolution='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + techname.ToString() + " : " + res + System.Environment.NewLine + oldRes + "' from RMA R, Notes N where R.rma_no=N.RMA_no and R.rma_no='" + rmaNum + "'", con);              
                cmd.ExecuteNonQuery();               
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void History(RMA rma, ref RichTextBox notes, ref Label rmaNum, ref Label status, ref Label type, ref Label techName, ref Label invoice, ref Label order, ref Label serial)
        {
            string Desp = "", Res = "", Stat = "",id;     
            try
            {
                con.Open();
                cmd = new SqlCommand(" Select * from RMA where rma_no= '"+rma.rma_no+"'",con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    rmaNum.Text = read.GetString(read.GetOrdinal("rma_no"));
                    status.Text = read.GetString(read.GetOrdinal("Status"));                   
                    type.Text = read.GetString(read.GetOrdinal("type"));                   
                    invoice.Text = Convert.ToString(read["invoiceNo"]);
                    order.Text = Convert.ToString(read["orderNo"]);
                    serial.Text = Convert.ToString(read["serialNo"]);
                    id = read.GetString(read.GetOrdinal("userID"));
                    techName.Text = grab.getEmployeeName(id);
                }           
                con.Close();

                con.Open();
                cmd = new SqlCommand("Select * from Notes where RMA_no='" + rma.rma_no + "'", con);
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Desp = read.GetString(read.GetOrdinal("description"));
                    Res = read.GetString(read.GetOrdinal("resolution"));
                    Stat = read.GetString(read.GetOrdinal("statusUpdates"));
                }
                con.Close();
                //notes.Clear();
                notes.Text = " \b Description}"+ System.Environment.NewLine + Desp + System.Environment.NewLine + "___________________________________________________________________________________________________________" + System.Environment.NewLine;                    
                notes.Text += " \b Resolution" + System.Environment.NewLine + Res + System.Environment.NewLine + "___________________________________________________________________________________________________________" + System.Environment.NewLine;
                notes.Text += " \b Status Updates" + System.Environment.NewLine + Stat + System.Environment.NewLine + "___________________________________________________________________________________________________________" + System.Environment.NewLine;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                              
        }
    }
    
}
