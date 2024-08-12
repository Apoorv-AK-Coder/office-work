using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace TravelSite.Models
{
    public class DatabaseAccess
    {
        public static bool Set_SearchResultDetails(string FileName, string Content)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    string _CommandText = string.Empty;
                    SqlParameter[] param = new SqlParameter[3];
                    _CommandText = "getSet_SearchResultDetails";

                    param[0] = new SqlParameter("@paramFileName", SqlDbType.VarChar, (200));
                    param[0].Value = FileName;

                    param[1] = new SqlParameter("@paramContent", SqlDbType.Xml);
                    param[1].Value = Content;

                    param[2] = new SqlParameter("@paramType", SqlDbType.VarChar, (200));
                    param[2].Value = "insert";

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string get_SearchResultDetails(string FileName)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    string _CommandText = string.Empty;
                    SqlParameter[] param = new SqlParameter[2];
                    _CommandText = "getSet_SearchResultDetails";

                    param[0] = new SqlParameter("@paramFileName", SqlDbType.VarChar, (200));
                    param[0].Value = FileName;

                    param[1] = new SqlParameter("@paramType", SqlDbType.VarChar, (200));
                    param[1].Value = "select";

                    string str = Convert.ToString(SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, _CommandText, param));
                    if (string.IsNullOrEmpty(str))
                    {
                        str = "<Itineraries></Itineraries>";
                    }
                    return str;
                }
            }
            catch
            {
                return "<Itineraries></Itineraries>";
            }
        }

        public static DataTable Get_CompanyPhones(string sCompanyID, string sSourceMedia)
        {
            DataTable dtPhone = new DataTable();
            using (SqlConnection SqlConn = DataConnection.GetConnectionMoresand())
            {
                SqlConn.Open();
                using (SqlCommand SqlCmd = new SqlCommand("GetSetCompanyPhoneDetails", SqlConn))
                {
                    using (SqlDataAdapter SqlDA = new SqlDataAdapter())
                    {
                        SqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlCmd.Parameters.AddWithValue("@prmCompanyID", sCompanyID);
                        SqlCmd.Parameters.AddWithValue("@prmSourceMedia", sSourceMedia);
                        SqlCmd.Parameters.AddWithValue("@prmQueryType", "SEL");
                        SqlDA.SelectCommand = SqlCmd;
                        SqlDA.Fill(dtPhone);
                        SqlConn.Close();
                    }
                }
            }
            return dtPhone;
        }

        #region InsertOfflineBookingDetails
        public bool InsertFlightBookingDetails(string bkngMst_bookingId, string bkngMst_reference, string bkngMst_origin,
            string bkngMst_destination, string bkngMst_productBookingStatus, string bkngMst_productBookingRemarks,
            string bkngMst_productTotalAmount, string bkngMst_currencyType, string bkngMst_bookingByCompany, string BM_IsInsertBM,

            string bkngDtl_productBookingId, string bkngDtl_productProvider, string bkngDtl_productBookingBy,
            string bkngDtl_productBookingByType, string bkngDtl_productBookingDateTime, string bkngDtl_productBookingStatus,
            string bkngDtl_productTotalAmount, string bkngDtl_productType, string bkngDtl_productSupplier,
            string bkngDtl_productUpdateTime, string bkngDtl_firstName, string bkngDtl_lastName, string bkngDtl_travelStartDate,
            string bkngDtl_productBookingRemarkComment, string bkngDtl_productBookingRemarks, string bkngDtl_productIsLocked,
            string bkngDtl_productModifiedBy, string bkngDtl_productFareType,

            string cntDtl_bookingId, string cntDtl_productBookingId, string cntDtl_paxId, string cntDtl_contactNumber,
            string cntDtl_fax, string cntDtl_emailAddress, string cntDtl_country, string cntDtl_city, string cntDtl_address,
            string cntDtl_postalCode, string cntDtl_addressType, string cntDtl_phoneNo, string cntDtl_state,

            string crdDtl_bookingId, string crdDtl_transactionNo, string crdDtl_cardNo, string crdDtl_cardHolderName,
            string crdDtl_cardExpiryDate, string crdDtl_cardSecurityCode, string crdDtl_cardType, string crdDtl_cardCountry,
            string crdDtl_cardCountryState, string crdDtl_cardCity, string crdDtl_cardPostalCode, string crdDtl_cardAddress,
            string crdDtl_cardCharges, string crdDtl_cardChargesType,

            DataTable pax, DataTable amChg, DataTable seg)
        {
            string _CommandText = string.Empty;
            SqlParameter[] param = new SqlParameter[61];

            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "Usp_OfflineBookingDetail_Insert";

                    #region
                    param[0] = new SqlParameter("@ParamBM_BookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = bkngMst_bookingId;

                    param[1] = new SqlParameter("@ParamBM_InvoiceNo", SqlDbType.NVarChar, (50));
                    param[1].Value = bkngMst_reference;
                    #region
                    if (!string.IsNullOrEmpty(bkngMst_origin))
                    {
                        param[2] = new SqlParameter("@ParamBM_Origin", SqlDbType.NVarChar, (50));
                        param[2].Value = bkngMst_origin;
                    }
                    if (!string.IsNullOrEmpty(bkngMst_destination))
                    {
                        param[3] = new SqlParameter("@ParamBM_Destination", SqlDbType.NVarChar, (50));
                        param[3].Value = bkngMst_destination;
                    }
                    if (!string.IsNullOrEmpty(bkngMst_productBookingStatus))
                    {
                        param[4] = new SqlParameter("@ParamBM_BookingStatus", SqlDbType.NVarChar, (50));
                        param[4].Value = bkngMst_productBookingStatus;
                    }
                    if (!string.IsNullOrEmpty(bkngMst_productBookingRemarks))
                    {
                        param[5] = new SqlParameter("@ParamBM_BookingRemarks", SqlDbType.NVarChar, (50));
                        param[5].Value = bkngMst_productBookingRemarks;
                    }
                    if (!string.IsNullOrEmpty(bkngMst_productTotalAmount))
                    {
                        param[6] = new SqlParameter("@ParamBM_BookingTotalAmount", SqlDbType.Money, (50));
                        param[6].Value = bkngMst_productTotalAmount;
                    }
                    if (!string.IsNullOrEmpty(bkngMst_currencyType))
                    {
                        param[7] = new SqlParameter("@ParamBM_CurrencyType", SqlDbType.NVarChar, (50));
                        param[7].Value = bkngMst_currencyType;
                    }
                    if (!string.IsNullOrEmpty(bkngMst_bookingByCompany))
                    {
                        param[8] = new SqlParameter("@ParamBM_BookingByCompany", SqlDbType.NVarChar, (50));
                        param[8].Value = bkngMst_bookingByCompany;
                    }
                    if (!string.IsNullOrEmpty(BM_IsInsertBM))
                    {
                        param[9] = new SqlParameter("@paramBM_IsInsertBM", SqlDbType.NVarChar, (50));
                        param[9].Value = BM_IsInsertBM;
                    }
                    #endregion

                    #region
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingId))
                    {
                        param[10] = new SqlParameter("@ParamBD_productBookingId", SqlDbType.NVarChar, (50));
                        param[10].Value = bkngDtl_productBookingId;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productProvider))
                    {
                        param[11] = new SqlParameter("@ParamBD_productProvider", SqlDbType.NVarChar, (50));
                        param[11].Value = bkngDtl_productProvider;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingBy))
                    {
                        param[12] = new SqlParameter("@ParamBD_productBookingBy", SqlDbType.NVarChar, (50));
                        param[12].Value = bkngDtl_productBookingBy;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingByType))
                    {
                        param[13] = new SqlParameter("@ParamBD_productBookingByType", SqlDbType.NVarChar, (50));
                        param[13].Value = bkngDtl_productBookingByType;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingDateTime))
                    {
                        param[14] = new SqlParameter("@ParamBD_productBookingDateTime", SqlDbType.DateTime, (50));
                        param[14].Value = bkngDtl_productBookingDateTime;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingStatus))
                    {
                        param[15] = new SqlParameter("@ParamBD_productBookingStatus", SqlDbType.NVarChar, (50));
                        param[15].Value = bkngDtl_productBookingStatus;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productTotalAmount))
                    {
                        param[16] = new SqlParameter("@ParamBD_productTotalAmount", SqlDbType.Money, (50));
                        param[16].Value = bkngDtl_productTotalAmount;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productType))
                    {
                        param[17] = new SqlParameter("@ParamBD_productType", SqlDbType.NVarChar, (50));
                        param[17].Value = bkngDtl_productType;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productSupplier))
                    {
                        param[18] = new SqlParameter("@ParamBD_productSupplier", SqlDbType.NVarChar, (50));
                        param[18].Value = bkngDtl_productSupplier;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productUpdateTime))
                    {
                        param[19] = new SqlParameter("@ParamBD_productUpdateTime", SqlDbType.DateTime, (50));
                        param[19].Value = bkngDtl_productUpdateTime;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_firstName))
                    {
                        param[20] = new SqlParameter("@ParamBD_firstName", SqlDbType.NVarChar, (50));
                        param[20].Value = bkngDtl_firstName;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_lastName))
                    {
                        param[21] = new SqlParameter("@ParamBD_lastName", SqlDbType.NVarChar, (50));
                        param[21].Value = bkngDtl_lastName;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_travelStartDate))
                    {
                        param[22] = new SqlParameter("@ParamBD_travelStartDate", SqlDbType.DateTime, (50));
                        param[22].Value = bkngDtl_travelStartDate;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingRemarkComment))
                    {
                        param[23] = new SqlParameter("@ParamBD_productBookingRemarkComment", SqlDbType.NVarChar, (50));
                        param[23].Value = bkngDtl_productBookingRemarkComment;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productBookingRemarks))
                    {
                        param[24] = new SqlParameter("@ParamBD_productBookingRemarks", SqlDbType.NVarChar, (50));
                        param[24].Value = bkngDtl_productBookingRemarks;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productIsLocked))
                    {
                        param[25] = new SqlParameter("@ParamBD_productIsLocked", SqlDbType.NVarChar, (50));
                        param[25].Value = bool.Parse(bkngDtl_productIsLocked);
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productModifiedBy))
                    {
                        param[26] = new SqlParameter("@ParamBD_productModifiedBy", SqlDbType.NVarChar, (50));
                        param[26].Value = bkngDtl_productModifiedBy;
                    }
                    if (!string.IsNullOrEmpty(bkngDtl_productFareType))
                    {
                        param[27] = new SqlParameter("@ParamBD_productFareType", SqlDbType.NVarChar, (50));
                        param[27].Value = bkngDtl_productFareType;
                    }
                    #endregion

                    #region
                    if (!string.IsNullOrEmpty(cntDtl_bookingId))
                    {
                        param[28] = new SqlParameter("@ParamCNT_cnt_bookingId", SqlDbType.NVarChar, (50));
                        param[28].Value = cntDtl_bookingId;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_productBookingId))
                    {
                        param[29] = new SqlParameter("@ParamCNT_cnt_productBookingId", SqlDbType.NVarChar, (50));
                        param[29].Value = cntDtl_productBookingId;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_paxId))
                    {
                        param[30] = new SqlParameter("@ParamCNT_paxId", SqlDbType.NVarChar, (50));
                        param[30].Value = cntDtl_paxId;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_contactNumber))
                    {
                        param[31] = new SqlParameter("@ParamCNT_contactNumber", SqlDbType.NVarChar, (50));
                        param[31].Value = cntDtl_contactNumber;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_fax))
                    {
                        param[32] = new SqlParameter("@ParamCNT_fax", SqlDbType.NVarChar, (50));
                        param[32].Value = cntDtl_fax;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_emailAddress))
                    {
                        param[33] = new SqlParameter("@ParamCNT_emailAddress", SqlDbType.NVarChar, (50));
                        param[33].Value = cntDtl_emailAddress;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_country))
                    {
                        param[34] = new SqlParameter("@ParamCNT_country", SqlDbType.NVarChar, (50));
                        param[34].Value = cntDtl_country;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_city))
                    {
                        param[35] = new SqlParameter("@ParamCNT_city", SqlDbType.NVarChar, (50));
                        param[35].Value = cntDtl_city;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_address))
                    {
                        param[36] = new SqlParameter("@ParamCNT_address", SqlDbType.NVarChar, (50));
                        param[36].Value = cntDtl_address;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_postalCode))
                    {
                        param[37] = new SqlParameter("@ParamCNT_postalCode", SqlDbType.NVarChar, (50));
                        param[37].Value = cntDtl_postalCode;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_addressType))
                    {
                        param[38] = new SqlParameter("@ParamCNT_addressType", SqlDbType.NVarChar, (50));
                        param[38].Value = cntDtl_addressType;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_phoneNo))
                    {
                        param[39] = new SqlParameter("@ParamCNT_phoneNo", SqlDbType.NVarChar, (50));
                        param[39].Value = cntDtl_phoneNo;
                    }
                    if (!string.IsNullOrEmpty(cntDtl_state))
                    {
                        param[40] = new SqlParameter("@ParamCNT_state", SqlDbType.NVarChar, (50));
                        param[40].Value = cntDtl_state;
                    }
                    #endregion

                    #region
                    if (!string.IsNullOrEmpty(crdDtl_bookingId))
                    {
                        param[41] = new SqlParameter("@ParamCRD_crd_bookingId", SqlDbType.NVarChar, (50));
                        param[41].Value = crdDtl_bookingId;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_transactionNo))
                    {
                        param[42] = new SqlParameter("@ParamCRD_transactionNo", SqlDbType.NVarChar, (50));
                        param[42].Value = crdDtl_transactionNo;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardNo))
                    {
                        param[43] = new SqlParameter("@ParamCRD_cardNo", SqlDbType.NVarChar, (50));
                        param[43].Value = crdDtl_cardNo;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardHolderName))
                    {
                        param[44] = new SqlParameter("@ParamCRD_cardHolderName", SqlDbType.NVarChar, (50));
                        param[44].Value = crdDtl_cardHolderName;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardExpiryDate))
                    {
                        param[45] = new SqlParameter("@ParamCRD_cardExpiryDate", SqlDbType.NVarChar, (50));
                        param[45].Value = crdDtl_cardExpiryDate;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardSecurityCode))
                    {
                        param[46] = new SqlParameter("@ParamCRD_cardSecurityCode", SqlDbType.NVarChar, (50));
                        param[46].Value = crdDtl_cardSecurityCode;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardType))
                    {
                        param[47] = new SqlParameter("@ParamCRD_cardType", SqlDbType.NVarChar, (50));
                        param[47].Value = crdDtl_cardType;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardCountry))
                    {
                        param[48] = new SqlParameter("@ParamCRD_cardCountry", SqlDbType.NVarChar, (50));
                        param[48].Value = crdDtl_cardCountry;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardCountryState))
                    {
                        param[49] = new SqlParameter("@ParamCRD_cardCountryState", SqlDbType.NVarChar, (50));
                        param[49].Value = crdDtl_cardCountryState;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardCity))
                    {
                        param[50] = new SqlParameter("@ParamCRD_cardCity", SqlDbType.NVarChar, (50));
                        param[50].Value = crdDtl_cardCity;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardPostalCode))
                    {
                        param[51] = new SqlParameter("@ParamCRD_cardPostalCode", SqlDbType.NVarChar, (50));
                        param[51].Value = crdDtl_cardPostalCode;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardAddress))
                    {
                        param[52] = new SqlParameter("@ParamCRD_cardAddress", SqlDbType.NVarChar, (50));
                        param[52].Value = crdDtl_cardAddress;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardCharges))
                    {
                        param[53] = new SqlParameter("@ParamCRD_cardCharges", SqlDbType.Money, (50));
                        param[53].Value = crdDtl_cardCharges;
                    }
                    if (!string.IsNullOrEmpty(crdDtl_cardChargesType))
                    {
                        param[54] = new SqlParameter("@ParamCRD_cardChargesType ", SqlDbType.Char, (4));
                        param[54].Value = crdDtl_cardChargesType;
                    }
                    #endregion

                    param[55] = new SqlParameter("@ParamPassengers", pax);
                    param[56] = new SqlParameter("@ParamAmountCharges", amChg);
                    param[57] = new SqlParameter("@ParamAirSectors", seg);

                    //param[58] = new SqlParameter("@ParamCheck ", SqlDbType.Int);
                    //param[58].Value = 0;

                    param[58] = new SqlParameter("@ParamCheck", SqlDbType.Int);
                    param[58].Direction = ParameterDirection.Output;

                    param[59] = new SqlParameter("@paramStatus", SqlDbType.Bit);
                    param[59].Direction = ParameterDirection.Output;

                    param[60] = new SqlParameter("@ParamError", SqlDbType.NVarChar, (1000));
                    param[60].Direction = ParameterDirection.Output;

                    #endregion


                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    var Error_string = param[60].Value;
                    var Check_Int = param[58].Value;
                    return Convert.ToBoolean(param[59].Value);

                }
            }
            catch (Exception ex)
            {

            }

            return true;
        }


        public bool InsertFlightBookingDetails(string BM_BookingID, string BM_InvoiceNo, string BM_Origin,
         string BM_Destination, string BM_BookingStatus, string BM_BookingRemarks, double BM_BookingTotalAmount,
         string BM_BookingType, string BM_CurrencyType, string BM_BookingByCompany, string BM_IsInsertBM,
         string BD_ProdID, string BD_Provider, string BD_BookingBy, string BD_BookingByType,
         string BD_BookingDateTime, string BD_BookingStatus, string BD_BookingRemarks, double BD_TotalAmount,
         string BD_PNR, string BD_SourceMedia, string BD_ProductType, string BD_ModifiedBy, string BD_Supplier,
         string SM_JourneyType, string SM_LastTktDate, string SM_Origin, string SM_Destination,
         string SM_ValidatingCarrier, string SM_CabinClass, string CD_PaxID, string CD_ContactNo, string CD_PhoneNo, string CD_FaxNo,
         string CD_EmailID, string CD_Country, string CD_City, string CD_Address, string CD_PostCode,
         string CD_AddressType, DataTable dtAirSectors, DataTable dtAmountCharges, DataTable dtPassengers, string Airline_change, string FareType, int UsrID, string BD_FirstName, string BD_LastName, string BD_TravelStartDate, string Communication, string GeoCode, string CountryCode, string SM_TstTime,double Markup)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[50];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "Usp_InsertFlightOnline";
                    param[0] = new SqlParameter("@BookingId", SqlDbType.NVarChar, (50));
                    param[0].Value = BM_BookingID;
                    if (!string.IsNullOrEmpty(BM_InvoiceNo))
                    {
                        param[1] = new SqlParameter("@InvoiceNo", SqlDbType.NVarChar, (50));
                        param[1].Value = BM_InvoiceNo;
                    }
                    if (!string.IsNullOrEmpty(BM_Origin))
                    {
                        param[2] = new SqlParameter("@Origin", SqlDbType.NVarChar, (150));
                        param[2].Value = BM_Origin;
                    }
                    if (!string.IsNullOrEmpty(BM_Destination))
                    {
                        param[3] = new SqlParameter("@Destination", SqlDbType.NVarChar, (150));
                        param[3].Value = BM_Destination;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingStatus))
                    {
                        param[4] = new SqlParameter("@BookingStatus", SqlDbType.NVarChar, (100));
                        param[4].Value = "2";
                    }
                    if (!string.IsNullOrEmpty(BM_BookingRemarks))
                    {
                        param[5] = new SqlParameter("@Remark", SqlDbType.NVarChar, (2000));
                        param[5].Value = BM_BookingRemarks;
                    }

                    param[6] = new SqlParameter("@TotalAmount", SqlDbType.Money);
                    param[6].Value = BM_BookingTotalAmount;

                    if (!string.IsNullOrEmpty(BM_BookingType))
                    {
                        param[7] = new SqlParameter("@BookingType", SqlDbType.NVarChar, (50));
                        param[7].Value = BM_BookingType;
                    }
                    if (!string.IsNullOrEmpty(BM_CurrencyType))
                    {
                        param[8] = new SqlParameter("@CurrencyType", SqlDbType.NVarChar, (25));
                        param[8].Value = BM_CurrencyType;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingByCompany))
                    {
                        param[9] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, (50));
                        param[9].Value = BM_BookingByCompany;
                    }

                    param[10] = new SqlParameter("@IsInsertBM", SqlDbType.NVarChar, (50));
                    param[10].Value = BM_IsInsertBM;

                    param[11] = new SqlParameter("@ProdId", SqlDbType.NVarChar, (50));
                    param[11].Value = BD_ProdID;

                    if (!string.IsNullOrEmpty(BD_Provider))
                    {
                        param[12] = new SqlParameter("@Provider", SqlDbType.NVarChar, (50));
                        param[12].Value = BD_Provider;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingBy))
                    {
                        param[13] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
                        param[13].Value = UsrID;
                    }

                    if (!string.IsNullOrEmpty(BD_BookingDateTime))
                    {
                        param[14] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                        param[14].Value = Convert.ToDateTime(BD_BookingDateTime);
                    }

                    if (!string.IsNullOrEmpty(BD_PNR))
                    {
                        param[15] = new SqlParameter("@PNR", SqlDbType.NVarChar, (50));
                        param[15].Value = BD_PNR;
                    }
                    if (!string.IsNullOrEmpty(BD_SourceMedia))
                    {
                        param[16] = new SqlParameter("@SourceMedia", SqlDbType.NVarChar, (50));
                        param[16].Value = BD_SourceMedia;
                    }
                    if (!string.IsNullOrEmpty(BD_ProductType))
                    {
                        param[17] = new SqlParameter("@ProductType", SqlDbType.VarChar, (50));
                        param[17].Value = BD_ProductType;
                    }
                    param[18] = new SqlParameter("@ReferenceNo", SqlDbType.VarChar, (100));
                    param[18].Value = BM_BookingID;

                    if (!string.IsNullOrEmpty(BD_Supplier))
                    {
                        param[19] = new SqlParameter("@Supplier", SqlDbType.VarChar, (100));
                        param[19].Value = BD_Supplier;
                    }
                    if (!string.IsNullOrEmpty(SM_JourneyType))
                    {
                        param[20] = new SqlParameter("@JourneyType", SqlDbType.NVarChar, (100));
                        param[20].Value = SM_JourneyType;
                    }
                    if (!string.IsNullOrEmpty(SM_LastTktDate))
                    {
                        param[21] = new SqlParameter("@LastTktDate", SqlDbType.NVarChar, (200));
                        param[21].Value = SM_LastTktDate;
                    }

                    if (!string.IsNullOrEmpty(SM_ValidatingCarrier))
                    {
                        param[22] = new SqlParameter("@ValidatingCarrier", SqlDbType.NVarChar, (150));
                        param[22].Value = SM_ValidatingCarrier;
                    }
                    if (!string.IsNullOrEmpty(SM_CabinClass))
                    {
                        param[23] = new SqlParameter("@CabinClass", SqlDbType.VarChar, (50));
                        param[23].Value = SM_CabinClass;
                    }

                    param[25] = new SqlParameter("@AirSectors", dtAirSectors);
                    param[26] = new SqlParameter("@AmountCharges", dtAmountCharges);
                    param[27] = new SqlParameter("@Passengers", dtPassengers);
                    //param[28] = new SqlParameter("@ParamCheck", SqlDbType.Int);
                    //param[28].Direction = ParameterDirection.Output;
                    param[29] = new SqlParameter("@ParamError", SqlDbType.NVarChar, (500));
                    param[29].Direction = ParameterDirection.Output;

                    if (!string.IsNullOrEmpty(FareType))
                    {
                        param[30] = new SqlParameter("@FareType", SqlDbType.NVarChar, (15));
                        param[30].Value = FareType;
                    }
                    if (UsrID != 0)
                    {
                        param[31] = new SqlParameter("@ClientId", SqlDbType.Int);
                        param[31].Value = UsrID;
                    }

                    if (!string.IsNullOrEmpty(BD_FirstName))
                    {
                        param[32] = new SqlParameter("@Firstname", SqlDbType.NVarChar, (100));
                        param[32].Value = BD_FirstName;
                    }
                    if (!string.IsNullOrEmpty(BD_LastName))
                    {
                        param[33] = new SqlParameter("@LastName", SqlDbType.NVarChar, (100));
                        param[33].Value = BD_LastName;
                    }
                    if (!string.IsNullOrEmpty(BD_TravelStartDate))
                    {
                        param[34] = new SqlParameter("@TravelStartDate", SqlDbType.DateTime);
                        param[34].Value = BD_TravelStartDate;
                    }

                    if (!string.IsNullOrEmpty(CountryCode))
                    {
                        param[35] = new SqlParameter("@CountryCode", SqlDbType.NVarChar, (100));
                        param[35].Value = CountryCode;
                    }
                    param[36] = new SqlParameter("@ParamStatus", SqlDbType.Bit);
                    param[36].Direction = ParameterDirection.Output;
                    param[37] = new SqlParameter("@DocType", SqlDbType.Char);
                    param[37].Value = "O";

                    param[38] = new SqlParameter("@Email", SqlDbType.NVarChar, (150));
                    param[38].Value = CD_EmailID;
                    param[39] = new SqlParameter("@Phone", SqlDbType.NVarChar, (20));
                    param[39].Value = CD_PhoneNo;
                    param[40] = new SqlParameter("@Mobile", SqlDbType.NVarChar, (20));
                    param[40].Value = CD_ContactNo;
                    param[41] = new SqlParameter("@City", SqlDbType.NVarChar, (100));
                    param[41].Value = CD_City;
                    param[42] = new SqlParameter("@Address", SqlDbType.NVarChar, (1000));
                    param[42].Value = CD_Address;
                    param[43] = new SqlParameter("@PostCode", SqlDbType.NVarChar, (100));
                    param[43].Value = CD_PostCode;
                    param[44] = new SqlParameter("@Markup", SqlDbType.Money);
                    param[44].Value = Markup;

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);

                    if (count > 0 || string.IsNullOrEmpty(param[29].Value.ToString()))
                        return true;
                    else
                        return false;
                    //return Convert.ToBoolean(param[28].Value); @Markup
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }




        #endregion
        public bool InsertFlightBookingDetails(string BM_BookingID, string BM_InvoiceNo, string BM_Origin,
            string BM_Destination, string BM_BookingStatus, string BM_BookingRemarks, double BM_BookingTotalAmount,
            string BM_BookingType, string BM_CurrencyType, string BM_BookingByCompany, string BM_IsInsertBM,
            string BD_ProdID, string BD_Provider, string BD_BookingBy, string BD_BookingByType,
            string BD_BookingDateTime, string BD_BookingStatus, string BD_BookingRemarks, double BD_TotalAmount,
            string BD_PNR, string BD_SourceMedia, string BD_ProductType, string BD_ModifiedBy, string BD_Supplier,
            string SM_JourneyType, string SM_LastTktDate, string SM_Origin, string SM_Destination,
            string SM_ValidatingCarrier, string SM_CabinClass, string CD_PaxID, string CD_ContactNo, string CD_PhoneNo, string CD_FaxNo,
            string CD_EmailID, string CD_Country, string CD_City, string CD_Address, string CD_PostCode,
            string CD_AddressType, DataTable dtAirSectors, DataTable dtAmountCharges, DataTable dtPassengers, string Airline_change, string FareType, int UsrID, string BD_FirstName, string BD_LastName, string BD_TravelStartDate)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[50];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "InsertFlightBooking_New";
                    param[0] = new SqlParameter("@ParamBM_BookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = BM_BookingID;
                    if (!string.IsNullOrEmpty(BM_InvoiceNo))
                    {
                        param[1] = new SqlParameter("@ParamBM_InvoiceNo", SqlDbType.NVarChar, (50));
                        param[1].Value = BM_InvoiceNo;
                    }
                    if (!string.IsNullOrEmpty(BM_Origin))
                    {
                        param[2] = new SqlParameter("@ParamBM_Origin", SqlDbType.NVarChar, (150));
                        param[2].Value = BM_Origin;
                    }
                    if (!string.IsNullOrEmpty(BM_Destination))
                    {
                        param[3] = new SqlParameter("@ParamBM_Destination", SqlDbType.NVarChar, (150));
                        param[3].Value = BM_Destination;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingStatus))
                    {
                        param[4] = new SqlParameter("@ParamBM_BookingStatus", SqlDbType.NVarChar, (100));
                        param[4].Value = BM_BookingStatus;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingRemarks))
                    {
                        param[5] = new SqlParameter("@ParamBM_BookingRemarks", SqlDbType.NVarChar, (2000));
                        param[5].Value = BM_BookingRemarks;
                    }

                    param[6] = new SqlParameter("@ParamBM_BookingTotalAmount", SqlDbType.Money);
                    param[6].Value = BM_BookingTotalAmount;

                    if (!string.IsNullOrEmpty(BM_BookingType))
                    {
                        param[7] = new SqlParameter("@ParamBM_BookingType", SqlDbType.NVarChar, (50));
                        param[7].Value = BM_BookingType;
                    }
                    if (!string.IsNullOrEmpty(BM_CurrencyType))
                    {
                        param[8] = new SqlParameter("@ParamBM_CurrencyType", SqlDbType.NVarChar, (25));
                        param[8].Value = BM_CurrencyType;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingByCompany))
                    {
                        param[9] = new SqlParameter("@ParamBM_BookingByCompany", SqlDbType.NVarChar, (50));
                        param[9].Value = BM_BookingByCompany;
                    }

                    param[10] = new SqlParameter("@ParamBM_IsInsertBM", SqlDbType.NVarChar, (50));
                    param[10].Value = BM_IsInsertBM;

                    param[11] = new SqlParameter("@ParamBD_ProdID", SqlDbType.NVarChar, (50));
                    param[11].Value = BD_ProdID;

                    if (!string.IsNullOrEmpty(BD_Provider))
                    {
                        param[12] = new SqlParameter("@ParamBD_Provider", SqlDbType.NVarChar, (50));
                        param[12].Value = BD_Provider;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingBy))
                    {
                        param[13] = new SqlParameter("@ParamBD_BookingBy", SqlDbType.NVarChar, (100));
                        param[13].Value = BD_BookingBy;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingByType))
                    {
                        param[14] = new SqlParameter("@ParamBD_BookingByType", SqlDbType.NVarChar, (100));
                        param[14].Value = BD_BookingByType;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingDateTime))
                    {
                        param[15] = new SqlParameter("@ParamBD_BookingDateTime", SqlDbType.DateTime);
                        param[15].Value = Convert.ToDateTime(BD_BookingDateTime);
                    }
                    if (!string.IsNullOrEmpty(BD_BookingStatus))
                    {
                        param[16] = new SqlParameter("@ParamBD_BookingStatus", SqlDbType.NVarChar, (50));
                        param[16].Value = BD_BookingStatus;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingRemarks))
                    {
                        param[17] = new SqlParameter("@ParamBD_BookingRemarks", SqlDbType.NVarChar, (2000));
                        param[17].Value = BD_BookingRemarks;
                    }

                    param[18] = new SqlParameter("@ParamBD_TotalAmount", SqlDbType.Money);
                    param[18].Value = BD_TotalAmount;

                    if (!string.IsNullOrEmpty(BD_PNR))
                    {
                        param[19] = new SqlParameter("@ParamBD_PNR", SqlDbType.NVarChar, (50));
                        param[19].Value = BD_PNR;
                    }
                    if (!string.IsNullOrEmpty(BD_SourceMedia))
                    {
                        param[20] = new SqlParameter("@ParamBD_SourceMedia", SqlDbType.NVarChar, (50));
                        param[20].Value = BD_SourceMedia;
                    }
                    if (!string.IsNullOrEmpty(BD_ProductType))
                    {
                        param[21] = new SqlParameter("@ParamBD_ProductType", SqlDbType.VarChar, (50));
                        param[21].Value = BD_ProductType;
                    }
                    if (!string.IsNullOrEmpty(BD_ModifiedBy))
                    {
                        param[22] = new SqlParameter("@ParamBD_ModifiedBy", SqlDbType.VarChar, (100));
                        param[22].Value = BD_ModifiedBy;
                    }
                    if (!string.IsNullOrEmpty(BD_Supplier))
                    {
                        param[23] = new SqlParameter("@ParamBD_Supplier", SqlDbType.VarChar, (100));
                        param[23].Value = BD_Supplier;
                    }
                    if (!string.IsNullOrEmpty(SM_JourneyType))
                    {
                        param[24] = new SqlParameter("@ParamSM_JourneyType", SqlDbType.NVarChar, (100));
                        param[24].Value = SM_JourneyType;
                    }
                    if (!string.IsNullOrEmpty(SM_LastTktDate))
                    {
                        param[25] = new SqlParameter("@ParamSM_LastTktDate", SqlDbType.NVarChar, (200));
                        param[25].Value = SM_LastTktDate;
                    }
                    if (!string.IsNullOrEmpty(SM_Origin))
                    {
                        param[26] = new SqlParameter("@ParamSM_Origin", SqlDbType.NVarChar, (150));
                        param[26].Value = SM_Origin;
                    }
                    if (!string.IsNullOrEmpty(SM_Destination))
                    {
                        param[27] = new SqlParameter("@ParamSM_Destination", SqlDbType.NVarChar, (150));
                        param[27].Value = SM_Destination;
                    }
                    if (!string.IsNullOrEmpty(SM_ValidatingCarrier))
                    {
                        param[28] = new SqlParameter("@ParamSM_ValidatingCarrier", SqlDbType.NVarChar, (150));
                        param[28].Value = SM_ValidatingCarrier;
                    }
                    if (!string.IsNullOrEmpty(SM_CabinClass))
                    {
                        param[29] = new SqlParameter("@ParamSM_CabinClass", SqlDbType.VarChar, (50));
                        param[29].Value = SM_CabinClass;
                    }
                    if (!string.IsNullOrEmpty(CD_PaxID))
                    {
                        param[30] = new SqlParameter("@ParamCD_PaxID", SqlDbType.NVarChar, (50));
                        param[30].Value = CD_PaxID;
                    }
                    if (!string.IsNullOrEmpty(CD_ContactNo))
                    {
                        param[31] = new SqlParameter("@ParamCD_ContactNo", SqlDbType.NVarChar, (100));
                        param[31].Value = CD_ContactNo;
                    }
                    if (!string.IsNullOrEmpty(CD_FaxNo))
                    {
                        param[32] = new SqlParameter("@ParamCD_FaxNo", SqlDbType.NVarChar, (100));
                        param[32].Value = CD_FaxNo;
                    }
                    if (!string.IsNullOrEmpty(CD_EmailID))
                    {
                        param[33] = new SqlParameter("@ParamCD_EmailID", SqlDbType.NVarChar, (500));
                        param[33].Value = CD_EmailID;
                    }
                    if (!string.IsNullOrEmpty(CD_Country))
                    {
                        param[34] = new SqlParameter("@ParamCD_Country", SqlDbType.NVarChar, (200));
                        param[34].Value = CD_Country;
                    }
                    if (!string.IsNullOrEmpty(CD_City))
                    {
                        param[35] = new SqlParameter("@ParamCD_City", SqlDbType.NVarChar, (200));
                        param[35].Value = CD_City;
                    }
                    if (!string.IsNullOrEmpty(CD_Address))
                    {
                        param[36] = new SqlParameter("@ParamCD_Address", SqlDbType.NVarChar, (2000));
                        param[36].Value = CD_Address;
                    }
                    if (!string.IsNullOrEmpty(CD_PostCode))
                    {
                        param[37] = new SqlParameter("@ParamCD_PostCode", SqlDbType.NVarChar, (50));
                        param[37].Value = CD_PostCode;
                    }
                    if (!string.IsNullOrEmpty(CD_AddressType))
                    {
                        param[38] = new SqlParameter("@ParamCD_AddressType", SqlDbType.NVarChar, (50));
                        param[38].Value = CD_AddressType;
                    }
                    param[39] = new SqlParameter("@ParamAirSectors", dtAirSectors);
                    param[40] = new SqlParameter("@ParamAmountCharges", dtAmountCharges);
                    param[41] = new SqlParameter("@ParamPassengers", dtPassengers);
                    param[42] = new SqlParameter("@paramStatus", SqlDbType.Bit);
                    param[42].Direction = ParameterDirection.Output;


                    if (!string.IsNullOrEmpty(CD_PhoneNo))
                    {
                        param[43] = new SqlParameter("@ParamCD_PhoneNo", SqlDbType.NVarChar, (50));
                        param[43].Value = CD_PhoneNo;
                    }
                    if (!string.IsNullOrEmpty(Airline_change))
                    {
                        param[44] = new SqlParameter("@ParamAirline_Change", SqlDbType.NVarChar, (5));
                        param[44].Value = Airline_change;
                    }
                    if (!string.IsNullOrEmpty(FareType))
                    {
                        param[45] = new SqlParameter("@ParamFareType", SqlDbType.NVarChar, (5));
                        param[45].Value = FareType;
                    }
                    if (UsrID != 0)
                    {
                        param[46] = new SqlParameter("@ParamUsrID", SqlDbType.Int);
                        param[46].Value = UsrID;
                    }

                    if (!string.IsNullOrEmpty(BD_FirstName))
                    {
                        param[47] = new SqlParameter("@ParamBD_Firstname", SqlDbType.NVarChar, (100));
                        param[47].Value = BD_FirstName;
                    }
                    if (!string.IsNullOrEmpty(BD_LastName))
                    {
                        param[48] = new SqlParameter("@ParamBD_LastName", SqlDbType.NVarChar, (100));
                        param[48].Value = BD_LastName;
                    }
                    if (!string.IsNullOrEmpty(BD_TravelStartDate))
                    {
                        param[49] = new SqlParameter("@ParamBD_TravelStartDate", SqlDbType.DateTime);
                        param[49].Value = BD_TravelStartDate;
                    }

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    return Convert.ToBoolean(param[42].Value);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool InsertFlightBookingDetails1(string BM_BookingID, string BM_InvoiceNo, string BM_Origin,
            string BM_Destination, string BM_BookingStatus, string BM_BookingRemarks, double BM_BookingTotalAmount,
            string BM_BookingType, string BM_CurrencyType, string BM_BookingByCompany, string BM_IsInsertBM,
            string BD_ProdID, string BD_Provider, string BD_BookingBy, string BD_BookingByType,
            string BD_BookingDateTime, string BD_BookingStatus, string BD_BookingRemarks, double BD_TotalAmount,
            string BD_PNR, string BD_SourceMedia, string BD_ProductType, string BD_ModifiedBy, string BD_Supplier,
            string SM_JourneyType, string SM_LastTktDate, string SM_Origin, string SM_Destination,
            string SM_ValidatingCarrier, string SM_CabinClass, string CD_PaxID, string CD_ContactNo, string CD_PhoneNo, string CD_FaxNo,
            string CD_EmailID, string CD_Country, string CD_City, string CD_Address, string CD_PostCode,
            string CD_AddressType, DataTable dtAirSectors, DataTable dtAmountCharges, DataTable dtPassengers)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[44];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "InsertFlightBooking";
                    param[0] = new SqlParameter("@ParamBM_BookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = BM_BookingID;
                    if (!string.IsNullOrEmpty(BM_InvoiceNo))
                    {
                        param[1] = new SqlParameter("@ParamBM_InvoiceNo", SqlDbType.NVarChar, (50));
                        param[1].Value = BM_InvoiceNo;
                    }
                    if (!string.IsNullOrEmpty(BM_Origin))
                    {
                        param[2] = new SqlParameter("@ParamBM_Origin", SqlDbType.NVarChar, (150));
                        param[2].Value = BM_Origin;
                    }
                    if (!string.IsNullOrEmpty(BM_Destination))
                    {
                        param[3] = new SqlParameter("@ParamBM_Destination", SqlDbType.NVarChar, (150));
                        param[3].Value = BM_Destination;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingStatus))
                    {
                        param[4] = new SqlParameter("@ParamBM_BookingStatus", SqlDbType.NVarChar, (100));
                        param[4].Value = BM_BookingStatus;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingRemarks))
                    {
                        param[5] = new SqlParameter("@ParamBM_BookingRemarks", SqlDbType.NVarChar, (2000));
                        param[5].Value = BM_BookingRemarks;
                    }

                    param[6] = new SqlParameter("@ParamBM_BookingTotalAmount", SqlDbType.Money);
                    param[6].Value = BM_BookingTotalAmount;

                    if (!string.IsNullOrEmpty(BM_BookingType))
                    {
                        param[7] = new SqlParameter("@ParamBM_BookingType", SqlDbType.NVarChar, (50));
                        param[7].Value = BM_BookingType;
                    }
                    if (!string.IsNullOrEmpty(BM_CurrencyType))
                    {
                        param[8] = new SqlParameter("@ParamBM_CurrencyType", SqlDbType.NVarChar, (25));
                        param[8].Value = BM_CurrencyType;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingByCompany))
                    {
                        param[9] = new SqlParameter("@ParamBM_BookingByCompany", SqlDbType.NVarChar, (50));
                        param[9].Value = BM_BookingByCompany;
                    }

                    param[10] = new SqlParameter("@ParamBM_IsInsertBM", SqlDbType.NVarChar, (50));
                    param[10].Value = BM_IsInsertBM;

                    param[11] = new SqlParameter("@ParamBD_ProdID", SqlDbType.NVarChar, (50));
                    param[11].Value = BD_ProdID;

                    if (!string.IsNullOrEmpty(BD_Provider))
                    {
                        param[12] = new SqlParameter("@ParamBD_Provider", SqlDbType.NVarChar, (50));
                        param[12].Value = BD_Provider;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingBy))
                    {
                        param[13] = new SqlParameter("@ParamBD_BookingBy", SqlDbType.NVarChar, (100));
                        param[13].Value = BD_BookingBy;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingByType))
                    {
                        param[14] = new SqlParameter("@ParamBD_BookingByType", SqlDbType.NVarChar, (100));
                        param[14].Value = BD_BookingByType;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingDateTime))
                    {
                        param[15] = new SqlParameter("@ParamBD_BookingDateTime", SqlDbType.DateTime);
                        param[15].Value = Convert.ToDateTime(BD_BookingDateTime);
                    }
                    if (!string.IsNullOrEmpty(BD_BookingStatus))
                    {
                        param[16] = new SqlParameter("@ParamBD_BookingStatus", SqlDbType.NVarChar, (50));
                        param[16].Value = BD_BookingStatus;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingRemarks))
                    {
                        param[17] = new SqlParameter("@ParamBD_BookingRemarks", SqlDbType.NVarChar, (2000));
                        param[17].Value = BD_BookingRemarks;
                    }

                    param[18] = new SqlParameter("@ParamBD_TotalAmount", SqlDbType.Money);
                    param[18].Value = BD_TotalAmount;

                    if (!string.IsNullOrEmpty(BD_PNR))
                    {
                        param[19] = new SqlParameter("@ParamBD_PNR", SqlDbType.NVarChar, (50));
                        param[19].Value = BD_PNR;
                    }
                    if (!string.IsNullOrEmpty(BD_SourceMedia))
                    {
                        param[20] = new SqlParameter("@ParamBD_SourceMedia", SqlDbType.NVarChar, (50));
                        param[20].Value = BD_SourceMedia;
                    }
                    if (!string.IsNullOrEmpty(BD_ProductType))
                    {
                        param[21] = new SqlParameter("@ParamBD_ProductType", SqlDbType.VarChar, (50));
                        param[21].Value = BD_ProductType;
                    }
                    if (!string.IsNullOrEmpty(BD_ModifiedBy))
                    {
                        param[22] = new SqlParameter("@ParamBD_ModifiedBy", SqlDbType.VarChar, (100));
                        param[22].Value = BD_ModifiedBy;
                    }
                    if (!string.IsNullOrEmpty(BD_Supplier))
                    {
                        param[23] = new SqlParameter("@ParamBD_Supplier", SqlDbType.VarChar, (100));
                        param[23].Value = BD_Supplier;
                    }
                    if (!string.IsNullOrEmpty(SM_JourneyType))
                    {
                        param[24] = new SqlParameter("@ParamSM_JourneyType", SqlDbType.NVarChar, (100));
                        param[24].Value = SM_JourneyType;
                    }
                    if (!string.IsNullOrEmpty(SM_LastTktDate))
                    {
                        param[25] = new SqlParameter("@ParamSM_LastTktDate", SqlDbType.NVarChar, (200));
                        param[25].Value = SM_LastTktDate;
                    }
                    if (!string.IsNullOrEmpty(SM_Origin))
                    {
                        param[26] = new SqlParameter("@ParamSM_Origin", SqlDbType.NVarChar, (150));
                        param[26].Value = SM_Origin;
                    }
                    if (!string.IsNullOrEmpty(SM_Destination))
                    {
                        param[27] = new SqlParameter("@ParamSM_Destination", SqlDbType.NVarChar, (150));
                        param[27].Value = SM_Destination;
                    }
                    if (!string.IsNullOrEmpty(SM_ValidatingCarrier))
                    {
                        param[28] = new SqlParameter("@ParamSM_ValidatingCarrier", SqlDbType.NVarChar, (150));
                        param[28].Value = SM_ValidatingCarrier;
                    }
                    if (!string.IsNullOrEmpty(SM_CabinClass))
                    {
                        param[29] = new SqlParameter("@ParamSM_CabinClass", SqlDbType.VarChar, (50));
                        param[29].Value = SM_CabinClass;
                    }
                    if (!string.IsNullOrEmpty(CD_PaxID))
                    {
                        param[30] = new SqlParameter("@ParamCD_PaxID", SqlDbType.NVarChar, (50));
                        param[30].Value = CD_PaxID;
                    }
                    if (!string.IsNullOrEmpty(CD_ContactNo))
                    {
                        param[31] = new SqlParameter("@ParamCD_ContactNo", SqlDbType.NVarChar, (100));
                        param[31].Value = CD_ContactNo;
                    }
                    if (!string.IsNullOrEmpty(CD_FaxNo))
                    {
                        param[32] = new SqlParameter("@ParamCD_FaxNo", SqlDbType.NVarChar, (100));
                        param[32].Value = CD_FaxNo;
                    }
                    if (!string.IsNullOrEmpty(CD_EmailID))
                    {
                        param[33] = new SqlParameter("@ParamCD_EmailID", SqlDbType.NVarChar, (500));
                        param[33].Value = CD_EmailID;
                    }
                    if (!string.IsNullOrEmpty(CD_Country))
                    {
                        param[34] = new SqlParameter("@ParamCD_Country", SqlDbType.NVarChar, (200));
                        param[34].Value = CD_Country;
                    }
                    if (!string.IsNullOrEmpty(CD_City))
                    {
                        param[35] = new SqlParameter("@ParamCD_City", SqlDbType.NVarChar, (200));
                        param[35].Value = CD_City;
                    }
                    if (!string.IsNullOrEmpty(CD_Address))
                    {
                        param[36] = new SqlParameter("@ParamCD_Address", SqlDbType.NVarChar, (2000));
                        param[36].Value = CD_Address;
                    }
                    if (!string.IsNullOrEmpty(CD_PostCode))
                    {
                        param[37] = new SqlParameter("@ParamCD_PostCode", SqlDbType.NVarChar, (50));
                        param[37].Value = CD_PostCode;
                    }
                    if (!string.IsNullOrEmpty(CD_AddressType))
                    {
                        param[38] = new SqlParameter("@ParamCD_AddressType", SqlDbType.NVarChar, (50));
                        param[38].Value = CD_AddressType;
                    }
                    param[39] = new SqlParameter("@ParamAirSectors", dtAirSectors);
                    param[40] = new SqlParameter("@ParamAmountCharges", dtAmountCharges);
                    param[41] = new SqlParameter("@ParamPassengers", dtPassengers);
                    param[42] = new SqlParameter("@paramStatus", SqlDbType.Bit);
                    param[42].Direction = ParameterDirection.Output;


                    if (!string.IsNullOrEmpty(CD_PhoneNo))
                    {
                        param[43] = new SqlParameter("@ParamCD_PhoneNo", SqlDbType.NVarChar, (50));
                        param[43].Value = CD_PhoneNo;
                    }

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    return Convert.ToBoolean(param[42].Value);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool BookingDetails_Update(string BookingID, string ProdBookingID, string ProdProvider,
            string ProdBookingBy, string ProdBookingByType, string ProdBookingDateTime, string ProdBookingStatus,
            string ProdBookingRemarks, double ProdTotalAmount, string PNRConfirmation)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[10];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "BookingDetails_Update";

                    param[0] = new SqlParameter("@ParamBookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = BookingID;


                    param[1] = new SqlParameter("@ParamProdBookingID", SqlDbType.NVarChar, (50));
                    param[1].Value = ProdBookingID;

                    if (!string.IsNullOrEmpty(ProdProvider))
                    {
                        param[2] = new SqlParameter("@ParamProdProvider", SqlDbType.NVarChar, (50));
                        param[2].Value = ProdProvider;
                    }

                    if (!string.IsNullOrEmpty(ProdBookingBy))
                    {
                        param[3] = new SqlParameter("@ParamProdBookingBy", SqlDbType.NVarChar, (100));
                        param[3].Value = ProdBookingBy;
                    }
                    if (!string.IsNullOrEmpty(ProdBookingByType))
                    {
                        param[4] = new SqlParameter("@ParamProdBookingByType", SqlDbType.NVarChar, (100));
                        param[4].Value = ProdBookingByType;
                    }
                    if (!string.IsNullOrEmpty(ProdBookingDateTime))
                    {
                        param[5] = new SqlParameter("@ParamProdBookingDateTime", SqlDbType.DateTime);
                        param[5].Value = Convert.ToDateTime(ProdBookingDateTime);
                    }
                    if (!string.IsNullOrEmpty(ProdBookingStatus))
                    {
                        param[6] = new SqlParameter("@ParamProdBookingStatus", SqlDbType.NVarChar, (50));
                        param[6].Value = ProdBookingStatus;
                    }
                    if (!string.IsNullOrEmpty(ProdBookingRemarks))
                    {
                        param[7] = new SqlParameter("@ParamProdBookingRemarks", SqlDbType.NVarChar, (2000));
                        param[7].Value = ProdBookingRemarks;
                    }
                    if (ProdTotalAmount > 0)
                    {
                        param[8] = new SqlParameter("@ParamProdTotalAmount", SqlDbType.Money);
                        param[8].Value = ProdTotalAmount;
                    }
                    if (!string.IsNullOrEmpty(PNRConfirmation))
                    {
                        param[9] = new SqlParameter("@ParamPNRConfirmation", SqlDbType.NVarChar, (50));
                        param[9].Value = PNRConfirmation;
                    }

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool insertOnlinePaymentDetails(string BookingID, string ProdID, string TrnsNO, string TrnsType,
           string TrnsPaymentStatus, double TrnsAmount, string TrnsCurrencyType, string TrnsBy, string TrnsRemarks,
           string TrnsSecurityKey, string TrnsStatus, string TrnsStatusDetail, string TrnsVSPTxID, string TrnsAuthNo,
           string TrnsAVSCV2, string TrnsAddressResult, string TrnsPostCodeResult, string TrnsCV2Result,
           string Trns3DSecureStatus, string TrnsCAVV, string CRDCardNo, string CRDHolderName, string CRDExpDate,
           string CRDValidFrom, string CRDIssueNo, string CRDSecurityCode, string CRDCardType, string CRDCountry,
           string CRDCoutyState, string CRDCity, string CRDPostCode, string CRDAddress, double CRDCardCharges,
           string CRDChargesType, string IsCardChargeInsert, string IsChangeBookingDetails, string BookingStatus,
           string BookingRemarks)
        {

           



            try
            {

                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[39];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "insertOnlinePaymentDetails";

                    param[0] = new SqlParameter("@paramBookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = BookingID;

                    if (!string.IsNullOrEmpty(ProdID))
                    {
                        param[1] = new SqlParameter("@paramProdID", SqlDbType.NVarChar, (50));
                        param[1].Value = ProdID;
                    }

                    param[2] = new SqlParameter("@paramTrnsNO", SqlDbType.NVarChar, (50));
                    param[2].Value = TrnsNO;

                    if (!string.IsNullOrEmpty(TrnsType))
                    {
                        param[3] = new SqlParameter("@paramTrnsType", SqlDbType.NVarChar, (200));
                        param[3].Value = TrnsType;
                    }
                    if (!string.IsNullOrEmpty(TrnsPaymentStatus))
                    {
                        param[4] = new SqlParameter("@paramTrnsPaymentStatus", SqlDbType.NVarChar, (100));
                        param[4].Value = TrnsPaymentStatus;
                    }
                    if (TrnsAmount > 0)
                    {
                        param[5] = new SqlParameter("@paramTrnsAmount", SqlDbType.Money);
                        param[5].Value = TrnsAmount;
                    }
                    if (!string.IsNullOrEmpty(TrnsCurrencyType))
                    {
                        param[6] = new SqlParameter("@paramTrnsCurrencyType", SqlDbType.NVarChar, (50));
                        param[6].Value = TrnsCurrencyType;
                    }
                    if (!string.IsNullOrEmpty(TrnsBy))
                    {
                        param[7] = new SqlParameter("@paramTrnsBy", SqlDbType.NVarChar, (100));
                        param[7].Value = TrnsBy;
                    }

                    if (!string.IsNullOrEmpty(TrnsRemarks))
                    {
                        param[8] = new SqlParameter("@paramTrnsRemarks", SqlDbType.NVarChar, (2000));
                        param[8].Value = TrnsRemarks;
                    }
                    if (!string.IsNullOrEmpty(TrnsSecurityKey))
                    {
                        param[9] = new SqlParameter("@paramTrnsSecurityKey", SqlDbType.NVarChar, (50));
                        param[9].Value = TrnsSecurityKey;
                    }
                    if (!string.IsNullOrEmpty(TrnsStatus))
                    {
                        param[10] = new SqlParameter("@paramTrnsStatus", SqlDbType.NVarChar, (50));
                        param[10].Value = TrnsStatus;
                    }
                    if (!string.IsNullOrEmpty(TrnsStatusDetail))
                    {
                        param[11] = new SqlParameter("@paramTrnsStatusDetail", SqlDbType.NVarChar, (500));
                        param[11].Value = TrnsStatusDetail;
                    }
                    if (!string.IsNullOrEmpty(TrnsVSPTxID))
                    {
                        param[12] = new SqlParameter("@paramTrnsVSPTxID", SqlDbType.NVarChar, (50));
                        param[12].Value = TrnsVSPTxID;
                    }
                    if (!string.IsNullOrEmpty(TrnsAuthNo))
                    {
                        param[13] = new SqlParameter("@paramTrnsAuthNo", SqlDbType.NVarChar, (50));
                        param[13].Value = TrnsAuthNo;
                    }
                    if (!string.IsNullOrEmpty(TrnsAVSCV2))
                    {
                        param[14] = new SqlParameter("@paramTrnsAVSCV2", SqlDbType.NVarChar, (50));
                        param[14].Value = TrnsAVSCV2;
                    }
                    if (!string.IsNullOrEmpty(TrnsAddressResult))
                    {
                        param[15] = new SqlParameter("@paramTrnsAddressResult", SqlDbType.NVarChar, (200));
                        param[15].Value = TrnsAddressResult;
                    }
                    if (!string.IsNullOrEmpty(TrnsPostCodeResult))
                    {
                        param[16] = new SqlParameter("@paramTrnsPostCodeResult", SqlDbType.NVarChar, (100));
                        param[16].Value = TrnsPostCodeResult;
                    }
                    if (!string.IsNullOrEmpty(TrnsCV2Result))
                    {
                        param[17] = new SqlParameter("@paramTrnsCV2Result", SqlDbType.NVarChar, (50));
                        param[17].Value = TrnsCV2Result;
                    }
                    if (!string.IsNullOrEmpty(Trns3DSecureStatus))
                    {
                        param[18] = new SqlParameter("@paramTrns3DSecureStatus", SqlDbType.NVarChar, (50));
                        param[18].Value = Trns3DSecureStatus;
                    }
                    if (!string.IsNullOrEmpty(TrnsCAVV))
                    {
                        param[19] = new SqlParameter("@paramTrnsCAVV", SqlDbType.NVarChar, (50));
                        param[19].Value = TrnsCAVV;
                    }
                    if (!string.IsNullOrEmpty(CRDCardNo))
                    {
                        param[20] = new SqlParameter("@paramCRDCardNo", SqlDbType.NVarChar, (100));
                        param[20].Value = CRDCardNo;
                    }
                    if (!string.IsNullOrEmpty(CRDHolderName))
                    {
                        param[21] = new SqlParameter("@paramCRDHolderName", SqlDbType.NVarChar, (200));
                        param[21].Value = CRDHolderName;
                    }
                    if (!string.IsNullOrEmpty(CRDExpDate))
                    {
                        param[22] = new SqlParameter("@paramCRDExpDate", SqlDbType.NVarChar, (50));
                        param[22].Value = CRDExpDate;
                    }
                    if (!string.IsNullOrEmpty(CRDValidFrom))
                    {
                        param[23] = new SqlParameter("@paramCRDValidFrom", SqlDbType.NVarChar, (50));
                        param[23].Value = CRDValidFrom;
                    }
                    if (!string.IsNullOrEmpty(CRDIssueNo))
                    {
                        param[24] = new SqlParameter("@paramCRDIssueNo", SqlDbType.NVarChar, (100));
                        param[24].Value = CRDIssueNo;
                    }
                    if (!string.IsNullOrEmpty(CRDSecurityCode))
                    {
                        param[25] = new SqlParameter("@paramCRDSecurityCode", SqlDbType.NVarChar, (100));
                        param[25].Value = CRDSecurityCode;
                    }
                    if (!string.IsNullOrEmpty(CRDCardType))
                    {
                        param[26] = new SqlParameter("@paramCRDCardType", SqlDbType.NVarChar, (200));
                        param[26].Value = CRDCardType;
                    }
                    if (!string.IsNullOrEmpty(CRDCountry))
                    {
                        param[27] = new SqlParameter("@paramCRDCountry", SqlDbType.NVarChar, (200));
                        param[27].Value = CRDCountry;
                    }
                    if (!string.IsNullOrEmpty(CRDCoutyState))
                    {
                        param[28] = new SqlParameter("@paramCRDCoutyState", SqlDbType.NVarChar, (200));
                        param[28].Value = CRDCoutyState;
                    }
                    if (!string.IsNullOrEmpty(CRDCity))
                    {
                        param[29] = new SqlParameter("@paramCRDCity", SqlDbType.NVarChar, (200));
                        param[29].Value = CRDCity;
                    }
                    if (!string.IsNullOrEmpty(CRDPostCode))
                    {
                        param[30] = new SqlParameter("@paramCRDPostCode", SqlDbType.NVarChar, (50));
                        param[30].Value = CRDPostCode;
                    }
                    if (!string.IsNullOrEmpty(CRDAddress))
                    {
                        param[31] = new SqlParameter("@paramCRDAddress", SqlDbType.NVarChar, (1000));
                        param[31].Value = CRDAddress;
                    }
                    if (CRDCardCharges > 0)
                    {
                        param[32] = new SqlParameter("@paramCRDCardCharges", SqlDbType.Money);
                        param[32].Value = CRDCardCharges;
                    }
                    if (!string.IsNullOrEmpty(CRDChargesType))
                    {
                        param[33] = new SqlParameter("@paramCRDChargesType", SqlDbType.Char, (4));
                        param[33].Value = CRDChargesType;
                    }

                    param[34] = new SqlParameter("@paramIsCardChargeInsert", SqlDbType.NVarChar, (50));
                    param[34].Value = IsCardChargeInsert;

                    param[35] = new SqlParameter("@paramIsChangeBookingDetails", SqlDbType.NVarChar, (50));
                    param[35].Value = IsChangeBookingDetails;

                    if (!string.IsNullOrEmpty(BookingStatus))
                    {
                        param[36] = new SqlParameter("@paramBookingStatus", SqlDbType.NVarChar, (50));
                        param[36].Value = BookingStatus;
                    }
                    if (!string.IsNullOrEmpty(BookingRemarks))
                    {
                        param[37] = new SqlParameter("@paramBookingRemarks", SqlDbType.NVarChar, (2000));
                        param[37].Value = BookingRemarks;
                    }
                    param[38] = new SqlParameter("@paramMassege", SqlDbType.VarChar, (100));
                    param[38].Direction = ParameterDirection.Output;

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    return Convert.ToBoolean(param[38].Value);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SavePageTrack(string userHostAddress, string RequestSource, string WebPage, string OriginalURL, string WebSite, string Origin, string Destination,
             string date, string ReturnDate, string IPCity, string IPCountry, string Browser, string SessionID, string Remarks, string RedirectFrom, string Device, string CabinClass, string BookingId)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[18];
                using (SqlConnection connection = DataConnection.GetPageTrackerConnection())
                {
                    _CommandText = "ST_PageTracker_Insert";
                    param[0] = new SqlParameter("@paramIP", SqlDbType.NVarChar, (50));
                    param[0].Value = userHostAddress;

                    param[1] = new SqlParameter("@paramReqSource", SqlDbType.NVarChar, (100));
                    param[1].Value = RequestSource;

                    param[2] = new SqlParameter("@paramPage", SqlDbType.NVarChar, (50));
                    if (WebPage.Contains(".aspx"))
                        param[2].Value = WebPage;
                    else
                        param[2].Value = WebPage + ".aspx";

                    param[3] = new SqlParameter("@paramPageUrl", SqlDbType.NVarChar, (500));
                    param[3].Value = OriginalURL;

                    param[4] = new SqlParameter("@paramSite", SqlDbType.NVarChar, (100));
                    param[4].Value = WebSite;

                    param[5] = new SqlParameter("@paramOrigin", SqlDbType.NVarChar, (50));
                    param[5].Value = Origin;

                    param[6] = new SqlParameter("@paramDestination", SqlDbType.NVarChar, (50));
                    param[6].Value = Destination;

                    if (WebPage == "Firm")
                    {
                        param[2].Value = "BookingDetails.aspx";
                    }

                    try
                    {
                        param[7] = new SqlParameter("@paramdate", SqlDbType.DateTime);
                        param[7].Value = Convert.ToDateTime(date);
                    }
                    catch { param[7].Value = Convert.ToDateTime("01/01/1900"); }

                    if (!string.IsNullOrEmpty(ReturnDate))
                    {
                        try
                        {
                            param[8] = new SqlParameter("@paramReturnDate", SqlDbType.DateTime);
                            param[8].Value = Convert.ToDateTime(ReturnDate);
                        }
                        catch { param[8].Value = Convert.ToDateTime("01/01/1900"); }
                    }
                    param[9] = new SqlParameter("@paramIPCity", SqlDbType.NVarChar, (50));
                    param[9].Value = IPCity;
                    param[10] = new SqlParameter("@paramIPCountry", SqlDbType.NVarChar, (50));
                    param[10].Value = IPCountry;
                    param[11] = new SqlParameter("@paramBrowser", SqlDbType.NVarChar, (200));
                    param[11].Value = Browser;
                    param[12] = new SqlParameter("@paramSession", SqlDbType.NVarChar, (200));
                    param[12].Value = SessionID;
                    param[13] = new SqlParameter("@paramRemarks", SqlDbType.NVarChar, (200));
                    param[13].Value = Remarks;
                    param[14] = new SqlParameter("@paramRedirectFrom", SqlDbType.NVarChar, (100));
                    param[14].Value = RedirectFrom;
                    param[15] = new SqlParameter("@paramDeviceName", SqlDbType.NVarChar, (100));
                    param[15].Value = Device;
                    param[16] = new SqlParameter("@paramCabinClass", SqlDbType.NVarChar, (2));
                    param[16].Value = CabinClass;
                    if (!string.IsNullOrEmpty(BookingId))
                    {
                        param[17] = new SqlParameter("@Booking_Id", SqlDbType.NVarChar, (50));
                        param[17].Value = BookingId;
                    }
                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);

                    if (count > 0)
                        return true;
                    else
                        return false;
                }

            }
            catch { return false; }

        }

        #region For Bloked IP
        public string GetBlockedIPs(string Company)
        {
            string sResponse = string.Empty;
            string _CommandText = string.Empty;
            SqlParameter[] param = new SqlParameter[2];
            try
            {
                using (SqlConnection con = DataConnection.GetConnectionMoresand())
                {
                    _CommandText = "sp_Admin_BlockIp";
                    con.Open();
                    SqlCommand sqCom = new SqlCommand(_CommandText, con);
                    sqCom.CommandType = CommandType.StoredProcedure;
                    sqCom.Parameters.AddWithValue("@paramCompanyID", Company);
                    sqCom.Parameters.AddWithValue("@Counter", 5);
                    using (XmlReader reader = sqCom.ExecuteXmlReader())
                    {
                        while (reader.Read())
                        {
                            sResponse = reader.ReadOuterXml();
                        }
                    }
                    con.Close();
                }
            }
            catch { }
            return sResponse;
        }
        #endregion

        public DataTable GetCouponDetail(string sCounponCode, string sFrom, string sTo, string sAirlineCode, string sClass, string sProvider, string sJourneyType, string sProductType, string sApplicableFor, string sSourceMedia, string sMinAmount, string sType)
        {
            DataTable dtCoupon = new DataTable();
            try
            {
                using (SqlConnection SqlConn = DataConnection.GetConnectionMoresand())
                {
                    SqlConn.Open();
                    using (SqlCommand SqlCmd = new SqlCommand("sp_VoucherMaster", SqlConn))
                    {
                        using (SqlDataAdapter SqlDA = new SqlDataAdapter())
                        {
                            SqlCmd.CommandType = CommandType.StoredProcedure;
                            if (!string.IsNullOrEmpty(sCounponCode))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramCouponCode", sCounponCode);
                            }
                            if (!string.IsNullOrEmpty(sFrom))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramFrom", sFrom);
                            }
                            if (!string.IsNullOrEmpty(sTo))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramTo", sTo);
                            }
                            if (!string.IsNullOrEmpty(sAirlineCode))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramAirV", sAirlineCode);
                            }
                            if (!string.IsNullOrEmpty(sClass))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramClass", sClass);
                            }
                            if (!string.IsNullOrEmpty(sProvider))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramProvider", sProvider);
                            }
                            if (!string.IsNullOrEmpty(sJourneyType))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramJourneyType", sJourneyType);
                            }
                            if (!string.IsNullOrEmpty(sProductType))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramProductType", sProductType);
                            }
                            if (!string.IsNullOrEmpty(sApplicableFor))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramApplicableFor", sApplicableFor);
                            }
                            if (!string.IsNullOrEmpty(sSourceMedia))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramSource", sSourceMedia);
                            }
                            if (!string.IsNullOrEmpty(sMinAmount))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramAppliMinAmount", sMinAmount);
                            }
                            if (!string.IsNullOrEmpty(sType))
                            {
                                SqlCmd.Parameters.AddWithValue("@paramType", sType);
                            }
                            SqlCmd.Parameters.AddWithValue("@Counter", 4);
                            SqlDA.SelectCommand = SqlCmd;
                            SqlDA.Fill(dtCoupon);
                            SqlConn.Close();
                        }
                    }
                }
            }
            catch { }
            return dtCoupon;
        }

        public bool InsertCouponDetails(string BookingID, string Product, string Discount, string CouponCode, string Status, string UserID)
        {
            string _CommandText = string.Empty;
            SqlParameter[] param = new SqlParameter[8];

            try
            {
                using (SqlConnection Con = DataConnection.GetConnectionMoresand())
                {
                    _CommandText = "GetVoucherlDetails";

                    param[0] = new SqlParameter("@paramBookingID", SqlDbType.VarChar, (50));
                    param[0].Value = BookingID;

                    param[1] = new SqlParameter("@paramProduct", SqlDbType.VarChar, (20));
                    param[1].Value = Product;

                    param[2] = new SqlParameter("@paramCouponCode", SqlDbType.VarChar, (50));
                    param[2].Value = CouponCode;

                    param[3] = new SqlParameter("@paramDiscount", SqlDbType.Money);
                    param[3].Value = Convert.ToDouble(Discount).ToString("f2");

                    param[4] = new SqlParameter("@paramStatus", SqlDbType.VarChar, (20));
                    param[4].Value = Status;

                    param[5] = new SqlParameter("@paramCreateBy", SqlDbType.VarChar, (100));
                    param[5].Value = UserID;

                    param[6] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[6].Value = 2;

                    param[7] = new SqlParameter("@paramReturn", SqlDbType.VarChar, 100);
                    param[7].Direction = ParameterDirection.Output;

                    SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, _CommandText, param);
                    if (param[7].Value.ToString().ToUpper() == "TRUE")
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCouponStatus(string BookingID, string Product, string CouponCode, string Status)
        {
            string _CommandText = string.Empty;
            SqlParameter[] param = new SqlParameter[6];

            try
            {
                using (SqlConnection Con = DataConnection.GetConnectionMoresand())
                {
                    _CommandText = "GetVoucherlDetails";

                    param[0] = new SqlParameter("@paramBookingID", SqlDbType.VarChar, (50));
                    param[0].Value = BookingID;

                    param[1] = new SqlParameter("@paramProduct", SqlDbType.VarChar, (20));
                    param[1].Value = Product;

                    param[2] = new SqlParameter("@paramCouponCode", SqlDbType.VarChar, (50));
                    param[2].Value = CouponCode;

                    param[3] = new SqlParameter("@paramStatus", SqlDbType.VarChar, (20));
                    param[3].Value = Status;

                    param[4] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[4].Value = 3;

                    param[5] = new SqlParameter("@paramReturn", SqlDbType.VarChar, 100);
                    param[5].Direction = ParameterDirection.Output;

                    SqlHelper.ExecuteNonQuery(Con, CommandType.StoredProcedure, _CommandText, param);
                    if (param[5].Value.ToString().ToUpper() == "TRUE")
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool InsertAmountDetails(string BookingID, string ProdBookingID, string ChargeID, string ChargesFor, string CostPrice, string SellPrice, string ChargesStatus, string SupplierID, string ChargesRemark)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[10];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "AmountChargesDetail_Insert";

                    param[0] = new SqlParameter("@ParamBookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = BookingID;

                    param[1] = new SqlParameter("@ParamProdBookingID", SqlDbType.NVarChar, (50));
                    param[1].Value = ProdBookingID;

                    param[2] = new SqlParameter("@paramChargeID", SqlDbType.NVarChar, (50));
                    param[2].Value = ChargeID;

                    param[3] = new SqlParameter("@paramChargesfor", SqlDbType.NVarChar, (50));
                    param[3].Value = ChargesFor;

                    param[4] = new SqlParameter("@paramCostPrice", SqlDbType.Money);
                    param[4].Value = -Convert.ToDouble(CostPrice);

                    param[5] = new SqlParameter("@paramSellPrice", SqlDbType.Money);
                    param[5].Value = -Convert.ToDouble(SellPrice);

                    param[6] = new SqlParameter("@paramChargesStatus", SqlDbType.NVarChar, (50));
                    param[6].Value = ChargesStatus;

                    param[7] = new SqlParameter("@paramSupplierID", SqlDbType.NVarChar, (500));
                    param[7].Value = SupplierID;

                    param[8] = new SqlParameter("@paramChargesRemarks", SqlDbType.NVarChar, (50));
                    param[8].Value = ChargesRemark;

                    param[9] = new SqlParameter("@paramChargesDate", SqlDbType.DateTime);
                    param[9].Value = System.DateTime.Now;

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public bool InsertOtpDetails(string BookingID, string BookinDateTime, string OTP_Number, string companyId, string MobileNumber)
        {
            bool bMod = false;
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[5];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "InsertOneTimePassword";
                    param[0] = new SqlParameter("@bookingId", SqlDbType.NVarChar, (50));
                    param[0].Value = BookingID;
                    param[1] = new SqlParameter("@bookingDateTime", SqlDbType.DateTime);
                    param[1].Value = BookinDateTime;

                    if (!string.IsNullOrEmpty(OTP_Number))
                    {
                        param[2] = new SqlParameter("@Otp_Number", SqlDbType.NVarChar, (10));
                        param[2].Value = OTP_Number;
                    }
                    if (!string.IsNullOrEmpty(companyId))
                    {
                        param[3] = new SqlParameter("@companyId", SqlDbType.NVarChar, (50));
                        param[3].Value = companyId;
                    }
                    if (!string.IsNullOrEmpty(MobileNumber))
                    {
                        param[4] = new SqlParameter("@Phone_No", SqlDbType.NVarChar, (50));
                        param[4].Value = MobileNumber;
                    }
                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    if (count == 1)
                    {
                        bMod = true;
                    }
                    return bMod;

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool CheckValidOtp(string bookingid, string otpno)
        {
            DataTable dt = new DataTable();
            bool bReturn = false;
            string _CommandText = string.Empty;
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "ChekValidOneTimePwd";
                    param[0] = new SqlParameter("@bookingID", SqlDbType.NVarChar, 50);
                    param[0].Value = bookingid;
                    param[1] = new SqlParameter("@companyId", SqlDbType.NVarChar, 50);
                    param[1].Value = "";
                    param[2] = new SqlParameter("@mobno", SqlDbType.NVarChar, 50);
                    param[2].Value = "";
                    param[3] = new SqlParameter("@otpno", SqlDbType.NVarChar, 10);
                    param[3].Value = otpno;
                    SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, _CommandText, param);
                    dt.Load(dr);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    string bCheck = dt.Rows[0]["IsValid"].ToString();
                    if (bCheck == "1")
                    {
                        bReturn = true;
                    }
                }
            }
            catch
            {
                bReturn = false;
            }

            return bReturn;
        }

        public bool BookingMaster_Update(string BookingID, string ProdBookingStatus, string ProdBookingRemarks, double ProdTotalAmount)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[4];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "BookingMaster_Update";

                    param[0] = new SqlParameter("@paramBookingID", SqlDbType.NVarChar, (50));
                    param[0].Value = BookingID;

                    if (!string.IsNullOrEmpty(ProdBookingStatus))
                    {
                        param[1] = new SqlParameter("@paramBookingStatus", SqlDbType.NVarChar, (50));
                        param[1].Value = ProdBookingStatus;
                    }
                    if (!string.IsNullOrEmpty(ProdBookingRemarks))
                    {
                        param[2] = new SqlParameter("@paramBookingRemarks", SqlDbType.NVarChar, (2000));
                        param[2].Value = ProdBookingRemarks;
                    }
                    if (ProdTotalAmount > 0)
                    {
                        param[3] = new SqlParameter("@paramBookingTotalAmount", SqlDbType.Money);
                        param[3].Value = ProdTotalAmount;
                    }

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }


        #region ActiveCampaign


        public void postdata(string Emailid, string Fname, string Lastname, string phone, string RegisreationUser, string SubsciberUser, string Title, string UsrID)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");   //  For Add Contact 
                request.Method = "POST";

                string postData = "email=" + Emailid + "&first_name=" + Fname + "&last_name=" + Lastname + "&phone=" + phone + "&field[1,0]=" + Title + "&field[5,0]=" + RegisreationUser + "&field[6,0]=" + SubsciberUser + "&p[3]=3&status[3]=1&instantresponders[3]=1";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                string RValues = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();



                XmlDocument doc1 = new XmlDocument();
                doc1.LoadXml(RValues);
                string ID = string.Empty;
                if (doc1.SelectSingleNode("subscriber_insert_post") != null)
                {
                    if (doc1.SelectSingleNode("subscriber_insert_post/subscriber_id") != null)
                    {
                        ID = doc1.SelectSingleNode("subscriber_insert_post/subscriber_id").InnerText;
                    }
                    else
                    {
                        ID = doc1.SelectSingleNode("subscriber_insert_post/row/id").InnerText;
                    }
                    UpDateCampaignID(ID, UsrID);
                }

            }
            catch
            {

            }
            //Console.ReadLine();
        }

        public void Updatedata(string ID, string Title, string FirstName, string LastName, string Email, string MobileNo, string DOB, string Gender, string Marital, string HolidayDest, string HolidayBudget, string Deal, string Newsletter, string Frequency, string Origin, string Destination, string BookingStatus, string BookingDate, string BookingType, string ProductType, string Address, string City, string State, string Country, string PostCode, string CompanyID)
        {
            string RegisreationUser = "";
            string SubsciberUser = "NewSubscriber";
            StringBuilder Str = new StringBuilder();
            if (!string.IsNullOrEmpty(DOB))
            {
                DOB = Convert.ToDateTime(DOB).ToString("yyyy-MM-dd");
            }
            else
            {
                DOB = "";
            }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");   //  For Add Contact 
                request.Method = "POST";

                Str.Append("id=" + ID + "&email=" + Email + "&first_name=" + FirstName + "&last_name=" + LastName + "&phone=" + MobileNo + "");
                if (!string.IsNullOrEmpty(Title))
                {
                    Str.Append("&field[1,0]=" + Title + "");
                }
                if (!string.IsNullOrEmpty(MobileNo))
                {
                    Str.Append("&field[4,0]=" + MobileNo + "");
                }
                if (!string.IsNullOrEmpty(RegisreationUser))
                {
                    Str.Append("&field[5,0]=" + RegisreationUser + "");
                }
                if (!string.IsNullOrEmpty(SubsciberUser))
                {
                    Str.Append("&field[6,0]=" + SubsciberUser + "");
                }
                if (!string.IsNullOrEmpty(Deal))
                {
                    Str.Append("&field[19,0]=" + Deal + "");
                }
                if (!string.IsNullOrEmpty(Newsletter))
                {
                    Str.Append("&field[20,0]=" + Newsletter + "");
                }
                if (!string.IsNullOrEmpty(Marital))
                {
                    Str.Append("&field[26,0]=" + Marital + "");
                }
                if (!string.IsNullOrEmpty(HolidayDest))
                {
                    Str.Append("&field[31,0]=" + HolidayDest + "");
                }
                if (!string.IsNullOrEmpty(HolidayBudget))
                {
                    Str.Append("&field[32,0]=" + HolidayBudget + "");
                }
                if (!string.IsNullOrEmpty(DOB))
                {
                    Str.Append("&field[3,0]=" + DOB + "");
                }
                if (!string.IsNullOrEmpty(Gender))
                {
                    Str.Append("&field[2,0]=" + Gender + "");
                }
                if (!string.IsNullOrEmpty(Frequency))
                {
                    Str.Append("&field[21,0]=" + Frequency + "");
                }
                if (!string.IsNullOrEmpty(Origin))
                {
                    Str.Append("&field[16,0]=" + Origin + "");
                }
                if (!string.IsNullOrEmpty(Destination))
                {
                    Str.Append("&field[10,0]=" + Destination + "");
                }
                if (!string.IsNullOrEmpty(BookingStatus))
                {
                    Str.Append("&field[27,0]=" + BookingStatus + "");
                }
                if (!string.IsNullOrEmpty(BookingDate))
                {
                    Str.Append("&field[17,0]=" + Convert.ToDateTime(BookingDate).ToString("yyyy-MM-dd") + "");
                }
                if (!string.IsNullOrEmpty(BookingType))
                {
                    Str.Append("&field[36,0]=" + BookingType + "");
                }
                if (!string.IsNullOrEmpty(ProductType))
                {
                    Str.Append("&field[14,0]=" + ProductType + "");
                }

                if (!string.IsNullOrEmpty(Address))
                {
                    Str.Append("&field[35,0]=" + Address + "");
                }
                if (!string.IsNullOrEmpty(City))
                {
                    Str.Append("&field[25,0]=" + City + "");
                }
                if (!string.IsNullOrEmpty(State))
                {
                    Str.Append("&field[33,0]=" + State + "");
                }
                if (!string.IsNullOrEmpty(Country))
                {
                    Str.Append("&field[11,0]=" + Country + "");
                }
                if (!string.IsNullOrEmpty(PostCode))
                {
                    Str.Append("&field[34,0]=" + PostCode + "");
                }
                if (!string.IsNullOrEmpty(CompanyID))
                {
                    Str.Append("&field[22,0]=" + CompanyID + "");
                }

                Str.Append("&p[3]=11&status[3]=1&instantresponders[3]=1");
                string postData = Str.ToString();
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                string RValues = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();

                string PinCode = string.Empty;

                UpDateUserDetails(ID, Title, FirstName, LastName, Email, MobileNo, DOB, Gender, Marital, HolidayDest, HolidayBudget, Deal, Newsletter, Frequency, Address, City, PinCode, Country, Origin, Destination, BookingStatus, BookingDate, BookingType, ProductType, State, CompanyID);

            }
            catch
            {

            }
            //Console.ReadLine();

        }

        public void UpDateUserDetails(string ID, string Title, string FirstName, string LastName, string Email, string MobileNo, string DOB, string Gender, string Marital, string HolidayDest, string HolidayBudget, string Deal, string Newsletter, string Frequency, string Address, string City, string PinCode, string Country, string Origin, string Destination, string BookingStatus, string BookingDate, string BookingType, string ProductType, string State, string CompanyID)
        {
            string ImagePath = string.Empty;
            UserData ObjUserData = new UserData();
            User ObjUser = new User();
            ObjUser.LoginId = Email;
            ObjUser.Image = ImagePath;
            ObjUser.First_Name = FirstName.Trim();
            ObjUser.Last_Name = LastName.Trim();
            ObjUser.MailId = Email.Trim();
            ObjUser.MobileNo = MobileNo.Trim();
            if (!string.IsNullOrEmpty(Address))
            {
                ObjUser.Address = Address.Trim();
            }
            if (!string.IsNullOrEmpty(City))
            {
                ObjUser.City = City.Trim();
            }
            if (!string.IsNullOrEmpty(Title))
            {
                ObjUser.Title = Title.Trim();
            }
            if (!string.IsNullOrEmpty(Country))
            {
                ObjUser.Country = Country;
            }
            if (!string.IsNullOrEmpty(PinCode))
            {
                ObjUser.PinCode = PinCode.Trim();
            }
            if (!string.IsNullOrEmpty(DOB))
            {
                ObjUser.DOB = Convert.ToDateTime(DOB).ToString("dd-MM-yyyy");
            }
            if (!string.IsNullOrEmpty(Gender))
            {
                ObjUser.Gender = Gender;
            }
            if (!string.IsNullOrEmpty(Marital))
            {
                ObjUser.Marital = Marital;
            }
            if (!string.IsNullOrEmpty(HolidayDest))
            {
                ObjUser.HolidayDestination = HolidayDest;
            }
            if (!string.IsNullOrEmpty(HolidayBudget))
            {
                ObjUser.HolidayBudget = HolidayBudget;
            }
            if (!string.IsNullOrEmpty(Deal))
            {

                ObjUser.DealInterest = Deal;
            }
            if (!string.IsNullOrEmpty(Newsletter))
            {
                ObjUser.RegionInterest = Newsletter;
            }
            if (!string.IsNullOrEmpty(Frequency))
            {
                ObjUser.Frequency = Frequency;
            }
            ObjUser.CampaignID = ID;
            if (!string.IsNullOrEmpty(Origin))
            {
                ObjUser.Origin = Origin;
            }
            if (!string.IsNullOrEmpty(Destination))
            {
                ObjUser.Destination = Destination;
            }
            if (!string.IsNullOrEmpty(BookingStatus))
            {
                ObjUser.BookingStatus = BookingStatus;
            }
            if (!string.IsNullOrEmpty(BookingDate))
            {
                ObjUser.BookingDate = BookingDate;
            }
            if (!string.IsNullOrEmpty(BookingType))
            {
                ObjUser.BookingType = BookingType;
            }
            if (!string.IsNullOrEmpty(ProductType))
            {
                ObjUser.ProductType = ProductType;
            }

            if (!string.IsNullOrEmpty(CompanyID))
            {
                ObjUser.CompanyID = CompanyID;
            }
            if (!string.IsNullOrEmpty(State))
            {
                ObjUser.State = State;
            }

            if (ObjUserData.UpdateCampaignUserDetails(ObjUser))
            {

            }
            else
            {

            }
        }

        public void InsertUSerDetail(string ID, string Title, string FirstName, string LastName, string Email, string MobileNo, string DOB, string Gender, string Marital, string HolidayDest, string HolidayBudget, string Deal, string Newsletter, string Frequency, string Address, string City, string PinCode, string Country, string Origin, string Destination, string BookingStatus, string BookingDate, string BookingType, string ProductType, string CompanyID)
        {
            User ObjUser = new User();
            UserData ObjData = new UserData();
            string EncPassword = string.Empty;
            string SrcMedia = string.Empty;
            string key = string.Empty;
            //try
            //{
            //    SrcMedia = Request.UrlReferrer.Query;
            //    SrcMedia = SrcMedia.Split('=')[1];

            //}
            //catch { }

            EncPassword = "";
            ObjUser.LoginId = Email.Trim();
            ObjUser.Password = "";
            ObjUser.First_Name = FirstName.Trim();
            ObjUser.Last_Name = LastName.Trim();
            ObjUser.Enc_Password = EncPassword;
            ObjUser.MailId = Email.Trim();
            ObjUser.CompanyId = CompCredentials.CompanyId;
            ObjUser.MobileNo = MobileNo;
            ObjUser.Status = true;
            ObjUser.LastLogin = DateTime.Now;
            ObjUser.ModifiedDate = DateTime.Now;
            ObjUser.ReferredBy = 0;
            ObjUser.SourceMedia = SrcMedia;

            ObjUser.DOB = DOB;
            ObjUser.Gender = Gender;
            ObjUser.Marital = Marital;
            ObjUser.HolidayDestination = HolidayDest;
            ObjUser.HolidayBudget = HolidayBudget;
            ObjUser.DealInterest = Deal;
            ObjUser.RegionInterest = Newsletter;
            ObjUser.Frequency = Frequency;
            ObjUser.CampaignID = ID;
            ObjUser.Origin = Origin;
            ObjUser.Destination = Destination;
            ObjUser.ProductType = ProductType;
            string Msg = string.Empty;
            DataTable temp = ObjData.UserAuthorized(ObjUser, 10);
            if (temp != null && temp.Rows.Count > 0)
            {

            }
            else
            {
                int Rval = ObjData.RegisterUser(ObjUser);
            }

        }

        public void UpDateCampaignID(string ID, string UsrID)
        {
            string ImagePath = string.Empty;
            UserData ObjUserData = new UserData();
            User ObjUser = new User();
            ObjUser.UsrId = Convert.ToInt32(UsrID);

            ObjUser.CampaignID = ID;

            if (ObjUserData.UpdateCampaignID(ObjUser))
            {

            }
            else
            {

            }
        }

        public void ActiveDestinationCampaign(string Title, string FirstName, string LastName, string Email, string MobileNo, string DOB, string Gender, string Marital, string HolidayDest, string HolidayBudget, string Deal, string Newsletter, string Frequency, string Origin, string Destination, string BookingStatus, string BookingDate, string BookingType, string ProductType, string Adderss, string City, string State, string Country, string PostCode, string CompanyID)
        {

            //Deal = Deal.Substring(0, Deal.LastIndexOf(",") + 0);
            //Newsletter = Newsletter.Substring(0, Newsletter.LastIndexOf(",") + 0);
            //Frequency = Frequency.Substring(0, Frequency.LastIndexOf(",") + 0);

            string SubsciberUser = "NewSubscriber";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("");   //  For Add Contact 
                request.Method = "POST";

                string postData = "email=" + Email + "&first_name=" + FirstName + "&last_name=" + LastName + "&phone=" + MobileNo + "&field[1,0]=" + Title + "&field[6,0]=" + SubsciberUser + "&p[3]=3&status[3]=1&instantresponders[3]=1";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                string RValues = responseFromServer;
                reader.Close();
                dataStream.Close();
                response.Close();



                XmlDocument doc1 = new XmlDocument();
                doc1.LoadXml(RValues);
                string ID = string.Empty;
                if (doc1.SelectSingleNode("subscriber_insert_post/row/id") != null)
                {
                    ID = doc1.SelectSingleNode("subscriber_insert_post/row/id").InnerText;
                    Updatedata(ID, Title, FirstName, LastName, Email, MobileNo, DOB, Gender, Marital, HolidayDest, HolidayBudget, Deal, Newsletter, Frequency, Origin, Destination, BookingStatus, BookingDate, BookingType, ProductType, Adderss, City, State, Country, PostCode, CompanyID);
                }
                else
                {
                    string Address = string.Empty;

                    InsertUSerDetail(ID, Title, FirstName, LastName, Email, MobileNo, DOB, Gender, Marital, HolidayDest, HolidayBudget, Deal, Newsletter, Frequency, Address, City, PostCode, Country, Origin, Destination, BookingStatus, BookingDate, BookingType, ProductType, CompanyID);
                }
            }
            catch
            {

            }

        }


        #endregion

        #region Call System
        public string CallResponse(string ContactNo)
        {

            var responseString = "";
            string CheckRes = string.Empty;
            try
            {
                //var request = (HttpWebRequest)WebRequest.Create("http://192.168.67.15/wcb.php");
                var request = (HttpWebRequest)WebRequest.Create("http://185.8.95.225/wcb.php");
                var postData = "p=" + ContactNo + "";
                postData += "&i=3";
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                dynamic res = JObject.Parse(responseString);
                CheckRes = res.Response;
            }
            catch (WebException e)
            {

                using (WebResponse response = e.Response)
                {
                    CheckRes = "Failed";
                }
            }

            return CheckRes;

        }
        #endregion
    }
}