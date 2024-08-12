using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class Paxes
    {
        public List<Pax> Items { get; set; }
    }
    [Serializable]
    public class Pax
    {
        public Pax()
        { 
        
        }
        public Pax(int _paxID, string _paxType)
        {
            PaxType = _paxType;
            PaxId = _paxID;
        }
        public Pax(int _paxID, string _paxType, string _Title, string _FirstName, string _LastName, string _Gender, string _Seat, string _Meal, DateTime _DOB)
        {
            PaxType = _paxType;
            PaxId = _paxID;
            Title = _Title;
            FirstName = _FirstName;
            LastName = _LastName;
            Gender = _Gender;
            Seat = _Seat;
            Meal = _Meal;
            DOB = _DOB;
        }
        public string PaxType { set; get; }
        public int PaxId { set; get; }
        public string Title { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Gender { set; get; }
        public string Seat { set; get; }
        public string Meal { set; get; }
        public string SeatName { set; get; }
        public string MealName { set; get; }
        public string FreqFlyerAirline { set; get; }
        public string FreqFlyerNo { set; get; }        
        public DateTime DOB { set; get; }

        public string BaggageCode { set; get; }
        public string PassportNo { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpiryDate { set; get; }
        public string CountryCode { set; get; }
        public string IssueCity { set; get; }
    }


    [Serializable]
    public class Passenger : ISerializable
    {
        private string _paxType = string.Empty;
        public string PassengerType
        {
            get { return _paxType; }
            set { _paxType = value; }
        }
        private int _noPax = 0;
        public int NoOfPassenger
        {
            get { return _noPax; }
            set { _noPax = value; }
        }

        private double _baseFare = 0;
        public double BaseFare
        {
            get { return _baseFare; }
            set { _baseFare = value; }
        }

        private double _taxes = 0;
        public double Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
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

        public Passenger() { }

        public Passenger(SerializationInfo info, StreamingContext context)
        {
            PassengerType = info.GetString("PassengerType");
            NoOfPassenger = info.GetInt16("NoOfPassenger");
            BaseFare = info.GetDouble("BaseFare");
            Taxes = info.GetDouble("Taxes");
            MarkUp = info.GetDouble("MarkUp");
            Commission = info.GetDouble("Commission");
            Safi = info.GetDouble("Safi");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PassengerType", PassengerType);
            info.AddValue("NoOfPassenger", NoOfPassenger);
            info.AddValue("BaseFare", BaseFare);
            info.AddValue("Taxes", Taxes);
            info.AddValue("MarkUp", MarkUp);
            info.AddValue("Commission", Commission);
            info.AddValue("Safi", Safi);
        }
    }


    [Serializable]
    public class PassengerDetail : ISerializable
    {
        private string _paxType = string.Empty;
        public string PassengerType
        {
            get { return _paxType; }
            set { _paxType = value; }
        }

        private string _paxTitle = string.Empty;
        public string Title
        {
            get { return _paxTitle; }
            set { _paxTitle = value; }
        }


        private string _paxFirstName = string.Empty;
        public string FirstName
        {
            get { return _paxFirstName; }
            set { _paxFirstName = value; }
        }

        private string _paxLastName = string.Empty;
        public string LastName
        {
            get { return _paxLastName; }
            set { _paxLastName = value; }
        }

        private string _paxDOB = string.Empty;
        public string DOB
        {
            get { return _paxDOB; }
            set { _paxDOB = value; }
        }
        public PassengerDetail() { }
        public PassengerDetail(SerializationInfo info, StreamingContext context)
        {
            PassengerType = info.GetString("Title");
            PassengerType = info.GetString("PassengerType");
            PassengerType = info.GetString("FirstName");
            PassengerType = info.GetString("LastName");
            PassengerType = info.GetString("DOB");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", Title);
            info.AddValue("PassengerType", PassengerType);
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("DOB", DOB);


        }
    }
}
