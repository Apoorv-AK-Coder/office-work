using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using System.Web.Routing;
using System.Web;
using TravelSite.Models;
 

namespace TravelSite.Controllers
{
    public class PassengerDetailsController : Controller
    {
        PassengerDetailsModel _objPassModel = new PassengerDetailsModel();
        PaxInfo _paxes = new PaxInfo();

        public string strResultDetials { set; get; }
        FlightSearch objSearchFare = new FlightSearch();
        FlightStructure _objFlight = new FlightStructure();
        SearchDetails SearchDetails;
        public static bool check = false;

        string[] list;
        public WebsiteContactDetails WCD = null;
        public string media { set; get; }
        public string key { set; get; }

        public ActionResult Passenger(string q)
        {
            try
            {
                if (!string.IsNullOrEmpty(q))
                {
                    list = q.Split('~');

                    SearchDetails = SearchDetails.Current(list[0]);
                    if (SearchDetails != null)
                    {
                        _objPassModel.unique = q;
                        _objPassModel.Guid = q;// list[0];
                        SearchDetails.IndexNumber = Convert.ToInt32(list[1]);
                        SearchDetails.Provider = list[2];
                        SearchDetails.Itinerary = objSearchFare.GetItineraryNew(list[0], list[1], list[2]);
                        _objPassModel.Itinerary = SearchDetails.Itinerary;
                        _objPassModel.Adult = SearchDetails.FlightSearchDetails.paxDetails.adults;
                        _objPassModel.Child = SearchDetails.FlightSearchDetails.paxDetails.children;
                        _objPassModel.Infant = SearchDetails.FlightSearchDetails.paxDetails.infants;
                        _objPassModel.InfantWithSeat = SearchDetails.FlightSearchDetails.paxDetails.infantOnSeat;
                        _objPassModel.url = RefreshResult(q);
                        List<ViewModel> _ModelVieww = new List<ViewModel>();
                        _ModelVieww.Add(new ViewModel { _AdultM = AdultList(SearchDetails.FlightSearchDetails.paxDetails.adults), _ChildM = ChildList(SearchDetails.FlightSearchDetails.paxDetails.children), _InfantM = InfatList(SearchDetails.FlightSearchDetails.paxDetails.infants), _BillingField = BillingField() });
                        _objPassModel._ViewModel = _ModelVieww;

                        ViewBag.Day = Passanger_Field.DayList();
                        ViewBag.Month = Passanger_Field.MonthList();
                        ViewBag.AdultYear = Passanger_Field.AdultYear();
                        ViewBag.ChildYear = Passanger_Field.ChildYear();
                        ViewBag.InfantYear = Passanger_Field.InfantYear();
                        ViewBag.SeatList = Passanger_Field.SeatList();
                        ViewBag.MealList = Passanger_Field.MealList();
                        ViewBag.GenderList = Passanger_Field.genderList();
                        ViewBag.TitleAdultList = Passanger_Field.titleadultList();
                        ViewBag.TitleChildList = Passanger_Field.titlechildList();
                        ViewBag.TitleInfantList = Passanger_Field.titleinfantList();
                        ViewBag.CountryList = Passanger_Field.CountryList();
                        ViewBag.Frequentairline = SearchDetails.Itinerary.Sectors[0].AirlineName + "(" + SearchDetails.Itinerary.Sectors[0].AirV + ")";
                        if (SearchDetails.Itinerary != null)
                        {
                            try
                            {
                                SearchDetails.AddPassenger();
                            }
                            catch { }


                        }
                        try
                        {
                            media = SearchDetails.SourceMedia;
                            key = SearchDetails.key;
                            WCD = new WebsiteContactDetails(Request["__sourceMedia"] != null ? Request["__sourceMedia"] : media, Request["key"] != null ? Request["key"] : key);
                            _objPassModel.keyvalue = media;
                            _objPassModel.ContactNo1 = WCD.ContactNo1;
                            SearchDetails.ContactNo1 = WCD.ContactNo1;
                        }
                        catch { return RedirectToAction("ErrorPage", "Common"); }

                    }
                    else
                    {
                        return RedirectToAction("ErrorPage", "Common");
                    }
                }
                else
                {
                    return RedirectToAction("ErrorPage", "Common");
                }
            }
            catch { return RedirectToAction("ErrorPage", "Common"); }
            return View(_objPassModel);
        }


        #region Generate Pax Class Fields

        public List<Adult_Pax> AdultList(int Adult_)
        {
            List<Adult_Pax> _adultList = new List<Adult_Pax>();
            for (int i = 0; i < Adult_; i++)
            {
                _adultList.Add(new Adult_Pax { Title = null, Day = null, Month = null, Year = null, FirstName = "", LastName = "", Gender = null, Meal = null, Seat = null });
            }
            return _adultList;
        }
        public List<Child_Pax> ChildList(int Child_)
        {
            List<Child_Pax> _childList = new List<Child_Pax>();
            for (int i = 0; i < Child_; i++)
            {
                _childList.Add(new Child_Pax { Title = null, Day = null, Month = null, Year = null, FirstName = "", LastName = "", Gender = null, Meal = null, Seat = null });
            }

            return _childList;
        }
        public List<Infant_Pax> InfatList(int Infaint)
        {
            List<Infant_Pax> _infantList = new List<Infant_Pax>();
            for (int i = 0; i < Infaint; i++)
            {
                _infantList.Add(new Infant_Pax { Title = null, Day = null, Month = null, Year = null, FirstName = "", LastName = "", Gender = null, Meal = null, Seat = null });
            }

            return _infantList;
        }
        public List<Billing_Field> BillingField()
        {
            List<Billing_Field> _BillingF = new List<Billing_Field>();
            _BillingF.Add(new Billing_Field { Country = null, AddressLine1 = "", AddressLine2 = "", City = "", CState = "", FirstName = "", LastName = "", PostalCode = "" });
            return _BillingF;
        }

