using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class HomePageOffer
    {
        public HomePageOffer()
        {
            Company = CompCredentials.CompanyId; 
        }
        public string CClass { set; get; }
        public string PageType { set; get; }
        public string Company { set; get; }
        public string OfferType { set; get; }
        public string Counter { set; get; }
        public string Domain { set; get; }
    }
    public class FlightOfferRequest
    {
        public FlightOfferRequest()
        {
            Company = CompCredentials.CompanyId;
        }
        public string SeasonID { set; get; }
        public string DestFrom { set; get; }
        public string DestFromName { set; get; }
        public string DestTo { set; get; }
        public string DestToName { set; get; }
        public string CabinClass { set; get; }
        public string ContinentCode { set; get; }
        public string ContinentName { set; get; }
        public string PageType { set; get; }
        public string Company { set; get; }
        public string Counter { set; get; }
        public string DepDate { set; get; }
        public string RetDate { set; get; }
        public string Domain { set; get; }
    }
    public class ContantHeadingReq
    {
        public ContantHeadingReq()
        {
            CompanyID = CompCredentials.CompanyId; 
        }
        public string ContantHeadingID { set; get; }
        public string DestinationCode { set; get; }
        public string AirportCode { set; get; }
        public string ContantHeading { set; get; }
        public string ContantTab { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
        public string LangCode { set; get; }
        public string company { set; get; }
        public string PageUrl { set; get; }
        public string CompanyID { set; get; }
        public string Airline { set; get; }
        public string Type { set; get; }
        public int Counter { set; get; }

    }
    public class FareQuotesDetails
    {
        public FareQuotesDetails()
        {

        }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Phone { set; get; }
        public string EMail { set; get; }
        public string TripType { set; get; }
        public DateTime date { set; get; }
        public DateTime ReturnDate { set; get; }
        public string DepartCityCode { set; get; }
        public string DestCityCode { set; get; }
        public string cClass { set; get; }
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
        public string RefCode { set; get; }
        public string SourceMedia { set; get; }
        public string AirlineName { set; get; }
        public string CallRes { set; get; }
    }
}