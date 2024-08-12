using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelSite.Models;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace TravelSite.Controllers
{
    public class SearchResController : Controller
    {
        FlightSearch _objFare = new FlightSearch();
        SearchDetails _objSearch;
        string sUnique = string.Empty;
        string source = string.Empty;
        public string contactno1 = string.Empty;
        public WebsiteContactDetails WCD = null;
        public string media { set; get; }
        public string key { set; get; }
                

        public ActionResult Search()
        {
            if (Request["compid"] != null || Request["utm_source"] != null)
            {
                GoingResult();
            }
            else
            {
                //Error.RedirectError("Invalid source of redirection!");
            }
            return View();
        }

        public ActionResult SearchRes()
        {

            if (Request["campaign"] != null || Request["utm_source"] != null)
            {
                GoingResult();
            }
            else
            {
                //Error.RedirectError("Invalid source of redirection!");
            }
            return View();
        }
        private void GoingResult()
        {
            source = Request["compid"].ToString().ToLower();

            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            var url = string.Empty;

            SetSearchRequest();


            //if (_objSearch.FlightSearchDetails.flexiType)
            //    url = urlHelper.Action("ResultFlx", "ResultFlx", new { areaname = " ", q = sUnique });
            //else
                url = urlHelper.Action("FlightResult", "Result", new { areaname = " ", q = sUnique });

            Response.RedirectPermanent(url);


        }
        private void SetSearchRequest()
        {
            FlightSearchDetails.PaxDetails px = new FlightSearchDetails.PaxDetails();
            FlightSearchDetails _objSearch = new FlightSearchDetails();
            Segments _seg;
            if (Request["jtype"] == "R")
            {
                _objSearch.JourneyType = "R";
            }
            else
                _objSearch.JourneyType = "O";

            if (Request["jtype"].ToString() != "R")
            {
                _seg = new Segments();
                _seg.origin = Common.GetAirportCode(Request["from"].ToString());
                _seg.destination = Common.GetAirportCode(Request["to"].ToString());
                _seg.date = Convert.ToDateTime(Request["ddate"].ToString()).ToString("dd-MM-yyyy");
                _seg.destinationType = "A";
                _seg.originType = "A";
                _objSearch.searchId = _seg.origin + "_" + _seg.destination + "_" + Convert.ToDateTime(_seg.date).ToString("yyyy-dd-MM");
                _objSearch.segments.Add(_seg);
            }
            else
            {

                for (int i = 1; i <= 2; i++)
                {

                    if (i == 1)
                    {
                        _seg = new Segments();
                        _seg.origin = Common.GetAirportCode(Request["from"].ToString());
                        _seg.destination = Common.GetAirportCode(Request["to"].ToString());
                        _seg.date = Convert.ToDateTime(Request["ddate"].ToString()).ToString("dd-MM-yyyy");
                        _seg.originType = "A";
                        _objSearch.searchId = _seg.origin + "_" + _seg.destination + "_" + Convert.ToDateTime(_seg.date).ToString("yyyy-dd-MM");

                    }
                    else
                    {
                        _seg = new Segments();
                        _seg.origin = Common.GetAirportCode(Request["to"].ToString());
                        _seg.destination = Common.GetAirportCode(Request["from"].ToString());
                        _seg.date = Convert.ToDateTime(Request["rdate"].ToString()).ToString("dd-MM-yyyy");
                        _seg.originType = "A";

                    }
                    _seg.destinationType = "A";
                    _objSearch.segments.Add(_seg);
                }
            }
            px.adults = Convert.ToInt32(Request["adults"]);
            px.children = Convert.ToInt32(Request["children"]);
            px.infants = Convert.ToInt32(Request["infants"]);
            px.youth = 0;
            px.infantOnSeat = 0;
            _objSearch.paxDetails = px;
            //_objSearch.uid= Request["uid"].ToString();
            _objSearch.PreferedAirlines = Request["airline"].ToString();
            _objSearch.cabinClass = Request["cabinclass"];
            _objSearch.currency = "USD";
            _objSearch.fareType = "";
            _objSearch.outboundClass = "";
            _objSearch.inboundClass = "";
            _objSearch.flexiType = false;
            _objSearch.flexi = false;
            //_objSearch.gds = Request["indx"].ToString().Split('-')[1];
            _objSearch.availableFare = false;
            _objSearch.companyId = Request["compid"];
            _objSearch.customerType = "DIR";
            _objSearch.alternateAirport = false;
            _objSearch.refundableFare = false;

            sUnique = Guid.NewGuid().ToString();
            SearchDetails _SearchDtl = SearchDetails.SetCurrent(sUnique);
            _SearchDtl.ProdID = "001";
            _SearchDtl.SourceMedia = "JETCOST";


            _SearchDtl.SetCompanyDetails(_SearchDtl.SourceMedia);
            _SearchDtl.FlightSearchDetails = _objSearch;
            FlightSearch _objFlt = new FlightSearch();
            var json = new JavaScriptSerializer().Serialize(_objSearch);
            _objFlt.Httppostcallapi(json.ToString(), "http://api.faressaver.com/api/flightsearch", _objSearch.searchId, sUnique);

        }
        private string getAriportCode(string subString)
        {
            int startIndex = subString.LastIndexOf("(");
            string sub = subString.Substring(startIndex + 1);
            string FlyingFrom = sub.Substring(0, 3);
            return FlyingFrom.Trim().ToUpper();
        }
    }
}