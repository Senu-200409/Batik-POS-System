using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models
{
    public class ProductsModel
    {
        public string ProductId { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryId { get; set; }
        public string UnitType { get; set; }
        public string Price { get; set; }
        public string ProductImage { get; set; }
        public string IsActive { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}