using System.Collections.Generic;
using System.Web.Mvc;
using OnlineGasAgencySystem.DataAccess;
using OnlineGasAgencySystem.Models;
namespace OnlineGasAgencySystem.Controllers
{
    public class CustomerSupportController : Controller
    {
        // GET: CustomerSupport
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetFAQList(int CompanyID)
        {
            List<FAQ> fAQs = new List<FAQ>();
            CustomerSupportDB customerSupportDB = new CustomerSupportDB();
            fAQs = customerSupportDB.GetFAQ(CompanyID);
            return Json(fAQs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompanies()
        {
            List<Company> companylist = new List<Company>();
            CustomerSupportDB customerSupportDB = new CustomerSupportDB();
            companylist = customerSupportDB.GetCompanyList();
            return Json(companylist, JsonRequestBehavior.AllowGet);
        }

    }
}