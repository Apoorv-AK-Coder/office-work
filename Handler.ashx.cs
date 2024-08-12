using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using TravelSite.Models;

namespace TravelSite
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string str = "";
            string prefixText = context.Request.QueryString["q"].ToString().Replace("'", "");
            try
            {
                List<AData> data = new List<AData>();
                using (SqlConnection SqlConn = DataConnection.GetConnection())
                {
                    SqlConn.Open();
                    using (SqlCommand SqlCmd = new SqlCommand("Usp_AutoComplete", SqlConn)) //GET_Airport_AutoComplete
                    {
                        SqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlCmd.Parameters.AddWithValue("@prefixText", prefixText);
                        SqlCmd.Parameters.AddWithValue("@LanguageCode", "EN");
                        using (SqlDataReader Reader = SqlCmd.ExecuteReader())
                        {
                            if (Reader != null)
                            {
                                while (Reader.Read())
                                {
                                    data.Add(new AData(Reader));
                                }
                            }
                        }
                        SqlConn.Close();
                    }
                }

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                context.Response.Write(javaScriptSerializer.Serialize(data));
            }
            catch(Exception ex)
            {
                context.Response.Write(str.ToString());
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public class AData
        {
            public AData(string _City_Name, string _Airport_Name, string _Airport_Code, string _CityCode,string _CountryName,string _CountryCode,string _Order_Id)
            {
                City_Name = _City_Name;
                Airport_Name = _Airport_Name;
                Airport_Code = _Airport_Code;
                CityCode = _CityCode;
                Country_Name = _CountryName;
                Country_Code = _CountryCode;
                Order_Id = _Order_Id;
            }
            public AData(DataRow dr)
            {               
                City_Name = dr["City_Name"].ToString();
                Airport_Name = dr["Airport_Name"].ToString();
                Airport_Code = dr["Airport_Code"].ToString();
                CityCode = dr["City_Code"].ToString();
                Country_Name = dr["Country_Name"].ToString();
                Country_Code = dr["Country_Code"].ToString();
                Order_Id = dr["Order_Id"].ToString();
            }
            public AData(SqlDataReader dr)
            {
                City_Name = dr["City_Name"].ToString();
                Airport_Name = dr["Airport_Name"].ToString();
                Airport_Code = dr["Airport_Code"].ToString();
                CityCode = dr["City_Code"].ToString();
                Country_Name = dr["Country_Name"].ToString();
                Country_Code = dr["Country_Code"].ToString();
                Order_Id = dr["Order_Id"].ToString();
            }
            public string City_Name { set; get; }
            public string Airport_Name { set; get; }
            public string Airport_Code { set; get; }
            public string CityCode { set; get; }
            public string Country_Name { set; get; }
            public string Country_Code { set; get; }
            public string Order_Id { set; get; }
        }

    }
}