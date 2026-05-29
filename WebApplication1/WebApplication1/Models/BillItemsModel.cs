using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models
{
    public class BillItemsModel
    {
        public string BillItemId { get; set; }
        public string BillId { get; set; }
        public string ProductId { get; set; }
        public string Qty { get; set; }
        public string UnitPrice { get; set; }
        public string Total { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}