        #endregion

        [HttpPost]
        public ActionResult Passenger(FormCollection frm, PassengerDetailsModel _ObjModel, string command)
        {
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            var url = string.Empty;

            string sGuid = string.Empty;
            if (!string.IsNullOrEmpty(frm["Guid"]))
            {
                sGuid = frm["Guid"].ToString();
                SearchDetails = SearchDetails.Current(frm["Guid"].ToString().Split('~')[0]);
                if (SearchDetails != null)
                {
                    SearchDetails.EmailID = frm["Email"].ToString().Trim();
                    SearchDetails.PhoneNo = frm["homePhone"].ToString().Trim();
                    SearchDetails.MobileNo = frm["MobNo"].ToString().Trim();
                    //string PayType = frm["Pay"].ToString().Trim();
                    try
                    {
                        if (command == null)
                        {
                            command = "Continue Booking";
                        }
                    }
                    catch { }
                    command = Common.GetCommandName(command.Trim());

                    SetPassenger(frm);
                    double GrandTotal = SearchDetails.Itinerary.GrandTotal;
                    string offerType = SearchDetails.Itinerary.OfferType;
                    SaveInDB _SaveInDB = new SaveInDB();
                    OnlineFlightStructure OBJ = new OnlineFlightStructure();
                    SearchDetails.ProdID = "001";
                    if (!string.IsNullOrEmpty(command) && command.Equals("Continue Booking"))
                    {
                        SearchDetails.BookingStatus = "2";
                        if (OBJ.SaveBookingDB(ref SearchDetails,"2"))
                        {                            
                            SearchDetails.SetTransactionNo();                           
                            try
                            {
                               // Emailcls.SendMail(CompCredentials.EmailID2, "Booking Alert - " + SearchDetails.BookingID, _objFlight.BookingDetails(frm["Guid"].ToString().Split('~')[0]), string.Empty,"", "reservation@faressaver.com"); // 
                            }
                            catch { ReadWriteFile.SaveFile(HttpContext.Server.MapPath("~/App_Data/Emails/" + SearchDetails.EmailID + "-PaxDetails.txt"), "Email failed"); }
                          
                            SearchDetails.PaymentCallbackDetails = new PaymentCallbackDetails();
                            url = urlHelper.Action("Paymentdetail", "Payment", new { q = sGuid });
                            return RedirectToActionPermanent("Paymentdetail", "Payment", new { q = sGuid });
                            
                        }
                        else
                            url = urlHelper.Action("Passenger", new { q = sGuid });

                        #region Fare match process

                        //if (objSearchFare.FareMatchAPI(frm["Guid"].ToString().Split('~')[0]))
                        //{
                        //    if (_SaveInDB.SaveBookingInDB(frm["Guid"].ToString().Split('~')[0]))  // _SaveInDB.SaveBookingInDB(frm["Guid"].ToString().Split('~')[0])
                        //    {
                        //        //SetShoppingCart();
                        //        SearchDetails.SetTransactionNo();
                        //        try
                        //        {
                        //            DataService objMail = new DataService();
                        //            bool mailsent = objMail.Sendcustomermail(CompCredentials.EmailID2, CompCredentials.EmailID2, "Booking Alert - " + SearchDetails.BookingID, _objFlight.BookingDetails(frm["Guid"].ToString().Split('~')[0]), "", "natwar@dial4travel.co.uk");
                        //            ReadWriteFile.SaveFile(HttpContext.Server.MapPath("~/App_Data/Emails/" + SearchDetails.EmailID + "-PaxDetails.txt"), "Booking Alert Email Sent - " + mailsent.ToString());
                        //        }
                        //        catch (Exception ex)
                        //        {
                        //            ReadWriteFile.SaveFile(HttpContext.Server.MapPath("~/App_Data/Emails/" + SearchDetails.EmailID + "-PaxDetails.txt"), "Email failed");
                        //        }

                        //        if (SearchDetails.HapID == "TJ_FRCOMP")
                        //        {
                        //            url = urlHelper.Action("Enquiry", "FlightEnquiry", new { q = sGuid });
                        //            return RedirectToActionPermanent("Enquiry", "FlightEnquiry", new { q = sGuid });
                        //        }
                        //        else
                        //        {
                        //            SearchDetails.PaymentCallbackDetails = new PaymentCallbackDetails();
                        //            if (SearchDetails.Itinerary.OfferType == "CALL")
                        //            {
                        //                url = urlHelper.Action("Paymentdetail", "Payment", new { q = sGuid });
                        //                return RedirectToActionPermanent("Paymentdetail", "Payment", new { q = sGuid });
                        //            }
                        //            else
                        //            {
                        //                if (PayType == "SAGE")
                        //                {
                        //                    url = urlHelper.Action("Paymentdetail", "Payment", new { q = sGuid });
                        //                    return RedirectToActionPermanent("Paymentdetail", "Payment", new { q = sGuid });
                        //                }
                        //                else if (PayType == "FNPL")
                        //                {
                        //                    return RedirectToActionPermanent("Index", "FlynowPaylater", new { q = sGuid });
                        //                }
                        //            }
                        //        }
                        //        url = urlHelper.Action("Enquiry", "FlightEnquiry", new { q = sGuid });
                        //    }
                        //    else
                        //        url = urlHelper.Action("Passenger", new { q = sGuid });
                        //}
                        //else
                        //{
                        //    if (SearchDetails.PriceChangeStatus == "PriceChange")
                        //    {
                        //        try
                        //        {
                        //            media = SearchDetails.SourceMedia;
                        //            key = SearchDetails.key;
                        //            WCD = new WebsiteContactDetails(Request["__sourceMedia"] != null ? Request["__sourceMedia"] : media, Request["key"] != null ? Request["key"] : key);
                        //            _ObjModel.keyvalue = media;
                        //            _ObjModel.ContactNo1 = WCD.ContactNo1;
                        //            _ObjModel.ContactNo1 = WCD.ContactNo1;
                        //        }
                        //        catch { return RedirectToAction("ErrorPage", "Common"); }

                        //        _ObjModel.OldPrice = GrandTotal.ToString("f2");
                        //        double dDiffAmount = SearchDetails.Itinerary.GrandTotal - GrandTotal;
                        //        _ObjModel.CPrice = dDiffAmount.ToString("f2");
                        //        _ObjModel.NewPrice = SearchDetails.Itinerary.GrandTotal.ToString("f2");
                        //        _ObjModel.Difference = dDiffAmount.ToString("f2");
                        //        _ObjModel.AirlineLogo = "../images/AirlineLogo/" + SearchDetails.Itinerary.Sectors[0].AirV + "_s.png";
                        //        _ObjModel.AirlineName = SearchDetails.Itinerary.Sectors[0].AirlineName;

                        //        _ObjModel.IsPriceChange = true;
                        //        _SaveInDB.SaveBookingInDB(frm["Guid"].ToString().Split('~')[0]);

                        //        _ObjModel.Itinerary = SearchDetails.Itinerary;
                        //        _ObjModel.Adult = SearchDetails.FlightSearchDetails.paxDetails.adults;
                        //        _ObjModel.Child = SearchDetails.FlightSearchDetails.paxDetails.children;
                        //        _ObjModel.Infant = SearchDetails.FlightSearchDetails.paxDetails.infants;
                        //        _ObjModel.InfantWithSeat = SearchDetails.FlightSearchDetails.paxDetails.infantOnSeat;
                        //        List<ViewModel> _ModelVieww = new List<ViewModel>();
                        //        _ModelVieww.Add(new ViewModel { _AdultM = AdultList(SearchDetails.FlightSearchDetails.paxDetails.adults), _ChildM = ChildList(SearchDetails.FlightSearchDetails.paxDetails.children), _InfantM = InfatList(SearchDetails.FlightSearchDetails.paxDetails.infants), _BillingField = BillingField() });
                        //        _objPassModel._ViewModel = _ModelVieww;
                        //        ViewBag.Day = Passanger_Field.DayList();
                        //        ViewBag.Month = Passanger_Field.MonthList();
                        //        ViewBag.AdultYear = Passanger_Field.AdultYear();
                        //        ViewBag.ChildYear = Passanger_Field.ChildYear();
                        //        ViewBag.InfantYear = Passanger_Field.InfantYear();
                        //        ViewBag.SeatList = Passanger_Field.SeatList();
                        //        ViewBag.MealList = Passanger_Field.MealList();
                        //        ViewBag.GenderList = Passanger_Field.genderList();
                        //        ViewBag.TitleAdultList = Passanger_Field.titleadultList();
                        //        ViewBag.TitleChildList = Passanger_Field.titlechildList();
                        //        ViewBag.TitleInfantList = Passanger_Field.titleinfantList();
                        //        ViewBag.CountryList = Passanger_Field.CountryList();
                        //        ViewBag.Frequentairline = SearchDetails.Itinerary.Sectors[0].AirlineName + "(" + SearchDetails.Itinerary.Sectors[0].AirV + ")";
                        //        return View("Passenger", _ObjModel);

                        //    }
                        //    else
                        //    {
                        //        // same as fare match

                        //        if (_SaveInDB.SaveBookingInDB(frm["Guid"].ToString().Split('~')[0]))  // _SaveInDB.SaveBookingInDB(frm["Guid"].ToString().Split('~')[0])
                        //        {
                        //            SetShoppingCart();
                        //            SearchDetails.SetTransactionNo();
                        //            try
                        //            {
                        //                DataService objMail = new DataService();
                        //                bool mailsent = objMail.Sendcustomermail(CompCredentials.EmailID2, CompCredentials.EmailID2, "Booking Alert - " + SearchDetails.BookingID, _objFlight.BookingDetails(frm["Guid"].ToString().Split('~')[0]), "", "natwar@dial4travel.co.uk");
                        //                ReadWriteFile.SaveFile(HttpContext.Server.MapPath("~/App_Data/Emails/" + SearchDetails.EmailID + "-PaxDetails.txt"), "Booking Alert Email Sent - " + mailsent.ToString());
                        //            }
                        //            catch (Exception ex)
                        //            {
                        //                ReadWriteFile.SaveFile(HttpContext.Server.MapPath("~/App_Data/Emails/" + SearchDetails.EmailID + "-PaxDetails.txt"), "Email failed");
                        //            }

                        //            if (SearchDetails.HapID == "TJ_FRCOMP")
                        //            {
                        //                url = urlHelper.Action("Enquiry", "FlightEnquiry", new { q = sGuid });
                        //                return RedirectToActionPermanent("Enquiry", "FlightEnquiry", new { q = sGuid });
                        //            }
                        //            else
                        //            {
                        //                SearchDetails.PaymentCallbackDetails = new PaymentCallbackDetails();
                        //                if (SearchDetails.Itinerary.OfferType == "CALL")
                        //                {
                        //                    url = urlHelper.Action("Paymentdetail", "Payment", new { q = sGuid });
                        //                    return RedirectToActionPermanent("Paymentdetail", "Payment", new { q = sGuid });
                        //                }
                        //                else
                        //                {
                        //                    if (PayType == "SAGE")
                        //                    {
                        //                        url = urlHelper.Action("Paymentdetail", "Payment", new { q = sGuid });
                        //                        return RedirectToActionPermanent("Paymentdetail", "Payment", new { q = sGuid });
                        //                    }
                        //                    else if (PayType == "FNPL")
                        //                    {
                        //                        return RedirectToActionPermanent("Index", "FlynowPaylater", new { q = sGuid });
                        //                    }
                        //                }
                        //            }
                        //            url = urlHelper.Action("Enquiry", "FlightEnquiry", new { q = sGuid });
                        //        }
                        //        else
                        //            url = urlHelper.Action("Passenger", new { q = sGuid });
                        //    }
                        //}

                        #endregion fare match
                    }

                    if (!string.IsNullOrEmpty(command) && command.Equals("Continue"))
                    {
                        url = RedirectToPayment(frm);
                    }

                    if (!string.IsNullOrEmpty(command) && command.Equals("Choose1"))
                    {
                        string[] sVal = frm["OptOneIndProvider"].ToString().Split('~');
                        SearchDetails.IndexNumber = Convert.ToInt32(sVal[0]);
                        SearchDetails.Provider = sVal[1];
                        SearchDetails.Itinerary = objSearchFare.GetItineraryNew(frm["Guid"].ToString().Split('~')[0], sVal[0], sVal[1]);
                        url = BookingProcessing(sVal[0], sVal[1], frm["Guid"].ToString().Split('~')[0], frm);
                    }
                    if (!string.IsNullOrEmpty(command) && command.Equals("Choose2"))
                    {
                        string[] sVal = frm["OptTwoIndProvider"].ToString().Split('~');
                        SearchDetails.IndexNumber = Convert.ToInt32(sVal[0]);
                        SearchDetails.Provider = sVal[1];
                        SearchDetails.Itinerary = objSearchFare.GetItineraryNew(frm["Guid"].ToString().Split('~')[0], sVal[0], sVal[1]);
                        url = BookingProcessing(sVal[0], sVal[1], frm["Guid"].ToString().Split('~')[0], frm);
                    }
                    if (!string.IsNullOrEmpty(command) && command.Equals("Choose3"))
                    {
                        string[] sVal = frm["OptThreeIndProvider"].ToString().Split('~');
                        SearchDetails.IndexNumber = Convert.ToInt32(sVal[0]);
                        SearchDetails.Provider = sVal[1];
                        SearchDetails.Itinerary = objSearchFare.GetItineraryNew(frm["Guid"].ToString().Split('~')[0], sVal[0], sVal[1]);
                        url = BookingProcessing(sVal[0], sVal[1], frm["Guid"].ToString().Split('~')[0], frm);
                    }
                    if (!string.IsNullOrEmpty(command) && command.Equals("Choose4"))
                    {
                        string[] sVal = frm["OptFourIndProvider"].ToString().Split('~');
                        SearchDetails.IndexNumber = Convert.ToInt32(sVal[0]);
                        SearchDetails.Provider = sVal[1];
                        SearchDetails.Itinerary = objSearchFare.GetItineraryNew(frm["Guid"].ToString().Split('~')[0], sVal[0], sVal[1]);
                        url = BookingProcessing(sVal[0], sVal[1], frm["Guid"].ToString().Split('~')[0], frm);
                    }
                }
            }
            else
            {
                url = urlHelper.Action("Passenger", new { q = sGuid });
            }
            Response.RedirectPermanent(url);
            return null;
        }


