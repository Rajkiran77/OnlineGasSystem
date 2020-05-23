using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineGasAgencySystem.Models
{
    public class Transaction
    {
        public int? transactionid { get; set; }
        public int? connectionid { get; set; }
        public string connectiontype { get; set; }
        public DateTime? tdob { get; set; }
        public DateTime? tdod { get; set; }
        public int? bookingid { get; set; }
        public int? price { get; set; }
        public int? companyid { get; set; }
        public string companyname { get; set; }
        public string statustype { get; set; }
        public int? userid { get; set; }
        public string username { get; set; }
        public long? userphone { get; set; }
        public long? useraltphone { get; set; }
        public string useraddress { get; set; }
    }
}