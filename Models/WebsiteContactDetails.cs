using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSite.Models;
using System.Web;
using System.Xml;
using System.Xml.XPath;


namespace TravelSite.Models
{

    public class WebsiteContactDetails
    {

        public WebsiteContactDetails(string uniCode, string key)
        {
            try
            {
                ContactNo1 = CompCredentials.ContactNo1;
                ContactNo2 = CompCredentials.ContactNo1;
                string code = string.Empty;
                SearchDetails SearchDetails;
                if (HttpContext.Current.Session.Count > 0)
                {
                    for (int i = HttpContext.Current.Session.Count; i > 0; i--)
                    {
                        if (HttpContext.Current.Session.Keys[i - 1].IndexOf("SearchParam#") != -1)
                        {
                            SearchDetails = SearchDetails.Current(HttpContext.Current.Session.Keys[i - 1].Split('#')[1]);
                            if (!string.IsNullOrEmpty(uniCode) && (uniCode.ToUpper() != SearchDetails.SourceMedia.ToUpper()))
                            {
                                SearchDetails.SourceMedia = uniCode;
                                SearchDetails.key = key;
                            }
                            else
                            {
                                uniCode = SearchDetails.SourceMedia.ToLower();
                                try
                                {
                                    //key = SearchDetails.key.ToLower();
                                }
                                catch
                                {
                                    key = "";
                                }
                            }
                            break;
                        }
                        else
                        {
                            SearchDetails = SearchDetails.SetCurrent(Guid.NewGuid().ToString());
                            SearchDetails.CompanyID = CompCredentials.CompanyId;
                            SearchDetails.SourceMedia = uniCode;
                            SearchDetails.key = key;

                        }
                    }
                }
                else
                {
                    SearchDetails = SearchDetails.SetCurrent(Guid.NewGuid().ToString());
                    SearchDetails.CompanyID = CompCredentials.CompanyId;
                    SearchDetails.SourceMedia = uniCode;
                    SearchDetails.key = key;

                }
                DataTable dtPhone = Caching.GetPhoneCachingData(CompCredentials.CompanyId, uniCode.ToUpper());
                if (dtPhone != null && dtPhone.Rows.Count > 0)
                {

                    ContactNo1 = dtPhone.Rows[0]["Phone1"].ToString();
                    ContactNo2 = dtPhone.Rows[0]["Phone2"].ToString();
                    media = dtPhone.Rows[0]["sourceMedia"].ToString();
                }
                DataSet ds = new DataSet();
                //string key = "ctbrand";
                if (uniCode.ToLower() != "" || key != "")
                {
                    media = uniCode;
                    keydata = key;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/googlecampaign.xml"));
                    
                    XmlNodeList xmlSelectedNode = xmlDoc.SelectNodes("//Compaigns/Compaign[@sourceMedia='"+ uniCode +"' and @key='"+ key +"']");
                    foreach (XmlNode node in xmlSelectedNode)
                    {
                        ContactNo1 = node.SelectSingleNode("contactNo1").InnerText;
                        ContactNo2 = node.SelectSingleNode("contactNo2").InnerText;
                    }
                }
            }
            catch
            {
                ContactNo1 = CompCredentials.ContactNo1;
                ContactNo2 = CompCredentials.ContactNo1;
                media = CompCredentials.CompanyId;
            }
        }

        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string media { get; set; }
        public string keydata { get; set; }
        public static string WebsiteUrl
        {
            get { return "http://" + HttpContext.Current.Request.Url.Authority + "/"; }
        }
        public static string WebsiteUrlHTTPS
        {
            get { return "https://" + HttpContext.Current.Request.Url.Host + "/"; }
        }
    }
}
