using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Customer_Registration.DAL;
using Customer_Registration.Models;

namespace Customer_Registration.Controllers
{
    public class UpdateCustomerRecordsController : ApiController
    {
        public string Get()
        {
            var queryItems = Request.RequestUri.ParseQueryString();
            // get the customer info from get() call
          //     'cid': cid , 'val': val, 'field': param
            string cid = queryItems["cid"].ToString();
            string val = queryItems["val"].ToString();
            string field = queryItems["field"].ToString();
           
            CustomersInterface.UpdateCustomerFields(cid,val,field);
            // return "Success"; 

 
            return "success";

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