        private void SetShoppingCart()
        {
            SearchDetails.Billing = new Billing();
            SearchDetails.Shipping = new Shipping();

            SearchDetails.Billing.FirstNames = SearchDetails.Passenger[0].FirstName.ToUpper().Trim();
            SearchDetails.Billing.Surname = SearchDetails.Passenger[0].LastName.ToUpper().Trim();
            SearchDetails.Billing.Address1 = "";
            SearchDetails.Billing.Address2 = " ";
            SearchDetails.Billing.City = "";
            SearchDetails.Billing.PostCode = "";
            SearchDetails.Billing.Country = "GB";
            SearchDetails.Billing.CountryName = "United Kingdom";
            SearchDetails.Billing.Region = " ";
            SearchDetails.Billing.Phone = SearchDetails.MobileNo;
            SearchDetails.Billing.Email = SearchDetails.EmailID;

            SearchDetails.Shipping.FirstNames = SearchDetails.Passenger[0].FirstName.ToUpper().Trim();
            SearchDetails.Shipping.Surname = SearchDetails.Passenger[0].LastName.ToUpper().Trim();
            SearchDetails.Shipping.Address1 = "";
            SearchDetails.Shipping.Address2 = " ";
            SearchDetails.Shipping.City = "";
            SearchDetails.Shipping.PostCode = "";
            SearchDetails.Shipping.Country = "GB";
            SearchDetails.Shipping.CountryName = "United Kingdom";// 
            SearchDetails.Shipping.Region = " ";
            SearchDetails.Shipping.Phone = SearchDetails.MobileNo;
            SearchDetails.Shipping.Email = SearchDetails.EmailID;

        }
        private string BookingProcessing(string sIndex, string sProvider, string sUnique, FormCollection frm)
        {
            double GrandTotal = SearchDetails.Itinerary.GrandTotal;
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            var url = string.Empty;

            if (objSearchFare.FareMatch(sUnique))
            {
                return RedirectToPaymentFltCh(sIndex, sProvider, frm);
            }
            else
            {
                return RedirectToPaymentFltCh(sIndex, sProvider, frm);
            }
        }


