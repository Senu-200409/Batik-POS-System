using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models
{
    public class SubCategoriesModel
    {
        public string SubCategoryId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string IsActive { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}