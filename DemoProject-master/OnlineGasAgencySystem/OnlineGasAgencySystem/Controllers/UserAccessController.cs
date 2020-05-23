using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineGasAgencySystem.DataAccess;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.Controllers
{
    public class UserAccessController : Controller
    {
        // GET: UserAccess
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string username, string password)
        {
            UserProfile userProfile = new UserProfile();
            UserProfileDB userProfileDB = new UserProfileDB();
            userProfile = userProfileDB.GetUserProfile(username);

            if (userProfile.userid != null && userProfile.userpassword.Trim() == password.Trim())
            {
                Session["UserName"] = userProfile.username.Trim();
                Session["UserID"] = userProfile.userid;
                Session["UserEmail"] = userProfile.useremail.Trim();
                List<string> name = new List<string>();
                List<UserProfile> nuser = new List<UserProfile>();
                name.Add("raj");
                name.Add("rajkiran");
                name.Add("vigu");
                name.Add("indra");
                name.Add("vinod");
                

                return Json(new { value = name, status = true, redirectUrl = Url.Action("Index", "Booking") }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (userProfile == null)
                {
                    return Json(new { status = false, errorMessage = "UserName is incorrect" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = false, errorMessage = "Password is incorrect" }, JsonRequestBehavior.AllowGet);
                }
            }

        }
        public JsonResult Register(UserProfile userProfile)
        {
            UserProfileDB userProfileDB = new UserProfileDB();
            userProfile = userProfileDB.InsertUserProfile(userProfile);
            if (userProfile.userid > 0)
            {
                return Json(new { status = true, Message = "Userprofile is sucessfully registered" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = false, Message = "Userprofile is not able to register" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}