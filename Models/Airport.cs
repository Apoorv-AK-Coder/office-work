using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TravelSite.Models
{
    [Serializable]
    public class Airport //: ISerializable
    {

        private string _airportCode;
        public string AirportCode
        {
            get { return _airportCode; }

            set
            {
                _airportCode = value;
                _airportCode = _airportCode.Trim().ToUpper();

                //set other details of airport   
                if (string.IsNullOrEmpty(_airportCode) || _airportCode.Length < 3)
                {
                    throw new ArgumentException("Invalid Origin/Destination Code : Origin/Destination Code must be three letters of city or airport code.");
                }

                System.Collections.Generic.Dictionary<string, Airport_Dictionary> oAirports = Airport_Dictionary.Current();
                if (oAirports != null && oAirports.ContainsKey(_airportCode))
                {
                    Airport_Dictionary _oAirport = (Airport_Dictionary)oAirports[_airportCode];

                    this._airportName = _oAirport.AirportName;
                    this._airportCityCode = _oAirport.AirportCityCode;
                    this._airportCityName = _oAirport.AirportCityName;

                    this._airportCountryCode = _oAirport.AirportCountryCode;
                    this._airportCountryName = _oAirport.AirportCountryName;

                    this._geoLocation = _oAirport.GeoLocation;
                }

            }
        }


        private string _airportName;
        public string AirportName
        {
            get { return _airportName; }
            set { _airportName = value; }
        }

        private string _airportCityCode;
        public string AirportCityCode
        {
            get { return _airportCityCode; }
            set { _airportCityCode = value; }

        }


        private string _airportCityName;
        public string AirportCityName
        {
            get { return _airportCityName; }
            set { _airportCityName = value; }
        }


        private string _airportCountryCode;
        public string AirportCountryCode
        {
            get { return _airportCountryCode; }
            set { _airportCountryCode = value; }
        }

        private string _airportCountryName;
        public string AirportCountryName
        {
            get { return _airportCountryName; }
            set { _airportCountryName = value; }
        }


        private string _geoLocation;
        public string GeoLocation
        {
            get { return _geoLocation; }
            set { _geoLocation = value; }
        }

        public Airport() { }
        //public Airport(SerializationInfo info, StreamingContext context)
        //{
        //    AirportCode = info.GetString("AirportCode");          
        //    GeoLocation = info.GetString("GeoLocation");
        //}

        //public void  GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("AirportCode", AirportCode);
        //    info.AddValue("AirportName", AirportName);
        //    info.AddValue("AirportCityCode", AirportCityCode);
        //    info.AddValue("AirportCityName", AirportCityName);

        //    info.AddValue("AirportCountryCode", AirportCountryCode);
        //    info.AddValue("AirportCountryName", AirportCountryName);
        //    info.AddValue("GeoLocation", GeoLocation);

        //}


    }


    [Serializable]
    public class Airport_Dictionary : ISerializable
    {


        private string _airportCode;
        public string AirportCode
        {
            get { return _airportCode; }
            set { _airportCode = value; }
        }


        private string _airportName;
        public string AirportName
        {
            get { return _airportName; }
            set { _airportName = value; }
        }

        private string _airportCityCode;
        public string AirportCityCode
        {
            get { return _airportCityCode; }
            set { _airportCityCode = value; }
        }


        private string _airportCityName;
        public string AirportCityName
        {
            get { return _airportCityName; }
            set { _airportCityName = value; }
        }


        private string _airportCountryCode;
        public string AirportCountryCode
        {
            get { return _airportCountryCode; }
            set { _airportCountryCode = value; }
        }

        private string _airportCountryName;
        public string AirportCountryName
        {
            get { return _airportCountryName; }
            set { _airportCountryName = value; }
        }


        private string _geoLocation;
        public string GeoLocation
        {
            get { return _geoLocation; }
            set { _geoLocation = value; }
        }

        public static System.Collections.Generic.Dictionary<string, Airport_Dictionary> Current()
        {
            System.Collections.Generic.Dictionary<string, Airport_Dictionary> Airports = null;
            if (HttpContext.Current != null)
            {
                if (HttpRuntime.Cache[Enum.GetName(typeof(Caching_OF), Caching_OF.AIRPORT_LIST)] == null)
                {
                    Caching.CatchStaticData(Caching_OF.AIRPORT_LIST);
                }
                Airports = (System.Collections.Generic.Dictionary<string, Airport_Dictionary>)HttpRuntime.Cache[Enum.GetName(typeof(Caching_OF), Caching_OF.AIRPORT_LIST)];

            }
            return Airports;
        }

        public Airport_Dictionary() { }

        public Airport_Dictionary(SerializationInfo info, StreamingContext context)
        {
            AirportCode = info.GetString("AirportCode");
            AirportName = info.GetString("AirportName");
            AirportCityCode = info.GetString("AirportCityCode");
            AirportCityName = info.GetString("AirportCityName");

            AirportCountryCode = info.GetString("AirportCountryCode");
            AirportCountryName = info.GetString("AirportCountryName");
            GeoLocation = info.GetString("GeoLocation");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AirportCode", AirportCode);
            info.AddValue("AirportName", AirportName);
            info.AddValue("AirportCityCode", AirportCityCode);
            info.AddValue("AirportCityName", AirportCityName);

            info.AddValue("AirportCountryCode", AirportCountryCode);
            info.AddValue("AirportCountryName", AirportCountryName);
            info.AddValue("GeoLocation", GeoLocation);

        }
    }
}