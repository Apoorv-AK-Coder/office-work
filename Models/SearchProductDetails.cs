using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class SearchProductDetails
    {
        public SearchProductDetails(string _ProdID, string _ProdType)
        {
            this.ProdID = _ProdID;
            this.ProdType = _ProdType;
        }
        public string ProdID { set; get; }
        public string ProdType { set; get; }

    }
}