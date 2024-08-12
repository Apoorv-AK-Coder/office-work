using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class FlightFareDestination
    {
        public FlightFareDestination(DataRow dr)
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
            ExpOffers_Date = string.IsNullOrEmpty(dr["ExpOffers_Date"].ToString()) ? "" : Convert.ToDateTime(dr["ExpOffers_Date"]).ToString("dd MM yyyy");
            Travel_DateStart = string.IsNullOrEmpty(dr["Travel_DateStart"].ToString()) ? "" : Convert.ToDateTime(dr["Travel_DateStart"]).ToString("dd MMM yyyy");
            Travel_DateEnd = string.IsNullOrEmpty(dr["Travel_DateEnd"].ToString()) ? "" : Convert.ToDateTime(dr["Travel_DateEnd"]).ToString("dd MMM yyyy");
            SequenceNo = dr["SequenceNo"].ToString();
            ImgUrl = dr["ImgUrl"].ToString();
            FilledBy = dr["FilledBy"].ToString();
            ImgThumbPath = dr.Table.Columns.Contains("ImgThumbPath") ? dr["ImgThumbPath"].ToString() : "";
            SeasonName = dr.Table.Columns.Contains("SeasonName") ? dr["SeasonName"].ToString() : "";
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
        public string SequenceNo { set; get; }
        public string ImgUrl { set; get; }
        public string FilledBy { set; get; }
        public string ImgThumbPath { set; get; }
        public string SeasonName { set; get; }
    }
    public class ContantHeading
    {
        public ContantHeading(DataRow dr)
        {
            ML_DestinationCode = dr["ML_DestinationCode"].ToString();
            ML_AirportCode = dr["ML_AirportCode"].ToString();
            ML_ContantHeading = dr["ML_ContantHeading"].ToString();
            ML_ContantTab = dr["ML_ContantTab"].ToString();
        }
        public string ML_DestinationCode { set; get; }
        public string ML_AirportCode { set; get; }
        public string ML_ContantHeading { set; get; }
        public string ML_ContantTab { set; get; }

    }
    public class TitleAndMeta
    {
        public TitleAndMeta(DataRow dr)
        {
            ML_ContentID = dr["ML_ContentID"].ToString();
            ML_CompanyID = dr["ML_CompanyID"].ToString();
            ML_Title = dr["ML_Title"].ToString();
            ML_Metatag = dr["ML_Metatag"].ToString();
            ML_Description = dr["ML_Description"].ToString();
            ML_LanguageCode = dr["ML_LanguageCode"].ToString();
            ML_PageType = dr["ML_PageType"].ToString();
            ML_Url = dr["ML_Url"].ToString();
            ML_Summary = dr["ML_Summary"].ToString();
            ML_MetaDescription = dr["ML_MetaDescription"].ToString();
        }
        public string ML_ContentID { set; get; }
        public string ML_CompanyID { set; get; }
        public string ML_Title { set; get; }
        public string ML_Metatag { set; get; }
        public string ML_Description { set; get; }
        public string ML_LanguageCode { set; get; }
        public string ML_PageType { set; get; }
        public string ML_Url { set; get; }
        public string ML_Summary { set; get; }
        public string ML_MetaDescription { set; get; }
    }
}
