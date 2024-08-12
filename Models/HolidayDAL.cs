
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class HolidayDAL
    {
        public static DataSet GetHolidaysDeal(DealParamEL ObjDealParam)
        {
            return Global.ExecuteSPReturnDS(new object[] {"GetDestinationAndContinant"
                                                        ,"@companycode",ObjDealParam.CompanyId
                                                        ,"@_counter",ObjDealParam.Counter                                                    
                 }, DataConnection.GetConnectionHotel());
        }
        public static DataTable GetDealDetail(DealParamEL ObjDealParam)
        {

            return Global.ExecuteSPReturnDT(new object[] {"GetDestinationAndContinant"
                                                        ,"@_hotelid",ObjDealParam.HotelId
                                                        ,"@roomid",ObjDealParam.RoomId
                                                        //,"@_PageID",ObjDealParam.PageId
                                                        ,"@destcode",ObjDealParam.DestCode
                                                        ,"@_counter",ObjDealParam.Counter
                                                        ,"@companycode",ObjDealParam.CompanyId 
                 }, DataConnection.GetConnectionHotel());
        }

        public static bool InsertEnquiry(HolidayEnq FQDetails)
        {
            //bool Rval = Global.ExecuteNonQuery(new object[] {"InsertFareQuotes"
            //                                        ,"@paramFirstName",ObjHE.FirstName
            //                                        ,"@paramLastName",ObjHE.LastName
            //                                        ,"@paramPhone",ObjHE.ContactNo
            //                                        ,"@paramEMail",ObjHE.Email                                                    
            //                                        ,"@paramdate",ObjHE.date                                                    
            //                                        ,"@paramDepartCityCode",ObjHE.DestCityCode
            //                                        ,"@paramDestCityCode",ObjHE.DestCityCode
            //                                        ,"@paramClass",ObjHE.Class                                                   
            //                                        ,"@paramBoardBasis",ObjHE.BoardBasis
            //                                        ,"@paramNoOfPassanger",ObjHE.NoOfPassanger
            //                                        ,"@paramNoOfNights",ObjHE.NoOfNights
            //                                        ,"@paramCompany",ObjHE.Company
            //                                        ,"@paramEnquiryType",ObjHE.EnquiryType
            //                                        ,"@paramTitle",ObjHE.Title                                                  
            //                                        ,"@paramCallRemarks",ObjHE.CallRemarks
            //                                        ,"@paramRefCode",ObjHE.RefCode
                                                    
            //     }, DataConnectionDAL.GetConnectionOfflinefares());

            //return Rval;
            //---
            try
            {
                SqlParameter[] Param = new SqlParameter[24];

                if (!string.IsNullOrEmpty(FQDetails.FirstName))
                {
                    Param[0] = new SqlParameter("@paramFirstName", SqlDbType.NVarChar);
                    Param[0].Value = FQDetails.FirstName;
                }
                if (!string.IsNullOrEmpty(FQDetails.LastName))
                {
                    Param[1] = new SqlParameter("@paramLastName", SqlDbType.NVarChar);
                    Param[1].Value = FQDetails.LastName;
                }
                if (!string.IsNullOrEmpty(FQDetails.Phone))
                {
                    Param[2] = new SqlParameter("@paramPhone", SqlDbType.NVarChar);
                    Param[2].Value = FQDetails.Phone;
                }
                if (!string.IsNullOrEmpty(FQDetails.Email))
                {
                    Param[3] = new SqlParameter("@paramEMail", SqlDbType.NVarChar);
                    Param[3].Value = FQDetails.Email;
                }
                //if (!string.IsNullOrEmpty(FQDetails.TripType))
                //{
                //    Param[4] = new SqlParameter("@paramTripType", SqlDbType.NVarChar);
                //    Param[4].Value = FQDetails.TripType;
                //}
                if (FQDetails.date != null)
                {
                    Param[5] = new SqlParameter("@paramdate", SqlDbType.Date);
                    Param[5].Value = FQDetails.date;
                }
                //if (FQDetails.ReturnDate != null)
                //{
                //    Param[6] = new SqlParameter("@paramReturnDate", SqlDbType.Date);
                //    Param[6].Value = FQDetails.ReturnDate;
                //}
                if (!string.IsNullOrEmpty(FQDetails.DepartCityCode))
                {
                    Param[7] = new SqlParameter("@paramDepartCityCode", SqlDbType.NVarChar);
                    Param[7].Value = FQDetails.DepartCityCode;
                }
                if (!string.IsNullOrEmpty(FQDetails.DestCityCode))
                {
                    Param[8] = new SqlParameter("@paramDestCityCode", SqlDbType.NVarChar);
                    Param[8].Value = FQDetails.DestCityCode;
                }
                if (!string.IsNullOrEmpty(FQDetails.Class))
                {
                    Param[9] = new SqlParameter("@paramClass", SqlDbType.NVarChar);
                    Param[9].Value = FQDetails.Class;
                }
                //if (FQDetails.CallDate != null)
                //{
                //    Param[10] = new SqlParameter("@paramCallDate", SqlDbType.Date);
                //    Param[10].Value = FQDetails.CallDate;
                //}
                //if (!string.IsNullOrEmpty(FQDetails.CallTime))
                //{
                //    Param[11] = new SqlParameter("@paramCallTime", SqlDbType.NVarChar);
                //    Param[11].Value = FQDetails.CallTime;
                //}
                if (!string.IsNullOrEmpty(FQDetails.CallRemarks))
                {
                    Param[12] = new SqlParameter("@paramCallRemarks", SqlDbType.NVarChar);
                    Param[12].Value = FQDetails.CallRemarks;
                }
                //if (FQDetails.dDateTime != null)
                //{
                //    Param[13] = new SqlParameter("@paramDateTime", SqlDbType.DateTime);
                //    Param[13].Value = FQDetails.dDateTime;
                //}
                if (!string.IsNullOrEmpty(FQDetails.Company))
                {
                    Param[14] = new SqlParameter("@paramCompany", SqlDbType.NVarChar);
                    Param[14].Value = FQDetails.Company;
                }
                if (!string.IsNullOrEmpty(FQDetails.EnquiryType))
                {
                    Param[15] = new SqlParameter("@paramEnquiryType", SqlDbType.NVarChar);
                    Param[15].Value = FQDetails.EnquiryType;
                }
                if (!string.IsNullOrEmpty(FQDetails.Title))
                {
                    Param[16] = new SqlParameter("@paramTitle", SqlDbType.NVarChar);
                    Param[16].Value = FQDetails.Title;
                }
                if (!string.IsNullOrEmpty(FQDetails.Title))
                {
                    Param[17] = new SqlParameter("@paramContactNo", SqlDbType.NVarChar);
                    Param[17].Value = FQDetails.ContactNo;
                }
                if (!string.IsNullOrEmpty(FQDetails.City))
                {
                    Param[18] = new SqlParameter("@paramCity", SqlDbType.NVarChar);
                    Param[18].Value = FQDetails.City;
                }
                if (!string.IsNullOrEmpty(FQDetails.BoardBasis))
                {
                    Param[19] = new SqlParameter("@paramBoardBasis", SqlDbType.NVarChar);
                    Param[19].Value = FQDetails.BoardBasis;
                }
                if (FQDetails.NoOfPassanger != null)
                {
                    Param[20] = new SqlParameter("@paramNoOfPassanger", SqlDbType.Int);
                    Param[20].Value = FQDetails.NoOfPassanger;
                }
                if (!string.IsNullOrEmpty(FQDetails.NoOfNights))
                {
                    Param[21] = new SqlParameter("@paramNoOfNights", SqlDbType.NVarChar);
                    Param[21].Value = FQDetails.NoOfNights;
                }
                //if (!string.IsNullOrEmpty(FQDetails.FeedBackType))
                //{
                //    Param[22] = new SqlParameter("@paramFeedBackType", SqlDbType.NVarChar);
                //    Param[22].Value = FQDetails.FeedBackType;
                //}
                if (!string.IsNullOrEmpty(FQDetails.Subject))
                {
                    Param[23] = new SqlParameter("@paramSubject", SqlDbType.NVarChar);
                    Param[23].Value = FQDetails.Subject;
                }
                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    int i = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "InsertFareQuotes", Param);
                    return i > 0 ? true : false;
                }
            }
            catch { return false; }
            //---
        }

        public static bool InsertCallBackEnquiry(HolidayEnq FQDetails)
        {
            
            try
            {
                SqlParameter[] Param = new SqlParameter[24];

                if (!string.IsNullOrEmpty(FQDetails.FirstName))
                {
                    Param[0] = new SqlParameter("@paramFirstName", SqlDbType.NVarChar);
                    Param[0].Value = FQDetails.FirstName;
                }
                if (!string.IsNullOrEmpty(FQDetails.LastName))
                {
                    Param[1] = new SqlParameter("@paramLastName", SqlDbType.NVarChar);
                    Param[1].Value = FQDetails.LastName;
                }
                if (!string.IsNullOrEmpty(FQDetails.Phone))
                {
                    Param[2] = new SqlParameter("@paramPhone", SqlDbType.NVarChar);
                    Param[2].Value = FQDetails.Phone;
                }
                if (!string.IsNullOrEmpty(FQDetails.Email))
                {
                    Param[3] = new SqlParameter("@paramRefCode", SqlDbType.NVarChar);
                    Param[3].Value = FQDetails.RefCode;
                }
                
                if (!string.IsNullOrEmpty(FQDetails.DepartCityCode))
                {
                    Param[7] = new SqlParameter("@paramDepartCityCode", SqlDbType.NVarChar);
                    Param[7].Value = FQDetails.DepartCityCode;
                }
                if (!string.IsNullOrEmpty(FQDetails.DestCityCode))
                {
                    Param[8] = new SqlParameter("@paramDestCityCode", SqlDbType.NVarChar);
                    Param[8].Value = FQDetails.DestCityCode;
                }
                if (!string.IsNullOrEmpty(FQDetails.Class))
                {
                    Param[9] = new SqlParameter("@paramClass", SqlDbType.NVarChar);
                    Param[9].Value = FQDetails.Class;
                }
                if (FQDetails.CallDate != null)
                {
                    Param[10] = new SqlParameter("@paramCallDate", SqlDbType.Date);
                    Param[10].Value = FQDetails.CallDate;
                }
                if (!string.IsNullOrEmpty(FQDetails.CallTime))
                {
                    Param[11] = new SqlParameter("@paramCallTime", SqlDbType.NVarChar);
                    Param[11].Value = FQDetails.CallTime;
                }
                if (!string.IsNullOrEmpty(FQDetails.CallRemarks))
                {
                    Param[12] = new SqlParameter("@paramCallRemarks", SqlDbType.NVarChar);
                    Param[12].Value = FQDetails.CallRemarks;
                }
                //if (FQDetails.dDateTime != null)
                //{
                //    Param[13] = new SqlParameter("@paramDateTime", SqlDbType.DateTime);
                //    Param[13].Value = FQDetails.dDateTime;
                //}
                if (!string.IsNullOrEmpty(FQDetails.Company))
                {
                    Param[14] = new SqlParameter("@paramCompany", SqlDbType.NVarChar);
                    Param[14].Value = FQDetails.Company;
                }
                if (!string.IsNullOrEmpty(FQDetails.EnquiryType))
                {
                    Param[15] = new SqlParameter("@paramEnquiryType", SqlDbType.NVarChar);
                    Param[15].Value = FQDetails.EnquiryType;
                }
                if (!string.IsNullOrEmpty(FQDetails.Title))
                {
                    Param[16] = new SqlParameter("@paramTitle", SqlDbType.NVarChar);
                    Param[16].Value = FQDetails.Title;
                }
                if (!string.IsNullOrEmpty(FQDetails.Title))
                {
                    Param[17] = new SqlParameter("@paramContactNo", SqlDbType.NVarChar);
                    Param[17].Value = FQDetails.ContactNo;
                }
                if (!string.IsNullOrEmpty(FQDetails.City))
                {
                    Param[18] = new SqlParameter("@paramCity", SqlDbType.NVarChar);
                    Param[18].Value = FQDetails.City;
                }
                if (!string.IsNullOrEmpty(FQDetails.BoardBasis))
                {
                    Param[19] = new SqlParameter("@paramBoardBasis", SqlDbType.NVarChar);
                    Param[19].Value = FQDetails.BoardBasis;
                }
                if (FQDetails.NoOfPassanger != null)
                {
                    Param[20] = new SqlParameter("@paramNoOfPassanger", SqlDbType.Int);
                    Param[20].Value = FQDetails.NoOfPassanger;
                }
                if (!string.IsNullOrEmpty(FQDetails.NoOfNights))
                {
                    Param[21] = new SqlParameter("@paramNoOfNights", SqlDbType.NVarChar);
                    Param[21].Value = FQDetails.NoOfNights;
                }
                //if (!string.IsNullOrEmpty(FQDetails.FeedBackType))
                //{
                //    Param[22] = new SqlParameter("@paramFeedBackType", SqlDbType.NVarChar);
                //    Param[22].Value = FQDetails.FeedBackType;
                //}
                if (!string.IsNullOrEmpty(FQDetails.Subject))
                {
                    Param[23] = new SqlParameter("@paramSubject", SqlDbType.NVarChar);
                    Param[23].Value = FQDetails.Subject;
                }
                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    int i = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "InsertFareQuotes", Param);
                    return i > 0 ? true : false;
                }
            }
            catch { return false; }
            //------

        }
        public static bool InsertFeedBackEnquiry(HolidayEnq ObjHE)
        {

            bool Rval = Global.ExecuteNonQuery(new object[] {"InsertFareQuotes"
                                                    ,"@paramFirstName",ObjHE.FirstName
                                                    ,"@paramLastName",ObjHE.LastName
                                                    ,"@paramPhone",ObjHE.ContactNo  
                                                    ,"@paramEMail",ObjHE.Email  
                                                    ,"@paramFeedBackType",ObjHE.FeedBackType
                                                    ,"@paramSubject",ObjHE.Subject                                                    
                                                    ,"@paramRefCode",ObjHE.RefCode                                                                                                                                              
                                                    ,"@paramCompany",ObjHE.Company
                                                    ,"@paramEnquiryType",ObjHE.EnquiryType
                                                    ,"@paramTitle",ObjHE.Title                                                  
                                                    ,"@paramCallRemarks",ObjHE.CallRemarks                                                    
                                                    
                 }, DataConnection.GetOffLineFareConnection());

            return Rval;
        }
    }
}
