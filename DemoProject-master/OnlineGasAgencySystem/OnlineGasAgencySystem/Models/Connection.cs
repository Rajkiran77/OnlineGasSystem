using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineGasAgencySystem.Models
{
    public class Connection
    {
        public int? connectionid { get; set; }
        public string  connectiontype { get; set; }
        public bool? isActive { get; set; }
        public int?  userid{ get; set; }
        public int? usertypeid { get; set; }
        public int? companyid { get; set; }
    }
}