using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_System.Models
{
    public class UserAuthKeyModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string AuthKey { get; set; }
    }
}