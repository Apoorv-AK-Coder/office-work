using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelSite.Models
{
    public class PaymentModel
    {
        public Itinerary Itinerary { set; get; }
        public List<Pax> Pax { set; get; }
        public string Contactno1 { get; set; }        
        public string DepDate { get; set; }
        public string RetDate { get; set; }
        public string DepDate1 { get; set; }
        public string RetDate1 { get; set; }
        public string DepDate2 { get; set; }
        public string RetDate2 { get; set; }
        public string DestFrom { get; set; }
        public string DestTo { get; set; }
        public string Guid { get; set; }
        public string Msg { get; set; }
        public string PriceData { get; set; }
      
        public double GrandTotal { get; set; }
        public double Safi { get; set; }
        public double Atol { get; set; }
        public string DeviceType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PriceBlock { get; set; }
        public string FromCode { get; set; }
        public string ToCode { get; set; }
        public string Price { get; set; }       
        public string Baggageinfo { get; set; }
        public string CompanyId { get; set; }
        public string DepSector { get; set; }
        public int Count { get; set; }
        public string CountryCode { get; set; }
       
        public string BookingID { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string CardName { get; set; }    
        public bool IsCouponDiscount { get; set; }
        public double CouponValue { get; set; }     
        public double DateDiff { get; set; }
        public string FareRestriction { get; set; }
        public double Markup { get; set; }
        public double CffCharge { get; set; }
        public string Provider { get; set; }
      
      
        public string MobileNo { get; set; }       
        public string totalpax { get; set; }
        public string Email { get; set; }
        public string IssueDate { get; set; }
        public string AirlineName { get; set; }
        public string Currency { get; set; }
        

        [Required(ErrorMessage = "Please enter card holder name ")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string Card_Name { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter proper card no.")]
        [Required(ErrorMessage = "Please enter proper card no.")]
        public string Card_No { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter proper Cvv no.")]
        [Required(ErrorMessage = "Please enter proper Cvv no.")]
        [DataType(DataType.Password)]
        public string CardCVV_No { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter proper Issue no.")]
        [Required(ErrorMessage = "*")]
        public string CardIssue_No { get; set; }
        [Required(ErrorMessage = " ")]
        public string Card_Address { get; set; }
        [Required(ErrorMessage = "Please enter city")]
        [DataType(DataType.Text)]
        //[RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        [RegularExpression("^[a-zA-Z0-9\\-\\s]+$", ErrorMessage = "Enter alphanumeric only")]
        public string Card_city { get; set; }
        [Required(ErrorMessage = "Please enter state")]
        [RegularExpression("^[a-zA-Z0-9\\-\\s]+$", ErrorMessage = "Enter alphanumeric only")]
        public string Card_State { get; set; }
        [Required(ErrorMessage = "Please enter pin")]
        public string Card_Pin { get; set; }
        [Required(ErrorMessage = "Please select card type")]
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Card Type")]
        public cardtype cardtype { get; set; }
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Card Type")]
        public cardtype debitcard { get; set; }
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Card Type")]
        public cardtype creditcard { get; set; }
        [Required(ErrorMessage = "Please select Country")]
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Country")]
        public CardCountry cardcountry { get; set; }
        [Required(ErrorMessage = "Please select Month")]
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Month")]
        public cardmonth card_month { get; set; }
        [Required(ErrorMessage = "Please select Year")]
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Year")]
        public cardyear card_year { get; set; }
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Month")]
        public cardmonth card_Issuemonth { get; set; }
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Year")]
        public cardyear card_Issueyear { get; set; }

        public string Card_Code { get; set; }
        public string url { get; set; }
        public string sGuid { get; set; }
        public string unique { get; set; }
        public string PaReq { get; set; }
        public string ACSUrl { get; set; }
        public string MD { get; set; }
        public string TermUrl { get; set; }
        public string VendorTxCode { get; set; }
        public string erromsg { get; set; }
        [BooleanRequired(ErrorMessage = " ")]
        [MustBeTrue(ErrorMessage = "Please check Terms & Conditions!")]
        public bool TermsAndConditionsAccepted { get; set; }
        public bool isReturn { get; set; }
        public bool PreviousUrl { get; set; }
        public string ValidFrom { get; set; }
        [Required(ErrorMessage = "Please enter address ")]
        public string Passenger_Addressone { get; set; }

        public string Passenger_Addresstwo { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        //[DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z0-9\\-\\s]+$", ErrorMessage = "Enter alphanumeric only")]
        public string Passenger_city { get; set; }
        [RegularExpression("^[a-zA-Z0-9\\-\\s]+$", ErrorMessage = "Enter alphanumeric only")]
        [Required(ErrorMessage = "Please enter State")]
        public string Passenger_State { get; set; }

        [Required(ErrorMessage = "Please enter Postal Code")]
        [DataType(DataType.PostalCode)]
        public string Passenger_Pin { get; set; }


        [Required(ErrorMessage = "Please select Country")]
        public string Passenger_countrylist { get; set; }
        [Required(ErrorMessage = " ")]
        public string FullAddress { get; set; }

        public class MustBeTrueAttribute : ValidationAttribute, IClientValidatable // IClientValidatable for client side Validation
        {
            public override bool IsValid(object value)
            {
                return value is bool && (bool)value;
            }
            // Implement IClientValidatable for client side Validation
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "checkbox", ErrorMessage = this.ErrorMessage } };
            }
        }
    }
    public class cardtype
    {
        public string ID { get; set; }
        public string Value { get; set; }
        //public string Disabled { get; set; }
    }
    public class CardCountry
    {

        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class cardmonth
    {

        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class cardyear
    {

        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class CardDropdownlist
    {
        #region cardlist
        public static List<cardtype> cardlist()
        {
            List<cardtype> _card = new List<cardtype>();
            _card.Add(new cardtype { ID = null, Value = "Select" });
            //_card.Add(new cardtype { ID = "-1", Value = "Credit Card" });
            //_card.Add(new cardtype { ID = "VISA", Value = "\xA0\xA0\xA0Visa Credit(0%)" });
            _card.Add(new cardtype { ID = "VISA", Value = "Visa Credit" });
            _card.Add(new cardtype { ID = "MC", Value = "Master Card" });            
            _card.Add(new cardtype { ID = "DELTA", Value = "Visa Debit/Delta" });
            _card.Add(new cardtype { ID = "UKE", Value = "Visa Electron" });
            _card.Add(new cardtype { ID = "SWITCH", Value = "Maestro" });           
            _card.Add(new cardtype { ID = "MAESTRO", Value = "Maestro cards" });
            _card.Add(new cardtype { ID = "AMEX", Value = "American Express cards" });
            _card.Add(new cardtype { ID = "DC", Value = "Diners Club cards" });
            _card.Add(new cardtype { ID = "JCB", Value = "Japan Credit Bureau cards" });
            _card.Add(new cardtype { ID = "LASER", Value = "Laser Cards" });
            _card.Add(new cardtype { ID = "PAYPAL", Value = "PAYPAL" });
            return _card;
        }
        #endregion


        #region debitcardlist
        public static List<cardtype> debitcardlist()
        {

            List<cardtype> _card = new List<cardtype>();
            _card.Add(new cardtype { ID = null, Value = "Select" });
            _card.Add(new cardtype { ID = "-1", Value = "Debit Card" });
            _card.Add(new cardtype { ID = "DELTA", Value = "\xA0\xA0\xA0Visa Debit/Delta(0%)" });
            _card.Add(new cardtype { ID = "UKE", Value = "\xA0\xA0\xA0Visa Electron(0%)" });
            _card.Add(new cardtype { ID = "SWITCH", Value = "\xA0\xA0\xA0Maestro(0%)" });
            //_card.Add(new cardtype { ID = null, Value = "Select" });
            //_card.Add(new cardtype { ID = "MC", Value = "Master Card(2%)" });
            //_card.Add(new cardtype { ID = "VISA", Value = "Visa Credit(2%)" });
            //_card.Add(new cardtype { ID = "DELTA", Value = "Visa Debit/Delta(0%)" });
            //_card.Add(new cardtype { ID = "UKE", Value = "Visa Electron(0%)" });
            //_card.Add(new cardtype { ID = "SWITCH", Value = "Maestro(0%)" });
            return _card;
        }
        #endregion
        #region creditcardlist
        public static List<cardtype> creditcardlist()
        {

            List<cardtype> _card = new List<cardtype>();
            _card.Add(new cardtype { ID = null, Value = "Select" });
            _card.Add(new cardtype { ID = "-1", Value = "Credit Card" });
            _card.Add(new cardtype { ID = "VISA", Value = "\xA0\xA0\xA0Visa Credit(2%)" });
            _card.Add(new cardtype { ID = "MC", Value = "\xA0\xA0\xA0Master Card(2%)" });

            return _card;
        }
        #endregion

        #region cardCountry
        public static List<CardCountry> CardCountryList()
        {
            List<CardCountry> _cardcountry = new List<CardCountry>();
            _cardcountry.Add(new CardCountry { ID = null, Value = "Select" });
            _cardcountry.Add(new CardCountry { ID = "AF", Value = "Afghanistan" });
            _cardcountry.Add(new CardCountry { ID = "AX", Value = "Aland Islands" });
            _cardcountry.Add(new CardCountry { ID = "AL", Value = "Albania" });
            _cardcountry.Add(new CardCountry { ID = "DZ", Value = "Algeria" });
            _cardcountry.Add(new CardCountry { ID = "AS", Value = "American Samoa" });
            _cardcountry.Add(new CardCountry { ID = "AD", Value = "Andorra" });
            _cardcountry.Add(new CardCountry { ID = "AO", Value = "Angola" });
            _cardcountry.Add(new CardCountry { ID = "AI", Value = "Anguilla" });
            _cardcountry.Add(new CardCountry { ID = "AQ", Value = "Antarctica" });
            _cardcountry.Add(new CardCountry { ID = "AG", Value = "Antigua and Barbuda" });
            _cardcountry.Add(new CardCountry { ID = "AR", Value = "Argentina" });
            _cardcountry.Add(new CardCountry { ID = "AM", Value = "Armenia" });
            _cardcountry.Add(new CardCountry { ID = "AW", Value = "Aruba" });
            _cardcountry.Add(new CardCountry { ID = "AU", Value = "Australia" });
            _cardcountry.Add(new CardCountry { ID = "AT", Value = "Austria" });
            _cardcountry.Add(new CardCountry { ID = "AZ", Value = "Azerbaijan" });
            _cardcountry.Add(new CardCountry { ID = "BS", Value = "Bahamas" });
            _cardcountry.Add(new CardCountry { ID = "BH", Value = "Bahrain" });
            _cardcountry.Add(new CardCountry { ID = "BD", Value = "Bangladesh" });
            _cardcountry.Add(new CardCountry { ID = "BB", Value = "Barbados" });
            _cardcountry.Add(new CardCountry { ID = "BY", Value = "Belarus" });
            _cardcountry.Add(new CardCountry { ID = "BE", Value = "Belgium" });
            _cardcountry.Add(new CardCountry { ID = "BZ", Value = "Belize" });
            _cardcountry.Add(new CardCountry { ID = "BJ", Value = "Benin" });
            _cardcountry.Add(new CardCountry { ID = "BM", Value = "Bermuda" });
            _cardcountry.Add(new CardCountry { ID = "BT", Value = "Bhutan" });
            _cardcountry.Add(new CardCountry { ID = "BO", Value = "Bolivia" });
            _cardcountry.Add(new CardCountry { ID = "BA", Value = "Bosnia and Herzegovina" });
            _cardcountry.Add(new CardCountry { ID = "BW", Value = "Botswana" });
            _cardcountry.Add(new CardCountry { ID = "BV", Value = "Bouvet Island" });
            _cardcountry.Add(new CardCountry { ID = "BR", Value = "Brazil" });
            _cardcountry.Add(new CardCountry { ID = "IO", Value = "British Indian Ocean Territory" });
            _cardcountry.Add(new CardCountry { ID = "BN", Value = "Brunei Darussalam" });
            _cardcountry.Add(new CardCountry { ID = "BG", Value = "Bulgaria" });
            _cardcountry.Add(new CardCountry { ID = "BF", Value = "Burkina Faso" });
            _cardcountry.Add(new CardCountry { ID = "BI", Value = "Burundi" });
            _cardcountry.Add(new CardCountry { ID = "KH", Value = "Cambodia" });
            _cardcountry.Add(new CardCountry { ID = "CM", Value = "Cameroon" });
            _cardcountry.Add(new CardCountry { ID = "CA", Value = "Canada" });
            _cardcountry.Add(new CardCountry { ID = "CV", Value = "Cape Verde" });
            _cardcountry.Add(new CardCountry { ID = "KY", Value = "Cayman Islands" });
            _cardcountry.Add(new CardCountry { ID = "CF", Value = "Central African Republic" });
            _cardcountry.Add(new CardCountry { ID = "TD", Value = "Chad" });
            _cardcountry.Add(new CardCountry { ID = "CL", Value = "Chile" });
            _cardcountry.Add(new CardCountry { ID = "CN", Value = "China" });
            _cardcountry.Add(new CardCountry { ID = "CX", Value = "Christmas Island" });
            _cardcountry.Add(new CardCountry { ID = "CC", Value = "Cocos (Keeling) Islands" });
            _cardcountry.Add(new CardCountry { ID = "CO", Value = "Colombia" });
            _cardcountry.Add(new CardCountry { ID = "KM", Value = "Comoros" });
            _cardcountry.Add(new CardCountry { ID = "CG", Value = "Congo" });
            _cardcountry.Add(new CardCountry { ID = "CD", Value = "Congo The Democratic Republic of the" });
            _cardcountry.Add(new CardCountry { ID = "CK", Value = "Cook Islands" });
            _cardcountry.Add(new CardCountry { ID = "CR", Value = "Costa Rica" });
            _cardcountry.Add(new CardCountry { ID = "CI", Value = "Côte d'Ivoire" });
            _cardcountry.Add(new CardCountry { ID = "HR", Value = "Croatia" });
            _cardcountry.Add(new CardCountry { ID = "CU", Value = "Cuba" });
            _cardcountry.Add(new CardCountry { ID = "CY", Value = "Cyprus" });
            _cardcountry.Add(new CardCountry { ID = "CZ", Value = "Czech Republic" });
            _cardcountry.Add(new CardCountry { ID = "DK", Value = "Denmark" });
            _cardcountry.Add(new CardCountry { ID = "DJ", Value = "Djibouti" });
            _cardcountry.Add(new CardCountry { ID = "DM", Value = "Dominica" });
            _cardcountry.Add(new CardCountry { ID = "DO", Value = "Dominican Republic" });
            _cardcountry.Add(new CardCountry { ID = "EC", Value = "Ecuador" });
            _cardcountry.Add(new CardCountry { ID = "EG", Value = "Egypt" });
            _cardcountry.Add(new CardCountry { ID = "SV", Value = "El Salvador" });
            _cardcountry.Add(new CardCountry { ID = "GQ", Value = "Equatorial Guinea" });
            _cardcountry.Add(new CardCountry { ID = "ER", Value = "Eritrea" });
            _cardcountry.Add(new CardCountry { ID = "EE", Value = "Estonia" });
            _cardcountry.Add(new CardCountry { ID = "ET", Value = "Ethiopia" });
            _cardcountry.Add(new CardCountry { ID = "FK", Value = "Falkland Islands (Malvinas)" });
            _cardcountry.Add(new CardCountry { ID = "FO", Value = "Faroe Islands" });
            _cardcountry.Add(new CardCountry { ID = "FJ", Value = "Fiji" });
            _cardcountry.Add(new CardCountry { ID = "FI", Value = "Finland" });
            _cardcountry.Add(new CardCountry { ID = "FR", Value = "France" });
            _cardcountry.Add(new CardCountry { ID = "GF", Value = "French Guiana" });
            _cardcountry.Add(new CardCountry { ID = "PF", Value = "French Polynesia" });
            _cardcountry.Add(new CardCountry { ID = "TF", Value = "French Southern Territories" });
            _cardcountry.Add(new CardCountry { ID = "GA", Value = "Gabon" });
            _cardcountry.Add(new CardCountry { ID = "GM", Value = "Gambia" });
            _cardcountry.Add(new CardCountry { ID = "GE", Value = "Georgia" });
            _cardcountry.Add(new CardCountry { ID = "DE", Value = "Germany" });
            _cardcountry.Add(new CardCountry { ID = "GH", Value = "Ghana" });
            _cardcountry.Add(new CardCountry { ID = "GI", Value = "Gibraltar" });
            _cardcountry.Add(new CardCountry { ID = "GR", Value = "Greece" });
            _cardcountry.Add(new CardCountry { ID = "GL", Value = "Greenland" });
            _cardcountry.Add(new CardCountry { ID = "GD", Value = "Grenada" });
            _cardcountry.Add(new CardCountry { ID = "GP", Value = "Guadeloupe" });
            _cardcountry.Add(new CardCountry { ID = "GU", Value = "Guam" });
            _cardcountry.Add(new CardCountry { ID = "GT", Value = "Guatemala" });
            _cardcountry.Add(new CardCountry { ID = "GG", Value = "Guernsey" });
            _cardcountry.Add(new CardCountry { ID = "GN", Value = "Guinea" });
            _cardcountry.Add(new CardCountry { ID = "GW", Value = "Guinea-Bissau" });
            _cardcountry.Add(new CardCountry { ID = "GY", Value = "Guyana" });
            _cardcountry.Add(new CardCountry { ID = "HT", Value = "Haiti" });
            _cardcountry.Add(new CardCountry { ID = "HM", Value = "Heard Island and McDonald Islands" });
            _cardcountry.Add(new CardCountry { ID = "VA", Value = "Holy See (Vatican City State)" });
            _cardcountry.Add(new CardCountry { ID = "HN", Value = "Honduras" });
            _cardcountry.Add(new CardCountry { ID = "HK", Value = "Hong Kong" });
            _cardcountry.Add(new CardCountry { ID = "HU", Value = "Hungary" });
            _cardcountry.Add(new CardCountry { ID = "IS", Value = "Iceland" });
            _cardcountry.Add(new CardCountry { ID = "IN", Value = "India" });
            _cardcountry.Add(new CardCountry { ID = "ID", Value = "Indonesia" });
            _cardcountry.Add(new CardCountry { ID = "IR", Value = "Iran Islamic Republic of" });
            _cardcountry.Add(new CardCountry { ID = "IQ", Value = "Iraq" });
            _cardcountry.Add(new CardCountry { ID = "IE", Value = "Ireland" });
            _cardcountry.Add(new CardCountry { ID = "IM", Value = "Isle of Man" });
            _cardcountry.Add(new CardCountry { ID = "IL", Value = "Israel" });
            _cardcountry.Add(new CardCountry { ID = "IT", Value = "Italy" });
            _cardcountry.Add(new CardCountry { ID = "JM", Value = "Jamaica" });
            _cardcountry.Add(new CardCountry { ID = "JP", Value = "Japan" });
            _cardcountry.Add(new CardCountry { ID = "JE", Value = "Jersey" });
            _cardcountry.Add(new CardCountry { ID = "JO", Value = "Jordan" });
            _cardcountry.Add(new CardCountry { ID = "KZ", Value = "Kazakhstan" });
            _cardcountry.Add(new CardCountry { ID = "KE", Value = "Kenya" });
            _cardcountry.Add(new CardCountry { ID = "KI", Value = "Kiribati" });
            _cardcountry.Add(new CardCountry { ID = "KP", Value = "Korea Democratic People's Republic of" });
            _cardcountry.Add(new CardCountry { ID = "KR", Value = "Korea Republic of" });
            _cardcountry.Add(new CardCountry { ID = "KW", Value = "Kuwait" });
            _cardcountry.Add(new CardCountry { ID = "KG", Value = "Kyrgyzstan" });
            _cardcountry.Add(new CardCountry { ID = "LA", Value = "Lao People's Democratic Republic" });
            _cardcountry.Add(new CardCountry { ID = "LV", Value = "Latvia" });
            _cardcountry.Add(new CardCountry { ID = "LB", Value = "Lebanon" });
            _cardcountry.Add(new CardCountry { ID = "LS", Value = "Lesotho" });
            _cardcountry.Add(new CardCountry { ID = "LR", Value = "Liberia" });
            _cardcountry.Add(new CardCountry { ID = "LY", Value = "Libyan Arab Jamahiriya" });
            _cardcountry.Add(new CardCountry { ID = "LI", Value = "Liechtenstein" });
            _cardcountry.Add(new CardCountry { ID = "LT", Value = "Lithuania" });
            _cardcountry.Add(new CardCountry { ID = "LU", Value = "Luxembourg" });
            _cardcountry.Add(new CardCountry { ID = "MO", Value = "Macao" });
            _cardcountry.Add(new CardCountry { ID = "MK", Value = "Macedonia The Former Yugoslav Republic of" });
            _cardcountry.Add(new CardCountry { ID = "MG", Value = "Madagascar" });
            _cardcountry.Add(new CardCountry { ID = "MW", Value = "Malawi" });
            _cardcountry.Add(new CardCountry { ID = "MY", Value = "Malaysia" });
            _cardcountry.Add(new CardCountry { ID = "MV", Value = "Maldives" });
            _cardcountry.Add(new CardCountry { ID = "ML", Value = "Mali" });
            _cardcountry.Add(new CardCountry { ID = "MT", Value = "Malta" });
            _cardcountry.Add(new CardCountry { ID = "MH", Value = "Marshall Islands" });
            _cardcountry.Add(new CardCountry { ID = "MQ", Value = "Martinique" });
            _cardcountry.Add(new CardCountry { ID = "MR", Value = "Mauritania" });
            _cardcountry.Add(new CardCountry { ID = "MU", Value = "Mauritius" });
            _cardcountry.Add(new CardCountry { ID = "MT", Value = "Mayotte" });
            _cardcountry.Add(new CardCountry { ID = "MX", Value = "Mexico" });
            _cardcountry.Add(new CardCountry { ID = "FM", Value = "Microneia Federated States of" });
            _cardcountry.Add(new CardCountry { ID = "MD", Value = "Moldova" });
            _cardcountry.Add(new CardCountry { ID = "MC", Value = "Monaco" });
            _cardcountry.Add(new CardCountry { ID = "MN", Value = "Mongolia" });
            _cardcountry.Add(new CardCountry { ID = "ME", Value = "Montenegro" });
            _cardcountry.Add(new CardCountry { ID = "MS", Value = "Montserrat" });
            _cardcountry.Add(new CardCountry { ID = "MA", Value = "Morocco" });
            _cardcountry.Add(new CardCountry { ID = "MZ", Value = "Mozambique" });
            _cardcountry.Add(new CardCountry { ID = "MM", Value = "Myanmar" });
            _cardcountry.Add(new CardCountry { ID = "NA", Value = "Namibia" });
            _cardcountry.Add(new CardCountry { ID = "NR", Value = "Nauru" });
            _cardcountry.Add(new CardCountry { ID = "NP", Value = "Nepal" });
            _cardcountry.Add(new CardCountry { ID = "NL", Value = "Netherlands" });
            _cardcountry.Add(new CardCountry { ID = "AN", Value = "Netherlands Antilles" });
            _cardcountry.Add(new CardCountry { ID = "NC", Value = "New Caledonia" });
            _cardcountry.Add(new CardCountry { ID = "NZ", Value = "New Zealand" });
            _cardcountry.Add(new CardCountry { ID = "NI", Value = "Nicaragua" });
            _cardcountry.Add(new CardCountry { ID = "NE", Value = "Niger" });
            _cardcountry.Add(new CardCountry { ID = "NG", Value = "Nigeria" });
            _cardcountry.Add(new CardCountry { ID = "NU", Value = "Niue" });
            _cardcountry.Add(new CardCountry { ID = "NF", Value = "Norfolk Island" });
            _cardcountry.Add(new CardCountry { ID = "MP", Value = "Northern Mariana Islands" });
            _cardcountry.Add(new CardCountry { ID = "NO", Value = "Norway" });
            _cardcountry.Add(new CardCountry { ID = "OM", Value = "Oman" });
            _cardcountry.Add(new CardCountry { ID = "PK", Value = "Pakistan" });
            _cardcountry.Add(new CardCountry { ID = "PW", Value = "Palau" });
            _cardcountry.Add(new CardCountry { ID = "PS", Value = "Palestinian Territory Occupied" });
            _cardcountry.Add(new CardCountry { ID = "PA", Value = "Panama" });
            _cardcountry.Add(new CardCountry { ID = "PG", Value = "Papua New Guinea" });
            _cardcountry.Add(new CardCountry { ID = "PY", Value = "Paraguay" });
            _cardcountry.Add(new CardCountry { ID = "PE", Value = "Peru" });
            _cardcountry.Add(new CardCountry { ID = "PH", Value = "Philippines" });
            _cardcountry.Add(new CardCountry { ID = "PN", Value = "Pitcairn" });
            _cardcountry.Add(new CardCountry { ID = "PL", Value = "Poland" });
            _cardcountry.Add(new CardCountry { ID = "PT", Value = "Portugal" });
            _cardcountry.Add(new CardCountry { ID = "PR", Value = "Puerto Rico" });
            _cardcountry.Add(new CardCountry { ID = "QA", Value = "Qatar" });
            _cardcountry.Add(new CardCountry { ID = "RE", Value = "Réunion" });
            _cardcountry.Add(new CardCountry { ID = "RO", Value = "Romania" });
            _cardcountry.Add(new CardCountry { ID = "RU", Value = "Russian Federation" });
            _cardcountry.Add(new CardCountry { ID = "RW", Value = "Rwanda" });
            _cardcountry.Add(new CardCountry { ID = "BL", Value = "Saint Barthélemy" });
            _cardcountry.Add(new CardCountry { ID = "SH", Value = "Saint Helena" });
            _cardcountry.Add(new CardCountry { ID = "KN", Value = "Saint Kitts and Nevis" });
            _cardcountry.Add(new CardCountry { ID = "LC", Value = "Saint Lucia" });
            _cardcountry.Add(new CardCountry { ID = "MF", Value = "Saint Martin" });
            _cardcountry.Add(new CardCountry { ID = "PM", Value = "Saint Pierre and Miquelon" });
            _cardcountry.Add(new CardCountry { ID = "VC", Value = "Saint Vincent and the Grenadines" });
            _cardcountry.Add(new CardCountry { ID = "WS", Value = "Samoa" });
            _cardcountry.Add(new CardCountry { ID = "SM", Value = "San Marino" });
            _cardcountry.Add(new CardCountry { ID = "ST", Value = "Sao Tome and Principe" });
            _cardcountry.Add(new CardCountry { ID = "SA", Value = "Saudi Arabia" });
            _cardcountry.Add(new CardCountry { ID = "SN", Value = "Senegal" });
            _cardcountry.Add(new CardCountry { ID = "RS", Value = "Serbia" });
            _cardcountry.Add(new CardCountry { ID = "SC", Value = "Seychelles" });
            _cardcountry.Add(new CardCountry { ID = "SL", Value = "Sierra Leone" });
            _cardcountry.Add(new CardCountry { ID = "SG", Value = "Singapore" });
            _cardcountry.Add(new CardCountry { ID = "SK", Value = "Slovakia" });
            _cardcountry.Add(new CardCountry { ID = "SI", Value = "Slovenia" });
            _cardcountry.Add(new CardCountry { ID = "SB", Value = "Solomon Islands" });
            _cardcountry.Add(new CardCountry { ID = "SO", Value = "Somalia" });
            _cardcountry.Add(new CardCountry { ID = "ZA", Value = "South Africa" });
            _cardcountry.Add(new CardCountry { ID = "GS", Value = "South Georgia and the South Sandwich Islands" });
            _cardcountry.Add(new CardCountry { ID = "ES", Value = "Spain" });
            _cardcountry.Add(new CardCountry { ID = "LK", Value = "Sri Lanka" });
            _cardcountry.Add(new CardCountry { ID = "SD", Value = "Sudan" });
            _cardcountry.Add(new CardCountry { ID = "SR", Value = "Suriname" });
            _cardcountry.Add(new CardCountry { ID = "SJ", Value = "Svalbard and Jan Mayen" });
            _cardcountry.Add(new CardCountry { ID = "SZ", Value = "Swaziland" });
            _cardcountry.Add(new CardCountry { ID = "SE", Value = "Sweden" });
            _cardcountry.Add(new CardCountry { ID = "CH", Value = "Switzerland" });
            _cardcountry.Add(new CardCountry { ID = "SY", Value = "Syrian Arab Republic" });
            _cardcountry.Add(new CardCountry { ID = "TW", Value = "Taiwan Province of China" });
            _cardcountry.Add(new CardCountry { ID = "TJ", Value = "Tajikistan" });
            _cardcountry.Add(new CardCountry { ID = "TZ", Value = "Tanzania United Republic of" });
            _cardcountry.Add(new CardCountry { ID = "TH", Value = "Thailand" });
            _cardcountry.Add(new CardCountry { ID = "TL", Value = "Timor-Leste" });
            _cardcountry.Add(new CardCountry { ID = "TG", Value = "Togo" });
            _cardcountry.Add(new CardCountry { ID = "TK", Value = "Tokelau" });
            _cardcountry.Add(new CardCountry { ID = "TO", Value = "Tonga" });
            _cardcountry.Add(new CardCountry { ID = "TT", Value = "Trinidad and Tobago" });
            _cardcountry.Add(new CardCountry { ID = "TN", Value = "Tunisia" });
            _cardcountry.Add(new CardCountry { ID = "TR", Value = "Turkey" });
            _cardcountry.Add(new CardCountry { ID = "TM", Value = "Turkmenistan" });
            _cardcountry.Add(new CardCountry { ID = "TC", Value = "Turks and Caicos Islands" });
            _cardcountry.Add(new CardCountry { ID = "TV", Value = "Tuvalu" });
            _cardcountry.Add(new CardCountry { ID = "UG", Value = "Uganda" });
            _cardcountry.Add(new CardCountry { ID = "UA", Value = "Ukraine" });
            _cardcountry.Add(new CardCountry { ID = "AE", Value = "United Arab Emirates" });
            _cardcountry.Add(new CardCountry { ID = "GB", Value = "United Kingdom" });
            _cardcountry.Add(new CardCountry { ID = "US", Value = "United States" });
            _cardcountry.Add(new CardCountry { ID = "UM", Value = "United States Minor Outlying Islands" });
            _cardcountry.Add(new CardCountry { ID = "UY", Value = "Uruguay" });
            _cardcountry.Add(new CardCountry { ID = "UZ", Value = "Uzbekistan" });
            _cardcountry.Add(new CardCountry { ID = "VU", Value = "Vanuatu" });
            _cardcountry.Add(new CardCountry { ID = "VE", Value = "Venezuela" });
            _cardcountry.Add(new CardCountry { ID = "VN", Value = "Viet Nam" });
            _cardcountry.Add(new CardCountry { ID = "VG", Value = "Virgin Islands British" });
            _cardcountry.Add(new CardCountry { ID = "VI", Value = "Virgin Islands U.S." });
            _cardcountry.Add(new CardCountry { ID = "WF", Value = "Wallis and Futuna" });
            _cardcountry.Add(new CardCountry { ID = "EH", Value = "Western Sahara" });
            _cardcountry.Add(new CardCountry { ID = "YE", Value = "Yemen" });
            _cardcountry.Add(new CardCountry { ID = "ZM", Value = "Zambia" });
            _cardcountry.Add(new CardCountry { ID = "ZW", Value = "Zimbabwe" });
            return _cardcountry;
        }
        #endregion

        #region Month
        public static List<cardmonth> cardMonthList()
        {
            List<cardmonth> _ListMonth = new System.Collections.Generic.List<cardmonth>();
            _ListMonth.Add(new cardmonth { ID = null, Value = "Month" });
            _ListMonth.Add(new cardmonth { ID = "01", Value = "JAN" });
            _ListMonth.Add(new cardmonth { ID = "02", Value = "FEB" });
            _ListMonth.Add(new cardmonth { ID = "03", Value = "MAR" });
            _ListMonth.Add(new cardmonth { ID = "04", Value = "APR" });
            _ListMonth.Add(new cardmonth { ID = "05", Value = "MAY" });
            _ListMonth.Add(new cardmonth { ID = "06", Value = "JUN" });
            _ListMonth.Add(new cardmonth { ID = "07", Value = "JUL" });
            _ListMonth.Add(new cardmonth { ID = "08", Value = "AUG" });
            _ListMonth.Add(new cardmonth { ID = "09", Value = "SEP" });
            _ListMonth.Add(new cardmonth { ID = "10", Value = "OCT" });
            _ListMonth.Add(new cardmonth { ID = "11", Value = "NOV" });
            _ListMonth.Add(new cardmonth { ID = "12", Value = "DEC" });
            return _ListMonth;
        }
        #endregion
        #region card Year
        public static List<cardyear> cardYear()
        {
            List<cardyear> _cardListYr = new System.Collections.Generic.List<cardyear>();
            _cardListYr.Add(new cardyear { ID = null, Value = "Year" });
            for (int i = System.DateTime.Now.Year; i <= System.DateTime.Now.Year + 15; i++)
            {
                _cardListYr.Add(new cardyear { ID = i.ToString(), Value = "" + i + "" });
            }
            return _cardListYr;
        }
        #endregion


    }
}