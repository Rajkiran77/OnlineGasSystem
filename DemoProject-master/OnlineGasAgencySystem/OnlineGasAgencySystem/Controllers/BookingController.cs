using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineGasAgencySystem.DataAccess;
using OnlineGasAgencySystem.Helper;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking 
        public ActionResult Index()
        {
            Booking booking = new Booking();
            BookingDB bookingDB = new BookingDB();
            booking = bookingDB.GetBooking(Convert.ToInt32(Session[Constant.UserID]));
            return View(booking);
        }
    }
}