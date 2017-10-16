using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Customer_Registration.DAL;
using System.Web;
using Customer_Registration.Models;
using System.Web.SessionState;
using System.Web.Mvc;
namespace Customer_Registration.Controllers
{
    public class LoginController : ApiController

    {
       
        public string Get()
        {

            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post(Customer cus)
        {
            string afterlogin = "";
            
            // get the customer info from post() call
            string username = cus.username.ToString();
            string password = cus.password.ToString();

            //call the DB to insert into Customer table 
           bool login = AdminInterface.GetAdminData(username, password);
           //HttpContext.Current.Session.Clear();
          // HttpContext.Current.Session["sdd"] = "dd";
                
            // return "Success"; 
           if (login)
               afterlogin = "Success";
           else
               afterlogin = "UnSuccess";
            return afterlogin;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
