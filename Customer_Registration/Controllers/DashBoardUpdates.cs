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
  public class DashBoardUpdatesController : ApiController
  {
    public List<Customer_Info> Get()
    {
      List<Customer_Info> records = CustomersInterface.GetBreakDownByAge();

      return records;

    }

    // GET api/values/5
    public List<Customer_Info> Get(int id)
        {
      List<Customer_Info> records=null;
          if(id==1)
           records = CustomersInterface.GetUsersPerHour();
          else if(id==2)
           records = CustomersInterface.GetBreakDownByAge();
        
          return records;

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
