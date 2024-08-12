using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelSite.Models
{
    
    public class Itineraries
    {
        //[XmlElement("Itinerary")]
        public List<Itinerary> Items { get; set; }
        public string errorMessage { get; set; }
    }
    public class BaseItinerary
    {
        public List<Itinerary> Items { get; set; }
        public string errorMessage { get; set; }
    }


    public class Itinerary
    {
        private double _basefare = 0;
        public double BaseFare
        {
            get
            {
                return _basefare;
            }
            set { _basefare = value; }
        }
        private double _taxes = 0;

        public double Taxes
        {
            get
            {

                return _taxes;
            }
            set { _taxes = value; }

        }
        private double _totalPrice = 0;
        public double TotalPrice
        {
            get
            {

                return _totalPrice;
            }
            set { _totalPrice = value; }
        }

        ///// <summary>
        ///// This property specially used by UAPI
        ///// </summary>
        //private double _approximateBasePrice = 0;
        //public double ApproximateBasePrice
        //{
        //    get
        //    {
        //        return _approximateBasePrice;
        //    }
        //    set
        //    {
        //        _approximateBasePrice = value;
        //    }

        //}

        ///// <summary>
        ///// This property specially used by UAPI
        ///// </summary>
        //private double _approximateTotalPrice = 0;
        //public double ApproximateTotalPrice
        //{
        //    get
        //    {
        //        return _approximateTotalPrice;
        //    }
        //    set
        //    {
        //        _approximateTotalPrice = value;
        //    }
        //}

        //private string _approximateCurrency = string.Empty;
        //public string ApproximateCurrency
        //{
        //    get { return _approximateCurrency; }
        //    set { _approximateCurrency = value; }
        //}
        //public string ApproximateCurrencySymble
        //{
        //    get; set;
        //}

        //private CurrencyExchange _currencyExchnage = new CurrencyExchange();
        //public CurrencyExchange CurrencyExchange
        //{
        //    get { return _currencyExchnage; }
        //    set { _currencyExchnage = value; }
        //}


        private double _markUp = 0;
        public double MarkUp
        {
            get
            {

                return _markUp;
            }
            set { _markUp = value; }

        }
        private double _commission = 0;
        public double Commission
        {
            get
            {
                return _commission;
            }
            set { }
        }
        private double _safi = 0;
        public double Safi
        {
            get
            {

                return _safi;
            }
            set { }
        }
        private double _grandtotal = 0;
        public double GrandTotal
        {
            get
            {

                return _grandtotal;
            }
            set { _grandtotal = value; }
        }
        private string _currency = string.Empty;
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        private string _fareType = string.Empty;
        public string FareType
        {
            get { return _fareType; }
            set { _fareType = value; }
        }
        private int _indexNumber = 0;
        public int IndexNumber
        {
            get { return _indexNumber; }
            set { _indexNumber = value; }
        }
        private string _provider = string.Empty;
        public string Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }
        private string _valCarrier = string.Empty;
        public string ValCarrier
        {
            get { return _valCarrier; }
            set { _valCarrier = value; }
        }
        private string _lastTicketingDate;
        public string LastTicketingDate
        {
            get { return _lastTicketingDate; }
            set { _lastTicketingDate = value; }
        }

        private string _pcc;
        public string PCC
        {
            get { return _pcc; }
            set { _pcc = value; }
        }
        private string _offerType = "BOOK";
        public string OfferType
        {
            get { return _offerType; }
            set { _offerType = value; }
        }

        private AdultDetails _adult = new AdultDetails();
        public AdultDetails AdultInfo
        {
            get { return _adult; }
            set { _adult = value; }
        }
        private ChildDetails _child = new ChildDetails();
        public ChildDetails ChildInfo
        {
            get { return _child; }
            set { _child = value; }
        }
        private InfantDetails _infant = new InfantDetails();
        public InfantDetails InfantInfo
        {
            get { return _infant; }
            set { _infant = value; }
        }

        private InfantDetails _infantWithSeat = new InfantDetails();
        public InfantDetails InfantInfoWithSeat
        {
            get { return _infantWithSeat; }
            set { _infantWithSeat = value; }
        }

        private List<FareBasisCodes> _fareBasisCodes = new List<FareBasisCodes>();
        public List<FareBasisCodes> FareBasisCodes
        {
            get { return _fareBasisCodes; }
        }
        private List<Sector> _sectors = new List<Sector>();
        public List<Sector> Sectors
        {
            get { return _sectors; }
            set { _sectors = value; }
        }

        private string _key = string.Empty;
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private string _Uid = string.Empty;
        public string Uid
        {
            get { return _Uid; }
            set { _Uid = value; }
        }

        private string _KeyPt = string.Empty;
        public string KeyPt
        {
            get { return _KeyPt; }
            set { _KeyPt = value; }

        }


        private string _warnings;


        public string Warnings { get { return _warnings; } set { _warnings = value; } }

        public string Islcc { get; set; }
        public string url { get; set; }

        public Itinerary() { }



    }


    public class AdultDetails
    {
        private int _noAdult = 0;
        public int NoAdult
        {
            get { return _noAdult; }
            set { _noAdult = value; }
        }
        private double _adTax = 0;
        public double AdTax
        {
            get { return _adTax; }
            set { _adTax = value; }
        }
        private double _adtBFare = 0;
        public double AdtBFare
        {
            get { return _adtBFare; }
            set { _adtBFare = value; }
        }
        private double _markUp = 0;
        public double MarkUp
        {
            get { return _markUp; }
            set { _markUp = value; }
        }
        private double _commission = 0;
        public double Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }
        private double _safi = 0;
        public double Safi
        {
            get { return _safi; }
            set { _safi = value; }
        }

        public AdultDetails() { }


    }


    public class ChildDetails
    {
        private int _noChild = 0;
        public int NoChild
        {
            get { return _noChild; }
            set { _noChild = value; }
        }
        private double _chTax = 0;
        public double CHTax
        {
            get { return _chTax; }
            set { _chTax = value; }
        }
        private double _chdBFare = 0;
        public double ChdBFare
        {
            get { return _chdBFare; }
            set { _chdBFare = value; }
        }
        private double _markUp = 0;
        public double MarkUp
        {
            get { return _markUp; }
            set { _markUp = value; }
        }
        private double _commission = 0;
        public double Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }
        private double _safi = 0;
        public double Safi
        {
            get { return _safi; }
            set { _safi = value; }
        }

        public ChildDetails() { }


    }


    public class InfantDetails
    {
        private int _noInfant = 0;
        public int NoInfant
        {
            get { return _noInfant; }
            set { _noInfant = value; }
        }
        private double _inTax = 0;
        public double InTax
        {
            get { return _inTax; }
            set { _inTax = value; }
        }
        private double _infBFare = 0;
        public double InfBFare
        {
            get { return _infBFare; }
            set { _infBFare = value; }
        }
        private double _markUp = 0;
        public double MarkUp
        {
            get { return _markUp; }
            set { _markUp = value; }
        }
        private double _commission = 0;
        public double Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }
        private double _safi = 0;
        public double Safi
        {
            get { return _safi; }
            set { _safi = value; }
        }

        public InfantDetails() { }


    }



    public class FareBasisCodes
    {
        private string _fareBasis = string.Empty;
        public string FareBasis
        {
            get { return _fareBasis; }
            set { _fareBasis = value; }
        }
        private string _airline = string.Empty;
        public string Airline
        {
            get { return _airline; }
            set { _airline = value; }
        }
        private string _paxType = string.Empty;
        public string PaxType
        {
            get { return _paxType; }
            set { _paxType = value; }
        }
        private string _origin = string.Empty;
        public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        private string _destination = string.Empty;
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        private string _fareRst = string.Empty;
        public string FareRst
        {
            get { return _fareRst; }
            set { _fareRst = value; }
        }

        public FareBasisCodes() { }


    }



    public class Baggage_Info
    {
        private string _kgs = null;
        public string Kgs
        {
            get { return _kgs; }
            set { _kgs = value; }
        }

        private string _pieces = null;
        public string Pieces
        {
            get { return _pieces; }
            set { _pieces = value; }
        }

        private double _price = 0;

        public double Price
        {
            get
            {

                return this._price;
            }

            set { this._price = value; }

        }

        private string _description = string.Empty;

        public string Description
        {
            get
            {

                return this._description;
            }

            set { this._description = value; }

        }

    }



}


