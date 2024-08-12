using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TravelSite.Models
{
    [Serializable]
    [XmlType(TypeName = "BaggageDetails")]
    public class BaggageDetails
    {
        private string _baggageCode = string.Empty;
        public string BaggageCode
        {
            get { return _baggageCode; }
            set { _baggageCode = value; }
        }
        private string _fee = string.Empty;
        public string Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }
        private string _weight = string.Empty;
        public string Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        private string _pieces = string.Empty;
        public string Pieces
        {
            get { return _pieces; }
            set { _pieces = value; }
        }
        private string _minpaxage = string.Empty;
        public string MinPaxAge
        {
            get { return _minpaxage; }
            set { _minpaxage = value; }
        }
    }
}