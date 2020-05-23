using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineGasAgencySystem.DataAccess;
using OnlineGasAgencySystem.Helper;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {

            List<Transaction> transactionList = new List<Transaction>();
            TransactionDB transactionDB = new TransactionDB();
            transactionList = transactionDB.GetTransaction(Session[Constant.UserName].ToString());
            return View(transactionList);


        }
    }
}