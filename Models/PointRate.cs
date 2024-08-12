using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public static class PointRate
    {
        public static int Signup = 0;
        public static int ProfileUpdate = 0;
        public static int Fbshare = 0;
        public static int Fblike = 0;
        public static int Twtfollow = 0;
        public static int Twtpost = 0;
        public static int VideoReview = 0;
        public static int ImageReview = 0;
        public static int TextReview = 0;
        public static int FeedbackReview = 0;
        public static int ReferFriend = 0;
        public static int Newsletter = 0;
        public static int CompleteSurvey = 0;
        public static int DownloadMobileApp = 0;
        public static int FirstBookonAPP = 0;
        public static int BirthdayPoints = 0;
        public static string RedeemRate = string.Empty;
        public static int YClassMaxSpend = 0;
        public static int WClassMaxSpend = 0;
        public static int CClassMaxSpend = 0;
        public static int FClassMaxSpend = 0;
        public static string YClassEarnRate = string.Empty;
        public static string WClassEarnRate = string.Empty;
        public static string CClassEarnRate = string.Empty;
        public static string FClassEarnRate = string.Empty;
        public static int BookPoints = 0;

        public static DataTable GetPointRate()
        {
            DataTable temp = new DataTable();
            temp = Global.ExecuteSPReturnDT(new object[] {"Usp_GetUserProfile"                                                                                                                                               
                                                        ,"@Counter",7
                 }, DataConnection.GetConnectionPoints());

            return temp;
        }
    }
}