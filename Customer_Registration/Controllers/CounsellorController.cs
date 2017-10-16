using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer_Registration.DAL;
using Customer_Registration.Models;

namespace Customer_Registration.Controllers
{
    //  Counsellor/Register
    public class CounsellorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult DisplayCounsellor()
        {
            return View(CustomersInterface.GetCustomersData());
        }
        [ActionName("DisplayCustomers_Authenticate")]
        public ActionResult DisplayCounsellor(string id)
        {
            if (Session["Admin"] == null)
            {
                Session["Admin"] = id;
                // RedirectToAction("/Home/Register");
                // Redirect("/Home/Register");
            }
            return View(CustomersInterface.GetCustomersData());
        }

        [HttpPost]
        public string Register1(Counsellor counsellor)
        {

            return "";
        }
    }
}
