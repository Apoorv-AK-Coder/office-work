using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TravelSite.Models
{
    public class Contact
    {
        private string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _Mobile = string.Empty;
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private AddressEL _address = new AddressEL();
        public AddressEL AddressDetail
        {
            get { return _address; }
            set { _address = value; }
        }
    }

    public class AddressEL
    {
        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _state = string.Empty;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _country = string.Empty;
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _postCode = string.Empty;
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }
    }
}