        private void GetFlightOption(PassengerDetailsModel _ObjModel, string Guid)
        {
            objSearchFare.RemoveItinerary(Guid.Split('~')[0]);
            List<Itinerary> xElem = objSearchFare.GetAltOptionFlights(Guid.Split('~')[0]);
            int ctr = 0;
            foreach (Itinerary item in xElem)
            {
                if (ctr == 0)
                {
                    _ObjModel.ImageUrl1 = "../images/AirlineLogo/" + item.Sectors[0].AirV + "_s.png";
                    _ObjModel.Opt1UpdateFare = item.GrandTotal.ToString("f2");
                    _ObjModel.Opt1OrgFare = SearchDetails.Itinerary.GrandTotal.ToString("f2");
                    _ObjModel.Opt1DiffFare = (item.GrandTotal - SearchDetails.Itinerary.GrandTotal).ToString("f2");
                    _ObjModel.Opt1IndexProvider = item.IndexNumber.ToString() + "~" + item.Provider;
                    _ObjModel.Airline1 = item.Sectors[0].AirlineName;
                }
                else if (ctr == 1)
                {
                    _ObjModel.ImageUrl2 = "../images/AirlineLogo/" + item.Sectors[0].AirV + "_s.png";
                    _ObjModel.Opt2UpdateFare = item.GrandTotal.ToString("f2");
                    _ObjModel.Opt2OrgFare = SearchDetails.Itinerary.GrandTotal.ToString("f2");
                    _ObjModel.Opt2DiffFare = (item.GrandTotal - SearchDetails.Itinerary.GrandTotal).ToString("f2");
                    _ObjModel.Opt2IndexProvider = item.IndexNumber.ToString() + "~" + item.Provider;
                    _ObjModel.Airline2 = item.Sectors[0].AirlineName;
                }
                else if (ctr == 2)
                {
                    _ObjModel.ImageUrl3 = "../images/AirlineLogo/" + item.Sectors[0].AirV + "_s.png";
                    _ObjModel.Opt3UpdateFare = item.GrandTotal.ToString("f2");
                    _ObjModel.Opt3OrgFare = SearchDetails.Itinerary.GrandTotal.ToString("f2");
                    _ObjModel.Opt3DiffFare = (item.GrandTotal - SearchDetails.Itinerary.GrandTotal).ToString("f2");
                    _ObjModel.Opt3IndexProvider = item.IndexNumber.ToString() + "~" + item.Provider;
                    _ObjModel.Airline3 = item.Sectors[0].AirlineName;
                }
                else if (ctr == 3)
                {
                    _ObjModel.ImageUrl4 = "../images/AirlineLogo/" + item.Sectors[0].AirV + "_s.png";
                    _ObjModel.Opt4UpdateFare = item.GrandTotal.ToString("f2");
                    _ObjModel.Opt4OrgFare = SearchDetails.Itinerary.GrandTotal.ToString("f2");
                    _ObjModel.Opt4DiffFare = (item.GrandTotal - SearchDetails.Itinerary.GrandTotal).ToString("f2");
                    _ObjModel.Opt4IndexProvider = item.IndexNumber.ToString() + "~" + item.Provider;
                    _ObjModel.Airline4 = item.Sectors[0].AirlineName;
                }
                ctr++;
            }
        }

