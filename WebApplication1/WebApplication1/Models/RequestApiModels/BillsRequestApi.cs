using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models.RequestApiModels
{
    public class BillsRequestApi : RequestAPI
    {
        public string BillId { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string UserId { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountAmount { get; set; }
        public string NetAmount { get; set; }
        public string PaymentType { get; set; }
        //public string CreateDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedDate { get; set; }
        //public string UpdatedBy { get; set; }
    }
}