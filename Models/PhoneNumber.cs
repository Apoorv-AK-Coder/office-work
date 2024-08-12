using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class PhoneNumber
    {
        public string PhoneNumber1 { get; set; }
        public string SourceMedia { get; set; }
        public PhoneNumber()
        {
            PhoneNumber1 = "866-699-8919";
        }
        public string description { get; set; }
    }
}