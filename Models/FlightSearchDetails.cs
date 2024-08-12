using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelSite.Models
{
    public class FlightSearchDetails
    {

        public FlightSearchDetails()
        {
           
        }

        List<Segments> _segments = new List<Segments>();
        public List<Segments> segments
        {
            get { return _segments; }
            set { _segments = value; }
        }
        //public string uid { set; get; }        
        
       
        public string PreferedAirlines { set; get; }
        //public string Service { set; get; }
        public string cabinClass { set; get; }
       



        public string JourneyType { get; set; }

        public string searchId { get; set; }
        public string companyId { get; set; }
        //public string sourceMedia { get; set; }

        public string customerType { get; set; }
        private bool _alternateAirport = false;
        public bool alternateAirport
        {
            get { return _alternateAirport; }
            set { _alternateAirport = value; }
        }
        [Required(ErrorMessage = "journeyType is mandatory")]
        //public string journeyType { get; set; }
        private bool _direct = false;
        public bool directFlight
        {
            get { return _direct; }
            set { _direct = value; }
        }
        private bool _flexi = false;
        public bool flexi
        {
            get { return _flexi; }
            set { _flexi = value; }
        }
        private string _gds = string.Empty;
        public string gds
        {
            get { return _gds; }
            set { _gds = value; }
        }
        private bool _flexiFareType = false;
        public bool flexiType
        {
            get { return _flexiFareType; }
            set { _flexiFareType = value; }
        }

        public string currency { get; set; }
        public double maxAmount { get; set; }
        
        public string outboundClass { get; set; }
        public string inboundClass { get; set; }
        public string fareType { get; set; }
        public bool availableFare { get; set; }
        public bool refundableFare { get; set; }
        private string _preferedAirline = "ALL";
        public string preferedAirline
        {
            get { return _preferedAirline; }
            set { _preferedAirline = value; }
        }
        public PaxDetails paxDetails { get; set; }
        //public IList<Segment> segments { get; set; }
        public bool isCache { get; set; }


        //public class SearchRequest
        //{
        //    public string searchId { get; set; }

        //    [Required(ErrorMessage = "companyid is mandatory")]
        //    public string companyId { get; set; }
        //    public string sourceMedia { get; set; }

        //    public string customerType { get; set; }
        //    private bool _alternateAirport = false;
        //    public bool alternateAirport
        //    {
        //        get { return _alternateAirport; }
        //        set { _alternateAirport = value; }
        //    }
        //    [Required(ErrorMessage = "journeyType is mandatory")]
        //    public string journeyType { get; set; }
        //    private bool _direct = false;
        //    public bool directFlight
        //    {
        //        get { return _direct; }
        //        set { _direct = value; }
        //    }
        //    private bool _flexi = false;
        //    public bool flexi
        //    {
        //        get { return _flexi; }
        //        set { _flexi = value; }
        //    }
        //    private string _gds = string.Empty;
        //    public string gds
        //    {
        //        get { return _gds; }
        //        set { _gds = value; }
        //    }
        //    private bool _flexiFareType = false;
        //    public bool flexiType
        //    {
        //        get { return _flexiFareType; }
        //        set { _flexiFareType = value; }
        //    }

        //    public string currency { get; set; }
        //    public double maxAmount { get; set; }
        //    public string cabinClass { get; set; }
        //    public string outboundClass { get; set; }
        //    public string inboundClass { get; set; }
        //    public string fareType { get; set; }
        //    public bool availableFare { get; set; }
        //    public bool refundableFare { get; set; }
        //    private string _preferedAirline = "ALL";
        //    public string preferedAirline
        //    {
        //        get { return _preferedAirline; }
        //        set { _preferedAirline = value; }
        //    }
        //    public PaxDetails paxDetails { get; set; }
        //    public IList<Segment> segments { get; set; }
        //    public bool isCache { get; set; }

        //    //public static SearchRequest Current()
        //    //{
        //    //    SearchRequest _rq = null;
        //    //    if (HttpContext.Current != null)
        //    //    {
        //    //        if (HttpContext.Current.Session[HttpContext.Current.Session.SessionID] == null)
        //    //        {
        //    //            _rq = new SearchRequest();
        //    //            HttpContext.Current.Session[HttpContext.Current.Session.SessionID] = _rq;

        //    //        }

        //    //        _rq = (SearchRequest)HttpContext.Current.Session[HttpContext.Current.Session.SessionID];

        //    //    }
        //    //    return _rq;
        //    //}
        //}
        public class PaxDetails
        {
            private int _adult = 0;
            public int adults
            {
                get { return _adult; }
                set { _adult = value; }
            }
            private int _youth = 0;
            public int youth
            {
                get { return _youth; }
                set { _youth = value; }
            }
            private int _child = 0;
            public int children
            {
                get { return _child; }
                set { _child = value; }
            }
            private int _infant = 0;
            public int infants
            {
                get { return _infant; }
                set { _infant = value; }
            }
            private int _infantOnSeat = 0;
            public int infantOnSeat
            {
                get { return _infantOnSeat; }
                set { _infantOnSeat = value; }
            }

        }

    }

    //public class Segment
    //{
    //    int _segId;
    //    string hdestfrom;
    //    string hdestto;
    //    public string origin { get; set; }
    //    public string destination { get; set; }
    //    public string originType { get; set; }
    //    public string destinationType { get; set; }
    //    public string date
    //    { get; set; }
    //    public int SegId
    //    {
    //        get { return _segId; }
    //        set { _segId = value; }
    //    }
    //    public string from
    //    {
    //        get { return hdestfrom; }
    //        set { hdestfrom = value; }
    //    }
    //    public string to
    //    {
    //        get { return hdestto; }
    //        set { hdestto = value; }
    //    }

    //    public string time { get; set; }
    //}
    
}
