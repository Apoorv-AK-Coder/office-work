using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelSite.Models;
using TravelSite.ViewModels;

namespace TravelSite.Controllers
{
    public class FlightEnquiryController : Controller
    {
        // GET: FlightEnquiry
        SearchDetails SearchDetails;
        Enquiry _objEnq = new Enquiry();
        FareQuotesDetails FQD = new FareQuotesDetails();
        public ActionResult Enquiry(string q)
        {
            SearchDetails = SearchDetails.Current(q);
            _objEnq.Guid = q;

            //List<Sector> SectorDept = new List<Sector>();
            //List<Sector> SectorRet = new List<Sector>();
            //if (SearchDetails != null)
            //{
            //    for (int j = 0; j < SearchDetails.Itinerary.Sectors.Count; j++)
            //    {
            //        if (SearchDetails.Itinerary.Sectors[j].IsReturn == false)
            //            SectorDept.Add(SearchDetails.Itinerary.Sectors[j]);
            //        else
            //            SectorRet.Add(SearchDetails.Itinerary.Sectors[j]);
            //    }

            //    SecureQueryString qs = new SecureQueryString();
            //    qs["isPrev"] = "YES";
            //    qs.ExpireTime = DateTime.Now.AddMinutes(120);
            //    qs["From"] = SearchDetails.Itinerary.Sectors[0].Departure.AirportCode;
            //    qs["DestfromName"] = SearchDetails.Itinerary.Sectors[0].Departure.AirportCityName;
            //    if (SearchDetails.FlightSearchDetails.segments.Count == 2)
            //    {
            //        qs["To"] = SectorRet[0].Departure.AirportCode;
            //        qs["DesttoName"] = SectorRet[0].Departure.AirportCityName;
            //        qs["ITravel_DateStart"] = SectorRet[0].Departure.Date;
            //        qs["ITravel_DateEnd"] = "";
            //    }
            //    else
            //    {
            //        qs["To"] = "";
            //        qs["DesttoName"] = "";
            //        qs["ITravel_DateStart"] = "";
            //        qs["ITravel_DateEnd"] = "";
            //    }
            //    qs["Airline_Name"] = SectorDept[0].AirlineName;
            //    qs["Airline_Code"] = SectorDept[0].AirV;
            //    qs["ClassType"] = SectorDept[0].CabinClass.Name;
            //    qs["Total"] = SearchDetails.Itinerary.GrandTotal.ToString();
            //    qs["OTravel_DateStart"] = SectorDept[0].Departure.Date;
            //    qs["OTravel_DateEnd"] = "";
            //    qs["JType"] = Common.GetStopOvers(SearchDetails.FlightSearchDetails.segments.Count);
            //    qs["Offline"] = "true";

            //}    
            return View(_objEnq);
        }

        
        private  string GetMailBody(ref Enquiry _objEnq)
        {
            string emailContent = string.Empty;
            
            emailContent += @"<table width='700' border='0' align='center' cellpadding='0' cellspacing='0' bgcolor='#FFFFFF'>" +
  "<tr>" +
   " <td><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
      "<tr>" +
        "<td align='left' valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
          "<tr>" +
            "<td align='left' valign='top' style='background-color:#324065;'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
              "<tr>" +
                "<td height='80' align='center' valign='middle'><table width='100%' border='0' cellspacing='0' cellpadding='5'>" +
  "<tr>" +
   " <td align='center'><a href='https://www.Faressaver.com/'><img src='https://www.Faressaver.com/images/logo.png' alt='Fares Saver' width='289' height='45' border='0' /></a></td>" +
   " <td align='center'>" +
"<h2 style='color:#C34B26; margin:0px; padding:0px; font-family:Arial, Helvetica, sans-serif; font-size:18px;'>" +
"<span style='color:#C34B26;'>CALL US: </span><a href='tel:" + CompCredentials.ContactNo1 + "' style='text-decoration:none; olor:#FFF;'>" + CompCredentials.ContactNo1 + "</a></h2>" +

"<p style='color:#FFF; font-size:12px; font-family:Arial, Helvetica, sans-serif;'>" + CompCredentials.OfficeTimimg + "</p></td>" +
  "<td align='center'><img src='https://www.Faressaver.com/images/atol-logo.png' width='70' height='71' /></td>" +
 " </tr>" +
"</table>" +
"</td>" +
              "</tr>" +

            "</table></td>" +
          "</tr>" +

         " <tr>" +
            "<td align='left' valign='top' style='background:#e7f3ff; padding:0 10px;'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
  "<tr>" +
    "<td height='50' align='center' valign='middle' style='border-bottom:#acc2d6 solid 1px; font-family:Arial, Helvetica, sans-serif; font-size:14px; font-weight:bold; color:#49596c;'>ENQUIRY FOR FLIGHT - " + _objEnq.RefCode + "</td>" +
  "</tr>" +
  "<tr>" +
    "<td align='left' valign='top' style='padding:0 20px;'></td>" +
  "</tr>" +
 " <tr>" +
    "<td align='left' valign='top'>&nbsp;</td>" +
 " </tr>" +
  "<tr>" +
   " <td align='left' valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
      "<tr>" +
        "<td width='32' align='left' valign='middle'><img src='https://www.Faressaver.com/images/pax.png' width='24' height='24' /></td>" +
        "<td width='5' align='left' valign='middle'>&nbsp;</td>" +
        "<td height='40' align='left' valign='middle' style='font-size:18px; color:#333333; font-family:Arial, Helvetica, sans-serif; font-weight:bold;'>Contact Details</td>" +

      "</tr>" +
    "</table></td>" +
  "</tr>" +
 " <tr>" +
   " <td align='left' valign='top' style='background:#EEEEEE;'><table width='100%' cellpadding='5' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:normal;'>" +
    "<thead>" +
     " <tr>" +
        "<th align='left' valign='middle' style='background:#ED8323' >Name</th>" +
        "<th align='left' valign='middle' style='background:#ED8323'> 	Phone Number </th>" +
        "<th align='left' valign='middle' style='background:#ED8323'>Email ID</th>" +

      "</tr>" +
    "</thead>" +
   " <tbody>" +
      "<tr>" +
       " <td align='left' valign='top' style='border-right:#FFF solid 1px; border-bottom:#FFF solid 1px; '>" + _objEnq.FirstName + " " + _objEnq.LastName + "</td>" +
       "<td align='left' valign='top' style='border-right:#FFF solid 1px; border-bottom:#FFF solid 1px;'>" + _objEnq.Phone + "</td>" +
        "<td align='left' valign='top' style='border-right:#FFF solid 1px; border-bottom:#FFF solid 1px;'><strong>" + _objEnq.Email + "</strong>" +
        "</p>" +
       " </td>" +

      "</tr>" +

   " </tbody>" +
  "</table></td>" +
 " </tr>" +
"  <tr>" +
  " <td align='left' valign='top'>&nbsp;</td>" +
"  </tr>" +
 " <tr>" +
   " <td align='left' valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
     " <tr>" +
       " <td width='32' align='left' valign='middle'><img src='https://www.Faressaver.com/images/flight-info.png' width='24' height='24' /></td>" +
      "  <td width='5' align='left' valign='middle'>&nbsp;</td>" +
     "   <td height='40' align='left' valign='middle' style='font-size:18px; color:#333333; font-family:Arial, Helvetica, sans-serif; font-weight:bold;'>Flight Details</td>" +

    "  </tr>" +
    "</table></td>" +
 " </tr>" +

        //"  <tr>" +
        //  "  <td align='left' valign='top' style='background:#26519E; padding:0 10px;'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
        //     " <tr>" +
        //      "  <td align='left' valign='middle' style='border-right:#FFF solid 1px;'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
        //        "  <tr>" +
        //        "    <td align='left' valign='middle'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Flight From</p>" +
        //         "   <p style='font-size:13px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>" + qs["DestfromName"].ToString() + "</p>" +
        //          "  </td>" +
        //            "<td width='40' align='center' valign='middle'></td>" +
        //           " <td align='left' valign='middle'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Flight To</p>" +
        //            "<p style='font-size:13px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>" + qs["DesttoName"].ToString() + "</p></td>" +
        //          "</tr>" +
        //        "</table></td>" +
        //        "<td align='center' valign='middle' style='border-right:#FFF solid 1px;'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Departure Date</p>" +
        //           " <p style='font-size:14px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>" + qs["OTravel_DateStart"].ToString() + "</p></td>" +
        //        "<td align='center' valign='middle'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Return Date</p>" +
        //           " <p style='font-size:14px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>" + qs["ITravel_DateStart"].ToString() + "</p></td>" +
        //      "</tr>" +
        //        "<tr>" +
        //        "<td align='left' valign='middle'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Airline Name</p></td>" +
        //        "<td width='40' align='center' valign='middle'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Class</p></td><td>&nbsp;&nbsp;</td>" +
        //        "<td align='left' valign='middle'><p style='font-size:11px; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Price</p></td>" +
        //        "</tr>" +
        //        "<tr>" +
        //        "<td align='left' valign='middle'><p style='font-size:13px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>" + qs["Airline_Name"].ToString() + "</p></td>" +
        //            "<td width='40' align='center' valign='middle'><p style='font-size:13px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>Economy</p><td>&nbsp;&nbsp;</td></td>" +
        //        "<td align='left' valign='middle'><p style='font-size:13px; font-weight:bold; color:#FFF; font-family:Arial, Helvetica, sans-serif;'>" + qs["Total"].ToString() + "</p></td>" +
        //        "</tr>" +
        "</table></td>" +
        "<td align='center' valign='middle' style='border-right:#FFF solid 1px;'>" +
           "</td>" +
        "<td align='center' valign='middle'>" +
           "</td>" +
      "</tr>" +
    "</table></td>" +
  "</tr>" +
  "<tr>" +
    "<td align='left' valign='top'>&nbsp;</td>" +
  "</tr>" +
  "<tr>" +
    "<td align='left' valign='top'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
          "<tr>" +
            "<td align='left' valign='top' style='background:#333333; border-bottom:#FFF solid 1px; color:#FFF; padding:5px 10px; font-size:12px; font-weight:bold; font-family:Arial, Helvetica, sans-serif;'>Enquiry Details</td>" +
          "</tr>" +
          "<tr>" +
            "<td align='left' valign='top' style='padding:10px; background:#FFF; font-family:Arial, Helvetica, sans-serif; font-size:11px; font-weight:normal; border:#acc2d6 solid 1px;'>" + _objEnq.Remarks + "" +
"</td>" +
          "</tr>" +
        "</table></td>" +
  "</tr>" +
  "<tr>" +
    "<td align='left' valign='top'>&nbsp;</td>" +
  "</tr>" +
"</table>" +
"</td>" +
         " </tr>" +



        "</table></td>" +
      "</tr>" +



      "<tr>" +
          "<td align='center' style='padding:10px;'>" +
"</td>" +
        "</tr> " +


      "<tr>" +
        "<td align='left' valign='top' style='padding:10px 10px;'><table width='100%' border='0' cellspacing='0' cellpadding='0'>" +



"<tr>" +
"<td align='center' valign='middle' style='font-family:Arial, Helvetica, sans-serif; font-size:11px; color:#6c6c6c; text-decoration:none; line-height:22px; text-align:center; '><table width='100%' border='0' cellspacing='0' ellpadding='0'>" +
 " <tr>" +
    "<td width='150' align='center' valign='middle'><img src='https://www.Faressaver.com/images/atol-logo.png' width='150' height='77' /></td>" +
    "<td align='center' valign='middle'><a href='mailto:support@faressaver.com' style='color:#469ca9; text-decoration:none;'>support@faressaver.com</a> | Call " + CompCredentials.ContactNo1 + "<br />" +

"Offer valid only on  " +
"<a href='https://www.Faressaver.com' style='color:#469ca9; text-decoration:none;'>Faressaver.com</a>" +
 "Check out our <a href='https://www.Faressaver.com/terms.aspx' style='color:#469ca9; text-decoration:none;'>Privacy Policy</a> © " + System.DateTime.Now.Year + ". <br />" +

"All Right Reserved. <a href='https://www.Faressaver.com/terms.aspx' style='color:#469ca9; text-decoration:none;'>Faressaver.com</a></td>" +
   " <td align='center' valign='middle'><img src='https://www.Faressaver.com/images/certificate_secure_booking.png' width='100' height='63' alt='secure booking' /></td>" +
 " </tr>" +
"</table>" +
"</td>" +
          "</tr>" +
        "</table></td>" +
     " </tr>" +
    "</table></td>" +
 " </tr>" +
"</table>";

            return emailContent;
            //try
            //{

            //    bool m = client.SET_Call_Details(callref, "INSERT", "", "WebSite", "TRVJUNCTION", txtMobile.Value.Trim(),
            //                       txtName.Value.Trim(), txtEmail.Value.Trim(), qs["From"].ToString(), qs["To"].ToString(),
            //                       "1", qs["OTravel_DateStart"].ToString(), qs["ITravel_DateStart"].ToString(), qs["Airline_Code"].ToString(), "Web Enquiry", "Enquiry", txtMsg.Value);

            //}
            //catch { }
            

        }

    }
    
}