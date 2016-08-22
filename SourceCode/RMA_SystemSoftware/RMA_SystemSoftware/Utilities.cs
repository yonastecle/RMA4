using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;


namespace RMA_SystemSoftware
{
    class Utilities
    {
        public void SendEmail(string rmaNum, string reason, string status)
        {
            try
            {
                //Create a string list to hold all the recipients of the email
                List<string> lstAllRecipients = new List<string>();
                //Below is hardcoded - can be replaced with db data if need be, this is where we add the people to receive the email
                lstAllRecipients.Add("tanmeet@CNBCOMPUTERS.com");

                //this is where we instantiate 
                Outlook.Application outlookApp = new Outlook.Application();
                //Creating a mail item
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
                // Thread.Sleep(10000);

                // Recipients, more can be added to list
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                //Cycle through list of recipients and add to Outlook Recipients list
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }

                //Add CC -Or Carbon Copy
               /* Outlook.Recipient oCCRecip = oRecips.Add("tanmeetkaur28@gmail.com");//Rey or Kong or both?
                oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                oCCRecip.Resolve(); */

                if(status.Contains("hold"))
                {
                    //Add the Subject of the email
                    oMailItem.Subject = "RMA" + rmaNum+" put on Hold";

                    // body, bcc etc...
                    //The text variable is passed through as an argument when the method is instantiated
                    oMailItem.Body = "RMA Number: " + rmaNum + " has been put on hold \n Reason: " + reason;

                }
                else if(status.Contains("complete"))
                {
                    oMailItem.Subject = " WO"+rmaNum+" Completed";
                    oMailItem.Body = "Work has ben completed for RMA Number: " + rmaNum + " \n Resolution: " + reason;

                }                                  

                //This will send the email without opening an Outlook window
                oMailItem.Send();
                //oMailItem.Display(true);//This would be used to open an Outlook window and show the message in a new email window            
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error occured while preparing to email.\n"
                    + ex.Message, "Oh snap...... Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
