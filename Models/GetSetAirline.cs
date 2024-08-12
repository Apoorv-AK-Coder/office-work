using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class GetSetAirline
    {
        
        public DataTable GETAirlineFareImage(AirlinefareRequest AFReq)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[3];
                if (!string.IsNullOrEmpty(AFReq.Company))
                {
                    Param[0] = new SqlParameter("@paramCompany", SqlDbType.VarChar);
                    Param[0].Value = AFReq.Company;
                }
                if (!string.IsNullOrEmpty(AFReq.Airline))
                {
                    Param[1] = new SqlParameter("@ParamAirlineName", SqlDbType.VarChar);
                    Param[1].Value = AFReq.Airline;
                }
                Param[2] = new SqlParameter("@Counter", SqlDbType.VarChar);
                Param[2].Value = AFReq.Counter;
                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GETFareFlightDestination_New", Param);
                    if (ds.Tables[0] != null)
                        return ds.Tables[0];
                    else return null;
                }
            }
            catch { return null; }
        }
        public DataSet GetFaresFlightAirline(AirlineRequest AReq)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[3];
                if (!string.IsNullOrEmpty(AReq.Airline))
                {
                    Param[0] = new SqlParameter("@ParamAirlineCode", SqlDbType.VarChar);
                    Param[0].Value = AReq.Airline;
                }
                if (!string.IsNullOrEmpty(AReq.CabinClass))
                {
                    Param[1] = new SqlParameter("@ParamClass", SqlDbType.VarChar, 50);
                    Param[1].Value = AReq.CabinClass;
                }
                Param[2] = new SqlParameter("@Counter", SqlDbType.VarChar);
                Param[2].Value = AReq.Counter;

                using (SqlConnection connection = DataConnection.GetOffLineFareConnection())
                {
                    DataSet ds = SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "GETFareFlightDestination_New", Param);
                    if (ds!= null)
                        return ds;
                    else return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
