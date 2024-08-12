using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelSite.Models
{

    //[Serializable]
    ////[XmlType(TypeName = "Sector")]
    //public class Sector
    //{
    //    private string _airV = string.Empty;
    //    public string AirV
    //    {
    //        get { return _airV; }

    //        set
    //        {
    //            _airV = value;
    //            _airV = _airV.Trim().ToUpper();


    //            if (!String.IsNullOrEmpty(_airV))
    //            {
    //                System.Collections.Generic.Dictionary<string, Airline_Dictionary> oAirlines = Airline_Dictionary.Current();
    //                if (oAirlines.ContainsKey(_airV))
    //                {
    //                    _airlineName = ((Airline_Dictionary)oAirlines[_airV]).AirlineName;
    //                }
    //            }
    //        }
    //    }
    //    private string _airlineName = string.Empty;
    //    public string AirlineName
    //    {
    //        get { return _airlineName; }
    //        set { _airlineName = value; }
    //    }

    //    private string _airlineLogoPath = string.Empty;
    //    public string AirlineLogoPath
    //    {
    //        get { return _airlineLogoPath; }
    //        set { _airlineLogoPath = value; }
    //    }
    //    private string _class = string.Empty;
    //    public string Class
    //    {
    //        get { return _class; }
    //        set { _class = value; }
    //    }
    //    private CabinClass _cabinClass = new CabinClass();
    //    public CabinClass CabinClass
    //    {
    //        get { return _cabinClass; }
    //        set { _cabinClass = value; }

    //    }
    //    private int _noSeats = 0;
    //    public int NoSeats
    //    {
    //        get { return _noSeats; }
    //        set { _noSeats = value; }
    //    }
    //    private string _fltNum = string.Empty;
    //    public string FltNum
    //    {
    //        get { return _fltNum; }
    //        set { _fltNum = value; }
    //    }
    //    private Departure _secdeparture = new Departure();
    //    public Departure Departure
    //    {
    //        get { return _secdeparture; }
    //        set { _secdeparture = value; }

    //    }
    //    private Arrival _secarrival = new Arrival();
    //    public Arrival Arrival
    //    {
    //        get { return _secarrival; }
    //        set { _secarrival = value; }

    //    }
    //    private string _equipType = string.Empty;
    //    public string EquipType
    //    {
    //        get { return _equipType; }
    //        set { _equipType = value; }
    //    }
    //    private string _elapsedTime;
    //    public string ElapsedTime
    //    {
    //        get { return _elapsedTime; }
    //        set { _elapsedTime = value; }
    //    }
    //    private string _actualTime;
    //    public string ActualTime
    //    {
    //        get { return _actualTime; }
    //        set { _actualTime = value; }
    //    }
    //    private int _techStopOver = 0;
    //    public int TechStopOver
    //    {
    //        get { return _techStopOver; }
    //        set { _techStopOver = value; }
    //    }
    //    private string _status = string.Empty;
    //    public string Status
    //    {
    //        get { return _status; }
    //        set { _status = value; }
    //    }
    //    private bool _isReturn = false;
    //    public bool IsReturn
    //    {
    //        get { return _isReturn; }
    //        set { _isReturn = value; }
    //    }
    //    private string _optrCarrier = string.Empty;
    //    public string OptrCarrier
    //    {
    //        get { return _optrCarrier; }
    //        set { _optrCarrier = value; }
    //    }
    //    private string _optrCarrierDes = string.Empty;
    //    public string OptrCarrierDes
    //    {
    //        get { return _optrCarrierDes; }
    //        set { _optrCarrierDes = value; }
    //    }
    //    private string _mrktCarrier = string.Empty;
    //    public string MrktCarrier
    //    {
    //        get { return _mrktCarrier; }
    //        set { _mrktCarrier = value; }
    //    }
    //    private string _mrktCarrierDes = string.Empty;
    //    public string MrktCarrierDes
    //    {
    //        get { return _mrktCarrierDes; }
    //        set { _mrktCarrierDes = value; }
    //    }
    //    private string _baggageInfo = string.Empty;
    //    public string BaggageInfo
    //    {
    //        get { return _baggageInfo; }
    //        set { _baggageInfo = value; }
    //    }

    //    Baggage_Info _baggage_Info = new Baggage_Info();
    //    public Baggage_Info Baggage_Info
    //    {
    //        get { return _baggage_Info; }
    //        set { _baggage_Info = value; }

    //    }

    //    private string _transitTime = string.Empty;
    //    public string TransitTime
    //    {
    //        get { return _transitTime; }
    //        set { _transitTime = value; }
    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _key = string.Empty;
    //    public string Key
    //    {
    //        get { return _key; }
    //        set { _key = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _distance = string.Empty;
    //    public string Distance
    //    {
    //        get { return _distance; }
    //        set { _distance = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _eTicket = string.Empty;
    //    public string ETicket
    //    {
    //        get { return _eTicket; }
    //        set { _eTicket = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _changeOfPlane = string.Empty;
    //    public string ChangeOfPlane
    //    {
    //        get { return _changeOfPlane; }
    //        set { _changeOfPlane = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _participantLevel = string.Empty;
    //    public string ParticipantLevel
    //    {
    //        get { return _participantLevel; }
    //        set { _participantLevel = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private bool _optionalServicesIndicator = false;
    //    public bool OptionalServicesIndicator
    //    {
    //        get { return _optionalServicesIndicator; }
    //        set { _optionalServicesIndicator = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _availabilitySource = string.Empty;
    //    public string AvailabilitySource
    //    {
    //        get { return _availabilitySource; }
    //        set { _availabilitySource = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _group = string.Empty;
    //    public string Group
    //    {
    //        get { return _group; }
    //        set { _group = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _linkAvailability = string.Empty;
    //    public string LinkAvailability
    //    {
    //        get { return _linkAvailability; }
    //        set { _linkAvailability = value; }

    //    }

    //    /// <summary>
    //    /// This property specially used by UAPI
    //    /// </summary>
    //    private string _polledAvailabilityOption = string.Empty;
    //    public string PolledAvailabilityOption
    //    {
    //        get { return _polledAvailabilityOption; }
    //        set { _polledAvailabilityOption = value; }

    //    }

    //    private string _bookingCodeInfo = string.Empty;
    //    public string BookingCodeInfo
    //    {
    //        get { return _bookingCodeInfo; }
    //        set { _bookingCodeInfo = value; }

    //    }

    //    public Sector() { }
    //}
    
    //[Serializable]
    //public class Departure
    //{
    //    private string _airportCode;
    //    public string AirportCode
    //    {

    //        get { return _airportCode; }
    //        set { _airportCode = value; }
    //    }
    //    private string _airportName;
    //    public string AirportName
    //    {
    //        get { return _airportName; }
    //        set { _airportName = value; }
    //    }
    //    private string _airportCityCode;
    //    public string AirportCityCode
    //    {
    //        get { return _airportCityCode; }
    //        set { _airportCityCode = value; }
    //    }
    //    private string _airportCityName;
    //    public string AirportCityName
    //    {
    //        get { return _airportCityName; }
    //        set { _airportCityName = value; }
    //    }
    //    private string _airportCountryCode;
    //    public string AirportCountryCode
    //    {
    //        get { return _airportCountryCode; }
    //        set { _airportCountryCode = value; }
    //    }
    //    private string _airportCountryName;
    //    public string AirportCountryName
    //    {
    //        get { return _airportCountryName; }
    //        set { _airportCountryName = value; }
    //    }
    //    private string _geoLocation;
    //    public string GeoLocation
    //    {
    //        get { return _geoLocation; }
    //        set { _geoLocation = value; }
    //    }
    //    private string _terminal;
    //    public string Terminal
    //    {

    //        get { return _terminal; }
    //        set { _terminal = value; }
    //    }
    //    private string _date;
    //    public string Date
    //    {
    //        get { return _date; }
    //        set { _date = value; }
    //    }
    //    private string _time;
    //    public string Time
    //    {

    //        get { return _time; }
    //        set { _time = value; }
    //    }
    //    public string Day { get; set; }
     
    //    private string _dateTimeStamp;
    //    public string DateTimeStamp
    //    {

    //        get { return _dateTimeStamp; }
    //        set { _dateTimeStamp = value; }
    //    }
    //}
    
    //[Serializable]
    //public class Arrival
    //{
    //    private string _airportCode;
    //    public string AirportCode
    //    {

    //        get { return _airportCode; }
    //        set { _airportCode = value; }
    //    }
    //    private string _airportName;
    //    public string AirportName
    //    {
    //        get { return _airportName; }
    //        set { _airportName = value; }
    //    }
    //    private string _airportCityCode;
    //    public string AirportCityCode
    //    {
    //        get { return _airportCityCode; }
    //        set { _airportCityCode = value; }
    //    }
    //    private string _airportCityName;
    //    public string AirportCityName
    //    {
    //        get { return _airportCityName; }
    //        set { _airportCityName = value; }
    //    }
    //    private string _airportCountryCode;
    //    public string AirportCountryCode
    //    {
    //        get { return _airportCountryCode; }
    //        set { _airportCountryCode = value; }
    //    }
    //    private string _airportCountryName;
    //    public string AirportCountryName
    //    {
    //        get { return _airportCountryName; }
    //        set { _airportCountryName = value; }
    //    }
    //    private string _geoLocation;
    //    public string GeoLocation
    //    {
    //        get { return _geoLocation; }
    //        set { _geoLocation = value; }
    //    }
    //    private string _terminal;
    //    public string Terminal
    //    {
    //        get { return _terminal; }
    //        set { _terminal = value; }
    //    }
    //    private string _date;
    //    public string Date
    //    {
    //        get { return _date; }
    //        set { _date = value; }
    //    }
    //    private string _time;
    //    public string Time
    //    {
    //        get { return _time; }
    //        set { _time = value; }
    //    }
    //    public string Day { set; get; }
       
    //    private string _dateTimeStamp;
    //    public string DateTimeStamp
    //    {

    //        get { return _dateTimeStamp; }
    //        set { _dateTimeStamp = value; }
    //    }
    //}

    //[Serializable]
    //public class MarketingCarrier
    //{
    //    [XmlText]
    //    public string MktCarrierCode;
    //    private string _mrktCarrierDes;
    //    [XmlAttribute(AttributeName = "MrktCarrierDes")]
    //    public string MrktCarrierDes
    //    {
    //        get { return _mrktCarrierDes; }
    //        set{_mrktCarrierDes = value;}
    //    }
    //}

    //[Serializable]
    //public class OperatingCarrier
    //{
    //    [XmlText]
    //    public string OptrCarrierCode;
    //    private string _optrCarrierDes;
    //    [XmlAttribute(AttributeName = "OptrCarrierDes")]
    //    public string OptrCarrierDes
    //    {
    //        get { return _optrCarrierDes; }
    //        set { _optrCarrierDes = value;}
    //    }
    //}
   
    //[Serializable]
    //public class TransitTime
    //{
    //    [XmlText]
    //    public string TimeDes;
    //    private string _time;
    //    [XmlAttribute(AttributeName = "time")]
    //    public string Time
    //    {
    //        get { return _time; }
    //        set
    //        {
    //            _time = value;
    //        }
    //    }

    //}
}
