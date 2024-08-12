using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class SaveInDB
    {
        public SaveInDB()
        {

        }
        public bool SaveBookingInDB(string Guid)
        {
            string id = string.Empty;
            try
            {
                SearchDetails SearchDetails = SearchDetails.Current(Guid);
                GetSetDatabase GetSetDatabase = new GetSetDatabase();
                SearchDetails.BookingID = GetSetDatabase.GenerateIDs("FS");
                id = SearchDetails.BookingID;
                SearchDetails.BookingStatus = "Incomplete";

                DataTable dtSect = GetSectors(ref SearchDetails);
                string sec = DataTableToJSONWithJSONNet(dtSect);
                DataTable dtCharges = GetAmountCharges(ref SearchDetails);
                string charr = DataTableToJSONWithJSONNet(dtCharges);
                DataTable dtPaxes = GetPassenger(ref SearchDetails);
                string paxes = DataTableToJSONWithJSONNet(dtPaxes);

                return GetSetDatabase.SET_FlightDetails(SearchDetails.BookingID, SearchDetails.BookingID, "ARF",
                                             SearchDetails.Itinerary.Currency, CompCredentials.CompanyId, SearchDetails.BookingStatus,
                                             ("true"), SearchDetails.ProdID, SearchDetails.Itinerary.Provider,
                                             SearchDetails.AgentId, "DICT", DateTime.Now.ToString(), SearchDetails.BookingStatus, "",
                                             SearchDetails.Itinerary.TotalPrice.ToString(), "", SearchDetails.HapID,
                                             "ARF", "", "", SearchDetails.Itinerary.Provider, "",
                                             SearchDetails.FlightSearchDetails.segments.Count == 1 ? "OneWay" : "Return",
                                             SearchDetails.Itinerary.LastTicketingDate, SearchDetails.Itinerary.Sectors[0].Departure.AirportCode,
                                             SearchDetails.FlightSearchDetails.segments[0].destination, "",
                                             SearchDetails.Itinerary.Sectors[0].CabinClass.Name, "", "1", SearchDetails.PhoneNo,
                                             SearchDetails.MobileNo,"", SearchDetails.EmailID, "", "", "", "", "", "Delivery", "",
                                             dtSect, dtCharges, dtPaxes); 
                
            }
            catch (Exception ex)
            {
                ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Errors/" + Guid + " - " + id + ".txt"), Convert.ToString(ex.StackTrace + ex.Source));
                return false;
            }
        }

        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }

        #region Create Suppliment charges DataTable

        public DataTable CreateAmountChargesDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "AmountChargesTypes";
            dt.Columns.Add("BOK_MST_Booking_ID", typeof(String));
            dt.Columns.Add("BOK_DTL_Prod_Booking_ID", typeof(String));
            dt.Columns.Add("AMT_CHG_MST_Charge_ID", typeof(String));
            dt.Columns.Add("AMT_CHG_DTL_Charges_For", typeof(String));
            dt.Columns.Add("AMT_CHG_DTL_Cost_Price", typeof(double));
            dt.Columns.Add("AMT_CHG_DTL_Sell_Price", typeof(double));
            dt.Columns.Add("AMT_CHG_DTL_Charges_Status", typeof(String));
            dt.Columns.Add("AMT_CHG_DTL_Supplier_ID", typeof(String));
            dt.Columns.Add("AMT_CHG_DTL_Charges_Remarks", typeof(String));
            dt.Columns.Add("AMT_CHG_DTL_Charges_Date", typeof(DateTime));
            //dt.Columns.Add("AMT_CHG_DTL_ModifiedBy", typeof(String));
            //dt.Columns.Add("AMT_CHG_DTL_ModifiedDate", typeof(DateTime));
            return dt;
        }

        public DataTable GetAmountCharges(ref SearchDetails SearchDetails)
        {
            DataTable dt = CreateAmountChargesDataTable();
            string ProdID = SearchDetails.ProdID;
           
            DataRow dr = null;

            #region Add row For Adult
            if (SearchDetails.Itinerary.AdultInfo.NoAdult > 0)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "FARE";
                dr["AMT_CHG_DTL_Charges_For"] = "ADT";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.AdultInfo.AdtBFare;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.AdultInfo.AdtBFare;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "TAX";
                dr["AMT_CHG_DTL_Charges_For"] = "ADT";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.AdultInfo.AdTax;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.AdultInfo.AdTax;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Markup";
                dr["AMT_CHG_DTL_Charges_For"] = "ADT";
                dr["AMT_CHG_DTL_Cost_Price"] = 0;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.AdultInfo.MarkUp;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Commission";
                dr["AMT_CHG_DTL_Charges_For"] = "ADT";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.AdultInfo.Commission;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.AdultInfo.Commission;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
            }
            #endregion
            #region Add row For Child
            if (SearchDetails.Itinerary.ChildInfo.NoChild > 0)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "FARE";
                dr["AMT_CHG_DTL_Charges_For"] = "CHD";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.ChildInfo.ChdBFare;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.ChildInfo.ChdBFare;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "TAX";
                dr["AMT_CHG_DTL_Charges_For"] = "CHD";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.ChildInfo.CHTax;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.ChildInfo.CHTax;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Markup";
                dr["AMT_CHG_DTL_Charges_For"] = "CHD";
                dr["AMT_CHG_DTL_Cost_Price"] = 0;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.ChildInfo.MarkUp;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Commission";
                dr["AMT_CHG_DTL_Charges_For"] = "CHD";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.ChildInfo.Commission;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.ChildInfo.Commission;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
            }
            #endregion
            #region Add row For Infant
            if (SearchDetails.Itinerary.InfantInfo.NoInfant > 0)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "FARE";
                dr["AMT_CHG_DTL_Charges_For"] = "INF";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.InfantInfo.InfBFare;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfo.InfBFare;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "TAX";
                dr["AMT_CHG_DTL_Charges_For"] = "INF";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.InfantInfo.InTax;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfo.InTax;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Markup";
                dr["AMT_CHG_DTL_Charges_For"] = "INF";
                dr["AMT_CHG_DTL_Cost_Price"] = 0;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfo.MarkUp;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Commission";
                dr["AMT_CHG_DTL_Charges_For"] = "INF";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.InfantInfo.Commission;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfo.Commission;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
            }
            #endregion
            #region Add row For Infant with seat
            if (SearchDetails.Itinerary.InfantInfoWithSeat.NoInfant > 0)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "FARE";
                dr["AMT_CHG_DTL_Charges_For"] = "INS";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.InfBFare;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.InfBFare;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "TAX";
                dr["AMT_CHG_DTL_Charges_For"] = "INS";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.InTax;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.InTax;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Markup";
                dr["AMT_CHG_DTL_Charges_For"] = "INS";
                dr["AMT_CHG_DTL_Cost_Price"] = 0;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.MarkUp;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "Commission";
                dr["AMT_CHG_DTL_Charges_For"] = "INS";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.Commission;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.InfantInfoWithSeat.Commission;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
            }
            #endregion
            #region Add row For Safi
            if (SearchDetails.Itinerary.Safi > 0)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["AMT_CHG_MST_Charge_ID"] = "SAFI";
                dr["AMT_CHG_DTL_Charges_For"] = "ALL";
                dr["AMT_CHG_DTL_Cost_Price"] = SearchDetails.Itinerary.Safi;
                dr["AMT_CHG_DTL_Sell_Price"] = SearchDetails.Itinerary.Safi;
                dr["AMT_CHG_DTL_Charges_Status"] = "OK";
                dr["AMT_CHG_DTL_Supplier_ID"] = "";
                dr["AMT_CHG_DTL_Charges_Remarks"] = "";
                dr["AMT_CHG_DTL_Charges_Date"] = DateTime.Now;
                //dr["AMT_CHG_DTL_ModifiedBy"] = "";
                //dr["AMT_CHG_DTL_ModifiedDate"] = DateTime.Now;
                dt.Rows.Add(dr);
            }
            #endregion
            return dt;
        }

        #endregion

        #region Create PaxDetail DataTable

        public DataTable CreatePaxDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "PassengersTypes";
            dt.Columns.Add("BOK_MST_Booking_ID", typeof(String));
            dt.Columns.Add("BOK_DTL_Prod_Booking_ID", typeof(String));
            dt.Columns.Add("PAX_DTL_Pax_ID", typeof(String));
            dt.Columns.Add("PAX_DTL_Title", typeof(String));
            dt.Columns.Add("PAX_DTL_Pax_First_Name", typeof(String));
            dt.Columns.Add("PAX_DTL_Pax_Middle_Name", typeof(String));
            dt.Columns.Add("PAX_DTL_Pax_Last_Name", typeof(String));
            dt.Columns.Add("PAX_DTL_Frequent_Flyer_No", typeof(String));
            dt.Columns.Add("PAX_DTL_Passport_No", typeof(String));
            dt.Columns.Add("PAX_DTL_Nationality", typeof(String));
            dt.Columns.Add("PAX_DTL_Expiry_Date", typeof(DateTime));
            dt.Columns.Add("PAX_DTL_Place_of_Issue", typeof(String));
            dt.Columns.Add("PAX_DTL_Place_of_Birth", typeof(String));
            dt.Columns.Add("PAX_DTL_Pax_DOB", typeof(DateTime));
            dt.Columns.Add("PAX_DTL_Pax_Gender", typeof(String));
            dt.Columns.Add("PAX_DTL_TicketNo", typeof(String));
            dt.Columns.Add("PAX_DTL_Seat", typeof(String));
            dt.Columns.Add("PAX_DTL_Meal", typeof(String));
            return dt;
        }

        public DataTable GetPassenger(ref SearchDetails SearchDetails)
        {
            DataTable dt = CreatePaxDataTable();
            DataRow dr = null;

            int ctr = 1;
            foreach (Pax Pax in SearchDetails.Passenger)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = SearchDetails.ProdID;
                dr["PAX_DTL_Pax_ID"] = (ctr++).ToString();
                dr["PAX_DTL_Title"] = Pax.Title;
                dr["PAX_DTL_Pax_First_Name"] = Pax.FirstName;
                dr["PAX_DTL_Pax_Middle_Name"] = "";
                dr["PAX_DTL_Pax_Last_Name"] = Pax.LastName;
                dr["PAX_DTL_Frequent_Flyer_No"] = "";
                dr["PAX_DTL_Passport_No"] = "";
                dr["PAX_DTL_Nationality"] = "";
                dr["PAX_DTL_Expiry_Date"] = Convert.ToDateTime("01-01-1900");
                dr["PAX_DTL_Place_of_Issue"] = "";
                dr["PAX_DTL_Place_of_Birth"] = "";
                dr["PAX_DTL_Pax_DOB"] = Pax.DOB;                
                dr["PAX_DTL_Pax_Gender"] = Pax.Gender;
                dr["PAX_DTL_TicketNo"] = "";
                dr["PAX_DTL_Seat"] = "";
                dr["PAX_DTL_Meal"] = "";
                dt.Rows.Add(dr);
            }

            return dt;
        }

        #endregion

        #region Create SectorDetail DataTable

        public DataTable CreateSectorDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "SectorTypes";
            dt.Columns.Add("BOK_MST_Booking_ID", typeof(String));
            dt.Columns.Add("BOK_DTL_Prod_Booking_ID", typeof(String));
            dt.Columns.Add("SEC_DTL_Carier_Name", typeof(String));
            dt.Columns.Add("SEC_DTL_From_Destination", typeof(String));
            dt.Columns.Add("SEC_DTL_From_Date_Time", typeof(DateTime));
            dt.Columns.Add("SEC_DTL_To_Destination", typeof(String));
            dt.Columns.Add("SEC_DTL_To_Date_Time", typeof(DateTime));
            dt.Columns.Add("SEC_DTL_Flight_No", typeof(String));
            dt.Columns.Add("SEC_DTL_Class", typeof(String));
            dt.Columns.Add("SEC_DTL_Status", typeof(String));
            dt.Columns.Add("SEC_DTL_Fare_Basis", typeof(String));
            dt.Columns.Add("SEC_DTL_Not_Valid_Befor", typeof(String));
            dt.Columns.Add("SEC_DTL_Not_Valid_After", typeof(String));
            dt.Columns.Add("SEC_DTL_Baggage_Allownce", typeof(String));
            dt.Columns.Add("SEC_DTL_Airport_Terminal", typeof(String));
            dt.Columns.Add("SEC_DTL_Seg_ID", typeof(String));
            dt.Columns.Add("SEC_DTL_Seg_Remarks", typeof(String));
            dt.Columns.Add("SEC_DTL_Actual_Time", typeof(String));
            dt.Columns.Add("SEC_DTL_Elapsed_Time", typeof(String));
            dt.Columns.Add("SEC_DTL_StopOver", typeof(String));
            dt.Columns.Add("SEC_DTL_TechStopOver", typeof(String));
            dt.Columns.Add("SEC_DTL_EquipType", typeof(String));
            dt.Columns.Add("SEC_DTL_isReturn", typeof(bool));
            dt.Columns.Add("SEC_DTL_OperatedBy", typeof(String));
            dt.Columns.Add("SEC_DTL_CabinClass", typeof(String));            

            return dt;
        }

        public DataTable GetSectors(ref SearchDetails SearchDetails)
        {
            DataTable dt = CreateSectorDataTable();
            string ProdID = SearchDetails.ProdID;
            int ctr = 1;
            DataRow dr = null;
            foreach (Sector Its in SearchDetails.Itinerary.Sectors)
            {
                dr = dt.NewRow();
                dr["BOK_MST_Booking_ID"] = SearchDetails.BookingID;
                dr["BOK_DTL_Prod_Booking_ID"] = ProdID;
                dr["SEC_DTL_Carier_Name"] = Its.AirV;
                dr["SEC_DTL_From_Destination"] = Its.Departure.AirportCode;
                dr["SEC_DTL_From_Date_Time"] = string.IsNullOrEmpty(Its.Departure.Date) ? Convert.ToDateTime("01-01-1900") : Convert.ToDateTime(Its.Departure.Date + " " + Its.Departure.Time);
                dr["SEC_DTL_To_Destination"] = Its.Arrival.AirportCode;
                dr["SEC_DTL_To_Date_Time"] = string.IsNullOrEmpty(Its.Arrival.Date) ? Convert.ToDateTime("01-01-1900") : Convert.ToDateTime(Its.Arrival.Date + " " + Its.Arrival.Time);
                dr["SEC_DTL_Flight_No"] = Its.FltNum;
                dr["SEC_DTL_Class"] = Its.Class;
                dr["SEC_DTL_Status"] = Its.Status;
                dr["SEC_DTL_Fare_Basis"] = "";
                dr["SEC_DTL_Not_Valid_Befor"] = "";
                dr["SEC_DTL_Not_Valid_After"] = "";
                dr["SEC_DTL_Baggage_Allownce"] = Its.BaggageInfo;
                dr["SEC_DTL_Airport_Terminal"] = Its.Departure.Terminal;
                //dr["SEC_DTL_Airport_Terminal_To"] = Its.Arrival.Terminal;
                dr["SEC_DTL_Seg_ID"] = (ctr++).ToString();
                dr["SEC_DTL_Seg_Remarks"] = "";
                dr["SEC_DTL_isReturn"] = Its.IsReturn;

                dr["SEC_DTL_Actual_Time"] = Its.ActualTime;
                dr["SEC_DTL_Elapsed_Time"] = Its.ElapsedTime;
                dr["SEC_DTL_StopOver"] = Its.TechStopOver;
                dr["SEC_DTL_TechStopOver"] = Its.TechStopOver;
                dr["SEC_DTL_EquipType"] = Its.EquipType;
                dr["SEC_DTL_OperatedBy"] = Its.OptrCarrier;
                dr["SEC_DTL_CabinClass"] = Its.CabinClass;


                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        public bool SavePaymentDetails(SearchDetails _objSearch)
        {
            Random rnd = new Random();
            string TransNo = rnd.Next(500).ToString();
            DatabaseAccess _objDB = new DatabaseAccess();
            return insertOnlinePaymentDetails(_objSearch.BookingID, _objSearch.ProdID, TransNo, _objSearch.Cvv, _objSearch.Cardnumber, _objSearch.CardHolderName,
                        _objSearch.Expirydate, "", "",  _objSearch.Cardtype, _objSearch.BillingCountry,_objSearch.State, _objSearch.City, _objSearch.PostCode,
                        _objSearch.Address1, _objSearch.CardCharge, "A");
        }
        public bool insertOnlinePaymentDetails(string BookingID, string ProdID, string TrnsNO, string TrnsCAVV, string CRDCardNo, string CRDHolderName, string CRDExpDate,
           string CRDValidFrom, string CRDIssueNo, string CRDCardType, string CRDCountry,
           string CRDCoutyState, string CRDCity, string CRDPostCode, string CRDAddress, double CRDCardCharges,
           string CRDChargesType)
        {
            try
            {
                string _CommandText = string.Empty;
                SqlParameter[] param = new SqlParameter[39];
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    _CommandText = "Usp_CardDetail";

                    param[0] = new SqlParameter("@BookingId", SqlDbType.NVarChar, (50));
                    param[0].Value = BookingID;

                    if (!string.IsNullOrEmpty(ProdID))
                    {
                        param[1] = new SqlParameter("@ProdId", SqlDbType.Int);
                        param[1].Value = ProdID;
                    }

                    param[2] = new SqlParameter("@TransactionNo", SqlDbType.NVarChar, (50));
                    param[2].Value = TrnsNO;

                    if (!string.IsNullOrEmpty(CRDCardNo))
                    {
                        param[3] = new SqlParameter("@CardNo", SqlDbType.NVarChar, (50));
                        param[3].Value = CRDCardNo;
                    }
                    if (!string.IsNullOrEmpty(CRDHolderName))
                    {
                        param[4] = new SqlParameter("@HolderName", SqlDbType.NVarChar, (100));
                        param[4].Value = CRDHolderName;
                    }                      
                    if (!string.IsNullOrEmpty(TrnsCAVV))
                    {
                        param[5] = new SqlParameter("@CVV", SqlDbType.NVarChar, (50));
                        param[5].Value = TrnsCAVV;
                    }
                    
                    if (!string.IsNullOrEmpty(CRDExpDate))
                    {
                        param[6] = new SqlParameter("@ExpDate", SqlDbType.NVarChar, (50));
                        param[6].Value = CRDExpDate;
                    }
                    if (!string.IsNullOrEmpty(CRDValidFrom))
                    {
                        param[7] = new SqlParameter("@ValidFrom", SqlDbType.NVarChar, (50));
                        param[7].Value = CRDValidFrom;
                    }
                    if (!string.IsNullOrEmpty(CRDIssueNo))
                    {
                        param[8] = new SqlParameter("@IssueNo", SqlDbType.NVarChar, (100));
                        param[8].Value = CRDIssueNo;
                    }
                    
                    if (!string.IsNullOrEmpty(CRDCardType))
                    {
                        param[9] = new SqlParameter("@CardType", SqlDbType.NVarChar, (200));
                        param[9].Value = CRDCardType;
                    }
                    if (!string.IsNullOrEmpty(CRDCountry))
                    {
                        param[10] = new SqlParameter("@Country", SqlDbType.NVarChar, (200));
                        param[10].Value = CRDCountry;
                    }
                    if (!string.IsNullOrEmpty(CRDCoutyState))
                    {
                        param[11] = new SqlParameter("@State", SqlDbType.NVarChar, (200));
                        param[11].Value = CRDCoutyState;
                    }
                    if (!string.IsNullOrEmpty(CRDCity))
                    {
                        param[12] = new SqlParameter("@City", SqlDbType.NVarChar, (200));
                        param[12].Value = CRDCity;
                    }
                    if (!string.IsNullOrEmpty(CRDPostCode))
                    {
                        param[13] = new SqlParameter("@PostCode", SqlDbType.NVarChar, (50));
                        param[13].Value = CRDPostCode;
                    }
                    if (!string.IsNullOrEmpty(CRDAddress))
                    {
                        param[14] = new SqlParameter("@Address", SqlDbType.NVarChar, (1000));
                        param[14].Value = CRDAddress;
                    }
                    if (CRDCardCharges > 0)
                    {
                        param[15] = new SqlParameter("@CardCharges", SqlDbType.Money);
                        param[15].Value = CRDCardCharges;
                    }
                    if (!string.IsNullOrEmpty(CRDChargesType))
                    {
                        param[16] = new SqlParameter("@ChargesType", SqlDbType.Char, (4));
                        param[16].Value = CRDChargesType;
                    }
                    param[17] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[17].Value = 2;

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                    if (count > 0)
                        return true;
                    else
                        return false;
                    
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }


       

        public bool SaveOfflineBookingInDB(DataTable dtSect, DataTable dtCharges, DataTable dtPaxes, string BookingStatus, string Currency, string CompanyID,
            string CabinClass, string BookingBy, String BookingRemarks, string destination)
        {
            string id = string.Empty;
            try
            {

                GetSetDatabase GetSetDatabase = new GetSetDatabase();
                string BookingID = GetSetDatabase.GenerateIDs("XP");
                string productId = "001";
                double TotalCost = 0;
                #region Set UP Booking Ref and Product Id
                foreach (DataRow dr in dtSect.Rows)
                {
                    dr["BOK_MST_Booking_ID"] = BookingID;
                    dr["BOK_DTL_Prod_Booking_ID"] = productId;
                }
                foreach (DataRow dr in dtCharges.Rows)
                {

                    dr["BOK_MST_Booking_ID"] = BookingID;
                    dr["BOK_DTL_Prod_Booking_ID"] = productId;
                }
                foreach (DataRow dr in dtPaxes.Rows)
                {
                    dr["BOK_MST_Booking_ID"] = BookingID;
                    dr["BOK_DTL_Prod_Booking_ID"] = productId;

                }

                #endregion


                if (GetSetDatabase.SET_FlightDetails(BookingID, BookingID, "ARF",
                                           Currency, CompanyID, BookingStatus,
                                          "true", productId, "",
                                           BookingBy, "INTR", DateTime.Now.ToString(), BookingStatus, BookingRemarks,
                                           TotalCost.ToString(), "", "",
                                           "ARF", "", BookingBy, "", "",
                                            "Return",
                                           "", dtSect.Rows[0]["SEC_DTL_From_Destination"].ToString(),
                                           destination, "",
                                           CabinClass, BookingBy, "1", "",
                                           "", "", "", "", "", "", "", "", "Delivery", "",
                                           dtSect, dtCharges, dtPaxes))
                { return true; }
                else { return false; }

            }
            catch (Exception ex)
            {


                return false;
            }
        }

    }
}