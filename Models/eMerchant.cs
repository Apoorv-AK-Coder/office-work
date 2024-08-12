using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class eMerchant
    {
        public eMerchant()
        {
            this.PayCurrency = "USD";
            this.PayConnectingServer = "LIVE";

           
            this.payProtocall = "3.00";
            this.TransactionType = "sale";//PAYMENT
        }
        public string PayCurrency { set; get; }
        public string PayEmail { set; get; }
        public string TerminalKey { set; get; }
        public string UserID { set; get; }
        public string Password { set; get; }
        public string payProtocall { set; get; }
        public string PayConnectingServer { set; get; }
        public decimal PayAmount { set; get; }
        public string TransactionType { set; get; }
    }
}