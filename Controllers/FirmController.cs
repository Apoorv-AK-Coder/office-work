using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelSite.Models;

namespace TravelSite.Controllers
{
    public class FirmController : Controller
    {
        // GET: Firm
        //SearchDetails _objSearch;
        BookingConfirm ObjBook = new BookingConfirm();
        public WebsiteContactDetails WCD = null;
        public string media { set; get; }
        public string key { set; get; }

        SearchDetails _ObjSearch;

        public ActionResult Firm(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                _ObjSearch = SearchDetails.Current(q.Split('~')[0]);
                if (_ObjSearch != null)
                {
                    ObjBook.Email = _ObjSearch.EmailID;
                    ObjBook.MobileNo = _ObjSearch.MobileNo;
                    ObjBook.Phone = _ObjSearch.PhoneNo;
                    ObjBook.Address = _ObjSearch.Address;
                    ObjBook.BookingRef = _ObjSearch.BookingID;
                    ObjBook.GrandTotal = _ObjSearch.Itinerary.GrandTotal;
                    ObjBook.Itinerary = _ObjSearch.Itinerary;
                    ObjBook.Pax = _ObjSearch.Passenger;
                    ObjBook.PNR = _ObjSearch.PNR;
                    ObjBook.CardCharge = _ObjSearch.CardCharge;
                    ObjBook.PaymentCallbackDetails = _ObjSearch.PaymentCallbackDetails;
                    ObjBook.KayakClickID = _ObjSearch.KayakClickID;
                    ObjBook.BookingStatus = _ObjSearch.BookingStatus;
                    ObjBook.Guid = q.Split('~')[0];

                    if (!string.IsNullOrEmpty(ObjBook.KayakClickID) && ObjBook.KayakClickID.Contains("@"))
                    {
                        string[] clickID = ObjBook.KayakClickID.Split('@');

                        string hap = clickID[1];
                        string cID = clickID[0];
                        if (hap.ToUpper() == "TJ_WEGO" && (cID != null && cID != ""))
                        {
                            if (ObjBook.BookingStatus.ToLower() == "option")
                                ObjBook.wegoid = "https://secure.wego.com/analytics/v2/conversions?conversion_id=c-wego-Faressaver.com&click_id=" + cID + "&comm_currency_code=USD&bv_currency_code=" + ObjBook.Itinerary.Currency + "&transaction_id=" + ObjBook.BookingRef + "&commission=10&total_booking_value=" + ObjBook.Itinerary.GrandTotal + "&status=pending width = '1' height = '1' border = '0' alt = '' >";

                            else
                                ObjBook.wegoid = "https://secure.wego.com/analytics/v2/conversions?conversion_id=c-wego-Faressaver.com&click_id=" + cID + "&comm_currency_code=USD&bv_currency_code=" + ObjBook.Itinerary.Currency + "&transaction_id=" + ObjBook.BookingRef + "&commission=10&total_booking_value=" + ObjBook.Itinerary.GrandTotal + "&status=confirmed width = '1' height = '1' border = '0' alt = '' >";

                        }
                        if ((hap.ToUpper() == "TJ_MMD" && (cID != null && cID != "")))
                        {
                            ObjBook.kayakid = "https://www.kayak.com/s/kayakpixel/confirm/FaressaverUKMMG?kayakclickid=" + cID + "&price=" + ObjBook.Itinerary.GrandTotal + "&currency=" + ObjBook.Itinerary.Currency + "&confirmation=" + ObjBook.BookingRef + "&rand=" + ObjBook.Guid + "/>";
                        }
                    }
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

            return View(ObjBook);
        }

        public ActionResult Decline(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                _ObjSearch = SearchDetails.Current(q.Split('~')[0]);
                if (_ObjSearch != null)
                {
                    ObjBook.Email = _ObjSearch.EmailID;
                    ObjBook.MobileNo = _ObjSearch.MobileNo;
                    ObjBook.Phone = _ObjSearch.PhoneNo;
                    ObjBook.Address = _ObjSearch.Address;
                    ObjBook.BookingRef = _ObjSearch.BookingID;
                    ObjBook.GrandTotal = _ObjSearch.Itinerary.GrandTotal;
                    ObjBook.Itinerary = _ObjSearch.Itinerary;
                    ObjBook.Pax = _ObjSearch.Passenger;
                    ObjBook.PNR = _ObjSearch.PNR;
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

            return View(ObjBook);
        }
    }
}