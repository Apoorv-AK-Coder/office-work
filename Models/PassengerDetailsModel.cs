using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelSite.Models
{
    public class PassengerDetailsModel
    {
        public Itinerary Itinerary { set; get; }

        public string SetFlightHtml { get; set; }
        public string SetHtmlPrice { get; set; }
        public string Guid { get; set; }
        public string ActFast { get; set; }
        public string SetPrice { get; set; }
        public string url { get; set; }
        public string keyvalue { get; set; }
        public bool IsPriceChange { get; set; }
        public double TotalDataCount { get; set; }
        public string MinPaxAge { get; set; }
        public bool ShowFltOption { get; set; }
        public string NewPrice { get; set; }
        public string OldPrice { get; set; }
        public string CPrice { get; set; }
        public string Difference { get; set; }
        public string AirlineLogo { get; set; }
        public string AirlineName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double mincost { get; set; }
        public string DivSign { get; set; }

        // Alternate flight options
        public string ImageUrl1 { get; set; }
        public string Opt1UpdateFare { get; set; }
        public string Opt1OrgFare { get; set; }
        public string Opt1DiffFare { get; set; }
        public string Opt1IndexProvider { get; set; }
        public string Airline1 { get; set; }

        //public string Opt1Provider { get; set; }

        public string ImageUrl2 { get; set; }
        public string Opt2UpdateFare { get; set; }
        public string Opt2OrgFare { get; set; }
        public string Opt2DiffFare { get; set; }
        public string Opt2IndexProvider { get; set; }
        public string Airline2 { get; set; }
        //public string Opt2Provider { get; set; }
        public string ImageUrl3 { get; set; }
        public string Opt3UpdateFare { get; set; }
        public string Opt3OrgFare { get; set; }
        public string Opt3DiffFare { get; set; }
        public string Opt3IndexProvider { get; set; }
        public string Airline3 { get; set; }

        public string ImageUrl4 { get; set; }
        public string Opt4UpdateFare { get; set; }
        public string Opt4OrgFare { get; set; }
        public string Opt4DiffFare { get; set; }
        public string Opt4IndexProvider { get; set; }
        public string Airline4 { get; set; }
        public bool AdtBaggInfo { set; get; }
        public bool ChdBaggInfo { set; get; }
        public int Adult { get; set; }
        public int Child { get; set; }
        public int Infant { get; set; }
        public int InfantWithSeat { get; set; }
        public string GrandTotal { get; set; }
        public string ContactNo1 { get; set; }

        public List<ViewModel> _ViewModel { get; set; }
        //[RegularExpression(@"^\d+$", ErrorMessage = "Please enter proper Phone No.")]
        //[Required(ErrorMessage = "*")]
        public string homePhone { get; set; }
        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter proper Phone No.")]
        [Required(ErrorMessage = "Please enter Mobile No.")]
        public string MobNo { get; set; }
        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Address not confirmed correctly.")]
        public string ConfirmEmail { get; set; }

        public bool promotial_deals { get; set; }
        [BooleanRequired(ErrorMessage = "Please check Terms & Conditions!")]
        public bool TermsAndConditionsAccepted { get; set; }

        [Required(ErrorMessage = " ")]
        public string Passenger_Addressone { get; set; }

        public string Passenger_Addresstwo { get; set; }

        [Required(ErrorMessage = " ")]
        //[DataType(DataType.Text)]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string Passenger_city { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string Passenger_State { get; set; }

        [Required(ErrorMessage = " ")]
        [DataType(DataType.PostalCode)]
        public string Passenger_Pin { get; set; }

        [Required(ErrorMessage = " ")]
        public string Passenger_countrylist { get; set; }

        public string SourceCode { get; set; }
        public string DestinationCode { get; set; }
        public string unique { get; set; }
        public string hdDOBDate { get; set; }
        public string hdRetDate { get; set; }
    }

    public class BooleanRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value is bool)
                return (bool)value;
            else
                return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "booleanrequired"
            };
        }
    }

    public class PassengerCountry
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public class PassengerDropdownlist
    {
        #region cardCountry
        public static List<PassengerCountry> PassengerCountryList()
        {
            List<PassengerCountry> _cardcountry = new List<PassengerCountry>();
            _cardcountry.Add(new PassengerCountry { ID = null, Value = "Select" });
            _cardcountry.Add(new PassengerCountry { ID = "AF", Value = "Afghanistan" });
            _cardcountry.Add(new PassengerCountry { ID = "AX", Value = "Aland Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "AL", Value = "Albania" });
            _cardcountry.Add(new PassengerCountry { ID = "DZ", Value = "Algeria" });
            _cardcountry.Add(new PassengerCountry { ID = "AS", Value = "American Samoa" });
            _cardcountry.Add(new PassengerCountry { ID = "AD", Value = "Andorra" });
            _cardcountry.Add(new PassengerCountry { ID = "AO", Value = "Angola" });
            _cardcountry.Add(new PassengerCountry { ID = "AI", Value = "Anguilla" });
            _cardcountry.Add(new PassengerCountry { ID = "AQ", Value = "Antarctica" });
            _cardcountry.Add(new PassengerCountry { ID = "AG", Value = "Antigua and Barbuda" });
            _cardcountry.Add(new PassengerCountry { ID = "AR", Value = "Argentina" });
            _cardcountry.Add(new PassengerCountry { ID = "AM", Value = "Armenia" });
            _cardcountry.Add(new PassengerCountry { ID = "AW", Value = "Aruba" });
            _cardcountry.Add(new PassengerCountry { ID = "AU", Value = "Australia" });
            _cardcountry.Add(new PassengerCountry { ID = "AT", Value = "Austria" });
            _cardcountry.Add(new PassengerCountry { ID = "AZ", Value = "Azerbaijan" });
            _cardcountry.Add(new PassengerCountry { ID = "BS", Value = "Bahamas" });
            _cardcountry.Add(new PassengerCountry { ID = "BH", Value = "Bahrain" });
            _cardcountry.Add(new PassengerCountry { ID = "BD", Value = "Bangladesh" });
            _cardcountry.Add(new PassengerCountry { ID = "BB", Value = "Barbados" });
            _cardcountry.Add(new PassengerCountry { ID = "BY", Value = "Belarus" });
            _cardcountry.Add(new PassengerCountry { ID = "BE", Value = "Belgium" });
            _cardcountry.Add(new PassengerCountry { ID = "BZ", Value = "Belize" });
            _cardcountry.Add(new PassengerCountry { ID = "BJ", Value = "Benin" });
            _cardcountry.Add(new PassengerCountry { ID = "BM", Value = "Bermuda" });
            _cardcountry.Add(new PassengerCountry { ID = "BT", Value = "Bhutan" });
            _cardcountry.Add(new PassengerCountry { ID = "BO", Value = "Bolivia" });
            _cardcountry.Add(new PassengerCountry { ID = "BA", Value = "Bosnia and Herzegovina" });
            _cardcountry.Add(new PassengerCountry { ID = "BW", Value = "Botswana" });
            _cardcountry.Add(new PassengerCountry { ID = "BV", Value = "Bouvet Island" });
            _cardcountry.Add(new PassengerCountry { ID = "BR", Value = "Brazil" });
            _cardcountry.Add(new PassengerCountry { ID = "IO", Value = "British Indian Ocean Territory" });
            _cardcountry.Add(new PassengerCountry { ID = "BN", Value = "Brunei Darussalam" });
            _cardcountry.Add(new PassengerCountry { ID = "BG", Value = "Bulgaria" });
            _cardcountry.Add(new PassengerCountry { ID = "BF", Value = "Burkina Faso" });
            _cardcountry.Add(new PassengerCountry { ID = "BI", Value = "Burundi" });
            _cardcountry.Add(new PassengerCountry { ID = "KH", Value = "Cambodia" });
            _cardcountry.Add(new PassengerCountry { ID = "CM", Value = "Cameroon" });
            _cardcountry.Add(new PassengerCountry { ID = "CA", Value = "Canada" });
            _cardcountry.Add(new PassengerCountry { ID = "CV", Value = "Cape Verde" });
            _cardcountry.Add(new PassengerCountry { ID = "KY", Value = "Cayman Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "CF", Value = "Central African Republic" });
            _cardcountry.Add(new PassengerCountry { ID = "TD", Value = "Chad" });
            _cardcountry.Add(new PassengerCountry { ID = "CL", Value = "Chile" });
            _cardcountry.Add(new PassengerCountry { ID = "CN", Value = "China" });
            _cardcountry.Add(new PassengerCountry { ID = "CX", Value = "Christmas Island" });
            _cardcountry.Add(new PassengerCountry { ID = "CC", Value = "Cocos (Keeling) Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "CO", Value = "Colombia" });
            _cardcountry.Add(new PassengerCountry { ID = "KM", Value = "Comoros" });
            _cardcountry.Add(new PassengerCountry { ID = "CG", Value = "Congo" });
            _cardcountry.Add(new PassengerCountry { ID = "CD", Value = "Congo The Democratic Republic of the" });
            _cardcountry.Add(new PassengerCountry { ID = "CK", Value = "Cook Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "CR", Value = "Costa Rica" });
            _cardcountry.Add(new PassengerCountry { ID = "CI", Value = "Côte d'Ivoire" });
            _cardcountry.Add(new PassengerCountry { ID = "HR", Value = "Croatia" });
            _cardcountry.Add(new PassengerCountry { ID = "CU", Value = "Cuba" });
            _cardcountry.Add(new PassengerCountry { ID = "CY", Value = "Cyprus" });
            _cardcountry.Add(new PassengerCountry { ID = "CZ", Value = "Czech Republic" });
            _cardcountry.Add(new PassengerCountry { ID = "DK", Value = "Denmark" });
            _cardcountry.Add(new PassengerCountry { ID = "DJ", Value = "Djibouti" });
            _cardcountry.Add(new PassengerCountry { ID = "DM", Value = "Dominica" });
            _cardcountry.Add(new PassengerCountry { ID = "DO", Value = "Dominican Republic" });
            _cardcountry.Add(new PassengerCountry { ID = "EC", Value = "Ecuador" });
            _cardcountry.Add(new PassengerCountry { ID = "EG", Value = "Egypt" });
            _cardcountry.Add(new PassengerCountry { ID = "SV", Value = "El Salvador" });
            _cardcountry.Add(new PassengerCountry { ID = "GQ", Value = "Equatorial Guinea" });
            _cardcountry.Add(new PassengerCountry { ID = "ER", Value = "Eritrea" });
            _cardcountry.Add(new PassengerCountry { ID = "EE", Value = "Estonia" });
            _cardcountry.Add(new PassengerCountry { ID = "ET", Value = "Ethiopia" });
            _cardcountry.Add(new PassengerCountry { ID = "FK", Value = "Falkland Islands (Malvinas)" });
            _cardcountry.Add(new PassengerCountry { ID = "FO", Value = "Faroe Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "FJ", Value = "Fiji" });
            _cardcountry.Add(new PassengerCountry { ID = "FI", Value = "Finland" });
            _cardcountry.Add(new PassengerCountry { ID = "FR", Value = "France" });
            _cardcountry.Add(new PassengerCountry { ID = "GF", Value = "French Guiana" });
            _cardcountry.Add(new PassengerCountry { ID = "PF", Value = "French Polynesia" });
            _cardcountry.Add(new PassengerCountry { ID = "TF", Value = "French Southern Territories" });
            _cardcountry.Add(new PassengerCountry { ID = "GA", Value = "Gabon" });
            _cardcountry.Add(new PassengerCountry { ID = "GM", Value = "Gambia" });
            _cardcountry.Add(new PassengerCountry { ID = "GE", Value = "Georgia" });
            _cardcountry.Add(new PassengerCountry { ID = "DE", Value = "Germany" });
            _cardcountry.Add(new PassengerCountry { ID = "GH", Value = "Ghana" });
            _cardcountry.Add(new PassengerCountry { ID = "GI", Value = "Gibraltar" });
            _cardcountry.Add(new PassengerCountry { ID = "GR", Value = "Greece" });
            _cardcountry.Add(new PassengerCountry { ID = "GL", Value = "Greenland" });
            _cardcountry.Add(new PassengerCountry { ID = "GD", Value = "Grenada" });
            _cardcountry.Add(new PassengerCountry { ID = "GP", Value = "Guadeloupe" });
            _cardcountry.Add(new PassengerCountry { ID = "GU", Value = "Guam" });
            _cardcountry.Add(new PassengerCountry { ID = "GT", Value = "Guatemala" });
            _cardcountry.Add(new PassengerCountry { ID = "GG", Value = "Guernsey" });
            _cardcountry.Add(new PassengerCountry { ID = "GN", Value = "Guinea" });
            _cardcountry.Add(new PassengerCountry { ID = "GW", Value = "Guinea-Bissau" });
            _cardcountry.Add(new PassengerCountry { ID = "GY", Value = "Guyana" });
            _cardcountry.Add(new PassengerCountry { ID = "HT", Value = "Haiti" });
            _cardcountry.Add(new PassengerCountry { ID = "HM", Value = "Heard Island and McDonald Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "VA", Value = "Holy See (Vatican City State)" });
            _cardcountry.Add(new PassengerCountry { ID = "HN", Value = "Honduras" });
            _cardcountry.Add(new PassengerCountry { ID = "HK", Value = "Hong Kong" });
            _cardcountry.Add(new PassengerCountry { ID = "HU", Value = "Hungary" });
            _cardcountry.Add(new PassengerCountry { ID = "IS", Value = "Iceland" });
            _cardcountry.Add(new PassengerCountry { ID = "IN", Value = "India" });
            _cardcountry.Add(new PassengerCountry { ID = "ID", Value = "Indonesia" });
            _cardcountry.Add(new PassengerCountry { ID = "IR", Value = "Iran Islamic Republic of" });
            _cardcountry.Add(new PassengerCountry { ID = "IQ", Value = "Iraq" });
            _cardcountry.Add(new PassengerCountry { ID = "IE", Value = "Ireland" });
            _cardcountry.Add(new PassengerCountry { ID = "IM", Value = "Isle of Man" });
            _cardcountry.Add(new PassengerCountry { ID = "IL", Value = "Israel" });
            _cardcountry.Add(new PassengerCountry { ID = "IT", Value = "Italy" });
            _cardcountry.Add(new PassengerCountry { ID = "JM", Value = "Jamaica" });
            _cardcountry.Add(new PassengerCountry { ID = "JP", Value = "Japan" });
            _cardcountry.Add(new PassengerCountry { ID = "JE", Value = "Jersey" });
            _cardcountry.Add(new PassengerCountry { ID = "JO", Value = "Jordan" });
            _cardcountry.Add(new PassengerCountry { ID = "KZ", Value = "Kazakhstan" });
            _cardcountry.Add(new PassengerCountry { ID = "KE", Value = "Kenya" });
            _cardcountry.Add(new PassengerCountry { ID = "KI", Value = "Kiribati" });
            _cardcountry.Add(new PassengerCountry { ID = "KP", Value = "Korea Democratic People's Republic of" });
            _cardcountry.Add(new PassengerCountry { ID = "KR", Value = "Korea Republic of" });
            _cardcountry.Add(new PassengerCountry { ID = "KW", Value = "Kuwait" });
            _cardcountry.Add(new PassengerCountry { ID = "KG", Value = "Kyrgyzstan" });
            _cardcountry.Add(new PassengerCountry { ID = "LA", Value = "Lao People's Democratic Republic" });
            _cardcountry.Add(new PassengerCountry { ID = "LV", Value = "Latvia" });
            _cardcountry.Add(new PassengerCountry { ID = "LB", Value = "Lebanon" });
            _cardcountry.Add(new PassengerCountry { ID = "LS", Value = "Lesotho" });
            _cardcountry.Add(new PassengerCountry { ID = "LR", Value = "Liberia" });
            _cardcountry.Add(new PassengerCountry { ID = "LY", Value = "Libyan Arab Jamahiriya" });
            _cardcountry.Add(new PassengerCountry { ID = "LI", Value = "Liechtenstein" });
            _cardcountry.Add(new PassengerCountry { ID = "LT", Value = "Lithuania" });
            _cardcountry.Add(new PassengerCountry { ID = "LU", Value = "Luxembourg" });
            _cardcountry.Add(new PassengerCountry { ID = "MO", Value = "Macao" });
            _cardcountry.Add(new PassengerCountry { ID = "MK", Value = "Macedonia The Former Yugoslav Republic of" });
            _cardcountry.Add(new PassengerCountry { ID = "MG", Value = "Madagascar" });
            _cardcountry.Add(new PassengerCountry { ID = "MW", Value = "Malawi" });
            _cardcountry.Add(new PassengerCountry { ID = "MY", Value = "Malaysia" });
            _cardcountry.Add(new PassengerCountry { ID = "MV", Value = "Maldives" });
            _cardcountry.Add(new PassengerCountry { ID = "ML", Value = "Mali" });
            _cardcountry.Add(new PassengerCountry { ID = "MT", Value = "Malta" });
            _cardcountry.Add(new PassengerCountry { ID = "MH", Value = "Marshall Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "MQ", Value = "Martinique" });
            _cardcountry.Add(new PassengerCountry { ID = "MR", Value = "Mauritania" });
            _cardcountry.Add(new PassengerCountry { ID = "MU", Value = "Mauritius" });
            _cardcountry.Add(new PassengerCountry { ID = "MT", Value = "Mayotte" });
            _cardcountry.Add(new PassengerCountry { ID = "MX", Value = "Mexico" });
            _cardcountry.Add(new PassengerCountry { ID = "FM", Value = "Microneia Federated States of" });
            _cardcountry.Add(new PassengerCountry { ID = "MD", Value = "Moldova" });
            _cardcountry.Add(new PassengerCountry { ID = "MC", Value = "Monaco" });
            _cardcountry.Add(new PassengerCountry { ID = "MN", Value = "Mongolia" });
            _cardcountry.Add(new PassengerCountry { ID = "ME", Value = "Montenegro" });
            _cardcountry.Add(new PassengerCountry { ID = "MS", Value = "Montserrat" });
            _cardcountry.Add(new PassengerCountry { ID = "MA", Value = "Morocco" });
            _cardcountry.Add(new PassengerCountry { ID = "MZ", Value = "Mozambique" });
            _cardcountry.Add(new PassengerCountry { ID = "MM", Value = "Myanmar" });
            _cardcountry.Add(new PassengerCountry { ID = "NA", Value = "Namibia" });
            _cardcountry.Add(new PassengerCountry { ID = "NR", Value = "Nauru" });
            _cardcountry.Add(new PassengerCountry { ID = "NP", Value = "Nepal" });
            _cardcountry.Add(new PassengerCountry { ID = "NL", Value = "Netherlands" });
            _cardcountry.Add(new PassengerCountry { ID = "AN", Value = "Netherlands Antilles" });
            _cardcountry.Add(new PassengerCountry { ID = "NC", Value = "New Caledonia" });
            _cardcountry.Add(new PassengerCountry { ID = "NZ", Value = "New Zealand" });
            _cardcountry.Add(new PassengerCountry { ID = "NI", Value = "Nicaragua" });
            _cardcountry.Add(new PassengerCountry { ID = "NE", Value = "Niger" });
            _cardcountry.Add(new PassengerCountry { ID = "NG", Value = "Nigeria" });
            _cardcountry.Add(new PassengerCountry { ID = "NU", Value = "Niue" });
            _cardcountry.Add(new PassengerCountry { ID = "NF", Value = "Norfolk Island" });
            _cardcountry.Add(new PassengerCountry { ID = "MP", Value = "Northern Mariana Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "NO", Value = "Norway" });
            _cardcountry.Add(new PassengerCountry { ID = "OM", Value = "Oman" });
            _cardcountry.Add(new PassengerCountry { ID = "PK", Value = "Pakistan" });
            _cardcountry.Add(new PassengerCountry { ID = "PW", Value = "Palau" });
            _cardcountry.Add(new PassengerCountry { ID = "PS", Value = "Palestinian Territory Occupied" });
            _cardcountry.Add(new PassengerCountry { ID = "PA", Value = "Panama" });
            _cardcountry.Add(new PassengerCountry { ID = "PG", Value = "Papua New Guinea" });
            _cardcountry.Add(new PassengerCountry { ID = "PY", Value = "Paraguay" });
            _cardcountry.Add(new PassengerCountry { ID = "PE", Value = "Peru" });
            _cardcountry.Add(new PassengerCountry { ID = "PH", Value = "Philippines" });
            _cardcountry.Add(new PassengerCountry { ID = "PN", Value = "Pitcairn" });
            _cardcountry.Add(new PassengerCountry { ID = "PL", Value = "Poland" });
            _cardcountry.Add(new PassengerCountry { ID = "PT", Value = "Portugal" });
            _cardcountry.Add(new PassengerCountry { ID = "PR", Value = "Puerto Rico" });
            _cardcountry.Add(new PassengerCountry { ID = "QA", Value = "Qatar" });
            _cardcountry.Add(new PassengerCountry { ID = "RE", Value = "Réunion" });
            _cardcountry.Add(new PassengerCountry { ID = "RO", Value = "Romania" });
            _cardcountry.Add(new PassengerCountry { ID = "RU", Value = "Russian Federation" });
            _cardcountry.Add(new PassengerCountry { ID = "RW", Value = "Rwanda" });
            _cardcountry.Add(new PassengerCountry { ID = "BL", Value = "Saint Barthélemy" });
            _cardcountry.Add(new PassengerCountry { ID = "SH", Value = "Saint Helena" });
            _cardcountry.Add(new PassengerCountry { ID = "KN", Value = "Saint Kitts and Nevis" });
            _cardcountry.Add(new PassengerCountry { ID = "LC", Value = "Saint Lucia" });
            _cardcountry.Add(new PassengerCountry { ID = "MF", Value = "Saint Martin" });
            _cardcountry.Add(new PassengerCountry { ID = "PM", Value = "Saint Pierre and Miquelon" });
            _cardcountry.Add(new PassengerCountry { ID = "VC", Value = "Saint Vincent and the Grenadines" });
            _cardcountry.Add(new PassengerCountry { ID = "WS", Value = "Samoa" });
            _cardcountry.Add(new PassengerCountry { ID = "SM", Value = "San Marino" });
            _cardcountry.Add(new PassengerCountry { ID = "ST", Value = "Sao Tome and Principe" });
            _cardcountry.Add(new PassengerCountry { ID = "SA", Value = "Saudi Arabia" });
            _cardcountry.Add(new PassengerCountry { ID = "SN", Value = "Senegal" });
            _cardcountry.Add(new PassengerCountry { ID = "RS", Value = "Serbia" });
            _cardcountry.Add(new PassengerCountry { ID = "SC", Value = "Seychelles" });
            _cardcountry.Add(new PassengerCountry { ID = "SL", Value = "Sierra Leone" });
            _cardcountry.Add(new PassengerCountry { ID = "SG", Value = "Singapore" });
            _cardcountry.Add(new PassengerCountry { ID = "SK", Value = "Slovakia" });
            _cardcountry.Add(new PassengerCountry { ID = "SI", Value = "Slovenia" });
            _cardcountry.Add(new PassengerCountry { ID = "SB", Value = "Solomon Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "SO", Value = "Somalia" });
            _cardcountry.Add(new PassengerCountry { ID = "ZA", Value = "South Africa" });
            _cardcountry.Add(new PassengerCountry { ID = "GS", Value = "South Georgia and the South Sandwich Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "ES", Value = "Spain" });
            _cardcountry.Add(new PassengerCountry { ID = "LK", Value = "Sri Lanka" });
            _cardcountry.Add(new PassengerCountry { ID = "SD", Value = "Sudan" });
            _cardcountry.Add(new PassengerCountry { ID = "SR", Value = "Suriname" });
            _cardcountry.Add(new PassengerCountry { ID = "SJ", Value = "Svalbard and Jan Mayen" });
            _cardcountry.Add(new PassengerCountry { ID = "SZ", Value = "Swaziland" });
            _cardcountry.Add(new PassengerCountry { ID = "SE", Value = "Sweden" });
            _cardcountry.Add(new PassengerCountry { ID = "CH", Value = "Switzerland" });
            _cardcountry.Add(new PassengerCountry { ID = "SY", Value = "Syrian Arab Republic" });
            _cardcountry.Add(new PassengerCountry { ID = "TW", Value = "Taiwan Province of China" });
            _cardcountry.Add(new PassengerCountry { ID = "TJ", Value = "Tajikistan" });
            _cardcountry.Add(new PassengerCountry { ID = "TZ", Value = "Tanzania United Republic of" });
            _cardcountry.Add(new PassengerCountry { ID = "TH", Value = "Thailand" });
            _cardcountry.Add(new PassengerCountry { ID = "TL", Value = "Timor-Leste" });
            _cardcountry.Add(new PassengerCountry { ID = "TG", Value = "Togo" });
            _cardcountry.Add(new PassengerCountry { ID = "TK", Value = "Tokelau" });
            _cardcountry.Add(new PassengerCountry { ID = "TO", Value = "Tonga" });
            _cardcountry.Add(new PassengerCountry { ID = "TT", Value = "Trinidad and Tobago" });
            _cardcountry.Add(new PassengerCountry { ID = "TN", Value = "Tunisia" });
            _cardcountry.Add(new PassengerCountry { ID = "TR", Value = "Turkey" });
            _cardcountry.Add(new PassengerCountry { ID = "TM", Value = "Turkmenistan" });
            _cardcountry.Add(new PassengerCountry { ID = "TC", Value = "Turks and Caicos Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "TV", Value = "Tuvalu" });
            _cardcountry.Add(new PassengerCountry { ID = "UG", Value = "Uganda" });
            _cardcountry.Add(new PassengerCountry { ID = "UA", Value = "Ukraine" });
            _cardcountry.Add(new PassengerCountry { ID = "AE", Value = "United Arab Emirates" });
            _cardcountry.Add(new PassengerCountry { ID = "GB", Value = "United Kingdom" });
            _cardcountry.Add(new PassengerCountry { ID = "US", Value = "United States" });
            _cardcountry.Add(new PassengerCountry { ID = "UM", Value = "United States Minor Outlying Islands" });
            _cardcountry.Add(new PassengerCountry { ID = "UY", Value = "Uruguay" });
            _cardcountry.Add(new PassengerCountry { ID = "UZ", Value = "Uzbekistan" });
            _cardcountry.Add(new PassengerCountry { ID = "VU", Value = "Vanuatu" });
            _cardcountry.Add(new PassengerCountry { ID = "VE", Value = "Venezuela" });
            _cardcountry.Add(new PassengerCountry { ID = "VN", Value = "Viet Nam" });
            _cardcountry.Add(new PassengerCountry { ID = "VG", Value = "Virgin Islands British" });
            _cardcountry.Add(new PassengerCountry { ID = "VI", Value = "Virgin Islands U.S." });
            _cardcountry.Add(new PassengerCountry { ID = "WF", Value = "Wallis and Futuna" });
            _cardcountry.Add(new PassengerCountry { ID = "EH", Value = "Western Sahara" });
            _cardcountry.Add(new PassengerCountry { ID = "YE", Value = "Yemen" });
            _cardcountry.Add(new PassengerCountry { ID = "ZM", Value = "Zambia" });
            _cardcountry.Add(new PassengerCountry { ID = "ZW", Value = "Zimbabwe" });
            return _cardcountry;
        }
        #endregion
    }

    public class Title
    {
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Title")]
        //[MustBeSelectedAttribute(ErrorMessageResourceType = typeof(Resources.Notifications),ErrorMessageResourceName = "SelectTitle")]
        public string ID { get; set; }
        public string Value { get; set; }
        public string Selected { get; set; }
    }
    public class Day
    {
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Day")]
        //[MustBeSelectedAttribute(ErrorMessageResourceType = typeof(Resources.Notifications), ErrorMessageResourceName = "SelectDay")]
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Month
    {
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Month")]
        //[MustBeSelectedAttribute(ErrorMessageResourceType = typeof(Resources.Notifications), ErrorMessageResourceName = "SelectMonth")]
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Year
    {
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Year")]
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Gender
    {
        [MustBeSelectedAttribute(ErrorMessage = "Please Select Gender")]
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Meal
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class MealName
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Seat
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class SeatName
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class FreqFlyerAirline
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class FreqFlyerNo
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Country
    {
        [MustBeSelectedAttribute(ErrorMessage = "Select Country")]
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class CountryCode
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }


    public class MustBeSelectedAttribute : ValidationAttribute, IClientValidatable // IClientValidatable for client side Validation
    {
        public override bool IsValid(object value)
        {
            if (value == null || (string)value == "0")
                return false;
            else
                return true;
        }
        // Implement IClientValidatable for client side Validation
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "dropdown", ErrorMessage = this.ErrorMessage } };
        }
    }

    public class Adult_Pax
    {
        public Title Title { get; set; }
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public Day Day { get; set; }
        public Month Month { get; set; }
        public Year Year { get; set; }
        public Gender Gender { get; set; }
        public Meal Meal { get; set; }
        public MealName MealName { get; set; }
        public Seat Seat { get; set; }
        public SeatName SeatName { get; set; }
        public FreqFlyerAirline FreqFlyerAirline { get; set; }
        public FreqFlyerNo FreqFlyerNo { get; set; }
        public BaggageData BaggageData { get; set; }
        public Country Country { get; set; }
        public CountryCode CountryCode { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9]+[ a-zA-Z-_]*.{2,}$", ErrorMessage = "Enter Valid Passport No")]
        [Required(ErrorMessage = "Enter Passport No")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Enter Issue Date")]
        public string IssueDate { get; set; }

        [Required(ErrorMessage = "Enter Expiry Date")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public string Passenger_countrylist { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*.{1,}$", ErrorMessage = "Enter Valid Issue City")]
        [Required(ErrorMessage = "Enter Issue City")]
        public string IssueCity { get; set; }

        [Required(ErrorMessage = "Enter Contact No")]
        public string ContactNo { get; set; }
        [RegularExpression(@"^[0-9]*.{10,}$", ErrorMessage = "Enter Valid MobileNo")]
        [Required(ErrorMessage = "Enter Mobile No")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Enter Email Address")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Enter Correct Email Address")]
        public string Email { get; set; }

    }
    public class Child_Pax
    {
        public Title Title { get; set; }
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Day Day { get; set; }
        public Month Month { get; set; }
        public Year Year { get; set; }
        public Gender Gender { get; set; }
        public Meal Meal { get; set; }
        public Seat Seat { get; set; }
        public MealName MealName { get; set; }
        public SeatName SeatName { get; set; }
        public BaggageData BaggageData { get; set; }
        public Country Country { get; set; }
        public CountryCode CountryCode { get; set; }
        [Required(ErrorMessage = "Enter Passport No")]
        public string Passport { get; set; }
        [Required(ErrorMessage = "Enter Issue Date")]
        public string IssueDate { get; set; }

        [Required(ErrorMessage = "Enter Expiry Date")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public string Passenger_countrylist { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*.{1,}$", ErrorMessage = "Enter Valid Issue City")]
        [Required(ErrorMessage = "Enter Issue City")]
        public string IssueCity { get; set; }
    }
    public class Infant_Pax
    {
        public Title Title { get; set; }
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Day Day { get; set; }
        public Month Month { get; set; }
        public Year Year { get; set; }
        public Gender Gender { get; set; }
        public Meal Meal { get; set; }
        public Seat Seat { get; set; }
        public MealName MealName { get; set; }
        public SeatName SeatName { get; set; }
        public Country Country { get; set; }
        public CountryCode CountryCode { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]+[ a-zA-Z-_]*.{2,}$", ErrorMessage = "Enter Valid Passport No")]
        [Required(ErrorMessage = "Enter Passport No")]
        public string Passport { get; set; }

        [Required(ErrorMessage = "Enter Issue Date")]
        public string IssueDate { get; set; }

        [Required(ErrorMessage = "Enter Expiry Date")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "Please Select Country")]
        public string Passenger_countrylist { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*.{1,}$", ErrorMessage = "Enter Valid Issue City")]
        [Required(ErrorMessage = "Enter Issue City")]
        public string IssueCity { get; set; }
    }
    public class Billing_Field
    {
        [Required(ErrorMessage = "Please Enter First Name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Address Line 1")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Please Enter Postal Code")]
        public string PostalCode { get; set; }
        public string AddressLine2 { get; set; }
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string CState { get; set; }
        [Required(ErrorMessage = "Please Enter Your City")]
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public string City { get; set; }
        [RegularExpression("([a-zA-Z .&'-]+)", ErrorMessage = "Enter only alphabets")]
        public Country Country { get; set; }
    }

    public class Passanger_Field
    {
        #region Title
        public static List<Title> titleList()
        {
            List<Title> _title = new List<Title>();
            _title.Add(new Title { ID = null, Value = "Select" });
            _title.Add(new Title { ID = "Mr", Value = "Mr" });
            _title.Add(new Title { ID = "Mstr", Value = "Master" });
            _title.Add(new Title { ID = "Mrs", Value = "Mrs" });
            _title.Add(new Title { ID = "Miss", Value = "Miss" });
            _title.Add(new Title { ID = "Dr", Value = "Dr" });

            return _title;
        }

        public static List<Title> titleadultList()
        {
            List<Title> _title = new List<Title>();
            _title.Add(new Title { ID = null, Value = "Select" });
            _title.Add(new Title { ID = "Mr", Value = "Mr" });
            _title.Add(new Title { ID = "Mrs", Value = "Mrs" });
            _title.Add(new Title { ID = "Miss", Value = "Miss" });
            _title.Add(new Title { ID = "Dr", Value = "Dr" });

            return _title;
        }
        public static List<Title> titlechildList()
        {
            List<Title> _title = new List<Title>();
            _title.Add(new Title { ID = null, Value = "Select" });
            _title.Add(new Title { ID = "Mstr", Value = "Mstr" });
            _title.Add(new Title { ID = "Miss", Value = "Miss" });
            return _title;
        }
        public static List<Title> titleinfantList()
        {
            List<Title> _title = new List<Title>();
            _title.Add(new Title { ID = null, Value = "Select" });
            _title.Add(new Title { ID = "Mstr", Value = "Mstr" });
            _title.Add(new Title { ID = "Miss", Value = "Miss" });


            return _title;
        }
        #endregion
        #region Day
        //  for (int i = System.DateTime.Now.Year - 11; i >= System.DateTime.Now.Year - 100; i--)
        public static List<Day> DayList()
        {
            List<Day> _ListDay = new System.Collections.Generic.List<Day>();
            _ListDay.Add(new Day { ID = null, Value = "Day" });
            for (int i = 1; i < 32; i++)
            {
                //_ListDay.Add(new Day { ID = "" + i + "", Value = "" + i + "" });
                if (i > 0 && i < 10)
                {
                    _ListDay.Add(new Day { ID = "" + "0" + i + "", Value = "" + "0" + i + "" });
                }
                else
                {
                    _ListDay.Add(new Day { ID = "" + i + "", Value = "" + i + "" });
                }
            }
            return _ListDay;
        }
        #endregion
        #region Month
        public static List<Month> MonthList()
        {
            List<Month> _ListMonth = new System.Collections.Generic.List<Month>();
            _ListMonth.Add(new Month { ID = null, Value = "Month" });
            _ListMonth.Add(new Month { ID = "01", Value = "JAN" });
            _ListMonth.Add(new Month { ID = "02", Value = "FEB" });
            _ListMonth.Add(new Month { ID = "03", Value = "MAR" });
            _ListMonth.Add(new Month { ID = "04", Value = "APR" });
            _ListMonth.Add(new Month { ID = "05", Value = "MAY" });
            _ListMonth.Add(new Month { ID = "06", Value = "JUN" });
            _ListMonth.Add(new Month { ID = "07", Value = "JUL" });
            _ListMonth.Add(new Month { ID = "08", Value = "AUG" });
            _ListMonth.Add(new Month { ID = "09", Value = "SEP" });
            _ListMonth.Add(new Month { ID = "10", Value = "OCT" });
            _ListMonth.Add(new Month { ID = "11", Value = "NOV" });
            _ListMonth.Add(new Month { ID = "12", Value = "DEC" });
            return _ListMonth;
        }
        #endregion
        #region Adult Year
        public static List<Year> AdultYear()
        {
            List<Year> _ListAdultYr = new System.Collections.Generic.List<Year>();
            _ListAdultYr.Add(new Year { ID = null, Value = "Year" });
            for (int i = System.DateTime.Now.Year - 18; i >= System.DateTime.Now.Year - 100; i--)
            {
                _ListAdultYr.Add(new Year { ID = "" + i + "", Value = "" + i + "" });
            }
            return _ListAdultYr;
        }
        #endregion
        #region child Year
        public static List<Year> ChildYear()
        {
            List<Year> _ListChildYr = new System.Collections.Generic.List<Year>();
            _ListChildYr.Add(new Year { ID = null, Value = "Year" });
            int Start = System.DateTime.Now.Year;
            int End = System.DateTime.Now.Year - 12;
            for (int i = Start; i >= End; i--)
            {
                _ListChildYr.Add(new Year { ID = "" + i + "", Value = "" + i + "" });
            }
            return _ListChildYr;
        }
        #endregion
        #region infant Year
        public static List<Year> InfantYear()
        {
            List<Year> _ListInfantYr = new System.Collections.Generic.List<Year>();
            _ListInfantYr.Add(new Year { ID = null, Value = "Year" });
            for (int i = System.DateTime.Now.Year; i >= System.DateTime.Now.Year - 2; i--)
            {
                _ListInfantYr.Add(new Year { ID = "" + i + "", Value = "" + i + "" });
            }
            return _ListInfantYr;
        }
        #endregion
        #region Seat List
        public static List<Seat> SeatList()
        {
            List<Seat> _ListSeat = new System.Collections.Generic.List<Seat>();
            _ListSeat.Add(new Seat { ID = "0", Value = "Any" });
            _ListSeat.Add(new Seat { ID = "A", Value = "AisleSeat" });
            _ListSeat.Add(new Seat { ID = "B", Value = "BulkheadSeat" });
            _ListSeat.Add(new Seat { ID = "C", Value = "Cot" });
            _ListSeat.Add(new Seat { ID = "E", Value = "ExitSeat" });
            _ListSeat.Add(new Seat { ID = "R", Value = "RearfacingSeat" });
            _ListSeat.Add(new Seat { ID = "P", Value = "UpperDeck" });
            _ListSeat.Add(new Seat { ID = "W", Value = "WindowSeat" });

            return _ListSeat;
        }
        #endregion
        #region Meal List

        public static List<Meal> MealList()
        {
            List<Meal> _ListMeal = new System.Collections.Generic.List<Meal>();
            _ListMeal.Add(new Meal { ID = "0", Value = "Any" });
            _ListMeal.Add(new Meal { ID = "AVML", Value = "AsianVeg" });
            _ListMeal.Add(new Meal { ID = "BBML", Value = "BabyInfantFood" });
            _ListMeal.Add(new Meal { ID = "BLML", Value = "BlandMeal" });
            _ListMeal.Add(new Meal { ID = "CHML", Value = "ChildMeal" });
            _ListMeal.Add(new Meal { ID = "DBML", Value = "Diabetic" });
            _ListMeal.Add(new Meal { ID = "FPML", Value = "FruitMeal" });
            _ListMeal.Add(new Meal { ID = "GFML", Value = "GlutenFree" });
            _ListMeal.Add(new Meal { ID = "HFML", Value = "HighFiber" });
            _ListMeal.Add(new Meal { ID = "HNML", Value = "HinduMeal" });
            _ListMeal.Add(new Meal { ID = "KSML", Value = "Kosher" });
            _ListMeal.Add(new Meal { ID = "LCML", Value = "LowCalorie" });
            _ListMeal.Add(new Meal { ID = "LFML", Value = "LowCholesterol" });
            _ListMeal.Add(new Meal { ID = "LPML", Value = "LowProtein" });
            _ListMeal.Add(new Meal { ID = "LSML", Value = "LowSodiumNoSa" });
            _ListMeal.Add(new Meal { ID = "MOML", Value = "Moslem" });
            _ListMeal.Add(new Meal { ID = "NLML", Value = "NonLactose" });
            _ListMeal.Add(new Meal { ID = "ORML", Value = "Oriental" });
            _ListMeal.Add(new Meal { ID = "PRML", Value = "LowPurin" });
            _ListMeal.Add(new Meal { ID = "RVML", Value = "RawVegetarian" });
            _ListMeal.Add(new Meal { ID = "SFML", Value = "Seafood" });
            _ListMeal.Add(new Meal { ID = "VGML", Value = "VegetarianNonDairy" });
            _ListMeal.Add(new Meal { ID = "VLML", Value = "VegetarianMilkEggs" });


            return _ListMeal;
        }
        #endregion
        #region Gender List
        public static List<Gender> genderList()
        {
            List<Gender> _ListGender = new System.Collections.Generic.List<Gender>();
            _ListGender.Add(new Gender { ID = null, Value = "Select" });
            _ListGender.Add(new Gender { ID = "M", Value = "Male" });
            _ListGender.Add(new Gender { ID = "F", Value = "Female" });
            return _ListGender;
        }
        #endregion
        #region Country
        public static List<Country> CountryList()
        {
            List<Country> _country = new List<Country>();
            _country.Add(new Country { ID = null, Value = "Select" });
            _country.Add(new Country { ID = "AF", Value = "Afghanistan" });
            _country.Add(new Country { ID = "AX", Value = "Aland Islands" });
            _country.Add(new Country { ID = "AL", Value = "Albania" });
            _country.Add(new Country { ID = "DZ", Value = "Algeria" });
            _country.Add(new Country { ID = "AS", Value = "American Samoa" });
            _country.Add(new Country { ID = "AD", Value = "Andorra" });
            _country.Add(new Country { ID = "AO", Value = "Angola" });
            _country.Add(new Country { ID = "AI", Value = "Anguilla" });
            _country.Add(new Country { ID = "AQ", Value = "Antarctica" });
            _country.Add(new Country { ID = "AG", Value = "Antigua and Barbuda" });
            _country.Add(new Country { ID = "AR", Value = "Argentina" });
            _country.Add(new Country { ID = "AM", Value = "Armenia" });
            _country.Add(new Country { ID = "AW", Value = "Aruba" });
            _country.Add(new Country { ID = "AU", Value = "Australia" });
            _country.Add(new Country { ID = "AT", Value = "Austria" });
            _country.Add(new Country { ID = "AZ", Value = "Azerbaijan" });
            _country.Add(new Country { ID = "BS", Value = "Bahamas" });
            _country.Add(new Country { ID = "BH", Value = "Bahrain" });
            _country.Add(new Country { ID = "BD", Value = "Bangladesh" });
            _country.Add(new Country { ID = "BB", Value = "Barbados" });
            _country.Add(new Country { ID = "BY", Value = "Belarus" });
            _country.Add(new Country { ID = "BE", Value = "Belgium" });
            _country.Add(new Country { ID = "BZ", Value = "Belize" });
            _country.Add(new Country { ID = "BJ", Value = "Benin" });
            _country.Add(new Country { ID = "BM", Value = "Bermuda" });
            _country.Add(new Country { ID = "BT", Value = "Bhutan" });
            _country.Add(new Country { ID = "BO", Value = "Bolivia" });
            _country.Add(new Country { ID = "BA", Value = "Bosnia and Herzegovina" });
            _country.Add(new Country { ID = "BW", Value = "Botswana" });
            _country.Add(new Country { ID = "BV", Value = "Bouvet Island" });
            _country.Add(new Country { ID = "BR", Value = "Brazil" });
            _country.Add(new Country { ID = "IO", Value = "British Indian Ocean Territory" });
            _country.Add(new Country { ID = "BN", Value = "Brunei Darussalam" });
            _country.Add(new Country { ID = "BG", Value = "Bulgaria" });
            _country.Add(new Country { ID = "BF", Value = "Burkina Faso" });
            _country.Add(new Country { ID = "BI", Value = "Burundi" });
            _country.Add(new Country { ID = "KH", Value = "Cambodia" });
            _country.Add(new Country { ID = "CM", Value = "Cameroon" });
            _country.Add(new Country { ID = "CA", Value = "Canada" });
            _country.Add(new Country { ID = "CV", Value = "Cape Verde" });
            _country.Add(new Country { ID = "KY", Value = "Cayman Islands" });
            _country.Add(new Country { ID = "CF", Value = "Central African Republic" });
            _country.Add(new Country { ID = "TD", Value = "Chad" });
            _country.Add(new Country { ID = "CL", Value = "Chile" });
            _country.Add(new Country { ID = "CN", Value = "China" });
            _country.Add(new Country { ID = "CX", Value = "Christmas Island" });
            _country.Add(new Country { ID = "CC", Value = "Cocos (Keeling) Islands" });
            _country.Add(new Country { ID = "CO", Value = "Colombia" });
            _country.Add(new Country { ID = "KM", Value = "Comoros" });
            _country.Add(new Country { ID = "CG", Value = "Congo" });
            _country.Add(new Country { ID = "CD", Value = "Congo The Democratic Republic of the" });
            _country.Add(new Country { ID = "CK", Value = "Cook Islands" });
            _country.Add(new Country { ID = "CR", Value = "Costa Rica" });
            _country.Add(new Country { ID = "CI", Value = "Côte d'Ivoire" });
            _country.Add(new Country { ID = "HR", Value = "Croatia" });
            _country.Add(new Country { ID = "CU", Value = "Cuba" });
            _country.Add(new Country { ID = "CY", Value = "Cyprus" });
            _country.Add(new Country { ID = "CZ", Value = "Czech Republic" });
            _country.Add(new Country { ID = "DK", Value = "Denmark" });
            _country.Add(new Country { ID = "DJ", Value = "Djibouti" });
            _country.Add(new Country { ID = "DM", Value = "Dominica" });
            _country.Add(new Country { ID = "DO", Value = "Dominican Republic" });
            _country.Add(new Country { ID = "EC", Value = "Ecuador" });
            _country.Add(new Country { ID = "EG", Value = "Egypt" });
            _country.Add(new Country { ID = "SV", Value = "El Salvador" });
            _country.Add(new Country { ID = "GQ", Value = "Equatorial Guinea" });
            _country.Add(new Country { ID = "ER", Value = "Eritrea" });
            _country.Add(new Country { ID = "EE", Value = "Estonia" });
            _country.Add(new Country { ID = "ET", Value = "Ethiopia" });
            _country.Add(new Country { ID = "FK", Value = "Falkland Islands (Malvinas)" });
            _country.Add(new Country { ID = "FO", Value = "Faroe Islands" });
            _country.Add(new Country { ID = "FJ", Value = "Fiji" });
            _country.Add(new Country { ID = "FI", Value = "Finland" });
            _country.Add(new Country { ID = "FR", Value = "France" });
            _country.Add(new Country { ID = "GF", Value = "French Guiana" });
            _country.Add(new Country { ID = "PF", Value = "French Polynesia" });
            _country.Add(new Country { ID = "TF", Value = "French Southern Territories" });
            _country.Add(new Country { ID = "GA", Value = "Gabon" });
            _country.Add(new Country { ID = "GM", Value = "Gambia" });
            _country.Add(new Country { ID = "GE", Value = "Georgia" });
            _country.Add(new Country { ID = "DE", Value = "Germany" });
            _country.Add(new Country { ID = "GH", Value = "Ghana" });
            _country.Add(new Country { ID = "GI", Value = "Gibraltar" });
            _country.Add(new Country { ID = "GR", Value = "Greece" });
            _country.Add(new Country { ID = "GL", Value = "Greenland" });
            _country.Add(new Country { ID = "GD", Value = "Grenada" });
            _country.Add(new Country { ID = "GP", Value = "Guadeloupe" });
            _country.Add(new Country { ID = "GU", Value = "Guam" });
            _country.Add(new Country { ID = "GT", Value = "Guatemala" });
            _country.Add(new Country { ID = "GG", Value = "Guernsey" });
            _country.Add(new Country { ID = "GN", Value = "Guinea" });
            _country.Add(new Country { ID = "GW", Value = "Guinea-Bissau" });
            _country.Add(new Country { ID = "GY", Value = "Guyana" });
            _country.Add(new Country { ID = "HT", Value = "Haiti" });
            _country.Add(new Country { ID = "HM", Value = "Heard Island and McDonald Islands" });
            _country.Add(new Country { ID = "VA", Value = "Holy See (Vatican City State)" });
            _country.Add(new Country { ID = "HN", Value = "Honduras" });
            _country.Add(new Country { ID = "HK", Value = "Hong Kong" });
            _country.Add(new Country { ID = "HU", Value = "Hungary" });
            _country.Add(new Country { ID = "IS", Value = "Iceland" });
            _country.Add(new Country { ID = "IN", Value = "India" });
            _country.Add(new Country { ID = "ID", Value = "Indonesia" });
            _country.Add(new Country { ID = "IR", Value = "Iran Islamic Republic of" });
            _country.Add(new Country { ID = "IQ", Value = "Iraq" });
            _country.Add(new Country { ID = "IE", Value = "Ireland" });
            _country.Add(new Country { ID = "IM", Value = "Isle of Man" });
            _country.Add(new Country { ID = "IL", Value = "Israel" });
            _country.Add(new Country { ID = "IT", Value = "Italy" });
            _country.Add(new Country { ID = "JM", Value = "Jamaica" });
            _country.Add(new Country { ID = "JP", Value = "Japan" });
            _country.Add(new Country { ID = "JE", Value = "Jersey" });
            _country.Add(new Country { ID = "JO", Value = "Jordan" });
            _country.Add(new Country { ID = "KZ", Value = "Kazakhstan" });
            _country.Add(new Country { ID = "KE", Value = "Kenya" });
            _country.Add(new Country { ID = "KI", Value = "Kiribati" });
            _country.Add(new Country { ID = "KP", Value = "Korea Democratic People's Republic of" });
            _country.Add(new Country { ID = "KR", Value = "Korea Republic of" });
            _country.Add(new Country { ID = "KW", Value = "Kuwait" });
            _country.Add(new Country { ID = "KG", Value = "Kyrgyzstan" });
            _country.Add(new Country { ID = "LA", Value = "Lao People's Democratic Republic" });
            _country.Add(new Country { ID = "LV", Value = "Latvia" });
            _country.Add(new Country { ID = "LB", Value = "Lebanon" });
            _country.Add(new Country { ID = "LS", Value = "Lesotho" });
            _country.Add(new Country { ID = "LR", Value = "Liberia" });
            _country.Add(new Country { ID = "LY", Value = "Libyan Arab Jamahiriya" });
            _country.Add(new Country { ID = "LI", Value = "Liechtenstein" });
            _country.Add(new Country { ID = "LT", Value = "Lithuania" });
            _country.Add(new Country { ID = "LU", Value = "Luxembourg" });
            _country.Add(new Country { ID = "MO", Value = "Macao" });
            _country.Add(new Country { ID = "MK", Value = "Macedonia The Former Yugoslav Republic of" });
            _country.Add(new Country { ID = "MG", Value = "Madagascar" });
            _country.Add(new Country { ID = "MW", Value = "Malawi" });
            _country.Add(new Country { ID = "MY", Value = "Malaysia" });
            _country.Add(new Country { ID = "MV", Value = "Maldives" });
            _country.Add(new Country { ID = "ML", Value = "Mali" });
            _country.Add(new Country { ID = "MT", Value = "Malta" });
            _country.Add(new Country { ID = "MH", Value = "Marshall Islands" });
            _country.Add(new Country { ID = "MQ", Value = "Martinique" });
            _country.Add(new Country { ID = "MR", Value = "Mauritania" });
            _country.Add(new Country { ID = "MU", Value = "Mauritius" });
            _country.Add(new Country { ID = "MT", Value = "Mayotte" });
            _country.Add(new Country { ID = "MX", Value = "Mexico" });
            _country.Add(new Country { ID = "FM", Value = "Microneia Federated States of" });
            _country.Add(new Country { ID = "MD", Value = "Moldova" });
            _country.Add(new Country { ID = "MC", Value = "Monaco" });
            _country.Add(new Country { ID = "MN", Value = "Mongolia" });
            _country.Add(new Country { ID = "ME", Value = "Montenegro" });
            _country.Add(new Country { ID = "MS", Value = "Montserrat" });
            _country.Add(new Country { ID = "MA", Value = "Morocco" });
            _country.Add(new Country { ID = "MZ", Value = "Mozambique" });
            _country.Add(new Country { ID = "MM", Value = "Myanmar" });
            _country.Add(new Country { ID = "NA", Value = "Namibia" });
            _country.Add(new Country { ID = "NR", Value = "Nauru" });
            _country.Add(new Country { ID = "NP", Value = "Nepal" });
            _country.Add(new Country { ID = "NL", Value = "Netherlands" });
            _country.Add(new Country { ID = "AN", Value = "Netherlands Antilles" });
            _country.Add(new Country { ID = "NC", Value = "New Caledonia" });
            _country.Add(new Country { ID = "NZ", Value = "New Zealand" });
            _country.Add(new Country { ID = "NI", Value = "Nicaragua" });
            _country.Add(new Country { ID = "NE", Value = "Niger" });
            _country.Add(new Country { ID = "NG", Value = "Nigeria" });
            _country.Add(new Country { ID = "NU", Value = "Niue" });
            _country.Add(new Country { ID = "NF", Value = "Norfolk Island" });
            _country.Add(new Country { ID = "MP", Value = "Northern Mariana Islands" });
            _country.Add(new Country { ID = "NO", Value = "Norway" });
            _country.Add(new Country { ID = "OM", Value = "Oman" });
            _country.Add(new Country { ID = "PK", Value = "Pakistan" });
            _country.Add(new Country { ID = "PW", Value = "Palau" });
            _country.Add(new Country { ID = "PS", Value = "Palestinian Territory Occupied" });
            _country.Add(new Country { ID = "PA", Value = "Panama" });
            _country.Add(new Country { ID = "PG", Value = "Papua New Guinea" });
            _country.Add(new Country { ID = "PY", Value = "Paraguay" });
            _country.Add(new Country { ID = "PE", Value = "Peru" });
            _country.Add(new Country { ID = "PH", Value = "Philippines" });
            _country.Add(new Country { ID = "PN", Value = "Pitcairn" });
            _country.Add(new Country { ID = "PL", Value = "Poland" });
            _country.Add(new Country { ID = "PT", Value = "Portugal" });
            _country.Add(new Country { ID = "PR", Value = "Puerto Rico" });
            _country.Add(new Country { ID = "QA", Value = "Qatar" });
            _country.Add(new Country { ID = "RE", Value = "Réunion" });
            _country.Add(new Country { ID = "RO", Value = "Romania" });
            _country.Add(new Country { ID = "RU", Value = "Russian Federation" });
            _country.Add(new Country { ID = "RW", Value = "Rwanda" });
            _country.Add(new Country { ID = "BL", Value = "Saint Barthélemy" });
            _country.Add(new Country { ID = "SH", Value = "Saint Helena" });
            _country.Add(new Country { ID = "KN", Value = "Saint Kitts and Nevis" });
            _country.Add(new Country { ID = "LC", Value = "Saint Lucia" });
            _country.Add(new Country { ID = "MF", Value = "Saint Martin" });
            _country.Add(new Country { ID = "PM", Value = "Saint Pierre and Miquelon" });
            _country.Add(new Country { ID = "VC", Value = "Saint Vincent and the Grenadines" });
            _country.Add(new Country { ID = "WS", Value = "Samoa" });
            _country.Add(new Country { ID = "SM", Value = "San Marino" });
            _country.Add(new Country { ID = "ST", Value = "Sao Tome and Principe" });
            _country.Add(new Country { ID = "SA", Value = "Saudi Arabia" });
            _country.Add(new Country { ID = "SN", Value = "Senegal" });
            _country.Add(new Country { ID = "RS", Value = "Serbia" });
            _country.Add(new Country { ID = "SC", Value = "Seychelles" });
            _country.Add(new Country { ID = "SL", Value = "Sierra Leone" });
            _country.Add(new Country { ID = "SG", Value = "Singapore" });
            _country.Add(new Country { ID = "SK", Value = "Slovakia" });
            _country.Add(new Country { ID = "SI", Value = "Slovenia" });
            _country.Add(new Country { ID = "SB", Value = "Solomon Islands" });
            _country.Add(new Country { ID = "SO", Value = "Somalia" });
            _country.Add(new Country { ID = "ZA", Value = "South Africa" });
            _country.Add(new Country { ID = "GS", Value = "South Georgia and the South Sandwich Islands" });
            _country.Add(new Country { ID = "ES", Value = "Spain" });
            _country.Add(new Country { ID = "LK", Value = "Sri Lanka" });
            _country.Add(new Country { ID = "SD", Value = "Sudan" });
            _country.Add(new Country { ID = "SR", Value = "Suriname" });
            _country.Add(new Country { ID = "SJ", Value = "Svalbard and Jan Mayen" });
            _country.Add(new Country { ID = "SZ", Value = "Swaziland" });
            _country.Add(new Country { ID = "SE", Value = "Sweden" });
            _country.Add(new Country { ID = "CH", Value = "Switzerland" });
            _country.Add(new Country { ID = "SY", Value = "Syrian Arab Republic" });
            _country.Add(new Country { ID = "TW", Value = "Taiwan Province of China" });
            _country.Add(new Country { ID = "TJ", Value = "Tajikistan" });
            _country.Add(new Country { ID = "TZ", Value = "Tanzania United Republic of" });
            _country.Add(new Country { ID = "TH", Value = "Thailand" });
            _country.Add(new Country { ID = "TL", Value = "Timor-Leste" });
            _country.Add(new Country { ID = "TG", Value = "Togo" });
            _country.Add(new Country { ID = "TK", Value = "Tokelau" });
            _country.Add(new Country { ID = "TO", Value = "Tonga" });
            _country.Add(new Country { ID = "TT", Value = "Trinidad and Tobago" });
            _country.Add(new Country { ID = "TN", Value = "Tunisia" });
            _country.Add(new Country { ID = "TR", Value = "Turkey" });
            _country.Add(new Country { ID = "TM", Value = "Turkmenistan" });
            _country.Add(new Country { ID = "TC", Value = "Turks and Caicos Islands" });
            _country.Add(new Country { ID = "TV", Value = "Tuvalu" });
            _country.Add(new Country { ID = "UG", Value = "Uganda" });
            _country.Add(new Country { ID = "UA", Value = "Ukraine" });
            _country.Add(new Country { ID = "AE", Value = "United Arab Emirates" });
            _country.Add(new Country { ID = "GB", Value = "United Kingdom" });
            _country.Add(new Country { ID = "US", Value = "United States" });
            _country.Add(new Country { ID = "UM", Value = "United States Minor Outlying Islands" });
            _country.Add(new Country { ID = "UY", Value = "Uruguay" });
            _country.Add(new Country { ID = "UZ", Value = "Uzbekistan" });
            _country.Add(new Country { ID = "VU", Value = "Vanuatu" });
            _country.Add(new Country { ID = "VE", Value = "Venezuela" });
            _country.Add(new Country { ID = "VN", Value = "Viet Nam" });
            _country.Add(new Country { ID = "VG", Value = "Virgin Islands British" });
            _country.Add(new Country { ID = "VI", Value = "Virgin Islands U.S." });
            _country.Add(new Country { ID = "WF", Value = "Wallis and Futuna" });
            _country.Add(new Country { ID = "EH", Value = "Western Sahara" });
            _country.Add(new Country { ID = "YE", Value = "Yemen" });
            _country.Add(new Country { ID = "ZM", Value = "Zambia" });
            _country.Add(new Country { ID = "ZW", Value = "Zimbabwe" });
            return _country;
        }
        #endregion
    }

    public class ViewModel
    {
        public List<Adult_Pax> _AdultM { get; set; }
        public List<Child_Pax> _ChildM { get; set; }
        public List<Infant_Pax> _InfantM { get; set; }
        public List<Billing_Field> _BillingField { get; set; }
    }
}