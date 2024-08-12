using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SagePay.IntegrationKit;

namespace TravelSite.Models
{
    public class PayZone
    {

        public PayZone(string payConnectingServer)
        {
            this.PayCurrency = "826";
            this.PayConnectingServer = payConnectingServer;

            if (this.PayConnectingServer == "LIVE")
            {
                this.PreSharedKey = "59G7m9Z6ZpFBW68RcqLL7S30fkC+Rp0Ozc7Ij6HKjmMMcTY9A3w=";
                this.MerchantID = "TRAVEL-8122159";
                this.Password = "Ajf116emarchant";
            }
            else if (this.PayConnectingServer == "TEST")
            {
                this.PreSharedKey = "eaf501dac4e36db1eff79b8a317d300f6449fca6";
                this.MerchantID = "TRAVEL-1144991";
                this.Password = "685NNAT693n";
            }

            this.ResultDeliveryMethod = RESULT_DELIVERY_METHOD.SERVER_PULL;
            this.HashMethod = HASH_METHOD.SHA1;
            this.TransactionType = "PREAUTH";//PREAUTH //SALE
            this.PreSharedKey = "59G7m9Z6ZpFBW68RcqLL7S30fkC+Rp0Ozc7Ij6HKjmMMcTY9A3w=";
            // this.PaymentProcessorDomain = "paymentprocessor.net";
            this.PaymentProcessorDomain = "payzoneonlinepayments.com";

        }
        public string PayCurrency { set; get; }
        public string PreSharedKey { set; get; }
        public HASH_METHOD HashMethod { set; get; }
        public string MerchantID { set; get; }
        public string Password { set; get; }
        public RESULT_DELIVERY_METHOD ResultDeliveryMethod { set; get; }
        public string PayConnectingServer { set; get; }

        public string TransactionType { set; get; }

        public string PaymentProcessorDomain { set; get; }
    }
}