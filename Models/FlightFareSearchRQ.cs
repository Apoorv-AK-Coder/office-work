using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace TravelSite.Models
{
    public class FlightFareSearchRQ : Company_Credential
    {
        public FlightFareSearchRQ()
        {
            _searchID = Guid.NewGuid().ToString();
        }
        private string _searchID = string.Empty;
        public string SearchID
        {
            get { return _searchID; }
            set { _searchID = value; }
        }
        private Trip_Type _tripType;
        public Trip_Type JourneyType
        {
            get { return _tripType; }
            set { _tripType = value; }
        }
        private Cabin_Class _cabinClass;
        public Cabin_Class CabinClass
        {
            get { return _cabinClass; }
            set { _cabinClass = value; }
        }
        private int _flexiSearch = 0;
        public int FlexiSearch
        {
            get { return _flexiSearch; }
            set { _flexiSearch = value; }
        }
        private bool _directFlight = false;
        public bool DirectFlight
        {
            get { return _directFlight; }
            set { _directFlight = value; }
        }
        private int _adults = 0;
        public int Adults
        {
            get { return _adults; }
            set { _adults = value; }
        }
        private int _children = 0;
        public int Children
        {
            get { return _children; }
            set { _children = value; }
        }
        //public int InfantsWithSeat { get; set; }
        private int _infants = 0;
        public int Infants
        {
            get { return _infants; }
            set { _infants = value; }
        }
        private int _infantsWithSeat = 0;
        public int InfantsWithSeat
        {
            get { return _infantsWithSeat; }
            set { _infantsWithSeat = value; }
        }
        private List<Segment> _segments = new List<Segment>();
        public List<Segment> Segments
        {
            get { return _segments; }
            set { _segments = value; }
        }
        private Airline _Airline = new Airline();
        public Airline Airline
        {
            get { return _Airline; }
            set { _Airline = value; }
        }
        //private List<Credential> _credential = new List<Credential>();
        //public List<Credential> Credentials
        //{
        //    get { return _credential; }

        //}

        //public void AddSegment(Segment _segment)
        //{
        //    _segments.Add(_segment);
        //}

        public static FlightFareSearchRQ Current()
        {
            FlightFareSearchRQ _rq = null;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session[HttpContext.Current.Session.SessionID] == null)
                {
                    _rq = new FlightFareSearchRQ();
                    HttpContext.Current.Session[HttpContext.Current.Session.SessionID] = _rq;

                }

                _rq = (FlightFareSearchRQ)HttpContext.Current.Session[HttpContext.Current.Session.SessionID];

            }
            return _rq;
        }

        public static FlightFareSearchRQ Current(FlightFareSearchRQ _rq)
        {

            if (HttpContext.Current != null)
            {
                HttpContext.Current.Session[HttpContext.Current.Session.SessionID] = _rq;
            }
            _rq = (FlightFareSearchRQ)HttpContext.Current.Session[HttpContext.Current.Session.SessionID];
            return _rq;
        }

        public bool Init_SearchRQ(XmlDocument _rq)
        {
            try
            {


                HttpContext.Current.Session[HttpContext.Current.Session.SessionID] = this;
                return true;
            }
            catch { return false; }
        }

        public bool Set_CabinClass(string _cabinClassCode)
        {
            _cabinClassCode = _cabinClassCode.Trim().ToUpper();
            bool setCabin = false;
            switch (_cabinClassCode)
            {
                case "Y":
                    _cabinClass = Cabin_Class.Economy;
                    setCabin = true;
                    break;
                case "W":
                    _cabinClass = Cabin_Class.PremiumEconomy;
                    setCabin = true;
                    break;

                case "C":
                case "B":
                    _cabinClass = Cabin_Class.Business;
                    setCabin = true;
                    break;
                case "F":
                    _cabinClass = Cabin_Class.First;
                    setCabin = true;
                    break;

            }
            return setCabin;

        }
        public string Get_CabinClass(Cabin_Class _cabin)
        {
            string _cabinCode = string.Empty;
            switch (_cabin)
            {
                case Cabin_Class.Economy:
                    _cabinCode = "Y";
                    break;
                case Cabin_Class.PremiumEconomy:
                    _cabinCode = "W";
                    break;

                case Cabin_Class.Business:
                    _cabinCode = "C";
                    break;
                case Cabin_Class.First:
                    _cabinCode = "F";
                    break;

            }
            return _cabinCode;

        }

        public string getJourneyType()
        {
            if (Trip_Type.Return_Trip == JourneyType)
                return "R";
            else if (Trip_Type.OneWay_Trip == JourneyType)
                return "O";
            else
                return "M";
        }
    }

    public class Segment
    {
        public Segment()
        { }
        public Segment(int _segmentID, string _origin, string _destination, string _Date)
        {
            _id = Convert.ToString(_segmentID);
            SetOrigin(_origin);
            SetDestination(_destination);
            _date = _Date;
        }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private Airport _origin = new Airport();
        public Airport Origin
        {
            get { return _origin; }
        }
        public void SetOrigin(string originCode)
        {
            if (originCode.Length == 3)
            {
                _origin.AirportCode = originCode;
            }
            else
            {
                int startIndex = originCode.LastIndexOf("[");
                string sub = originCode.Substring(startIndex + 1);
                if (sub.Length >= 3)
                {

                    _origin.AirportCode = sub.Substring(0, 3).ToUpper();
                }
                else { _origin.AirportCode = sub.ToUpper(); }

            }
        }
        private Airport _destination = new Airport();
        public Airport Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public void SetDestination(string destinationCode)
        {
            if (destinationCode.Length == 3)
            {
                _destination.AirportCode = destinationCode;
            }
            else
            {
                int startIndex = destinationCode.LastIndexOf("[");
                string sub = destinationCode.Substring(startIndex + 1);
                if (sub.Length >= 3)
                {

                    _destination.AirportCode = sub.Substring(0, 3).ToUpper();
                }
                else { _destination.AirportCode = sub.ToUpper(); }
            }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                if (string.IsNullOrEmpty(_date) || _date.Length < 10)
                {

                    throw new ArgumentException("Invalid Departure/Arrival Date : Departure/Arrival Date must be in 'dd/MM/yyyy' format");
                }

            }
        }
    }
}