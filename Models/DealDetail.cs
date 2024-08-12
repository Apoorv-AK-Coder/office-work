using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class DealDetail
    {
        public string HotelName { get; set; }
        public string DEST_NAME { get; set; }
        public string CAT_NAME { get; set; }
        public string CUNT_NAME { get; set; }
        public string DEST_CODE { get; set; }
        public string HTL_RM_BoardType { get; set; }
        public string totalprice { get; set; }
        public string HTL_DTL_StarRating { get; set; }
        public string HotelAddress { get; set; }
        public string HTL_DTL_Description { get; set; }
        public string HTL_RM_ToDate { get; set; }
        public string HTL_RM_FromDate { get; set; }
        public string HTL_RM_PRC_RoomID { get; set; }
        public string DATA_MSTR_ID { get; set; }
        public string DEST_THINGS_TO_GO { get; set; }
        public string NoofNight { get; set; }
        public string RoomFacility { get; set; }
        public string HotelFacility { get; set; }
        public string star_rating { get; set; }
        public string LargeImage { get; set; }
        public string ThumbImage { get; set; }
        public string returntype { get; set; }
        public string Non { get; set; }
        public string SaveUpTo { get; set; }
        public string Mappath { get; set; }
    }

    public class DealParamEL
    {
        public string HotelId { get; set; }        
        public string RoomId { get; set; }
        public string DestCode { get; set; }
        public int Counter { get; set; }
        public string PageId { get; set; }
        public string CompanyId { get; set; }   
    }
}
