using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer_Registration.DAL;

namespace Customer_Registration.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string id)
        {
            if (id != null)
            {
                System.Web.HttpContext.Current.Session["Admin"] = id;
                return RedirectToAction("ViewRecords", "Home");
            }
            else
            {
                System.Web.HttpContext.Current.Session["Admin"] = "";
                return View();
            }
           
        }


    }
}
