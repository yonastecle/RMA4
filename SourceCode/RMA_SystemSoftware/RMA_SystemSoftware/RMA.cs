using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMA_SystemSoftware
{
   public class RMA
    {
        public string rma_no { get; set; }
        public string customer { get; set; }
        public string userID { get; set; }
        public int invoiceNo { get; set; }
        public string Status { get; set; }
        public char type { get; set; }
        public int quantity { get; set; }
        public int category { get; set; }
        public string ups { get; set; }
        public string mar { get; set; }
        public string orderNo { get; set; }
        public string serialNo { get; set; }
        public DateTime date_received { get; set; }
        public DateTime date_assigned { get; set; }
        public DateTime date_hold { get; set; }
        public DateTime date_wait { get; set; }
        public DateTime date_closed { get; set; }
        public DateTime date_completed { get; set; }

    }
}
