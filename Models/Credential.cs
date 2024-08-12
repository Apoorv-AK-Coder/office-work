using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TravelSite.Models
{
    [Serializable]
    public class Credential : ISerializable
    {

        private string _company_ID = string.Empty;
        public string Company_ID
        {
            get { return _company_ID; }
            set { _company_ID = value; }
        }

        private string _company_Name = string.Empty;
        public string Company_Name
        {

            get { return _company_Name; }
            set { _company_Name = value; }

        }

        private string _hap = string.Empty;
        public string Hap
        {


            get { return _hap; }
            set { _hap = value; }

        }

        private string _hap_Type = string.Empty;
        public string Hap_Type
        {

            get { return _hap_Type; }
            set { _hap_Type = value; }
        }

        private string _hap_Pwd = string.Empty;
        public string Hap_Password
        {

            get { return _hap_Pwd; }
            set { _hap_Pwd = value; }
        }

        private string _product_Type = string.Empty;
        public string Product_Type
        {

            get { return _product_Type; }
            set { _product_Type = value; }
        }

        private string _supplier_ID = string.Empty;
        public string Supplier_ID
        {

            get { return _supplier_ID; }
            set { _supplier_ID = value; }
        }

        private string _supplier_User_ID = string.Empty;
        public string Supplier_User_ID
        {

            get { return _supplier_User_ID; }
            set { _supplier_User_ID = value; }
        }

        private string _supplier_Password = string.Empty;
        public string Supplier_Password
        {

            get { return _supplier_Password; }
            set { _supplier_Password = value; }
        }


        private string _supplier_Psuedo = string.Empty;
        public string Supplier_Psuedo
        {

            get { return _supplier_Psuedo; }
            set { _supplier_Psuedo = value; }
        }

        private string _supplier_WSAP_Session = string.Empty;
        public string Supplier_WSAP_Session
        {

            get { return _supplier_WSAP_Session; }
            set { _supplier_WSAP_Session = value; }
        }

        private string _supplier_Ord_ID = string.Empty;
        public string Supplier_Ord_ID
        {

            get { return _supplier_Ord_ID; }
            set { _supplier_Ord_ID = value; }
        }

        private string _supplier_Pass_Len = string.Empty;
        public string Supplier_Pass_Len
        {

            get { return _supplier_Pass_Len; }
            set { _supplier_Pass_Len = value; }
        }

        private string _email_ID = string.Empty;
        public string Email_ID
        {

            get { return _email_ID; }
            set { _email_ID = value; }
        }

        private string _supplier_Endpoint = string.Empty;
        public string Supplier_Endpoint
        {

            get { return _supplier_Endpoint; }
            set { _supplier_Endpoint = value; }
        }
        private string _supplier_Namespance = string.Empty;
        public string Supplier_Namespance
        {

            get { return _supplier_Namespance; }
            set { _supplier_Namespance = value; }
        }
        private bool _is_Cache = false;
        public bool is_Cache
        {

            get { return _is_Cache; }
            set { _is_Cache = value; }
        }
        private string _website_Landing_URL = string.Empty;
        public string Website_Landing_URL
        {

            get { return _website_Landing_URL; }
            set { _website_Landing_URL = value; }
        }


        private int _no_Of_Fares = 100;
        public int No_Of_Fares
        {

            get { return _no_Of_Fares; }
            set { _no_Of_Fares = value; }
        }

        private bool _isActive;
        public bool isActive
        {

            get { return _isActive; }
            set { _isActive = value; }
        }

        public Credential() { }
        public Credential(SerializationInfo info, StreamingContext context)
        {
            Company_ID = info.GetString("Company_ID");
            Company_Name = info.GetString("Company_Name");

            Hap = info.GetString("Hap");
            Hap_Type = info.GetString("Hap_Type");


            Hap_Password = info.GetString("Hap_Password");
            Product_Type = info.GetString("Product_Type");

            Supplier_ID = info.GetString("Supplier_ID");
            No_Of_Fares = info.GetInt32("No_Of_Fares");

            isActive = info.GetBoolean("isActive");

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Company_ID", Company_ID);
            info.AddValue("Company_Name", Company_Name);

            info.AddValue("Hap", Hap);
            info.AddValue("Hap_Type", Hap_Type);

            info.AddValue("Hap_Password", Hap_Password);
            info.AddValue("Product_Type", Product_Type);

            info.AddValue("Supplier_ID", Supplier_ID);
            info.AddValue("No_Of_Fares", No_Of_Fares);

            info.AddValue("isActive", isActive);

        }
    }
}