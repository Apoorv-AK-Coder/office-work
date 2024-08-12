using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web;



namespace TravelSite.Models
{
    public class GetDataOffer
    {
        Cache cache = HttpRuntime.Cache;
        GetSetOfferDAL GetSetOfferDAL = new GetSetOfferDAL();

        public GetDataOffer()
        {

        }
        public HomePageTopOffer GetHomePageTopBanner(HomePageOffer HPO)
        {
            DataSet ds = GetSetOfferDAL.GETHomePageOffer(HPO);
            HomePageTopOffer HomePageTopOffer = new HomePageTopOffer(ds);
            return HomePageTopOffer;
        }

        public List<TopOfferFare> GETHomePageOnlyOffer(HomePageOffer HPO)
        {
            DataTable dt = GetSetOfferDAL.GETHomePageOnlyOffer(HPO);
            List<TopOfferFare> TopOfferFare = new List<TopOfferFare>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TopOfferFare.Add(new TopOfferFare(dr));
                }
            }
            return TopOfferFare;
        }



        public List<BannerUpload> GetSearch_Bannner(HomePageOffer HPO)
        {
            DataTable dt = GetSetOfferDAL.GETHomePageOnlyOffer(HPO);
            List<BannerUpload> BannerUpload = new List<BannerUpload>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BannerUpload.Add(new BannerUpload(dr));
                }
            }
            return BannerUpload;
        }

        public List<FlightFareDestination> GetOfflineFaresFlightDestination(FlightOfferRequest FOReq)
        {
            DataTable dt = GetSetOfferDAL.GetOfflineFaresFlightDestination(FOReq);
            List<FlightFareDestination> FlightFareDestination = new List<FlightFareDestination>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightFareDestination.Add(new FlightFareDestination(dr));
                }
            }
            return FlightFareDestination;
        }


        public List<FlightFareDestination> GetFaresFlightDestination(FlightOfferRequest FOReq)
        {
            DataTable dt = GetSetOfferDAL.GetFaresFlightDestination(FOReq);
            List<FlightFareDestination> FlightFareDestination = new List<FlightFareDestination>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightFareDestination.Add(new FlightFareDestination(dr));
                }
            }
            return FlightFareDestination;
        }

        public List<FlightFareDestination> GetFaresFlightDestination1(FlightOfferRequest FOReq)
        {


            DataTable dt1 = new DataTable();
            try
            {
                dt1 = (DataTable)cache[FOReq.DestFrom + FOReq.DestTo];
            }
            catch { }
            DataTable dt = new DataTable();
            if (dt1 == null)
            {
                dt = GetSetOfferDAL.GetFaresFlightDestination(FOReq);
            }


            if (dt.Rows.Count > 0)
            {
                if (dt1 == null)
                {
                    cache.Insert(FOReq.DestFrom + FOReq.DestTo, dt, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 120, 0));
                }
            }

            if (dt1 != null)
            {
                dt = dt1;
            }
            List<FlightFareDestination> FlightFareDestination = new List<FlightFareDestination>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightFareDestination.Add(new FlightFareDestination(dr));
                }
            }
            return FlightFareDestination;
        }
        public List<ContantHeading> GetContents(ContantHeadingReq CHeading)
        {
            DataTable dt = GetSetOfferDAL.GetContents(CHeading);
            List<ContantHeading> ContantHeading = new List<ContantHeading>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ContantHeading.Add(new ContantHeading(dr));
                }
            }
            return ContantHeading;
        }
        public List<TitleAndMeta> GetTitleAndMeta(ContantHeadingReq CHeading)
        {
            DataTable dt = GetSetOfferDAL.GetContents(CHeading);
            List<TitleAndMeta> TitleAndMeta = new List<TitleAndMeta>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TitleAndMeta.Add(new TitleAndMeta(dr));
                }
            }
            return TitleAndMeta;
        }
        public bool SetFareQuotes(FareQuotesDetails FQDetails)
        {
            GetSetOfferDAL GetSetOfferDAL = new GetSetOfferDAL();
            return GetSetOfferDAL.SetFareQuotes(FQDetails);
        }
    }
}
