using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    [Serializable]
    public class HomePageTopOffer
    {
        public HomePageTopOffer(DataSet ds)
        {
            List<BannerUpload> _BannerUpload = new List<BannerUpload>();
            List<TopOfferFare> _TopOfferFare = new List<TopOfferFare>();
            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {

                        _TopOfferFare.Add(new TopOfferFare(dr));
                    }
                }
                if (ds.Tables[1] != null)
                {

                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {

                        _BannerUpload.Add(new BannerUpload(dr));
                    }
                }
            }

            BannerUpload = _BannerUpload;
            TopOfferFare = _TopOfferFare;
        }
        public List<BannerUpload> BannerUpload { set; get; }
        public List<TopOfferFare> TopOfferFare { set; get; }

    }
    [Serializable]
    public class BannerUpload
    {
        public BannerUpload()
        {
        }
        public BannerUpload(DataRow dr)
        {
            Id = dr["Id"].ToString();
            Company = dr["Company"].ToString();
            Type = dr["Type"].ToString();
            PageType = dr["PageType"].ToString();
            ImagePath = dr["ImagePath"].ToString();
            Description = dr["Description"].ToString();
            Link = dr["Link"].ToString();
            TitleTag = dr["TitleTag"].ToString();
            AltTag = dr["AltTag"].ToString();
            Caption = dr["Caption"].ToString();
            ModifyBy = dr["ModifyBy"].ToString();
            ModifyDate = dr["ModifyDate"].ToString();
        }
        public string Id { set; get; }
        public string Company { set; get; }
        public string Type { set; get; }
        public string PageType { set; get; }
        public string ImagePath { set; get; }
        public string Description { set; get; }
        public string Link { set; get; }
        public string TitleTag { set; get; }
        public string AltTag { set; get; }
        public string Caption { set; get; }
        public string ModifyBy { set; get; }
        public string ModifyDate { set; get; }
    }
    [Serializable]
    public class TopOfferFare
    {
        public TopOfferFare(DataRow dr)
        {
            From = dr["From"].ToString();
            DestfromName = dr["DestfromName"].ToString();
            Airline_Code = dr["Airline_Code"].ToString();
            To = dr["To"].ToString();
            DesttoName = dr["DesttoName"].ToString();
            ClassType = dr["ClassType"].ToString();
            Airline_Name = dr["Airline_Name"].ToString();
            GrandTotal = string.IsNullOrEmpty(dr["GrandTotal"].ToString()) ? 0 : Convert.ToDouble(dr["GrandTotal"]);
            Continent_Name = dr["Continent_Name"].ToString();
            Travel_DateStart = dr["Travel_DateStart"].ToString();
            Travel_DateEnd = dr["Travel_DateEnd"].ToString();
            ExpOffers_Date = dr["ExpOffers_Date"].ToString();
        }
        public string From { set; get; }
        public string DestfromName { set; get; }
        public string Airline_Code { set; get; }
        public string To { set; get; }
        public string DesttoName { set; get; }
        public string ClassType { set; get; }
        public string Airline_Name { set; get; }
        public double GrandTotal { set; get; }
        public string Continent_Name { set; get; }
        public string Travel_DateStart { set; get; }
        public string Travel_DateEnd { set; get; }
        public string ExpOffers_Date { set; get; }
    }

    
}