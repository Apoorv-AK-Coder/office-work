using System;
using System.Web;
using System.Text;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Xml.XPath;
using System.Data;
using System.Net;
using System.Configuration;
using System.IO.Compression;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace TravelSite.Models
{
    public class FlightSearch
    {
        public string SearchFares(string sUnique)
        {
            string sResponse = string.Empty;
            string ss = string.Empty;
            string SearchRQ = string.Empty;
            try
            {
                SearchDetails _objSearch = SearchDetails.Current(sUnique);
                SearchRQ = GetSearchRequest(_objSearch);
                if (SearchRQ.ToLower().IndexOf("error") == -1)
                {
                    List<Itinerary> lst = new List<Itinerary>();
                    sResponse = CallFlightService(SearchRQ, "GetLowFares");
                    ss = sResponse;
                    //string filePath = HttpContext.Current.Server.MapPath(@"~\App_Data\Response\Result\test.xml");
                    //XmlDocument xdoc = new XmlDocument();
                    //filePath = System.IO.File.ReadAllText(filePath);
                    //xdoc.LoadXml(filePath);
                    //sResponse = xdoc.OuterXml;
                    // ...............
                    Itineraries Iten = ParseLowFareResult(sResponse, sUnique);
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = int.MaxValue };
                    sResponse = serializer.Serialize(Iten);
                }
                ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"), sResponse);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return ss;
        }


        #region  WebAPI Call

        public string SearchFaresAPI(string sUnique)
        {
            string sResponse = string.Empty;
            string ss = string.Empty;
            string Req = CreateSearchRequest(sUnique, string.Empty);
            //ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Request/" + sUnique + ".txt"), Req);
            string baseaddress = "http://api.Faressaver.com/api/flights?" + Req + "";
            if (Req.ToLower().IndexOf("error") == -1)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseaddress);
                        request.Method = "get";
                        request.ContentType = "application/json; charset=utf-8";
                        byte[] buffer = new byte[(1024 * 64)];
                        MemoryStream ms = new MemoryStream();
                        HttpWebResponse response = default(HttpWebResponse);
                        try
                        {
                            response = (HttpWebResponse)request.GetResponse();
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            sResponse = reader.ReadToEnd();
                        }
                        catch (Exception ex)
                        {
                            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseaddress);
                            request.Method = "get";
                            request.ContentType = "application/json; charset=utf-8";
                            // byte[] buffer = new byte[(1024 * 64)];
                            // MemoryStream ms = new MemoryStream();
                            //HttpWebResponse response = default(HttpWebResponse);
                            try
                            {
                                response = (HttpWebResponse)request.GetResponse();
                                StreamReader reader = new StreamReader(response.GetResponseStream());
                                sResponse = reader.ReadToEnd();
                            }
                            catch (Exception exx)
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"), sResponse);
            return ss;
        }

        private string CreateSearchRequest(string sUnique, string Data)
        {
            SearchDetails _objSearch = SearchDetails.Current(sUnique);
            StringBuilder sRequest = new StringBuilder();
            string device = string.Empty;
            string CompanyID = string.Empty;
            string UserAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            try
            {
                if (UserAgent != null && (UserAgent.Contains("iPhone") || UserAgent.Contains("Windows Phone") || UserAgent.Contains("Android")))
                {
                    // mobile browser detected
                    device = "M";
                }

                else if (UserAgent != null && UserAgent.Contains("iPad"))
                {
                    device = "T";
                }
                else
                {
                    device = "D";
                }
            }
            catch { }
            try
            {
                if (string.IsNullOrEmpty(_objSearch.CompanyID))
                {
                    _objSearch.CompanyID = CompanyCredentials.CompanyId;
                }
                // string from, string to, string date1, string date2, string adt, string chd, string inf, string infws, string cclass, string preairline, string isreturn, string isdirect, string isflexi, string currency, string compid, string credentialid, string uid, string locale
                //sRequest.Append("from=" + _objSearch.FlightSearchDetails.segments[0].origin + "&to=" + _objSearch.FlightSearchDetails.segments[0].destination);
                //sRequest.Append("&date1=" + Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[0].date).ToString("dd-MM-yyyy") + "&date2=" + (_objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.R ? "" + Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("dd-MM-yyyy") + "" : ""));
                //sRequest.Append("&adt=" + _objSearch.FlightSearchDetails.paxDetails.adults + "" + "&chd=" + _objSearch.FlightSearchDetails.paxDetails.children + "&inf=" + _objSearch.FlightSearchDetails.paxDetails.infants + "&infws=0");
                //sRequest.Append("&cclass=" + _objSearch.FlightSearchDetails.CabinClass + "&preairline=" + (string.IsNullOrEmpty(_objSearch.FlightSearchDetails.PreferedAirlines) ? "ANY" : _objSearch.FlightSearchDetails.PreferedAirlines));
                //sRequest.Append("&isreturn=" + (_objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.R ? "true" : (_objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.O ? "false" : "M")));
                //sRequest.Append("&isdirect=" + (_objSearch.FlightSearchDetails.NonStop ? "true" : "false") + "&isflexi=false" + "&currency=" + CompanyCredentials.Currency + " &compid=" + _objSearch.CompanyID + "&credentialid=" + _objSearch.CompanyID);
                //if (string.IsNullOrEmpty(_objSearch.FlightSearchDetails.uid))
                //    sRequest.Append("&uid=null" + "&locale=EN-GB");
                //else
                //    sRequest.Append("&uid" + _objSearch.FlightSearchDetails.uid + "&locale=EN-GB");


                //sRequest.Append("CompId=" + _objSearch.CompanyID + "&JType=" + (_objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.R ? "R" : (_objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.O ? "O" : "M")) + "&adults=" + _objSearch.FlightSearchDetails.paxDetails.adults + "");
                //sRequest.Append("&children=" + _objSearch.FlightSearchDetails.paxDetails.children + "&infants=" + _objSearch.FlightSearchDetails.paxDetails.infants + "&Airline=" + (string.IsNullOrEmpty(_objSearch.FlightSearchDetails.PreferedAirlines) ? "ALL" : _objSearch.FlightSearchDetails.PreferedAirlines));
                //sRequest.Append("&NonStop=" + (_objSearch.FlightSearchDetails.NonStop ? "true" : "false") + "&currency=usd&cabin=" + _objSearch.FlightSearchDetails.CabinClass);

                //sRequest.Append("&date2=" + (_objSearch.FlightSearchDetails.JourneyType == ENum.JourneyType.R ? "" + Convert.ToDateTime(_objSearch.FlightSearchDetails.segments[1].date).ToString("dd-MMM-yyyy") + "" : ""));
                //sRequest.Append("&locale=EN-US");
                //sRequest.Append("&uid=" + _objSearch.FlightSearchDetails.uid);



                return sRequest.ToString();
            }
            catch { return "<error>Invalid search request</error>"; }
        }

        public string FarematchAPI(string sUnique)
        {
            string sResponse = string.Empty;
            string ss = string.Empty;
            string Req = CreateSearchRequest(sUnique, string.Empty);
            //ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Request/" + sUnique + ".txt"), Req);
            string baseaddress = "http://api.Faressaver.com/api/farematch?" + Req + "";
            if (Req.ToLower().IndexOf("error") == -1)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseaddress);
                        request.Method = "get";
                        request.ContentType = "application/json; charset=utf-8";
                        byte[] buffer = new byte[(1024 * 64)];
                        MemoryStream ms = new MemoryStream();
                        HttpWebResponse response = default(HttpWebResponse);
                        try
                        {
                            response = (HttpWebResponse)request.GetResponse();
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            sResponse = reader.ReadToEnd();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseaddress);
                    request.Method = "get";
                    request.ContentType = "application/json; charset=utf-8";
                    byte[] buffer = new byte[(1024 * 64)];
                    MemoryStream ms = new MemoryStream();
                    HttpWebResponse response = default(HttpWebResponse);
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        sResponse = reader.ReadToEnd();
                    }
                    catch (Exception exx)
                    {

                    }
                }

            }
            ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"), sResponse);

            return ss;
        }

        public bool FareMatchAPI(string Guid)
        {
            SearchDetails searchDetila = SearchDetails.Current(Guid);
            double GrandTotalOld = searchDetila.Itinerary.GrandTotal;
            string Request = Get_FareMatch_SOAP_Request(Guid);
            string response = CallFlightWebAPI(Request, Guid);


            if (ParseFareMatch(response, searchDetila))
            {
                if (GrandTotalOld < searchDetila.Itinerary.GrandTotal)
                {
                    searchDetila.PriceChangeStatus = "PriceChange";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                searchDetila.PriceChangeStatus = "error";
                return false;
            }
        }

        private string CallFlightWebAPI(string Request, string Guid)
        {
            string sResponse = string.Empty;
            string ss = string.Empty;
            //ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Request/" + sUnique + ".txt"), Req);
            string baseaddress = "http://api.Faressaver.com/api/farematch"; // + Request + "";
            if (!string.IsNullOrEmpty(Request) && Request.ToLower().IndexOf("error") == -1)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseaddress);
                        request.Method = "post";
                        request.ContentType = "application/xml;";
                        request.ContentType = "application/xml";
                        request.MediaType = "application/xml";
                        request.Accept = "application/xml";
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        byte[] data = encoder.GetBytes(Request);
                        request.GetRequestStream().Write(data, 0, data.Length);
                        try
                        {
                            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            sResponse = reader.ReadToEnd();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                                StreamReader reader = new StreamReader(response.GetResponseStream());
                                sResponse = reader.ReadToEnd();
                            }
                            catch (Exception exx)
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(baseaddress);
                    request.Method = "get";
                    request.ContentType = "application/json; charset=utf-8";
                    byte[] buffer = new byte[(1024 * 64)];
                    MemoryStream ms = new MemoryStream();
                    HttpWebResponse response = default(HttpWebResponse);
                    try
                    {
                        response = (HttpWebResponse)request.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        sResponse = reader.ReadToEnd();
                    }
                    catch (Exception exx)
                    {

                    }
                }


            }
            ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/FareMatch/" + Guid + ".txt"), sResponse);

            return sResponse;
        }

        public string Httppostcallapi(string Data, string URL, string key,string sUnique)
        {
            
            HttpWebRequest Request;
            string strRS = "";
            string signature = string.Empty;
            try
            {
                 ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                //Trust all certificates
                //System.Net.ServicePointManager.ServerCertificateValidationCallback =
                //    ((sender, certificate, chain, sslPolicyErrors) => false);

                // trust sender
                //System.Net.ServicePointManager.ServerCertificateValidationCallback
                //                = ((sender, cert, chain, errors) => cert.Subject.Contains("YourServerName"));



                Request = (HttpWebRequest)WebRequest.Create(URL);
                Request.Credentials = CredentialCache.DefaultCredentials;
                Request.Proxy = null;

                Request.ContentType = "application/json";
                Request.Method = "POST";
                Request.Accept = "application/json";
                Request.Headers.Add("token: " + key + "");
                Request.Headers.Add("Accept-Encoding: gzip");
                Request.ProtocolVersion = HttpVersion.Version10;

                HttpWebResponse htpResponse = null;
                Stream s = Request.GetRequestStream();
                s.Write(System.Text.Encoding.ASCII.GetBytes(Data), 0, Data.Length);
                s.Close();
                try
                {
                    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                    Stream compressedStream = Response.GetResponseStream();

                    Stream decompressedStream = null;
                    if (Response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        decompressedStream = new GZipStream(compressedStream, CompressionMode.Decompress);
                    }
                    else
                    {
                        decompressedStream = compressedStream;
                    }

                    using (StreamReader srmResponse = new StreamReader(decompressedStream))
                    {
                        strRS = srmResponse.ReadToEnd();
                    }

                    ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"), strRS);
                }
                catch (WebException EX)
                {
                    Stream receiveStream = null;

                    if (EX.Response != null)
                    {

                        receiveStream = EX.Response.GetResponseStream();

                        StreamReader streamReader = new StreamReader(receiveStream, Encoding.UTF8);
                        string result = streamReader.ReadToEnd();
                        ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"), result);
                        return result;
                    }
                    else
                    {

                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                strRS = ex.Message; ;
            }
            //BaseItinerary routes_list = JsonConvert.DeserializeObject<BaseItinerary>(strRS);
            return strRS;
        }

        #endregion




        private string CallFlightService(string RQ, string SOAPActionName)
        {
            //return "";
            HttpWebRequest Request;
            try
            {
                Request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["FlightBookingEngine"].ToString());
                Request.Credentials = CredentialCache.DefaultCredentials;
                Request.Proxy = null;
                Request.Headers.Add("Accept-Encoding: gzip");
                Request.Headers.Add("SOAPAction: \"http://tempuri.org/" + SOAPActionName + "\"");
                Request.ContentType = "text/xml;charset=UTF-8";
                Request.Method = "POST";
                Stream s = Request.GetRequestStream();
                s.Write(System.Text.Encoding.ASCII.GetBytes(RQ.ToString()), 0, RQ.ToString().Length);

                s.Close();

                XmlDocument XMLdoc = new XmlDocument();
                try
                {
                    HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                    Stream compressedStream = Response.GetResponseStream();
                    Stream decompressedStream = null;
                    if (Response.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        decompressedStream = new GZipStream(compressedStream, CompressionMode.Decompress);
                    }
                    else
                    {
                        decompressedStream = compressedStream;
                    }
                    XMLdoc.Load(decompressedStream);

                    XmlNode filteredResponse = XMLdoc.SelectSingleNode("//*[local-name()='Body']/*");
                    return filteredResponse.OuterXml;
                    // return XMLdoc.OuterXml;
                }
                catch (WebException EX)
                {
                    Stream receiveStream = null;
                    if (EX.Response != null)
                    {
                        receiveStream = EX.Response.GetResponseStream();
                        StreamReader streamReader = new StreamReader(receiveStream, Encoding.UTF8);
                        string result = streamReader.ReadToEnd();
                        XmlDocument responseXmlDocument = new XmlDocument();
                        XmlDocument filteredDocument = null;
                        responseXmlDocument.LoadXml(result);
                        XmlNode filteredResponse = responseXmlDocument.SelectSingleNode("//*[local-name()='Body']/*");
                        filteredDocument = new XmlDocument();
                        return filteredResponse.OuterXml;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Itinerary> GetItineraries(string sUnique)
        {
            List<Itinerary> tmp = new List<Itinerary>();
            string strJason = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"));
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = int.MaxValue };
            tmp = serializer.Deserialize<List<Itinerary>>(strJason);
            //dynamic  tmp = JsonConvert.DeserializeObject<dynamic>(strJason);
            try
            {
                //BaseItinerary Iten =  serializer.Deserialize<BaseItinerary>(strJason);
                JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                //BaseItinerary routes_list = (BaseItinerary)json_serializer.DeserializeObject(strJason);
                 tmp = (List<Itinerary>) json_serializer.Deserialize<List<Itinerary>>(strJason);
                return tmp;
            }
            catch (Exception ex)
            {

            }


            return tmp;
        }
        public Itineraries  GetItinerariesNew(string sUnique)
        {
            string strJason = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"));
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = int.MaxValue };

            try
            {
                var jsonResult = JsonConvert.DeserializeObject(strJason).ToString();
                Itineraries routes_list = JsonConvert.DeserializeObject<Itineraries>(jsonResult);
                //BaseItinerary routes_list =JsonConvert.DeserializeObject<BaseItinerary>(strJason);
                //dynamic tmp  = JsonConvert.DeserializeObject<BaseItinerary>(strJason);
                return routes_list;
            }
            catch(Exception ex)
            {

            }

            return serializer.Deserialize<Itineraries>(strJason);
        }
        

        public Itinerary GetItineraryNew(string sUnique, string sIndex, string sProvider)
        {
            string strJason = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/Response/Result/" + sUnique + ".txt"));
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = int.MaxValue };
            var jsonResult = JsonConvert.DeserializeObject(strJason).ToString();
            Itineraries Iten = JsonConvert.DeserializeObject<Itineraries>(jsonResult);
           
            List<Itinerary> it = (from Itinerary i in Iten.Items
                                  where i.IndexNumber == Convert.ToInt32(sIndex) && i.Provider == sProvider
                                  select i).ToList();

            return it.Count > 0 ? it[0] : null;
        }
        public void RemoveItinerary(string sUnique)
        {
            SearchDetails SearchDetails = SearchDetails.Current(sUnique);
            Itineraries itn = GetItinerariesNew(sUnique);
            Itineraries itnNew = new Itineraries();
            itnNew.Items = (from Itinerary i in itn.Items
                            where i.IndexNumber != SearchDetails.IndexNumber || i.Provider != SearchDetails.Provider
                            select i).ToList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer() { MaxJsonLength = int.MaxValue };
            string sResponse = serializer.Serialize(itnNew);

            ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/FCheck/" + sUnique + ".txt"), sResponse);
        }

        public List<Itinerary> GetAltOptionFlights(string sUnique)
        {
            SearchDetails SearchDetails = SearchDetails.Current(sUnique);
            List<Itinerary> Iten = new List<Itinerary>();
            Itineraries _Itineraries = GetItinerariesNew(sUnique);
            List<Itinerary> It1 = (from Itinerary i in _Itineraries.Items
                                   where i.IndexNumber != SearchDetails.IndexNumber && i.ValCarrier == SearchDetails.Itinerary.ValCarrier
                                   select i).ToList();
            It1 = It1.GroupBy(p => new { p.ValCarrier })
                 .Select(g => g.First()).ToList();

            List<Itinerary> It2 = (from Itinerary i in _Itineraries.Items
                                   where i.ValCarrier != SearchDetails.Itinerary.ValCarrier
                                   select i).ToList();
            It2 = It2.GroupBy(p => new { p.ValCarrier })
               .Select(g => g.First()).ToList();
            List<Itinerary> It3 = (from Itinerary i in _Itineraries.Items
                                   where i.ValCarrier != SearchDetails.Itinerary.ValCarrier
                                   select i).ToList();
            It3 = It3.GroupBy(p => new { p.ValCarrier })
               .Select(g => g.First()).ToList();
            List<Itinerary> It4 = (from Itinerary i in _Itineraries.Items
                                   where i.ValCarrier != SearchDetails.Itinerary.ValCarrier
                                   select i).ToList();
            It4 = It4.GroupBy(p => new { p.ValCarrier })
               .Select(g => g.First()).ToList();
            if (It1.Count > 0 && It2.Count > 0)
            {
                Iten.Add(It1[0]);
                Iten.Add(It2[0]);

            }
            else if (It1.Count == 0)
            {
                Iten.Add(It2[0]);
                if (It2.Count >= 2)
                    Iten.Add(It2[1]);
                if (It2.Count >= 3)
                    Iten.Add(It2[2]);
                if (It2.Count >= 4)
                    Iten.Add(It2[3]);
            }
            else if (It2.Count == 0)
            {
                Iten.Add(It2[0]);
                if (It2.Count >= 2)
                    Iten.Add(It2[1]);
                if (It2.Count >= 3)
                    Iten.Add(It2[2]);
                if (It2.Count >= 4)
                    Iten.Add(It2[3]);
            }
            else if (It3.Count == 0)
            {
                Iten.Add(It3[0]);
                if (It3.Count >= 2)
                    Iten.Add(It3[1]);
                if (It3.Count >= 3)
                    Iten.Add(It3[2]);
                if (It3.Count >= 4)
                    Iten.Add(It3[3]);
            }
            else if (It4.Count == 0)
            {
                Iten.Add(It4[0]);
                if (It4.Count >= 2)
                    Iten.Add(It4[1]);
                if (It4.Count >= 3)
                    Iten.Add(It4[2]);
                if (It4.Count >= 4)
                    Iten.Add(It4[3]);
            }
            return Iten;
        }



        public bool FareMatch(string Guid)
        {
            SearchDetails searchDetila = SearchDetails.Current(Guid);
            double GrandTotalOld = searchDetila.Itinerary.GrandTotal;
            if (ParseFareMatch(CallFlightService(Get_FareMatch_SOAP_Request(Guid), "Fare_Availbility_Match"), searchDetila))
            {
                if (GrandTotalOld < searchDetila.Itinerary.GrandTotal)
                {
                    searchDetila.PriceChangeStatus = "PriceChange";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                searchDetila.PriceChangeStatus = "error";
                return false;
            }
        }
        public void BookFlight(string Guid)
        {
            //BookFlight
            SearchDetails searchDetila = SearchDetails.Current(Guid);
            ChackAndSetPnr(CallFlightService(Get_FlightBooking_Request(Guid), "BookFlight"), searchDetila);

            //SaveInDB obj = new SaveInDB();
            //obj.UpdatePnrAndBookingStatus(Guid);
        }

        public Itineraries RecLocRetrieval(string recloc, string companyID, string provider, string destination)
        {
            Itineraries Itineraries = new Itineraries();
            Itineraries = ParsePNRRetrievalResult(CallFlightService(Get_PNRRetrieval_SOAP_Request(recloc, companyID, provider, destination), "RetrieveRecordLocator"));
            return Itineraries;
        }

        
        private string GetSearchRequest(SearchDetails objSearch)
        {
            string query = "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                      "<soap:Body>" +
                        "<GetLowFares xmlns=\"http://tempuri.org/\">" +
                          "<FligthSearchRQ> <![CDATA[" + SearchXmlRQ(objSearch) + "]]></FligthSearchRQ>" +
                        "</GetLowFares>" +
                      "</soap:Body>" +
                    "</soap:Envelope>";
            return query;

        }
        private string Get_FareMatch_SOAP_Request(string Guid)
        {
            string query = "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
              "<soap:Body>" +
                "<Fare_Availbility_Match xmlns=\"http://tempuri.org/\">" +
                  "<_FareMatchRQ><![CDATA[" + FareMatchXmlRQ(Guid) + "]]></_FareMatchRQ>" +
                "</Fare_Availbility_Match>" +
              "</soap:Body>" +
            "</soap:Envelope>";
            return query;

        }


        private string Get_PNRRetrieval_SOAP_Request(string recloc, string companyID, string provider, string destination)
        {


            string query = "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                               "<soap:Body>" +
                                 "<RetrieveRecordLocator xmlns=\"http://tempuri.org/\">" +
                                   "<RecordLocatorRQ> <![CDATA[" + PNRRetrieveXmlRQ(recloc, companyID, provider, destination) + "]]></RecordLocatorRQ>" +
                                 "</RetrieveRecordLocator>" +
                               "</soap:Body>" +
                             "</soap:Envelope>";
            return query;

        }

        private string Get_FlightBooking_Request(string Guid)
        {


            string query = "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
              "<soap:Body>" +
                "<BookFlight xmlns=\"http://tempuri.org/\">" +
                  "<_BookFlightRQ><![CDATA[" + FlightBookingRQ(Guid) + "]]></_BookFlightRQ>" +
                "</BookFlight>" +
              "</soap:Body>" +
            "</soap:Envelope>";

            #region log write
            SearchDetails _searchDetails = SearchDetails.Current(Guid);
            string Pth = HttpContext.Current.Server.MapPath(@"~\App_Data\BookingRQ\" + _searchDetails.EmailID + ".txt");
            File.WriteAllText(Pth, query);
            #endregion

            return query;

        }
        private string SearchXmlRQ(SearchDetails objSearch)
        {
            string xmlSearchRQ = string.Empty;

            xmlSearchRQ = "<AirFareSearchRQ>" +
          "<Authentication>" +
              //"<CompanyId>" + _searchRQ.CompanyID + "</CompanyId>" +
              "<CompanyId>" + objSearch.CompanyID + "</CompanyId>" +
              "<CredentialId>" + objSearch.HapID + "</CredentialId>" +
              "<CredentialPassword>" + objSearch.HapPassword + "</CredentialPassword>" +
              "<CredentialType>" + objSearch.HapType + "</CredentialType>" +
               "<SearchID>" + objSearch.Guid + "</SearchID>" +
          "</Authentication>" +
          "<JourneyType>" + objSearch.FlightSearchDetails.JourneyType + "</JourneyType>" +
          "<Segments>" +
              segmentXML(objSearch) +
          "</Segments>" +
          "<PaxDetail>" +
              "<NoAdult>" + objSearch.FlightSearchDetails.paxDetails.adults + "</NoAdult>" +
              "<NoChild>" + objSearch.FlightSearchDetails.paxDetails.children + "</NoChild>" +
              "<NoInfant>" + objSearch.FlightSearchDetails.paxDetails.infants + "</NoInfant>" +
              "<NoInfantWithSeat>" + objSearch.FlightSearchDetails.paxDetails.infantOnSeat + "</NoInfantWithSeat>" +
          "</PaxDetail>" +
          "<Flexi>" + (objSearch.FlightSearchDetails.flexi ? 1 : 0) + "</Flexi>" +
          "<Direct>" + (objSearch.FlightSearchDetails.directFlight ? 1 : 0) + "</Direct>" +
          "<Cabin>" +
              "<Class>" + objSearch.FlightSearchDetails.cabinClass + "</Class>" +
          "</Cabin>";
            if (string.IsNullOrEmpty(objSearch.FlightSearchDetails.PreferedAirlines))
            {
                xmlSearchRQ += "<Airlines>" +
                 "<Airline>All</Airline>" +
             "</Airlines>";
            }
            else
            {
                xmlSearchRQ += "<Airlines>" +
                 "<Airline>" + objSearch.FlightSearchDetails.PreferedAirlines + "</Airline>" +
             "</Airlines>";
            }

            xmlSearchRQ += "</AirFareSearchRQ>";
            return xmlSearchRQ;
        }
        private string PNRRetrieveXmlRQ(string recloc, string companyID, string provider, string destination)
        {
            string xmlSearchRQ = string.Empty;

            xmlSearchRQ = "<PNRRQ>" +
                          "<Authentication>" +
                            "<CompanyId>" + companyID + "</CompanyId> " +
                          "</Authentication>" +
                          "<Provider>" + provider + "</Provider>" +
                          "<PNR>" + recloc + "</PNR>" +
                          "<Destination>" + destination + "</Destination>" +
                        "</PNRRQ>";
            return xmlSearchRQ;
        }

        private string FareMatchXmlRQ(string Guid)
        {
            SearchDetails _searchDetails = SearchDetails.Current(Guid);

            if (_searchDetails.Itinerary.Provider == "2T") { _searchDetails.Itinerary.Provider = "1T"; }


            string xmlSearchRQ = string.Empty;
            xmlSearchRQ = "<FareMatchRQ>" +
               "<Authentication>" +
                 "<CompanyId>" + _searchDetails.CompanyID + "</CompanyId>" +
                 "<CredentialId>" + _searchDetails.HapID + "</CredentialId>" +
                 "<CredentialPassword>" + _searchDetails.HapPassword + "</CredentialPassword>" +
                 "<CredentialType>" + _searchDetails.HapType + "</CredentialType>" +
               "</Authentication>" +
                 "<Itinerary>" +
                 "<PCC>" + _searchDetails.Itinerary.PCC + "</PCC>" +
                 "<BaseFare>" + _searchDetails.Itinerary.BaseFare + "</BaseFare>" +
                 "<Taxes>" + _searchDetails.Itinerary.Taxes + "</Taxes>" +
                 "<TotalPrice>" + _searchDetails.Itinerary.TotalPrice + "</TotalPrice>" +
                 //"<ApproximateBasePrice>" + _searchDetails.Itinerary.ApproximateBasePrice + "</ApproximateBasePrice>" +
                 //"<ApproximateTotalPrice>" + _searchDetails.Itinerary.ApproximateTotalPrice + "</ApproximateTotalPrice>" +
                 "<MarkUp>" + _searchDetails.Itinerary.MarkUp + "</MarkUp>" +
                 "<Commission>" + _searchDetails.Itinerary.Commission + "</Commission>" +
                 "<Safi>" + _searchDetails.Itinerary.Safi + "</Safi>" +
                 "<GrandTotal>" + _searchDetails.Itinerary.GrandTotal + "</GrandTotal>" +
                 "<Currency>" + _searchDetails.Itinerary.Currency + "</Currency>" +
                 //"<ApproximateCurrency>" + _searchDetails.Itinerary.ApproximateCurrency + "</ApproximateCurrency>" +
                 //  "<CurrencyExchange BaseCurrency=\"" + _searchDetails.Itinerary.CurrencyExchange.BaseCurrency + "\" RequestedCurrency=\"" +
                 // _searchDetails.Itinerary.CurrencyExchange.RequestedCurrency + "\" ExchangeRate=\"" + _searchDetails.Itinerary.CurrencyExchange.ExchangeRate +
                 // "\" ></CurrencyExchange>" +
                 "<FareType>" + _searchDetails.Itinerary.FareType + "</FareType>" +
                 "<IndexNumber>" + _searchDetails.Itinerary.IndexNumber + "</IndexNumber>" +
                 "<Provider>" + _searchDetails.Itinerary.Provider + "</Provider>" +
                 "<ValCarrier>" + _searchDetails.Itinerary.ValCarrier + "</ValCarrier>" +
                 "<Passengers>";

            //foreach (var p in _searchDetails.Itinerary.Passengers)
            //{
            //    if (p.PassengerType == "ADT")
            //    {
            //        xmlSearchRQ += "<Passenger>" +
            //      "<PassengerType>ADT</PassengerType>" +
            //      "<NoOfPassenger>" + p.NoOfPassenger + "</NoOfPassenger>" +
            //      "<BaseFare>" + p.BaseFare + "</BaseFare>" +
            //      "<Taxes>" + p.Taxes + "</Taxes>" +
            //      "<MarkUp>" + p.MarkUp + "</MarkUp>" +
            //      "<Commission>" + p.Commission + "</Commission>" +
            //      "<Safi>" + p.Safi + "</Safi>" +
            //    "</Passenger>";
            //    }
            //    else if (p.PassengerType == "CHD" || p.PassengerType == "CNN")
            //    {
            //        xmlSearchRQ += "<Passenger>" +
            //      "<PassengerType>ADT</PassengerType>" +
            //      "<NoOfPassenger>" + p.NoOfPassenger + "</NoOfPassenger>" +
            //      "<BaseFare>" + p.BaseFare + "</BaseFare>" +
            //      "<Taxes>" + p.Taxes + "</Taxes>" +
            //      "<MarkUp>" + p.MarkUp + "</MarkUp>" +
            //      "<Commission>" + p.Commission + "</Commission>" +
            //      "<Safi>" + p.Safi + "</Safi>" +
            //    "</Passenger>";
            //    }
            //    else if (p.PassengerType == "INF")
            //    {
            //        xmlSearchRQ += "<Passenger>" +
            //      "<PassengerType>ADT</PassengerType>" +
            //      "<NoOfPassenger>" + p.NoOfPassenger + "</NoOfPassenger>" +
            //      "<BaseFare>" + p.BaseFare + "</BaseFare>" +
            //      "<Taxes>" + p.Taxes + "</Taxes>" +
            //      "<MarkUp>" + p.MarkUp + "</MarkUp>" +
            //      "<Commission>" + p.Commission + "</Commission>" +
            //      "<Safi>" + p.Safi + "</Safi>" +
            //    "</Passenger>";
            //    }
            //}


            xmlSearchRQ += "</Passengers>" +
            "<FareBasisCodes />" +
            "<Sectors>";
            foreach (Sector IS in _searchDetails.Itinerary.Sectors)
            {
                xmlSearchRQ += "<Sector>" +
                  "<AirV>" + IS.AirV + "</AirV>" +
                  "<AirlineName>" + IS.AirlineName + "</AirlineName>" +
                  "<AirlineLogoPath />" +
                  "<Class>" + IS.Class + "</Class>" +
                  "<CabinClass>" +
                    "<Code>" + IS.CabinClass.Code + "</Code>" +
                    "<Name>" + IS.CabinClass.Name + "</Name>" +
                  "</CabinClass>" +
                  "<NoSeats>" + IS.NoSeats + "</NoSeats>" +
                  "<FltNum>" + IS.FltNum + "</FltNum>" +
                  "<Departure>" +
                    "<AirportCode>" + IS.Departure.AirportCode + "</AirportCode>" +
                    "<GeoLocation>" + IS.Departure.GeoLocation + "</GeoLocation>" +
                    "<Terminal>" + IS.Departure.Terminal + "</Terminal>" +
                    "<Date>" + IS.Departure.Date + "</Date>" +
                    "<Time>" + IS.Departure.Time + "</Time>" +
                    "<DateTimeStamp>" + IS.Departure.DateTimeStamp + "</DateTimeStamp>" +
                  "</Departure>" +
                  "<Arrival>" +
                      "<AirportCode>" + IS.Arrival.AirportCode + "</AirportCode>" +
                    "<GeoLocation>" + IS.Arrival.GeoLocation + "</GeoLocation>" +
                    "<Terminal>" + IS.Arrival.Terminal + "</Terminal>" +
                    "<Date>" + IS.Arrival.Date + "</Date>" +
                    "<Time>" + IS.Arrival.Time + "</Time>" +
                    "<DateTimeStamp>" + IS.Arrival.DateTimeStamp + "</DateTimeStamp>" +
                  "</Arrival>" +
                  "<EquipType>" + IS.EquipType + "</EquipType>" +
                  "<ElapsedTime>" + IS.ElapsedTime + "</ElapsedTime>" +
                  "<ActualTime>" + IS.ActualTime + "</ActualTime>" +
                  "<TechStopOver>" + IS.TechStopOver + "</TechStopOver>" +
                  "<Status>" + IS.Status + "</Status>" +
                  "<IsReturn>" + IS.IsReturn.ToString().ToLower() + "</IsReturn>" +
                  "<OptrCarrier>" + IS.OptrCarrier + "</OptrCarrier>" +
                  "<OptrCarrierDes>" + IS.OptrCarrierDes + "</OptrCarrierDes>" +
                  "<MrktCarrier>" + IS.MrktCarrier + "</MrktCarrier>" +
                  "<MrktCarrierDes>" + IS.MrktCarrierDes + "</MrktCarrierDes>" +
                  "<BaggageInfo>" + IS.BaggageInfo + "</BaggageInfo>" +
                  "<TransitTime>" + IS.TransitTime + "</TransitTime>" +
                  "<Key>" + IS.Key + "</Key>" +
                  "<Distance>" + IS.Distance + "</Distance>" +
                  "<ETicket>" + IS.ETicket + "</ETicket>" +
                  "<ChangeOfPlane>" + IS.ChangeOfPlane + "</ChangeOfPlane>" +
                  "<ParticipantLevel>" + IS.ParticipantLevel + "</ParticipantLevel>" +
                  "<OptionalServicesIndicator>" + IS.OptionalServicesIndicator + "</OptionalServicesIndicator>" +
                  "<AvailabilitySource>" + IS.AvailabilitySource + "</AvailabilitySource>" +
                  "<Group>" + IS.Group + "</Group>" +
                  "<LinkAvailability>" + IS.LinkAvailability + "</LinkAvailability>" +
                  "<PolledAvailabilityOption>" + IS.PolledAvailabilityOption + "</PolledAvailabilityOption>" +
                  "<BookingCodeInfo>" + IS.BookingCodeInfo + "</BookingCodeInfo>" +
                "</Sector>";
            }
            xmlSearchRQ += "</Sectors>" +
             "<Key>" + _searchDetails.Itinerary.Key + "</Key>" +
           "</Itinerary>" +
         "</FareMatchRQ>";

            return xmlSearchRQ;
        }
        private string FlightBookingRQ(string Guid)
        {
            SearchDetails _searchDetails = SearchDetails.Current(Guid);
            string xmlSearchRQ = string.Empty;
            xmlSearchRQ += "<BookingRQ>" +
                              "<SessionId>A473B93C-E49B-4F6F-AB9F-A4A300A3A732</SessionId>" +
                               "<Authentication>" +
                                 "<CompanyId>" + _searchDetails.flightFareSearchRQ.CompanyID + "</CompanyId>" +
                                 "<CredentialId>" + _searchDetails.flightFareSearchRQ.HAP + "</CredentialId>" +
                                 "<CredentialPassword>" + _searchDetails.flightFareSearchRQ.HAP_Password + "</CredentialPassword>" +
                                 "<CredentialType>" + _searchDetails.flightFareSearchRQ.HAP_Type + "</CredentialType>" +
                              "</Authentication>" +
                              "<Itinerary>" +
                                 "<BaseFare>" + _searchDetails.Itinerary.BaseFare + "</BaseFare>" +
                                 "<Taxes>" + _searchDetails.Itinerary.Taxes + "</Taxes>" +
                                 "<TotalPrice>" + _searchDetails.Itinerary.TotalPrice + "</TotalPrice>" +
                                 //"<ApproximateBasePrice>" + _searchDetails.Itinerary.ApproximateBasePrice + "</ApproximateBasePrice>" +
                                 //"<ApproximateTotalPrice>" + _searchDetails.Itinerary.ApproximateTotalPrice + "</ApproximateTotalPrice>" +
                                 "<MarkUp>" + _searchDetails.Itinerary.MarkUp + "</MarkUp>" +
                                 "<Commission>" + _searchDetails.Itinerary.Commission + "</Commission>" +
                                 "<Safi>" + _searchDetails.Itinerary.Safi + "</Safi>" +
                                 "<GrandTotal>" + _searchDetails.Itinerary.GrandTotal + "</GrandTotal>" +
                                 "<Currency>" + _searchDetails.Itinerary.Currency + "</Currency>" +
                                 //"<ApproximateCurrency>" + _searchDetails.Itinerary.ApproximateCurrency + "</ApproximateCurrency>" +
                                 "<FareType>" + _searchDetails.Itinerary.FareType + "</FareType>" +
                                 "<IndexNumber>" + _searchDetails.Itinerary.IndexNumber + "</IndexNumber>" +
                                 "<Provider>" + _searchDetails.Itinerary.Provider + "</Provider>" +
                                 "<ValCarrier>" + _searchDetails.Itinerary.ValCarrier + "</ValCarrier>" +
                                 "<Passengers>";
            if (_searchDetails.Itinerary.AdultInfo.NoAdult > 0)
            {
                xmlSearchRQ += "<Passenger>" +
                  "<PassengerType>ADT</PassengerType>" +
                  "<NoOfPassenger>" + _searchDetails.Itinerary.AdultInfo.NoAdult + "</NoOfPassenger>" +
                  "<BaseFare>" + _searchDetails.Itinerary.AdultInfo.AdtBFare + "</BaseFare>" +
                  "<Taxes>" + _searchDetails.Itinerary.AdultInfo.AdTax + "</Taxes>" +
                  "<MarkUp>" + _searchDetails.Itinerary.AdultInfo.MarkUp + "</MarkUp>" +
                  "<Commission>" + _searchDetails.Itinerary.AdultInfo.Commission + "</Commission>" +
                  "<Safi>" + _searchDetails.Itinerary.AdultInfo.Safi + "</Safi>" +
                "</Passenger>";
            }
            if (_searchDetails.Itinerary.ChildInfo.NoChild > 0)
            {
                xmlSearchRQ += "<Passenger>" +
                  "<PassengerType>CNN</PassengerType>" +
                  "<NoOfPassenger>" + _searchDetails.Itinerary.ChildInfo.NoChild + "</NoOfPassenger>" +
                  "<BaseFare>" + _searchDetails.Itinerary.ChildInfo.ChdBFare + "</BaseFare>" +
                  "<Taxes>" + _searchDetails.Itinerary.ChildInfo.CHTax + "</Taxes>" +
                  "<MarkUp>" + _searchDetails.Itinerary.ChildInfo.MarkUp + "</MarkUp>" +
                  "<Commission>" + _searchDetails.Itinerary.ChildInfo.Commission + "</Commission>" +
                  "<Safi>" + _searchDetails.Itinerary.ChildInfo.Safi + "</Safi>" +
                "</Passenger>";
            }
            if (_searchDetails.Itinerary.InfantInfo.NoInfant > 0)
            {
                xmlSearchRQ += "<Passenger>" +
                  "<PassengerType>INF</PassengerType>" +
                  "<NoOfPassenger>" + _searchDetails.Itinerary.InfantInfo.NoInfant + "</NoOfPassenger>" +
                  "<BaseFare>" + _searchDetails.Itinerary.InfantInfo.InfBFare + "</BaseFare>" +
                  "<Taxes>" + _searchDetails.Itinerary.InfantInfo.InTax + "</Taxes>" +
                  "<MarkUp>" + _searchDetails.Itinerary.InfantInfo.MarkUp + "</MarkUp>" +
                  "<Commission>" + _searchDetails.Itinerary.InfantInfo.Commission + "</Commission>" +
                  "<Safi>" + _searchDetails.Itinerary.InfantInfo.Safi + "</Safi>" +
                "</Passenger>";
            }
            if (_searchDetails.Itinerary.InfantInfoWithSeat.NoInfant > 0)
            {
                xmlSearchRQ += "<Passenger>" +
                  "<PassengerType>INF</PassengerType>" +
                  "<NoOfPassenger>" + _searchDetails.Itinerary.InfantInfoWithSeat.NoInfant + "</NoOfPassenger>" +
                  "<BaseFare>" + _searchDetails.Itinerary.InfantInfoWithSeat.InfBFare + "</BaseFare>" +
                  "<Taxes>" + _searchDetails.Itinerary.InfantInfoWithSeat.InTax + "</Taxes>" +
                  "<MarkUp>" + _searchDetails.Itinerary.InfantInfoWithSeat.MarkUp + "</MarkUp>" +
                  "<Commission>" + _searchDetails.Itinerary.InfantInfoWithSeat.Commission + "</Commission>" +
                  "<Safi>" + _searchDetails.Itinerary.InfantInfoWithSeat.Safi + "</Safi>" +
                "</Passenger>";
            }

            xmlSearchRQ += "</Passengers>" +
"<FareBasisCodes />" +
"<Sectors>";
            foreach (Sector IS in _searchDetails.Itinerary.Sectors)
            {
                xmlSearchRQ += "<Sector>" +
                  "<AirV>" + IS.AirV + "</AirV>" +
                  "<AirlineName>" + IS.AirlineName + "</AirlineName>" +
                  "<AirlineLogoPath />" +
                  "<Class>" + IS.Class + "</Class>" +
                  "<CabinClass>" +
                    "<Code>" + IS.CabinClass.Code + "</Code>" +
                    "<Name>" + IS.CabinClass.Name + "</Name>" +
                  "</CabinClass>" +
                  "<NoSeats>" + IS.NoSeats + "</NoSeats>" +
                  "<FltNum>" + IS.FltNum + "</FltNum>" +
                  "<Departure>" +
                    "<AirportCode>" + IS.Departure.AirportCode + "</AirportCode>" +
                    "<GeoLocation>" + IS.Departure.GeoLocation + "</GeoLocation>" +
                    "<Terminal>" + IS.Departure.Terminal + "</Terminal>" +
                    "<Date>" + IS.Departure.Date + "</Date>" +
                    "<Time>" + IS.Departure.Time + "</Time>" +
                    "<DateTimeStamp>" + IS.Departure.DateTimeStamp + "</DateTimeStamp>" +
                  "</Departure>" +
                  "<Arrival>" +
                      "<AirportCode>" + IS.Arrival.AirportCode + "</AirportCode>" +
                    "<GeoLocation>" + IS.Arrival.GeoLocation + "</GeoLocation>" +
                    "<Terminal>" + IS.Arrival.Terminal + "</Terminal>" +
                    "<Date>" + IS.Arrival.Date + "</Date>" +
                    "<Time>" + IS.Arrival.Time + "</Time>" +
                    "<DateTimeStamp>" + IS.Arrival.DateTimeStamp + "</DateTimeStamp>" +
                  "</Arrival>" +
                  "<EquipType>" + IS.EquipType + "</EquipType>" +
                  "<ElapsedTime>" + IS.ElapsedTime + "</ElapsedTime>" +
                  "<ActualTime>" + IS.ActualTime + "</ActualTime>" +
                  "<TechStopOver>" + IS.TechStopOver + "</TechStopOver>" +
                  "<Status>" + IS.Status + "</Status>" +
                  "<IsReturn>" + IS.IsReturn.ToString().ToLower() + "</IsReturn>" +
                  "<OptrCarrier>" + IS.OptrCarrier + "</OptrCarrier>" +
                  "<OptrCarrierDes>" + IS.OptrCarrierDes + "</OptrCarrierDes>" +
                  "<MrktCarrier>" + IS.MrktCarrier + "</MrktCarrier>" +
                  "<MrktCarrierDes>" + IS.MrktCarrierDes + "</MrktCarrierDes>" +
                  "<BaggageInfo>" + IS.BaggageInfo + "</BaggageInfo>" +
                  "<TransitTime>" + IS.TransitTime + "</TransitTime>" +
                  "<Key>" + IS.Key + "</Key>" +
                  "<Distance>" + IS.Distance + "</Distance>" +
                  "<ETicket>" + IS.ETicket + "</ETicket>" +
                  "<ChangeOfPlane>" + IS.ChangeOfPlane + "</ChangeOfPlane>" +
                  "<ParticipantLevel>" + IS.ParticipantLevel + "</ParticipantLevel>" +
                  "<OptionalServicesIndicator>" + IS.OptionalServicesIndicator + "</OptionalServicesIndicator>" +
                  "<AvailabilitySource>" + IS.AvailabilitySource + "</AvailabilitySource>" +
                  "<Group>" + IS.Group + "</Group>" +
                  "<LinkAvailability>" + IS.LinkAvailability + "</LinkAvailability>" +
                  "<PolledAvailabilityOption>" + IS.PolledAvailabilityOption + "</PolledAvailabilityOption>" +
                "</Sector>";
            }
            xmlSearchRQ += "</Sectors>" +
         "<Key>" + _searchDetails.Itinerary.Key + "</Key>" +
       "</Itinerary>";
            xmlSearchRQ += _searchDetails.PricingInfo;
            xmlSearchRQ += "<PaxDetails>";
            foreach (Pax pax in _searchDetails.Passenger)
            {
                string PType = "ADT";
                if (pax.PaxType.ToLower() == "adult" || pax.PaxType.ToLower() == "adt")
                    PType = "ADT";
                else if (pax.PaxType.ToLower() == "child" || pax.PaxType.ToLower() == "chd" || pax.PaxType.ToLower() == "cnn")
                    PType = "CNN";
                if (pax.PaxType.ToLower() == "infant" || pax.PaxType.ToLower() == "inf")
                    PType = "INF";
                if (pax.PaxType.ToLower() == "infantwithseat" || pax.PaxType.ToLower() == "ins" || pax.PaxType.ToLower() == "infant with seat")
                    PType = "INS";

                xmlSearchRQ += "<PaxDetail>" +
                    "<Type>" + PType + "</Type>" +
                    "<Title>" + pax.Title + "</Title>" +
                    "<FirstName>" + pax.FirstName + "</FirstName>" +
                    "<LastName>" + pax.LastName + "</LastName>" +
                    "<Age />" +
                    "<DOB>" + pax.DOB.ToString("dd-MM-yyyy") + "</DOB>" +
                    "<Gender>" + ((pax.Gender.ToLower() == "male" || pax.Gender.ToLower() == "m") ? "M" : "F") + "</Gender>" +
                    "<Email>" + _searchDetails.EmailID + "</Email>" +
                    "<Phone>" + _searchDetails.PhoneNo + "</Phone>" +
                    "<Meal>" + pax.Meal + "</Meal>" +
                    "<Seat>" + pax.Seat + "</Seat>" +
                    "<Passport />" +
                    "<Nationality />" +
                  "</PaxDetail>";
            }
            xmlSearchRQ += "</PaxDetails>" +
          "</BookingRQ>";

            return xmlSearchRQ;
        }
        private string segmentXML(SearchDetails objSearch)
        {
            string segments = string.Empty;
            //foreach (Segments seg in objSearch.FlightSearchDetails.segments)
            //{
            //    segments += "<Segment id='" + seg.SegId + "'>" +
            //              "<Origin>" + seg.origin + "</Origin>" +
            //              "<Destination>" + seg.destination + "</Destination>" +
            //              "<Date>" + seg.date + "</Date>" +
            //          "</Segment>";
            //}
            return segments;
        }

        private Itineraries ParseLowFareResult(string result, string Guid)
        {
            result = result.Replace(" xmlns=\"http://tempuri.org/\"", "");
            Itineraries Itineraries = new Itineraries();
            TextReader tr = new StringReader(result);
            XDocument doc = XDocument.Load(tr);
            List<Itinerary> oItineraries = new List<Itinerary>();
            int ctr = 0;
            foreach (XElement xItinerary in doc.Element("GetLowFaresResponse").Element("Itineraries").Elements("Itinerary"))
            {
                Itinerary oItin = new Itinerary();
                foreach (XElement node in xItinerary.Elements())
                {
                    switch (node.Name.LocalName)
                    {
                        case "Key":
                            oItin.Key = node.Value;
                            break;
                        //case "ApproximateBasePrice":
                        //    oItin.ApproximateBasePrice = Convert.ToDouble(node.Value);
                        //    break;
                        //case "ApproximateTotalPrice":
                        //    oItin.ApproximateTotalPrice = Convert.ToDouble(node.Value);
                        //    break;
                        //case "ApproximateCurrency":
                        //    oItin.ApproximateCurrency = node.Value;
                        //    break;
                        //case "CurrencyExchange":
                        //    oItin.CurrencyExchange.BaseCurrency = node.Attribute("BaseCurrency").Value;
                        //    oItin.CurrencyExchange.RequestedCurrency = node.Attribute("RequestedCurrency").Value;
                        //    oItin.CurrencyExchange.ExchangeRate = Convert.ToDecimal(node.Attribute("ExchangeRate").Value);
                        //    oItin.Currency = oItin.CurrencyExchange.RequestedCurrency;
                        //    break;
                        case "Currency":
                            oItin.Currency = node.Value;
                            break;
                        case "FareType":
                            oItin.FareType = node.Value;
                            break;
                        case "IndexNumber":
                            oItin.IndexNumber = ctr++; //Convert.ToInt32(node.Value);
                            break;
                        case "Provider":
                            oItin.Provider = node.Value;
                            break;
                        case "ValCarrier":
                            oItin.ValCarrier = node.Value;
                            break;
                        case "LastTicketingDate":
                            oItin.LastTicketingDate = node.Value;
                            break;
                        case "PCC":
                            oItin.PCC = node.Value;
                            break;
                        case "OfferType":
                            oItin.OfferType = node.Value;
                            break;
                        case "Passengers":
                            SetPassengers(ref oItin, node);
                            break;
                        case "AdultInfo":
                            AdultInfo(ref oItin, node);
                            break;
                        case "ChildInfo":
                            ChildrenInfo(ref oItin, node);
                            break;
                        case "InfantInfo":
                            InfantInfo(ref oItin, node);
                            break;
                        case "InfantInfoWithSeat":
                            InfantInfoWithSeat(ref oItin, node);
                            break;
                        case "FareBasisCodes":
                            oItin.LastTicketingDate = node.Value;
                            break;
                        case "Sectors":
                        case "_Sectors":
                            Sectors(ref oItin, node);
                            break;
                    }
                }
                oItineraries.Add(oItin);
            }
            Itineraries.Items = oItineraries;
            return (Itineraries);

        }

        private Itineraries ParsePNRRetrievalResult(string result)
        {
            result = result.Replace(" xmlns=\"http://tempuri.org/\"", "");
            Itineraries Itineraries = new Itineraries();
            TextReader tr = new StringReader(result);
            XDocument doc = XDocument.Load(tr);
            List<Itinerary> oItineraries = new List<Itinerary>();
            int ctr = 0;
            foreach (XElement xItinerary in doc.Element("RetrieveRecordLocatorResponse").Elements("RetrieveRecordLocatorResult"))
            {
                Itinerary oItin = new Itinerary();
                foreach (XElement node in xItinerary.Elements())
                {
                    switch (node.Name.LocalName)
                    {
                        case "Key":
                            oItin.Key = node.Value;
                            break;
                        //case "ApproximateBasePrice":
                        //    oItin.ApproximateBasePrice = Convert.ToDouble(node.Value);
                        //    break;
                        //case "ApproximateTotalPrice":
                        //    oItin.ApproximateTotalPrice = Convert.ToDouble(node.Value);
                        //    break;
                        //case "ApproximateCurrency":
                        //    oItin.ApproximateCurrency = node.Value;
                        //    break;
                        //case "CurrencyExchange":
                        //    oItin.CurrencyExchange.BaseCurrency = node.Attribute("BaseCurrency").Value;
                        //    oItin.CurrencyExchange.RequestedCurrency = node.Attribute("RequestedCurrency").Value;
                        //    oItin.CurrencyExchange.ExchangeRate = Convert.ToDecimal(node.Attribute("ExchangeRate").Value);
                        //    oItin.Currency = oItin.CurrencyExchange.RequestedCurrency;
                        //    break;
                        case "Currency":
                            oItin.Currency = node.Value;
                            break;
                        case "FareType":
                            oItin.FareType = node.Value;
                            break;
                        case "IndexNumber":
                            oItin.IndexNumber = ctr++; //Convert.ToInt32(node.Value);
                            break;
                        case "Provider":
                            oItin.Provider = node.Value;
                            break;
                        case "ValCarrier":
                            oItin.ValCarrier = node.Value;
                            break;
                        case "LastTicketingDate":
                            oItin.LastTicketingDate = node.Value;
                            break;
                        case "Passengers":
                            SetPassengers(ref oItin, node);
                            break;
                        case "AdultInfo":
                            AdultInfo(ref oItin, node);
                            break;
                        case "ChildInfo":
                            ChildrenInfo(ref oItin, node);
                            break;
                        case "InfantInfo":
                            InfantInfo(ref oItin, node);
                            break;
                        case "FareBasisCodes":
                            oItin.LastTicketingDate = node.Value;
                            break;
                        case "Sectors":
                        case "_Sectors":
                            Sectors(ref oItin, node);
                            break;
                        //Warnings
                        case "PassengersDetails":
                            PassengersDetails(ref oItin, node);
                            break;
                        case "Warnings":
                            oItin.Warnings = node.Value;
                            break;
                    }
                }
                oItineraries.Add(oItin);
            }
            Itineraries.Items = oItineraries;
            return (Itineraries);

        }

        private bool ParseFareMatch(string result, SearchDetails searchDetails)
        {
            result = result.Replace(" xmlns=\"http://tempuri.org/\"", "");
            if (string.IsNullOrEmpty(result))
                return false;

            TextReader tr = new StringReader(result);
            XDocument doc = XDocument.Load(tr);
            //List<Itinerary> oItineraries = new List<Itinerary>();
            if (result.ToLower().IndexOf("error") == -1 && result.ToLower().IndexOf("fault") == -1 && result.ToLower().IndexOf("warnings") == -1)
            {
                Itinerary oItin = new Itinerary();
                //EL.Flight.Itinerary oItin = searchDetails.Itinerary;
                int ctr = 0;
                XElement xItinerary = doc.Element("FlightFareMatchRS").Element("Itinerary");


                foreach (XElement node in xItinerary.Elements())
                {
                    switch (node.Name.LocalName)
                    {
                        case "Key":
                            oItin.Key = node.Value;
                            break;
                        //case "ApproximateBasePrice":
                        //    oItin.ApproximateBasePrice = Convert.ToDouble(node.Value);
                        //    break;
                        //case "ApproximateTotalPrice":
                        //    oItin.ApproximateTotalPrice = Convert.ToDouble(node.Value);
                        //    break;
                        //case "ApproximateCurrency":
                        //    oItin.ApproximateCurrency = node.Value;
                        //    break;
                        case "Currency":
                            oItin.Currency = node.Value;
                            break;
                        case "FareType":
                            oItin.FareType = node.Value;
                            break;
                        case "IndexNumber":
                            oItin.IndexNumber = ctr++; //Convert.ToInt32(node.Value);
                            break;
                        case "Provider":
                            oItin.Provider = node.Value;
                            break;
                        case "ValCarrier":
                            oItin.ValCarrier = node.Value;
                            break;
                        case "LastTicketingDate":
                            oItin.LastTicketingDate = node.Value;
                            break;
                        case "Passengers":
                            SetPassengers(ref oItin, node);
                            break;
                        case "AdultInfo":
                            AdultInfo(ref oItin, node);
                            break;
                        case "ChildInfo":
                            ChildrenInfo(ref oItin, node);
                            break;
                        case "InfantInfo":
                            InfantInfo(ref oItin, node);
                            break;
                        case "FareBasisCodes":
                            oItin.LastTicketingDate = node.Value;
                            break;
                        case "Sectors":
                        case "_Sectors":
                            Sectors(ref oItin, node);
                            break;
                    }
                }
                //if (oItin.Provider == "1F" && oItin.Provider != "2F" && oItin.Provider != "1Q" && oItin.Provider != "1T" && oItin.Provider != "1DH")
                if (oItin.Provider == "1P" || oItin.Provider == "1G" || oItin.Provider == "1A" || oItin.Provider == "1ACH" || oItin.Provider == "1RCH")
                {
                    searchDetails.PricingInfo = doc.Element("FlightFareMatchRS").Element("PricingInfos").ToString();
                }
                if (searchDetails.Itinerary.TotalPrice == oItin.TotalPrice)
                {
                    oItin.MarkUp = searchDetails.Itinerary.MarkUp;
                    oItin.Safi = searchDetails.Itinerary.Safi;
                    oItin.Commission = searchDetails.Itinerary.Commission;
                    oItin.GrandTotal = searchDetails.Itinerary.GrandTotal;
                }
                //searchDetails.Itinerary = oItin;
                return true;
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);
                foreach (XmlElement xelm in xmlDoc.DocumentElement.SelectNodes("//Warnings/Warnings/Error"))
                {
                    searchDetails.PriceChangeErrorMsg += (xelm.InnerText + "  ");
                }
                return false;
            }
            //return oItin;


        }

        private void ChackAndSetPnr(string result, SearchDetails searchDetails)
        {
            try
            {
                #region log write

                string Pth = HttpContext.Current.Server.MapPath(@"~\App_Data\BookingRS\" + searchDetails.EmailID + ".txt");
                File.WriteAllText(Pth, result);
                #endregion


                //if (result.ToLower().IndexOf("error") == -1 && result.ToLower().IndexOf("fault") == -1)
                //{
                result = RemoveAllNamespaces(result);
                result = result.Replace(" xmlns=\"http://tempuri.org/\"", "");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);
                if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning") != null)
                {
                    foreach (XmlNode xnds in xmlDoc.SelectNodes("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning"))
                    {
                        searchDetails.DeclineMsg += (xnds.InnerText + "  ");
                    }
                }
                if (xmlDoc.DocumentElement.SelectSingleNode("//Error") != null)
                {
                    searchDetails.DeclineMsg += (xmlDoc.DocumentElement.SelectSingleNode("//Error").InnerText + "  ");
                }
                if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/RecLocDetails/RecLocDetails/RecLoc") != null)
                {
                    if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/RecLocDetails/RecLocDetails/RecLoc[Provider='UAPI']/PNRNo") != null)
                    {
                        searchDetails.PNRUAPI = xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/RecLocDetails/RecLocDetails/RecLoc[Provider='UAPI']/PNRNo").InnerText;
                    }
                    if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/RecLocDetails/RecLocDetails/RecLoc[Provider='" + searchDetails.Provider + "']/PNRNo") != null)
                    {
                        searchDetails.PNR = xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/RecLocDetails/RecLocDetails/RecLoc[Provider='" + searchDetails.Provider + "']/PNRNo").InnerText;
                    }
                }
                if (string.IsNullOrEmpty(searchDetails.PNR) && string.IsNullOrEmpty(searchDetails.PNRUAPI))
                {
                    searchDetails.BookingStatus = "Decline";
                }
                else
                {
                    searchDetails.BookingStatus = "Confirm";
                }

                //}
                //else
                //{
                //    result = RemoveAllNamespaces(result);
                //    result = result.Replace(" xmlns=\"http://tempuri.org/\"", "");
                //    XmlDocument xmlDoc = new XmlDocument();
                //    xmlDoc.LoadXml(result);
                //    if (xmlDoc.DocumentElement.SelectSingleNode("//Error").InnerText != null)
                //    {
                //        searchDetails.DeclineMsg += (xmlDoc.DocumentElement.SelectSingleNode("//Error").InnerText + "  ");
                //    }
                //    else if (xmlDoc.DocumentElement.SelectSingleNode("//Warning").InnerText != null)
                //    {
                //        searchDetails.DeclineMsg += (xmlDoc.DocumentElement.SelectSingleNode("//Warning").InnerText + "  ");
                //    }

                //    searchDetails.PNR = "";
                //    searchDetails.PNRUAPI = "";
                //    searchDetails.BookingStatus = "Decline";
                //}
            }
            catch
            {

                searchDetails.PNR = "";
                searchDetails.PNRUAPI = "";
                searchDetails.BookingStatus = "Decline";
            }

        }

        private void ChackAndSetPnr1(string result, SearchDetails searchDetails)
        {
            try
            {
                #region log write

                string Pth = HttpContext.Current.Server.MapPath(@"~\App_Data\BookingRS\" + searchDetails.EmailID + ".txt");
                File.WriteAllText(Pth, result);
                #endregion

                if (result.ToLower().IndexOf("error") == -1 && result.ToLower().IndexOf("fault") == -1)
                {
                    result = RemoveAllNamespaces(result);
                    result = result.Replace(" xmlns=\"http://tempuri.org/\"", "");
                    TextReader tr = new StringReader(result);
                    XDocument doc = XDocument.Load(tr);
                    if (doc.Element("BookFlightResult").Element("RecLocDetails").Element("RecLocDetails").Elements("RecLoc") != null)
                    {
                        foreach (XElement node in doc.Element("BookFlightResult").Element("RecLocDetails").Element("RecLocDetails").Elements("RecLoc"))
                        {
                            if (node.Element("Provider").Value == "UAPI")
                            {
                                searchDetails.PNRUAPI = node.Element("PNRNo").Value;
                            }
                            else if (node.Element("Provider").Value == "1G")
                            {
                                searchDetails.PNR = node.Element("PNRNo").Value;
                            }
                            else
                            {
                                searchDetails.PNR = node.Element("PNRNo").Value;
                            }
                        }
                        if (string.IsNullOrEmpty(searchDetails.PNR) && string.IsNullOrEmpty(searchDetails.PNRUAPI))
                        {
                            searchDetails.PNRUAPI = "Decline";
                        }
                        else
                        {
                            searchDetails.PNRUAPI = "Confirm";
                        }
                    }
                    else
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(result);
                        searchDetails.DeclineMsg = "";
                        foreach (XmlElement xelm in xmlDoc.DocumentElement.SelectSingleNode("//Warning"))
                        {
                            searchDetails.DeclineMsg += (xelm.Value + "  ");
                        }
                        //if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning") != null)
                        //{
                        //    searchDetails.DeclineMsg += xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning").InnerText;
                        //}
                        //if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning[2]") != null)
                        //{
                        //    searchDetails.DeclineMsg += ("  And    " + xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning[2]").InnerText);
                        //}
                        searchDetails.PNR = "";
                        searchDetails.PNRUAPI = "";
                        searchDetails.PNRUAPI = "Decline";
                    }
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(result);
                    searchDetails.DeclineMsg = "";
                    foreach (XmlElement xelm in xmlDoc.DocumentElement.SelectSingleNode("//Warning"))
                    {
                        searchDetails.DeclineMsg += (xelm.Value + "  ");
                    }
                    //if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning") != null)
                    //{
                    //    searchDetails.DeclineMsg += xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning").InnerText;
                    //}
                    //if (xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning[2]") != null)
                    //{
                    //    searchDetails.DeclineMsg +=("  And    " +xmlDoc.SelectSingleNode("BookFlightResponse/BookFlightResult/Warnings/Warnings/Warning[2]").InnerText);
                    //}
                    searchDetails.PNR = "";
                    searchDetails.PNRUAPI = "";
                    searchDetails.PNRUAPI = "Decline";
                }
            }
            catch
            {

                searchDetails.PNR = "";
                searchDetails.PNRUAPI = "";
                searchDetails.PNRUAPI = "Decline";
            }

        }

        private void SetPassengers(ref Itinerary oItin, XElement Passengers)
        {

            foreach (XElement node in Passengers.Elements("Passenger"))
            {
                switch (node.Element("PassengerType").Value)
                {
                    case "ADT":
                        AdultInfo(ref oItin, node);
                        break;
                    case "CNN":
                    case "CHD":
                        ChildrenInfo(ref oItin, node);
                        break;
                    case "INF":
                        InfantInfo(ref oItin, node);
                        break;
                    case "INS":
                        InfantWithSeatInfo(ref oItin, node);
                        break;
                }
            }
        }

        private void AdultInfo(ref Itinerary oItin, XElement AdultInfo)
        {
            foreach (XElement node in AdultInfo.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "NoOfPassenger":
                        oItin.AdultInfo.NoAdult = Convert.ToInt32(node.Value);
                        break;
                    case "BaseFare":
                        oItin.AdultInfo.AdtBFare = Convert.ToDouble(node.Value);
                        break;
                    case "Taxes":
                        oItin.AdultInfo.AdTax = Convert.ToDouble(node.Value);
                        break;
                    case "MarkUp":
                        oItin.AdultInfo.MarkUp = Convert.ToDouble(node.Value);
                        break;
                    case "Commission":
                        oItin.AdultInfo.Commission = Convert.ToDouble(node.Value);
                        break;
                    case "Safi":
                        oItin.AdultInfo.Safi = Convert.ToDouble(node.Value);
                        break;
                }
            }
        }

        private void ChildrenInfo(ref Itinerary oItin, XElement ChildrenInfo)
        {
            foreach (XElement node in ChildrenInfo.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "NoOfPassenger":
                        oItin.ChildInfo.NoChild = Convert.ToInt32(node.Value);
                        break;
                    case "BaseFare":
                        oItin.ChildInfo.ChdBFare = Convert.ToDouble(node.Value);
                        break;
                    case "Taxes":
                        oItin.ChildInfo.CHTax = Convert.ToDouble(node.Value);
                        break;
                    case "MarkUp":
                        oItin.ChildInfo.MarkUp = Convert.ToDouble(node.Value);
                        break;
                    case "Commission":
                        oItin.ChildInfo.Commission = Convert.ToDouble(node.Value);
                        break;
                    case "Safi":
                        oItin.ChildInfo.Safi = Convert.ToDouble(node.Value);
                        break;
                }
            }
        }

        private void InfantInfo(ref Itinerary oItin, XElement InfantInfo)
        {
            foreach (XElement node in InfantInfo.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "NoOfPassenger":
                        oItin.InfantInfo.NoInfant = Convert.ToInt32(node.Value);
                        break;
                    case "BaseFare":
                        oItin.InfantInfo.InfBFare = Convert.ToDouble(node.Value);
                        break;
                    case "Taxes":
                        oItin.InfantInfo.InTax = Convert.ToDouble(node.Value);
                        break;
                    case "MarkUp":
                        oItin.InfantInfo.MarkUp = Convert.ToDouble(node.Value);
                        break;
                    case "Commission":
                        oItin.InfantInfo.Commission = Convert.ToDouble(node.Value);
                        break;
                    case "Safi":
                        oItin.InfantInfo.Safi = Convert.ToDouble(node.Value);
                        break;
                }
            }
        }
        private void InfantInfoWithSeat(ref Itinerary oItin, XElement InfantInfo)
        {
            foreach (XElement node in InfantInfo.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "NoOfPassenger":
                        oItin.InfantInfo.NoInfant = Convert.ToInt32(node.Value);
                        break;
                    case "BaseFare":
                        oItin.InfantInfo.InfBFare = Convert.ToDouble(node.Value);
                        break;
                    case "Taxes":
                        oItin.InfantInfo.InTax = Convert.ToDouble(node.Value);
                        break;
                    case "MarkUp":
                        oItin.InfantInfo.MarkUp = Convert.ToDouble(node.Value);
                        break;
                    case "Commission":
                        oItin.InfantInfo.Commission = Convert.ToDouble(node.Value);
                        break;
                    case "Safi":
                        oItin.InfantInfo.Safi = Convert.ToDouble(node.Value);
                        break;
                }
            }
        }
        private void InfantWithSeatInfo(ref Itinerary oItin, XElement InfantInfo)
        {
            foreach (XElement node in InfantInfo.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "NoOfPassenger":
                        oItin.InfantInfoWithSeat.NoInfant = Convert.ToInt32(node.Value);
                        break;
                    case "BaseFare":
                        oItin.InfantInfoWithSeat.InfBFare = Convert.ToDouble(node.Value);
                        break;
                    case "Taxes":
                        oItin.InfantInfoWithSeat.InTax = Convert.ToDouble(node.Value);
                        break;
                    case "MarkUp":
                        oItin.InfantInfoWithSeat.MarkUp = Convert.ToDouble(node.Value);
                        break;
                    case "Commission":
                        oItin.InfantInfoWithSeat.Commission = Convert.ToDouble(node.Value);
                        break;
                    case "Safi":
                        oItin.InfantInfoWithSeat.Safi = Convert.ToDouble(node.Value);
                        break;
                }
            }
        }

        private void FareBasisCodes(ref Itinerary oItin, XElement FareBasisCodes)
        {
            //foreach (XElement node in FareBasisCodes.Elements())
            //{
            //    switch (node.Name.LocalName)
            //    {

            //    }
            //}
        }

        private void Sectors(ref Itinerary oItin, XElement Sectors)
        {

            foreach (XElement nodeSector in Sectors.Elements("Sector"))
            {
                Sector oISector = new Sector();
                foreach (XElement node in nodeSector.Elements())
                {
                    switch (node.Name.LocalName)
                    {
                        case "AirV":
                            oISector.AirV = node.Value;
                            break;
                        case "AirlineLogoPath":
                            oISector.AirlineLogoPath = node.Value;
                            break;
                        case "Class":
                            oISector.Class = node.Value;
                            break;
                        case "CabinClass":
                            CabinCalss(ref oISector, node);
                            break;
                        case "NoSeats":
                            oISector.NoSeats = Convert.ToInt16(node.Value);
                            break;
                        case "FltNum":
                            oISector.FltNum = node.Value;
                            break;
                        case "Departure":
                            Departure(ref oISector, node);
                            break;
                        case "Arrival":
                            Arrival(ref oISector, node);
                            break;
                        case "EquipType":
                            oISector.EquipType = node.Value;
                            break;
                        case "ElapsedTime":
                            oISector.ElapsedTime = node.Value;
                            break;
                        case "ActualTime":
                            oISector.ActualTime = node.Value;
                            break;
                        case "TechStopOver":
                            oISector.TechStopOver = Convert.ToInt16(node.Value);
                            break;
                        case "Status":
                            oISector.Status = node.Value;
                            break;
                        case "IsReturn":
                            oISector.IsReturn = Convert.ToBoolean(node.Value);
                            break;
                        case "OptrCarrier":
                            oISector.OptrCarrier = node.Value;
                            break;
                        case "OptrCarrierDes":
                            oISector.OptrCarrierDes = node.Value;
                            break;
                        case "MrktCarrier":
                            oISector.MrktCarrier = node.Value;
                            break;
                        case "MrktCarrierDes":
                            oISector.MrktCarrierDes = node.Value;
                            break;
                        case "BaggageInfo":
                            oISector.BaggageInfo = node.Value;
                            break;
                        case "Baggage_Info":

                            foreach (XElement n in node.Elements())
                            {
                                switch (n.Name.LocalName)
                                {
                                    case "Kgs":
                                        oISector.Baggage_Info.Kgs = n.Value;
                                        break;
                                    case "Pieces":
                                        oISector.Baggage_Info.Pieces = n.Value;
                                        break;
                                    case "Price":
                                        oISector.Baggage_Info.Price = Convert.ToDouble(n.Value);
                                        break;
                                    case "Description":
                                        oISector.Baggage_Info.Description = n.Value;
                                        break;
                                }

                            }

                            break;
                        case "TransitTime":
                            oISector.TransitTime = node.Value;
                            break;
                        case "Key":
                            oISector.Key = node.Value;
                            break;
                        case "Distance":
                            oISector.Distance = node.Value;
                            break;
                        case "ETicket":
                            oISector.ETicket = node.Value;
                            break;
                        case "ChangeOfPlane":
                            oISector.ChangeOfPlane = node.Value;
                            break;
                        case "ParticipantLevel":
                            oISector.ParticipantLevel = node.Value;
                            break;
                        case "OptionalServicesIndicator":
                            oISector.OptionalServicesIndicator = Convert.ToBoolean(node.Value);
                            break;
                        case "AvailabilitySource":
                            oISector.AvailabilitySource = node.Value;
                            break;
                        case "Group":
                            oISector.Group = node.Value;
                            break;
                        case "LinkAvailability":
                            oISector.LinkAvailability = node.Value;
                            break;
                        case "PolledAvailabilityOption":
                            oISector.PolledAvailabilityOption = node.Value;
                            break;
                        case "BookingCodeInfo":
                            oISector.BookingCodeInfo = node.Value;
                            break;
                    }
                }
                oItin.Sectors.Add(oISector);
            }
        }

        private void CabinCalss(ref Sector oItin, XElement CClass)
        {
            foreach (XElement node in CClass.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "Name":
                        oItin.CabinClass.Name = node.Value;
                        break;
                }
            }
        }

        private void Departure(ref Sector oItin, XElement Dept)
        {
            foreach (XElement node in Dept.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "AirportCode":
                        oItin.Departure.AirportCode = node.Value;
                        break;
                    case "AirportName":
                        oItin.Departure.AirportName = node.Value;
                        break;
                    case "AirportCityCode":
                        oItin.Departure.AirportCityCode = node.Value;
                        break;

                    case "AirportCityName":
                        oItin.Departure.AirportCityName = node.Value;
                        break;

                    case "AirportCountryCode":
                        oItin.Departure.AirportCountryCode = node.Value;
                        break;
                    case "AirportCountryName":
                        oItin.Departure.AirportCountryName = node.Value;
                        break;

                    case "GeoLocation":
                        oItin.Departure.GeoLocation = node.Value;
                        break;
                    case "Terminal":
                        oItin.Departure.Terminal = node.Value;
                        break;
                    case "Date":
                        oItin.Departure.Date = node.Value;
                        //oItin.Departure.Day = Convert.ToDateTime(node.Value).ToString("ddd");
                        break;
                    case "Time":
                        oItin.Departure.Time = node.Value;
                        break;
                    case "DateTimeStamp":
                        oItin.Departure.DateTimeStamp = node.Value;
                        break;
                }
            }
        }

        private void Arrival(ref Sector oItin, XElement Ariv)
        {
            foreach (XElement node in Ariv.Elements())
            {
                switch (node.Name.LocalName)
                {
                    case "AirportCode":
                        oItin.Arrival.AirportCode = node.Value;
                        break;
                    case "AirportName":
                        oItin.Arrival.AirportName = node.Value;
                        break;
                    case "AirportCityCode":
                        oItin.Arrival.AirportCityCode = node.Value;
                        break;

                    case "AirportCityName":
                        oItin.Arrival.AirportCityName = node.Value;
                        break;

                    case "AirportCountryCode":
                        oItin.Arrival.AirportCountryCode = node.Value;
                        break;
                    case "AirportCountryName":
                        oItin.Arrival.AirportCountryName = node.Value;
                        break;
                    case "GeoLocation":
                        oItin.Arrival.GeoLocation = node.Value;
                        break;
                    case "Terminal":
                        oItin.Arrival.Terminal = node.Value;
                        break;
                    case "Date":
                        oItin.Arrival.Date = node.Value;
                        break;
                    case "Time":
                        oItin.Arrival.Time = node.Value;
                        break;
                    case "DateTimeStamp":
                        oItin.Arrival.DateTimeStamp = node.Value;
                        break;
                }
            }
        }

        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
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
                                                    "<img src='" + WebsiteStaticData.WebsiteUrl + "images/Logo.png' style='width:300px; height:46px;' alt='logo' />" +
                                               " </td>" +
                                            " </tr>" +
                                            "<tr>" +
                                                "<td valign='top' style='font-size: 11px; font-family: Arial, Helvetica, sans-serif;'>" +
                                                    "Suite B2:11 Vista Centre Salisbury Road, Hounslow" +
                                                    "TW4 6JQ, United Kingdom<br />" +

                                                    "<small class='pink-text'>Registration:</small>" +
                                                   " Company Regd no. 09162028 (Regd in England)<br />" +


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
            if (SearchDetails.BookingStatus.ToLower() == "decline")
            {
                sb.Append("<tr>" +
                            "<td><p>Thank you for choosing us the opportunity in assisting you with your forthcoming trip.</p>" +
                            "<p>Your reservation is booked, and tickets confirmed. Tickets will be sent to the email address you supplied within 24 hours.</p>" +
                             "<p>If you have not received your tickets after this time, or you require any further assistance, please contact us on " + WebsiteStaticData.ContactNo1 + " or email support@faressaver.com</p>" +
                            "</td>" +

                        " </tr>" +
                        "<tr>" +
                            "<td>&nbsp;</td>" +
                        " </tr>");
            }
            else if (SearchDetails.BookingStatus.ToLower() == "option")
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
                                        "<img src='" + WebsiteStaticData.WebsiteUrl + "images/airplane-ico.png' style='width:32px; height:32px;' />" +
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
                                                                "<img src='" + WebsiteStaticData.WebsiteUrl + "images/barcode.png' style='width:100px; height:45px;' />" +
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
                                                            "<td align='left' valign='middle'>" + SearchDetails.Passenger[0].Title + " " + SearchDetails.Passenger[0].FirstName + " " + SearchDetails.Passenger[0].LastName + "</td>" +
                                                        " </tr>" +
                                                        "<tr>" +
                                                            "<td align='left' valign='middle'>Phone No</td>" +
                                                            "<td width='10' align='left' valign='middle'>:</td>" +
                                                           "<td align='left' valign='middle'>" + SearchDetails.MobileNo + "</td>" +
                                                        " </tr>");
            if (!string.IsNullOrEmpty(SearchDetails.PhoneNo))
            {
                sb.Append("<tr>" +
                     "<td align='left' valign='middle'>Alternate No</td>" +
                     "<td width='10' align='left' valign='middle'>:</td>" +
                     "<td align='left' valign='middle'>" + SearchDetails.PhoneNo + "</td>" +
                 " </tr>");
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
                              "<img src='" + WebsiteStaticData.WebsiteUrl + "images/pax.png' width='24' height='24' />" +
                                " </td>" +
                                 "<td width='5' height='30' align='left' valign='middle'>&nbsp;</td>" +
                                 "<td height='30' align='left' valign='middle'>" + SearchDetails.Passenger[i].Title + " " + SearchDetails.Passenger[i].FirstName + " " + SearchDetails.Passenger[i].LastName + "</td>" +
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
       "<img src='" + WebsiteStaticData.WebsiteUrl + "images/airplane-ico.png' style='width:32px; height:32px;' />" +
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
                          "<img src='" + WebsiteStaticData.WebsiteUrl + "images/barcode.png' style='width:100px height:45px' />" +
                     " </td>" +
                      "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
                          "<p>" + Its.AirlineName + "</p>" +
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
                                                    "<img src='" + WebsiteStaticData.WebsiteUrl + "images/pax.png' width='24' height='24' />" +
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
            //    if (p.PassengerType == "ADT")
            //    {
            //        sb.Append("<tr>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Adult</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             SearchDetails.Itinerary.CurrencySymble + (p.BaseFare + p.Taxes + p.MarkUp + p.Commission + p.Safi) +
            //        "</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             "<strong>" + p.NoOfPassenger + " </strong>" +
            //             "</p>" +
            //        "</td>" +
            //         "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.CurrencySymble + (p.NoOfPassenger * +(p.BaseFare + p.Taxes + p.MarkUp + p.Commission + p.Safi)) + " </strong></td>" +
            //     "</tr>");
            //    }
            //    else if (p.PassengerType == "CHD" || p.PassengerType == "CNN")
            //    {
            //        sb.Append("<tr>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Child</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             SearchDetails.Itinerary.CurrencySymble + (p.BaseFare + p.Taxes + p.MarkUp + p.Commission + p.Safi) +
            //        "</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             "<strong>" + p.NoOfPassenger + " </strong>" +
            //             "</p>" +
            //        "</td>" +
            //         "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.CurrencySymble + (p.NoOfPassenger * +(p.BaseFare + p.Taxes + p.MarkUp + p.Commission + p.Safi)) + " </strong></td>" +
            //     "</tr>");
            //    }
            //    else if (p.PassengerType == "INF")
            //    {
            //        sb.Append("<tr>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Infant</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             SearchDetails.Itinerary.CurrencySymble + (p.BaseFare + p.Taxes + p.MarkUp + p.Commission + p.Safi) +
            //        "</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             "<strong>" + p.NoOfPassenger + " </strong>" +
            //             "</p>" +
            //        "</td>" +
            //         "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.CurrencySymble + (p.NoOfPassenger * +(p.BaseFare + p.Taxes + p.MarkUp + p.Commission + p.Safi)) + " </strong></td>" +
            //     "</tr>");
            //    }

            //}

            //if (SearchDetails.Itinerary.InfantInfoWithSeat.NoInfant > 0)
            //{
            //    sb.Append("<tr>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>Infant With Seat</td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //              SearchDetails.Itinerary.CurrencySymble + (SearchDetails.Itinerary.InfantInfoWithSeat.InfBFare + SearchDetails.Itinerary.InfantInfoWithSeat.InTax + SearchDetails.Itinerary.InfantInfoWithSeat.MarkUp + SearchDetails.Itinerary.InfantInfoWithSeat.Commission + SearchDetails.Itinerary.InfantInfoWithSeat.Safi) +
            //        " </td>" +
            //         "<td align='left' valign='top' style='border-right: #FFF solid 1px; border-bottom: #FFF solid 1px;'>" +
            //             "<strong>" + SearchDetails.Itinerary.InfantInfoWithSeat.NoInfant + " </strong>" +
            //             "</p>" +
            //        " </td>" +
            //         "<td align='left' valign='top' style='border-bottom: #FFF solid 1px;'><strong>" + SearchDetails.Itinerary.CurrencySymble + (SearchDetails.Itinerary.InfantInfoWithSeat.NoInfant * +(SearchDetails.Itinerary.InfantInfoWithSeat.InfBFare + SearchDetails.Itinerary.InfantInfoWithSeat.InTax + SearchDetails.Itinerary.InfantInfoWithSeat.MarkUp + SearchDetails.Itinerary.InfantInfoWithSeat.Commission + SearchDetails.Itinerary.InfantInfoWithSeat.Safi)) + " </strong></td>" +
            //     " </tr>");
            //}

            sb.Append("</tbody>" +
                            "</table>" +
                       " </td>" +
                    " </tr>" +
                    "<tr>" +
                        "<td>&nbsp;</td>" +
                    " </tr>");
            if (SearchDetails.BookingStatus.ToLower() != "incomplete")
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
                             // SearchDetails.Itinerary.CurrencySymble + SearchDetails.Itinerary.GrandTotal + "<span></span>" +
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
                     // SearchDetails.Itinerary.CurrencySymble + SearchDetails.PaymentCallbackDetails.Surcharge + "<span></span>" +
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
                             // SearchDetails.Itinerary.CurrencySymble + SearchDetails.TransctionAmount.ToString("f2") + "<span></span>" +
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
                "<li>Please note that you must have a valid Passport having a minimum of 6 months before expiry after travel has been completed, or you will not be permitted to travel. Your passport must be clearly legible and in excellent condition. Presenting a damaged passport at check-in may mean you are unable to travel. For travel to the USA it is mandatory to possess a machine-readable passport or valid visa for travel; otherwise you will be denied boarding. Details of the airline flight numbers/schedules and destination airport will be shown on your invoice/confirmation.Please note that a flight described as “direct” will not necessarily be non-stop. Flight schedules may change at any time and provided there is enough time to do so, we will advise you of any changes prior to departure. However, we strongly recommend you reconfirm your reservations on all flights during your journey, at least 72 hours prior to departure of each flight.We cannot accept any responsibility for delays or missed flights. If you wish to change any item on you flight itinerary, other than increasing the number of persons in your party, providing we can accommodate the change, you must confirm the change in writing and pay an amendment fee of £75 per item changed, plus the airline/supplier charges applicable to their ticket terms & conditions.Occasionally we are required to collect additional taxes.You will be informed of any additional taxes prior to ticket issuance.Once tickets have been issued, most airlines do not allow any changes. In all cases, a complete name change is not possible, which means tickets cannot be transferred to someone else. However, in most situations a name correction can be made, depending upon the supplier/airline’s conditions. For full terms and conditions, please use this link: <a href='https://www.Faressaver.com/terms-conditions.aspx' target='_blank'> https://www.Faressaver.com/terms-conditions.aspx</a> </li>" +
                "</ul></td>" +
            " </tr>" +
            "<tr>" +
                "<td style='padding: 10px 0px;'>" +
                    "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                        "<tr>" +
                            "<td width='250' align='left' valign='middle'>" +
                                "<a href='/'><img src='" + WebsiteStaticData.WebsiteUrl + "images/booking-home.png' style='width:90px; height:34px;' border='0' /></a>" +
                           " </td>" +
                            "<td align='center'>" +
                                "<a href='#'><img class='printMe' src='" + WebsiteStaticData.WebsiteUrl + "images/booking-print.png' style='width:90px; height:34px;' border='0' /></a>" +
                           " </td>" +
                            "<td align='right'>" +
                                "<a href='/'><img src='" + WebsiteStaticData.WebsiteUrl + "images/another-booking.png' style='width:213px; height:34px;' border='0' /></a>" +
                           " </td>" +
                        " </tr>" +
                    "</table>" +
               " </td>" +
            " </tr>" +
        "</table>" +
   " </td>" +
" </tr>" +
"</table>");

            try
            {
                if (!string.IsNullOrEmpty(SearchDetails.KayakClickID) && SearchDetails.KayakClickID.Contains("@"))
                {
                    string[] clickID = SearchDetails.KayakClickID.Split('@');

                    string hap = clickID[1];
                    string cID = clickID[0];
                    if (hap.ToUpper() == "TJ_WEGO" && (cID != null && cID != ""))
                    {
                        if (SearchDetails.BookingStatus.ToLower() == "option")
                        {
                            sb.Append("<img src='https://secure.wego.com/analytics/v2/conversions?conversion_id=c-wego-Faressaver.com&click_id=" + cID + "&comm_currency_code=USD&bv_currency_code=" + SearchDetails.Itinerary.Currency + "&transaction_id=" + SearchDetails.BookingID + "&commission=10&total_booking_value=" + SearchDetails.Itinerary.GrandTotal + "&status=pending' width='1' height='1' border='0' alt=''>");
                        }
                        else
                        {
                            sb.Append("<img src='https://secure.wego.com/analytics/v2/conversions?conversion_id=c-wego-Faressaver.com&click_id=" + cID + "&comm_currency_code=USD&bv_currency_code=" + SearchDetails.Itinerary.Currency + "&transaction_id=" + SearchDetails.BookingID + "&commission=10&total_booking_value=" + SearchDetails.Itinerary.GrandTotal + "&status=confirmed' width='1' height='1' border='0' alt=''>");
                        }
                    }
                    else if (hap.ToUpper() == "TJ_MMD" && (cID != null && cID != ""))
                    { sb.Append("<img src='https://www.kayak.com/s/kayakpixel/confirm/FaressaverUKMMG?kayakclickid=" + cID + "&price=" + SearchDetails.Itinerary.GrandTotal + "&currency=" + SearchDetails.Itinerary.Currency + "&confirmation=" + SearchDetails.BookingID + "&rand=" + Guid + "'/>"); }
                }
            }
            catch (Exception)
            {

                throw;
            }


            return sb.ToString();

        }


        private void PassengersDetails(ref Itinerary oItin, XElement Passengers)
        {


            foreach (XElement pxd in Passengers.Elements("PassengerDetail"))
            {
                PassengerDetail pd = new PassengerDetail();
                foreach (XElement node in pxd.Elements())
                {

                    switch (node.Name.LocalName)
                    {
                        case "PassengerType":
                            pd.PassengerType = node.Value;
                            break;
                        case "Title":
                            pd.Title = node.Value;
                            break;
                        case "FirstName":
                            pd.FirstName = node.Value;
                            break;
                        case "LastName":
                            pd.LastName = node.Value;
                            break;
                        case "DOB":
                            pd.DOB = node.Value;
                            break;
                    }

                }
                //oItin.PassengersDetails.Add(pd);

            }

        }

        public static string GenerateBookingRef()
        {
            //IDCreator.IDCreator objBok = new IDCreator.IDCreator();
            return ""; // objBok.GenerateIDs("XP");
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
                    DateTime NewTime = DateTime.Now.AddMinutes(-1440);
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
        public static bool CheckIPAddress()
        {
            try
            {
                XDocument xDoc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/IPAddress.xml"));
                var IP = (from ip in xDoc.Descendants("ip") where ip.Value == HttpContext.Current.Request.UserHostAddress select ip).FirstOrDefault();
                return IP != null ? true : false;
            }
            catch
            {
                return false;
            }
        }
        public static string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
