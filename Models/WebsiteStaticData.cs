using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class WebsiteStaticData
    {
        public static string ContactNo1
        {
            get
            {               
                string contact1 = "866-699-8919";
                if (HttpContext.Current.Request.Browser.Cookies)
                {
                    HttpCookie nameCookie = HttpContext.Current.Request.Cookies["JT_SourceMedia"];

                    //If Cookie exists fetch its value.
                    string name = nameCookie != null ? nameCookie.Value.Split('=')[1] : "";
                    if (name.ToUpper() == "DC")
                    {
                        contact1 = "866-699-8919";
                    }                        
                }
                return contact1;
            }
        }
        public static string ContactNo2
        {
            get
            {
                
                string contact1 = "866-699-8919";
               
                return contact1;
            }
        }
        public static string OfficeTimimg
        {
            get { return "24 hours a day / 7 days a week"; }
        }

        public static string EmailID1
        {
            get { return "support@faressaver.com"; }
        }
        public static string EmailID2
        {
            get { return "onlinebooking@Faressaver.com"; }
        }
        public static string WebsiteUrl
        {
            get
            {
                if (HttpContext.Current.Request.Url.Host.ToLower().Contains("localhost"))
                {
                    return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + "/";
                }
                else { return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/"; }
            }

        }
        public static string WebsiteUrlHTTPS
        {
            get
            {

                if (HttpContext.Current.Request.Url.Host.ToLower().Contains("localhost"))
                {


                    return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + "/";
                }
                else { return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/"; }

            }
        }

       
    }
    public static class MyEnums
    {
        #region Currency
        public struct Currency
        {
            public const String GBP = "£", INR = "₹", USD = "$", EUR = "€";
        };
        #endregion
    }
}