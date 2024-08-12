using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using SagePay.IntegrationKit;
//using SagePay.IntegrationKit.Messages;


namespace TravelSite.Models
{
    public class SearchDetails
    {
        private SearchDetails()
        { }
        public static SearchDetails Current(string uniCode)
        {
            SearchDetails _objSearch = null;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["SearchParam#" + uniCode] != null)
                {
                    _objSearch = (SearchDetails)HttpContext.Current.Session["SearchParam#" + uniCode];
                }
            }
            return _objSearch;
        }
        public static SearchDetails SetCurrent(string uniCode)
        {
            SearchDetails _objSearch = new SearchDetails();
            HttpContext.Current.Session["SearchParam#" + uniCode] = _objSearch;
            _objSearch.Guid = uniCode;
            return _objSearch;
        }

        public FlightFareSearchRQ flightFareSearchRQ { get; set; }

        public void setSearchDetails(ref string _from, ref string _to, ref string _fromDate, ref string _toDate,
            Trip_Type TripType, ref string CabinClassCode, ref string prefAir, ref int _adults, ref int _childs,
            ref int _infants, ref int CalenderSearchDays, ref bool DirectFlight, ref string CompanyID, ref string CredentialID,
            ref string CredentialPwd, ref string CredentialType, ref int _infantsWithSeat)
        {
            FlightFareSearchRQ _searchRQ = new FlightFareSearchRQ();
            _searchRQ.Set_Company_Credential(CompanyID, CredentialID, CredentialPwd, CredentialType);

            #region Outbound
            _searchRQ.Segments.Add(new Segment(1, _from, _to, _fromDate));

            _searchRQ.JourneyType = TripType;
            #endregion

            #region Inbound
            if (Trip_Type.Return_Trip == TripType)
            {
                _searchRQ.Segments.Add(new Segment(2, _to, _from, _toDate));
            }
            #endregion

            #region other parameters

            _searchRQ.Adults = _adults;
            _searchRQ.Children = _childs;
            _searchRQ.Infants = _infants;
            _searchRQ.InfantsWithSeat = _infantsWithSeat;
            _searchRQ.Set_CabinClass(CabinClassCode);
            _searchRQ.DirectFlight = DirectFlight;
            _searchRQ.FlexiSearch = CalenderSearchDays;
            _searchRQ.Airline.AirlineCode = prefAir;

            #endregion


            flightFareSearchRQ = _searchRQ;
            _SearchProd.Add(new SearchProductDetails("00" + (_SearchProd.Count + 1), "ARF"));
        }

        List<SearchProductDetails> _SearchProd = new List<SearchProductDetails>();
        public List<SearchProductDetails> SearchProd
        {
            get { return this._SearchProd; }
        }



        FlightSearchDetails _FlightSearchDetails = new FlightSearchDetails();
        public FlightSearchDetails FlightSearchDetails
        {
            get { return _FlightSearchDetails; }
            set { _FlightSearchDetails = value; }
        }
        public void SetCompanyDetails(string _SourceMedia)
        {
            if (_SourceMedia == CompCredentials.SourceMedia || string.IsNullOrEmpty(_SourceMedia))
            {
                CompanyID = CompCredentials.CompanyId;
                HapID = CompCredentials.HapId;
                HapPassword = CompCredentials.HapPassword;
                HapType = CompCredentials.HapType;
                CoustmerType = CompCredentials.CoustmerType;
                RedirectFrom = SourceMedia = CompCredentials.SourceMedia;
                CompanyName = "Fares Saver Online";
                //BranchId = "1";
                //AgentId = "1";
            }
            else
            {
                try
                {
                    System.Data.DataTable dtCred = Miscellaneous.GET_Campaign_Master(_SourceMedia, _SourceMedia);                   
                    if (dtCred != null)
                    {
                        if (dtCred.Rows.Count > 0)
                        {
                            RedirectFrom = SourceMedia  = dtCred.Rows[0]["Code"].ToString();
                            HapID = dtCred.Rows[0]["Id"].ToString();
                            HapPassword = CompCredentials.HapPassword; ;
                            HapType = "LIVE"; //dtCred.Rows[0]["WL_HAP_Type"].ToString();
                            CompanyName = dtCred.Rows[0]["Name"].ToString();
                            CoustmerType = "DICT";

                        }
                        else
                        {
                            CompanyID = CompCredentials.CompanyId;
                            HapID = CompCredentials.HapId;
                            HapPassword = CompCredentials.HapPassword;
                            HapType = CompCredentials.HapType;
                            CoustmerType = CompCredentials.CoustmerType;
                            RedirectFrom = SourceMedia = CompCredentials.SourceMedia;
                            CompanyName = "Fares Saver Online";
                        }
                    }
                    else
                    {
                        CompanyID = CompCredentials.CompanyId;
                        HapID = CompCredentials.HapId;
                        HapPassword = CompCredentials.HapPassword;
                        HapType = CompCredentials.HapType;
                        CoustmerType = CompCredentials.CoustmerType;
                        RedirectFrom = SourceMedia = CompCredentials.SourceMedia;
                        CompanyName = "Fares Saver Online";
                    }
                }
                catch
                {
                    CompanyID = CompCredentials.CompanyId;
                    HapID = CompCredentials.HapId;
                    HapPassword = CompCredentials.HapPassword;
                    HapType = CompCredentials.HapType;
                    CoustmerType = CompCredentials.CoustmerType;
                    RedirectFrom = SourceMedia = CompCredentials.SourceMedia;
                    CompanyName = "Fares Saver Online";
                }
            }
        }

        public string CardName { set; get; }
        
        public string Utm_Source { get; set; }
        public string Guid { set; get; }
        public string PriceChangeStatus { set; get; }
        public string PriceChangeErrorMsg { set; get; }
        public string PricingInfo { set; get; }
        public string DeclineMsg { set; get; }
        public string KayakClickID { get; set; }
        public string PNRUAPI { set; get; }
        public string CompanyID { set; get; }
        public string AgentId { set; get; }
        public string BranchId { set; get; }
        public string CoustmerType { set; get; }
        public string HapID { set; get; }
        public string HapPassword { set; get; }
        public string HapType { set; get; }
        public string SourceMedia { set; get; }
        public string key { set; get; }
        public string code { set; get; }
        public string CompanyName { set; get; }
        public string RedirectFrom { set; get; }
        public string Status { set; get; }
        public string DiffAmount { set; get; }
        public int IndexNumber { set; get; }
        public string Provider { set; get; }
        public string Airline_Change { set; get; }

        public Itinerary Itinerary { set; get; }
        public Itinerary ItineraryOld { set; get; }
        public string FareMatchStatus { set; get; }
        public string BookingSession { set; get; }
        public string linkid { set; get; }
        
        public string Jtype { set; get; }
        public string BookStatus { set; get; }
        public string AdultBaggage { set; get; }
        public double AdultBaggagePrice { set; get; }
        public Boolean ChkData { get; set; }
        public Boolean ChackPT { get; set; }
        public int AdultBaggageCount { set; get; }
        public string ChildBaggage { set; get; }
        public double ChildBaggagePrice { set; get; }
        public int ChildBaggageCount { set; get; }
        public int UserID { set; get; }
        public string KeyPt { set; get; }
        public string ContactNo1 { set; get; }
        public string CouponStartDate { set; get; }
        public string CouponEndDate { set; get; }
        public string Communication { set; get; }
        public string TSTTime { set; get; }
        public double CardCharge { set; get; }

        List<Pax> _pax = new List<Pax>();
        public List<Pax> Passenger
        {
            get { return this._pax; }
            set { _pax = value; }
        }
        public void AddPassenger()
        {
            _pax = new List<Pax>();
            for (int i = 0; i < _FlightSearchDetails.paxDetails.adults; i++)
            {
                _pax.Add(new Pax(_pax.Count + 1, "Adult"));
            }
            for (int i = 0; i < _FlightSearchDetails.paxDetails.children; i++)
            {
                _pax.Add(new Pax(_pax.Count + 1, "Child"));
            }
            for (int i = 0; i < _FlightSearchDetails.paxDetails.infants; i++)
            {
                _pax.Add(new Pax(_pax.Count + 1, "Infant"));
            }
        }

        public string EmailID { set; get; }
        public string MobileNo { set; get; }
        public string PhoneNo { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string State { set; get; }
        public string Country { set; get; }
        public string PostCode { set; get; }
        public string BookingID { set; get; }
        public string ProdID { set; get; }
        public string PNR { set; get; }
        public string trnID { set; get; }
        public string BookingStatus { set; get; }

        //SagePay _sagepayment;
        //public SagePay SagePayment
        //{
        //    get { return _sagepayment; }
        //    set { _sagepayment = value; }
        //}

        public bool BookingFirm { set; get; }
        public bool BookingMail { set; get; }
        private bool _isCoupon = true;
        public bool IsCoupon
        {
            set { _isCoupon = value; }
            get { return _isCoupon; }
        }
        private double _couponValue = 0;
        public double CouponValue
        {
            set { _couponValue = value; }
            get { return _couponValue; }
        }
        public string CouponCode { set; get; }

        private bool _isIPAddress = false;
        public bool IsIPAddress
        {
            set { _isIPAddress = value; }
            get { return _isIPAddress; }
        }
        private bool _isInsurance = false;
        public bool IsInsurance
        {
            set { _isInsurance = value; }
            get { return _isInsurance; }
        }
        public int InsuranceID { set; get; }
        private double _insuranceCharge = 0;
        public double InsuranceCharge
        {
            set { _insuranceCharge = value; }
            get { return _insuranceCharge; }
        }
        
        private bool _holdFree = false;
        public bool HoldFree
        {
            get { return _holdFree; }
            set { _holdFree = value; }
        }
        public string OTPNumber { set; get; }

        public string _currency = "GBP";
        public string Currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        public string _basecurrency = "";
        public string BaseCurrency
        {
            set { _basecurrency = value; }
            get { return _basecurrency; }
        }
        public string _clientcurrency = "";
        public string ClientCurrency
        {
            set { _clientcurrency = value; }
            get { return _clientcurrency; }
        }
        public string _exchrate = "";
        public string ExchRate
        {
            set { _exchrate = value; }
            get { return _exchrate; }
        }

        public void SetTransactionNo()
        {
            GetSetDatabase GetSetDatabase = new GetSetDatabase();
            trnID = GetSetDatabase.GenerateIDs("TRN");
        }
        
        public Billing Billing { set; get; }
        public Shipping Shipping { set; get; }
        public double TransctionAmount { set; get; }
        public PaymentCallbackDetails PaymentCallbackDetails { set; get; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public double AtolAmount { get; set; }

        public string Token { get; set; }


        public string Cvv{ get; set; }
        public string Cardtype { get; set; }
        public string CardHolderName { get; set; }
       // public string CardName { get; set; }
        public string Cardnumber { get; set; }
        public string Expirydate { get; set; }
        public string BillingCountry { get; set; }

    }
}
