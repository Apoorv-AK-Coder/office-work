using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class Billing
    {
        string _FirstNames;
        string _Surname;
        string _Address1;
        string _Address2;
        string _City;
        string _PostCode;
        string _Country;
        string _Region;
        string _Phone;
        string _Email;
        string _CountryName;


        public string FirstNames { get { return _FirstNames; } set { _FirstNames = value; } }
        public string Surname { get { return _Surname; } set { _Surname = value; } }
        public string Address1 { get { return _Address1; } set { _Address1 = value; } }
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }
        public string City { get { return _City; } set { _City = value; } }
        public string PostCode { get { return _PostCode; } set { _PostCode = value; } }
        public string Country { get { return _Country; } set { _Country = value; } }
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }
        public string Region { get { return _Region; } set { _Region = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }

        public Billing()
        {

            _FirstNames = string.Empty;
            _Surname = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _City = string.Empty;
            _PostCode = string.Empty;
            _Country = string.Empty;
            _CountryName = string.Empty;
            _Region = string.Empty;
            _Phone = string.Empty;
            _Email = string.Empty;
        }

    }

    public class Shipping
    {
        string _FirstNames;
        string _Surname;
        string _Address1;
        string _Address2;
        string _City;
        string _PostCode;
        string _Country;
        string _CountryName;
        string _Region;
        string _Phone;
        string _Email;

        public string FirstNames { get { return _FirstNames; } set { _FirstNames = value; } }
        public string Surname { get { return _Surname; } set { _Surname = value; } }
        public string Address1 { get { return _Address1; } set { _Address1 = value; } }
        public string Address2 { get { return _Address2; } set { _Address2 = value; } }
        public string City { get { return _City; } set { _City = value; } }
        public string PostCode { get { return _PostCode; } set { _PostCode = value; } }
        public string Country { get { return _Country; } set { _Country = value; } }
        public string CountryName { get { return _CountryName; } set { _CountryName = value; } }
        public string Region { get { return _Region; } set { _Region = value; } }
        public string Phone { get { return _Phone; } set { _Phone = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }

        public Shipping()
        {


            _FirstNames = string.Empty;
            _Surname = string.Empty;
            _Address1 = string.Empty;
            _Address2 = string.Empty;
            _City = string.Empty;
            _PostCode = string.Empty;
            _Country = string.Empty;
            _CountryName = string.Empty;
            _Region = string.Empty;
            _Phone = string.Empty;
            _Email = string.Empty;
        }
    }
}