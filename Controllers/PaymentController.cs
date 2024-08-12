using System;
using System.Web.Mvc;
using System.Text;
using System.Collections.Generic;


using System.Linq;
using SagePay.IntegrationKit;
using System.Data;
using System.Web.Routing;
using System.Web;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using TravelSite.Models;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace TravelSite.Controllers
{
    public class PaymentController : Controller
    {
        public string strResultDetials { set; get; }
        FlightSearch objSearchFare = new FlightSearch();
        FlightStructure _objFlight = new FlightStructure();
        
        SearchDetails _objSearch;
        SearchDetails SearchDetails;
        string[] list;
        public static int Rw = 1;
        //SagePayDirectIntegration objSPI = new SagePayDirectIntegration("flights");
        PaymentModel _objPaymentModel = new PaymentModel();
        public string media { set; get; }
        public string key { set; get; }
        public WebsiteContactDetails WCD = null;
        public static string url = string.Empty;
        public static string urlguid = string.Empty;
        User ObjUser = new User();


        public ActionResult Paymentdetail(string q, string CardMsg)
        {
            try
            {
                string device = string.Empty;
                var UserAgent = HttpContext.Request.ServerVariables["HTTP_USER_AGENT"];
                if (UserAgent != null && (UserAgent.Contains("iPhone") || UserAgent.Contains("Windows Phone") || UserAgent.Contains("Android")))
                    device = "m";
                else if (UserAgent != null && UserAgent.Contains("iPad"))
                    device = "t";
                else
                    device = "d";
                _objPaymentModel.DeviceType = device;
            }
            catch { }
            try
            {
                if (!string.IsNullOrEmpty(q))
                {
                    list = q.Split('~');
                    url = q;
                    urlguid = q;
                    _objSearch = SearchDetails.Current(list[0]);
                    try
                    {
                        media = _objSearch.SourceMedia;
                        key = _objSearch.key;
                        WCD = new WebsiteContactDetails(Request["__sourceMedia"] != null ? Request["__sourceMedia"] : media, Request["key"] != null ? Request["key"] : key);
                        _objPaymentModel.Contactno1 = WCD.ContactNo1;

                    }
                    catch { }
                    if (_objSearch != null)
                    {

                        _objPaymentModel.Guid = q;
                        _objPaymentModel.unique = q;
                        _objPaymentModel.url = RefreshResult(q);
                        _objSearch.Provider = list[2];
                        _objSearch.Itinerary = _objSearch.Itinerary;
                        _objPaymentModel.DepDate2 = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("yyyy-MM-dd");
                        _objPaymentModel.RetDate2 = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("yyyy-MM-dd") : "";

                        _objPaymentModel.DepDate = Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("ddd, dd MMM yyyy");
                        _objPaymentModel.RetDate = _objSearch.FlightSearchDetails.segments.Count == 2 ? Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("ddd, dd MMM yyyy") : "";

                        _objPaymentModel.MobileNo = _objSearch.MobileNo;

                        string CabinCls = string.Empty;

                        _objPaymentModel.DestFrom = _objSearch.FlightSearchDetails.segments[0].origin.ToString();
                        _objPaymentModel.DestTo = _objSearch.FlightSearchDetails.segments[0].destination.ToString();
                        if (_objSearch.Itinerary != null)
                        {
                            //try
                            //{
                            //    Tracker oTracker = new Tracker(System.Web.HttpContext.Current, _objSearch.FlightSearchDetails.segments[0].origin,
                            //        _objSearch.FlightSearchDetails.segments[0].destination, _objSearch.FlightSearchDetails.segments[0].date,
                            //        _objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.R ? _objSearch.FlightSearchDetails.segments[1].date : "",
                            //        _objSearch.HapID, "", _objSearch.CompanyID);
                            //    Tracker.PageTracking(oTracker);
                            //}
                            //catch { }

                        }
                        ViewBag.cardcountry = CardDropdownlist.CardCountryList();
                        ViewBag.cardtype = CardDropdownlist.cardlist();
                        ViewBag.debitcard = CardDropdownlist.debitcardlist();
                        ViewBag.creditcard = CardDropdownlist.creditcardlist();
                        ViewBag.cardmonth = CardDropdownlist.cardMonthList();
                        ViewBag.cardyear = CardDropdownlist.cardYear();
                        ViewBag.Msg = CardMsg;
                        try
                        {
                            _objPaymentModel.Addr1 = _objSearch.Address1;
                            _objPaymentModel.Addr2 = _objSearch.Address2;
                            _objPaymentModel.City = _objSearch.City;
                            _objPaymentModel.Country = _objSearch.Country;
                            _objPaymentModel.PostalCode = _objSearch.PostCode;
                            _objPaymentModel.CardName = _objSearch.CardName;
                        }
                        catch { }
                        _objPaymentModel.Msg = CardMsg;
                        _objPaymentModel.CountryCode = _objSearch.Itinerary.Sectors[0].Departure.AirportCountryCode;
                        _objPaymentModel.GrandTotal = _objSearch.Itinerary.GrandTotal + _objSearch.AtolAmount;
                        _objPaymentModel.Safi = _objSearch.Itinerary.Safi;
                        _objPaymentModel.Atol = _objSearch.AtolAmount;
                        _objPaymentModel.Itinerary = _objSearch.Itinerary;
                        _objPaymentModel.Pax = _objSearch.Passenger;
                        _objPaymentModel.CompanyId = _objSearch.CompanyID;

                        _objPaymentModel.sGuid = q;
                        _objPaymentModel.BookingID = _objSearch.BookingID;

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch { return RedirectToAction("ErrorPage", "Common"); }
            return View(_objPaymentModel);
        }


        [HttpPost]
        public ActionResult Paymentdetail(FormCollection frm, PaymentModel objmodel, string command)
        {
            string vcard_token = string.Empty;
            string NegativeMarkup = string.Empty;
            string PositiveMarkup = string.Empty;
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            var url = string.Empty;
           // Payment _objPay = new Payment();
            string sCardCode = string.Empty;
            string PayPalUrl = string.Empty;
            UserData ObjUserData = new UserData();
            
            try
            {
                string sUnique = string.Empty;
                if (frm["Guid"] != null)
                    sUnique = frm["Guid"].Split('~')[0];
                _objSearch = SearchDetails.Current(sUnique);

                try
                {
                    _objSearch.Country = objmodel.Passenger_countrylist;// frm["hdnPassengercountry"];
                    _objSearch.PostCode = objmodel.Passenger_Pin;
                    _objSearch.Address = objmodel.Passenger_Addressone + " " + objmodel.Passenger_Addresstwo;
                    _objSearch.City = objmodel.Passenger_city;
                    _objSearch.State = objmodel.Passenger_State;
                    _objSearch.Country = objmodel.Passenger_countrylist;// frm["hdnPassengercountry"];
                    _objSearch.PostCode = objmodel.Passenger_Pin;
                    _objSearch.Address1 = objmodel.Passenger_Addressone;
                    _objSearch.Address2 = objmodel.Passenger_Addresstwo;

                }
                catch { }

                if (!string.IsNullOrEmpty(frm["Guid"]))
                {
                    #region Check Url Exits                    
                    sCardCode = frm["cardtype"].ToString();
                    objmodel.ValidFrom = frm["ddlMastroMonth"].ToString() + frm["ddlMastroYear"].ToString();
                    objmodel.CardIssue_No = frm["txtIssueNumber"].ToString(); string CardType = CreditCardData(objmodel.Card_No);
                    _objSearch.CardCharge = 0;
                    _objSearch.Cvv = objmodel.CardCVV_No.ToString();
                    _objSearch.Cardtype = sCardCode;  objmodel.Card_Name.ToString().Trim();
                    _objSearch.CardHolderName = objmodel.Card_Name.ToUpper().ToString().Trim();
                    _objSearch.CardName = CardType;
                    _objSearch.Cardnumber = objmodel.Card_No.ToString().Trim().Replace(" ", "");
                    _objSearch.Expirydate = frm["card_month"].ToString()+"-"+ frm["card_year"].ToString();
                    _objSearch.BillingCountry = _objSearch.Country;

                    //objmodel.Card_No.ToString().Trim().Replace(" ", "")
                    //    objmodel.Card_Name.ToString().Trim()
                    //    objmodel.CardCVV_No.ToString()
                    //    frm["txtIssueNumber"].ToString()
                    //    ExpiryDate, objmodel.ValidFrom
                    string strSecurityKey = "";
                    string strStatus = "OK"; string strStatusDetail = "OK"; string strVPSTxId = ""; string strTxAuthNo = "87878898"; string strAVSCV2 = ""; string strAddressResult = ""; string strPostCodeResult = ""; string strCV2Result = "OK"; string str3DSecureStatus = "OK"; string strCAVV = objmodel.CardCVV_No; string sBookingStatus = "Firm"; string sBookingRemark = ""; string fnpl = "";
                    SaveInDB objSaveInDB = new SaveInDB();
                    if (objSaveInDB.SavePaymentDetails(_objSearch))
                    {
                        url = urlHelper.Action("Firm", "Firm", new { areaname = " ", q = frm["Guid"].ToString() });
                    }
                    else
                        url = urlHelper.Action("Firm", "Firm", new { areaname = " ", q = frm["Guid"].ToString() });


                    #region Check Card Data
                    //try
                    //{
                    //    if ((objmodel.Card_No.ToString().Trim().Replace(" ", "") != "4929000000006" && objmodel.CardCVV_No.ToString() != "123" && objmodel.Card_Name.ToUpper().ToString().Trim() != "PRABHUDIAL"))
                    //    {
                    //        string CardType = CreditCardData(objmodel.Card_No);
                    //        if (!string.IsNullOrEmpty(CardType))
                    //        {
                    //            sCardCode = CardType;
                    //        }
                    //    }
                    //}
                    //catch { }


                    #endregion

                    

                    //#endregion

                    #endregion
                }
                else
                {
                    #region Url Not Exists
                    url = urlHelper.Action("FlightResult", "Result", new { q = sUnique });
                    #endregion
                }

                if (url == "" && url == null)
                {
                    url = urlHelper.Action("Index", "Home");
                }

                Response.RedirectPermanent(url);
            }
            catch { return RedirectToAction("Index", "Home"); }
            return null;
        }

        #region Session Expire Code

        public string RefreshResult(string unique)
        {
            list = unique.Split('~');
            SearchDetails = SearchDetails.Current(list[0]);
            string JType = "O";
            if (SearchDetails.FlightSearchDetails.JourneyType == "R")
                JType = "R";

            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            var url = string.Empty;
            bool ss = false;

            url = "from=" + SearchDetails.FlightSearchDetails.segments[0].origin + "&to=" + SearchDetails.FlightSearchDetails.segments[0].destination + "&ddate=" + SearchDetails.FlightSearchDetails.segments[0].date + "&rdate=" + (SearchDetails.FlightSearchDetails.segments.Count > 1 ? SearchDetails.FlightSearchDetails.segments[1].date : "") + "&adults=" + SearchDetails.FlightSearchDetails.paxDetails.adults + "&children=" + SearchDetails.FlightSearchDetails.paxDetails.children +
                    "&infants=" + SearchDetails.FlightSearchDetails.paxDetails.infants + "&jtype=" + JType + "&cabinclass=" + SearchDetails.FlightSearchDetails.cabinClass + "&isflex=" + ss + "&airline=" + SearchDetails.FlightSearchDetails.preferedAirline + "&compid=" + (string.IsNullOrEmpty(SearchDetails.SourceMedia) ? CompCredentials.CompanyId : SearchDetails.SourceMedia) + "&isdirect=" + SearchDetails.FlightSearchDetails.directFlight + "";

            return url.ToString();

        }

        #endregion

        #region CheckContinent

        public bool CheckContinent()
        {
            try
            {
                //Payment _objPay = new Payment();
                //string FareType = _objSearch.Itinerary.FareType;
                //string Cont = string.Empty;
                //string sBookingRemark = string.Empty;
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(HttpContext.Server.MapPath("~/App_Data/Continent.xml"));
                //XmlNodeList xmlSelectedNode = xmlDoc.SelectNodes("//Continents/Continent[@Code=\"" + _objSearch.FlightSearchDetails.segments[0].destination + "\"]");

                //foreach (XmlNode node in xmlSelectedNode)
                //{
                //    Cont = node.SelectSingleNode("ContinentCode").InnerText;

                //}

                //if (FareType == "RP" && Cont == "NAM")
                //{
                //    if (!_objPay.CheckNegativeMarkUp(_objSearch.Itinerary.AdultInfo.MarkUp, Convert.ToInt16(300), "Continent"))
                //    {
                //        _objSearch.CheckContinent = "Firm";
                //        return true;
                //    }
                //    else
                //    {
                //        _objSearch.CheckContinent = "DeclineMarkup";
                //        return true;
                //    }
                //}
                //else
                //{
                //    return false;
                //}
                return false;
            }
            catch { return false; }

        }
        #endregion

        public bool CheckCountry(string CountryCode)
        {
            bool wedata = false;
            #region Check Country WeSwap
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Server.MapPath("~/App_Data/Country.xml"));
                XmlNodeList xmlSelectedNode = xmlDoc.SelectNodes("//Countries/Country[@Code=\"" + CountryCode + "\"]");
                if (xmlSelectedNode.Count > 0)
                {
                    foreach (XmlNode node in xmlSelectedNode)
                    {
                        if (node.SelectSingleNode("CountryCode").InnerText != null)
                        {
                            wedata = true;
                            // _objPaymentModel.WeSwapCountry = true;
                        }
                        else
                        {
                            wedata = false;
                            //_objPaymentModel.WeSwapCountry = false;
                        }

                    }
                }
                else
                {
                    wedata = false;
                    // _objPaymentModel.WeSwapCountry = false;
                }

            }
            catch { }
            return wedata;
            #endregion
        }
        public class Credentials
        {

            [JsonProperty("partner_code")]
            public string partner_code { get; set; }

            [JsonProperty("campaign_code")]
            public string campaign_code { get; set; }

            [JsonProperty("first_name")]
            public string first_name { get; set; }

            [JsonProperty("last_name")]
            public string last_name { get; set; }
            [JsonProperty("email")]
            public string email { get; set; }
            [JsonProperty("date_of_birth")]
            public string date_of_birth { get; set; }
            [JsonProperty("gender")]
            public string gender { get; set; }
            [JsonProperty("title")]
            public string title { get; set; }
            [JsonProperty("address")]
            public string address { get; set; }
            [JsonProperty("city")]
            public string city { get; set; }


            [JsonProperty("country")]
            public string country { get; set; }

            [JsonProperty("country_code")]
            public string country_code { get; set; }
            [JsonProperty("postcode")]
            public string postcode { get; set; }
            [JsonProperty("agent_id")]
            public string agent_id { get; set; }
            [JsonProperty("booking_ref")]
            public string booking_ref { get; set; }
            [JsonProperty("test")]
            public string test { get; set; }
            [JsonProperty("telephone")]
            public string telephone { get; set; }



        }

        public class Header
        {
            [JsonProperty("typ")]
            public string typ { get; set; }

            [JsonProperty("alg")]
            public string alg { get; set; }
        }

        private static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        private static string Base64Encode(byte[] text)
        {
            return Convert.ToBase64String((text))
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        #region Implement FlyNowPayLater

        public string FNPLCard(string vcard_token, string sUnique, PaymentModel objmodel, FormCollection frm)
        {

            #region FlyNowPayLater
            string issueno = string.Empty;
            string Token = string.Empty;
            string api_key = "ENCP6J6T2IKPF1URTJAX7OLB";
            string AppID = "N21YO5RXH4-EG8DPS40AQ";
            string MerchantReference = "PX567890"; // Merchant Reference
            var responseString = "";


            try
            {
                if (vcard_token != "")
                {
                    try
                    {
                        var request = (HttpWebRequest)WebRequest.Create("https://merchants.flynowpaylater.com/app.service/" + AppID + "/virtualcard.issue");
                        var postData = "reference=" + vcard_token + "";
                        var data = Encoding.ASCII.GetBytes(postData);

                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        request.ContentLength = data.Length;

                        using (var stream = request.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }

                        var response = (HttpWebResponse)request.GetResponse();

                        responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    }
                    catch (WebException e)
                    {

                        using (WebResponse response = e.Response)
                        {
                            HttpWebResponse httpResponse = (HttpWebResponse)response;
                            Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                            using (Stream data = response.GetResponseStream())
                            using (var reader = new StreamReader(data))
                            {
                                string text = reader.ReadToEnd();
                                Console.WriteLine(text);
                            }
                        }
                    }
                }
            }
            catch { }
            #endregion

            #region Save FNPL  Card Details Response...........................
            try
            {
                if (vcard_token != "" && vcard_token != null)
                {
                    Token = vcard_token;
                    try
                    {
                        ReadWriteFile.SaveFile(Server.MapPath("~/FNPLCard/" + _objSearch.BookingID + ".txt"), responseString);
                        ReadWriteFile.SaveFile(Server.MapPath("~/App_Data/Response/Fly/" + sUnique + ".txt"), responseString);
                    }
                    catch { }
                }
                else
                {
                    Token = "";
                }



            }
            catch { }

            #endregion

            #region  Update Fnpl  Card Information..............................
            try
            {
                _objSearch.Address = objmodel.Passenger_Addressone + " " + objmodel.Passenger_Addresstwo;
                _objSearch.City = objmodel.Passenger_city;
                _objSearch.State = objmodel.Passenger_State;
                _objSearch.Country = objmodel.Passenger_countrylist;// frm["hdnPassengercountry"];
                _objSearch.PostCode = objmodel.Passenger_Pin;
                _objSearch.Address = objmodel.Passenger_Addressone + " " + objmodel.Passenger_Addresstwo;
                _objSearch.City = objmodel.Passenger_city;
                _objSearch.State = objmodel.Passenger_State;
                _objSearch.Country = objmodel.Passenger_countrylist;// frm["hdnPassengercountry"];
                _objSearch.PostCode = objmodel.Passenger_Pin;

                _objSearch.Address1 = objmodel.Passenger_Addressone;
                _objSearch.Address2 = objmodel.Passenger_Addresstwo;
                _objSearch.CardName = objmodel.Card_Name;
            }
            catch { }

            try
            {
                if (vcard_token != "" && vcard_token != null)
                {


                    var strJason = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Response/Fly/" + sUnique + ".txt"));
                    XmlDocument doc1 = (XmlDocument)JsonConvert.DeserializeXmlNode(strJason, "root");
                    if (doc1.SelectSingleNode("root/card/details") != null)
                    {
                        _objSearch.CardName = doc1.SelectSingleNode("root/card/details/name").InnerText;
                    }
                    if (doc1.SelectSingleNode("root/card/address/line1") != null)
                    {
                        _objSearch.Address = doc1.SelectSingleNode("root/card/address/line1").InnerText + " " + doc1.SelectSingleNode("root/card/address/line2").InnerText;
                    }
                    _objSearch.City = doc1.SelectSingleNode("root/card/address/city").InnerText;
                    //_objSearch.Country = doc1.SelectSingleNode("root/vcInfo/vcCardAddress/vcCounty").InnerText;
                    _objSearch.PostCode = doc1.SelectSingleNode("root/card/address/postalcode").InnerText;
                    _objSearch.State = doc1.SelectSingleNode("root/card/address/line3").InnerText;
                    objmodel.Card_Name = doc1.SelectSingleNode("root/card/details/name").InnerText;
                    objmodel.CardCVV_No = doc1.SelectSingleNode("root/card/details/cvv").InnerText;
                    objmodel.Card_No = doc1.SelectSingleNode("root/card/details/number").InnerText;
                    objmodel.Card_Code = "DELTA";
                    issueno = doc1.SelectSingleNode("root/card/details/expiry").InnerText;

                    frm["card_month"] = issueno.Split('/')[0].ToString();
                    frm["card_year"] = issueno.Split('/')[1].ToString();

                }
            }
            catch { }


            #endregion

            return Token;
        }

        #endregion

        #region Card API

        public string CreditCardData(string CardNo)
        {
            string CardCode = string.Empty; string CardType = string.Empty; string Level = string.Empty;
            var responseString = "";
            string Key = "2b294d2ecfab1f55804b95d4e7a8a7ee";

            try
            {

                #region Hit Card Service

                try
                {
                    var request = (HttpWebRequest)WebRequest.Create("https://api.bincodes.com/cc/?format=json&api_key=" + Key + "&cc=" + CardNo.Replace(" ", "") + "");
                    var postData = "";
                    var data = Encoding.ASCII.GetBytes(postData);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    var response = (HttpWebResponse)request.GetResponse();

                    responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
                catch (WebException e)
                {

                    using (WebResponse response = e.Response)
                    {
                        HttpWebResponse httpResponse = (HttpWebResponse)response;
                        Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                        using (Stream data = response.GetResponseStream())
                        using (var reader = new StreamReader(data))
                        {
                            string text = reader.ReadToEnd();
                            Console.WriteLine(text);
                        }
                    }
                }
                catch { }

                #endregion

                #region Save Credit Card Details Response...........................
                try
                {
                    try
                    {
                        ReadWriteFile.SaveFile(Server.MapPath("~/App_Data/Response/CreditCard/" + _objSearch.BookingID + ".txt"), responseString);
                    }
                    catch { }

                }
                catch { }


                //string filePath = HttpContext.Server.MapPath("/Booking.xml");
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filePath);
                //responseString = xmlDoc.OuterXml;

                XmlDocument xmlDoc = (XmlDocument)JsonConvert.DeserializeXmlNode(responseString, "root");
                if (xmlDoc.SelectSingleNode("root/bin") != null)
                {
                    CardCode = xmlDoc.SelectSingleNode("root/card").InnerText;
                    CardType = xmlDoc.SelectSingleNode("root/type").InnerText;
                    Level = xmlDoc.SelectSingleNode("root/level").InnerText;
                }

                if (CardCode.ToUpper() == "VISA" && CardType.ToUpper() == "CREDIT" && Level.ToUpper() != "ELECTRON")
                    CardCode = "VISA";
                else if (CardCode.ToUpper() == "VISA" && CardType.ToUpper() == "DEBIT" && Level.ToUpper() != "ELECTRON")
                    CardCode = "DELTA";
                else if (CardCode.ToUpper() == "VISA" && CardType.ToUpper() == "DEBIT" && Level.ToUpper() == "ELECTRON")
                    CardCode = "UKE";
                else if (CardCode.ToUpper() == "VISA" && CardType.ToUpper() == "CREDIT" && Level.ToUpper() == "ELECTRON")
                    CardCode = "UKE";
                else if (CardCode.ToUpper() == "MASTERCARD" && CardType.ToUpper() == "CREDIT")
                    CardCode = "MC";
                else if (CardCode.ToUpper() == "MASTERCARD" && CardType.ToUpper() == "DEBIT")
                    CardCode = "MCDEBIT";
                else if (CardCode.ToUpper() == "AMERICAN EXPRESS" && CardType.ToUpper() == "CREDIT")
                    CardCode = "AMEX";
                else if (CardCode.ToUpper() == "MAESTRO" && CardType.ToUpper() == "CREDIT")
                    CardCode = "SWITCH";
                else if (CardCode.ToUpper() == "MAESTRO" && CardType.ToUpper() == "DEBIT")
                    CardCode = "SWITCH";

                #endregion
            }
            catch { }

            return CardCode;
        }

        #endregion

    }
}