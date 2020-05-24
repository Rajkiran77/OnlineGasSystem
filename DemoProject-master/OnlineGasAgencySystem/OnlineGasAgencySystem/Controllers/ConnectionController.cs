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
    public class ConnectionController : Controller
    {
      


        // GET: Connection chhhhhh

        // GET: Connection chhhhhh hello



     

        public ActionResult Index()
        {
            Connection connection = new Connection();
            ConnectionDB connectionDB = new ConnectionDB();
            connection = connectionDB.GetConnection(Convert.ToInt32(Session[Constant.UserID]));
            return View(connection);

        }
    }
}