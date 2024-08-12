using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace TravelSite.Models
{
    public class Common
    {

        public static string GenerateBookingRef()
        {
            //IDCreator.IDCreator objBok = new IDCreator.IDCreator();
            return "XP00";// objBok.GenerateIDs("XP");
        }
        public static string GetStopOvers(int stops)
        {
            string stop = string.Empty;
            switch (stops)
            {
                case 0:
                    stop = "non stop";
                    break;
                case 1:
                    stop = "1 stop";
                    break;
                case 2:
                    stop = "2 stops";
                    break;
                case 3:
                    stop = "3 stops";
                    break;
                case 4:
                    stop = "4 stops";
                    break;

                case 5:
                    stop = "5 stops";
                    break;
                case 6:
                    stop = "6 stops";
                    break;
            }
            return stop;
        }
        public static string GetAirportCode(string _str)
        {
            string subString = _str;
            int startIndex = subString.LastIndexOf("(");
            string sub = subString.Substring(startIndex + 1);
            string FlyingFrom = sub.Substring(0, 3);
            return FlyingFrom.Trim().ToUpper();
        }
        public static string arrengeDate(string str)
        {
            string retStr = str.Replace("/", "-");
            return retStr;
        }
        public static bool SaveWSFile(String fileContents, string path)
        {
            FileStream fs = new FileStream(@path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            XmlDocument _root = new XmlDocument();
            _root.LoadXml(fileContents);
            try
            {
                sw.WriteLine(fileContents);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string RemoveSign(string s)
        {

            string sName = string.Empty;
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            if (s.Contains("-"))
            {
                string[] arr = s.Split('-');
                sName = AddStringInArray(arr);
            }
            else if (s.Contains(" "))
            {
                string[] arr = s.Split(' ');
                sName = AddStringInArray(arr);

            }
            else if (s.Contains("/"))
            {
                string[] arr = s.Split('/');
                sName = AddStringInArray(arr);

            }
            else
            {
                if (!s.Contains("-") || !s.Contains(" "))
                {
                    sName = AddSpace(s);
                    if (sName.Contains(" "))
                    {
                        string[] arr = sName.Split(' ');
                        sName = AddStringInArray(arr);
                    }
                    else
                    {
                        sName = UppercaseFirst(s);
                    }
                }
                else
                {
                    sName = UppercaseFirst(s);
                }
            }
            return sName;
        }

        public static string AddSpace(string s)
        {
            if (s == "Australia/OCEANIA")
            {
                s = "australia/oceania";
            }
            else if (s == "USA")
            {
                s = "usa";
            }
            else
            {
                char[] chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    string strChar = chars.GetValue(i).ToString();
                    if (s.Contains(strChar))
                    {
                        s = s.Replace(strChar, " " + strChar);
                    }
                }
                if (s.Contains(" "))
                {
                    s = s.Substring(1);
                }
            }
            return s;

        }

        public static string AddspecialSign(string s)
        {
            char[] chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (s.Contains(strChar))
                {
                    s = s.Replace(strChar, "-" + strChar);
                }
            }
            if (s.Contains("-"))
            {
                s = s.Substring(1);
            }
            return s;
        }

        public static string AddStringInArray(string[] arr)
        {
            string sName = string.Empty;
            string third = string.Empty;
            for (int i = 1; i <= arr.Length; i++)
            {
                sName = UppercaseFirst(arr[arr.Length - i].ToString()) + " " + sName;
            }
            return sName;
        }
        public static string GetCardNumber(string cardNo)
        {
            string cardnumber = string.Empty;
            try
            {
                if (cardNo.Length > 4)
                {
                    string last4digit = cardNo.Substring((cardNo.Length - 4));
                    cardnumber = last4digit.PadLeft(cardNo.Length, 'x');
                }
                else
                {
                    cardnumber = cardNo;
                }
            }
            catch
            {

            }
            return cardnumber;
        }

        public static string SetFlightSector(XmlDocument xmlDoc)
        {
            StringBuilder sb = new StringBuilder();
            string sHtml = string.Empty;
            sb.Append("<div class=\"detailblock1\">");
            int iGoCount = 1;
            foreach (XmlNode sector in xmlDoc.SelectNodes("Itinerary/Sectors/Sector[isReturn='false']"))
            {
                string _depGoDt = sector.SelectSingleNode("Departure/Date").InnerText;
                string _depGoDy = sector.SelectSingleNode("Departure/Day").InnerText;
                DateTime depdy = Convert.ToDateTime(_depGoDt);
                if (iGoCount == 1)
                {
                    sb.Append("<h2>Leave:" + _depGoDy + "," + depdy.ToString("dd MMM yyyy") + "</h2>");
                }
                sb.Append(" <div class=\"detailrow1\">");
                string depttime = sector.SelectSingleNode("Departure/Time").InnerText;
                sb.Append("  <span class=\"dcol1\">" + depttime + "<br> <span>" + _depGoDy + "" + depdy.ToString("dd MMM") + "</span> </span>");
                sb.Append("  <span class=\"dcol1\"><i class=\"fa fa-long-arrow-right\"></i></span>");
                string _depGoArriveDt = sector.SelectSingleNode("Arrival/Date").InnerText;
                string _depGoArriveDy = sector.SelectSingleNode("Arrival/Day").InnerText;
                string deptArrivetime = sector.SelectSingleNode("Arrival/Time").InnerText;
                DateTime depArrivedy = Convert.ToDateTime(_depGoArriveDt);
                sb.Append("<span class=\"dcol1\">" + deptArrivetime + " <br><span>" + _depGoArriveDy + "" + depArrivedy.ToString("dd MMM") + "</span></span>");

                string _depDuration = sector.SelectSingleNode("ActualTime").InnerText;
                if (_depDuration.Length > 1)
                {
                    string[] _arrDuration = _depDuration.Split(':');

                    _depDuration = _arrDuration[0] + "h:" + _arrDuration[1] + "m";
                }

                sb.Append("<span class=\"dcol1\">" + _depDuration + "</span>");

                sb.Append("<div class=\"location\">");
                string deptAirport = sector.SelectSingleNode("Departure/AirpName").InnerText;
                string deptAirportcode = sector.SelectSingleNode("Departure/AirpCode").InnerText;

                string deptArriveAirport = sector.SelectSingleNode("Arrival/AirpName").InnerText;
                string deptArriveAirportcode = sector.SelectSingleNode("Arrival/AirpCode").InnerText;

                string deptArriveAirlinename = sector.SelectSingleNode("AirlineName").InnerText;
                string deptArriveAirlinecode = sector.SelectSingleNode("FltNum").InnerText;
                string deptEquipType = sector.SelectSingleNode("EquipType").InnerText;

                string airlineclass = sector.SelectSingleNode("CabinClass/Des").InnerText;
                string airlineclasscode = sector.SelectSingleNode("CabinClass/Code").InnerText;

                sb.Append("<p>" + deptAirport + "(" + deptAirportcode + ")" + " to " + deptArriveAirport + "(" + deptArriveAirportcode + ")" + "</p>");
                sb.Append("<ul>");
                sb.Append("<li>" + deptArriveAirlinename + deptArriveAirlinecode + "</li>");
                sb.Append("<li>" + airlineclass + "/ Coach" + "(" + airlineclasscode + ")" + "</li>");
                sb.Append("<li>" + deptEquipType + "</li>");
                sb.Append("</ul>");
                sb.Append("</div>");
                sb.Append("</div>");
                iGoCount++;

            }
            sb.Append("</div>");


            int iretCount = 1;
            if (xmlDoc.SelectSingleNode("/Itinerary/Sectors/Sector[isReturn='true']") != null)
            {
                sb.Append("<div class=\"detailblock1\">");
                foreach (XmlNode sector in xmlDoc.SelectNodes("Itinerary/Sectors/Sector[isReturn='true']"))
                {

                    string _depGoDt = sector.SelectSingleNode("Departure/Date").InnerText;
                    string _depGoDy = sector.SelectSingleNode("Departure/Day").InnerText;
                    DateTime depdy = Convert.ToDateTime(_depGoDt);
                    if (iretCount == 1)
                    {
                        sb.Append("<h2>Return:" + _depGoDy + "," + depdy.ToString("dd MMM yyyy") + "</h2>");
                    }
                    sb.Append(" <div class=\"detailrow1\">");
                    string depttime = sector.SelectSingleNode("Departure/Time").InnerText;
                    sb.Append("  <span class=\"dcol1\">" + depttime + "<br> <span>" + _depGoDy + "" + depdy.ToString("dd MMM") + "</span> </span>");
                    sb.Append("  <span class=\"dcol1\"><i class=\"fa fa-long-arrow-right\"></i></span>");
                    string _depGoArriveDt = sector.SelectSingleNode("Arrival/Date").InnerText;
                    string _depGoArriveDy = sector.SelectSingleNode("Arrival/Day").InnerText;
                    string deptArrivetime = sector.SelectSingleNode("Arrival/Time").InnerText;
                    DateTime depArrivedy = Convert.ToDateTime(_depGoArriveDt);
                    sb.Append("<span class=\"dcol1\">" + deptArrivetime + " <br><span>" + _depGoArriveDy + "" + depArrivedy.ToString("dd MMM") + "</span></span>");
                    string _depDuration = sector.SelectSingleNode("ActualTime").InnerText;
                    if (_depDuration.Length > 1)
                    {
                        string[] _arrDuration = _depDuration.Split(':');

                        _depDuration = _arrDuration[0] + "h:" + _arrDuration[1] + "m";
                    }

                    sb.Append("<span class=\"dcol1\">" + _depDuration + "</span>");
                    //sb.Append("<span class=\"dcol1 Overnight\"> <img src=\"~/images/light.png\"> " + "Overnight - Arrives Wed, 25 Jul" + "</span>");
                    sb.Append("<div class=\"location\">");
                    string deptAirport = sector.SelectSingleNode("Departure/AirpName").InnerText;
                    string deptAirportcode = sector.SelectSingleNode("Departure/AirpCode").InnerText;

                    string deptArriveAirport = sector.SelectSingleNode("Arrival/AirpName").InnerText;
                    string deptArriveAirportcode = sector.SelectSingleNode("Arrival/AirpCode").InnerText;

                    string deptArriveAirlinename = sector.SelectSingleNode("AirlineName").InnerText;
                    string deptArriveAirlinecode = sector.SelectSingleNode("FltNum").InnerText;
                    string deptEquipType = sector.SelectSingleNode("EquipType").InnerText;

                    string airlineclass = sector.SelectSingleNode("CabinClass/Des").InnerText;
                    string airlineclasscode = sector.SelectSingleNode("CabinClass/Code").InnerText;

                    sb.Append("<p>" + deptAirport + "(" + deptAirportcode + ")" + " to " + deptArriveAirport + "(" + deptArriveAirportcode + ")" + "</p>");
                    sb.Append("<ul>");
                    sb.Append("<li>" + deptArriveAirlinename + deptArriveAirlinecode + "</li>");
                    sb.Append("<li>" + airlineclass + "/ Coach" + "(" + airlineclasscode + ")" + "</li>");
                    sb.Append("<li>" + deptEquipType + "</li>");
                    sb.Append("</ul>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    iretCount++;

                }
                sb.Append("</div>");
            }
            return sHtml = sb.ToString();


        }

        public static string SetFlightPriceDetails(XmlDocument xmlDoc)
        {
            StringBuilder sb = new StringBuilder();
            string sHtml = string.Empty;
            string noofAdult = "0";
            string noofChild = "0";
            string noofInf = "0";
            string adultsafi = "0";
            string childsafi = "0";
            string Infsafi = "0";
            string AdultTotal = "0";
            string ChildTotal = "0";
            string InfantTotal = "0";

            if (xmlDoc.SelectNodes("Itinerary/Adult").Count > 0)
            {
                noofAdult = Convert.ToInt32(xmlDoc.SelectSingleNode("Itinerary/Adult/NoAdult").InnerText).ToString();
                string AdTax = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Adult/AdTax").InnerText).ToString("#0.00");
                string AdtBFare = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Adult/AdtBFare").InnerText).ToString("#0.00");
                string markUp = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Adult/markUp").InnerText).ToString("#0.00");
                string Commission = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Adult/Commission").InnerText).ToString("#0.00");
                string subtoaltax = (Convert.ToDouble(AdTax) * Convert.ToDouble(noofAdult)).ToString("#0.00");
                string subTotalAmount = (Convert.ToDouble(AdtBFare) + Convert.ToDouble(markUp) + Convert.ToDouble(Commission)).ToString();
                string TotalAmount = (Convert.ToDouble(subTotalAmount) * Convert.ToDouble(noofAdult)).ToString("#0.00");
                string grandtotal = (Convert.ToDouble(TotalAmount) + Convert.ToDouble(subtoaltax)).ToString("#0.00");
                adultsafi = (Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Adult/Safi").InnerText)).ToString("#0.00");
                sb.Append("<tr><td>" + noofAdult + " Adult</td>");
                //sb.Append("<td>£" + TotalAmount + "</td>");
                //sb.Append("<td>£" + subtoaltax + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>£" + grandtotal + "</td></tr>");
                AdultTotal = grandtotal;
            }
            if (xmlDoc.SelectNodes("Itinerary/Child").Count > 0)
            {
                noofChild = Convert.ToInt32(xmlDoc.SelectSingleNode("Itinerary/Child/NoChild").InnerText).ToString();
                string AdTax = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Child/CHTax").InnerText).ToString("#0.00");
                string AdtBFare = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Child/ChdBFare").InnerText).ToString("#0.00");
                string markUp = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Child/markUp").InnerText).ToString("#0.00");
                string Commission = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Child/Commission").InnerText).ToString("#0.00");
                string subtoaltax = (Convert.ToDouble(AdTax) * Convert.ToDouble(noofChild)).ToString("#0.00");
                string subTotalAmount = (Convert.ToDouble(AdtBFare) + Convert.ToDouble(markUp) + Convert.ToDouble(Commission)).ToString();
                string TotalAmount = (Convert.ToDouble(subTotalAmount) * Convert.ToDouble(noofChild)).ToString("#0.00");
                string grandtotal = (Convert.ToDouble(TotalAmount) + Convert.ToDouble(subtoaltax)).ToString("#0.00");
                childsafi = (Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Child/Safi").InnerText)).ToString("#0.00");
                sb.Append("<tr><td>" + noofChild + " Child</td>");
                //sb.Append("<td>£" + TotalAmount + "</td>");
                //sb.Append("<td>£" + subtoaltax + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>£" + grandtotal + "</td></tr>");
                ChildTotal = grandtotal;
            }
            if (xmlDoc.SelectNodes("Itinerary/Infant").Count > 0)
            {
                noofInf = Convert.ToInt32(xmlDoc.SelectSingleNode("Itinerary/Infant/NoInfant").InnerText).ToString();
                string AdTax = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Infant/InTax").InnerText).ToString("#0.00");
                string AdtBFare = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Infant/InfBFare").InnerText).ToString("#0.00");
                string markUp = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Infant/markUp").InnerText).ToString("#0.00");
                string Commission = Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Infant/Commission").InnerText).ToString("#0.00");
                string subtoaltax = (Convert.ToDouble(AdTax) * Convert.ToDouble(noofInf)).ToString("#0.00");
                string subTotalAmount = (Convert.ToDouble(AdtBFare) + Convert.ToDouble(markUp) + Convert.ToDouble(Commission)).ToString();
                string TotalAmount = (Convert.ToDouble(subTotalAmount) * Convert.ToDouble(noofInf)).ToString("#0.00");
                string grandtotal = (Convert.ToDouble(TotalAmount) + Convert.ToDouble(subtoaltax)).ToString("#0.00");
                //string subTotalAmount = (Convert.ToDouble(AdTax) + Convert.ToDouble(AdtBFare) + Convert.ToDouble(markUp) + Convert.ToDouble(Commission)).ToString();
                //string TotalAmount = (Convert.ToDouble(subTotalAmount) * Convert.ToDouble(noofChild)).ToString("#0.00");
                Infsafi = (Convert.ToDouble(xmlDoc.SelectSingleNode("Itinerary/Infant/Safi").InnerText)).ToString("#0.00");

                sb.Append("<tr><td>" + noofInf + " Infant</td>");
                //sb.Append("<td>£" + TotalAmount + "</td>");
                //sb.Append("<td>£" + subtoaltax + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td></td>");
                sb.Append("<td>£" + grandtotal + "</td></tr>");
                InfantTotal = grandtotal;
            }

            string totalpax = (Convert.ToInt32(noofAdult) + Convert.ToInt32(noofChild) + Convert.ToInt32(noofInf)).ToString();
            string totalsafi = (Convert.ToDouble(adultsafi) + Convert.ToDouble(childsafi) + Convert.ToDouble(Infsafi)).ToString("#0.00");
            string TotalPrice = (Convert.ToDouble(AdultTotal) + Convert.ToDouble(ChildTotal) + Convert.ToDouble(InfantTotal) + Convert.ToDouble(totalsafi)).ToString("#0.00");

            sb.Append("<tr><td>Scheduled Airline Failure Insurance(SAFI)</td>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("<td> £" + totalsafi + "</td></tr>");

            sb.Append("<tr><td><strong></strong></td>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("<td><strong>Total Amount  £" + TotalPrice + "</strong></td>");

            return sHtml = sb.ToString();
        }
        public static class XmlValidator
        {
            public static bool Validate(string xml)
            {
                try
                {
                    new XmlDocument().LoadXml(xml);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static double ATOLFee
        {
            //get { return 2.5; }
            get { return 0; }
        }
        public static double SAFIFee
        {
            get { return 1.5; }
        }

        public static DataTable GetHomeAirlineFares(string Class, string PageType, string Domain, string CompId)
        {
            return Global.ExecuteSPReturnDT(new object[] {"GetSubdomainFlightFares"
                                                        ,"@paramClass",Class
                                                        ,"@paramPageType",PageType
                                                        ,"@paramCompany",CompId
                                                        ,"@Counter",Domain                                                   
                 }, DataConnection.GetOffLineFareConnection());
        }

        public static DataTable GetHomeTopDestination(string Currency, string Domain, string CompId)
        {
            return Global.ExecuteSPReturnDT(new object[] {"Usp_GetTopDestination"
                                                        ,"@Currency",Currency
                                                        ,"@Domain",Domain
                                                        ,"@CompId",CompId                                                                                                       
            }, DataConnection.GetPageTrackerConnection());
        }


        public static List<OfflineFare> GetHomeFare(string Class, string OfferType, string PageType, string Counter, string CompId)
        {

            List<OfflineFare> _listModel = new List<OfflineFare>();

            DataTable Dt = Global.ExecuteSPReturnDT(new object[] {"GETHomePageOffer"
                                                    ,"@paramPageType",PageType
                                                    ,"@Counter",Counter
                                                    ,"@paramCompany",string.IsNullOrEmpty(CompId)?null:CompId
                                                    ,"@paramOfferType",OfferType 
                                                    ,"@paramClass",Class
                                                        
                 }, DataConnection.GetOffLineFareConnection());


            foreach (DataRow drow in Dt.Rows)
            {
                _listModel.Add(
                    new OfflineFare
                    {
                        sourceName = drow["DestfromName"].ToString(),
                        DestinationName = drow["DesttoName"].ToString(),
                        ContinentUrl = drow["Continent_Name"].ToString(),
                        Destinationurl = Common.AddspecialSign(drow["DesttoName"].ToString()),
                        Countryurl = Common.AddspecialSign(drow["Country"].ToString()),
                        ContinentName = drow["Continent_Name"].ToString().ToLower().Replace("/", "-"),
                        DestinationImg = "https://www.flightsandholidays.biz//ImageUrl/" + drow["To"].ToString().Trim() + "3517_CT_T.png",
                        AirlineImg = "https://www.flightsandholidays.biz//images/AirlineLogo/" + drow["Airline_Code"].ToString().Trim() + ".gif",
                        Airlinename = drow["Airline_Name"].ToString(),
                        Price = Convert.ToDecimal(drow["GrandTotal"].ToString()).ToString("#0"),
                        destinationcode = drow["To"].ToString(),
                        ClassType = drow["ClassType"].ToString(),
                        StartDate = drow["Travel_DateStart"].ToString(),
                        EndDate = drow["Travel_DateEnd"].ToString(),

                    });
            }
            return _listModel;


        }
        public static List<OfflineFare> GetFaresAirportForDestination(string counter, string destcode, string continentname, string CompId, string Class)
        {
            try
            {
                List<OfflineFare> _listModel = new List<OfflineFare>();
                DataTable Dt = Global.ExecuteSPReturnDT(new object[] {"GETFareFlightDestination_New"
                                                    ,"@ParamDestToName",destcode
                                                    ,"@Counter",counter
                                                    ,"@ParamCompany",CompId
                                                    ,"@ParamClass",Class
                                                    //,"@ParamContinentName",continentname                                                                                                          
                                                    
                 }, DataConnection.GetOffLineFareConnection());

                foreach (DataRow drow in Dt.Rows)
                {
                    _listModel.Add(
                        new OfflineFare
                        {
                            SourceCode = drow["From"].ToString(),
                            sourceName = drow["DestfromName"].ToString(),
                            DestinationName = drow["DesttoName"].ToString(),
                            ContinentUrl = drow["Continent_Name"].ToString(),
                            Destinationurl = Common.AddspecialSign(drow["DesttoName"].ToString()),
                            Countryurl = Common.AddspecialSign(drow["Country"].ToString()),
                            DestinationImg = "https://www.flightsandholidays.biz//ImageUrl/" + drow["To"].ToString().Trim() + "3517_CT_T.png",
                            AirlineImg = "https://www.flightsandholidays.biz//images/AirlineLogo/" + drow["Airline_Code"].ToString().Trim() + ".gif",
                            Airlinename = drow["Airline_Name"].ToString(),
                            Price = Convert.ToDecimal(drow["GrandTotal"].ToString()).ToString("#0"),
                            destinationcode = drow["To"].ToString(),
                            ClassType = drow["ClassType"].ToString(),
                            StartDate = Convert.ToDateTime(drow["Travel_DateStart"].ToString()).ToString("dd MMM yy"),
                            EndDate = Convert.ToDateTime(drow["Travel_DateEnd"].ToString()).ToString("dd MMM yy"),

                        });
                }
                return _listModel;
            }
            catch
            {
                return null;
            }
        }
        public static void DeleteFiles(string directoryPath)
        {
            foreach (string item in System.IO.Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories))
            {
                try
                {
                    FileInfo obFileInfo = new FileInfo(item);
                    obFileInfo.Refresh();
                    DateTime fileCreation = obFileInfo.LastWriteTime;
                    DateTime NewTime = DateTime.Now.AddDays(-120);
                    if (NewTime > fileCreation)
                    {
                        try
                        {
                            System.IO.File.Delete(obFileInfo.FullName);
                        }
                        catch { }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        public static DataTable GetMetatag(string PageUrl)
        {
            try
            {
                DataTable Dt = Global.ExecuteSPReturnDT(new object[] {"Usp_GetMetaTags"
                                                    ,"@PageUrl",PageUrl
                                                    ,"@CompanyId",CompCredentials.CompanyId                                                  
                                                        
                 }, DataConnection.GetMlWebsite());
                return Dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataSet GetFlightFaresByContinents(int Counter)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Global.ExecuteSPReturnDS(new object[] {"Usp_GetCheapDestinations"                                                    
                                                 ,"@Counter",Counter                                                 
                 }, DataConnection.GetOffLineFareConnection());
                return ds == null ? null : ds;
            }
            catch
            {
                ds = null;
                return ds;
            }
        }
        public static string GetCommandName(string cmd)
        {
            string Rval = "Continue Booking";
            switch (cmd.Trim())
            {
                case "Continuer Réservation":
                    Rval = "Continue Booking";
                    break;
                case "Continuer":
                    Rval = "Continue";
                    break;
                case "continuar reserva":
                    Rval = "Continue Booking";
                    break;
                case "Continuar":
                    Rval = "Continue";
                    break;
                case "Nu Boeken":
                    Rval = "Continue Booking";
                    break;
                case "Doorgaan":
                    Rval = "Continue";
                    break;
                case "Buchung fortsetzen":
                    Rval = "Continue Booking";
                    break;
                case "Weiter":
                    Rval = "Continue";
                    break;
                case "Payer":
                    Rval = "Pay";
                    break;
                case "Bezahlen":
                    Rval = "Pay";
                    break;
                case "Betalen":
                    Rval = "Pay";
                    break;
                case "Paga":
                    Rval = "Pay";
                    break;
                case "Pay":
                    Rval = "Pay";
                    break;
                case "Choose1":
                    Rval = "Choose1";
                    break;
                case "Choose2":
                    Rval = "Choose2";
                    break;
                case "Choose3":
                    Rval = "Choose3";
                    break;
                case "Choose4":
                    Rval = "Choose4";
                    break;
                case "Continue":
                    Rval = "Continue";
                    break;
                default:
                    {
                        Rval = "Continue Booking";
                        break;
                    }
            }
            return Rval;

        }
        public static string GetClassName(string Class)
        {
            string Rval = string.Empty;
            switch (Class.ToLower())
            {
                case "economy":
                    Rval = "Economy";
                    break;
                case "premium economy":
                    Rval = "Premium Economy";
                    break;
                case "business":
                    Rval = "Business";
                    break;
                case "first class":
                    Rval = "FirstClass";
                    break;
            }
            return Rval;
        }
    }
    #region Items

    [Serializable]
    public class Items<T>
    {
        List<T> _items;
        public Items()
        {
            _items = new List<T>();
        }

        public bool Add(T item)
        {
            try
            {
                _items.Add(item);
                return true;
            }
            catch { return false; }
        }

        public bool RemoveAt(int index)
        {
            try
            {
                _items.RemoveAt(index);
                return true;
            }
            catch { return false; }
        }

        public bool InsertAt(int index, T item)
        {
            try
            {
                _items.Insert(index, item);
                return true;
            }
            catch { return false; }
        }

        #region Properties

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public List<T> List
        {
            get { return _items; }
        }
        #endregion



    }

    #endregion

    #region Pax Info

    /// <summary>
    /// Summary description for PaxInfo
    /// </summary>

    [Serializable]
    public class PaxInfo : Items<PaxInfo>
    {
        #region Data menbers
        string _paxType;
        string _paxId;
        string _title;
        string _fName;
        string _lName;
        string _seat;
        string _meal;
        string _day;
        string _month;
        string _year;
        string _sex;
        string _age;
        #endregion

        #region Constructor
        public PaxInfo()
        {
            _paxType = string.Empty;
            _paxId = string.Empty;
            _title = string.Empty;
            _fName = string.Empty;
            _lName = string.Empty;
            _seat = string.Empty;
            _meal = string.Empty;
            _day = string.Empty;
            _month = string.Empty;
            _year = string.Empty;
            _sex = string.Empty;
            _age = string.Empty;


        }
        public PaxInfo(string paxType, string PaxId, string Title, string FirstName,
            string LastName, string Seat, string Meal, string Sex)
        {
            this._paxType = paxType;
            this._paxId = PaxId;
            this._title = Title;
            this._fName = FirstName;
            this._lName = LastName;
            this._seat = Seat;
            this._meal = Meal;
            this._sex = Sex;


        }
        #endregion

        #region Properties

        public string PaxType
        {
            get { return this._paxType; }
            set { this._paxType = value; }
        }

        public string PaxId
        {
            get { return this._paxId; }
            set { this._paxId = value; }
        }


        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }


        public string FirstName
        {
            get { return this._fName; }
            set { this._fName = value; }
        }


        public string LastName
        {
            get { return this._lName; }
            set { this._lName = value; }
        }

        public string Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public string Seat
        {
            get { return this._seat; }
            set { this._seat = value; }
        }


        public string Meal
        {
            get { return this._meal; }
            set { this._meal = value; }
        }

        public string Day
        {
            get { return this._day; }
            set { this._day = value; }
        }
        public string Month
        {
            get { return this._month; }
            set { this._month = value; }
        }
        public string Year
        {
            get { return this._year; }
            set { this._year = value; }
        }
        public string Age
        {
            get { return this._age; }
            set { this._age = value; }
        }
        public string DOB
        {
            get { try { return Convert.ToDateTime(this._day + "/" + this.Month + "/" + this.Year).ToString("dd-MM-yyyy"); } catch { return string.Empty; } }
        }
        #endregion

        public void AddPax(string paxType, int noOfPax)
        {
            for (int i = 0; i < noOfPax; i++)
                this.Add(new PaxInfo(paxType, "", "", "", "", "", "", ""));
        }

        public void GetPaxDetails(FormCollection frm, string paxCount)
        {
            // adult-1/child-1/infant-1
            string paxC = paxCount;
            int adult = Convert.ToInt16(paxCount.Split('/')[0].Split('-')[1]);
            int child = Convert.ToInt16(paxCount.Split('/')[1].Split('-')[1]);
            int infant = Convert.ToInt16(paxCount.Split('/')[2].Split('-')[1]);
            this.List.Clear();
            int count = 1;
            DateTime now = DateTime.Today;
            for (int i = 0; i < adult; i++)
            {
                try
                {
                    PaxInfo _pax = new PaxInfo();
                    _pax.PaxId = count.ToString();
                    _pax.PaxType = "ADULT";
                    _pax.Title = frm["_ViewModel[0]._AdultM[" + i + "].Title.ID"];
                    _pax.FirstName = frm["_ViewModel[0]._AdultM[" + i + "].FirstName"];
                    _pax.LastName = frm["_ViewModel[0]._AdultM[" + i + "].LastName"];
                    //DateTime PaxDOB = Convert.ToDateTime(Day + "/" + Month + "/" + Year);// Convert.ToDateTime(((TextBox)gvr.FindControl("txtDOB")).Text.Trim());
                    _pax.Day = frm["_ViewModel[0]._AdultM[" + i + "].Day.ID"];
                    _pax.Month = frm["_ViewModel[0]._AdultM[" + i + "].Month.ID"];
                    _pax.Year = frm["_ViewModel[0]._AdultM[" + i + "].Year.ID"];

                    DateTime PaxDOB = Convert.ToDateTime(_pax.Day + "/" + _pax.Month + "/" + _pax.Year);
                    _pax.Seat = frm["_ViewModel[0]._AdultM[" + i + "].Seat.ID"];
                    _pax.Meal = frm["_ViewModel[0]._AdultM[" + i + "].Meal.ID"];
                    _pax.Sex = frm["_ViewModel[0]._AdultM[" + i + "].Gender.ID"];
                    this.Add(_pax);
                    count++;
                }
                catch
                {

                }
            }
            for (int i = 0; i < child; i++)
            {
                try
                {
                    int age = now.Year;
                    PaxInfo _pax = new PaxInfo();
                    _pax.PaxId = count.ToString();
                    _pax.PaxType = "CHILD";
                    _pax.Title = frm["_ViewModel[0]._ChildM[" + i + "].Title.ID"];
                    _pax.FirstName = frm["_ViewModel[0]._ChildM[" + i + "].FirstName"];
                    _pax.LastName = frm["_ViewModel[0]._ChildM[" + i + "].LastName"];
                    //DateTime PaxDOB = Convert.ToDateTime(Day + "/" + Month + "/" + Year);// Convert.ToDateTime(((TextBox)gvr.FindControl("txtDOB")).Text.Trim());
                    _pax.Day = frm["_ViewModel[0]._ChildM[" + i + "].Day.ID"];
                    _pax.Month = frm["_ViewModel[0]._ChildM[" + i + "].Month.ID"];
                    _pax.Year = frm["_ViewModel[0]._ChildM[" + i + "].Year.ID"];
                    _pax._age = (age - Convert.ToInt32(frm["_ViewModel[0]._ChildM[" + i + "].Year.ID"].ToString())).ToString();
                    DateTime PaxDOB = Convert.ToDateTime(_pax.Day + "/" + _pax.Month + "/" + _pax.Year);
                    _pax.Seat = frm["_ViewModel[0]._ChildM[" + i + "].Seat.ID"];
                    _pax.Meal = frm["_ViewModel[0]._ChildM[" + i + "].Meal.ID"];
                    _pax.Sex = frm["_ViewModel[0]._ChildM[" + i + "].Gender.ID"];
                    this.Add(_pax);
                    count++;
                }
                catch
                {

                }
            }


            for (int i = 0; i < infant; i++)
            {
                try
                {
                    int age = now.Year;
                    PaxInfo _pax = new PaxInfo();
                    _pax.PaxId = count.ToString();
                    _pax.PaxType = "INFANT";
                    _pax.Title = frm["_ViewModel[0]._InfantM[" + i + "].Title.ID"];
                    _pax.FirstName = frm["_ViewModel[0]._InfantM[" + i + "].FirstName"];
                    _pax.LastName = frm["_ViewModel[0]._InfantM[" + i + "].LastName"];
                    //DateTime PaxDOB = Convert.ToDateTime(Day + "/" + Month + "/" + Year);// Convert.ToDateTime(((TextBox)gvr.FindControl("txtDOB")).Text.Trim());
                    _pax.Day = frm["_ViewModel[0]._InfantM[" + i + "].Day.ID"];
                    _pax.Month = frm["_ViewModel[0]._InfantM[" + i + "].Month.ID"];
                    _pax.Year = frm["_ViewModel[0]._InfantM[" + i + "].Year.ID"];
                    _pax._age = (age - Convert.ToInt32(frm["_ViewModel[0]._InfantM[" + i + "].Year.ID"].ToString())).ToString();
                    DateTime PaxDOB = Convert.ToDateTime(_pax.Day + "/" + _pax.Month + "/" + _pax.Year);
                    // _pax.Seat = frm["SeatReqInfant" + i + ""];
                    _pax.Meal = frm["_ViewModel[0]._InfantM[" + i + "].Meal.ID"];
                    _pax.Sex = frm["_ViewModel[0]._InfantM[" + i + "].Gender.ID"];
                    this.Add(_pax);
                    count++;
                }
                catch
                {

                }
            }
        }
        //---
        #region Get Passengers details

        public DataTable GetPaxDetail(PaxInfo _gridPax, string BookingRef, string ProdBookingId)
        {

            CreateDataTable objCreateDTbl = new CreateDataTable();
            using (DataTable paxTbl = objCreateDTbl.CreatePaxDataTable())
            {
                try
                {
                    int _count = _gridPax.Count;
                    for (int i = 0; i < _count; i++)
                    {

                        string gender = _gridPax[i].PaxType.ToString();
                        if (gender.ToUpper().Trim() == "ADULT")
                        {
                            gender = "ADT";
                        }
                        else if (gender.ToUpper().Trim() == "CHILD")
                        {
                            gender = "CHD";
                        }
                        else if (gender.ToUpper().Trim() == "INFANT")
                        {
                            gender = "INF";
                        }

                        string _tital = _gridPax[i].Title.ToString();
                        _tital = _tital.Trim().ToUpper();
                        string _FName = _gridPax[i].FirstName.ToString();
                        _FName = _FName.Trim().ToUpper();
                        string _LName = _gridPax[i].LastName.ToString();
                        _LName = _LName.Trim().ToUpper();
                        string _day = _gridPax[i].Day.ToString();
                        string _month = _gridPax[i].Month.ToString();
                        string _year = _gridPax[i].Year.ToString();
                        DateTime PaxDOB = Convert.ToDateTime(_day + "/" + _month + "/" + _year);

                        DataRow dr = objCreateDTbl.CreatePaxDtaRow(paxTbl.NewRow(), BookingRef, ProdBookingId, Convert.ToString(i + 1), _tital,
                        _FName, "", _LName, "", "", "", "", "", "", Convert.ToDateTime(PaxDOB.Day.ToString() + "/" + PaxDOB.Month.ToString() + "/" + PaxDOB.Year.ToString() + " 00:00").ToString(), gender);
                        paxTbl.Rows.Add(dr);
                    }
                }
                catch { }
                return paxTbl;

            }
        }
        #endregion

    }

    [Serializable]
    public class SSRnSeats : Items<SSRnSeats>
    {
        public string PaxName { get; set; }
        public string Flight { get; set; }
        public string SSR { get; set; }
        public string SSRStatus { get; set; }
        public string Seat { get; set; }


        public string SSRCode
        {
            get { return SSR; }
            set
            {
                SSR = value;
                SSR = GetMealCode_Name(SSR);
            }
        }
        public static string GetMealCode_Name(string MealCode)
        {
            string ReturnMealCode = string.Empty;
            switch (MealCode)
            {
                case "AVML":
                    { ReturnMealCode = "Asian Veg"; break; }
                case "BBML":
                    { ReturnMealCode = "Baby/Infant Food"; break; }
                case "BLML":
                    { ReturnMealCode = "Bland Meal"; break; }
                case "CHML":
                    { ReturnMealCode = "Child Meal"; break; }
                case "DBML":
                    { ReturnMealCode = "Diabetic"; break; }
                case "FPML":
                    { ReturnMealCode = "Fruit Meal"; break; }
                case "GFML":
                    { ReturnMealCode = "Gluten Free"; break; }
                case "HFML":
                    { ReturnMealCode = "High Fiber"; break; }
                case "HNML":
                    { ReturnMealCode = "Hindu Meal"; break; }
                case "KSML":
                    { ReturnMealCode = "Kosher"; break; }
                case "LCML":
                    { ReturnMealCode = "Low Calorie"; break; }
                case "LFML":
                    { ReturnMealCode = "Low Cholesterol"; break; }
                case "LPML":
                    { ReturnMealCode = "Low Protein"; break; }
                case "LSML":
                    { ReturnMealCode = "Low Sodium/No Salt"; break; }
                case "MOML":
                    { ReturnMealCode = "Moslem"; break; }
                case "NLML":
                    { ReturnMealCode = "Non-Lactose"; break; }
                case "ORML":
                    { ReturnMealCode = "Oriental"; break; }
                case "PRML":
                    { ReturnMealCode = "Low Purin"; break; }
                case "RVML":
                    { ReturnMealCode = "Raw Vegetarian"; break; }
                case "SFML":
                    { ReturnMealCode = "Seafood"; break; }
                case "VGML":
                    { ReturnMealCode = "Vegetarian/Non Dairy"; break; }

                case "VLML":
                    { ReturnMealCode = "Vegetarian/Milk/Eggs"; break; }
                default:
                    break;
            }
            return ReturnMealCode;
        }

    }

    #endregion

    #region CreateDataTable
    /// <summary>
    /// Summary description for CreateDataTable
    /// </summary>
    public class CreateDataTable
    {
        public CreateDataTable()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Create PaxDetail DataTable
        public DataTable CreatePaxDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Passengers";
            dt.Columns.Add("BookingID", typeof(String));
            dt.Columns.Add("ProdBookingId", typeof(String));
            dt.Columns.Add("PAXID", typeof(String));
            dt.Columns.Add("Title", typeof(String));
            dt.Columns.Add("FName", typeof(String));
            dt.Columns.Add("MName", typeof(String));
            dt.Columns.Add("LName", typeof(String));
            dt.Columns.Add("FrequentFlyerNo", typeof(String));
            dt.Columns.Add("PassportNo", typeof(String));
            dt.Columns.Add("Nationality", typeof(String));
            dt.Columns.Add("PassportExp", typeof(DateTime));
            dt.Columns.Add("POI", typeof(String));
            dt.Columns.Add("POB", typeof(String));
            dt.Columns.Add("DOB", typeof(DateTime));
            dt.Columns.Add("Gender", typeof(String));
            return dt;
        }

        #endregion

        #region Create SectorDetail DataTable
        public DataTable CreateSectorDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Sectors";
            dt.Columns.Add("BookingRef", typeof(String));
            dt.Columns.Add("ProdBookingId", typeof(String));
            dt.Columns.Add("CarierName", typeof(String));
            dt.Columns.Add("FromDestination", typeof(String));
            dt.Columns.Add("FromDateTime", typeof(DateTime));
            dt.Columns.Add("ToDestination", typeof(String));
            dt.Columns.Add("ToDateTime", typeof(DateTime));
            dt.Columns.Add("FlightNo", typeof(String));
            dt.Columns.Add("Class", typeof(String));
            dt.Columns.Add("Status", typeof(String));
            dt.Columns.Add("Fare_Basis", typeof(String));
            dt.Columns.Add("NotValidBefor", typeof(String));
            dt.Columns.Add("NotValidAfter", typeof(String));
            dt.Columns.Add("BaggageAllownce", typeof(String));
            dt.Columns.Add("AirportTerminal", typeof(String));
            dt.Columns.Add("SegID", typeof(String));
            dt.Columns.Add("SegRemarks", typeof(String));

            return dt;
        }
        #endregion

        #region Create SectorDetail DataRow
        public DataRow CreateSectorDtaRow(DataRow dr, string BookingRef, string ProdBookingId, string CarierName,
            string FromDestination, DateTime FromDateTime, string ToDestination, DateTime ToDateTime,
            string FlightNo, string Class, string Status, string Fare_Basis, string NotValidBefor,
            string NotValidAfter, string BaggageAllownce, string AirportTerminal, string SegID, string SegRemarks,
            string JType, string LTD, string Org, string Des, string ValCar)
        {

            dr["BookingRef"] = BookingRef;
            dr["ProdBookingId"] = ProdBookingId;
            dr["CarierName"] = CarierName;
            dr["FromDestination"] = FromDestination;
            dr["FromDateTime"] = FromDateTime;
            dr["ToDestination"] = ToDestination;
            dr["ToDateTime"] = ToDateTime;
            dr["FlightNo"] = FlightNo;
            dr["Class"] = Class;
            dr["Status"] = Status;
            dr["Fare_Basis"] = Fare_Basis;
            dr["NotValidBefor"] = NotValidBefor;
            dr["NotValidAfter"] = NotValidAfter;
            dr["BaggageAllownce"] = BaggageAllownce;
            dr["AirportTerminal"] = AirportTerminal;
            dr["SegID"] = SegID;
            dr["SegRemarks"] = SegRemarks;

            return dr;
        }

        #endregion
        #region Create PaxDetail DtaRow
        public DataRow CreatePaxDtaRow(DataRow dr, string BookingRef, string ProdBookingId, string PAXID,
            string Title, string FName, string MName, string LName,
            string FrequentFlyerNo, string PassportNo, string Nationality,
            string PassportExp, string POI, string POB, string DOB, string Gender)
        {
            dr["BookingID"] = BookingRef;
            dr["ProdBookingId"] = ProdBookingId;
            dr["PAXID"] = PAXID;
            dr["Title"] = Title;
            dr["FName"] = FName;
            dr["MName"] = MName;
            dr["LName"] = LName;
            dr["FrequentFlyerNo"] = FrequentFlyerNo;
            dr["PassportNo"] = PassportNo;
            dr["Nationality"] = Nationality;
            if (PassportExp == "" || PassportExp == null)
            {
                dr["PassportExp"] = Convert.ToDateTime("1/1/1900 00:00:00");
            }
            else
            {
                dr["PassportExp"] = Convert.ToDateTime(PassportExp);
            }
            dr["POI"] = POI;
            dr["POB"] = POB;
            if (DOB == "" || DOB == null)
            {
                dr["DOB"] = Convert.ToDateTime("1/1/1900 00:00:00");
            }
            else
            {
                dr["DOB"] = Convert.ToDateTime(DOB);
            }
            dr["Gender"] = Gender;
            return dr;
        }

        #endregion

        #region Create Suppliment charges DataTable
        public DataTable CreateAmountChargesDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "AmountCharges";
            dt.Columns.Add("BookingRef", typeof(String));
            dt.Columns.Add("ProdBookingId", typeof(String));
            dt.Columns.Add("ChargeId", typeof(String));
            dt.Columns.Add("Chargesfor", typeof(String));
            dt.Columns.Add("CostPrice", typeof(Double));
            dt.Columns.Add("SellPrice", typeof(Double));
            dt.Columns.Add("ChargesStatus", typeof(String));
            dt.Columns.Add("SupplierId", typeof(String));
            dt.Columns.Add("ChargesRemarks", typeof(String));
            dt.Columns.Add("ChargesDate", typeof(DateTime));
            return dt;
        }
        #endregion

        #region Create SectorDetail DataRow
        public DataRow CreateAmountChargesDtaRow(DataRow dr, string BookingRef, string ProdBookingId, string ChargeID,
            string Chargesfor, double CostPrice, double SellPrice, string ChargesStatus, string SupplierID,
            string ChargesRemarks, DateTime ChargesDate)
        {
            dr["BookingRef"] = BookingRef;
            dr["ProdBookingId"] = ProdBookingId;
            dr["ChargeID"] = ChargeID;
            dr["Chargesfor"] = Chargesfor;
            dr["CostPrice"] = CostPrice;
            dr["SellPrice"] = SellPrice;
            dr["ChargesStatus"] = ChargesStatus;
            dr["SupplierID"] = SupplierID;
            dr["ChargesRemarks"] = ChargesRemarks;
            dr["ChargesDate"] = ChargesDate;
            return dr;
        }

        #endregion


    }
    #endregion
}