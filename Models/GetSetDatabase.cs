using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;

namespace TravelSite.Models
{
    public class GetSetDatabase
    {
        //Create object of the Binding
        static Binding binding = new BasicHttpBinding();
        //Create endpointAddress of the Service
        static EndpointAddress endpointAddress = new
        EndpointAddress("http://dataservices.flightxpertuk.com/FandHServices.svc?wsdl");

        //Create Client of the Service        


        public GetSetDatabase() { }

        #region airport autocomplete



        #endregion

        #region booking Flow

        #region Booking Master


        #endregion

        #region Booking Details



        #endregion





        #region SET_FlightDetails

        public bool SET_FlightDetails(string BM_BookingID, string BM_InvoiceNo, string BM_BookingType,
            string BM_CurrencyType, string BM_BookingByCompany, string BM_BookingStatus, string BM_IsInsertBM,
            string BD_ProdID, string BD_Provider, string BD_BookingBy, string BD_BookingByType,
            string BD_BookingDateTime, string BD_BookingStatus,
            string BD_BookingRemarks, string BD_TotalAmount, string BD_PNRConfirmation, string BD_SourceMedia,
            string BD_ProductType, string BD_isLocked, string BD_ModifiedBy, string BD_Supplier,
            string BD_MailIssued, string SM_JourneyType, string SM_LastTktDate, string SM_Origin,
            string SM_Destination, string SM_ValidatingCarrier, string SM_CabinClass, string SM_ModifiedBy,
            string CD_PaxID, string CD_PhoneNo, string CD_MobileNo, string CD_FAX, string CD_EmailAddress,
            string CD_Country, string CD_State, string CD_City, string CD_Address, string CD_PostCode,
            string CD_AddressType, string CD_ModifiedBy, DataTable AirSectors, DataTable AmountCharges,
            DataTable Passengers)
        {

            SqlParameter[] param = new SqlParameter[46];
            try
            {
                using (SqlConnection conection = DataConnection.GetConnection())
                {
                    if (!string.IsNullOrEmpty(BM_BookingID))
                    {
                        param[0] = new SqlParameter("@ParamBM_BookingID", SqlDbType.VarChar, 50);
                        param[0].Value = BM_BookingID;
                    }
                    if (!string.IsNullOrEmpty(BM_InvoiceNo))
                    {
                        param[1] = new SqlParameter("@ParamBM_InvoiceNo", SqlDbType.VarChar, 50);
                        param[1].Value = BM_InvoiceNo;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingType))
                    {
                        param[2] = new SqlParameter("@ParamBM_BookingType", SqlDbType.VarChar, 50);
                        param[2].Value = BM_BookingType;
                    }
                    if (!string.IsNullOrEmpty(BM_CurrencyType))
                    {
                        param[3] = new SqlParameter("@ParamBM_CurrencyType", SqlDbType.VarChar, 50);
                        param[3].Value = BM_CurrencyType;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingByCompany))
                    {
                        param[4] = new SqlParameter("@ParamBM_BookingByCompany", SqlDbType.VarChar, 50);
                        param[4].Value = BM_BookingByCompany;
                    }
                    if (!string.IsNullOrEmpty(BM_BookingStatus))
                    {
                        param[5] = new SqlParameter("@ParamBM_BookingStatus", SqlDbType.VarChar, 50);
                        param[5].Value = BM_BookingStatus;
                    }
                    param[6] = new SqlParameter("@ParamBM_IsInsertBM", SqlDbType.VarChar, 50);
                    param[6].Value = BM_IsInsertBM;
                    if (!string.IsNullOrEmpty(BD_ProdID))
                    {
                        param[7] = new SqlParameter("@ParamBD_ProdID", SqlDbType.VarChar, 50);
                        param[7].Value = BD_ProdID;
                    }
                    if (!string.IsNullOrEmpty(BD_Provider))
                    {
                        param[8] = new SqlParameter("@ParamBD_Provider", SqlDbType.VarChar, 50);
                        param[8].Value = BD_Provider;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingBy))
                    {
                        param[9] = new SqlParameter("@ParamBD_BookingBy", SqlDbType.VarChar, 100);
                        param[9].Value = BD_BookingBy;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingByType))
                    {
                        param[10] = new SqlParameter("@ParamBD_BookingByType", SqlDbType.VarChar, 100);
                        param[10].Value = BD_BookingByType;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingDateTime))
                    {
                        param[11] = new SqlParameter("@ParamBD_BookingDateTime", SqlDbType.DateTime);
                        param[11].Value = Convert.ToDateTime(BD_BookingDateTime);
                    }
                    if (!string.IsNullOrEmpty(BD_BookingStatus))
                    {
                        param[12] = new SqlParameter("@ParamBD_BookingStatus", SqlDbType.VarChar, 50);
                        param[12].Value = BD_BookingStatus;
                    }
                    if (!string.IsNullOrEmpty(BD_BookingRemarks))
                    {
                        param[13] = new SqlParameter("@ParamBD_BookingRemarks", SqlDbType.VarChar, 2000);
                        param[13].Value = BD_BookingRemarks;
                    }
                    if (!string.IsNullOrEmpty(BD_TotalAmount))
                    {
                        param[14] = new SqlParameter("@ParamBD_TotalAmount", SqlDbType.Money);
                        param[14].Value = Convert.ToDouble(BD_TotalAmount);
                    }
                    if (!string.IsNullOrEmpty(BD_PNRConfirmation))
                    {
                        param[15] = new SqlParameter("@ParamBD_PNRConfirmation", SqlDbType.VarChar, 50);
                        param[15].Value = BD_PNRConfirmation;
                    }
                    if (!string.IsNullOrEmpty(BD_SourceMedia))
                    {
                        param[16] = new SqlParameter("@ParamBD_SourceMedia", SqlDbType.VarChar, 50);
                        param[16].Value = BD_SourceMedia;
                    }
                    if (!string.IsNullOrEmpty(BD_ProductType))
                    {
                        param[17] = new SqlParameter("@ParamBD_ProductType", SqlDbType.VarChar, 50);
                        param[17].Value = BD_ProductType;
                    }
                    if (!string.IsNullOrEmpty(BD_isLocked))
                    {
                        param[18] = new SqlParameter("@ParamBD_isLocked", SqlDbType.Bit);
                        param[18].Value = Convert.ToBoolean(BD_isLocked);
                    }
                    if (!string.IsNullOrEmpty(BD_ModifiedBy))
                    {
                        param[19] = new SqlParameter("@ParamBD_ModifiedBy", SqlDbType.VarChar, 100);
                        param[19].Value = BD_ModifiedBy;
                    }
                    if (!string.IsNullOrEmpty(BD_Supplier))
                    {
                        param[20] = new SqlParameter("@ParamBD_Supplier", SqlDbType.VarChar, 100);
                        param[20].Value = BD_Supplier;
                    }
                    if (!string.IsNullOrEmpty(BD_MailIssued))
                    {
                        param[21] = new SqlParameter("@ParamBD_MailIssued", SqlDbType.Bit);
                        param[21].Value = Convert.ToBoolean(BD_MailIssued);
                    }

                    if (!string.IsNullOrEmpty(SM_JourneyType))
                    {
                        param[22] = new SqlParameter("@ParamSM_JourneyType", SqlDbType.VarChar, 50);
                        param[22].Value = SM_JourneyType;
                    }
                    if (!string.IsNullOrEmpty(SM_LastTktDate))
                    {
                        param[23] = new SqlParameter("@ParamSM_LastTktDate", SqlDbType.VarChar, 200);
                        param[23].Value = SM_LastTktDate;
                    }
                    if (!string.IsNullOrEmpty(SM_Origin))
                    {
                        param[24] = new SqlParameter("@ParamBM_Origin", SqlDbType.VarChar, 50);
                        param[24].Value = SM_Origin;
                    }
                    if (!string.IsNullOrEmpty(SM_Destination))
                    {
                        param[25] = new SqlParameter("@ParamBM_Destination", SqlDbType.VarChar, 50);
                        param[25].Value = SM_Destination;
                    }
                    if (!string.IsNullOrEmpty(SM_ValidatingCarrier))
                    {
                        param[26] = new SqlParameter("@ParamSM_ValidatingCarrier", SqlDbType.VarChar, 50);
                        param[26].Value = SM_ValidatingCarrier;
                    }
                    if (!string.IsNullOrEmpty(SM_CabinClass))
                    {
                        param[27] = new SqlParameter("@ParamSM_CabinClass", SqlDbType.VarChar, 50);
                        param[27].Value = SM_CabinClass;
                    }
                    if (!string.IsNullOrEmpty(SM_ModifiedBy))
                    {
                        param[28] = new SqlParameter("@ParamSM_ModifiedBy", SqlDbType.VarChar, 50);
                        param[28].Value = SM_ModifiedBy;
                    }

                    if (!string.IsNullOrEmpty(CD_PaxID))
                    {
                        param[29] = new SqlParameter("@ParamCD_PaxID", SqlDbType.VarChar, 50);
                        param[29].Value = CD_PaxID;
                    }
                    if (!string.IsNullOrEmpty(CD_PhoneNo))
                    {
                        param[30] = new SqlParameter("@ParamCD_ContactNo", SqlDbType.VarChar, 100);
                        param[30].Value = CD_PhoneNo;
                    }
                    if (!string.IsNullOrEmpty(CD_MobileNo))
                    {
                        param[31] = new SqlParameter("@ParamCD_ContactNo", SqlDbType.VarChar, 100);
                        param[31].Value = CD_MobileNo;
                    }
                    if (!string.IsNullOrEmpty(CD_FAX))
                    {
                        param[32] = new SqlParameter("@ParamCD_FaxNo", SqlDbType.VarChar, 100);
                        param[32].Value = CD_FAX;
                    }
                    if (!string.IsNullOrEmpty(CD_EmailAddress))
                    {
                        param[33] = new SqlParameter("@ParamCD_EmailID", SqlDbType.VarChar, 500);
                        param[33].Value = CD_EmailAddress;
                    }
                    if (!string.IsNullOrEmpty(CD_Country))
                    {
                        param[34] = new SqlParameter("@ParamCD_Country", SqlDbType.VarChar, 200);
                        param[34].Value = CD_Country;
                    }
                    if (!string.IsNullOrEmpty(CD_State))
                    {
                        param[35] = new SqlParameter("@ParamCD_State", SqlDbType.VarChar, 100);
                        param[35].Value = CD_State;
                    }
                    if (!string.IsNullOrEmpty(CD_City))
                    {
                        param[36] = new SqlParameter("@ParamCD_City", SqlDbType.VarChar, 200);
                        param[36].Value = CD_City;
                    }
                    if (!string.IsNullOrEmpty(CD_Address))
                    {
                        param[37] = new SqlParameter("@ParamCD_Address", SqlDbType.VarChar, 2000);
                        param[37].Value = CD_Address;
                    }
                    if (!string.IsNullOrEmpty(CD_PostCode))
                    {
                        param[38] = new SqlParameter("@ParamCD_PostCode", SqlDbType.VarChar, 50);
                        param[38].Value = CD_PostCode;
                    }
                    if (!string.IsNullOrEmpty(CD_AddressType))
                    {
                        param[39] = new SqlParameter("@ParamCD_AddressType", SqlDbType.VarChar, 50);
                        param[39].Value = CD_AddressType;
                    }
                    //if (!string.IsNullOrEmpty(CD_ModifiedBy))
                    //{
                    //    param[40] = new SqlParameter("@ParamCD_ModifiedBy", SqlDbType.VarChar, 50);
                    //    param[40].Value = CD_ModifiedBy;
                    //}
                    param[41] = new SqlParameter("@ParamPassengers", Passengers);
                    param[42] = new SqlParameter("@ParamAmountCharges", AmountCharges);
                    param[43] = new SqlParameter("@ParamAirSectors", AirSectors);

                    param[44] = new SqlParameter("@ParamStatus", SqlDbType.Bit);
                    param[44].Direction = ParameterDirection.Output;

                    param[45] = new SqlParameter("@ParamError", SqlDbType.VarChar, 500);
                    param[45].Direction = ParameterDirection.Output;
                    SqlHelper.ExecuteNonQuery(conection, CommandType.StoredProcedure, "Usp_InsertFlightBooking", param);

                    string log = "Status=" + param[44].Value + "  ErrorNO=" + param[45].Value;
                    ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Errors/" + BM_BookingID + "--GetSetInDB.txt"), Convert.ToString(log));

                    return Convert.ToBoolean(param[44].Value);
                }
            }
            catch (Exception ex)
            {
                ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Errors/" + BM_BookingID + "--GetSetInDB.txt"), Convert.ToString(ex.Message + "\\n\\t" + ex.StackTrace + "\\n\\t" + ex.Source));
                return false;
            }
        }

        #endregion

        #region Transaction Master

        public string SET_Transaction_Master(string BookingID, string TrnsNo, string TrnsType, string TrnsPaymentStatus,
        string TrnsAmount, string TrnsCurrencyType, string TrnsBy, string TrnsDateTime, string TrnsRemarks,
        string TrnsSecurityKey, string TrnsStatus, string TrnsStatusDetail, string TrnsVSPTxID, string TrnsAuthNo,
        string TrnsAVSCV2, string TrnsAddressResult, string TrnsPostCodeResult, string TrnsCV2Result, string Trns3DSecureStatus,
        string TrnsCAVV, string TrnsModifiedBy, string Counter)
        {
            //   return client.SET_Transaction_Master(BookingID, TrnsNo, TrnsType, TrnsPaymentStatus,
            //TrnsAmount, TrnsCurrencyType, TrnsBy, TrnsDateTime, TrnsRemarks,
            //TrnsSecurityKey, TrnsStatus, TrnsStatusDetail, TrnsVSPTxID, TrnsAuthNo,
            //TrnsAVSCV2, TrnsAddressResult, TrnsPostCodeResult, TrnsCV2Result, Trns3DSecureStatus,
            //TrnsCAVV, TrnsModifiedBy, Counter);

            SqlParameter[] param = new SqlParameter[23];
            try
            {
                using (SqlConnection conection = DataConnection.GetConnection())
                {
                    if (!string.IsNullOrEmpty(BookingID))
                    {
                        param[0] = new SqlParameter("@ParamBookingID", SqlDbType.VarChar, 50);
                        param[0].Value = BookingID;
                    }
                    if (!string.IsNullOrEmpty(TrnsNo))
                    {
                        param[1] = new SqlParameter("@ParamTrnsNo", SqlDbType.VarChar, 50);
                        param[1].Value = TrnsNo;
                    }
                    if (!string.IsNullOrEmpty(TrnsType))
                    {
                        param[2] = new SqlParameter("@ParamTrnsType", SqlDbType.VarChar, 200);
                        param[2].Value = TrnsType;
                    }
                    if (!string.IsNullOrEmpty(TrnsPaymentStatus))
                    {
                        param[3] = new SqlParameter("@ParamTrnsPaymentStatus", SqlDbType.VarChar, 100);
                        param[3].Value = TrnsPaymentStatus;
                    }
                    if (!string.IsNullOrEmpty(TrnsAmount))
                    {
                        param[4] = new SqlParameter("@ParamTrnsAmount", SqlDbType.Money);
                        param[4].Value = Convert.ToDouble(TrnsAmount);
                    }
                    if (!string.IsNullOrEmpty(TrnsCurrencyType))
                    {
                        param[5] = new SqlParameter("@ParamTrnsCurrencyType", SqlDbType.VarChar, 50);
                        param[5].Value = TrnsCurrencyType;
                    }
                    if (!string.IsNullOrEmpty(TrnsBy))
                    {
                        param[6] = new SqlParameter("@ParamTrnsBy", SqlDbType.VarChar, 100);
                        param[6].Value = TrnsBy;
                    }
                    if (!string.IsNullOrEmpty(TrnsDateTime))
                    {
                        param[7] = new SqlParameter("@ParamTrnsDateTime", SqlDbType.DateTime);
                        param[7].Value = Convert.ToDateTime(TrnsDateTime);
                    }
                    if (!string.IsNullOrEmpty(TrnsRemarks))
                    {
                        param[8] = new SqlParameter("@ParamTrnsRemarks", SqlDbType.VarChar, 2000);
                        param[8].Value = TrnsRemarks;
                    }
                    if (!string.IsNullOrEmpty(TrnsSecurityKey))
                    {
                        param[9] = new SqlParameter("@ParamTrnsSecurityKey", SqlDbType.VarChar, 50);
                        param[9].Value = TrnsSecurityKey;
                    }
                    if (!string.IsNullOrEmpty(TrnsStatus))
                    {
                        param[10] = new SqlParameter("@ParamTrnsStatus", SqlDbType.VarChar, 50);
                        param[10].Value = TrnsStatus;
                    }
                    if (!string.IsNullOrEmpty(TrnsStatusDetail))
                    {
                        param[11] = new SqlParameter("@ParamTrnsStatusDetail", SqlDbType.VarChar, 500);
                        param[11].Value = TrnsStatusDetail;
                    }
                    if (!string.IsNullOrEmpty(TrnsVSPTxID))
                    {
                        param[12] = new SqlParameter("@ParamTrnsVSPTxID", SqlDbType.VarChar, 50);
                        param[12].Value = TrnsVSPTxID;
                    }
                    if (!string.IsNullOrEmpty(TrnsAuthNo))
                    {
                        param[13] = new SqlParameter("@ParamTrnsAuthNo", SqlDbType.VarChar, 50);
                        param[13].Value = TrnsAuthNo;
                    }
                    if (!string.IsNullOrEmpty(TrnsAVSCV2))
                    {
                        param[14] = new SqlParameter("@ParamTrnsAVSCV2", SqlDbType.VarChar, 50);
                        param[14].Value = TrnsAVSCV2;
                    }
                    if (!string.IsNullOrEmpty(TrnsAddressResult))
                    {
                        param[15] = new SqlParameter("@ParamTrnsAddressResult", SqlDbType.VarChar, 200);
                        param[15].Value = TrnsAddressResult;
                    }
                    if (!string.IsNullOrEmpty(TrnsPostCodeResult))
                    {
                        param[16] = new SqlParameter("@ParamTrnsPostCodeResult", SqlDbType.VarChar, 100);
                        param[16].Value = TrnsPostCodeResult;
                    }
                    if (!string.IsNullOrEmpty(TrnsCV2Result))
                    {
                        param[17] = new SqlParameter("@ParamTrnsCV2Result", SqlDbType.VarChar, 50);
                        param[17].Value = TrnsCV2Result;
                    }
                    if (!string.IsNullOrEmpty(Trns3DSecureStatus))
                    {
                        param[18] = new SqlParameter("@ParamTrns3DSecureStatus", SqlDbType.VarChar, 50);
                        param[18].Value = Trns3DSecureStatus;
                    }
                    if (!string.IsNullOrEmpty(TrnsCAVV))
                    {
                        param[19] = new SqlParameter("@ParamTrnsCAVV", SqlDbType.VarChar, 50);
                        param[19].Value = TrnsCAVV;
                    }
                    if (!string.IsNullOrEmpty(TrnsModifiedBy))
                    {
                        param[20] = new SqlParameter("@ParamTrnsModifiedBy", SqlDbType.VarChar, 50);
                        param[20].Value = TrnsModifiedBy;
                    }
                    param[21] = new SqlParameter("@Counter", SqlDbType.VarChar, 500);
                    param[21].Value = Counter;

                    param[22] = new SqlParameter("@ParamStatus", SqlDbType.VarChar, 500);
                    param[22].Direction = ParameterDirection.Output;

                    SqlHelper.ExecuteNonQuery(conection, CommandType.StoredProcedure, "GET_SET_Transaction_Master", param);
                    return param[22].Value.ToString();
                }
            }
            catch
            {
                return "false";
            }
        }



        #endregion

        #region Transaction Details

        public string SET_Transaction_Details(string BookingID, string TrnsNO, string CRDCardNo, string CRDHolderName, string CRDExpDate,
           string CRDValidFrom, string CRDIssueNo, string CRDSecurityCode, string CRDCardType, string CRDCountry,
           string CRDCoutyState, string CRDCity, string CRDPostCode, string CRDAddress, double CRDCardCharges,
           string CRDChargesType, string ModifiedBy, string Counter)
        {

            try
            {
                SqlParameter[] param = new SqlParameter[19];

                if (!string.IsNullOrEmpty(BookingID))
                {
                    param[0] = new SqlParameter("@ParamBookingID", SqlDbType.VarChar, 50);
                    param[0].Value = BookingID;
                }
                if (!string.IsNullOrEmpty(TrnsNO))
                {
                    param[1] = new SqlParameter("@ParamTrnsNo", SqlDbType.VarChar, 50);
                    param[1].Value = TrnsNO;
                }
                if (!string.IsNullOrEmpty(CRDCardNo))
                {
                    param[2] = new SqlParameter("@ParamCard_No", SqlDbType.VarChar, 100);
                    param[2].Value = CRDCardNo;
                }
                if (!string.IsNullOrEmpty(CRDHolderName))
                {
                    param[3] = new SqlParameter("@ParamHolder_Name", SqlDbType.VarChar, 200);
                    param[3].Value = CRDHolderName;
                }
                if (!string.IsNullOrEmpty(CRDExpDate))
                {
                    param[4] = new SqlParameter("@ParamExp_Date", SqlDbType.VarChar, 50);
                    param[4].Value = CRDExpDate;
                }
                if (!string.IsNullOrEmpty(CRDValidFrom))
                {
                    param[5] = new SqlParameter("@ParamValid_From", SqlDbType.VarChar, 50);
                    param[5].Value = CRDValidFrom;
                }
                if (!string.IsNullOrEmpty(CRDIssueNo))
                {
                    param[6] = new SqlParameter("@ParamIssue_No", SqlDbType.VarChar, 100);
                    param[6].Value = CRDIssueNo;
                }
                if (!string.IsNullOrEmpty(CRDSecurityCode))
                {
                    param[7] = new SqlParameter("@ParamSecurity_Code", SqlDbType.VarChar, 100);
                    param[7].Value = CRDSecurityCode;
                }
                if (!string.IsNullOrEmpty(CRDCardType))
                {
                    param[8] = new SqlParameter("@ParamCard_Type", SqlDbType.VarChar, 200);
                    param[8].Value = CRDCardType;
                }
                if (!string.IsNullOrEmpty(CRDCountry))
                {
                    param[9] = new SqlParameter("@ParamCountry", SqlDbType.VarChar, 200);
                    param[9].Value = CRDCountry;
                }
                if (!string.IsNullOrEmpty(CRDCoutyState))
                {
                    param[10] = new SqlParameter("@ParamCouty_State", SqlDbType.VarChar, 200);
                    param[10].Value = CRDCoutyState;
                }
                if (!string.IsNullOrEmpty(CRDCity))
                {
                    param[11] = new SqlParameter("@ParamCity", SqlDbType.VarChar, 200);
                    param[11].Value = CRDCity;
                }
                if (!string.IsNullOrEmpty(CRDPostCode))
                {
                    param[12] = new SqlParameter("@ParamPost_Code", SqlDbType.VarChar, 50);
                    param[12].Value = CRDPostCode;
                }
                if (!string.IsNullOrEmpty(CRDAddress))
                {
                    param[13] = new SqlParameter("@ParamAddress", SqlDbType.VarChar, 1000);
                    param[13].Value = CRDAddress;
                }
                if (CRDCardCharges > 0)
                {
                    param[14] = new SqlParameter("@ParamCard_Charges", SqlDbType.Money);
                    param[14].Value = Convert.ToDouble(CRDCardCharges);
                }
                if (!string.IsNullOrEmpty(CRDChargesType))
                {
                    param[15] = new SqlParameter("@ParamCharges_Type", SqlDbType.VarChar, 50);
                    param[15].Value = CRDChargesType;
                }
                if (!string.IsNullOrEmpty(ModifiedBy))
                {
                    param[16] = new SqlParameter("@ParamModifiedBy", SqlDbType.VarChar, 50);
                    param[16].Value = ModifiedBy;
                }
                param[17] = new SqlParameter("@Counter", SqlDbType.VarChar, 500);
                param[17].Value = Counter;

                param[18] = new SqlParameter("@ParamStatus", SqlDbType.VarChar, 500);
                param[18].Direction = ParameterDirection.Output;

                using (SqlConnection conection = DataConnection.GetConnection())
                {
                    SqlHelper.ExecuteNonQuery(conection, CommandType.StoredProcedure, "GET_SET_Transaction_Details", param);
                    return param[18].Value.ToString();
                }
            }
            catch
            {
                return "false";
            }
        }


        #endregion

        #endregion

        #region ID Creater

        public string GenerateIDs(string _prefix)
        {
            //return client.GenerateIDs(_prefix);
            string ID = string.Empty;
            using (SqlConnection _objConnection = DataConnection.GetConnection())
            {
                using (SqlCommand _objCommand = new SqlCommand())
                {
                    _objCommand.CommandType = CommandType.StoredProcedure;
                    _objCommand.CommandText = "Usp_GenrateIDs";
                    _objCommand.Connection = _objConnection;
                    _objCommand.Parameters.Add("@STRBOOKREFNO", SqlDbType.NVarChar, 25).Direction = ParameterDirection.Output;
                    _objCommand.Parameters.Add("@INTBOOKREFSuffix", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                    _objCommand.Parameters.Add("@STRPREFIX", SqlDbType.NVarChar, 25).Value = _prefix;
                    _objConnection.Open();
                    _objCommand.ExecuteNonQuery();
                    ID = (_objCommand.Parameters["@STRBOOKREFNO"].Value.ToString() + _objCommand.Parameters["@INTBOOKREFSuffix"].Value.ToString());
                    _objConnection.Close();
                    return ID;
                }
            }
        }

        #endregion




        #region CampaignMaster

        public DataTable GET_Campaign_Master(string CampID, string CompanyID)
        {

            //return client.GET_Campaign_Master(CampID, CompanyID);
            SqlParameter[] param = new SqlParameter[3];
            try
            {
                if (!String.IsNullOrEmpty(CompanyID))
                {
                    param[0] = new SqlParameter("@CompanyId", SqlDbType.NVarChar, (100));
                    param[0].Value = CompanyID;
                }
                using (SqlConnection conection = DataConnection.GetConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(conection, CommandType.StoredProcedure, "SP_Get_CompanyDetails", param);
                    return ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region Get Exchange Rate


        #endregion
    }
}