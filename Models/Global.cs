using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class Global
    {

        public static string GenerateIDs(string _prefix)

        {

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
        public static DataTable ExecuteSPReturnDT(object[] dbCallIngrediats, SqlConnection Conn)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                    {
                        string parValue = null;
                        if (dbCallIngrediats[i + 1] != null)
                            parValue = dbCallIngrediats[i + 1].ToString();

                        cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                    }
                    cmd.Connection.Open();
                    da.Fill(dt);
                }
                catch { return dt; }
            }
            return dt;
        }
        public static DataSet ExecuteSPReturnDS(object[] dbCallIngrediats, SqlConnection Conn)
        {

            DataSet ds = new DataSet();
            using (SqlConnection con = Conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), Conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                    {
                        string parValue = null;
                        if (dbCallIngrediats[i + 1] != null)
                            parValue = dbCallIngrediats[i + 1].ToString();

                        cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                    }
                    cmd.Connection.Open();
                    da.Fill(ds);
                }
                catch { return ds; }
            }
            return ds;
        }
        public static bool ExecuteNonQuery(object[] dbCallIngrediats, SqlConnection Conn)
        {

            int Rval = 0;
            using (SqlConnection con = Conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 1; i < dbCallIngrediats.Length; i += 2)
                    {
                        string parValue = null;
                        if (dbCallIngrediats[i + 1] != null)
                            parValue = dbCallIngrediats[i + 1].ToString();

                        cmd.Parameters.AddWithValue(dbCallIngrediats[i].ToString(), parValue);
                    }

                    cmd.Connection.Open();
                    Rval = cmd.ExecuteNonQuery();
                }
                catch { return false; }
            }
            return Rval == 1 ? true : false;
        }
    }
}
