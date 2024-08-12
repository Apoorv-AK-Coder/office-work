using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{

    public class FlightFareAirline
    {
        public FlightFareAirline(DataRow dr)
        {
            Airline_Code = dr["Airline_Code"].ToString();
            From = dr["From"].ToString();
            To = dr["To"].ToString();
            DestfromName = dr["DestfromName"].ToString();
            DesttoName = dr["DesttoName"].ToString();
            Country = dr["Country"].ToString();
            Airline_Name = dr["Airline_Name"].ToString();
            Continent_Name = dr["Continent_Name"].ToString();
            Continent_Code = dr["Continent_Code"].ToString();
            BaseFare = string.IsNullOrEmpty(dr["BaseFare"].ToString()) ? 0 : Convert.ToDouble(dr["BaseFare"]);
            Tax = string.IsNullOrEmpty(dr["Tax"].ToString()) ? 0 : Convert.ToDouble(dr["Tax"]);
            Directflt = dr["Directflt"].ToString();
            Total = string.IsNullOrEmpty(dr["Total"].ToString()) ? 0 : Convert.ToDouble(dr["Total"]);
            Markup = string.IsNullOrEmpty(dr["Markup"].ToString()) ? 0 : Convert.ToDouble(dr["Markup"]);
            GrandTotal = string.IsNullOrEmpty(dr["GrandTotal"].ToString()) ? 0 : Convert.ToDouble(dr["GrandTotal"]);
            ClassType = dr["ClassType"].ToString();
            Class = dr["Class"].ToString();
            ExpOffers_Date = string.IsNullOrEmpty(dr["ExpOffers_Date"].ToString()) ? "" : Convert.ToDateTime(dr["ExpOffers_Date"]).ToString("dd/MM/yyyy");
            Travel_DateStart = string.IsNullOrEmpty(dr["Travel_DateStart"].ToString()) ? "" : Convert.ToDateTime(dr["Travel_DateStart"]).ToString("dd/MM/yyyy");
            Travel_DateEnd = string.IsNullOrEmpty(dr["Travel_DateEnd"].ToString()) ? "" : Convert.ToDateTime(dr["Travel_DateEnd"]).ToString("dd/MM/yyyy");
            FilledBy = dr["FilledBy"].ToString();
        }
        public string Airline_Code { set; get; }
        public string From { set; get; }
        public string To { set; get; }
        public string DestfromName { set; get; }
        public string DesttoName { set; get; }
        public string Country { set; get; }
        public string Airline_Name { set; get; }
        public string Continent_Name { set; get; }
        public string Continent_Code { set; get; }
        public double BaseFare { set; get; }
        public double Tax { set; get; }
        public string Directflt { set; get; }
        public double Total { set; get; }
        public double Markup { set; get; }
        public double GrandTotal { set; get; }
        public string ClassType { set; get; }
        public string Class { set; get; }
        public string ExpOffers_Date { set; get; }
        public string Travel_DateStart { set; get; }
        public string Travel_DateEnd { set; get; }
        public string FilledBy { set; get; }
    }
    public class AirlineRequest
    {
        public AirlineRequest()
        {

        }
        public string Airline { set; get; }
        public string CabinClass { set; get; }
        public string Counter { set; get; }
    }

    public class FlightFareAirlineHome
    {
        public FlightFareAirlineHome(DataRow dr)
        {

            Airline_Name = dr["Airline_Name"].ToString().Trim();
            Airline_Code = dr["Airline_Code"].ToString().Trim();
            Total = string.IsNullOrEmpty(dr["Total"].ToString()) ? 0 : Convert.ToDouble(dr["Total"]);
            ClassType = dr["ClassType"].ToString();
            AIR_ThumbImage = dr["AIR_ThumbImage"].ToString();
            FullImage = dr["FullImage"].ToString();
        }
        public string Airline_Name { set; get; }
        public string Airline_Code { set; get; }
        public double Total { set; get; }
        public string ClassType { set; get; }
        public string AIR_ThumbImage { set; get; }
        public string FullImage { set; get; }
    }
    public class AirlinefareRequest
    {
        public AirlinefareRequest()
        {

        }
        public string Company { set; get; }
        public string Airline { set; get; }
        public string Counter { set; get; }
    }
}
