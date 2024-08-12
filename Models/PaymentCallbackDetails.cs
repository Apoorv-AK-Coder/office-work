using SagePay.IntegrationKit.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class PaymentCallbackDetails
    {
        public PaymentCallbackDetails()
        {

        }
        public PaymentCallbackDetails(IServerNotificationRequest serverNotificationRequest)
        {
            this.VendorTxCode = serverNotificationRequest.VendorTxCode;
            this.AvsCv2 = serverNotificationRequest.AvsCv2;
            this.AddressResult = serverNotificationRequest.AddressResult.ToString();
            this.AddressStatus = serverNotificationRequest.AddressStatus;
            this.BankAuthCode = serverNotificationRequest.BankAuthCode;
            this.CardType = serverNotificationRequest.CardType.ToString();
            this.Cavv = serverNotificationRequest.Cavv;
            this.Cv2Result = serverNotificationRequest.Cv2Result.ToString();
            this.DeclineCode = serverNotificationRequest.DeclineCode;
            this.ExpiryDate = serverNotificationRequest.ExpiryDate;
            this.FraudResponse = serverNotificationRequest.FraudResponse.ToString();
            ///GiftAid = serverNotificationRequest.GiftAid;
            this.Last4Digits = serverNotificationRequest.Last4Digits;
            this.PostCodeResult = serverNotificationRequest.PostCodeResult.ToString();
            this.Status = serverNotificationRequest.Status.ToString();
            this.StatusMessage = serverNotificationRequest.StatusDetail;
            this.Surcharge = serverNotificationRequest.Surcharge;
            this.ThreeDSecureStatus = serverNotificationRequest.ThreeDSecureStatus.ToString();
            this.TokenId = serverNotificationRequest.Token;
            this.TxAuthNo = serverNotificationRequest.TxAuthNo.ToString();
            this.VpsTxId = serverNotificationRequest.VpsTxId;
            this.PayerStatus = serverNotificationRequest.PayerStatus;

            //calculateCapturedAmountWithSurcharge(order, serverNotificationRequest);
        }

        public PaymentCallbackDetails(IDirectPaymentResult result)
        {
            this.VendorTxCode = result.VpsTxId;
            this.AvsCv2 = result.AvsCv2;
            this.AddressResult = result.AddressResult.ToString();
            // this.AddressStatus = result.AddressStatus;
            this.BankAuthCode = result.BankAuthCode;
            // this.CardType = result.CardType.ToString();
            this.Cavv = result.Cavv;
            this.Cv2Result = result.Cv2Result.ToString();
            this.DeclineCode = result.DeclineCode;
            this.ExpiryDate = result.ExpiryDate;
            this.FraudResponse = result.FraudResponse.ToString();
            ///GiftAid = serverNotificationRequest.GiftAid;
           // this.Last4Digits = result.Last4Digits;
            this.PostCodeResult = result.PostCodeResult.ToString();
            this.Status = result.Status.ToString();
            this.StatusMessage = result.StatusDetail;
            this.Surcharge = result.Surcharge;
            this.ThreeDSecureStatus = result.ThreeDSecureStatus.ToString();
            this.TokenId = result.Token;
            this.TxAuthNo = result.TxAuthNo.ToString();
            this.VpsTxId = result.VpsTxId;
            this.PayerStatus = result.Status.ToString();

            //calculateCapturedAmountWithSurcharge(order, serverNotificationRequest);
        }

        public string VendorTxCode { set; get; }
        public string AvsCv2 { set; get; }
        public string AddressResult { set; get; }
        public string AddressStatus { set; get; }
        public string BankAuthCode { set; get; }
        public string CardType { set; get; }
        public string Cavv { set; get; }
        public string Cv2Result { set; get; }
        public string DeclineCode { set; get; }
        public string ExpiryDate { set; get; }
        public string FraudResponse { set; get; }
        public string GiftAid { set; get; }
        public string Last4Digits { set; get; }
        public string PostCodeResult { set; get; }
        public string Status { set; get; }
        public string StatusMessage { set; get; }
        public decimal? Surcharge { set; get; }
        public string ThreeDSecureStatus { set; get; }
        public string TokenId { set; get; }
        public string TxAuthNo { set; get; }
        public string VpsTxId { set; get; }
        public string PayerStatus { set; get; }
    }
}