using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models.RequestApiModels
{
    public class UserRequestApi : RequestAPI
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }

        public string IsActive { get; set; }

        //public string CreateDate { get; set; }

        //public string CreatedBy { get; set; }

        //public string UpdatedDate { get; set; }

        //public string UpdatedBy { get; set; }
    }
}