using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TravelSite.Models
{
    public class FlightStructure
    {
        public bool SaveBookingDB(ref SearchDetails SearchDetails, string BookStatus)
        {
            SearchDetails.BookingID = FlightSearch.GenerateBookingRef();
            SearchDetails.ProdID = "001";

            DataTable dtPax = null;// GetPaxTable(SearchDetails);
            DataTable dtSec = null;// GetSectorTable(SearchDetails);
            DataTable dtAmt = null;// GetAmountTable(SearchDetails);
            string Firstname = dtPax.Rows[0]["PAX_DTL_Pax_First_Name"].ToString();
            string lastname = dtPax.Rows[0]["PAX_DTL_Pax_Last_Name"].ToString();
            string travelstartdate = dtSec.Rows[0]["SEC_DTL_From_Date_Time"].ToString();
            List<Sector> sec = (from Sector i in SearchDetails.Itinerary.Sectors
                                where i.IsReturn == false
                                select i).ToList();
            DuplicateBooking(SearchDetails.Passenger[0].FirstName, SearchDetails.Passenger[0].LastName, sec[0].Departure.AirportCode, sec[sec.Count - 1].Arrival.AirportCode, sec[0].Departure.Date);

            DatabaseAccess _objDB = new DatabaseAccess();
            string JourneyType = (SearchDetails.FlightSearchDetails.JourneyType == "R" ? "Return" : (SearchDetails.FlightSearchDetails.JourneyType =="O" ? "OneWay" : "MultiCity"));

            return _objDB.InsertFlightBookingDetails(SearchDetails.BookingID, SearchDetails.BookingID, sec[0].Departure.AirportCode, sec[sec.Count - 1].Arrival.AirportCode, BookStatus, "",
                SearchDetails.Itinerary.GrandTotal, "ARF", CompCredentials.Currency, CompCredentials.CompanyId, "true", SearchDetails.ProdID,
                 SearchDetails.Itinerary.Provider, CompCredentials.HapId, "DICT", DateTime.Now.ToString(), BookStatus, "",
                 (SearchDetails.Itinerary.TotalPrice), "", SearchDetails.CompanyName, "ARF", "", "",
                 JourneyType, SearchDetails.Itinerary.LastTicketingDate, sec[0].Departure.AirportCode, sec[sec.Count - 1].Arrival.AirportCode,
                 SearchDetails.Itinerary.ValCarrier, SearchDetails.Itinerary.Sectors[0].CabinClass.Name, "1", SearchDetails.MobileNo,
                 SearchDetails.PhoneNo, "", SearchDetails.EmailID, SearchDetails.Country, SearchDetails.City, SearchDetails.Address,
                 SearchDetails.PostCode, "Delivery", dtSec, dtAmt, dtPax, SearchDetails.Airline_Change, SearchDetails.Itinerary.FareType, 0, Firstname, lastname, travelstartdate);

        }

        //public DataTable GetSectorTable(SearchDetails SearchDetail)
        //{
        //    TableStructure _objTable = new TableStructure();
        //    using (DataTable dtSec = _objTable.SectorDataTable())
        //    {
        //        int iSecID = 1;
        //        foreach (var Sec in SearchDetail.Itinerary.Sectors)
        //        {
        //            dtSec.Rows.Add(_objTable.SectorDataRow(dtSec.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, Sec.AirV.ToUpper(),
        //                Sec.Departure.AirportCode.ToUpper(), Convert.ToDateTime(Sec.Departure.Date + " " + Sec.Departure.Time),
        //                            Sec.Arrival.AirportCode.ToUpper(), Convert.ToDateTime(Sec.Arrival.Date + " " + Sec.Arrival.Time), Sec.FltNum, Sec.Class, Sec.Status,
        //                            "", "", "", "", Sec.Departure.Terminal, Sec.Arrival.Terminal, iSecID.ToString(), "", Sec.ActualTime.ToString(), Sec.ElapsedTime, "", "", Sec.EquipType, Sec.IsReturn, ""));
        //            iSecID++;
        //        }
        //        return dtSec;
        //    }
        //}
        //public DataTable GetPaxTable(SearchDetails SearchDetail)
        //{
        //    TableStructure _objTable = new TableStructure();
        //    using (DataTable dtPax = _objTable.PaxDataTable())
        //    {
        //        foreach (Pax pax in SearchDetail.Passenger)
        //        {
        //            string PaxType = pax.PaxType.ToUpper() == "ADT" || pax.PaxType.ToUpper() == "ADULT" ? "ADT" : (pax.PaxType.ToUpper() == "CHD" || pax.PaxType.ToUpper() == "CHILD" ? "CHD" : (pax.PaxType.ToUpper() == "INF" || pax.PaxType.ToUpper() == "INFANT" ? "INF" : "ADT"));
        //            DataRow dr = _objTable.PaxDataRow(dtPax.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, pax.PaxId.ToString(), pax.Title.ToUpper(),
        //                pax.FirstName.ToUpper(), "", pax.LastName.ToUpper(), "", "", "", Convert.ToDateTime("01/01/1900"), "", "", pax.DOB, PaxType, "");
        //            dtPax.Rows.Add(dr);
        //        }
        //        return dtPax;
        //    }
        //}
        //public DataTable GetAmountTable(SearchDetails SearchDetail)
        //{

        //    TableStructure _objTable = new TableStructure();
        //    using (DataTable dtAmt = _objTable.AmountDataTable())
        //    {
        //        AddAdultAmountRow(dtAmt, SearchDetail);
        //        if (SearchDetail.Itinerary.ChildInfo.NoChild > 0)
        //        {
        //            AddChildAmountRow(dtAmt, SearchDetail);
        //        }
        //        if (SearchDetail.Itinerary.InfantInfo.NoInfant > 0)
        //        {
        //            AddInfantAmountRow(dtAmt, SearchDetail);
        //        }

        //        dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "SAFI", "NA", Convert.ToDouble(SearchDetail.Itinerary.Safi), Convert.ToDouble(SearchDetail.Itinerary.Safi), "OK", "SAFI", "", DateTime.Now));

        //        return dtAmt;
        //    }
        //}

        //private void AddAdultAmountRow(DataTable dtAmt, SearchDetails SearchDetail)
        //{
        //    TableStructure _objTable = new TableStructure();
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "ADT", (SearchDetail.Itinerary.AdultInfo.AdtBFare * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.AdtBFare * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "TAX", "ADT", (SearchDetail.Itinerary.AdultInfo.AdTax * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.AdTax * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "ADT", (SearchDetail.Itinerary.AdultInfo.MarkUp * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.MarkUp * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Commission", "ADT", (SearchDetail.Itinerary.AdultInfo.Commission * SearchDetail.Itinerary.AdultInfo.NoAdult), (SearchDetail.Itinerary.AdultInfo.Commission * SearchDetail.Itinerary.AdultInfo.NoAdult), "OK", "", "", DateTime.Now));

        //    if (SearchDetail.AdultBaggagePrice > 0)
        //    {
        //        dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "BaggagePrice", "ADT", SearchDetail.AdultBaggagePrice, SearchDetail.AdultBaggagePrice, "OK", "", "", DateTime.Now));
        //    }

        //}
        //private void AddChildAmountRow(DataTable dtAmt, SearchDetails SearchDetail)
        //{
        //    TableStructure _objTable = new TableStructure();
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "CHD", (SearchDetail.Itinerary.ChildInfo.ChdBFare * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.ChdBFare * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "TAX", "CHD", (SearchDetail.Itinerary.ChildInfo.CHTax * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.CHTax * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "CHD", (SearchDetail.Itinerary.ChildInfo.MarkUp * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.MarkUp * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Commission", "CHD", (SearchDetail.Itinerary.ChildInfo.Commission * SearchDetail.Itinerary.ChildInfo.NoChild), (SearchDetail.Itinerary.ChildInfo.Commission * SearchDetail.Itinerary.ChildInfo.NoChild), "OK", "", "", DateTime.Now));

        //    if (SearchDetail.ChildBaggagePrice > 0)
        //    {
        //        dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "BaggagePrice", "CHD", SearchDetail.ChildBaggagePrice, SearchDetail.ChildBaggagePrice, "OK", "", "", DateTime.Now));
        //    }
        //}
        //private void AddInfantAmountRow(DataTable dtAmt, SearchDetails SearchDetail)
        //{
        //    TableStructure _objTable = new TableStructure();
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "FARE", "INF", (SearchDetail.Itinerary.InfantInfo.InfBFare * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.InfBFare * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "TAX", "INF", (SearchDetail.Itinerary.InfantInfo.InTax * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.InTax * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Markup", "INF", (SearchDetail.Itinerary.InfantInfo.MarkUp * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.MarkUp * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));
        //    dtAmt.Rows.Add(_objTable.AmountDataRow(dtAmt.NewRow(), SearchDetail.BookingID, SearchDetail.ProdID, "Commission", "INF", (SearchDetail.Itinerary.InfantInfo.Commission * SearchDetail.Itinerary.InfantInfo.NoInfant), (SearchDetail.Itinerary.InfantInfo.Commission * SearchDetail.Itinerary.InfantInfo.NoInfant), "OK", "", "", DateTime.Now));

        //}

        private void DuplicateBooking(string sFName, string sLName, string sOrg, string sDest, string DepDate)
        {
            try
            {
                //BookingUpdation.BookingUpdation _objUpdate = new BookingUpdation.BookingUpdation();                
                //if (_objUpdate.MarkDuplicateBooking(sFName, sLName, sOrg, sDest, Convert.ToDateTime(DepDate).ToString("yyyy-MM-dd"), CompCredentials.CompanyId))
                //{
                //    int i = 1;
                //}
                //else
                //{
                //    int i = 0;
                //}
            }
            catch { }
        }

        public string BookingDetails(string Guid)
        {
            SearchDetails SearchDetails = SearchDetails.Current(Guid);
            List<Sector> SectorDept = new List<Sector>();
            List<Sector> SectorRet = new List<Sector>();

            for (int j = 0; j < SearchDetails.Itinerary.Sectors.Count; j++)
            {
                if (SearchDetails.Itinerary.Sectors[j].IsReturn)
                    SectorRet.Add(SearchDetails.Itinerary.Sectors[j]);
                else
                    SectorDept.Add(SearchDetails.Itinerary.Sectors[j]);
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("<table width='800' border='0' align='center' cellpadding='0' cellspacing='0' style='font-size: 12px; font-family: Arial, Helvetica, sans-serif; color:#000;'>" +
        "<tr>" +
            "<td style='padding: 20px; border: #e6e6e6 solid 1px;'>" +
                "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                    "<tr>" +
                        "<td>" +
                            "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                "<tr>" +
                                    "<td align='left' valign='top'>" +
                                        "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                            "<tr>" +
                                                "<td>" +
                                                    "<img src='" + CompCredentials.WebsiteUrl + "images/Logo.png' style='width:300px; height:46px;' alt='logo' />" +
                                               " </td>" +
                                            " </tr>" +
                                            "<tr>" +
                                                "<td valign='top' style='font-size: 11px; font-family: Arial, Helvetica, sans-serif;'>" +
                                                    "2440 broad way suite 219," +
                                                    "New York NY 10024<br />" +
                                                   // "<small class='pink-text'>Registration:</small>" +
                                                   //" Company Regd no. 09162028 (Regd in England)<br />" +
                                                    "<small class='pink-text'>Telephone: </small>" +
                                                    WebsiteStaticData.ContactNo1 +
                                               " </td>" +
                                            " </tr>" +
                                        "</table>" +
                                   " </td>" +
                                    "<td width='20' align='left' valign='top'>&nbsp;</td>" +
                                    "<td align='right' valign='middle' style='font-size: 16px; font-weight: bold; color: #333333; font-family: Arial, Helvetica, sans-serif; text-transform: uppercase;'>ONLINE BOOKING CONFIRMATION FOR FLIGHT</td>" +
                                " </tr>" +
                            "</table>" +
                       " </td>" +
                    " </tr>" +
                    "<tr>" +
                        "<td>&nbsp;</td>" +
                    " </tr>");
            if (SearchDetails.BookingStatus == "2")
            {
                sb.Append("<tr>" +
                            "<td><p>Thank you for allowing us the opportunity in assisting you with your forthcoming trip.</p>" +
                            "<p>Your reservation is booked, and tickets confirmed. Tickets will be sent to the email address you supplied within 24 hours.</p>" +
                             "<p>If you have not received your tickets after this time, or you require any further assistance, please contact us on " + WebsiteStaticData.ContactNo1 + " or email support@faressaver.com</p>" +
                            "</td>" +
                        " </tr>" +
                        "<tr>" +
                            "<td>&nbsp;</td>" +
                        " </tr>");
            }
            else if (SearchDetails.BookingStatus == "option")
            {
                sb.Append("<tr>" +
                            "<td>Your booking is under process of Airline confirmation. Please accept our apologies for the inconvenience. For more information please call our customer care team for further information on " + WebsiteStaticData.ContactNo1 + "</td>" +
                        " </tr>" +
                        "<tr>" +
                            "<td>&nbsp;</td>" +
                        " </tr>");
            }
            sb.Append("<tr>" +
                        "<td>" +
                            "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                "<tr>" +
                                    "<td width='32' align='left' valign='middle'>" +
                                        "<img src='" + CompCredentials.WebsiteUrl + "images/airplane-ico.png' style='width:32px; height:32px;' />" +
                                   " </td>" +
                                    "<td width='10' align='left' valign='middle'>&nbsp;</td>" +
                                    "<td align='left' valign='middle' style='font-size: 18px; color: #333333; font-weight: bold;'>Booking reference</td>" +
                                " </tr>" +
                            "</table>" +
                       " </td>" +
                    " </tr>" +
                    "<tr>" +
                        "<td>" +
                            "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                "<tr>" +
                                    "<td align='left' valign='top' style='background: #e6e6e6;'>" +
                                        "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                            "<tr>" +
                                                "<td align='left' valign='top' style='background: #333333; border-bottom: #FFF solid 1px; color: #FFF; padding: 5px 10px; font-size: 12px; font-weight: bold; font-family: Arial, Helvetica, sans-serif;'>Reservation Number</td>" +
                                            " </tr>" +
                                            "<tr>" +
                                                "<td align='left' valign='top' style='padding: 10px;'>" +
                                                    // <!--passenger contact-->
                                                    "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                                        "<tr>" +
                                                            "<td align='center' valign='middle' style='background: #FFF; border: #000 solid 1px; color: #F90; font-size: 18px; font-weight: bold; text-transform: uppercase; padding: 5px 10px;'>" + SearchDetails.BookingID + "</td>" +
                                                            "<td width='10' align='left' valign='middle'>&nbsp;</td>" +
                                                            "<td align='center' valign='middle'>" +
                                                                "<img src='" + CompCredentials.WebsiteUrl + "images/barcode.png' style='width:100px; height:45px;' />" +
                                                           " </td>" +
                                                        " </tr>" +
                                                        "<tr>" +
                                                            "<td align='left' valign='middle'>&nbsp;</td>" +
                                                            "<td width='10' align='left' valign='middle'>&nbsp;</td>" +
                                                            "<td align='left' valign='middle'>&nbsp;</td>" +
                                                        " </tr>" +
                                                        "<tr>" +
                                                            "<td align='left' valign='middle'>Name</td>" +
                                                            "<td width='10' align='left' valign='middle'>:</td>" +
                                                            "<td align='left' valign='middle'>" + SearchDetails.Passenger[0].Title.ToUpper() + " " + SearchDetails.Passenger[0].FirstName.ToUpper() + " " + SearchDetails.Passenger[0].LastName.ToUpper() + "</td>" +
                                                        " </tr>" +

                                                        "<tr>" +
                                                            "<td align='left' valign='middle'>Phone No</td>" +
                                                            "<td width='10' align='left' valign='middle'>:</td>" +
                                                            "<td align='left' valign='middle'>" + SearchDetails.MobileNo + "</td>" +
                                                        " </tr>") ;
            if (!string.IsNullOrEmpty(SearchDetails.PhoneNo))
            {
                sb.Append("<tr>" +
                   "<td align='left' valign='middle'>Alternate Phone</td>" +
                   "<td width='10' align='left' valign='middle'>:</td>" +
                   "<td align='left' valign='middle'>" + SearchDetails.PhoneNo + "</td>" +                  
                  "</tr>");
            }
            sb.Append("<tr>" +
                                                            "<td align='left' valign='middle'>Email Address</td>" +
                                                            "<td align='left' valign='middle'>:</td>" +
                                                            "<td align='left' valign='middle'>" + SearchDetails.EmailID + "</td>" +
                                                        " </tr>" +
                                                        "<tr>" +
                                                            "<td align='left' valign='middle'>Booking Date</td>" +
                                                            "<td align='left' valign='middle'>:</td>" +
                                                            "<td align='left' valign='middle'>" + DateTime.Today.ToString("dd MMM yyyy") + "</td>" +
                                                        " </tr>" +

                                                    "</table>" +
                                               " </td>" +
                                            " </tr>" +
                                        "</table>" +
                                   " </td>" +
                                    "<td width='10' align='left' valign='top'>&nbsp;</td>" +
                                    "<td align='left' valign='top' style='background: #e6e6e6;'>" +

                                        "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                            "<tr>" +
                                                "<td style='background: #ED8323; border-bottom: #FFF solid 1px; color: #FFF; padding: 5px 10px; font-size: 12px; font-weight: bold; font-family: Arial, Helvetica, sans-serif;'>Name of Passenger(s)</td>" +
                                            " </tr>" +
                                            "<tr>" +
                                                "<td style='padding: 10px;'>" +
                                                    "<table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            //Passenegr details
            for (int i = 0; i < SearchDetails.Passenger.Count; i++)
            {
                sb.Append("<tr>" +
                            "<td height='30' align='left' valign='middle'>" +
                              "<img src='" + CompCredentials.WebsiteUrl + "images/pax.png' width='24' height='24' />" +
                                " </td>" +
                                 "<td width='5' height='30' align='left' valign='middle'>&nbsp;</td>" +
                                 "<td height='30' align='left' valign='middle'>" + SearchDetails.Passenger[i].Title.ToUpper() + " " + SearchDetails.Passenger[i].FirstName.ToUpper() + " " + SearchDetails.Passenger[i].LastName.ToUpper() + "</td>" +
                                   " </tr>");

            }


            sb.Append("</table>" +
              " </td>" +
           " </tr>" +
       "</table>" +
  " </td>" +
" </tr>" +
"</table>" +
" </td>" +
" </tr>" +
"<tr>" +
"<td>&nbsp;</td>" +
" </tr>" +
"<tr>" +
"<td>" +
"<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
"<tr>" +
   "<td width='32' align='left' valign='middle'>" +
       "<img src='" + CompCredentials.WebsiteUrl + "images/airplane-ico.png' style='width:32px; height:32px;' />" +
  " </td>" +
   "<td width='10' align='left' valign='middle'>&nbsp;</td>" +
   "<td align='left' valign='middle' style='font-size: 18px; color: #333333; font-weight: bold;'>Your flight itinerary</td>" +
   "<td width='250' align='center' valign='middle' style='background: #FFF; border: #000 solid 1px; color: #F90; font-size: 18px; font-weight: bold; text-transform: uppercase; padding: 5px 10px;'>" + (string.IsNullOrEmpty(SearchDetails.PNR) ? "" : "PNR NUMBER: " + SearchDetails.PNR) + "</td>" +
" </tr>" +
"</table>" +
" </td>" +
" </tr>" +
"<tr>" +
"<td style='background: #eeeeee;'>" +
// <!--Itinerary Details-->
"<table class='table table-bordered' width='100%' cellpadding='5'>" +
"<thead>" +
   "<tr>" +
      " <th align='left' valign='middle' style='background: #ED8323'>Date</th>" +
       "<th align='left' valign='middle' style='background: #ED8323'>Flight Number</th>" +
       "<th align='left' valign='middle' style='background: #ED8323'>Departing</th>" +
       "<th align='left' valign='middle' style='background: #ED8323'>Arriving</th>" +
   " </tr>" +
"</thead>" +
"<tbody>");
            foreach (Sector Its in SearchDetails.Itinerary.Sectors)
            {
                sb.Append("<tr>" +
                      "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                          "<strong>" + Convert.ToDateTime(Its.Departure.Date).ToString("ddd, dd MMM yyyyy") + "</strong><br />" +
                          "<img src='" + CompCredentials.WebsiteUrl + "images/barcode.png' style='width:100px height:45px' />" +
                     " </td>" +
                      "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                          "<p>" + Its.AirlineName + " (" + Its.CabinClass.Name + ")</p>" +
                          Its.AirV + Its.FltNum);
                if (Its.OptrCarrierDes != "")
                {
                    sb.Append("<p><small>Operated by " + Its.OptrCarrierDes + "</small></p>");
                }
                sb.Append(" </td>" +
                                                       "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                                                           "<strong>" + Its.Departure.AirportCityName + "</strong>" +
                                                           "<p>" +
                                                           Its.Departure.AirportName + "(" + Its.Departure.AirportCode + ")" + "<br />" +
                                                                Its.Departure.Time +

                                                           "</p>" +
                                                      " </td>" +
                                                       "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'>" +
                                                           "<strong>" + Its.Arrival.AirportCityName + "</strong>" +
                                                           "<p>" +
                                                            Its.Arrival.AirportName + "(" + Its.Arrival.AirportCode + ")" + "<br />" +
                                                               Its.Arrival.Time +

                                                           "</p>" +
                                                      " </td>" +
                                                   " </tr>");
            }
            try
            {
                //baggage info
                sb.Append("<tr>" +
                    "<td  colspan='4' align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                    "<strong>Baggage Included : </strong> " + SearchDetails.Itinerary.Sectors[0].Baggage_Info.Description + " per adult" +

                    " </td>" +
                    "</tr>");
            }
            catch { }

            sb.Append("</tbody>" +
                                        "</table>" +
                                   " </td>" +
                                " </tr>" +
                                "<tr>" +
                                    "<td>&nbsp;</td>" +
                                " </tr>" +
                                "<tr>" +
                                    "<td>" +
                                        "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                                            "<tr>" +
                                                "<td width='32' align='left' valign='middle'>" +
                                                    "<img src='" + CompCredentials.WebsiteUrl + "images/pax.png' width='24' height='24' />" +
                                               " </td>" +
                                                "<td width='10' align='left' valign='middle'>&nbsp;</td>" +
                                                "<td align='left' valign='middle' style='font-size: 18px; color: #333333; font-weight: bold;'>Pricing Details</td>" +

                                            " </tr>" +
                                        "</table>" +
                                   " </td>" +
                                " </tr>" +
                                "<tr>" +
                                    "<td style='background: #eeeeee;'>" +
                                        //<!--Pricing Details-->
                                        "<table class='table table-bordered' width='100%' cellpadding='5'>" +
                                            "<thead>" +
                                                "<tr>" +
                                                    "<th align='left' valign='middle' style='background: #ED8323'>Fare Type</th>" +
                                                    "<th align='left' valign='middle' style='background: #ED8323'>Fare Per Person </th>" +
                                                    "<th align='left' valign='middle' style='background: #ED8323'>No. of Passenger</th>" +
                                                    "<th align='left' valign='middle' style='background: #ED8323'>Total Fare </th>" +
                                                " </tr>" +
                                            "</thead>" +
                                            "<tbody>");

            //foreach (var p in SearchDetails.Itinerary.Passengers)
            //{
            if (SearchDetails.Itinerary.AdultInfo.NoAdult>0)
            {
                sb.Append("<tr>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Adult</td>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                     SearchDetails.Itinerary.Currency + (SearchDetails.Itinerary.AdultInfo.AdtBFare + SearchDetails.Itinerary.AdultInfo.AdTax + SearchDetails.Itinerary.AdultInfo.MarkUp + SearchDetails.Itinerary.AdultInfo.Commission + SearchDetails.Itinerary.AdultInfo.Safi) +
                " </td>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                     "<strong>" + SearchDetails.Itinerary.AdultInfo.NoAdult + " </strong>" +
                     "</p>" +
                " </td>" +
                 "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.Currency + (SearchDetails.Itinerary.AdultInfo.NoAdult * +(SearchDetails.Itinerary.AdultInfo.AdtBFare + SearchDetails.Itinerary.AdultInfo.AdTax + SearchDetails.Itinerary.AdultInfo.MarkUp + SearchDetails.Itinerary.AdultInfo.Commission + SearchDetails.Itinerary.AdultInfo.Safi)) + " </strong></td>" +
             " </tr>");

            }
            if (SearchDetails.Itinerary.ChildInfo.NoChild > 0)
            {
                sb.Append("<tr>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Child</td>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                     SearchDetails.Itinerary.Currency + (SearchDetails.Itinerary.ChildInfo.ChdBFare + SearchDetails.Itinerary.ChildInfo.CHTax + SearchDetails.Itinerary.ChildInfo.MarkUp + SearchDetails.Itinerary.ChildInfo.Commission + SearchDetails.Itinerary.ChildInfo.Safi) +
                " </td>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                     "<strong>" + SearchDetails.Itinerary.ChildInfo.NoChild + " </strong>" +
                     "</p>" +
                " </td>" +
                 "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.Currency + (SearchDetails.Itinerary.ChildInfo.NoChild * +(SearchDetails.Itinerary.ChildInfo.ChdBFare + SearchDetails.Itinerary.ChildInfo.CHTax + SearchDetails.Itinerary.ChildInfo.MarkUp + SearchDetails.Itinerary.ChildInfo.Commission + SearchDetails.Itinerary.ChildInfo.Safi)) + " </strong></td>" +
             " </tr>");
            }
            if (SearchDetails.Itinerary.InfantInfo.NoInfant > 0)
            {
                sb.Append("<tr>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Child</td>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                     SearchDetails.Itinerary.Currency + (SearchDetails.Itinerary.InfantInfo.InfBFare + SearchDetails.Itinerary.InfantInfo.InTax + SearchDetails.Itinerary.InfantInfo.MarkUp + SearchDetails.Itinerary.InfantInfo.Commission + SearchDetails.Itinerary.InfantInfo.Safi) +
                " </td>" +
                 "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                     "<strong>" + SearchDetails.Itinerary.InfantInfo.NoInfant + " </strong>" +
                     "</p>" +
                " </td>" +
                 "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.Currency + (SearchDetails.Itinerary.InfantInfo.NoInfant * +(SearchDetails.Itinerary.InfantInfo.InfBFare + SearchDetails.Itinerary.InfantInfo.InTax + SearchDetails.Itinerary.InfantInfo.MarkUp + SearchDetails.Itinerary.InfantInfo.Commission + SearchDetails.Itinerary.InfantInfo.Safi)) + " </strong></td>" +
             " </tr>");
            }
            sb.Append("</tbody>" +
                            "</table>" +
                       " </td>" +
                    " </tr>" +
                    "<tr>" +
                        "<td>&nbsp;</td>" +
                    " </tr>");
            if (SearchDetails.BookingStatus.ToLower() != "2")
            {
                sb.Append("<tr>" +
         "<td valign='top' align='left' style='background: #FFF; padding: 5px; border: #dedcda solid 1px; padding: 5px; font-size: 13px;'>" +
             "<table width='100%' cellspacing='0' cellpadding='0' border='0'>" +
                 "<tbody>" +

                     "<tr>" +
                         "<td height='10' colspan='2'></td>" +
                     " </tr>" +
                     "<tr>" +
                         "<td width='21%' class='black_conf'>" +
                             "<strong>Total</strong>" +
                        " </td>" +
                         "<td width='79%'>" +
                              SearchDetails.Itinerary.Currency + SearchDetails.Itinerary.GrandTotal + "<span></span>" +
                        " </td>" +
                     " </tr>" +
                     "<tr>" +
                         "<td height='10' colspan='2'></td>" +
                     " </tr>" +
                     "<tr>" +
                         "<td>" +
                             "<strong><span></span>&nbsp;Card Charge</strong>" +
                        " </td>" +
                         "<td>" +
                      SearchDetails.Itinerary.Currency + SearchDetails.CardCharge + "<span></span>" +
                        " </td>" +
                     " </tr>" +
                     "<tr>" +
                         "<td height='10' colspan='2'></td>" +
                     " </tr>" +
                     "<tr>" +
                         "<td class='black_conf'>" +
                             "<strong>Total for Services</strong>" +
                        " </td>" +
                         "<td>" +
                              SearchDetails.Itinerary.Currency + SearchDetails.Itinerary.GrandTotal.ToString("f2") + "<span></span>" +
                        " </td>" +
                     " </tr>" +
                 "</tbody>" +
             "</table>" +
        " </td>" +
     " </tr>");
            }

            sb.Append("<tr>" +
                "<td><br/><br/><b>Booking Terms and Conditions</b></td>" +
            " </tr>" +
            "<tr>" +
                "<td><ul style='line-height: 20px;'>" +
                "<li>Tickets are non-changeable and non-refundable, unless specified. Please contact us on the above number for a detailed description of ticket conditions.</li>" +
                "<li>Local authorities in certain countries may impose additional taxes (tourist tax, etc.), which will require payment to be made locally. The customer is exclusively responsible for paying any such additional taxes. The tax fee amount may change between original booking date and stay dates. In all events of local tax increases, you will always be liable to pay tax fees at the higher rate.</li>" +
                "<li>It is the passenger own responsibility to ensure that all travel documentation is correct. Please note, for passengers travelling on a one-way ticket, most countries will not allow entry without the relevant visas or documentation. For all passengers having a connecting flight via a third country, even though you are not staying in this third country, you may also require a transit visa. For further information, please contact the consulate of the country you are travelling through. For the most up to date information on visas, passports, health and travel advice worldwide, please visit the web sites of UK Visas, Home Office and the Foreign and Commonwealth Office.</li>" +
                "<li>Please note that you must have a valid Passport having a minimum of 6 months before expiry after travel has been completed, or you will not be permitted to travel. Your passport must be clearly legible and in excellent condition. Presenting a damaged passport at check-in may mean you are unable to travel. For travel to the USA it is mandatory to possess a machine-readable passport or valid visa for travel; otherwise you will be denied boarding. Details of the airline flight numbers/schedules and destination airport will be shown on your invoice/confirmation.Please note that a flight described as “direct” will not necessarily be non-stop. Flight schedules may change at any time and provided there is enough time to do so, we will advise you of any changes prior to departure. However, we strongly recommend you reconfirm your reservations on all flights during your journey, at least 72 hours prior to departure of each flight.We cannot accept any responsibility for delays or missed flights. If you wish to change any item on you flight itinerary, other than increasing the number of persons in your party, providing we can accommodate the change, you must confirm the change in writing and pay an amendment fee of USD 75 per item changed, plus the airline/supplier charges applicable to their ticket terms & conditions.Occasionally we are required to collect additional taxes.You will be informed of any additional taxes prior to ticket issuance.Once tickets have been issued, most airlines do not allow any changes. In all cases, a complete name change is not possible, which means tickets cannot be transferred to someone else. However, in most situations a name correction can be made, depending upon the supplier/airline’s conditions. For full terms and conditions, please use this link: <a href='https://www.Faressaver.com/terms-conditions' target='_blank'> https://www.Faressaver.com/terms-conditions</a> </li>" +
                "</ul></td>" +
            " </tr>" +
            "<tr>" +
                "<td style='padding: 10px 0px;'>" +
                    "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                        "<tr>" +
                            "<td width='250' align='left' valign='middle'>" +
                                "<a href='/'><img src='" + CompCredentials.WebsiteUrl + "images/booking-home.png' style='width:90px; height:34px;' border='0' /></a>" +
                           " </td>" +
                            "<td align='center'>" +
                                "<a href='#'><img class='printMe' src='" + CompCredentials.WebsiteUrl + "images/booking-print.png' style='width:90px; height:34px;' border='0' /></a>" +
                           " </td>" +
                            "<td align='right'>" +
                                "<a href='/'><img src='" + CompCredentials.WebsiteUrl + "images/another-booking.png' style='width:213px; height:34px;' border='0' /></a>" +
                           " </td>" +
                        " </tr>" +
                    "</table>" +
               " </td>" +
            " </tr>" +
        "</table>" +
   " </td>" +
" </tr>" +
"</table>");

           

            return sb.ToString();

        }



        public void MailFromPaxDetail(ref SearchDetails _objSearch)
        {
            //Mails.Mails email = new Mails.Mails();
            //try
            //{
            //    email.SendMail(CompCredentials.OnlineEmail, CompCredentials.OnlineEmail, "", "Online Booking without Payment (Fares Saver)", GetMailBody(ref _objSearch));
            //}
            //catch { }
        }


        
    }
}
