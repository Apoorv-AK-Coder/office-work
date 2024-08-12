using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.ViewModels
{
    public class Destination
    {
        public string destinationname { get; set; }
        public string continentname { get; set; }
        public string airportlink { get; set; }
        public string orgcode { get; set; }
        public string destcode { get; set; }
        public string data { get; set; }
        public string tab { get; set; }
        public string tabdata { get; set; }
        public string Image { get; set; }
        public string feefo { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string destfrom = string.Empty;
        public string destto = string.Empty;
        public string fromdate = string.Empty;
        public string todate = string.Empty;
        public string adult = string.Empty;
        public string child = string.Empty;
        public string infant = string.Empty;
        public string triptype = string.Empty;
    }
    public class Specialoffer
    {
        public string groupon { get; set; }
        public string wowcher { get; set; }
        public string newsletter { get; set; }
    }
    public class Holidayoffer
    {
        public string HotelNameSpan { get; set; }
        public string HtlAddSpan { get; set; }
        public string StarImgSpan { get; set; }
        public string PriceSpan { get; set; }
        public string RefCodeSpan { get; set; }
        public string NightsSpan { get; set; }
        public string BoardTypeSpan { get; set; }
        public string SaveUptoSpan { get; set; }

        public string sync1 { get; set; }
        public string sync2 { get; set; }
        public string HtlDescDiv { get; set; }


        public string HtlFaciDiv { get; set; }


        public string RoomFaciDiv { get; set; }

        public string GoToDiv { get; set; }
        public string MapDiv { get; set; }


        public string data { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string destcode { get; set; }
        public string hotelid { get; set; }
    }
    public class Airlineoffer
    {
        public string airlinedata { get; set; }
        public string Image { get; set; }
        public string TabHeader { get; set; }
        public string TabDetails { get; set; }
        public string orgcode { get; set; }
        public string destcode { get; set; }
        public string feefo { get; set; }
    }
}