public class CabinClass
{
    private string _cabinClassCode;
    public string Code
    {
        get { return _cabinClassCode; }
        set { _cabinClassCode = value; }
    }
    private string _cabinClassName;
    public string Name
    {
        get { return _cabinClassName; }
        set { _cabinClassName = value; }
    }

}


public class Sector
{
    private string _airchange;
    public string AirChange
    {
        get { return _airchange; }
        set { _airchange = value; }
    }
    private string _airV = string.Empty;
    public string AirV
    {
        get { return _airV; }

        set
        {
            _airV = value;
            _airV = _airV.Trim().ToUpper();


            //if (!String.IsNullOrEmpty(_airV))
            //{

            //    if (AllCaching.FilterAirline(_airV).ContainsKey(_airV))
            //    {
            //        _airlineName = AllCaching.FilterAirline(_airV)[_airV].AirlineName;
            //    }
            //}
        }
    }
    private string _airlineName = string.Empty;
    public string AirlineName
    {
        get { return _airlineName; }
        set { _airlineName = value; }
    }

    private string _airlineLogoPath = string.Empty;
    public string AirlineLogoPath
    {
        get { return _airlineLogoPath; }
        set { _airlineLogoPath = value; }
    }
    private string _class = string.Empty;
    public string Class
    {
        get { return _class; }
        set { _class = value; }
    }
    private CabinClass _cabinClass = new CabinClass();
    public CabinClass CabinClass
    {
        get { return _cabinClass; }
        set { _cabinClass = value; }

    }
    private int _noSeats = 0;
    public int NoSeats
    {
        get { return _noSeats; }
        set { _noSeats = value; }
    }
    private string _fltNum = string.Empty;
    public string FltNum
    {
        get { return _fltNum; }
        set { _fltNum = value; }
    }
    private Departure _secdeparture = new Departure();
    public Departure Departure
    {
        get { return _secdeparture; }
        set { _secdeparture = value; }

    }
    private Arrival _secarrival = new Arrival();
    public Arrival Arrival
    {
        get { return _secarrival; }
        set { _secarrival = value; }

    }
    private string _equipType = string.Empty;
    public string EquipType
    {
        get { return _equipType; }
        set { _equipType = value; }
    }
    private string _elapsedTime;
    public string ElapsedTime
    {
        get { return _elapsedTime; }
        set { _elapsedTime = value; }
    }
    private string _actualTime;
    public string ActualTime
    {
        get { return _actualTime; }
        set { _actualTime = value; }
    }
    private int _techStopOver = 0;
    public int TechStopOver
    {
        get { return _techStopOver; }
        set { _techStopOver = value; }
    }
    private string _status = string.Empty;
    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    private bool _isReturn = false;
    public bool IsReturn
    {
        get { return _isReturn; }
        set { _isReturn = value; }
    }
    private string _optrCarrier = string.Empty;
    public string OptrCarrier
    {
        get { return _optrCarrier; }
        set { _optrCarrier = value; }
    }
    private string _optrCarrierDes = string.Empty;
    public string OptrCarrierDes
    {
        get { return _optrCarrierDes; }
        set { _optrCarrierDes = value; }
    }
    private string _mrktCarrier = string.Empty;
    public string MrktCarrier
    {
        get { return _mrktCarrier; }
        set { _mrktCarrier = value; }
    }
    private string _mrktCarrierDes = string.Empty;
    public string MrktCarrierDes
    {
        get { return _mrktCarrierDes; }
        set { _mrktCarrierDes = value; }
    }
    private string _baggageInfo = string.Empty;
    public string BaggageInfo
    {
        get { return _baggageInfo; }
        set { _baggageInfo = value; }
    }

