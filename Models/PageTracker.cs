using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class PageTracker
    {
        #region constructor
        public PageTracker(HttpContext ctx, string _origin, string _destination, string _date, string _returnDate,
            string _sourceMedia, string _remarks, string _redirectFrom)
        {
            try
            {

                sessionReferrer = (ctx.Request.UrlReferrer == null) ? string.Empty : ctx.Request.UrlReferrer.ToString();
                sessionURL = (ctx.Request.Url == null) ? string.Empty : ctx.Request.Url.ToString();
                originalReferrer = sessionReferrer;
                originalURL = sessionURL;
                userHostAddress = ctx.Request.UserHostAddress.ToString();
                userAgent = ctx.Request.UserAgent.ToString();
                browser = ctx.Request.Browser.Browser;
                crawler = ctx.Request.Browser.Crawler.ToString();
                sessionID = ctx.Session.SessionID;
                remarks = _remarks;
                origin = _origin;
                destination = _destination;
                //date = _date;
                returnDate = _returnDate;
                source = _sourceMedia;
                redirectFrom = _redirectFrom;

                if (ipCity == null || ipCity.Length == 0)
                {
                    ipCity = string.Empty;
                }
                if (ipRegion == null || ipRegion.Length == 0)
                {
                    ipRegion = string.Empty;
                }
                if (ipCountry == null || ipCountry.Length == 0)
                {
                    ipCountry = string.Empty;
                }
            }
            catch { }
        }

        public PageTracker()
        {
        }
        #endregion

        #region Methods

        public bool SavePageTrack()
        {

            //if (userHostAddress != "203.196.136.226" || userHostAddress != "125.63.65.114" || userHostAddress != "222.165.187.74" ||
            //userHostAddress != "83.244.130.69" || userHostAddress != "83.244.130.66" || userHostAddress != "31.221.37.178" ||
            //userHostAddress != "31.221.39.170" || (RequestSource == "Fares Saver Offline"))
            //{
            try
            {

                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[15];

                try
                {
                    using (SqlConnection connection = DataConnection.GetPageTrackerConnection())
                    {
                        _CommandText = "ST_PageTracker_Insert";
                        param[0] = new SqlParameter("@paramIP", SqlDbType.NVarChar, (50));
                        param[0].Value = userHostAddress;

                        param[1] = new SqlParameter("@paramReqSource", SqlDbType.NVarChar, (100));
                        param[1].Value = RequestSource;

                        param[2] = new SqlParameter("@paramPage", SqlDbType.NVarChar, (50));
                        param[2].Value = WebPage;

                        param[3] = new SqlParameter("@paramPageUrl", SqlDbType.NVarChar, (500));
                        param[3].Value = OriginalURL;

                        param[4] = new SqlParameter("@paramSite", SqlDbType.NVarChar, (100));
                        param[4].Value = WebSite;

                        param[5] = new SqlParameter("@paramOrigin", SqlDbType.NVarChar, (50));
                        param[5].Value = Origin;

                        param[6] = new SqlParameter("@paramDestination", SqlDbType.NVarChar, (50));
                        param[6].Value = Destination;

                        try
                        {
                            param[7] = new SqlParameter("@paramdate", SqlDbType.DateTime);
                            param[7].Value = Convert.ToDateTime(date);
                        }
                        catch { param[7].Value = Convert.ToDateTime("01/01/1900"); }

                        if (!string.IsNullOrEmpty(ReturnDate))
                        {
                            try
                            {
                                param[8] = new SqlParameter("@paramReturnDate", SqlDbType.DateTime);
                                param[8].Value = Convert.ToDateTime(ReturnDate);
                            }
                            catch { param[8].Value = Convert.ToDateTime("01/01/1900"); }
                        }
                        param[9] = new SqlParameter("@paramIPCity", SqlDbType.NVarChar, (50));
                        param[9].Value = IPCity;

                        param[10] = new SqlParameter("@paramIPCountry", SqlDbType.NVarChar, (50));
                        param[10].Value = IPCountry;
                        param[11] = new SqlParameter("@paramBrowser", SqlDbType.NVarChar, (200));
                        param[11].Value = Browser;
                        param[12] = new SqlParameter("@paramSession", SqlDbType.NVarChar, (200));
                        param[12].Value = SessionID;
                        param[13] = new SqlParameter("@paramRemarks", SqlDbType.NVarChar, (200));
                        param[13].Value = Remarks;
                        param[14] = new SqlParameter("@paramRedirectFrom", SqlDbType.NVarChar, (100));
                        param[14].Value = RedirectFrom;
                        int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                        if (count > 0)
                            return true;
                        else
                            return false;
                    }
                }
                catch
                {
                    return false;
                }

            }
            catch { return false; }
            //}
            //else
            //{
            //    return true;
            //}
        }



        public bool SavePageTrackOffline()
        {

            if (userHostAddress != "203.196.136.226" || userHostAddress != "125.63.65.114" || userHostAddress != "222.165.187.74" ||
                 userHostAddress != "83.244.130.69" || userHostAddress != "83.244.130.66" || userHostAddress != "31.221.37.178" ||
                 userHostAddress != "31.221.39.170" || (RequestSource == "Club Traveller"))
            {
                try
                {

                    string _CommandText = string.Empty;
                    SqlParameter[] param = new SqlParameter[11];

                    try
                    {
                        _CommandText = "ST_PageTrackerOffline_Insert";
                        param[0] = new SqlParameter("@paramIP", SqlDbType.NVarChar, (50));
                        param[0].Value = userHostAddress;

                        param[1] = new SqlParameter("@paramReqSource", SqlDbType.NVarChar, (100));
                        param[1].Value = RequestSource;

                        param[2] = new SqlParameter("@paramPage", SqlDbType.NVarChar, (50));
                        param[2].Value = WebPage;

                        param[3] = new SqlParameter("@paramPageUrl", SqlDbType.NVarChar, (500));
                        param[3].Value = OriginalURL;

                        param[4] = new SqlParameter("@paramSite", SqlDbType.NVarChar, (100));
                        param[4].Value = WebSite;

                        param[5] = new SqlParameter("@paramIPCity", SqlDbType.NVarChar, (50));
                        param[5].Value = IPCity;
                        param[6] = new SqlParameter("@paramIPCountry", SqlDbType.NVarChar, (50));
                        param[6].Value = IPCountry;
                        param[7] = new SqlParameter("@paramBrowser", SqlDbType.NVarChar, (200));
                        param[7].Value = Browser;
                        param[8] = new SqlParameter("@paramSession", SqlDbType.NVarChar, (200));
                        param[8].Value = SessionID;
                        param[9] = new SqlParameter("@paramRemarks", SqlDbType.NVarChar, (200));
                        param[9].Value = Remarks;
                        param[10] = new SqlParameter("@paramRedirectFrom", SqlDbType.NVarChar, (100));
                        param[10].Value = RedirectFrom;

                        int count = 0;// SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionStringTrack"].ToString(), CommandType.StoredProcedure, _CommandText, param);
                        if (count > 0)
                            return true;
                        else
                            return false;

                    }
                    catch
                    {
                        return false;
                    }

                }
                catch { return false; }
            }
            else
            {
                return true;
            }
        }


        public DataTable SearchPageTrack(string _Origin, string _Destination, string _Fromdate, string _Todate,
         string _fromReturnDate, string _toReturnDate, string _ReqSource, string _fromHitDate, string _toHitDate,
         string _Site, string _IPAddress, string _Page, string _Page_Url, string _IPCountry, string _IPCiry,
         string _Browser, string _SessionID)
        {
            DataSet dsPageTrack;
            string _CommandText = string.Empty;
            SqlParameter[] param = new SqlParameter[17];
            try
            {
                using (SqlConnection connection = DataConnection.GetPageTrackerConnection())
                {
                    _CommandText = "ST_PageTracker_Get";
                    if (!string.IsNullOrEmpty(_Fromdate) && !string.IsNullOrEmpty(_Todate))
                    {
                        _Todate = Convert.ToDateTime(_Todate).AddDays(1).ToString("dd/MM/yyyy");
                    }

                    if (!string.IsNullOrEmpty(_fromReturnDate) && !string.IsNullOrEmpty(_toReturnDate))
                    {
                        _toReturnDate = Convert.ToDateTime(_toReturnDate).AddDays(1).ToString("dd/MM/yyyy");
                    }

                    if (!string.IsNullOrEmpty(_fromHitDate) && !string.IsNullOrEmpty(_toHitDate))
                    {
                        _toHitDate = Convert.ToDateTime(_toHitDate).AddDays(1).ToString("dd/MM/yyyy");
                    }

                    if (!string.IsNullOrEmpty(_Origin))
                    {
                        param[0] = new SqlParameter("@paramOrigin", SqlDbType.NVarChar, 50);
                        param[0].Value = _Origin;
                    }
                    if (!string.IsNullOrEmpty(_Destination))
                    {
                        param[1] = new SqlParameter("@paramDestination", SqlDbType.NVarChar, 50);
                        param[1].Value = _Destination;
                    }

                    if (!string.IsNullOrEmpty(_Fromdate))
                    {
                        param[2] = new SqlParameter("@paramFromdate", SqlDbType.DateTime);
                        param[2].Value = Convert.ToDateTime(_Fromdate);
                    }
                    if (!string.IsNullOrEmpty(_Todate))
                    {
                        param[3] = new SqlParameter("@paramTodate", SqlDbType.DateTime);
                        param[3].Value = Convert.ToDateTime(_Todate);
                    }
                    if (!string.IsNullOrEmpty(_fromReturnDate))
                    {
                        param[4] = new SqlParameter("@paramFromReturnDate", SqlDbType.DateTime);
                        param[4].Value = Convert.ToDateTime(_fromReturnDate);
                    }

                    if (!string.IsNullOrEmpty(_toReturnDate))
                    {
                        param[5] = new SqlParameter("@paramToReturnDate", SqlDbType.DateTime);
                        param[5].Value = Convert.ToDateTime(_toReturnDate);
                    }
                    if (!string.IsNullOrEmpty(_ReqSource))
                    {
                        param[6] = new SqlParameter("@paramReqSource", SqlDbType.NVarChar, 100);
                        param[6].Value = _ReqSource;
                    }
                    if (!string.IsNullOrEmpty(_fromHitDate))
                    {
                        param[7] = new SqlParameter("@paramFromDatenTime", SqlDbType.DateTime);
                        param[7].Value = Convert.ToDateTime(_fromHitDate);
                    }

                    if (!string.IsNullOrEmpty(_toHitDate))
                    {
                        param[8] = new SqlParameter("@paramToDatenTime", SqlDbType.DateTime);
                        param[8].Value = Convert.ToDateTime(_toHitDate);
                    }
                    if (!string.IsNullOrEmpty(_Site))
                    {
                        param[9] = new SqlParameter("@paramSite", SqlDbType.NVarChar, 100);
                        param[9].Value = _Site;
                    }
                    if (!string.IsNullOrEmpty(_IPAddress))
                    {
                        param[10] = new SqlParameter("@paramIP", SqlDbType.NVarChar, 50);
                        param[10].Value = _IPAddress;
                    }

                    if (!string.IsNullOrEmpty(_Page))
                    {
                        param[11] = new SqlParameter("@paramPage", SqlDbType.NVarChar, 50);
                        param[11].Value = _Page;
                    }
                    if (!string.IsNullOrEmpty(_Page_Url))
                    {
                        param[12] = new SqlParameter("@paramPageUrl", SqlDbType.NVarChar, 500);
                        param[12].Value = _Page_Url;
                    }
                    if (!string.IsNullOrEmpty(_IPCountry))
                    {
                        param[13] = new SqlParameter("@paramIPCountry", SqlDbType.NVarChar, 50);
                        param[13].Value = _IPCountry;
                    }

                    if (!string.IsNullOrEmpty(_IPCiry))
                    {
                        param[14] = new SqlParameter("@paramIPCity", SqlDbType.NVarChar, 50);
                        param[14].Value = _IPCiry;
                    }
                    if (!string.IsNullOrEmpty(_Browser))
                    {
                        param[15] = new SqlParameter("@paramBrowser", SqlDbType.NVarChar, 50);
                        param[15].Value = _Browser;
                    }
                    if (!string.IsNullOrEmpty(_SessionID))
                    {
                        param[16] = new SqlParameter("@paramSessionID", SqlDbType.NVarChar, 200);
                        param[16].Value = _SessionID;
                    }
                    dsPageTrack = null;// SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, _CommandText, param);
                    return dsPageTrack.Tables[0];
                }
            }
            catch (Exception ex)
            {

                dsPageTrack = null;
                return dsPageTrack.Tables[0];
            }
        }
        #endregion

        #region Private Variables
        private DateTime expires = DateTime.Now;

        private int visitCount = 0;
        string originalReferrer = string.Empty, originalURL = string.Empty, sessionURL = string.Empty;
        string userHostAddress = string.Empty, userAgent = string.Empty, sessionReferrer = string.Empty;
        string browser = string.Empty, crawler = string.Empty;
        string ipCity = string.Empty, ipRegion = string.Empty, ipCountry = string.Empty; string source = string.Empty;
        string origin = string.Empty, destination = string.Empty, date = string.Empty, returnDate = string.Empty;
        string sessionID = string.Empty, remarks = string.Empty, redirectFrom = string.Empty;
        #endregion

        #region Properties
        public int VisitCount
        {
            get
            {
                return visitCount;
            }
        }

        public string OriginalReferrer
        {
            get
            {
                return originalReferrer;
            }
        }

        public string OriginalURL
        {
            get
            {
                return originalURL;
            }
        }

        public string SessionReferrer
        {
            get
            {
                return sessionReferrer;
            }
        }

        public string SessionURL
        {
            get
            {
                return sessionURL;
            }
        }

        public string SessionUserHostAddress
        {
            get
            {
                return userHostAddress;
            }
        }

        public string SessionUserAgent
        {
            get
            {
                return userAgent;
            }
        }

        public string Browser
        {
            get
            {
                return browser;
            }
        }
        public string Crawler
        {
            get
            {
                return crawler;
            }
        }


        public string IPCity
        {
            get
            {
                return ipCity;
            }
        }
        public string IPRegion
        {
            get
            {
                return ipRegion;
            }
        }
        public string IPCountry
        {
            get
            {
                return ipCountry;
            }
        }



        public string Origin
        {
            get
            {
                return origin;
            }
        }


        public string Destination
        {
            get
            {
                return destination;
            }
        }
        public string date1
        {
            get
            {
                return date;
            }
        }
        public string ReturnDate
        {
            get
            {
                return returnDate;
            }
        }
        public string RequestSource
        {
            get
            {
                return source;
            }
        }

        public string WebPage
        {
            get
            {
                try
                {
                    if (OriginalURL.Length > 0)
                    {
                        int lastSlace = OriginalURL.LastIndexOf(".uk/");
                        int firstQS = OriginalURL.IndexOf("?");
                        if (firstQS != -1)
                        {

                            string _page = OriginalURL.Substring((lastSlace + 4), (firstQS - (lastSlace + 4)));
                            if (_page.LastIndexOf("/") != -1)
                            {
                                return _page.Substring((_page.LastIndexOf("/") + 1));
                            }
                            else
                            {
                                return _page;
                            }
                        }
                        else
                        {
                            string _page = OriginalURL.Substring((lastSlace + 4));
                            if (_page.LastIndexOf("/") != -1)
                            {
                                return _page.Substring((_page.LastIndexOf("/") + 1));
                            }
                            else
                            {
                                return _page;
                            }


                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                catch { return ""; }
            }
        }

        public string WebSite
        {
            get
            {
                try
                {
                    if (OriginalURL.Length > 0)
                    {
                        int firstSlace = OriginalURL.IndexOf(".uk/");
                        return OriginalURL.Substring(0, (firstSlace + 3));
                    }
                    else
                    {
                        return "";
                    }
                }
                catch { return ""; }
            }
        }

        public string SessionID
        {
            get
            {
                return sessionID;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }
        }
        public string RedirectFrom
        {
            get
            {
                return redirectFrom;
            }
        }

        #endregion
    }
}