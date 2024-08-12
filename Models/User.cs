using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelSite.Models
{
    public class User
    {
        string _BookingID;
        public string BookingID
        {
            get { return _BookingID; }
            set { _BookingID = value; }
        }


        int _UsrId;
        public int UsrId
        {
            get { return _UsrId; }
            set { _UsrId = value; }
        }

        string _LoginId;

        public string LoginId
        {
            get { return _LoginId; }
            set { _LoginId = value; }
        }
        string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        string _First_Name;
        public string First_Name
        {
            get { return _First_Name; }
            set { _First_Name = value; }
        }

        string _Last_Name;
        public string Last_Name
        {
            get { return _Last_Name; }
            set { _Last_Name = value; }
        }

        string _Password;
        [Required(ErrorMessage = "*")]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        string _Enc_Password;
        public string Enc_Password
        {
            get { return _Enc_Password; }
            set { _Enc_Password = value; }
        }

        string _MailId;
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string MailId
        {
            get { return _MailId; }
            set { _MailId = value; }
        }

        string _MobileNo;
        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        string _PhoneNo;
        [Required(ErrorMessage = "*")]
        public string PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }

        string _FaxNo;
        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }

        string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        string _Country;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        string _PinCode;
        public string PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }

        string _CompanyId;
        public string CompanyId
        {
            get { return _CompanyId; }
            set { _CompanyId = value; }
        }


        string _SourceMedia;
        public string SourceMedia
        {
            get { return _SourceMedia; }
            set { _SourceMedia = value; }
        }

        bool _Status;
        public bool Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        string _CampaignID;
        public string CampaignID
        {
            get { return _CampaignID; }
            set { _CampaignID = value; }
        }


        bool _IsVerified;
        public bool IsVerified
        {
            get { return _IsVerified; }
            set { _IsVerified = value; }
        }

        DateTime _ModifiedDate;
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        string _DOB;
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        string _BookingType;
        public string BookingType
        {
            get { return _BookingType; }
            set { _BookingType = value; }
        }

        string _ProductType;
        public string ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
        }
        string _CompanyID;
        public string CompanyID
        {
            get { return _CompanyID; }
            set { _CompanyID = value; }
        }

        string _BookingDate;
        public string BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }

        string _BookingStatus;
        public string BookingStatus
        {
            get { return _BookingStatus; }
            set { _BookingStatus = value; }
        }


        int _ReferredBy;
        public int ReferredBy
        {
            get { return _ReferredBy; }
            set { _ReferredBy = value; }
        }
        DateTime _LastLogin;
        public DateTime LastLogin
        {
            get { return _LastLogin; }
            set { _LastLogin = value; }
        }
        string _UsuallyFlyFrom;
        public string UsuallyFlyFrom
        {
            get { return _UsuallyFlyFrom; }
            set { _UsuallyFlyFrom = value; }
        }



        string _Marital;
        public string Marital
        {
            get { return _Marital; }
            set { _Marital = value; }
        }
        string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        string _HolidayDestination;
        public string HolidayDestination
        {
            get { return _HolidayDestination; }
            set { _HolidayDestination = value; }
        }
        string _HolidayBudget;
        public string HolidayBudget
        {
            get { return _HolidayBudget; }
            set { _HolidayBudget = value; }
        }
        string _DealInterest;
        public string DealInterest
        {
            get { return _DealInterest; }
            set { _DealInterest = value; }
        }
        string _RegionInterest;
        public string RegionInterest
        {
            get { return _RegionInterest; }
            set { _RegionInterest = value; }
        }
        string _Frequnecy;
        public string Frequency
        {
            get { return _Frequnecy; }
            set { _Frequnecy = value; }
        }

        string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        int _Points;
        public int Points
        {
            get { return _Points; }
            set { _Points = value; }
        }
        string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        bool _IsUpdated;
        public bool IsUpdated
        {
            get { return _IsUpdated; }
            set { _IsUpdated = value; }
        }

        bool _IsPromoOffer;
        public bool IsPromoOffer
        {
            get { return _IsPromoOffer; }
            set { _IsPromoOffer = value; }
        }
        string _CreatedBy;
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        string _Origin;
        public string Origin
        {
            get { return _Origin; }
            set { _Origin = value; }
        }
        string _Destination;
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }



        public List<TravelPreference> TPList { get; set; }
        public List<NwsLetter> NwsList { get; set; }
        public List<Mailings> MlList { get; set; }
        public string TPids { get; set; }
        public string NWSids { get; set; }
        public string MLids { get; set; }
        public List<MyBooking> BOKList { get; set; }
        public List<MyPoint> PointList { get; set; }
        int _Redeemable;
        public int Redeemable
        {
            get { return _Redeemable; }
            set { _Redeemable = value; }
        }
        int _Redeemed;
        public int Redeemed
        {
            get { return _Redeemed; }
            set { _Redeemed = value; }
        }
        public List<MyReview> ReviewList { get; set; }

        bool _IsAlreadyBuyProduct;
        public bool IsAlreadyBuyProduct
        {
            get { return _IsAlreadyBuyProduct; }
            set { _IsAlreadyBuyProduct = value; }
        }

    }
}
