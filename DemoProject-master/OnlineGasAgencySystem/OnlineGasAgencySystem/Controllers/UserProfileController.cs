using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineGasAgencySystem.DataAccess;
using OnlineGasAgencySystem.Helper;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUserProfile() {
            UserProfile userprofile = new UserProfile();
            UserProfileDB userProfileDB = new UserProfileDB();
            userprofile = userProfileDB.GetUserProfile(Session[Constant.UserName].ToString());
            return Json(userprofile,JsonRequestBehavior.AllowGet);
        }
    }
   
}