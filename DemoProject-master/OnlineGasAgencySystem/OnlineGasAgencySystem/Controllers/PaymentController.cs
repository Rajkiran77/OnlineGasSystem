using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineGasAgencySystem.DataAccess;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            /*Payment payment = new Payment();
            PaymentDB paymentDB = new PaymentDB();
            Payment = paymentDB.GetPayment(Session["UserName"].ToString());*/
            return View();
        }
    }
}