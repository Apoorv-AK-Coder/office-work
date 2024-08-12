using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace TravelSite.Models
{
    public class GetSetOfferDAL
    {

        public DataSet GETHomePageOffer(HomePageOffer HPO)
        {

            try
            {
                SqlParameter[] Param = new SqlParameter[5];

                if (!string.IsNullOrEmpty(HPO.Company))
                {
                    Param[0] = new SqlParameter("@paramCompany", SqlDbType.VarChar);
                    Param[0].Value = HPO.Company;
                }
                if (!string.IsNullOrEmpty(HPO.OfferType))
                {
                    Param[1] = new SqlParameter("@paramOfferType", SqlDbType.VarChar);
                    Param[1].Value = HPO.OfferType;
                }
                if (!string.IsNullOrEmpty(HPO.PageType))
                {
                    Param[2] = new SqlParameter("@paramPageType", SqlDbType.VarChar);
                    Param[2].Value = HPO.PageType;
                }
                if (!string.IsNullOrEmpty(HPO.CClass))
                {
                    Param[3] = new SqlParameter("@paramClass", SqlDbType.VarChar);
                    Param[3].Value = HPO.CClass;
                }
                Param[4] = new SqlParameter("@Counter", SqlDbType.VarChar);
                Param[4].Value = HPO.Counter;

                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    return SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GETHomePageOffer", Param);
                }
            }
            catch { return null; }
        }

        public DataTable GETHomePageOnlyOffer(HomePageOffer HPO)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[5];

                if (!string.IsNullOrEmpty(HPO.Company))
                {
                    Param[0] = new SqlParameter("@paramCompany", SqlDbType.VarChar);
                    Param[0].Value = HPO.Company;
                }
                if (!string.IsNullOrEmpty(HPO.OfferType))
                {
                    Param[1] = new SqlParameter("@paramOfferType", SqlDbType.VarChar);
                    Param[1].Value = HPO.OfferType;
                }
                if (!string.IsNullOrEmpty(HPO.PageType))
                {
                    Param[2] = new SqlParameter("@paramPageType", SqlDbType.VarChar);
                    Param[2].Value = HPO.PageType;
                }
                if (!string.IsNullOrEmpty(HPO.CClass))
                {
                    Param[3] = new SqlParameter("@paramClass", SqlDbType.VarChar);
                    Param[3].Value = HPO.CClass;
                }
                Param[4] = new SqlParameter("@Counter", SqlDbType.VarChar);
                Param[4].Value = HPO.Counter;

                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GETHomePageOffer", Param);
                    if (ds.Tables[0] != null)
                        return ds.Tables[0];
                    else return null;
                }
            }
            catch { return null; }
        }

        public DataTable GetRecentBlog_Tb()
        {
            DataSet _ds = new DataSet();
            try
            {
                using (SqlConnection connection = DataConnection.GetConnectionBlog())
                {
                    SqlCommand _cmd = new SqlCommand("showrecentblog", connection);
                    _cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter _adp = new SqlDataAdapter(_cmd);
                    _adp.Fill(_ds);
                    return _ds.Tables[0];
                }
            }
            catch
            {
                return _ds.Tables[0];
            }
        }

        public DataSet GetBlogContent_DS()
        {
            DataSet _ds = new DataSet();
            try
            {
                using (SqlConnection _con = DataConnection.GetConnectionBlog())
                {
                    SqlParameter[] _sqlParam = new SqlParameter[5];
                    _sqlParam[0] = new SqlParameter("@subcatid", SqlDbType.Int);
                    _sqlParam[1] = new SqlParameter("@blgid", SqlDbType.Int);
                    _sqlParam[2] = new SqlParameter("@Page", 1);
                    _sqlParam[3] = new SqlParameter("@PageSize", 4);
                    _sqlParam[4] = new SqlParameter("@company", "3517_CT");
                    _ds = SqlHelper.ExecuteDataset(_con, CommandType.StoredProcedure, "showblogwithheading", _sqlParam);
                    return _ds;
                }
            }
            catch
            {
                return _ds;
            }
        }
        public DataTable GetOfflineFaresFlightDestination(FlightOfferRequest FOReq)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[13];
                if (!string.IsNullOrEmpty(FOReq.SeasonID))
                {
                    Param[0] = new SqlParameter("@ParamSeasonID", SqlDbType.Int);
                    Param[0].Value = Convert.ToInt32(FOReq.SeasonID);
                }
                if (!string.IsNullOrEmpty(FOReq.DestFrom))
                {
                    Param[1] = new SqlParameter("@ParamDestFrom", SqlDbType.VarChar, 50);
                    Param[1].Value = FOReq.DestFrom;
                }
                if (!string.IsNullOrEmpty(FOReq.DestFromName))
                {
                    Param[2] = new SqlParameter("@ParamDestFromName", SqlDbType.VarChar, 100);
                    Param[2].Value = FOReq.DestFromName;
                }
                if (!string.IsNullOrEmpty(FOReq.DestTo))
                {
                    Param[3] = new SqlParameter("@ParamDestTo", SqlDbType.VarChar, 50);
                    Param[3].Value = FOReq.DestTo;
                }
                if (!string.IsNullOrEmpty(FOReq.DestToName))
                {
                    Param[4] = new SqlParameter("@ParamDestToName", SqlDbType.VarChar, 50);
                    Param[4].Value = FOReq.DestToName;
                }
                if (!string.IsNullOrEmpty(FOReq.CabinClass))
                {
                    Param[5] = new SqlParameter("@ParamClass", SqlDbType.VarChar, 20);
                    Param[5].Value = FOReq.CabinClass;
                }
                if (!string.IsNullOrEmpty(FOReq.ContinentCode))
                {
                    Param[6] = new SqlParameter("@ParamContinentCode", SqlDbType.VarChar, 50);
                    Param[6].Value = FOReq.ContinentCode;
                }
                if (!string.IsNullOrEmpty(FOReq.ContinentName))
                {
                    Param[7] = new SqlParameter("@ParamContinentName", SqlDbType.VarChar, 100);
                    Param[7].Value = FOReq.ContinentName;
                }
                if (!string.IsNullOrEmpty(FOReq.PageType))
                {
                    Param[8] = new SqlParameter("@ParamPageType", SqlDbType.VarChar, 50);
                    Param[8].Value = FOReq.PageType;
                }
                if (!string.IsNullOrEmpty(FOReq.Company))
                {
                    Param[9] = new SqlParameter("@ParamCompany", SqlDbType.VarChar, 50);
                    Param[9].Value = FOReq.Company;
                }

                if (!string.IsNullOrEmpty(FOReq.DepDate))
                {
                    Param[10] = new SqlParameter("@ParamTravelStartDate", SqlDbType.DateTime);
                    Param[10].Value = Convert.ToDateTime(FOReq.DepDate);
                }
                if (!string.IsNullOrEmpty(FOReq.RetDate))
                {
                    Param[11] = new SqlParameter("@ParamTravelEndDate", SqlDbType.DateTime);
                    Param[11].Value = Convert.ToDateTime(FOReq.RetDate);
                }



                Param[12] = new SqlParameter("@Counter", SqlDbType.VarChar);
                Param[12].Value = FOReq.Counter;

                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GETFareFlightDestination_New", Param);
                    if (ds.Tables[0] != null)
                        return ds.Tables[0];
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetFaresFlightDestination(FlightOfferRequest FOReq)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[11];
                if (!string.IsNullOrEmpty(FOReq.SeasonID))
                {
                    Param[0] = new SqlParameter("@ParamSeasonID", SqlDbType.Int);
                    Param[0].Value = Convert.ToInt32(FOReq.SeasonID);
                }
                if (!string.IsNullOrEmpty(FOReq.DestFrom))
                {
                    Param[1] = new SqlParameter("@ParamDestFrom", SqlDbType.VarChar, 50);
                    Param[1].Value = FOReq.DestFrom;
                }
                if (!string.IsNullOrEmpty(FOReq.DestFromName))
                {
                    Param[2] = new SqlParameter("@ParamDestFromName", SqlDbType.VarChar, 100);
                    Param[2].Value = FOReq.DestFromName;
                }
                if (!string.IsNullOrEmpty(FOReq.DestTo))
                {
                    Param[3] = new SqlParameter("@ParamDestTo", SqlDbType.VarChar, 50);
                    Param[3].Value = FOReq.DestTo;
                }
                if (!string.IsNullOrEmpty(FOReq.DestToName))
                {
                    Param[4] = new SqlParameter("@ParamDestToName", SqlDbType.VarChar, 50);
                    Param[4].Value = FOReq.DestToName;
                }
                if (!string.IsNullOrEmpty(FOReq.CabinClass))
                {
                    Param[5] = new SqlParameter("@ParamClass", SqlDbType.VarChar, 20);
                    Param[5].Value = FOReq.CabinClass;
                }
                if (!string.IsNullOrEmpty(FOReq.ContinentCode))
                {
                    Param[6] = new SqlParameter("@ParamContinentCode", SqlDbType.VarChar, 50);
                    Param[6].Value = FOReq.ContinentCode;
                }
                if (!string.IsNullOrEmpty(FOReq.ContinentName))
                {
                    Param[7] = new SqlParameter("@ParamContinentName", SqlDbType.VarChar, 100);
                    Param[7].Value = FOReq.ContinentName;
                }
                if (!string.IsNullOrEmpty(FOReq.PageType))
                {
                    Param[8] = new SqlParameter("@ParamPageType", SqlDbType.VarChar, 50);
                    Param[8].Value = FOReq.PageType;
                }
                if (!string.IsNullOrEmpty(FOReq.Company))
                {
                    Param[9] = new SqlParameter("@ParamCompany", SqlDbType.VarChar, 50);
                    Param[9].Value = FOReq.Company;
                }
                Param[10] = new SqlParameter("@Counter", SqlDbType.VarChar);
                Param[10].Value = FOReq.Counter;

                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GETFareFlightDestination_New", Param);
                    if (ds.Tables[0] != null)
                        return ds.Tables[0];
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetContents(ContantHeadingReq CHeading)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                if (!string.IsNullOrEmpty(CHeading.AirportCode))
                {
                    param[0] = new SqlParameter("@paramAirportCode", SqlDbType.VarChar, 5);
                    param[0].Value = CHeading.AirportCode;
                }
                if (!string.IsNullOrEmpty(CHeading.DestinationCode))
                {
                    param[1] = new SqlParameter("@paramDestinationCode", SqlDbType.VarChar, 5);
                    param[1].Value = CHeading.DestinationCode;
                }
                if (!string.IsNullOrEmpty(CHeading.LangCode))
                {
                    param[2] = new SqlParameter("@paramLangCode", SqlDbType.VarChar, 5);
                    param[2].Value = CHeading.LangCode;
                }
                if (!string.IsNullOrEmpty(CHeading.PageUrl))
                {
                    param[3] = new SqlParameter("@paramPageUrl", SqlDbType.VarChar, 2000);
                    param[3].Value = CHeading.PageUrl;
                }
                if (!string.IsNullOrEmpty(CHeading.CompanyID))
                {
                    param[4] = new SqlParameter("@paramcompany", SqlDbType.VarChar, 50);
                    param[4].Value = CHeading.CompanyID;
                }
                if (!string.IsNullOrEmpty(CHeading.Airline))
                {
                    param[5] = new SqlParameter("@paramML_Airline", SqlDbType.VarChar, 50);
                    param[5].Value = CHeading.Airline;
                }
                if (!string.IsNullOrEmpty(CHeading.Type))
                {
                    param[6] = new SqlParameter("@paramML_Type", SqlDbType.VarChar, 50);
                    param[6].Value = CHeading.Type;
                }
                param[7] = new SqlParameter("@Counter", SqlDbType.Int);
                param[7].Value = CHeading.Counter;

                using (SqlConnection connection = DataConnection.GetConnectionMLWebsites())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_ContantHeading", param);
                    if (ds.Tables[0] != null)
                        return ds.Tables[0];
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool SetFareQuotes(FareQuotesDetails FQDetails)
        {
            try
            {
                string device = string.Empty;
                var UserAgent = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
                if (UserAgent != null && (UserAgent.Contains("iPhone") || UserAgent.Contains("Windows Phone") || UserAgent.Contains("Android")))
                    device = "M";
                else if (UserAgent != null && UserAgent.Contains("iPad"))
                    device = "T";
                else
                    device = "D";

                SqlParameter[] Param = new SqlParameter[29];

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
                if (!string.IsNullOrEmpty(FQDetails.EMail))
                {
                    Param[3] = new SqlParameter("@paramEMail", SqlDbType.NVarChar);
                    Param[3].Value = FQDetails.EMail;
                }
                if (!string.IsNullOrEmpty(FQDetails.TripType))
                {
                    Param[4] = new SqlParameter("@paramTripType", SqlDbType.NVarChar);
                    Param[4].Value = FQDetails.TripType;
                }
                if (FQDetails.date != null)
                {
                    Param[5] = new SqlParameter("@paramdate", SqlDbType.Date);
                    Param[5].Value = FQDetails.date;
                }
                if (FQDetails.ReturnDate != null)
                {
                    Param[6] = new SqlParameter("@paramReturnDate", SqlDbType.Date);
                    Param[6].Value = FQDetails.ReturnDate;
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
                if (!string.IsNullOrEmpty(FQDetails.cClass))
                {
                    Param[9] = new SqlParameter("@paramClass", SqlDbType.NVarChar);
                    Param[9].Value = FQDetails.cClass;
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
                if (FQDetails.dDateTime != null)
                {
                    Param[13] = new SqlParameter("@paramDateTime", SqlDbType.DateTime);
                    Param[13].Value = FQDetails.dDateTime;
                }
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
                if (!string.IsNullOrEmpty(FQDetails.FeedBackType))
                {
                    Param[22] = new SqlParameter("@paramFeedBackType", SqlDbType.NVarChar);
                    Param[22].Value = FQDetails.FeedBackType;
                }
                if (!string.IsNullOrEmpty(FQDetails.Subject))
                {
                    Param[23] = new SqlParameter("@paramSubject", SqlDbType.NVarChar);
                    Param[23].Value = FQDetails.Subject;
                }
                if (!string.IsNullOrEmpty(FQDetails.RefCode))
                {
                    Param[24] = new SqlParameter("@paramRefCode", SqlDbType.NVarChar);
                    Param[24].Value = FQDetails.RefCode;
                }
                if (!string.IsNullOrEmpty(FQDetails.SourceMedia))
                {
                    Param[25] = new SqlParameter("@ParamSourceMedia", SqlDbType.NVarChar);
                    Param[25].Value = FQDetails.SourceMedia;
                }
                if (!string.IsNullOrEmpty(device))
                {
                    Param[26] = new SqlParameter("@DeviceName", SqlDbType.VarChar, 50);
                    Param[26].Value = device;
                }

                if (!string.IsNullOrEmpty(FQDetails.AirlineName))
                {
                    Param[27] = new SqlParameter("@ParamAirlineName", SqlDbType.VarChar, 50);
                    Param[27].Value = FQDetails.AirlineName;
                }
                if (!string.IsNullOrEmpty(FQDetails.CallRes))
                {
                    Param[28] = new SqlParameter("@ParamCallRes", SqlDbType.NVarChar);
                    Param[28].Value = FQDetails.CallRes;
                }
                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    int i = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "InsertFareQuotes", Param);
                    return i > 0 ? true : false;
                }
            }
            catch { return false; }
        }
    }
}