    Baggage_Info _baggage_Info = new Baggage_Info();
    public Baggage_Info Baggage_Info
    {
        get { return _baggage_Info; }
        set { _baggage_Info = value; }

    }

    private string _transitTime = string.Empty;
    public string TransitTime
    {
        get { return _transitTime; }
        set { _transitTime = value; }
    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _key = string.Empty;
    public string Key
    {
        get { return _key; }
        set { _key = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _distance = string.Empty;
    public string Distance
    {
        get { return _distance; }
        set { _distance = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _eTicket = string.Empty;
    public string ETicket
    {
        get { return _eTicket; }
        set { _eTicket = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _changeOfPlane = string.Empty;
    public string ChangeOfPlane
    {
        get { return _changeOfPlane; }
        set { _changeOfPlane = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _participantLevel = string.Empty;
    public string ParticipantLevel
    {
        get { return _participantLevel; }
        set { _participantLevel = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private bool _optionalServicesIndicator = false;
    public bool OptionalServicesIndicator
    {
        get { return _optionalServicesIndicator; }
        set { _optionalServicesIndicator = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _availabilitySource = string.Empty;
    public string AvailabilitySource
    {
        get { return _availabilitySource; }
        set { _availabilitySource = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _group = string.Empty;
    public string Group
    {
        get { return _group; }
        set { _group = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _linkAvailability = string.Empty;
    public string LinkAvailability
    {
        get { return _linkAvailability; }
        set { _linkAvailability = value; }

    }

    /// <summary>
    /// This property specially used by UAPI
    /// </summary>
    private string _polledAvailabilityOption = string.Empty;
    public string PolledAvailabilityOption
    {
        get { return _polledAvailabilityOption; }
        set { _polledAvailabilityOption = value; }

    }

    private string _bookingCodeInfo = string.Empty;
    public string BookingCodeInfo
    {
        get { return _bookingCodeInfo; }
        set { _bookingCodeInfo = value; }

    }

    public Sector() { }
}


public class Departure
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
    private string _terminal;
    public string Terminal
    {

        get { return _terminal; }
        set { _terminal = value; }
    }
    private string _date;
    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }
    private string _time;
    public string Time
    {

        get { return _time; }
        set { _time = value; }
    }
    public string Day { get; set; }

    private string _dateTimeStamp;
    public string DateTimeStamp
    {

        get { return _dateTimeStamp; }
        set { _dateTimeStamp = value; }
    }
}


public class Arrival
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
    private string _terminal;
    public string Terminal
    {
        get { return _terminal; }
        set { _terminal = value; }
    }
    private string _date;
    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }
    private string _time;
    public string Time
    {
        get { return _time; }
        set { _time = value; }
    }
    public string Day { set; get; }

    private string _dateTimeStamp;
    public string DateTimeStamp
    {

        get { return _dateTimeStamp; }
        set { _dateTimeStamp = value; }
    }
}


public class MarketingCarrier
{

    public string MktCarrierCode;
    private string _mrktCarrierDes;

    public string MrktCarrierDes
    {
        get { return _mrktCarrierDes; }
        set { _mrktCarrierDes = value; }
    }
}


public class OperatingCarrier
{

    public string OptrCarrierCode;
    private string _optrCarrierDes;

    public string OptrCarrierDes
    {
        get { return _optrCarrierDes; }
        set { _optrCarrierDes = value; }
    }
}

[Serializable]
public class TransitTime
{

    public string TimeDes;
    private string _time;

    public string Time
    {
        get { return _time; }
        set
        {
            _time = value;
        }
    }

}


public class AdultDetails
{
    private int _noAdult = 0;
    public int NoAdult
    {
        get { return _noAdult; }
        set { _noAdult = value; }
    }
    private double _adTax = 0;
    public double AdTax
    {
        get { return _adTax; }
        set { _adTax = value; }
    }
    private double _adtBFare = 0;
    public double AdtBFare
    {
        get { return _adtBFare; }
        set { _adtBFare = value; }
    }
    private double _markUp = 0;
    public double MarkUp
    {
        get { return _markUp; }
        set { _markUp = value; }
    }
    private double _commission = 0;
    public double Commission
    {
        get { return _commission; }
        set { _commission = value; }
    }
    private double _safi = 0;
    public double Safi
    {
        get { return _safi; }
        set { _safi = value; }
    }


}


public class ChildDetails
{
    private int _noChild = 0;
    public int NoChild
    {
        get { return _noChild; }
        set { _noChild = value; }
    }
    private double _chTax = 0;
    public double CHTax
    {
        get { return _chTax; }
        set { _chTax = value; }
    }
    private double _chdBFare = 0;
    public double ChdBFare
    {
        get { return _chdBFare; }
        set { _chdBFare = value; }
    }
    private double _markUp = 0;
    public double MarkUp
    {
        get { return _markUp; }
        set { _markUp = value; }
    }
    private double _commission = 0;
    public double Commission
    {
        get { return _commission; }
        set { _commission = value; }
    }
    private double _safi = 0;
    public double Safi
    {
        get { return _safi; }
        set { _safi = value; }
    }

    public ChildDetails() { }


}


public class InfantDetails
{
    private int _noInfant = 0;
    public int NoInfant
    {
        get { return _noInfant; }
        set { _noInfant = value; }
    }
    private double _inTax = 0;
    public double InTax
    {
        get { return _inTax; }
        set { _inTax = value; }
    }
    private double _infBFare = 0;
    public double InfBFare
    {
        get { return _infBFare; }
        set { _infBFare = value; }
    }
    private double _markUp = 0;
    public double MarkUp
    {
        get { return _markUp; }
        set { _markUp = value; }
    }
    private double _commission = 0;
    public double Commission
    {
        get { return _commission; }
        set { _commission = value; }
    }
    private double _safi = 0;
    public double Safi
    {
        get { return _safi; }
        set { _safi = value; }
    }

    public InfantDetails() { }


}



public class FareBasisCodes
{
    private string _fareBasis = string.Empty;
    public string FareBasis
    {
        get { return _fareBasis; }
        set { _fareBasis = value; }
    }
    private string _airline = string.Empty;
    public string Airline
    {
        get { return _airline; }
        set { _airline = value; }
    }
    private string _paxType = string.Empty;
    public string PaxType
    {
        get { return _paxType; }
        set { _paxType = value; }
    }
    private string _origin = string.Empty;
    public string Origin
    {
        get { return _origin; }
        set { _origin = value; }
    }
    private string _destination = string.Empty;
    public string Destination
    {
        get { return _destination; }
        set { _destination = value; }
    }
    private string _fareRst = string.Empty;
    public string FareRst
    {
        get { return _fareRst; }
        set { _fareRst = value; }
    }

    public FareBasisCodes() { }


}



public class Baggage_Info
{
    private string _kgs = null;
    //  [XmlElement("Kgs", IsNullable = false,Namespace = "")]
    public string Kgs
    {
        get { return _kgs; }
        set { _kgs = value; }
    }

    private string _pieces = null;
    // [XmlElement("Kgs", IsNullable = false, Namespace = "")]
    public string Pieces
    {
        get { return _pieces; }
        set { _pieces = value; }
    }

    private double _price = 0;

    public double Price
    {
        get
        {

            return this._price;
        }

        set { this._price = value; }

    }

    private string _description = string.Empty;

    public string Description
    {
        get
        {

            return this._description;
        }

        set { this._description = value; }

    }



    public Baggage_Info() { }

}


public class CurrencyExchange
{
    private string _baseCurrency = string.Empty;


    public string BaseCurrency
    {
        get { return _baseCurrency; }
        set { _baseCurrency = value; }
    }

    private string _requestedCurrency = string.Empty;

    public string RequestedCurrency
    {
        get { return _requestedCurrency; }
        set { _requestedCurrency = value; }
    }

    private Decimal _exchangeRate = 1;

    public Decimal ExchangeRate
    {
        get { return _exchangeRate; }
        set { _exchangeRate = value; }
    }




}