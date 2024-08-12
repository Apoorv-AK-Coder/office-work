using TravelSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.ViewModels
{
    public class HomeBanner
    {
        public string Banner = string.Empty;
        public string FlightOffer = string.Empty;
        public string Slider = string.Empty;
        public string Blog = string.Empty;
        public string ContactNo = string.Empty;
        public string ContactNo1 = string.Empty;
        public string ContactNo2 = string.Empty;
        public string Popular = string.Empty;
        public string Arrival = string.Empty;
        public string BestSeller = string.Empty;
        public string Special = string.Empty;
        public string feefo = string.Empty;
        public int bannercount;
        public string destfrom = string.Empty;
        public string destto = string.Empty;
        public string fromdate = string.Empty;
        public string todate = string.Empty;
        public string adult = string.Empty;
        public string child = string.Empty;
        public string infant = string.Empty;
        public string triptype = string.Empty;
        public string emailid = string.Empty;
        public string password = string.Empty;
        public string Domain = string.Empty;
        public string TopDest = string.Empty;
        public string TopRoutes = string.Empty;
        public string SourceMedia = string.Empty;
        public string ImagePath = string.Empty;


        
        public string DestHeading { get; set; }
        public string PageContent { get; set; }
        public string DestName { get; set; }
        public string ContinentName { get; set; }
        public string ContinentCode { get; set; }
        public string Itinerary { get; set; }




    }
    public class metadesc
    {
        public string title = string.Empty;
        public string Description = string.Empty;
        public string Language = string.Empty;
        public string Metatag = string.Empty;
        public string canonical = string.Empty;

    }
    public class thanku
    {
        public bool divCallBack { get; set; }
        public bool divContactUs { get; set; }
        public bool divFeedback { get; set; }
        public bool divFlightEnquiry { get; set; }
        public bool divHolidayEnquiry { get; set; }
        public bool divNewsLetterMails { get; set; }
    }
    public class feefo
    {
        public string divCallBack { get; set; }

    }
    public class dashboard
    {
        public string dashboarddata { get; set; }

    }


}