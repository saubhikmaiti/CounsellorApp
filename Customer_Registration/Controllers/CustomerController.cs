using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer_Registration.DAL;

namespace Customer_Registration.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult DisplayCustomers()
        {

            return View(CustomersInterface.GetCustomersData());
        }
        [ActionName("DisplayCustomers_Authenticate")]
        public ActionResult DisplayCustomers(string id)
        {
            if (Session["Admin"] == null)
            {
                Session["Admin"] = id;
                // RedirectToAction("/Home/Register");
                // Redirect("/Home/Register");
            }
            return View(CustomersInterface.GetCustomersData());
        }
 
    }
}
