using TravelSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TravelSite.Models
{
    public class OnlineFlightStructure
    {
        public bool SaveBookingDB(ref SearchDetails SearchDetails, string BookStatus)
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            Random _ORandom = new Random();
            GetSetDatabase GetSetDatabase = new GetSetDatabase();
            string BookingId = Global.GenerateIDs("FS");
            SearchDetails.BookingID = BookingId;
            BookingId = SearchDetails.BookingID;
            //IDGenratorService.IDGenratorService _objId = new IDGenratorService.IDGenratorService();
            dynamic val = HttpContext.Current.Session["Login"];
            string PrefixCode = string.Empty;
            int CompanyId = 1;
            if (val != null)
            {
                SearchDetails.UserID = val.LoginVm.Id;
                //bkngDtl.ModifiedByName = val.LoginVm.Fullname;
                CompanyId = val.LoginVm.CompanyId;
                PrefixCode = val.LoginVm.PrefixCode;
            }

            SearchDetails.CompanyID = "1";
            SearchDetails.Currency = "USD";

            SearchDetails.BookingID = BookingId;
            SearchDetails.ProdID = "1";
            string GeoCode = string.Empty;
            string CountryCode = string.Empty;
            string AirlineChange = string.Empty;
            DataTable dtPax = GetPaxTable(SearchDetails, SearchDetails.ProdID);
            DataTable dtSec = GetSectorTable(SearchDetails);
            DataTable dtAmt = GetAmountTable(SearchDetails);
            string Firstname = dtPax.Rows[0]["FirstName"].ToString();
            string lastname = dtPax.Rows[0]["LastName"].ToString();
            string travelstartdate = dtSec.Rows[0]["FromDateTime"].ToString();

            try
            {
                GeoCode = SearchDetails.Itinerary.Sectors[0].Departure.GeoLocation;
                CountryCode = SearchDetails.Itinerary.Sectors[0].Departure.AirportCountryCode;
            }
            catch { }
            if (!string.IsNullOrEmpty(SearchDetails.Airline_Change))
            {
                AirlineChange = SearchDetails.Airline_Change;
            }
            else
            {
                AirlineChange = SearchDetails.Itinerary.Sectors[0].AirChange;
            }

            List<Sector> sec = (from Sector i in SearchDetails.Itinerary.Sectors
                                where i.IsReturn == false
                                select i).ToList();

            if (dtSec.Rows.Count > 0)
                travelstartdate = dtSec.Rows[0]["FromDateTime"].ToString();
            List<Sector> retsec = (from Sector i in SearchDetails.Itinerary.Sectors
                                   where i.IsReturn == true
                                   select i).ToList();
            string JourneyType = "0";
            if (retsec.Count > 0)
            {
                JourneyType = "1";
            }
            else
                JourneyType = "0";
            //  DuplicateBooking(SearchDetails.Passenger[0].FirstName, SearchDetails.Passenger[0].LastName, sec[0].Departure.AirportCode, sec[sec.Count - 1].Arrival.AirportCode, sec[0].Departure.Date);
            SearchDetails.UserID = 1;
            DatabaseAccess _objDB = new DatabaseAccess();

            return _objDB.InsertFlightBookingDetails(SearchDetails.BookingID, SearchDetails.BookingID, sec[0].Departure.AirportCode, sec[sec.Count - 1].Arrival.AirportCode, BookStatus, "",
                SearchDetails.Itinerary.GrandTotal, "NEW-RESERVATION", SearchDetails.Currency, CompanyId.ToString(), "true", SearchDetails.ProdID,
                 SearchDetails.Itinerary.Provider, "HAPID", "DICT", DateTime.Now.ToString(), BookStatus, "",
                 (SearchDetails.Itinerary.TotalPrice), "", SearchDetails.SourceMedia, "ARF", "", "",
                 JourneyType, SearchDetails.Itinerary.LastTicketingDate, sec[0].Departure.AirportCode, sec[sec.Count - 1].Arrival.AirportCode,
                 SearchDetails.Itinerary.ValCarrier, SearchDetails.Itinerary.Sectors[0].CabinClass.Name, "1", SearchDetails.MobileNo,
                 SearchDetails.PhoneNo, "", SearchDetails.EmailID, SearchDetails.Country, SearchDetails.City, SearchDetails.Address,
                 SearchDetails.PostCode, "Delivery", dtSec, dtAmt, dtPax, AirlineChange, SearchDetails.Itinerary.FareType, SearchDetails.UserID, Firstname, lastname, travelstartdate, SearchDetails.Communication, GeoCode, CountryCode, SearchDetails.TSTTime, SearchDetails.Itinerary.MarkUp);

        }
        public DataTable GetSectorTable(SearchDetails SearchDetail)
        {
            TableStructure _objTable = new TableStructure();
            string TechStop = string.Empty;
            string OperatedBy = string.Empty;
            string status = "HK";
            using (DataTable dtSec = _objTable.SectorDetailTable())
            {
                int iSecID = 1;

                if (SearchDetail.Itinerary != null)
                {
                    foreach (var Sec in SearchDetail.Itinerary.Sectors)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(Sec.TechStopOver.ToString()))
                            {
                                TechStop = Sec.TechStopOver.ToString();
                            }
                            else
                            {
                                TechStop = "";
                            }
                            if (!string.IsNullOrEmpty(Sec.OptrCarrier))
                            {
                                OperatedBy = Sec.OptrCarrier+"-"+ Sec.FltNum;
                            }
                            else
                            {
                                OperatedBy = Sec.AirV.ToUpper() + "-" + Sec.FltNum;
                            }
                        }
                        catch { }
                        if(string.IsNullOrEmpty(Sec.Status))
                        {
                            status = "HK";
                        }
                        else
                        {
                            status = Sec.Status;
                        }
                        try
                        {

                            dtSec.Rows.Add(_objTable.SectorDetailRow(dtSec.NewRow(), iSecID, SearchDetail.BookingID, SearchDetail.ProdID, iSecID.ToString(), Sec.AirV.ToUpper() + "-"+ Sec.FltNum,
                               Sec.Departure.AirportCode.ToUpper(), Convert.ToDateTime(Sec.Departure.Date), Sec.Departure.Time, Sec.Departure.Terminal, Sec.Arrival.AirportCode.ToUpper(), Convert.ToDateTime(Sec.Arrival.Date), Sec.Arrival.Time, Sec.Arrival.Terminal
                               , Sec.Class, SearchDetail.PNR, status.ToUpper(), "EC", OperatedBy.ToUpper(), Convert.ToBoolean(Sec.IsReturn),
                               SearchDetail.UserID));
                        }
                        catch { }

                        iSecID++;
                    }
                }

                return dtSec;
            }
        }
        public DataTable GetPaxTable(SearchDetails SearchDetail, string ProdID)
        {
            TableStructure _objTable = new TableStructure();
            using (DataTable dtPax = _objTable.PassengerDetails())
            {
                int PaxId = 0;
                foreach (Pax pax in SearchDetail.Passenger)
                {
                    PaxId += 1;
                    string Gender = string.Empty;
                    string Title = "MR";
                    if (pax.Title != null)
                    {
                        Title = pax.Title.ToUpper();
                        if (pax.Title.ToUpper() == "MR" || pax.Title.ToUpper() == "MASTER")
                            Gender = "Male";
                        else
                            Gender = "Female";
                    }
                    else
                    {
                        Gender = "Male";
                    }

                    string PaxType = pax.PaxType.ToUpper() == "ADT" || pax.PaxType.ToUpper() == "ADULT" ? "ADT" : (pax.PaxType.ToUpper() == "CHD" || pax.PaxType.ToUpper() == "CHILD" ? "CHD" : (pax.PaxType.ToUpper() == "INF" || pax.PaxType.ToUpper() == "INFANT" ? "INF" : "ADT"));
                    DataRow dr = _objTable.PassengerDetailRow(dtPax.NewRow(), PaxId, SearchDetail.BookingID, ProdID, PaxId.ToString(), PaxType, Title,
                        pax.FirstName.ToUpper(), "", pax.LastName.ToUpper(), pax.DOB, Gender, "", "", "", SearchDetail.UserID);
                    dtPax.Rows.Add(dr);
                }
                return dtPax;
            }
        }
        public DataTable GetAmountTable(SearchDetails SearchDetail)
        {
            TableStructure _objTable = new TableStructure();
            using (DataTable dtAmt = _objTable.AmountDataTable())
            {
                if (SearchDetail.Itinerary != null)
                {
                    AddAdultAmountRow(dtAmt, SearchDetail);
                    if (SearchDetail.Itinerary.ChildInfo.NoChild > 0)
                    {
                        AddChildAmountRow(dtAmt, SearchDetail);
                    }
                    if (SearchDetail.Itinerary.InfantInfo.NoInfant > 0)
                    {
                        AddInfantAmountRow(dtAmt, SearchDetail);
                    }
                    //if (SearchDetail.Itinerary.Provider == "1M" && SearchDetail.Itinerary.ExtraCharges > 0)
                    //{
                    //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "ExtraFee", "NA", SearchDetail.Itinerary.ExtraCharges, SearchDetail.Itinerary.ExtraCharges, "OK", "", "", DateTime.Now));
                    //}

                }
                else
                {
                    AddAdultAmountRow(dtAmt, SearchDetail);

                }
                return dtAmt;
            }
        }

        private void AddAdultAmountRow(DataTable dtAmt, SearchDetails SearchDetail)
        {
            TableStructure _objTable = new TableStructure();
            if (SearchDetail.Itinerary != null)
            {
                //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "ADT", (SearchDetail.Itinerary.AdultInfo.AdtBFare * SearchDetail.Itinerary.AdultInfo.NoAdult + SearchDetail.AdultBaggagePrice), (SearchDetail.Itinerary.AdultInfo.AdtBFare * SearchDetail.Itinerary.AdultInfo.NoAdult + SearchDetail.AdultBaggagePrice), "OK", "", "", DateTime.Now));
                //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "TAX", "ADT", (SearchDetail.Itinerary.AdultInfo.AdTax * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.AdTax * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));
                //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "ADT", (SearchDetail.Itinerary.AdultInfo.MarkUp * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.MarkUp * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));
                //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Commission", "ADT", (SearchDetail.Itinerary.AdultInfo.Commission * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.Commission * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));
                try
                {
                    double Gross = (SearchDetail.Itinerary.AdultInfo.AdtBFare ) + (SearchDetail.Itinerary.AdultInfo.AdTax ); // * SearchDetail.Itinerary.AdultInfo.NoAdult * SearchDetail.Itinerary.AdultInfo.NoAdult
                    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "ADT", (SearchDetail.Itinerary.AdultInfo.AdtBFare ), (SearchDetail.Itinerary.AdultInfo.AdTax ), (SearchDetail.Itinerary.AdultInfo.MarkUp), Gross, SearchDetail.Itinerary.AdultInfo.NoAdult, DateTime.Now, SearchDetail.UserID));

                }
                catch
                {
                    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "ADT", 0, 0, 0, 0, 1, DateTime.Now, SearchDetail.UserID));
                }
                //if (SearchDetail.AdultBaggagePrice > 0)
                //{
                //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "BaggagePrice", "ADT", SearchDetail.AdultBaggagePrice, SearchDetail.AdultBaggagePrice, "OK", "", "", DateTime.Now));
                //}
            }
            else
            {
                //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "ADT", (SearchDetail.MakeGrandTotal), (SearchDetail.MakeGrandTotal), "OK", "", "", DateTime.Now));
                //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "ADT", (SearchDetail.MakeMarkup), (SearchDetail.MakeMarkup), "OK", "", "", DateTime.Now));
                dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "ADT", 0, 0, 0, 0, 1, DateTime.Now, SearchDetail.UserID));
            }
        }
        private void AddChildAmountRow(DataTable dtAmt, SearchDetails SearchDetail)
        {
            TableStructure _objTable = new TableStructure();
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "CHD", (SearchDetail.Itinerary.ChildInfo.ChdBFare * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.ChdBFare * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "TAX", "CHD", (SearchDetail.Itinerary.ChildInfo.CHTax * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.CHTax * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "CHD", (SearchDetail.Itinerary.ChildInfo.MarkUp * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.MarkUp * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Commission", "CHD", (SearchDetail.Itinerary.ChildInfo.Commission * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.Commission * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));

            //if (SearchDetail.ChildBaggagePrice > 0)
            //{
            //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "BaggagePrice", "CHD", SearchDetail.ChildBaggagePrice, SearchDetail.ChildBaggagePrice, "OK", "", "", DateTime.Now));
            //}
            if (SearchDetail.Itinerary.ChildInfo != null)
            {
                try
                {
                    double Gross = (SearchDetail.Itinerary.ChildInfo.ChdBFare) + (SearchDetail.Itinerary.ChildInfo.CHTax);
                    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "CHD", (SearchDetail.Itinerary.ChildInfo.ChdBFare), (SearchDetail.Itinerary.ChildInfo.CHTax), (SearchDetail.Itinerary.ChildInfo.MarkUp), Gross, SearchDetail.Itinerary.ChildInfo.NoChild, DateTime.Now, SearchDetail.UserID));

                }
                catch (Exception ex)
                {
                    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "CHD", 0, 0, 0, 0, 1, DateTime.Now, SearchDetail.UserID));
                }
            }
            else
            {
                dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "CHD", 0, 0, 0, 0, 1, DateTime.Now, SearchDetail.UserID));
            }
        }
        private void AddInfantAmountRow(DataTable dtAmt, SearchDetails SearchDetail)
        {
            TableStructure _objTable = new TableStructure();
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "INF", (SearchDetail.Itinerary.InfantInfo.InfBFare * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.InfBFare * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "TAX", "INF", (SearchDetail.Itinerary.InfantInfo.InTax * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.InTax * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "INF", (SearchDetail.Itinerary.InfantInfo.MarkUp * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.MarkUp * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
            //dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Commission", "INF", (SearchDetail.Itinerary.InfantInfo.Commission * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.Commission * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
            if (SearchDetail.Itinerary.InfantInfo != null && SearchDetail.Itinerary.InfantInfo.NoInfant > 0)
            {
                try
                {
                    double Gross = (SearchDetail.Itinerary.InfantInfo.InfBFare ) + (SearchDetail.Itinerary.InfantInfo.InTax);
                    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "INF", (SearchDetail.Itinerary.InfantInfo.InfBFare), (SearchDetail.Itinerary.InfantInfo.InTax), (SearchDetail.Itinerary.InfantInfo.MarkUp), Gross, SearchDetail.Itinerary.InfantInfo.NoInfant, DateTime.Now, SearchDetail.UserID));
                }
                catch (Exception ex)
                {
                    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "INF", 0, 0, 0, 0, 1, DateTime.Now, SearchDetail.UserID));
                }
            }
            else
            {
                dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), 1, SearchDetail.BookingID, SearchDetail.ProdID, "INF", 0, 0, 0, 0, 1, DateTime.Now, SearchDetail.UserID));
            }

        }
    }
}