        private void SetPassenger(FormCollection frm)
        {
            int Count = 0;

            double adtbaggageprice = 0;
            double chdbaggageprice = 0;
            int p = 0;
            int c = 0;
            for (int i = 0; i < SearchDetails.FlightSearchDetails.paxDetails.adults; i++)
            {
                try
                {
                    SearchDetails.Passenger[Count].Title = frm["_ViewModel[0]._AdultM[" + i + "].Title.ID"];
                    SearchDetails.Passenger[Count].FirstName = frm["_ViewModel[0]._AdultM[" + i + "].FirstName"];
                    SearchDetails.Passenger[Count].LastName = frm["_ViewModel[0]._AdultM[" + i + "].LastName"];
                    SearchDetails.Passenger[Count].Gender = frm["_ViewModel[0]._AdultM[" + i + "].Gender.ID"];

                    string sDay = frm["_ViewModel[0]._AdultM[" + i + "].Day.ID"];
                    string sMonth = frm["_ViewModel[0]._AdultM[" + i + "].Month.ID"];
                    string sYear = frm["_ViewModel[0]._AdultM[" + i + "].Year.ID"];
                    SearchDetails.Passenger[Count].DOB = Convert.ToDateTime(sDay + "/" + sMonth + "/" + sYear);
                    SearchDetails.Passenger[Count].Seat = frm["_ViewModel[0]._AdultM[" + i + "].Seat.ID"];
                    SearchDetails.Passenger[Count].SeatName = GetSeat(SearchDetails.Passenger[Count].Seat);
                    SearchDetails.Passenger[Count].Meal = frm["_ViewModel[0]._AdultM[" + i + "].Meal.ID"];
                    SearchDetails.Passenger[Count].MealName = GetMeal(SearchDetails.Passenger[Count].Meal);
                    //  int startIndex = frm["_ViewModel[0]._AdultM[" + i + "].FreqFlyerAirline.ID"].LastIndexOf("(");
                    //string sub = frm["_ViewModel[0]._AdultM[" + i + "].FreqFlyerAirline.ID"].Substring(startIndex + 1);
                    //   string frequentairline = sub.Replace(")", "");
                    // SearchDetails.Passenger[Count].FreqFlyerAirline = frequentairline;
                    //  SearchDetails.Passenger[Count].FreqFlyerNo = frm["_ViewModel[0]._AdultM[" + i + "].FreqFlyerNo.ID"];
                    SearchDetails.Passenger[Count].BaggageCode = frm["_ViewModel[0]._AdultM[" + i + "].BaggageData.ID"];

                    if (frm["_ViewModel[0]._AdultM[" + i + "].Passport"] != null && frm["_ViewModel[0]._AdultM[" + i + "].Passport"] != "")
                    {
                        SearchDetails.Passenger[Count].PassportNo = frm["_ViewModel[0]._AdultM[" + i + "].Passport"];
                    }
                    else
                    {
                        SearchDetails.Passenger[Count].PassportNo = "111111";
                    }
                    if (frm["_ViewModel[0]._AdultM[" + i + "].IssueDate"] != null && frm["_ViewModel[0]._AdultM[" + i + "].IssueDate"] != "")
                    {
                        SearchDetails.Passenger[Count].IssueDate = Convert.ToDateTime(frm["_ViewModel[0]._AdultM[" + i + "].IssueDate"].Replace("/", "-"));
                    }
                    if (frm["_ViewModel[0]._AdultM[" + i + "].ExpiryDate"] != null && frm["_ViewModel[0]._AdultM[" + i + "].ExpiryDate"] != "")
                    {
                        SearchDetails.Passenger[Count].ExpiryDate = Convert.ToDateTime(frm["_ViewModel[0]._AdultM[" + i + "].ExpiryDate"].Replace("/", "-"));
                    }
                    if (frm["_ViewModel[0]._AdultM[" + i + "].Country.ID"] != null && frm["_ViewModel[0]._AdultM[" + i + "].Country.ID"] != "")
                    {
                        SearchDetails.Passenger[Count].CountryCode = frm["_ViewModel[0]._AdultM[" + i + "].Country.ID"];
                    }
                    if (frm["_ViewModel[0]._AdultM[" + i + "].IssueCity"] != null && frm["_ViewModel[0]._AdultM[" + i + "].IssueCity"] != "")
                    {
                        SearchDetails.Passenger[Count].IssueCity = frm["_ViewModel[0]._AdultM[" + i + "].IssueCity"];
                    }

                    //if (SearchDetails.Passenger[Count].BaggageCode != "")
                    //{
                    //    for (int a = 0; a < SearchDetails.Itinerary.Baggages.Count; a++)
                    //    {
                    //        if (SearchDetails.Passenger[Count].BaggageCode == SearchDetails.Itinerary.Baggages[a].BaggageCode)
                    //        {
                    //            p++;
                    //            adtbaggageprice += Convert.ToDouble(SearchDetails.Itinerary.Baggages[a].Fee);
                    //            SearchDetails.AdultBaggage = "str";
                    //            SearchDetails.AdultBaggagePrice = adtbaggageprice;
                    //            SearchDetails.AdultBaggageCount = p;
                    //        }
                    //    }
                    //}

                    Count++;
                }
                catch
                {

                }
            }
            for (int i = 0; i < SearchDetails.FlightSearchDetails.paxDetails.children; i++)
            {
                try
                {
                    SearchDetails.Passenger[Count].Title = frm["_ViewModel[0]._ChildM[" + i + "].Title.ID"];
                    SearchDetails.Passenger[Count].FirstName = frm["_ViewModel[0]._ChildM[" + i + "].FirstName"];
                    SearchDetails.Passenger[Count].LastName = frm["_ViewModel[0]._ChildM[" + i + "].LastName"];
                    SearchDetails.Passenger[Count].Gender = frm["_ViewModel[0]._ChildM[" + i + "].Gender.ID"];

                    string sDay = frm["_ViewModel[0]._ChildM[" + i + "].Day.ID"];
                    string sMonth = frm["_ViewModel[0]._ChildM[" + i + "].Month.ID"];
                    string sYear = frm["_ViewModel[0]._ChildM[" + i + "].Year.ID"];
                    SearchDetails.Passenger[Count].DOB = Convert.ToDateTime(sDay + "/" + sMonth + "/" + sYear);
                    SearchDetails.Passenger[Count].Seat = frm["_ViewModel[0]._ChildM[" + i + "].Seat.ID"];
                    SearchDetails.Passenger[Count].SeatName = GetSeat(SearchDetails.Passenger[Count].Seat);
                    SearchDetails.Passenger[Count].Meal = frm["_ViewModel[0]._ChildM[" + i + "].Meal.ID"];
                    SearchDetails.Passenger[Count].MealName = GetSeat(SearchDetails.Passenger[Count].Seat);
                    SearchDetails.Passenger[Count].BaggageCode = frm["_ViewModel[0]._ChildM[" + i + "].BaggageData.ID"];
                    if (frm["_ViewModel[0]._ChildM[" + i + "].Passport"] != null && frm["_ViewModel[0]._ChildM[" + i + "].Passport"] != "")
                    {
                        SearchDetails.Passenger[Count].PassportNo = frm["_ViewModel[0]._ChildM[" + i + "].Passport"];
                    }
                    else
                    {
                        SearchDetails.Passenger[Count].PassportNo = "111111";
                    }
                    if (frm["_ViewModel[0]._ChildM[" + i + "].IssueDate"] != null && frm["_ViewModel[0]._ChildM[" + i + "].IssueDate"] != "")
                    {
                        SearchDetails.Passenger[Count].IssueDate = Convert.ToDateTime(frm["_ViewModel[0]._ChildM[" + i + "].IssueDate"].Replace("/", "-"));
                    }
                    if (frm["_ViewModel[0]._ChildM[" + i + "].ExpiryDate"] != null && frm["_ViewModel[0]._ChildM[" + i + "].ExpiryDate"] != "")
                    {
                        SearchDetails.Passenger[Count].ExpiryDate = Convert.ToDateTime(frm["_ViewModel[0]._ChildM[" + i + "].ExpiryDate"].Replace("/", "-"));
                    }
                    if (frm["_ViewModel[0]._ChildM[" + i + "].Country.ID"] != null && frm["_ViewModel[0]._ChildM[" + i + "].Country.ID"] != "")
                    {
                        SearchDetails.Passenger[Count].CountryCode = frm["_ViewModel[0]._ChildM[" + i + "].Country.ID"];
                    }
                    if (frm["_ViewModel[0]._ChildM[" + i + "].IssueCity"] != null && frm["_ViewModel[0]._ChildM[" + i + "].IssueCity"] != "")
                    {
                        SearchDetails.Passenger[Count].IssueCity = frm["_ViewModel[0]._ChildM[" + i + "].IssueCity"];
                    }


                    //if (SearchDetails.Passenger[Count].BaggageCode != "")
                    //{
                    //    for (int a = 0; a < SearchDetails.Itinerary.Baggages.Count; a++)
                    //    {
                    //        if (SearchDetails.Passenger[Count].BaggageCode == SearchDetails.Itinerary.Baggages[a].BaggageCode)
                    //        {
                    //            c++;
                    //            chdbaggageprice += Convert.ToDouble(SearchDetails.Itinerary.Baggages[a].Fee);
                    //            SearchDetails.ChildBaggage = "str";
                    //            SearchDetails.ChildBaggagePrice = chdbaggageprice;
                    //            SearchDetails.ChildBaggageCount = c;

                    //        }
                    //    }
                    //}
                    Count++;
                }
                catch
                {

                }
            }


            for (int i = 0; i < SearchDetails.FlightSearchDetails.paxDetails.infants; i++)
            {
                try
                {
                    SearchDetails.Passenger[Count].Title = frm["_ViewModel[0]._InfantM[" + i + "].Title.ID"];
                    SearchDetails.Passenger[Count].FirstName = frm["_ViewModel[0]._InfantM[" + i + "].FirstName"];
                    SearchDetails.Passenger[Count].LastName = frm["_ViewModel[0]._InfantM[" + i + "].LastName"];
                    SearchDetails.Passenger[Count].Gender = frm["_ViewModel[0]._InfantM[" + i + "].Gender.ID"];

                    string sDay = frm["_ViewModel[0]._InfantM[" + i + "].Day.ID"];
                    string sMonth = frm["_ViewModel[0]._InfantM[" + i + "].Month.ID"];
                    string sYear = frm["_ViewModel[0]._InfantM[" + i + "].Year.ID"];
                    SearchDetails.Passenger[Count].DOB = Convert.ToDateTime(sDay + "/" + sMonth + "/" + sYear);

                    SearchDetails.Passenger[Count].Seat = frm["_ViewModel[0]._InfantM[" + i + "].Seat.ID"];
                    SearchDetails.Passenger[Count].Meal = frm["_ViewModel[0]._InfantM[" + i + "].Meal.ID"];

                    if (frm["_ViewModel[0]._InfantM[" + i + "].Passport"] != null && frm["_ViewModel[0]._InfantM[" + i + "].Passport"] != "")
                    {
                        SearchDetails.Passenger[Count].PassportNo = frm["_ViewModel[0]._InfantM[" + i + "].Passport"];
                    }
                    else
                    {
                        SearchDetails.Passenger[Count].PassportNo = "111111";
                    }
                    if (frm["_ViewModel[0]._InfantM[" + i + "].IssueDate"] != null && frm["_ViewModel[0]._InfantM[" + i + "].IssueDate"] != "")
                    {
                        SearchDetails.Passenger[Count].IssueDate = Convert.ToDateTime(frm["_ViewModel[0]._InfantM[" + i + "].IssueDate"].Replace("/", "-"));
                    }
                    if (frm["_ViewModel[0]._InfantM[" + i + "].ExpiryDate"] != null && frm["_ViewModel[0]._InfantM[" + i + "].ExpiryDate"] != "")
                    {
                        SearchDetails.Passenger[Count].ExpiryDate = Convert.ToDateTime(frm["_ViewModel[0]._InfantM[" + i + "].ExpiryDate"].Replace("/", "-"));
                    }
                    if (frm["_ViewModel[0]._InfantM[" + i + "].Country.ID"] != null && frm["_ViewModel[0]._InfantM[" + i + "].Country.ID"] != "")
                    {
                        SearchDetails.Passenger[Count].CountryCode = frm["_ViewModel[0]._InfantM[" + i + "].Country.ID"];
                    }
                    if (frm["_ViewModel[0]._InfantM[" + i + "].IssueCity"] != null && frm["_ViewModel[0]._InfantM[" + i + "].IssueCity"] != "")
                    {
                        SearchDetails.Passenger[Count].IssueCity = frm["_ViewModel[0]._InfantM[" + i + "].IssueCity"];
                    }
                    Count++;
                }
                catch
                {

                }
            }

            SearchDetails.Itinerary.GrandTotal = Convert.ToDouble((SearchDetails.Itinerary.GrandTotal + adtbaggageprice + chdbaggageprice));

        }

