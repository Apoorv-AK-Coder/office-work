using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class HolidayEnq
    {

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string TripType { set; get; }
        public DateTime date { set; get; }
        public DateTime ReturnDate { set; get; }
        public string DepartCityCode { set; get; }
        public string DestCityCode { set; get; }
        public string Class { set; get; }
        public DateTime CallDate { set; get; }
        public string CallTime { set; get; }
        public string CallRemarks { set; get; }
        public DateTime dDateTime { set; get; }
        public string Company { set; get; }
        public string EnquiryType { set; get; }
        public string Title { set; get; }
        public string ContactNo { set; get; }
        public string City { set; get; }
        public string BoardBasis { set; get; }
        public int NoOfPassanger { set; get; }
        public string NoOfNights { set; get; }
        public string FeedBackType { set; get; }
        public string Subject { set; get; }
        public string RefCode { get; set; }
        public string SourceMedia { get; set; }
    }
}
