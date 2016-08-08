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
    class GrabData
    {
        SqlConnection con = new SqlConnection(@"Data Source=NimeshPatel-RMA\SQLEXPRESS;Initial Catalog=RMA_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;
        //SqlDataAdapter da;
        //DataSet ds;

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
                    MessageBox.Show("Changes Saved..Press Refresh! ", "DB Updated!");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Receiving+Technician:Autofilling the fields on selection of RMA# from the listbox or keypress
        public string autofill(string rmaNum, ref TextBox txtbox, ref Label lbl, ref  ComboBox cmbBox,  ref RadioButton repair, ref RadioButton replace, ref RadioButton refund)
        {
            string type = "";
            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                con.Open();
                cmd = new SqlCommand("Select * from RMA where rma_no='" + rmaNum+ "'", con);
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
        public void autofill(string rmaNum, ref TextBox txtboxRmaNum,ref Label lblStatus, ref ComboBox cmbBox, ref string req_type, ref int cat, ref RadioButton repair,ref RadioButton replace, ref RadioButton refund, ref RadioButton cat1, ref RadioButton cat2, ref RadioButton cat3, ref RadioButton cat4, ref Label lblTech, ref TextBox txtboxStatUpdate)
        {
            string ID = "";
            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();
                cmd = new SqlCommand("select * from RMA where rma_no ='" +rmaNum + "'", con);
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
                while (read.Read())
                    txtboxStatUpdate.Text = read.GetString(read.GetOrdinal("statusUpdates"));
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Change technician
        public void techChange(string rmaNum, ref ComboBox cmbBox)
        {
            string id ="";
            id = getEmployeeID(cmbBox.Text);      
            con.Open();
            cmd = new SqlCommand("update RMA set userID='" + id + "'where rma_no='" + rmaNum + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Technician Re-assigned!");
            con.Close();
        }                           
        //updating fields-Noes
        public string updateField(ref TextBox field, string rmaNum, string type)
        {
            string oldData = null;
            con.Open();
            cmd= new SqlCommand("Select * from Notes where RMA_no="+rmaNum)


            return oldData;
        }
        //public getNotes(string rmaNum)
        //{
        //    string notes;

        //    return notes;
        //}
    }
}
