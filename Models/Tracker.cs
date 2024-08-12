using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;


namespace TravelSite.Models
{
    public class Tracker
    {

        #region constructor
        public Tracker(HttpContext ctx, string _origin, string _destination, string _date, string _returnDate,
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
                date = _date;
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

        public Tracker()
        {
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


        public static bool PageTracking(Tracker oTracker)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[15];

                param[0] = new SqlParameter("@paramIP", SqlDbType.NVarChar, (50));
                param[0].Value = oTracker.SessionUserHostAddress;

                param[1] = new SqlParameter("@paramReqSource", SqlDbType.NVarChar, (100));
                param[1].Value = oTracker.RequestSource;

                param[2] = new SqlParameter("@paramPage", SqlDbType.NVarChar, (50));
                param[2].Value = oTracker.WebPage;

                param[3] = new SqlParameter("@paramPageUrl", SqlDbType.NVarChar, (500));
                param[3].Value = oTracker.OriginalURL;

                param[4] = new SqlParameter("@paramSite", SqlDbType.NVarChar, (100));
                param[4].Value = oTracker.WebSite;

                param[5] = new SqlParameter("@paramOrigin", SqlDbType.NVarChar, (50));
                param[5].Value = oTracker.Origin;

                param[6] = new SqlParameter("@paramDestination", SqlDbType.NVarChar, (50));
                param[6].Value = oTracker.Destination;

                try
                {
                    param[7] = new SqlParameter("@paramdate", SqlDbType.DateTime);
                    param[7].Value = Convert.ToDateTime(oTracker.date);
                }
                catch { param[7].Value = Convert.ToDateTime("01/01/1900"); }

                if (!string.IsNullOrEmpty(oTracker.ReturnDate))
                {
                    try
                    {
                        param[8] = new SqlParameter("@paramReturnDate", SqlDbType.DateTime);
                        param[8].Value = Convert.ToDateTime(oTracker.ReturnDate);
                    }
                    catch { param[8].Value = Convert.ToDateTime("01/01/1900"); }
                }
                param[9] = new SqlParameter("@paramIPCity", SqlDbType.NVarChar, (50));
                param[9].Value = oTracker.IPCity;

                param[10] = new SqlParameter("@paramIPCountry", SqlDbType.NVarChar, (50));
                param[10].Value = oTracker.IPCountry;
                param[11] = new SqlParameter("@paramBrowser", SqlDbType.NVarChar, (200));
                param[11].Value = oTracker.Browser;
                param[12] = new SqlParameter("@paramSession", SqlDbType.NVarChar, (200));
                param[12].Value = oTracker.SessionID;
                param[13] = new SqlParameter("@paramRemarks", SqlDbType.NVarChar, (200));
                param[13].Value = oTracker.Remarks;
                param[14] = new SqlParameter("@paramRedirectFrom", SqlDbType.NVarChar, (100));
                param[14].Value = oTracker.RedirectFrom;
                using (SqlConnection conection = DataConnection.GetConnection())
                {
                    int count = SqlHelper.ExecuteNonQuery(conection, CommandType.StoredProcedure, "ST_PageTracker_Insert", param);
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
       
        
        private static bool CheckIPAddress(string sIPAddress)
        {
            bool b = false;
            switch (sIPAddress)
            {
                case "203.196.136.226":
                    { b = true; break; }
                case "125.63.65.114":
                    { b = true; break; }
                case "222.165.187.74":
                    { b = true; break; }
                case "83.244.130.69":
                    { b = true; break; }
                case "83.244.130.66":
                    { b = true; break; }
                case "31.221.37.178":
                    { b = true; break; }
                case "31.221.39.170":
                    { b = true; break; }
            }

            return b;

        }

               
    }
}
