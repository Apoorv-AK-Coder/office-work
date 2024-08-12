using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using TravelSite.Models;
using MoreLinq;

namespace TravelSite.Controllers
{
    public class ResultController : Controller
    {
        PhoneNumber _phn = new PhoneNumber();
        string q = string.Empty;
        public string strResultDetials = string.Empty;
        public string strFilterPricing = string.Empty;
        SearchDetails _objSearch;
        Flight ObjFlt = new Flight();
        string[] list;

        public WebsiteContactDetails WCD = null;
        public string media { set; get; }
        public string key { set; get; }
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult FlightResult(string q)
        {
            try
            {
                if (!string.IsNullOrEmpty(q))
                {
                    //string Test = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                    _objSearch = SearchDetails.Current(Request["q"]);

                    ObjFlt.depdate = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("ddd dd MMM yyyy");
                    ObjFlt.retdate = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("ddd dd MMM yyyy") : "";
                    ObjFlt.from2 = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("dd MMM");
                    ObjFlt.to2 = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("dd MMM") : "";
                    ObjFlt.from1 = _objSearch.FlightSearchDetails.segments[0].origin.ToString();
                    ObjFlt.to1 = _objSearch.FlightSearchDetails.segments[0].destination.ToString();
                    ObjFlt.adult = _objSearch.FlightSearchDetails.paxDetails.adults;
                    ObjFlt.child = _objSearch.FlightSearchDetails.paxDetails.children;
                    ObjFlt.infant = _objSearch.FlightSearchDetails.paxDetails.infants;
                    ObjFlt.DestCode = _objSearch.FlightSearchDetails.segments[0].destination.ToString();
                    ObjFlt.ContactNo1 = "866-699-8919";
                    //try
                    //{
                    //    media = Request["__sourceMedia"];
                    //    key = Request["key"];
                    //    WCD = new WebsiteContactDetails(Request["__sourceMedia"] != null ? Request["__sourceMedia"] : media, Request["key"] != null ? Request["key"] : key);
                    //    ObjFlt.ContactNo1 = WCD.ContactNo1;
                    //}
                    //catch
                    //{
                    //    ObjFlt.ContactNo1 = "866-699-8919";
                    //}

                    ObjFlt.url = RefreshResult(q);
                    string ss = string.Empty;

                    if (ObjFlt.adult != 0)
                    {
                        ss = ObjFlt.adult + "Adult";
                    }
                    if (ObjFlt.child != 0)
                    {
                        ss += "," + ObjFlt.child + "Child";
                    }
                    if (ObjFlt.infant != 0)
                    {
                        ss += "," + ObjFlt.infant + "Infant";
                    }
                    ObjFlt.travel = ss;
                    ObjFlt.type = _objSearch.FlightSearchDetails.JourneyType.ToString();
                    if (_objSearch != null)
                    {
                        FlightSearch objSearchFare = new FlightSearch();
                        Itineraries Iten = new Itineraries();
                        ObjFlt.unique = Request["q"];
                        try
                        {
                            Iten = objSearchFare.GetItinerariesNew(Request["q"]);                                                       
                        }
                        catch(Exception ex)
                        {
                             Iten = objSearchFare.GetItinerariesNew(Request["q"]);
                        }                    
                        
                        
                        if (Iten != null && Iten.Items != null && Iten.Items.Count > 0)
                        {
                            ObjFlt.Items = Iten.Items; //.DistinctBy(m => new { m.ValCarrier, m.GrandTotal }).ToList();
                            ObjFlt.Count = Iten.Items.Count;
                            CompCredentials.SetCurrencySymbol(Iten.Items[0].Currency);
                            ObjFlt.Currency = CompCredentials.Currency_Symbol;
                            ObjFlt.SourceMedia = CompCredentials.SourceMedia;
                            BindFilter(ObjFlt.Items, ref ObjFlt);
                            
                        }
                        else
                        {
                            ObjFlt.Response = "<div class='sry_box'><div class='inner'> <p><strong>Sorry</strong>, there are no flights available on " + Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("dddd dd MMM yyyy") + ". You can </p><ul><li>Check +/- 3 days <a id='divModyfi3' style='cursor:pointer;' onclick='showmodify()'>flexible</a> search</li><li>Use <a style='cursor:pointer;' id='divModyfi4' onclick='showmodify()'>modify search</a> to check availability on another date</li><li>You can speak to our flight expert on <a href='tel:</a> </li></ul> <div class='clearfix'></div></div></div>";
                        }
                    }
                    else
                    {
                        Error.RedirectError("Your Session has been expired!");
                    }
                    // ********* END HERE ****************
                }
                else
                {
                    TempData["PhoneNumber"] = _phn.PhoneNumber1;
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorPage", "Common");
            }
            return View(ObjFlt);
        }
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult AlternateResult(string q)
        {
            try
            {
                if (!string.IsNullOrEmpty(q))
                {
                    //string Test = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                    string AirlineCode = Request["q"].ToString().Split('~')[1];
                    string Unique = Request["q"].ToString().Split('~')[0];
                    string GrandTotal= Request["q"].ToString().Split('~')[2];
                    _objSearch = SearchDetails.Current(Unique);

                    ObjFlt.depdate = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("ddd dd MMM yyyy");
                    ObjFlt.retdate = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("ddd dd MMM yyyy") : "";
                    ObjFlt.from2 = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("dd MMM");
                    ObjFlt.to2 = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("dd MMM") : "";
                    ObjFlt.from1 = _objSearch.FlightSearchDetails.segments[0].origin.ToString();
                    ObjFlt.to1 = _objSearch.FlightSearchDetails.segments[0].destination.ToString();
                    ObjFlt.adult = _objSearch.FlightSearchDetails.paxDetails.adults;
                    ObjFlt.child = _objSearch.FlightSearchDetails.paxDetails.children;
                    ObjFlt.infant = _objSearch.FlightSearchDetails.paxDetails.infants;
                    ObjFlt.DestCode = _objSearch.FlightSearchDetails.segments[0].destination.ToString();
                    try
                    {
                        media = Request["__sourceMedia"];
                        key = Request["key"];
                        WCD = new WebsiteContactDetails(Request["__sourceMedia"] != null ? Request["__sourceMedia"] : media, Request["key"] != null ? Request["key"] : key);
                        ObjFlt.ContactNo1 = WCD.ContactNo1;
                    }
                    catch
                    {
                        ObjFlt.ContactNo1 = "866-699-8919";
                    }

                    ObjFlt.url = RefreshResult(q);
                    string ss = string.Empty;

                    if (ObjFlt.adult != 0)
                    {
                        ss = ObjFlt.adult + "Adult";
                    }

                    if (ObjFlt.child != 0)
                    {
                        ss += "," + ObjFlt.child + "Child";
                    }
                    if (ObjFlt.infant != 0)
                    {
                        ss += "," + ObjFlt.infant + "Infant";
                    }

                    ObjFlt.travel = ss;

                    ObjFlt.type = _objSearch.FlightSearchDetails.JourneyType.ToString();
                    if (_objSearch != null)
                    {
                        FlightSearch objSearchFare = new FlightSearch();
                        ObjFlt.unique = Unique;//  Request["q"];
                        //RefreshResult();
                        Itineraries Iten = objSearchFare.GetItinerariesNew(Unique);

                        if (Iten != null && Iten.Items != null && Iten.Items.Count > 0)
                        {
                            ObjFlt.Items = Iten.Items.Where(o => (o.ValCarrier == AirlineCode) && (o.GrandTotal== Convert.ToDouble(GrandTotal))).ToList();
                            ObjFlt.Count = ObjFlt.Items.Count;
                            CompCredentials.SetCurrencySymbol(ObjFlt.Items[0].Currency);
                            ObjFlt.Currency = CompCredentials.Currency_Symbol;
                            ObjFlt.SourceMedia = CompCredentials.SourceMedia;
                            BindFilter(ObjFlt.Items, ref ObjFlt);
                            //Tracker.SavePageTracking(Iten.Items[0], System.Web.HttpContext.Current, _objSearch.CompanyName, _objSearch.RedirectFrom, "", _objSearch.FlightSearchDetails.CabinClass, string.Empty);
                        }
                        else
                        {
                            ObjFlt.Response = "<div class='sry_box'><div class='inner'> <p><strong>Sorry</strong>, there are no flights available on " + Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("dddd dd MMM yyyy") + ". You can </p><ul><li>Check +/- 3 days <a id='divModyfi3' style='cursor:pointer;' onclick='showmodify()'>flexible</a> search</li><li>Use <a style='cursor:pointer;' id='divModyfi4' onclick='showmodify()'>modify search</a> to check availability on another date</li><li>You can speak to our flight expert on <a href='tel:" + WCD.ContactNo1 + "'>" + WCD.ContactNo1 + "</a> </li></ul> <div class='clearfix'></div></div></div>";
                        }
                    }
                    else
                    {
                        Error.RedirectError("Your Session has been expired!");
                    }
                    // ********* END HERE ****************
                }
                else
                {
                    TempData["PhoneNumber"] = _phn.PhoneNumber1;
                }
            }
            catch
            {
                return RedirectToAction("ErrorPage", "Common");
            }
            return View(ObjFlt);
        }

        private void BindFilter(List<Itinerary> _Items, ref Flight ObjFlt)
        {
            List<filter1> Filter = new List<filter1>();
            int cal_duration = 0;
            int NoPax = 0;
            NoPax = ObjFlt.adult + ObjFlt.child;
            ObjFlt.mincost = _Items[0].GrandTotal;
            ObjFlt.maxcost = _Items[_Items.Count - 1].GrandTotal;

            for (int i = 0; i < _Items.Count; i++)
            {
                List<Sector> SectorDept = new List<Sector>();
                List<Sector> SectorRet = new List<Sector>();
                for (int j = 0; j < _Items[i].Sectors.Count; j++)
                {
                    if (_Items[i].Sectors[j].IsReturn == false)
                        SectorDept.Add(_Items[i].Sectors[j]);
                    else
                        SectorRet.Add(_Items[i].Sectors[j]);
                }
                cal_duration = Convert.ToInt32(SectorDept[SectorDept.Count - 1].ActualTime.Replace(":", "")) + Convert.ToInt32(SectorRet.Count > 0 ? SectorRet[SectorRet.Count - 1].ActualTime.Replace(":", "") : "0");
                List<Itinerary> ss = _Items;
                Filter.Add(new filter1(_Items[i].IndexNumber.ToString(), _Items[i].Provider, SectorDept[0].AirV, SectorDept[0].AirlineName,
                             (SectorDept.Count > SectorRet.Count ? SectorDept.Count : SectorRet.Count),
                             SectorDept[0].Departure.AirportCode, (SectorRet.Count > 0 ? SectorDept[0].Departure.AirportCode : ""), SectorDept[0].Departure.Time,
                             (SectorRet.Count > 0 ? SectorDept[0].Departure.Time : ""), Convert.ToDouble(_Items[i].GrandTotal / NoPax), cal_duration)); //Adult.AdtBFare + _Items[i].Adult.AdTax) / _Items[i].Adult.NoOfAdult
            }
            #region Bind Filter

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            ObjFlt.filterdata = javaScriptSerializer.Serialize(Filter);
            //strHtmResult += "<input id='hfFilterData' type='hidden' value='" + javaScriptSerializer.Serialize(Filter) + "'/>";
            List<double> d = (from filter1 i in Filter
                              where i.Stop == 1
                              select i.GrandTotal).ToList();
            string stop1 = d.Count > 0 ? CompCredentials.Currency_Symbol + d.Min().ToString("f2") : "NoFare";

            ObjFlt.stop1 = stop1;

            //Sb.Append("<input id='span1Stop' type='hidden' value='" + stop1 + "'/>");
            List<double> d2 = (from filter1 i in Filter
                               where i.Stop == 2
                               select i.GrandTotal).ToList();
            string stop2 = d2.Count > 0 ? CompCredentials.Currency_Symbol + d2.Min().ToString("f2") : "NoFare";
            //Sb.Append("<input id='span2Stop' type='hidden' value='" + stop2 + "'/>");
            ObjFlt.stop2 = stop2;

            List<double> d3 = (from filter1 i in Filter
                               where i.Stop > 2
                               select i.GrandTotal).ToList();
            string stop3 = d3.Count > 0 ? CompCredentials.Currency_Symbol + d3.Min().ToString("f2") : "NoFare";

            ObjFlt.stop3 = stop3;
            //Sb.Append("<input id='span3Stop' type='hidden' value='" + stop3 + "'/>");

            string[] arrDept = (from filter1 i in Filter
                                select i.DAirp).ToList().Distinct().ToArray();
            string strDepHtml = string.Empty;
            foreach (string s in arrDept)
            {
                List<double> gtot = (from filter1 i in Filter
                                     where i.DAirp == s
                                     select i.GrandTotal).ToList();
                strDepHtml += "<div class='frow1'>" +
                                "<span class='s1'><input name='' type='checkbox' id='Chk" + s + "' type='checkbox' onchange='MasterFiltering();'   checked='checked' />" + s + "</span>" +
                                "<span class='only_clik only'><span onclick='MasterFilteringDepartOnly(\"" + s + "\")'>only</span></span><span class='s1 pull-right'>" + CompCredentials.Currency_Symbol + (gtot.Count > 0 ? gtot.Min().ToString("f2") : "NoFare") + "</span></div>";
            }
            ObjFlt.airport = strDepHtml;
            if (true)
            {
                string[] arrArv = (from filter1 i in Filter
                                   select i.AirV).ToList().Distinct().ToArray();
                strDepHtml = string.Empty;
                foreach (string s in arrArv)
                {
                    List<filter1> gtot = (from filter1 i in Filter
                                          where i.AirV == s
                                          select i).ToList();
                    if (gtot.Count > 0)
                    {
                        strDepHtml += "<div class='frow1'>" +
                            "<span class='s1'><input name='' type='checkbox' value='' id='Chk" + s + "' type='checkbox' onchange='MasterFiltering();' checked='checked' /><span id='Chk" + s + "' type='checkbox' onclick='CheckAirline(\"" + s + "\");' style='cursor:pointer;'>" + (gtot.Count > 0 ? gtot[0].AirLineName : "") + "</span></span>" +
                            "<span class='only_clik only' onclick='MasterFilteringAirOnly(\"" + s + "\")'><span >only</span></span><span class='pull-right'>" + CompCredentials.Currency_Symbol + (gtot.Count > 0 ? gtot[0].GrandTotal.ToString("f2") : "0") + "</span></div>";
                    }
                }
                ObjFlt.airline = "<div class='frow1'><a onclick='MasterFilteringSelectAll()' class='fil_select_all'>Select All</a></div>" + strDepHtml;

            }
            #endregion

        }

        public class filter1
        {
            public filter1(string _IndexNumber, string _Provider, string _AirV, string _AirLineName, int _Stop, string _DAirp, string _RAirP, string _DTime,
            string _RTime, double _GrandTotal, int _ShortDuration)
            {
                IndexNumber = _IndexNumber;
                Provider = _Provider;
                AirV = _AirV;
                AirLineName = _AirLineName;
                Stop = _Stop;
                //RStop = _RStop;
                DAirp = _DAirp;
                RAirP = _RAirP;
                DTime = _DTime;
                RTime = _RTime;
                GrandTotal = _GrandTotal;
                ShortDuration = _ShortDuration;
            }
            public string IndexNumber { set; get; }
            public string Provider { set; get; }
            public string AirV { set; get; }
            public string AirLineName { set; get; }
            public int Stop { set; get; }
            //public string RStop { set; get; }
            public string DAirp { set; get; }
            public string RAirP { set; get; }
            public string DTime { set; get; }
            public string RTime { set; get; }
            public double GrandTotal { set; get; }
            public int ShortDuration { set; get; }
        }
        [ChildActionOnly]
        public PartialViewResult _ModifySearch()
        {
            FlightInner fltinner = new FlightInner();
            try
            {
                _objSearch = SearchDetails.Current(Request["q"].ToString().Split('~')[0]);
                fltinner.depdate = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("dd/MM/yyyy");
                fltinner.retdate = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("dd/MM/yyyy") : "";

                fltinner.from1 = _objSearch.FlightSearchDetails.segments[0].origin.ToString();
                fltinner.to1 = _objSearch.FlightSearchDetails.segments[0].destination.ToString();
                fltinner.adult = _objSearch.FlightSearchDetails.paxDetails.adults;
                fltinner.child = _objSearch.FlightSearchDetails.paxDetails.children;
                fltinner.infant = _objSearch.FlightSearchDetails.paxDetails.infants;
                fltinner.cabinclass = _objSearch.FlightSearchDetails.cabinClass;
                fltinner.airline = (_objSearch.FlightSearchDetails.PreferedAirlines.ToLower() == "all" ? "Any Airline" : _objSearch.FlightSearchDetails.PreferedAirlines);
                fltinner.nonstop = _objSearch.FlightSearchDetails.directFlight;
                fltinner.flexi = _objSearch.FlightSearchDetails.flexi;
                if (_objSearch.FlightSearchDetails.JourneyType == "R")
                    fltinner.triptype = "true";
                else
                    fltinner.triptype = "false";
            }
            catch { }
            return PartialView(fltinner);
        }
        [HttpPost]
        public ActionResult _ModifySearch(FormCollection frmV)
        {
            SearchDetails _objSearch;// = SearchDetailsBLL.Current(Request["q"]);
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
                    FlightSearchDetails ObjSearch = new FlightSearchDetails();
                    FlightSearchDetails.PaxDetails px = new FlightSearchDetails.PaxDetails();
                    Segments _seg;
                    if (frmV["return"] != null && frmV["return"].ToString() == "Return")
                    {
                        ObjSearch.JourneyType = "R";
                        for (int i = 1; i <= 2; i++)
                        {
                            if (i == 1)
                            {
                                _seg = new Segments();
                                _seg.origin = Common.GetAirportCode(frmV["flying_from"].ToString());
                                _seg.destination = Common.GetAirportCode(frmV["flying_to"].ToString());
                                _seg.date = Convert.ToDateTime(frmV["hffromdate"].ToString()).ToString("dd-MM-yyyy");
                                _seg.originType = "A";
                                ObjSearch.searchId = _seg.origin + "_" + _seg.destination + "_" + Convert.ToDateTime(_seg.date).ToString("yyyy-dd-MM");
                            }
                            else
                            {
                                _seg = new Segments();
                                _seg.origin = Common.GetAirportCode(frmV["flying_to"].ToString());
                                _seg.destination = Common.GetAirportCode(frmV["flying_from"].ToString());
                                _seg.date = Convert.ToDateTime(frmV["hftodate"].ToString()).ToString("dd-MM-yyyy");
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
                        _seg.date = Convert.ToDateTime(frmV["hffromdate"].ToString()).ToString("dd-MM-yyyy");
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
                        cookie.Values.Add("fromdate", frmV["hffromdate"].ToString());
                        cookie.Values.Add("todate", frmV["hftodate"].ToString());
                        cookie.Values.Add("Adult", frmV["Adult"].ToString().Trim());
                        cookie.Values.Add("Child", frmV["Children"].ToString().Trim());
                        cookie.Values.Add("Infant", frmV["Infant"].ToString().Trim());
                        cookie.Values.Add("TripType", frmV["hfTripType"]);
                        cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);
                    }
                    catch { }
                    px.adults = Convert.ToInt32(frmV["Adult"].ToString().Trim());
                    px.children = Convert.ToInt32(frmV["Children"].ToString().Trim());
                    px.infants = Convert.ToInt32(frmV["Infant"].ToString().Trim());
                    px.youth = 0;
                    px.infantOnSeat = 0;
                    ObjSearch.paxDetails = px;


                    ObjSearch.PreferedAirlines = frmV["airline"].ToString();
                    ObjSearch.preferedAirline = frmV["airline"].ToString();
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
                    _objFlt.Httppostcallapi(json.ToString(), "http://api.faressaver.com/api/flightsearch", ObjSearch.searchId, sUnique);                   
                    
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
        public string GetClassCode(string ClassName)
        {
            string Code = "Y";

            switch (ClassName)
            {
                case "Economy":
                    Code = "Y";
                    break;
                case "Premium Economy":
                    Code = "W";
                    break;
                case "Business":
                    Code = "C";
                    break;
                case "First Class":
                    Code = "F";
                    break;

            }
            return Code;

        }

        [HttpPost]
        public string RefreshResult(string unique)
        {
            list = unique.Split('~');
            _objSearch = SearchDetails.Current(list[0]);
            string JType = "O";
            if (_objSearch.FlightSearchDetails.JourneyType == "R")
                JType = "R";
            else
                JType = "O";

            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            var url = string.Empty;
            bool ss = false;
            url = "from=" + _objSearch.FlightSearchDetails.segments[0].origin + "&to=" + _objSearch.FlightSearchDetails.segments[0].destination + "&ddate=" + _objSearch.FlightSearchDetails.segments[0].date + "&rdate=" + (_objSearch.FlightSearchDetails.segments.Count > 1 ? _objSearch.FlightSearchDetails.segments[1].date : "") + "&adults=" + _objSearch.FlightSearchDetails.paxDetails.adults + "&children=" + _objSearch.FlightSearchDetails.paxDetails.children +
                    "&infants=" + _objSearch.FlightSearchDetails.paxDetails.infants + "&jtype=" + JType + "&cabinclass=" + _objSearch.FlightSearchDetails.cabinClass + "&isflex=" + ss + "&airline=" + _objSearch.FlightSearchDetails.preferedAirline + "&compid=" + (string.IsNullOrEmpty(_objSearch.SourceMedia) ? CompCredentials.CompanyId : _objSearch.SourceMedia) + "&isdirect=" + _objSearch.FlightSearchDetails.directFlight + "";
                       
            return url.ToString();

        }
    }
}