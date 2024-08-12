using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SagePay.IntegrationKit.Messages;

namespace TravelSite.Models
{
    [Serializable]
    public class SearchParamEL1
    {
        private SearchParamEL1()
        {
        }
        int _adult;
        int _child;
        int _infant;
        bool _isReturn;
        bool _isCalendar;
        string _prefAir;
        string _class;
        string _fareType;
        string _searchType;
        bool _nonStop;
        string _sourceMedia;
        string _companyName;
        string _redirectFrom;
        string _multiCity;
        string _bookingSession;
        string _bookingRef;
        string _xmlItinerary;
        string _xmlRequest;
        string _xmlPaxDetail;
        bool _bookingMail = false;
        bool _bookingFirm = false;
        string _pnr;
        List<Segments> _segments = new List<Segments>();
        Itinerary _itinerary = new Itinerary();
        Contact _contactDetail = new Contact();
        List<Pax> _paxes = new List<Pax>();
       
        public int Adult
        {
            get { return _adult; }
            set { _adult = value; }
        }
        public int Child
        {
            get { return _child; }
            set { _child = value; }
        }
        public int Infant
        {
            get { return _infant; }
            set { _infant = value; }
        }
        public bool IsReturn
        {
            get { return _isReturn; }
            set { _isReturn = value; }
        }
        public bool IsCalendar
        {
            get { return _isCalendar; }
            set { _isCalendar = value; }
        }
        public string PreferedAirlines
        {
            get { return _prefAir; }
            set { _prefAir = value; }
        }
        public string Service
        {
            get { return _class; }
            set { _class = value; }
        }

        public string BookingRef
        {
            get { return _bookingRef; }
            set { _bookingRef = value; }
        }
        public string BookingSession
        {
            get { return _bookingSession; }
            set { _bookingSession = value; }
        }
        public string fareType
        {
            get { return _fareType; }
            set { _fareType = value; }
        }
        public string searchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }
        public bool NonStop
        {
            get { return _nonStop; }
            set { _nonStop = value; }
        }
        public string sourceMedia
        {
            get { return _sourceMedia; }
            set { _sourceMedia = value; }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public string RedirectFrom
        {
            get { return _redirectFrom; }
            set { _redirectFrom = value; }
        }
        public string XMLItinerary
        {
            get { return _xmlItinerary; }
            set { _xmlItinerary = value; }
        }
        public string XMLRequest
        {
            get { return _xmlRequest; }
            set { _xmlRequest = value; }
        }
        public string XMLPaxDetail
        {
            get { return _xmlPaxDetail; }
            set { _xmlPaxDetail = value; }
        }
        public bool BookingMail
        {
            get { return _bookingMail; }
            set { _bookingMail = value; }
        }
        public bool BookingFirm
        {
            get { return _bookingFirm; }
            set { _bookingFirm = value; }
        }
        public string PNR
        {
            get { return _pnr; }
            set { _pnr = value; }
        }
        public string MultiCity
        {
            get { return _multiCity; }
            set { _multiCity = value; }
        }

        public ENum.JourneyType JourneyType { get; set; }
        public List<Segments> Segments
        {
            get { return _segments; }
            set { _segments = value; }
        }
        public Itinerary Itinerary
        {
            get { return _itinerary; }
            set { _itinerary = value; }
        }
        public List<Pax> Paxes
        {
            get { return _paxes; }
            set { _paxes = value; }
        }
        public Contact ContactDetail
        {
            get { return _contactDetail; }
            set { _contactDetail = value; }
        }
        public static SearchParamEL1 Current(string uniCode)
        {
            SearchParamEL1 _objSearch = null;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["SearchParam#" + uniCode] != null)
                {
                    _objSearch = (SearchParamEL1)HttpContext.Current.Session["SearchParam#" + uniCode];
                }
            }
            return _objSearch;
        }
        public static SearchParamEL1 SetCurrent(string uniCode)
        {
            SearchParamEL1 _objSearch = new SearchParamEL1();
            HttpContext.Current.Session["SearchParam#" + uniCode] = _objSearch;
            return _objSearch;
        }

        //public IDirectPaymentResult PaymentResult
        //{
        //    get { return _payResult; }
        //    set { _payResult = value; }
        //}

        //public SagePayDirectIntegration PaymentDetail
        //{
        //    get { return _paymentDetail; }
        //    set { _paymentDetail = value; }
        //}

    }

    [Serializable]
    public class Segments
    {
        string _origin;
        string _destination;
        string _destType;
        string _originType;
        string _date;
        int _segId;
        string hdestfrom;
        string hdestto;
        public string origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        public string destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public string destinationType
        {
            get { return _destType; }
            set { _destType = value; }
        }
        public string originType
        {
            get { return _originType; }
            set { _originType = value; }
        }

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
       // public int SegId
       // {
       //     get { return _segId; }
       //     set { _segId = value; }
       // }
       //public string  from
       // {
       //     get { return hdestfrom; }
       //     set { hdestfrom = value; }
       // }
       //public string to
       //{
       //    get { return hdestto; }
       //    set { hdestto = value; }
       //}
    }


}
