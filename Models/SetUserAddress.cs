using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class SetUserAddress
    {
        public static string Title { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string homePhone { get; set; }
      
        public static string MobNo { get; set; }
     
        public static string Email { get; set; }
      
        public static string ConfirmEmail { get; set; }

        public static bool promotial_deals { get; set; }
       
        public static string Passenger_Addressone { get; set; }

        public static string Passenger_Addresstwo { get; set; }

        public static string Passenger_city { get; set; }
        public static string Passenger_State { get; set; }        
        public static string Passenger_Pin { get; set; }       
        public static string Passenger_countrylist { get; set; }
        public static string _BookingID { get; set; }
    }
}