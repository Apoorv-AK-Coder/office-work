using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using TravelSite.Models;
using TravelSite.ViewModels;
using System.Data;
using System.Text;
using System.Web.Caching;
using System.Web.Script.Serialization;

namespace TravelSite.Controllers
{
    public class HomeController : Controller
    {
        HomeBanner ObjHB = new HomeBanner();
        Cache cache = HttpRuntime.Cache;
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index()
        {
            // WebsiteContactDetails WCD;
            string SrcMedia = string.Empty;
            string key = string.Empty;
            if (Request.RawUrl.IndexOf("__sourceMedia") != -1)
            {
                SrcMedia = Request.RawUrl.Substring(Request.RawUrl.IndexOf("__sourceMedia")).Split('&')[0];
                SrcMedia = SrcMedia.Split('=')[1];
                if (Request.RawUrl.IndexOf("key") != -1)
                {
                    key = Request.RawUrl.Substring(Request.RawUrl.IndexOf("key")).Split('&')[0];
                    key = key.Split('=')[1];
                }
                else
                {
                    key = "";
                }
            }
            else
            {
                //SrcMedia = "";
            }

            HttpCookie cookie = Request.Cookies["search"];
            if (cookie != null)
            {
                ObjHB.destfrom = cookie["DestFrom"];
                ObjHB.destto = cookie["DestTo"];
                ObjHB.fromdate = cookie["fromdate"];
                ObjHB.todate = cookie["todate"];
                ObjHB.adult = cookie["Adult"];
                ObjHB.child = cookie["Child"];
                ObjHB.infant = cookie["Infant"];
                ObjHB.triptype = cookie["TripType"];
            }

            ObjHB.Domain = CompCredentials.Domain;
            //WCD = new WebsiteContactDetails(Request["__sourceMedia"] != null ? Request["__sourceMedia"] : SrcMedia, Request["key"] != null ? Request["key"] : key);
            ObjHB.ContactNo1 = WebsiteStaticData.ContactNo1;
            ObjHB.ContactNo2 = WebsiteStaticData.ContactNo2;
            ObjHB.ContactNo = WebsiteStaticData.ContactNo1;
            TempData["PhoneNumber"] = WebsiteStaticData.ContactNo1;
            TempData["ContactNo1"] = WebsiteStaticData.ContactNo1;
            TempData["ContactNo2"] = WebsiteStaticData.ContactNo2;

            //TimeSpan start = new TimeSpan(08, 30, 0); //10 o'clock
            //TimeSpan end = new TimeSpan(23, 30, 0); //12 o'clock
            //TimeSpan now = DateTime.Now.TimeOfDay;
            //if ((now > start) && (now < end))
            //    TempData["Time"] = "true";
            //else
            //    TempData["Time"] = "false";
            //ObjHB.Banner = BindHomeOffer();

            DeleteFiles();
            return View(ObjHB);
        }

        public void DeleteFiles()
        {
            FlightSearch.DeleteFiles(Server.MapPath(@"~/App_Data/Response"));
        }

        public PartialViewResult _SearchEngineHome()
        {
            return PartialView();
        }

