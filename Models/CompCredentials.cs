using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class CompCredentials
    {
        public static string CompanyId = "FS";
        public static string CompanyName = "Fares Saver Online";
        public static string HapId = "FS";
        public static string HapPassword = "tr@365";
        public static string HapType = "LIVE";
        public static string ContactNo = "866-699-8919";        
        public static string Domain = "";
        public static string LogoPath1 = "";
        public static string LogoPath = "";


        public static string Fax = "";
        public static string Email = "";
        public static string Url = "";
        public static string Address = "";
        public static string AgentId = "1";
        public static string BranchId = "1";
        public static string CoustmerType = "DIR";
        public static string Author = "Fares Saver";
        public static string Currency_Symbol = "$";
        public static string Currency = "USD";
        public static string OnlineEmail = "test@test.com";
        public static string SourceMedia = "";

        public static void SetCurrencySymbol(string Curr)
        {
            switch (Curr)
            {
                case "EUR":
                    Currency_Symbol = "€";
                    break;
                case "USD":
                    Currency_Symbol = "$";
                    break;
                case "GBP":
                    Currency_Symbol = "£";
                    break;
            }
        }
        public static DataTable GetCompanyDetails()
        {
            DataTable Dt = Global.ExecuteSPReturnDT(new object[] {"Usp_GetCompanyDetails"
                                                    ,"@Domain",CompCredentials.Domain                                                                                                      
                 }, DataConnection.GetConnection());
            return Dt;
        }

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
                    else if (name.ToUpper() == "CHFT")
                    {

                        contact1 = "0203 137 6304";

                    }
                    else if (name.ToUpper() == "GPPC")
                    {

                        contact1 = "866-699-8919";

                    }
                    else if (name.ToUpper() == "INTNT")
                    {

                        contact1 = "866-699-8919";

                    }
                    else if (name.ToUpper() == "ALFAMSKY")
                    {

                        contact1 = "866-699-8919"; //given by prabhat on 5-2-2019

                    }
                    //0203 137 6305
                    else if (name.ToUpper() == "TJ_CFLT" || name.ToUpper() == "TJ_DCMeta" || name.ToUpper() == "TJ_EASYV" ||
                        name.ToUpper() == "TJ_MMD" || name.ToUpper() == "TJ_JETC" || name.ToUpper() == "TJ_TRVNGL"
                            || name.ToUpper() == "TJ_FRCOMP")
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
                //0203 475 5503 
                string contact1 = "0207 183 1571";
                if (HttpContext.Current.Request.Browser.Cookies)
                {

                    HttpCookie nameCookie = HttpContext.Current.Request.Cookies["JT_SourceMedia"];

                    //If Cookie exists fetch its value.
                    string name = nameCookie != null ? nameCookie.Value.Split('=')[1] : "";
                    if (name.ToUpper() == "DC")
                    {

                        contact1 = "0203 475 5503";
                    }
                    else if (name.ToUpper() == "CHFT")
                    {

                        contact1 = "0203 137 6304";

                    }
                    else if (name.ToUpper() == "GPPC")
                    {

                        contact1 = "866-699-8919";

                    }
                    else if (name.ToUpper() == "ALFAMSKY")
                    {

                        contact1 = "0203 137 6305"; //given by prabhat on 5-2-2019

                    }
                    //0203 137 6305


                }


                return contact1;
            }
        }
        public static string OfficeTimimg
        {
            get { return "24 hours a day / 7 days a week"; }
        }

        public static string EmailID1
        {
            get { return "varunsingh9188@gmail.com"; }
        }
        public static string EmailID2
        {
            get { return "varunsingh9188@gmail.com"; }
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

        public static string Facebook
        {
            get { return "https://www.facebook.com/FaressaverUK"; }
        }
        public static string GoolgePlus
        {
            get { return "https://plus.google.com/+FaressaverUk"; }
        }
        public static string Twitter
        {
            get { return "https://twitter.com/_Faressaver"; }
        }
        public static string Pinterest
        {
            get { return "https://uk.pinterest.com/travel_junction/"; }
        }


    }
}