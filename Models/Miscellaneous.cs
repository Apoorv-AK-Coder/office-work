using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class Miscellaneous : System.Web.UI.Page
    {
        public static void SetError(string ID, string Message)
        {
            Hashtable htblError = new Hashtable();
            htblError["ID"] = ID;
            htblError["Message"] = Message;

            SecureQueryString sqs = new SecureQueryString();
            sqs["appError"] = "true";
            sqs.ExpireTime = DateTime.Now.AddMinutes(30);

            // Session["_Error"] = htblError;
            System.Web.HttpContext.Current.Response.Redirect("~/Error.aspx?q=" + sqs.ToString(), false);
        }

        public static DataTable GET_Campaign_Master(string CampID, string CompanyID)
        {
            GetSetDatabase objGetSetDatabase = new GetSetDatabase();
            return objGetSetDatabase.GET_Campaign_Master(CampID, CompanyID);
        }
        public static string GetBlockedIPs(string Company)
        {
            DatabaseAccess obj = new DatabaseAccess();
            return obj.GetBlockedIPs(Company);
        }
        public static string getNewURL(string OldURL)
        {
            string newUrl = string.Empty;
            switch (OldURL.ToLower().Trim())
            {
                case "http://www.Faressaver.com/flight_enquiry.aspx": { newUrl = "http://www.Faressaver.com/flight-enquiry.aspx"; break; }
                case "http://www.Faressaver.com/holidayenquiry.aspx": { newUrl = "http://www.Faressaver.com/holiday-enquiry.aspx"; break; }
                case "http://www.Faressaver.com/airlines.aspx": { newUrl = "http://www.Faressaver.com/airlines.aspx"; break; }
                case "http://www.Faressaver.com/specialoffers.aspx": { newUrl = "http://www.Faressaver.com/special-offers.aspx"; break; }
                case "http://www.Faressaver.com/userlogin.aspx": { newUrl = "http://www.Faressaver.com/user-login.aspx"; break; }
                case "http://www.Faressaver.com/usersignup.aspx": { newUrl = "http://www.Faressaver.com/user-signup.aspx"; break; }
                case "http://www.Faressaver.com/privacy_policy.aspx": { newUrl = "http://www.Faressaver.com/privacy-policy.aspx"; break; }
                case "http://www.Faressaver.com/flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/premium-class-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/first-class-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/business-class-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/destination.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/why-book-with-us.aspx": { newUrl = "http://www.Faressaver.com/about-us.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/summer-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/winter-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/easter-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/half-term-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/awards.aspx": { newUrl = "http://www.Faressaver.com/about-us.aspx"; break; }
                case "http://www.Faressaver.com/sitemap.htm": { newUrl = "http://www.Faressaver.com/sitemap.aspx"; break; }
                case "http://www.Faressaver.com/customer-service.aspx": { newUrl = "http://www.Faressaver.com/faq.aspx"; break; }
                case "http://www.Faressaver.com/extras.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/insurance.Faressaver.com": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/visa.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-far-east.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-asia.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-africa.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-europe.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/europe.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-middle-east.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-north-america.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-caribbean.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/caribbean.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-australia/oceania.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia-oceania.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-china.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-south-america.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-newyork.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-new-york.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/cape-town-holiday-packages.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-goa.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-goa.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-delhi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-delhi.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-boston.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-boston.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-ho-chi-minh-city.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-ho-chi-minh-city.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-perth.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-perth.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-toronto.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-toronto.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-caracas.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-caracas.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-abudhabi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-abudhabi.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-narita.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-tokyo.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-doha.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-doha.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-bangkok.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-bangkok.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-manila.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-manila.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-atlanta.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-atlanta.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-orlando.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-orlando.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-daressalaam.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-dar-es-salaam.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-entebbe.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-entebbe.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-adelaide.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-adelaide.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-sanfrancisco.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-san-francisco.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-beijing.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-beijing.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-singapore.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-singapore.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-mexico.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-mexico.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-dubai.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-dubai.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-durban.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-durban.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-guangzhou.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-guangzhou.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-auckland.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-auckland.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-melbourne.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-melbourne.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-edmonton.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-edmonton.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-mumbai.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-mumbai.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-miami.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-miami.aspx"; break; }
                case "http://www.Faressaver.com/far-east/flights-to-bangkok.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-bangkok.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-bogota.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-bogota.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-sydney.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-sydney.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/johannesburg.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-johannesburg.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-cebu.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-cebu.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-christchurch.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-christchurch.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/bali.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-denpasar.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-cairns.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-cairns.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-amritsar.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-amritsar.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-lasvegas.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-las-vegas.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-phuket.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-phuket.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-abuja.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-abuja.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-harare.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-harare.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-hongkong.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-hong-kong.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-washington.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-washington.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-montreal.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-montreal.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-philadelphia.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-philadelphia.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-chicago.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-chicago.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-hanoi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-hanoi.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-lagos.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-lagos.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-quito.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-quito.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-ottawa.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-ottawa.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-calgary.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-calgary.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-rio.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-rio-de-janeiro.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-kohsamui.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-koh-samui.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/mumbai.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-mumbai.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/cairns.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-cairns.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-seattle.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-seattle.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-nairobi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-nairobi.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-lagos.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-lagos.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-christchurch.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-christchurch.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-islamabad.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-islamabad.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-guangzhou.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-guangzhou.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-houston.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-houston.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/edmonton.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-edmonton.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-queenstown.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-queenstown.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-bahrain.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-bahrain.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-buenosaires.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-buenos-aires.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-losangeles.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-los-angeles.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-capetown.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-cape-town.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-bali.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-denpasar.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/hong-kong.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-hong-kong.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-kuwait.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-kuwait.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/los-angeles.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-los-angeles.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/abu-dhabi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-abudhabi.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-ahmedabad.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-ahmedabad.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/nanjing.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-nanjing.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-hyderabad.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-hyderabad.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-taipei.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-taipei.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-colombo.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-colombo.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-vancouver.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-vancouver.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-osaka.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-osaka.aspx"; break; }
                case "http://www.Faressaver.com/africa/flights-to-nairobi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-nairobi.aspx"; break; }
                case "http://www.Faressaver.com/royal-jordanian-flights.aspx": { newUrl = "http://www.Faressaver.com/airlines.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/rio-de-janeiro.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-rio-de-janeiro.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-manila.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-manila.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-luzhou.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-luzhou.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-brisbane.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-brisbane.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-wellington.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-wellington.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/chengdu.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-chengdu.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/bogota.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-bogota.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-chengdu.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-chengdu.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/phnom-penh.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-phnom-penh.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/delhi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-delhi.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-penang.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-penang.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-tokyo.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-tokyo.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-santacruz.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-santa-cruz.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/shanghai.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-shanghai.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-changsha.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-changsha.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-cochin.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-kochi.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-entebbe.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-entebbe.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-honolulu.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-honolulu.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/colombo.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-colombo.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/beijing.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-beijing.aspx"; break; }
                case "http://www.Faressaver.com/flightsoffer/flights-to-auckland.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-auckland.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-phnompenh.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-phnom-penh.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-guadeloupe.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/flights-to-amsterdam.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/europe/flights-to-amsterdam.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-mauritius.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-mauritius.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-wellington.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-wellington.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/buenos-aires.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-buenos-aires.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/caracas.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-caracas.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/guangzhou.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-guangzhou.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/shenyang.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-shenyang.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/dalian.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/china/flights-to-dalian.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/hanoi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-hanoi.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/quito.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-quito.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-amman.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east/flights-to-amman.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-nadi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-nadi.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-halifax.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-halifax.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-canberra.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-canberra.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-portelizabeth.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-port-elizabeth.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-florianopolis.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america/flights-to-florianopolis.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-lagos.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-lagos.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-los-angeles.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-los-angeles.aspx"; break; }

                case "http://www.Faressaver.com/flights-to-seattle.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-seattle.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-singapore.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-singapore.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-bangkok.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-bangkok.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-harare.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-harare.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-orlando.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-orlando.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-newyork.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-new-york.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-chicago.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-chicago.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-ottawa.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-ottawa.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-miami": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america/flights-to-miami.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-m.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-n.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-s.america.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/south-america.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-fareast.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-s.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-fare-east.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-m.east.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/middle-east.aspx"; break; }
                case "http://www.Faressaver.com/cheap-flights/flights-to-n.america.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/north-america.aspx"; break; }
                case "http://www.Faressaver.com/direct-flights/kuala-lumpur.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-kuala-lumpur.aspx"; break; }
                //case "http://www.Faressaver.com/direct-flights/johannesburg.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-johannesburg.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-perth.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/australia/flights-to-perth.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-daressalaam.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-dar-es-salaam.aspx"; break; }
                //case "http://www.Faressaver.com/direct-flights/penang.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-penang.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-harare.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-harare.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-entebbe.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-entebbe.aspx"; break; }
                //case "http://www.Faressaver.com/business-class-flights.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-cebu.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-cebu.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-nairobi.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-nairobi.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-accra.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-accra.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-capetown.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-cape-town.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-bali.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-denpasar.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-johannesburg.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-johannesburg.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-abuja.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-abuja.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-osaka.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-osaka.aspx"; break; }
                case "http://www.Faressaver.com/flights-to-jakarta.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/far-east/flights-to-jakarta.aspx"; break; }
                //case "http://www.Faressaver.com/royal-jordanian-flights.aspx": { newUrl = "http://www.Faressaver.com/airlines.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-colombo.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/asia/flights-to-colombo.aspx"; break; }
                //case "http://www.Faressaver.com/flights-to-mauritius.aspx": { newUrl = "http://www.Faressaver.com/cheap-flights/africa/flights-to-mauritius.aspx"; break; }
                case "http://www.Faressaver.com/city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/paris-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/milan-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lisbon-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/amsterdam-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/ibiza-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/milan-2-3nights-cheap-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lanzarote-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lanzarote-2nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/rome-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/porto-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/rome-3nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city_breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/budapest-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/milan-2days-cheap-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/madrid-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/reykjavik-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/milan-2days-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/malta-3nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/reykjavik-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/brussels-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/rome-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/amsterdam-2nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/milan-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/berlin-3nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/krakow-2nights-cheap-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lisbon-3nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/amsterdam-2-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/amsterdam-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/warsaw-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lanzarote-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/algarve-3nights-cheap-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/copenhagen-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/krakow-3nights-cheap-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/algarve-3nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/paris-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lanzarote-3nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/barcelona-2nights-short-weekand-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/dublin-3nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/krakow-2-3nights-cheap-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/madrid-2nights-short-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/bratislava-weekend-breaks.aspx/images/": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/dublin-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/oslo-2-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/krakow-weekend-breaks.aspx/city-breaks/images/": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/krakow-weekend-breaks.aspx/item0022": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/venice-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/berlin-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/krakow-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/bratislava-2nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/copenhagen-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/madrid-3nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/florence-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/bratislava-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/copenhagen-3nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/rome-2-3nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/berlin-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/malta-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/budapest-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/barcelona-2days-3nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lisbon-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lisbon-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/lisbon-2nights-weekend-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/bratislava-weekend-breaks.aspx/item0019": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/bratislava-weekend-breaks.aspx/city-breaks/images/": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/istanbul-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/florence-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/malaga-weekend-breaks.aspx/item0023": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/krakow-weekend-breaks.aspx/images/": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/berlin-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/rome-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/budapest-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/warsaw-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks.a": { newUrl = "http://www.Faressaver.com"; break; }
                //case "http://www.Faressaver.com/city-breaks/europe/berlin-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/dublin-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/algarve-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/brussels-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                //case "http://www.Faressaver.com/city-breaks/europe/budapest-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/oslo-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/porto-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/prague-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/istanbul-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/malta-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/vienna-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                //case "http://www.Faressaver.com/city-breaks/europe/florence-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/porto-3nights-short-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/porto-2-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                //case "http://www.Faressaver.com/city-breaks/krakow-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/nice-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/madrid-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                //case "http://www.Faressaver.com/city-breaks/europe/warsaw-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/dublin-3nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/pisa-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/europe/lanzarote-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/krakow-3nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/oslo-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/paris-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/krakow-2nights-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/venice-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/berlin-2nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/milan-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                //case "http://www.Faressaver.com/city-breaks/rome-2nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/warsaw-2nights-short-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/venice-2nights-short-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/dublin-2nights-weekend-break.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/algarve-3nights-city-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                case "http://www.Faressaver.com/city-breaks/pisa-2nights-short-city-weekend-breaks.aspx": { newUrl = "http://www.Faressaver.com"; break; }
                default: { newUrl = OldURL; break; }
            }
            return newUrl;
        }

        public static bool ActiveHoldFree(string SourceMedia)
        {
            bool b = false;
            switch (SourceMedia.ToUpper())
            {
                case "TRVJUNCTION": { b = true; break; }
                case "NEWSLTR": { b = true; break; }
            }
            return b;
        }


    }
}