        public string RedirectToPaymentFltCh(string sIndex, string sProvider, FormCollection frm)
        {
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            string url = string.Empty;
            if (_objFlight.SaveBookingDB(ref SearchDetails, "Incomplete"))
            {
                string temp = frm["Guid"].ToString().Split('~')[0] + "~" + sIndex + "~" + sProvider;
                _objFlight.MailFromPaxDetail(ref SearchDetails);
                SecureQueryString sq = new SecureQueryString();
                sq["sUnique"] = frm["Guid"];
                sq.ExpireTime = DateTime.Now.AddMinutes(30);
                url = urlHelper.Action("Paymentdetail", "Payment", new { q = temp });
            }
            else
            {
                try
                {
                    string strE = "Error occured during insertion in database";

                }
                catch { }
                url = urlHelper.Action("Passenger", new { q = frm["Guid"] });

            }
            return url;
        }
        public string RedirectToPayment(FormCollection frm)
        {
            SaveInDB _SaveInDB = new SaveInDB();
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            string url = string.Empty;
            if (_SaveInDB.SaveBookingInDB(frm["Guid"].Split('~')[0]))
            {
                _objFlight.MailFromPaxDetail(ref SearchDetails);
                SecureQueryString sq = new SecureQueryString();
                sq["sUnique"] = frm["Guid"];
                sq.ExpireTime = DateTime.Now.AddMinutes(30);
                url = urlHelper.Action("Paymentdetail", "Payment", new { q = frm["Guid"] });
            }
            else
            {
                try
                {
                    string strE = "Error occured during insertion in database";
                    // _Email.SendTrnFailedMail("natwar@dial4travel.co.uk", "natwar@dial4travel.co.uk", "E8", strE);
                }
                catch { }
                url = urlHelper.Action("Passenger", new { q = frm["Guid"] });
                //RedirectToAction("Passenger", new { q = frm["Guid"] });
            }
            return url;
        }
        public string RedirectToResult(FormCollection frm)
        {
            var context = new RequestContext(new HttpContextWrapper(System.Web.HttpContext.Current), new RouteData());
            var urlHelper = new UrlHelper(context);
            string url = string.Empty;
            //_objFlight.MailFromPaxDetail(ref SearchDetails);
            url = urlHelper.Action("FlightResult", "Result", new { q = frm["Guid"].Split('~')[0] });

            return url;
        }
        [HttpPost]
        public JsonResult SendIten(string Email, string sUnique)
        {
            var rVal = string.Empty;
            bool b = false; // _Email.SendMail(CompCredentials.OnlineEmail, Email.Trim(), "", "Flight Itinerary Details", MailItinerary(sUnique));
            if (b)
                rVal = "Itinerary Details has been sent!";
            else
                rVal = "Mail not sent Please try again later!";
            return Json(rVal, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
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


        public string GetMeal(string ID)
        {
            string Value = string.Empty;
            switch (ID)
            {
                case "0":
                    Value = "Any";
                    break;
                case "AVML":
                    Value = "Asian Veg";
                    break;
                case "BBML":
                    Value = "Baby/Infant Food";
                    break;
                case "BLML":
                    Value = "Bland Meal";
                    break;
                case "CHML":
                    Value = "Child Meal";
                    break;
                case "DBML":
                    Value = "Diabetic";
                    break;

                case "FPML":
                    Value = "Fruit Meal";
                    break;
                case "GFML":
                    Value = "Gluten Free";
                    break;

                case "HFML":
                    Value = "High Fiber";
                    break;
                case "HNML":
                    Value = "Hindu Meal";
                    break;

                case "KSML":
                    Value = "Kosher";
                    break;
                case "LCML":
                    Value = "Low Calorie";
                    break;

                case "LFML":
                    Value = "Low Cholesterol";
                    break;
                case "LPML":
                    Value = "Low Protein";
                    break;
                case "LSML":
                    Value = "Low Sodium/No Salt";
                    break;
                case "MOML":
                    Value = "Moslem";
                    break;
                case "NLML":
                    Value = "Non-Lactose";
                    break;
                case "ORML":
                    Value = "Oriental";
                    break;
                case "PRML":
                    Value = "Low Purin";
                    break;
                case "RVML":
                    Value = "Raw Vegetarian";
                    break;
                case "SFML":
                    Value = "Seafood";
                    break;
                case "VGML":
                    Value = "Vegetarian/Non Dairy";
                    break;
                case "VLML":
                    Value = "Vegetarian/Milk/Eggs";
                    break;

            }
            return Value;
        }
        public string GetSeat(string ID)
        {
            string Value = string.Empty;
            switch (ID)
            {
                case "0":
                    Value = "Any";
                    break;
                case "A":
                    Value = "Aisle Seat";
                    break;
                case "B":
                    Value = "Bulkhead Seat";
                    break;
                case "C":
                    Value = "Cot";
                    break;
                case "E":
                    Value = "Exit Seat";
                    break;
                case "R":
                    Value = "Rear facing Seat";
                    break;

                case "P":
                    Value = "Upper Deck";
                    break;
                case "W":
                    Value = "Window Seat";
                    break;
            }
            return Value;
        }


    }
}