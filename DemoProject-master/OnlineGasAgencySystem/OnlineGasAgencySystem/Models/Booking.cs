using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineGasAgencySystem.Models
{
    public class Booking
    {
        public int? bookingid { get; set; }
        public int? userid { get; set; }
        public int? connectionid { get; set; }
        public int? price { get; set; }
        public string statustype { get; set; }

    }
}