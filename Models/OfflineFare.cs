using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class OfflineFare
    {

        public string DestinationImg { get; set; }
        public string AirlineImg { get; set; }
        public string Airlinename { get; set; }
        public string Price { get; set; }
        public string DestinationName { get; set; }
        public string Destinationurl { get; set; }
        public string ContinentUrl { get; set; }
        public string Countryurl { get; set; }
        public string sourceName { get; set; }
        public string SourceCode { get; set; }
        public string date { get; set; }
        public string destinationcode { get; set; }
        public string continentcode { get; set; }
        public string ClassType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string  ContinentName{get; set;}
    }

    public class FlightFare
    {
        public string ImagePath { get; set; }
        public string Total { get; set; }
        public string DestfromName { get; set; }
        public string DesttoName { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }        
        public string Continent_Code { get; set; }
        public string Continent_Name { get; set; }
        public string ClassType { get; set; }
        public string CountryName { get; set; }
        public string qs { get; set; }
        public string AirlineLogo { get; set; }
        
    }
}