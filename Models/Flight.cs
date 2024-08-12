using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class Flight
    {
        public List<Itinerary> Items { get; set; }
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public string Response { get; set; }
        public string Request { get; set; }
        public string Itinerary { get; set; }
        public string SourceMedia { get; set; }
        public string from1 { get; set; }
        public string to1 { get; set; }
        public string depdate { get; set; }
        public string type { get; set; }
        public string retdate { get; set; }
        public int adult { get; set; }
        public int child { get; set; }
        public int infant { get; set; }
        public string airline { get; set; }
        public string airport { get; set; }
        public string filterdata { get; set; }
        public double mincost { get; set; }
        public double maxcost { get; set; }
        public double totalcost { get; set; }
        public string returntype { get; set; }
        public string travel { get; set; }
        public string feefo { get; set; }
        public string unique { get; set; }
        public string Currency { get; set; }
        public string url { get; set; }
        public string stop1 { get; set; }
        public string stop2 { get; set; }
        public string stop3 { get; set; }
        public int Count { get; set; }
        public string DestCode { get; set; }
        public string from2 { get; set; }
        public string to2 { get; set; }
        public string ContactNo1 { get; set; }
    }
    public class FlightInner
    {



        public string SourceMedia { get; set; }
        public string from1 { get; set; }
        public string to1 { get; set; }
        public string depdate { get; set; }
        public string type { get; set; }
        public string retdate { get; set; }
        public int adult { get; set; }
        public int child { get; set; }
        public int infant { get; set; }
        public string airline { get; set; }
        public string airport { get; set; }
        public string filterdata { get; set; }
        public double mincost { get; set; }
        public double maxcost { get; set; }
        public double totalcost { get; set; }
        public string returntype { get; set; }
        public string triptype { get; set; }
        public string fltdata = string.Empty;
        public string faredetails = string.Empty;
        public string dest = string.Empty;
        public string destname = string.Empty;
        public string cabinclass = string.Empty;
        public bool nonstop { get; set; }
        public bool flexi { get; set; }
        public string travel = string.Empty;
        public string url = string.Empty;

    }

}