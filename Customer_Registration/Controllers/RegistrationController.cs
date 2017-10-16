using System.Net.Http;
using System.Web.Http;
using Customer_Registration.DAL;
using Customer_Registration.Models;

namespace Customer_Registration.Controllers
{
   
    public class RegistrationController : ApiController
    {
        public string Get()
        {
                var queryItems = Request.RequestUri.ParseQueryString();
                // get the customer info from get() call
                string name = queryItems["name"].ToString();
                string surname = queryItems["surname"].ToString();
                string email = queryItems["email"].ToString();
                string username = queryItems["username"].ToString();
                string password = queryItems["password"].ToString();
                string dateofBirth = queryItems["dateofbirth"].ToString();
                //call the DB to insert into Customer table 
                CustomersInterface.Insert_Customer_Info(name, surname, email, username, password, dateofBirth);
                // return "Success"; 
            
                return "Success";

        }
       
        [HttpPost]
        public string firstCall(HttpRequestMessage request,
            [FromBody] Counsellor counsellor)
        {
            return "Data Reached";
        }

        [HttpGet]
        public string RegisterCounsellor()
        {


            return "";
        }

            

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        public string Post()
        {
            //Counsellor counsellor
            return "ok";
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
