using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TravelSite.Models
{
    [Serializable]
    public class Airline : ISerializable
    {
        public Airline()
        {

        }

        private string _airlineName;
        public string AirlineName
        {
            get
            {

                return _airlineName;
            }
            set { }
        }
        private string _airlineCode;
        public string AirlineCode
        {
            get { return _airlineCode; }
            set
            {
                _airlineCode = value;
                _airlineCode = _airlineCode.Trim().ToUpper();


                if (!String.IsNullOrEmpty(_airlineCode) && _airlineCode != "ALL")
                {
                    System.Collections.Generic.Dictionary<string, Airline_Dictionary> oAirlines = Airline_Dictionary.Current();
                    if (oAirlines.ContainsKey(_airlineCode))
                    {
                        _airlineName = ((Airline_Dictionary)oAirlines[_airlineCode]).AirlineName;
                    }
                }
            }
        }

        public Airline(SerializationInfo info, StreamingContext context)
        {
            AirlineCode = info.GetString("AirlineCode");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AirlineName", AirlineName);
            info.AddValue("AirlineCode", AirlineCode);
        }

    }


    [Serializable]
    public class Airline_Dictionary : ISerializable
    {
        private string _airlineName;
        public string AirlineName
        {
            get { return _airlineName; }
            set { _airlineName = value; }
        }

        private string _airlineCode;
        public string AirlineCode
        {
            get { return _airlineCode; }
            set { _airlineCode = value; }
        }

        public static System.Collections.Generic.Dictionary<string, Airline_Dictionary> Current()
        {
            System.Collections.Generic.Dictionary<string, Airline_Dictionary> Airlines = null;
            //if (HttpRuntime.Current != null)
            //{
            if (HttpRuntime.Cache[Enum.GetName(typeof(Caching_OF), Caching_OF.AIRLINE_LIST)] == null)
            {
                Caching.CatchStaticData(Caching_OF.AIRLINE_LIST);
            }
            Airlines = (System.Collections.Generic.Dictionary<string, Airline_Dictionary>)HttpRuntime.Cache[Enum.GetName(typeof(Caching_OF), Caching_OF.AIRLINE_LIST)];

            //}
            return Airlines;
        }
        public Airline_Dictionary() { }

        public Airline_Dictionary(SerializationInfo info, StreamingContext context)
        {

            AirlineName = info.GetString("AirlineName");
            AirlineCode = info.GetString("AirlineCode");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("AirlineName", AirlineName);
            info.AddValue("AirlineCode", AirlineCode);
        }
    }
}