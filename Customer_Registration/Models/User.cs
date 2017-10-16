using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer_Registration.Models
{
    public abstract class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public UserType userType { get; set; }
    }

   
    public enum UserType
    {
        Admin = 0,
        CR,
        CE
    }
}