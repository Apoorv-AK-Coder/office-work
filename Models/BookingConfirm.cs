using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class BookingConfirm
    {
        public Itinerary Itinerary { set; get; }
        public List<Pax> Pax { set; get; }
        public PaymentCallbackDetails PaymentCallbackDetails { set; get; }
        public string Guid { get; set; }
        public string KayakClickID { get; set; }
        public string kayakid { get; set; }
        public string wegoid { get; set; }
        public string BookingStatus { get; set; }
        public string merchantreference { get; set; }
        public string loanamount { get; set; }
        public string BookingRef { get; set; }
        public string PNR { get; set; }
        public string Email { get; set; }
        public string Destination { get; set; }
        public string MobileNo { get; set; }
        public string Phone { get; set; }
        public string BookingDate { get; set; }
        public string Status { get; set; }
        public string CardHolderName { get; set; }
        public string CardNo { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CardType { get; set; }
        public double CardCharge { get; set; }
        public double GrandTotal { get; set; }

        public string Adult { get; set; }
        public string Child { get; set; }
        public string Infant { get; set; }


        public string PaxName { get; set; }
        public string Address { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
                        
        public string Coupon { get; set; }

        public string TransactionID { get; set; }
        public string DeviceType { get; set; }

        
        public string baggage_protection { set; get; }
        

        public string From { get; set; }

        public string To { get; set; }

        public string Pax_str { get; set; }

        public double PayExtra_Amount { get; set; }
    }
}