using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineGasAgencySystem.Models
{
    public class CustomerSupport
    {   public int? custsupportid { get; set; }
        public long? custsupportphno { get; set; }
        public string custsupportemail { get; set; }
        public string companyname { get; set; }
    }
}