        [WaitActionFilter]
        [HttpPost]
        public ActionResult _SearchEngineHome(FormCollection frmV)
        {
            SearchDetails _objSearch;
            if (HttpContext.Session.Count > 0)
            {
                for (int i = HttpContext.Session.Count; i > 0; i--)
                {
                    if (HttpContext.Session.Keys[i - 1].IndexOf("SearchParam#") != -1)
                    {
                        _objSearch = SearchDetails.Current(HttpContext.Session.Keys[i - 1].Split('#')[1]);
                        ViewBag.__sourceMedia = _objSearch.SourceMedia;
                        ViewBag.code = _objSearch.SourceMedia;
                        ViewBag.key = _objSearch.key;
                        break;
                    }
                }
            }
            else
            {
                ViewBag.__sourceMedia = "";
                ViewBag.code = "";
                ViewBag.key = "";
            }
            try
            {
                if (frmV != null)
                {
                   
                    //FlightFareSearchRQ _SearchRQ = new FlightFareSearchRQ();
                    FlightSearchDetails ObjSearch = new FlightSearchDetails();
                    FlightSearchDetails.PaxDetails px = new FlightSearchDetails.PaxDetails();
                    Segments _seg;

                    if (frmV["return"] != null && frmV["return"].ToString() == "Return")
                    {
                        if (frmV["hfTripType"] == "true")
                        {
                            ObjSearch.JourneyType = "R";
                        }
                        else
                            ObjSearch.JourneyType = "O";
                        for (int i = 1; i <= 2; i++)
                        {
                            if (i == 1)
                            {
                                _seg = new Segments();
                                _seg.origin = Common.GetAirportCode(frmV["flying_from"].ToString());
                                _seg.destination = Common.GetAirportCode(frmV["flying_to"].ToString());
                                _seg.date = Convert.ToDateTime(frmV["from"].ToString()).ToString("dd-MM-yyyy");                               
                                _seg.originType = "A";
                                ObjSearch.searchId = _seg.origin + "_"+ _seg.destination + "_"+ Convert.ToDateTime(_seg.date).ToString("yyyy-dd-MM") ;
                            }
                            else
                            {
                                _seg = new Segments();
                                _seg.origin = Common.GetAirportCode(frmV["flying_to"].ToString());
                                _seg.destination = Common.GetAirportCode(frmV["flying_from"].ToString());
                                _seg.date = Convert.ToDateTime(frmV["to"].ToString()).ToString("dd-MM-yyyy");                               
                                _seg.originType = "A";
                            }                            
                            _seg.destinationType = "A";                           
                            ObjSearch.segments.Add(_seg);
                        }
                    }
                    else
                    {
                        ObjSearch.JourneyType = "O";
                        _seg = new Segments();                        
                        _seg.origin = Common.GetAirportCode(frmV["flying_from"].ToString());
                        _seg.destination = Common.GetAirportCode(frmV["flying_to"].ToString());
                        _seg.date = Convert.ToDateTime(frmV["from"].ToString()).ToString("dd-MM-yyyy");                        
                        _seg.destinationType = "A";
                        _seg.originType = "A";
                        ObjSearch.searchId = _seg.origin + "_" + _seg.destination + "_" + Convert.ToDateTime(_seg.date).ToString("yyyy-dd-MM");
                        ObjSearch.segments.Add(_seg);
                    }
                    try
                    {
                        HttpCookie cookie = new HttpCookie("Search");
                        cookie.Values.Add("DestFrom", frmV["flying_from"].ToString());
                        cookie.Values.Add("DestTo", frmV["flying_to"].ToString());
                        cookie.Values.Add("fromdate", frmV["from"].ToString());
                        if (frmV["return"] == "Return")
                        {
                            cookie.Values.Add("todate", frmV["to"].ToString());
                        }
                        cookie.Values.Add("Adult", frmV["Adult"].ToString().Trim());
                        cookie.Values.Add("Child", frmV["Children"].ToString().Trim());
                        cookie.Values.Add("Infant", frmV["Infant"].ToString().Trim());
                        cookie.Values.Add("TripType", frmV["hfTripType"]);
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                    }
                    catch { }
                    px.adults= Convert.ToInt32(frmV["Adult"].ToString().Trim());
                    px.children = Convert.ToInt32(frmV["Children"].ToString().Trim());
                    px.infants = Convert.ToInt32(frmV["Infant"].ToString().Trim());
                    px.youth = 0;
                    px.infantOnSeat = 0;
                    ObjSearch.paxDetails= px;

                   
                   // ObjSearch.PreferedAirlines = frmV["airline"].ToString();
                  //  ObjSearch.preferedAirline = frmV["airline"].ToString();
                    ObjSearch.cabinClass = frmV["CabinClass"].ToString();
                    ObjSearch.currency = "USD";
                    ObjSearch.fareType = "";
                    ObjSearch.outboundClass = "";
                    ObjSearch.inboundClass = "";
                    ObjSearch.flexiType = false;
                    ObjSearch.flexi = false;
                    ObjSearch.gds = "1A";
                    ObjSearch.availableFare = false;
                    ObjSearch.companyId = "FS";
                    ObjSearch.customerType = "DIR";
                    ObjSearch.alternateAirport = false;
                    ObjSearch.refundableFare = false;




                    string sUnique = Guid.NewGuid().ToString();
                    SearchDetails _SearchDtl = SearchDetails.SetCurrent(sUnique);
                    _SearchDtl.ProdID = "001";
                    _SearchDtl.SourceMedia = ViewBag.__sourceMedia;
                    try
                    {
                        _SearchDtl.key = ViewBag.key;
                        _SearchDtl.code = ViewBag.code;
                    }
                    catch
                    {
                        _SearchDtl.key = "";
                        _SearchDtl.code = "";
                    }
                   
                    _SearchDtl.SetCompanyDetails(_SearchDtl.SourceMedia);                    
                    _SearchDtl.FlightSearchDetails = ObjSearch;
                    FlightSearch _objFlt = new FlightSearch();
                    var json = new JavaScriptSerializer().Serialize(ObjSearch); // http://localhost:52113/
                    //_objFlt.Httppostcallapi(json.ToString(), "http://localhost:52113/api/flightsearch", ObjSearch.searchId, sUnique);
                    _objFlt.Httppostcallapi(json.ToString(), "http://api1.faressaver.com/api/flightsearch", ObjSearch.searchId, sUnique);                   
                    return RedirectToAction("FlightResult", "Result", new { q = sUnique });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Common");
            }
        }

        private string BindHomeOffer()
        {
            string str = string.Empty;
            try
            {
                //DataTable dt1 = Common.GetHomeAirlineFares("Economy", "Home", CompCredentials.Domain.ToUpper(), CompCredentials.CompanyId);
                DataTable dt = Common.GetHomeTopDestination(CompCredentials.Currency, CompCredentials.Domain.ToUpper(), CompCredentials.CompanyId);

                string TopDest = string.Empty;
                string TopRoutes = string.Empty;
                int i = 0;
                string[] Destarr = new string[100];
                string temp = string.Empty;
                DataView dv = dt.DefaultView;
                dv.Sort = "Grandtotal asc";
                DataTable sortedDT = dv.ToTable();
                foreach (DataRow item in sortedDT.Rows)
                {
                    string CityName = item["City_Name"].ToString();
                    string ToCityName = item["ToCity_Name"].ToString();
                    string from = CityName + "(" + item["DepFrom"].ToString() + ")";
                    string to = ToCityName + "(" + item["DepTo"].ToString() + ")";

                    if (!temp.Contains(CityName))
                    {
                        if (i < 10)
                        {
                            string qs = "SearchRes.aspx?depCity=" + item["DepFrom"] + "&arrCity=" + item["DepTo"] + "&depDate=" + Convert.ToDateTime(item["FromDate"]).ToString("dd/MM/yyyy") + "&arrDate=" + Convert.ToDateTime(item["FromDate"]).AddDays(7).ToString("dd/MM/yyyy") + "&adult=" + item["NoAdult"] + "&child=" + item["NoChild"] + "&infant=" + item["NoInfant"] + "&CabinClass=" + item["CabinClass"] + "&dateFlex=true&AirCode=ALL&source=" + CompCredentials.CompanyId + "&utm_source=" + CompCredentials.CompanyId + "&DFlights=false&JType=2&ref=&from=" + from + "&to=" + to;
                            TopDest += "<li><font>" + ToCityName + " </font><a href='" + qs + "' onclick='Progressing_FS()' class='btn_yellow'>Book Now </a><strong><span></span>" + CompCredentials.Currency_Symbol + Convert.ToDouble(item["Grandtotal"]).ToString("f2") + "</strong>  </li>";
                        }
                        else
                        {
                            string qs = "SearchRes.aspx?depCity=" + item["DepFrom"] + "&arrCity=" + item["DepTo"] + "&depDate=" + Convert.ToDateTime(item["FromDate"]).ToString("dd/MM/yyyy") + "&arrDate=" + Convert.ToDateTime(item["FromDate"]).AddDays(7).ToString("dd/MM/yyyy") + "&adult=" + item["NoAdult"] + "&child=" + item["NoChild"] + "&infant=" + item["NoInfant"] + "&CabinClass=" + item["CabinClass"] + "&dateFlex=true&AirCode=ALL&source=" + CompCredentials.CompanyId + "&utm_source=" + CompCredentials.CompanyId + "&DFlights=false&JType=2&ref=&from=" + from + "&to=" + to;
                            TopRoutes += "<li><font>" + CityName + " - " + ToCityName + "</font> <a href='" + qs + "' onclick='Progressing_FS()' class='btn_yellow'>Book Now </a><strong><span></span>" + CompCredentials.Currency_Symbol + Convert.ToDouble(item["Grandtotal"]).ToString("f2") + "</strong>  </li>";
                        }
                        i++;
                        temp += CityName + ",";
                    }
                }
                ObjHB.TopDest = TopDest;
                ObjHB.TopRoutes = TopRoutes;
                return str.ToString();
            }
            catch
            {

            }
            return str.ToString();
        }

        private string BindBlog()
        {
            GetSetOffer ObjOff = new GetSetOffer();
            List<RecentBlogM> _rcntBlgs = new List<RecentBlogM>();
            StringBuilder sb = new StringBuilder();

            DataTable dt1 = new DataTable();
            try
            {
                dt1 = (DataTable)cache["dsblog"];
            }
            catch { }
            DataTable dt = new DataTable();
            if (dt1 == null)
            {
                dt = ObjOff.GetBlogContent_DS();
            }

            if (dt.Rows.Count > 0)
            {
                if (dt1 == null)
                {
                    cache.Insert("dsblog", dt, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 120, 0));
                }
            }

            if (dt1 != null)
            {
                dt = dt1;
            }

            try
            {

                sb.Append(" <div id='slider'>" +
                    "<a class='control_next'><i class='fa fa-angle-right'></i></a>" +
                    "<a class='control_prev'><i class='fa fa-angle-left'></i></a>" +
                    "<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string str = "//blog.Faressaver.com/" + dt.Rows[i]["subblgheader_v"].ToString().Trim().Replace(' ', '-') + "/" + dt.Rows[i]["blgheading_v"].ToString().Trim().Replace(' ', '-');
                    sb.Append("<li>" +
                               " <div class='blog-data'>" +
                                    "<a href='" + str + "'><img style='height: 139px;width: 323px;' src='" + dt.Rows[i]["imageurl"].ToString().Replace("http://", "//www.") + "' alt='" + dt.Rows[i]["imageurl"].ToString().Replace("http://", "//www.") + "'/></a>" +
                                  "<span class='blog-big'><a href='" + str + "'><span class='blog-big'>" + dt.Rows[i]["blgheading_v"] + "</span></a></span>" +
                                    " <br />" +
                                   " <span class='blog-small'><i class='fa fa-list'></i>&nbsp;Travel Post  |  " + Convert.ToDateTime(dt.Rows[i]["blgcontentcreated_date_d"]).ToString("ddd dd MMM, yyyy") + "</span>" +
                                   " <span class='blog-small'>" + dt.Rows[i]["summary"].ToString().Substring(0, 50) + " ...</span>" +
                                   "<a class='readmore-blog' href='" + str + "'>Read more</a>" +
                                    "<span style='margin: 5px 0 4px 8px; float: left;'><i class='fa fa-comment' style='color: #c32d6c;'></i><span class='date-blog'>15</span>&nbsp; <i class='fa fa-heart' style='color: #c32d6c;'></i><span class='date-blog'>225</span></span>" +
                                   " <div class='social-icons icon-circle' style='margin-right: 57px;'>" +
                                        "<span><a href='//www.facebook.com/Faressaver'><i class='fa fa-facebook'></i></a></span>" +
                                        "<span><a href='//plus.google.com/+Faressaver/posts'><i class='fa fa-google-plus'></i></a></span>" +
                                        "<span><a href='#'><i class='fa fa-linkedin'></i></a></span>" +
                                        "<span><a href='//twitter.com/Faressaver'><i class='fa fa-twitter'></i></a></span>" +

                                    "</div>" +
                                "</div>" +
                            "</li>");
                }
                sb.Append("</ul></div>");
            }
            catch { }
            return sb.ToString();
        }

        public class RecentBlogM
        {
            public string blgcontent_id_n { get; set; }
            public string blgheading_v { get; set; }
            public string subblgheader_v { get; set; }
            public string subblgheadre_id_n { get; set; }
        }


        [Route("~/about/")]
        public ActionResult AboutUs()
        {
            return View();
        }

        [Route("~/contact/")]
        public ActionResult contactus()
        {
            return View();
        }


        [Route("~/privacy-policy/")]
        public ActionResult privacypolicy()
        {
            return View();
        }


        [Route("~/refund-policy/")]
        public ActionResult refundpolicy()
        {
            return View();
        }


        [Route("~/terms-conditions/")]
        public ActionResult termsconditions()
        {
            return View();
        }
    }
}