using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.SessionState;
using System.Windows;

namespace TravelSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                //ipAddress = "137.174.67.255";
                //ipAddress = "103.158.217.23";
            }



            string APIKey = "9e4b26fcad22c4a412a062b703e6278007da63f8d8e3db3137226d4d954e4ac8";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress);
            using (System.Net.WebClient client = new WebClient())
            {
                try
                {
                    //string json = client.DownloadString(url);
                    //Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                    //List<Location> locations = new List<Location>();
                    //locations.Add(location);

                    //string city = location.CityName;
                    //string country = location.CountryName;

                    //if (country == "Spain")
                    //{
                    //    AddUpdateAppSettings("mykey", "Spain");
                    //}
                    //else
                    //{
                    //    AddUpdateAppSettings1("mykey", "India");
                    //}
                    //string ipaddress = location.IPAddress;
                }
                catch
                {

                }               
                
            }

            try
            {

                #region HTTPS Redirection

                //if (HttpContext.Current.Request.ServerVariables["HTTPS"] == "on")
                //{
                //    if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf("www.") == -1)
                //    {
                //        Response.Status = "301 Moved Permanently";
                //        Response.AddHeader("Location", HttpContext.Current.Request.Url.AbsoluteUri.Replace("https://", "https://www."));
                //        return;
                //    }
                //}
                //else
                //{

                //    if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().IndexOf("www.") == -1)
                //    {
                //        Response.Status = "301 Moved Permanently";
                //        Response.AddHeader("Location", HttpContext.Current.Request.Url.AbsoluteUri.Replace("http://", "https://www."));
                //        return;
                //    }
                //    else
                //    {
                //        Response.Status = "301 Moved Permanently";
                //        Response.AddHeader("Location", HttpContext.Current.Request.Url.AbsoluteUri.Replace("http://", "https://"));
                //        return;
                //    }
                //}


                #endregion

            }
            catch { }
        }

        public void AddUpdateAppSettings(string key, string value)
        {
            Configuration config = null;
            config = WebConfigurationManager.OpenWebConfiguration("~");
            var appsettingsection = (AppSettingsSection)config.GetSection("appSettings");
            appsettingsection.Settings["mykey"].Value = "Spain";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

        }


        public void AddUpdateAppSettings1(string key, string value)
        {
            Configuration config = null;
            config = WebConfigurationManager.OpenWebConfiguration("~");
            var appsettingsection = (AppSettingsSection)config.GetSection("appSettings");
            appsettingsection.Settings["mykey"].Value = "India";
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

        }



        public class Location
        {
            public string IPAddress { get; set; }
            public string CountryName { get; set; }
            public string CountryCode { get; set; }
            public string CityName { get; set; }
            public string RegionName { get; set; }
            public string ZipCode { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string TimeZone { get; set; }
        }
    }
}
