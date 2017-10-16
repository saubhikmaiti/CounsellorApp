using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer_Registration.Models
{
    public class Counsellor : User
    {
        public string crid { get; set; }
        public string name { get; set; }
        public string RegNo { get; set; }
        public string YrOfExp { get; set; }
        public string email { get; set; }
        public string specialization { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string phone { get; set; }
        public int placeId { get; set; }
        public string geoAddress { get; set; }
        public HttpPostedFileBase certificateattachment { get; set; }
        public HttpPostedFileBase profilepicattachment { get; set; }
        public HttpPostedFileBase resumeattachment { get; set; }
    }
}