using SagePay.IntegrationKit;
using SagePay.IntegrationKit.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class SagePayment
    {
        public SagePayment()
        {
            this.PayCurrency = "GBP";
            this.PayEmail = "support@faressaver.com";
            // this.VendorName = "Faressaver";
            this.VendorName = "flightsholiday";
            //this.PayEncriptedPwd = "861ad3694b6d05bb"; //live

            this.payProtocall = "3.00";
            this.PayConnectingServer = "LIVE";
            this.TransactionType = "DEFERRED";//PAYMENT
        }
        public string PayCurrency { set; get; }
        public string PayEmail { set; get; }
        public string VendorName { set; get; }
        public string PayEncriptedPwd
        {
            // set { this.PayEncriptedPwd = value; }
            get
            {
                string Pwd = string.Empty;
                if (PayConnectingServer == "LIVE")
                {
                    //    Pwd = "861ad3694b6d05bb";//Faressaver
                    Pwd = "dbc5ae3c5c54fd06"; //flightsholiday
                }
                else
                {
                    //Pwd = "0348b9897f6aecdb"; //test//Faressaver
                    Pwd = "a48b4a7e632822a1";//test //flightsholiday
                }
                return Pwd;
            }
        }


        public string payProtocall { set; get; }
        public string PayConnectingServer { set; get; }
        public decimal PayAmount { set; get; }
        public string TransactionType { set; get; }
        public string NotificationUrl { set; get; }
        public string VendorTxCode { set; get; }
        public string serverPaymentUrl
        {
            get { return "https://" + PayConnectingServer + ".sagepay.com/gateway/service/vspserver-register.vsp"; } //return "https://" + PayConnectingServer.ToLower() + ".sagepay.com/gateway/service/direct3dcallback.vsp"; }
        }
        public string directPaymentUrl
        {
            get { return "https://" + PayConnectingServer + ".sagepay.com/gateway/service/vspdirect-register.vsp"; } //return "https://" + PayConnectingServer.ToLower() + ".sagepay.com/gateway/service/direct3dcallback.vsp"; }
        }

        public Billing Billing { set; get; }
        public Shipping Shipping { set; get; }

        public void SetServerPaymentRequestData(IServerPayment request)
        {
            if (Billing.FirstNames == "PRABHUTEST" && Billing.Surname == "DIAL")
            {
                PayConnectingServer = "TEST";
            }

            decimal cardCharge = Convert.ToDecimal(0.025);
            request.VpsProtocol = (ProtocolVersion)Enum.Parse(typeof(ProtocolVersion), "V_" + payProtocall.Replace(".", ""));
            request.TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), TransactionType);
            request.Vendor = VendorName;
            VendorTxCode = GetNewVendorTxCode();
            request.VendorTxCode = VendorTxCode;
            request.Amount = PayAmount;
            request.Currency = PayCurrency;
            request.Description = "Booking from Faressaver.com";
            request.BillingSurname = Billing.Surname;
            request.BillingFirstnames = Billing.FirstNames;
            request.BillingAddress1 = ".";// Billing.Address1;
            request.BillingCity = ".";// Billing.City;
            request.BillingPostCode = " ";// Billing.PostCode;
            request.BillingCountry = Billing.Country;
            request.DeliverySurname = Shipping.Surname;
            request.DeliveryFirstnames = Shipping.FirstNames;
            request.DeliveryAddress1 = ".";//  Shipping.Address1;
            request.DeliveryCity = ".";// .City;
            request.DeliveryPostCode = " ";// Shipping.PostCode;
            request.DeliveryCountry = Shipping.Country;
            //Optional
            request.CustomerEmail = Billing.Email;
            request.ApplyAvsCv2 = 2;
            request.Apply3dSecure = 0;//3
            request.ReferrerId = "";
            request.AccountType = "E";
            request.Profile = "NORMAL";
            request.BasketXml = "<basket><item><description>AirFare Ticket</description><quantity>1</quantity><unitNetAmount>" + PayAmount + "</unitNetAmount><unitTaxAmount>0</unitTaxAmount><unitGrossAmount>" + PayAmount + "</unitGrossAmount><totalGrossAmount>" + PayAmount + "</totalGrossAmount></item></basket>";

            //if ((request.Amount * cardCharge) > 56)
            //{
            //    request.SurchargeXml = "<surcharges><surcharge><paymentType>VISA</paymentType><fixed>56</fixed></surcharge><surcharge><paymentType>MC</paymentType><fixed>56</fixed></surcharge><surcharge><paymentType>AMEX</paymentType><fixed>56</fixed></surcharge></surcharges>";
            //}
            //else {
            request.SurchargeXml = "<surcharges><surcharge><paymentType>VISA</paymentType><percentage>0</percentage></surcharge><surcharge><paymentType>MC</paymentType><percentage>0</percentage></surcharge><surcharge><paymentType>AMEX</paymentType><percentage>0.0</percentage></surcharge></surcharges>";
            //}

            request.NotificationUrl = NotificationUrl;
            request.CreateToken = 0;// (cart.Card.SaveTokenForFutureUse == true ? 1 : 0);
        }
        public void SetDirectPaymentRequestData(IDirectPayment request, RootObject robj)
        {
            if (Billing.FirstNames == "PRABHUTEST" && Billing.Surname == "DIAL")
            {
                PayConnectingServer = "TEST";
            }
            decimal cardCharge = Convert.ToDecimal(0.025);
            request.VpsProtocol = (ProtocolVersion)Enum.Parse(typeof(ProtocolVersion), "V_" + payProtocall.Replace(".", ""));
            request.TransactionType = (TransactionType)Enum.Parse(typeof(TransactionType), TransactionType);
            request.Vendor = VendorName;
            VendorTxCode = GetNewVendorTxCode();
            request.VendorTxCode = VendorTxCode;
            request.Amount = PayAmount;
            request.Currency = PayCurrency;
            request.Description = "Booking from Faressaver.com";
            request.BillingSurname = Billing.Surname;
            request.BillingFirstnames = Billing.FirstNames;
            request.BillingAddress1 = robj.card.address.line1 + " " + robj.card.address.line2;
            request.BillingCity = robj.card.address.city;
            request.BillingPostCode = robj.card.address.postalcode;
            request.DeliverySurname = Shipping.Surname;
            request.DeliveryFirstnames = Shipping.FirstNames;
            request.DeliveryAddress1 = robj.card.address.line1 + " " + robj.card.address.line2;
            request.DeliveryCity = robj.card.address.city;
            request.DeliveryPostCode = robj.card.address.postalcode;
            request.DeliveryCountry = Shipping.Country;
            //Optional
            request.CustomerEmail = Billing.Email;
            request.BillingAddress1 = robj.card.address.line1;
            request.BillingAddress2 = robj.card.address.line2;
            request.BillingPostCode = robj.card.address.postalcode;
            request.BillingCountry = "GB";

            request.Apply3dSecure = 2;
            request.ApplyAvsCv2 = 2;
            request.CardType = (CardType)Enum.Parse(typeof(CardType), robj.card.details.scheme);
            request.CardHolder = robj.card.details.name;

            request.CardNumber = robj.card.details.number;
            //request.StartDate = string.Empty;
            request.ExpiryDate = robj.card.details.expiry.Replace("/", "");
            request.Cv2 = robj.card.details.cvv;
                       

        }

        public string GetNewVendorTxCode()
        {
            Random random = new Random();
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            // 18 char max -13 chars - 6 chars
            return string.Format("{0}-{1}-{2}",
                VendorName.Substring(0, Math.Min(18, VendorName.Length)),
                (long)ts.TotalMilliseconds, random.Next(100000, 999999));
        }
    }

    public class Funded
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Details
    {
        public string scheme { get; set; }
        public string name { get; set; }
        public string number { get; set; }
        public string expiry { get; set; }
        public string cvv { get; set; }
    }

    public class Address
    {
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
    }

    public class Card
    {
        public Funded funded { get; set; }
        public Details details { get; set; }
        public Address address { get; set; }
    }

    public class Reference
    {
        public string virtual_card { get; set; }
        public string payment_card { get; set; }
        public string transaction { get; set; }
        public string request { get; set; }
    }

    public class RootObject
    {
        public bool error { get; set; }
        public Card card { get; set; }
        public Reference reference { get; set; }
    }
}