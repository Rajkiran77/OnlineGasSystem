using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineGasAgencySystem.Models
{
    public class UserProfile
    {
        public int? userid { get; set; }
        public string username { get; set; }
        public long? userphone { get; set; }
        public long? altphonenumber { get; set; }
        public string useremail { get; set; }
        public string useraddress { get; set; }
        public string userpassword { get; set; }
    }
}