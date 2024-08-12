using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.ViewModels
{
    public class Enquiry
    {       

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public string RefCode { get; set; }
        public string Guid { get; set; }
    }
}