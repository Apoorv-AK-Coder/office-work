
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class HolidayBAL
    {
        public const string OneRating = @"<ul><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href=''>" +
        "<i class='fa fa-star'></i></a></li><li><a href=''><i class='fa fa-star'></i></a></li><li><a href=''><i class='fa fa-star'></i></a></li>" +
        "<li><a href=''><i class='fa fa-star'></i></a></li></ul>";

        public const string Tworating = @"<ul><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href='' class='act_star'>" +
        "<i class='fa fa-star'></i></a></li><li><a href=''><i class='fa fa-star'></i></a></li><li><a href=''><i class='fa fa-star'></i></a></li>" +
        "<li><a href=''><i class='fa fa-star'></i></a></li></ul>";

        public const string ThreeRating = @"<ul><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href='' class='act_star'>" +
        "<i class='fa fa-star'></i></a></li><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href=''><i class='fa fa-star'></i></a></li>" +
        "<li><a href=''><i class='fa fa-star'></i></a></li></ul>";

        public const string FourRating = @"<ul><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href='' class='act_star'>" +
        "<i class='fa fa-star'></i></a></li><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li>" +
        "<li><a href=''><i class='fa fa-star'></i></a></li></ul>";

        public const string FiveRating = @"<ul><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href='' class='act_star'>" +
        "<i class='fa fa-star'></i></a></li><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li><li><a href='' class='act_star'><i class='fa fa-star'></i></a></li>" +
        "<li><a href='' class='act_star'><i class='fa fa-star'></i></a></li></ul>";
        public DataSet GetHolidaysDeal(DealParamEL ObjDealParam)
        {
            return HolidayDAL.GetHolidaysDeal(ObjDealParam);
        }
        public DataTable GetDealDetail(DealParamEL ObjDealParam)
        {
            return HolidayDAL.GetDealDetail(ObjDealParam);
        }
        public bool InsertEnquiry(HolidayEnq ObjHE)
        {
            return HolidayDAL.InsertEnquiry(ObjHE);
        }
        public bool InsertCallBackEnquiry(HolidayEnq ObjHE)
        {
            return HolidayDAL.InsertCallBackEnquiry(ObjHE);
        }
        public bool InsertFeedBackEnquiry(HolidayEnq ObjHE)
        {
            return HolidayDAL.InsertFeedBackEnquiry(ObjHE);
        }

        public string GetLargeHotelImgs(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            int counter = 0;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {


                    if (counter < 3)
                    {
                        foreach (DataRow drow in dt.Rows)
                        {
                            str.Append("<div class='item'>");
                            str.Append("<img src=" + drow["HTL_IMG_IMGPath"].ToString() + " alt=\"\">");
                            str.Append("</div>");
                        }
                    }
                    counter = counter + 1;

                }
                else
                {
                    str.Append("<div class='item'>");
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                    str.Append("</div>");
                    str.Append("<div class='item'>");
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                    str.Append("</div>");
                    str.Append("<div class='item'>");
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                    str.Append("</div>");
                }
            }
            catch
            {
                str.Append("<div class='item'>");
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                str.Append("</div>");
                str.Append("<div class='item'>");
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                str.Append("</div>");
                str.Append("<div class='item'>");
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                str.Append("</div>");
            }
            return str.ToString();

        }
        public string GetThumbHotelImgs(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            int counter = 0;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (counter < 3)
                    {
                        foreach (DataRow drow in dt.Rows)
                        {
                            str.Append("<div class='item'>");
                            str.Append("<img src=" + drow["HTL_IMG_ThumbNailPath"].ToString() + " style=\"width:95px; height:60px;\" alt=\"\" >");
                            str.Append("</div>");
                            // style=\"width:95px; height:60px;\"
                        }
                    }
                    counter = counter + 1;
                }
                else
                {
                    str.Append("<div class='item'>");
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                    str.Append("</div>");
                    str.Append("<div class='item'>");
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                    str.Append("</div>");
                    str.Append("<div class='item'>");
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                    str.Append("</div>");
                }
            }
            catch
            {
                str.Append("<div class='item'>");
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                str.Append("</div>");
                str.Append("<div class='item'>");
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                str.Append("</div>");
                str.Append("<div class='item'>");
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\" data-large-src=\"images/dest_banner_lg.jpg\">");
                str.Append("</div>");
            }
            return str.ToString();

        }
        public string GethotelDealimag(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    str.Append("<img src=" + dt.Rows[0]["HTL_IMG_IMGPath"].ToString() + " alt=\"\">");
                }
                else
                {
                    str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\">");
                }
            }
            catch
            {
                str.Append("<img src=\"http://holidaydesire.co.uk/images/img11.jpg\" alt=\"\">");
            }
            return str.ToString();

        }
        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public string RemoveSign(string s)
        {
            string sName = string.Empty;
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            if (s.Contains("-"))
            {
                string[] arr = s.Split('-');
                sName = AddStringInArray(arr);
            }
            else if (s.Contains(" "))
            {
                string[] arr = s.Split(' ');
                sName = AddStringInArray(arr);
            }
            else if (s.Contains("/"))
            {
                string[] arr = s.Split('/');
                sName = AddStringInArray(arr);
            }
            else
            {
                if (!s.Contains("-") || !s.Contains(" "))
                {
                    sName = AddSpace(s);
                    if (sName.Contains(" "))
                    {
                        string[] arr = sName.Split(' ');
                        sName = AddStringInArray(arr);
                    }
                    else
                    {
                        sName = UppercaseFirst(s);
                    }
                }
                else
                {
                    sName = UppercaseFirst(s);
                }
            }
            return sName;
        }
        public static string AddSpace(string s)
        {
            if (s == "Australia/OCEANIA")
            {
                s = "australia/oceania";
            }
            else if (s == "USA")
            {
                s = "usa";
            }
            else
            {
                char[] chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    string strChar = chars.GetValue(i).ToString();
                    if (s.Contains(strChar))
                    {
                        s = s.Replace(strChar, " " + strChar);
                    }
                }
                if (s.Contains(" "))
                {
                    s = s.Substring(1);
                }
            }
            return s;

        }
        public static string AddspecialSign(string s)
        {
            char[] chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (s.Contains(strChar))
                {
                    s = s.Replace(strChar, "-" + strChar);
                }
            }
            if (s.Contains("-"))
            {
                s = s.Substring(1);
            }

            return s;

        }
        public static string AddStringInArray(string[] arr)
        {
            string sName = string.Empty;
            string third = string.Empty;
            for (int i = 1; i <= arr.Length; i++)
            {
                sName = UppercaseFirst(arr[arr.Length - i].ToString()) + " " + sName;
            }
            return sName;
        }
        public string SetRatingImage(string Rating)
        {
            string RatingImage = string.Empty;

            switch (Rating)
            {
                case "1":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "1.5":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "2":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "2.5":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "3":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "3.5":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "4":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='grey-star_r' src='images/star-back-yello.png' />";
                    break;
                case "4.5":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' />";
                    break;
                case "5":
                    RatingImage = @"<img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' /><img class='pink-star_r' src='images/star-back-yello.png' />";
                    break;
                default:
                    RatingImage = "";
                    break;
            }
            return RatingImage;

        }
        public string CalculateNoOfNight(string godate, string frmdate)
        {
            DateTime todate = DateTime.Now.AddDays(2);
            DateTime fromdate = DateTime.Now;
            TimeSpan TimeDifference = TimeSpan.FromDays(1);
            if (!string.IsNullOrEmpty(godate) && !string.IsNullOrEmpty(frmdate))
            {
                todate = Convert.ToDateTime(godate.ToString());
                fromdate = Convert.ToDateTime(frmdate);
                TimeDifference = todate - fromdate;
            }
            return TimeDifference.Days.ToString();

        }
        public string GetBoardBasis(string BoardCode)
        {
            string ReturnBoardbasis = string.Empty;
            switch (BoardCode)
            {
                case "AI":
                    ReturnBoardbasis = "All Inclusive"; break;
                case "AB":
                    ReturnBoardbasis = "American Breakfast"; break;
                case "AS":
                    ReturnBoardbasis = "All Inclusive Special"; break;
                case "BB":
                    ReturnBoardbasis = "Bed and Breakfast"; break;
                case "BF":
                    ReturnBoardbasis = "Buffet Breakfast"; break;
                case "BH":
                    ReturnBoardbasis = "1 Bed and Breakfast + 1 Half Board"; break;
                case "BR":
                    ReturnBoardbasis = "Brunch"; break;
                case "CB":
                    ReturnBoardbasis = "Continental Breakfast"; break;
                case "DN":
                    ReturnBoardbasis = "Dinner"; break;
                case "EB":
                    ReturnBoardbasis = "External Board Type"; break;
                case "ET":
                    ReturnBoardbasis = "External Board Type"; break;
                case "EX":
                    ReturnBoardbasis = "External Boarding Type (Pegasus)"; break;
                case "FB":
                    ReturnBoardbasis = "Full Board"; break;
                case "FH":
                    {
                        ReturnBoardbasis = "1 Half Board + 1 Full Board"; break;
                    }

                case "FV":
                    {
                        ReturnBoardbasis = "Full Board Beverages Included"; break;
                    }

                case "HB":
                    {
                        ReturnBoardbasis = "Breakfast + Dinner"; break;
                    }

                case "HV":
                    {
                        ReturnBoardbasis = "Half Boad with Beverages Included"; break;
                    }
                case "IB":
                    {
                        ReturnBoardbasis = "Irish Breakfast"; break;
                    }
                case "RO":
                    {
                        ReturnBoardbasis = "Room Only"; break;
                    }
                case "SB":
                    {
                        ReturnBoardbasis = "Scottish Breakfast"; break;
                    }
                case "SC":
                    {
                        ReturnBoardbasis = "Self Catering"; break;
                    }
                default:
                    ReturnBoardbasis = "None"; break;

            }
            return ReturnBoardbasis;
        }
        public string Dateformatwithyear(string DepDate)
        {
            try
            {
                string[] words = DepDate.Split(' ');
                string day;
                day = words[0];
                return (Convert.ToDateTime(day).ToString("dd MMM yyyy")).ToString();
            }
            catch
            {
                return (Convert.ToDateTime(DateTime.Now).ToString("dd MMM yyyy")).ToString();
            }
        }
        public string DateformatOnlyMonths(string DepDate)
        {
            try
            {
                string[] words = DepDate.Split(' ');
                string day;
                day = words[0];
                return (Convert.ToDateTime(day).ToString("MMM yyyy")).ToString();
            }
            catch
            {
                return (Convert.ToDateTime(DateTime.Now).ToString("MMM yyyy")).ToString();
            }
        }
        public string GetRoomFacilaty(DealParamEL ObjDealParam)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                DataTable dt = GetDealDetail(ObjDealParam); // 4, "", roomID, "", ""
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow drow in dt.Rows)
                    {
                        str.Append("<li>" + drow["HTL_RM_FAC_Name"].ToString() + "</li>");
                    }
                }
                else
                {
                    str.Append("<li> No Facility Avaliable.</li>");
                }
            }
            catch
            {
                str.Append("<li> No Facility Avaliable.</li>");
            }
            return str.ToString();
        }
        public string GetHtlFacilaty(DealParamEL ObjDealParam)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                DataTable dt = GetDealDetail(ObjDealParam);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow drow in dt.Rows)
                    {
                        str.Append("<li>" + drow["HTL_FAC_Name"].ToString() + "</li>");
                    }
                }
                else
                {
                    str.Append("<li> No Facility Avaliable.</li>");
                }
            }
            catch
            {
                str.Append("<li> No Facility Avaliable.</li>");
            }
            return str.ToString();
        }
        public string GetStarImageSpecialOffer(string Rating)
        {
            string RatingImage = string.Empty;

            switch (Rating)
            {
                case "1":
                    RatingImage = OneRating;
                    break;
                case "1.5":
                    RatingImage = Tworating;
                    break;
                case "2":
                    RatingImage = Tworating;
                    break;
                case "2.5":
                    RatingImage = ThreeRating;
                    break;
                case "3":
                    RatingImage = ThreeRating;
                    break;
                case "3.5":
                    RatingImage = FourRating;
                    break;
                case "4":
                    RatingImage = FourRating;
                    break;
                case "4.5":
                    RatingImage = FiveRating;
                    break;
                case "5":
                    RatingImage = FiveRating;
                    break;
                default:
                    RatingImage = "";
                    break;
            }
            return RatingImage;

        }


    }
}
