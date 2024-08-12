using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace TravelSite.Models
{
    public class DataAccessClass
    {
        public DataTable GetSectors(string BookingRef, string ProdBookingId, string Itinerary)
        {
            CreateDataTable objCreateDTbl = new CreateDataTable();
            using (DataTable dtItinerary = objCreateDTbl.CreateSectorDataTable())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(Itinerary);
                int count = 1;
                string JourneyType = string.Empty;
                string ValCarrier = xmlDoc.SelectSingleNode("/Itinerary/ValCarrier").InnerText;
                string LTD = xmlDoc.SelectSingleNode("/Itinerary/LastTicketingDate").InnerText;
                string Origin = xmlDoc.SelectSingleNode("/Itinerary/Sectors/Sector[1]/Departure/AirpCode").InnerText;
                string Destination = xmlDoc.SelectSingleNode("/Itinerary/Sectors/Sector[isReturn='false'][last()]/Arrival/AirpCode").InnerText;
                if (xmlDoc.SelectNodes("/Itinerary/Sectors/Sector[isReturn='true']").Count > 0)
                {
                    JourneyType = "R";
                }
                else
                {
                    JourneyType = "O";
                }
                foreach (XmlNode Sector in xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Sectors").ChildNodes)
                {
                    string From = Sector.SelectSingleNode("Departure/AirpCode").InnerText;
                    string date = Sector.SelectSingleNode("Departure/Date").InnerText;
                    string DepartTime = Sector.SelectSingleNode("Departure/Time").InnerText;
                    string FTerminal = Sector.SelectSingleNode("Departure/Terminal").InnerText;
                    string To = Sector.SelectSingleNode("Arrival/AirpCode").InnerText;
                    string ArrivalDate = Sector.SelectSingleNode("Arrival/Date").InnerText;
                    string ArrivalTime = Sector.SelectSingleNode("Arrival/Time").InnerText;
                    string TTerminal = Sector.SelectSingleNode("Arrival/Terminal").InnerText;
                    string AirCode = Sector.SelectSingleNode("AirV").InnerText;
                    string FltNumber = Sector.SelectSingleNode("FltNum").InnerText;
                    string Class = Sector.SelectSingleNode("Class").InnerText;
                    string Status = Sector.SelectSingleNode("Status").InnerText;
                    if (!string.IsNullOrEmpty(FTerminal))
                    {
                        FTerminal = "D - " + FTerminal;
                    }
                    if (!string.IsNullOrEmpty(TTerminal))
                    {
                        if (string.IsNullOrEmpty(FTerminal))
                        {
                            TTerminal = "A - " + TTerminal;
                        }
                        else
                        {
                            TTerminal = " | A - " + TTerminal;
                        }
                    }
                    dtItinerary.Rows.Add(objCreateDTbl.CreateSectorDtaRow(dtItinerary.NewRow(), BookingRef,
                            ProdBookingId, AirCode.Trim().ToUpper(), From.Trim().ToUpper(),
                            Convert.ToDateTime(date.Trim() + " " + DepartTime.Trim()),
                            To.Trim().ToUpper(), Convert.ToDateTime(ArrivalDate.Trim() + " " + ArrivalTime.Trim()),
                            FltNumber.Trim(), Class.Trim(), Status.Trim(), "", "", "", "", FTerminal + TTerminal, (count).ToString(), "",
                            JourneyType, LTD, Origin, Destination, ValCarrier));
                    count++;
                }
                return dtItinerary;
            }
        }

        public DataTable GetAmountCharges(string BookingRef, string ProdBookingId, string Itinerary)
        {
            CreateDataTable objCreateDTbl = new CreateDataTable();
            using (DataTable dtAmountCharges = objCreateDTbl.CreateAmountChargesDataTable())
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(Itinerary);
                #region Base fares and taxes

                int totPax = 0;
                double baseFare = 0, tax = 0, markup = 0, commission = 0;
                if (xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Adult") != null)
                {
                    baseFare = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Adult/AdtBFare").InnerText);
                    tax = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Adult/AdTax").InnerText);
                    markup = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Adult/markUp").InnerText);
                    commission = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Adult/Commission").InnerText);
                    int noOfPax = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Adult/NoAdult").InnerText);
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                        BookingRef, ProdBookingId, "FARE", "ADT", (baseFare * noOfPax), (baseFare * noOfPax),
                        "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                           BookingRef, ProdBookingId, "TAX", "ADT", (tax * noOfPax), (tax * noOfPax),
                           "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                            BookingRef, ProdBookingId, "Markup", "ADT", (markup * noOfPax), (markup * noOfPax),
                            "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                            BookingRef, ProdBookingId, "Commission", "ADT", (commission * noOfPax), (commission * noOfPax),
                            "OK", "", "", DateTime.Now));
                    totPax += noOfPax;
                }
                if (xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Child") != null)
                {
                    baseFare = 0; tax = 0; markup = 0; commission = 0;
                    baseFare = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Child/ChdBFare").InnerText);
                    tax = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Child/CHTax").InnerText);
                    markup = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Child/markUp").InnerText);
                    commission = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Child/Commission").InnerText);
                    int noOfPax = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Child/NoChild").InnerText);
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                        BookingRef, ProdBookingId, "FARE", "CHD", (baseFare * noOfPax), (baseFare * noOfPax),
                        "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                           BookingRef, ProdBookingId, "TAX", "CHD", (tax * noOfPax), (tax * noOfPax),
                           "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                            BookingRef, ProdBookingId, "Markup", "CHD", (markup * noOfPax), (markup * noOfPax),
                            "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                            BookingRef, ProdBookingId, "Commission", "CHD", (commission * noOfPax), (commission * noOfPax),
                            "OK", "", "", DateTime.Now));
                    totPax += noOfPax;
                }
                if (xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Infant") != null)
                {
                    baseFare = 0; tax = 0; markup = 0; commission = 0;
                    baseFare = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Infant/InfBFare").InnerText);
                    tax = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Infant/InTax").InnerText);
                    markup = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Infant/markUp").InnerText);
                    commission = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Infant/Commission").InnerText);
                    int noOfPax = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Infant/NoInfant").InnerText);
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                        BookingRef, ProdBookingId, "FARE", "INF", (baseFare * noOfPax), (baseFare * noOfPax),
                        "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                           BookingRef, ProdBookingId, "TAX", "INF", (tax * noOfPax), (tax * noOfPax),
                           "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                            BookingRef, ProdBookingId, "Markup", "INF", (markup * noOfPax), (markup * noOfPax),
                            "OK", "", "", DateTime.Now));
                    dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                            BookingRef, ProdBookingId, "Commission", "INF", (commission * noOfPax), (commission * noOfPax),
                            "OK", "", "", DateTime.Now));
                    totPax += noOfPax;
                }
                #endregion
                if (xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Safi") != null)
                {
                    double SafiCharge = Convert.ToDouble(xmlDoc.DocumentElement.SelectSingleNode("/Itinerary/Safi").InnerText);
                    #region add Safi charges
                    try
                    {
                        dtAmountCharges.Rows.Add(objCreateDTbl.CreateAmountChargesDtaRow(dtAmountCharges.NewRow(),
                                            BookingRef, ProdBookingId, "SAFI", "NA", SafiCharge, SafiCharge,
                                            "OK", "SAFI", "", DateTime.Now));
                    }
                    catch { }
                    #endregion
                }

                return dtAmountCharges;
            }
        }

        public bool InsertFeedBackEnquiry(string name, string phone, string email, string Message, string Source, string Destination, DateTime depDate, DateTime retDate, string Class, string CallOpt, string BookingRef)
        {

            bool Rval = ExecuteNonQuery(new object[] {"InsertFareQuotes"
                                                    ,"@paramFirstName",name
                                                    ,"@paramDepartCityCode",Source
                                                    ,"@paramDestCityCode",Destination
                                                    ,"@paramPhone",phone  
                                                    ,"@paramEMail",email  
                                                    ,"@paramFeedBackType","Enquiry"                                                                                                
                                                    ,"@paramRefCode",BookingRef                                                                                                                                              
                                                    ,"@paramCompany",CompanyCredentials.CompanyId 
                                                    ,"@paramCallRemarks",Message
                                                    ,"@paramClass",Class
                                                    //,"@paramdate",DateTime.Now// depDate.ToShortDateString()
                                                    //,"@paramReturnDate",DateTime.Now//retDate.ToShortDateString()
                                                    //,"@paramDestCityCode",@paramDestCityCode
                                                    
                 });

            return Rval;
        }

        public static DataSet ExecuteSPReturnDS(object[] dbCallIngrediats, SqlConnection con)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = con)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(dbCallIngrediats[0].ToString(), connection);
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

        public DataTable GetFlightDistinationCheapFare(int counter)
        {
            try
            {
                using (SqlConnection _objConnection = DataConnection.GetOffLineFareConnection())
                {
                    using (SqlCommand _objCommand = new SqlCommand())
                    {
                        using (SqlDataAdapter adpt = new SqlDataAdapter(_objCommand))
                        {
                            using (DataSet dsrec = new DataSet())
                            {
                                _objCommand.CommandType = CommandType.StoredProcedure;
                                _objCommand.CommandText = "Get_CheapFareForDistination";
                                _objCommand.Connection = _objConnection;
                                _objCommand.Parameters.Add("@Counter", SqlDbType.Int).Value = counter;
                                _objCommand.CommandTimeout = 120;

                                adpt.Fill(dsrec);
                                return dsrec.Tables[0];
                            }
                        }
                    }
                }

            }
            catch
            {
                return null;
            }
        }

        public DataTable GetMetatag(string PageUrl)
        {
            try
            {
                SqlParameter[] Param = new SqlParameter[2];

                if (!string.IsNullOrEmpty(PageUrl))
                {
                    Param[0] = new SqlParameter("@PageUrl", SqlDbType.VarChar, 500);
                    Param[0].Value = PageUrl;
                }
                Param[1] = new SqlParameter("@CompanyId", SqlDbType.VarChar, 50);
                Param[1].Value = CompanyCredentials.CompanyId;

                using (SqlConnection connection = DataConnection.GetMlWebsite())
                {
                    DataSet ds = null;// SqlHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "Usp_GetMetaTags", Param);
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

      

        public static bool ExecuteNonQuery(object[] dbCallIngrediats)
        {

            int Rval = 0;
            using (SqlConnection con = DataConnection.GetOffLineFareConnection())
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

    }
}