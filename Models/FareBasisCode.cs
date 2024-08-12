using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelSite.Models
{
    [Serializable]
    [XmlType(TypeName = "FareBasisCode")]
   public  class FareBasisCodeEL
    {
        private string _farebasis = string.Empty;
        public string FareBasis
        {
            get { return _farebasis; }
            set { _farebasis = value; }
        }
        private string _airline = string.Empty;
        public string Airline
        {
            get { return _airline; }
            set { _airline= value; }
        }
        private string _paxtype = string.Empty;
        public string PaxType
        {
            get { return _paxtype; }
            set { _paxtype = value; }
        }
        private string _origin = string.Empty;
        public string Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        private string _destination = string.Empty;
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        private string _farerst = string.Empty;
        public string FareRst
        {
            get { return _farerst; }
            set { _farerst = value; }
        }
    }
}
