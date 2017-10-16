using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer_Registration.Models
{
    public class Customer
    {
        public string cid { get; set; }
        public string name{get;set;}
        public string surname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string password { get; set; }
        public DateTime Created_Time { get; set; }
    }
}