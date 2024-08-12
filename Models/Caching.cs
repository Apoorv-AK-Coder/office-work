using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace TravelSite.Models
{
    public class Caching
    {
        private static DataSet DS = null;

        public static void CatchStaticData(Caching_OF _cachingOf)
        {
            //if (Airport_Dictionary.Current() == null || Airline_Dictionary.Current() == null ||
            //    HttpRuntime.Cache[Enum.GetName(typeof(Caching_OF), Caching_OF.BLACKLIST_AIRLINES) + FlightFareSearchRQ.Current().CompanyID] == null ||
            //    HttpRuntime.Cache[FlightFareSearchRQ.Current().CompanyID +FlightFareSearchRQ.Current().HAP_Type] == null
            //    )
            //{
            
            switch (_cachingOf)
            {
                case Caching_OF.AIRLINE_LIST:
                    Airline_Caching();
                    break;

                case Caching_OF.AIRPORT_LIST:
                    Airport_Caching();
                    break;

                case Caching_OF.COMPANY_CREDENTIAL_LIST:
                    Credential_Caching(FlightFareSearchRQ.Current().CompanyID);
                    break;

                case Caching_OF.ALL_LIST:
                    All_Caching(FlightFareSearchRQ.Current().CompanyID);
                    break;

            }
            //cache data if anyone not cached.
            All_Caching(FlightFareSearchRQ.Current().CompanyID);
            //}
        }

        

        private static void Airline_Caching()
        {
            Dictionary<string, Airline_Dictionary> Airlines = new Dictionary<string, Airline_Dictionary>();
            if (DS != null)
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables["Airlines"] != null && DS.Tables["Airlines"].Rows.Count != 0)
                    {
                        foreach (DataRow dr in DS.Tables["Airlines"].Rows)
                        {
                            Airline_Dictionary airline = new Airline_Dictionary();
                            airline.AirlineName = Convert.ToString(dr["AirlineName"]).Trim();
                            airline.AirlineCode = Convert.ToString(dr["AirlineCode"]).ToUpper().Trim();

                            if (!Airlines.ContainsKey(airline.AirlineCode))
                            {
                                Airlines.Add(airline.AirlineCode, airline);
                            }
                        }
                        HttpRuntime.Cache.Insert(Enum.GetName(typeof(Caching_OF), Caching_OF.AIRLINE_LIST), Airlines, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new System.TimeSpan(0, 240, 0));
                    }
                }
            }
        }

        private static void Airport_Caching()
        {
            Dictionary<string, Airport_Dictionary> Airports = new Dictionary<string, Airport_Dictionary>();
            if (DS != null)
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables["Airports"] != null && DS.Tables["Airports"].Rows.Count != 0)
                    {
                        foreach (DataRow dr in DS.Tables["Airports"].Rows)
                        {
                            Airport_Dictionary airport = new Airport_Dictionary();
                            airport.AirportCode = Convert.ToString(dr["AirportCode"]).ToUpper().Trim();
                            airport.AirportName = Convert.ToString(dr["AirportName"]).Trim();
                            airport.AirportCityCode = Convert.ToString(dr["CityCode"]).Trim();
                            airport.AirportCityName = Convert.ToString(dr["CityName"]).Trim();
                            airport.AirportCountryCode = Convert.ToString(dr["CountryCode"]).Trim();
                            airport.AirportCountryName = Convert.ToString(dr["CountryName"]).Trim();
                            airport.GeoLocation = Convert.ToString(dr["GEO_Code"]).Trim();

                            if (!Airports.ContainsKey(airport.AirportCode))
                            {
                                Airports.Add(airport.AirportCode, airport);
                            }
                        }
                        HttpRuntime.Cache.Insert(Enum.GetName(typeof(Caching_OF), Caching_OF.AIRPORT_LIST), Airports, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new System.TimeSpan(0, 240, 0));

                    }
                }
            }
        }

        private static void Credential_Caching(string Company_ID)
        {
            if (DS != null)
            {
                if (DS.Tables.Count > 0)
                {
                    if (DS.Tables["Credentials"] != null && DS.Tables["Credentials"].Rows.Count != 0)
                    {

                        if (DS.Tables["Credentials"].Rows.Count > 0)
                        {
                            List<Credential> Credentials = new List<Credential>();
                            foreach (DataRow dr in DS.Tables["Credentials"].Rows)
                            {

                                if (Convert.ToBoolean(dr["Active"]))
                                {
                                    Credential _credential = new Credential();
                                    _credential.Company_ID = Convert.ToString(dr["Company_ID"]);
                                    _credential.Company_Name = Convert.ToString(dr["Company_Name"]);
                                    _credential.Hap = Convert.ToString(dr["Campaign_ID"]);
                                    _credential.Hap_Password = Convert.ToString(dr["Campaign_Password"]);
                                    _credential.Hap_Type = Convert.ToString(dr["Campaign_Type"]);
                                    _credential.Product_Type = Convert.ToString(dr["Product_Type"]);
                                    _credential.Supplier_ID = Convert.ToString(dr["Product_Code"]);
                                    int noOffares = 0;
                                    if (!int.TryParse(Convert.ToString(dr["NoOfFares"]), out noOffares)) { _credential.No_Of_Fares = 100; }
                                    else { _credential.No_Of_Fares = noOffares; }

                                    _credential.isActive = Convert.ToBoolean(dr["Active"]);

                                    _credential.Supplier_User_ID = Convert.ToString(dr["User_ID"]);
                                    _credential.Supplier_Password = Convert.ToString(dr["Password"]);
                                    _credential.Supplier_Psuedo = Convert.ToString(dr["Psuedo_Code"]);
                                    _credential.Supplier_WSAP_Session = Convert.ToString(dr["WSAP_OR_Session"]);
                                    _credential.Supplier_Ord_ID = Convert.ToString(dr["Ord_ID"]);
                                    _credential.Supplier_Pass_Len = Convert.ToString(dr["Pass_Len"]);

                                    //_credential.Email_ID = Convert.ToString(dr["WL_HAP_Email"]);
                                    _credential.Supplier_Endpoint = Convert.ToString(dr["ServiceURL"]);
                                    _credential.Supplier_Namespance = Convert.ToString(dr["NameSpace"]);
                                    //_credential.is_Cache = Convert.ToBoolean(dr["COMP_DTL_Is_Get_Cache"]);
                                    //_credential.Website_Landing_URL = Convert.ToString(dr["COMP_DTL_Company_Domain_RegForMrkt"]);

                                    if (!Credentials.Exists(x => x.Supplier_ID == _credential.Supplier_ID))
                                    {

                                        Credentials.Add(_credential);
                                    }
                                }
                            }
                            HttpRuntime.Cache.Insert(Company_ID + FlightFareSearchRQ.Current().HAP_Type, Credentials, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 120, 0));
                        }
                    }
                }

            }
        }


        private static void All_Caching(string Company_ID)
        {

            Airline_Caching();
            Airport_Caching();
            //Credential_Caching( Company_ID);
        }

        
        private static void SetPhoneCachingData(string sCompanyID, string sSource)
        {
            DataTable dtPhone = DatabaseAccess.Get_CompanyPhones(sCompanyID, sSource);
            HttpRuntime.Cache.Insert("Phone" + sCompanyID + "_" + sSource, dtPhone, null, DateTime.Now.AddMinutes(30), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
        }

        public static DataTable GetPhoneCachingData(string sCompanyID, string sSource)
        {
            DataTable dtPhone = null;

            if (HttpContext.Current != null)
            {
                if (HttpRuntime.Cache.Get("Phone" + sCompanyID + "_" + sSource) == null)
                {
                    SetPhoneCachingData(sCompanyID, sSource);
                }
                dtPhone = (DataTable)HttpRuntime.Cache.Get("Phone" + sCompanyID + "_" + sSource);
            }
            return dtPhone;
        }
    }
}
