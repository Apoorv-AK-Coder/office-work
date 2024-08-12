using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class TableStructure
    {
        #region Create sector table
        public DataTable SectorDetailTable()
        {
            DataTable dt = new DataTable("SectorDetails");
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("BookingId", typeof(string));
            dt.Columns.Add("ProdId", typeof(string));
            dt.Columns.Add("SegId", typeof(string));
            dt.Columns.Add("FlightNo", typeof(string));
            dt.Columns.Add("FromDestination", typeof(string));
            dt.Columns.Add("FromDateTime", typeof(DateTime));
            dt.Columns.Add("FromTime", typeof(string));
            dt.Columns.Add("DTerminal", typeof(string));
            dt.Columns.Add("ToDestination", typeof(string));
            dt.Columns.Add("ToDateTime", typeof(DateTime));
            dt.Columns.Add("ToTime", typeof(string));
            dt.Columns.Add("ATerminal", typeof(string));
            dt.Columns.Add("CbnClass", typeof(string));
            dt.Columns.Add("AirPnr", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("OperatedBy", typeof(string));
            dt.Columns.Add("IsReturn", typeof(bool));
            dt.Columns.Add("ModifiedBy", typeof(int));
            dt.Columns.Add("ModifiedDate", typeof(DateTime));
            return dt;
        }
        public DataRow SectorDetailRow(DataRow dr, int Id, string BookingId, string Prodid, string SegId, string FlightNo
            , string FromDestination, DateTime FromDateTime, string FromTime, string dterminal, string ToDestination, DateTime ToDateTime, string ToTime, string aterminal
            , string secclass, string airpnr, string status, string cabinclass, string OperatedBy
            , bool TripType, int ModifiedBy)
        {
            dr["Id"] = Id;
            dr["BookingId"] = BookingId;
            dr["Prodid"] = Prodid;
            dr["SegId"] = SegId;
            dr["FlightNo"] = FlightNo;
            dr["FromDestination"] = FromDestination;
            dr["FromDateTime"] = FromDateTime;
            dr["FromTime"] = FromTime;
            dr["DTerminal"] = dterminal;
            dr["ToDestination"] = ToDestination;
            dr["ToDateTime"] = ToDateTime;
            dr["ToTime"] = ToTime;
            dr["ATerminal"] = aterminal;
            dr["CbnClass"] = cabinclass;
            dr["AirPnr"] = airpnr;
            dr["Status"] = status;
            dr["Class"] = secclass;
            dr["OperatedBy"] = OperatedBy;
            dr["IsReturn"] = TripType;
            dr["ModifiedBy"] = ModifiedBy;
            dr["ModifiedDate"] = DateTime.Now;
            return dr;
        }

        public DataTable PassengerDetails()
        {
            DataTable dt = new DataTable("Passengers");
            dt.Columns.Add("BookingId", typeof(string));
            dt.Columns.Add("ProdId", typeof(string));
            dt.Columns.Add("PaxId", typeof(string));
            dt.Columns.Add("PaxType", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("DOB", typeof(DateTime));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("Meal", typeof(string));
            dt.Columns.Add("Seat", typeof(string));
            dt.Columns.Add("TicketNo", typeof(string));
            dt.Columns.Add("ModifiedBy", typeof(int));
            dt.Columns.Add("ModifiedDate", typeof(DateTime));

            return dt;
        }

        public DataRow PassengerDetailRow(DataRow dr, int Id, string BookingId,
            string ProdId, string PaxId, string PaxType, string Title, string FirstName,
            string MiddleName, string LastName, DateTime DOB, string Gender, string Meal,
            string Seat, string TicketNo, int ModifiedBy)
        {
            //dr["Id"] = Id;
            dr["BookingId"] = BookingId;
            dr["ProdId"] = ProdId;
            dr["PaxId"] = PaxId;
            dr["PaxType"] = PaxType;
            dr["Title"] = Title;
            dr["FirstName"] = FirstName;
            dr["MiddleName"] = MiddleName;
            dr["LastName"] = LastName;
            dr["DOB"] = DOB;
            dr["Gender"] = Gender;
            dr["Meal"] = Meal;
            dr["Seat"] = Seat;
            dr["TicketNo"] = TicketNo;
            dr["ModifiedBy"] = ModifiedBy;
            dr["ModifiedDate"] = DateTime.Now;
            return dr;
        }


        #region Car

        public DataTable PassengerDetailsCar()
        {
            DataTable dt = new DataTable("Passengers");
            dt.Columns.Add("BookingId", typeof(string));
            dt.Columns.Add("ProdId", typeof(string));
            dt.Columns.Add("PaxId", typeof(string));
            dt.Columns.Add("PaxType", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("MiddleName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Gender", typeof(string));
            dt.Columns.Add("ModifiedBy", typeof(int));
            dt.Columns.Add("ModifiedDate", typeof(DateTime));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedDate", typeof(DateTime));

            return dt;
        }

        public DataRow PassengerDetailRowCar(DataRow dr, int Id, string BookingId,
            string ProdId, string PaxId, string PaxType, string Title, string FirstName,
            string MiddleName, string LastName, int Age, string Gender, int ModifiedBy)
        {
            //dr["Id"] = Id;
            dr["BookingId"] = BookingId;
            dr["ProdId"] = ProdId;
            dr["PaxId"] = PaxId;
            dr["PaxType"] = PaxType;
            dr["Title"] = Title;
            dr["FirstName"] = FirstName;
            dr["MiddleName"] = MiddleName;
            dr["LastName"] = LastName;
            dr["Age"] = Age;
            dr["Gender"] = Gender;
            dr["ModifiedBy"] = ModifiedBy;
            dr["ModifiedDate"] = DateTime.Now;
            dr["CreatedBy"] = ModifiedBy;
            dr["CreatedDate"] = DateTime.Now;
            return dr;
        }


        #endregion Car


        #region Amount Charge Details Make Table
        public DataTable AmountDataTable()
        {
            DataTable ChargeDetails = new DataTable();
            ChargeDetails.TableName = "AmountCharges";
            ChargeDetails.Columns.Add(new DataColumn("Id", typeof(int)));
            ChargeDetails.Columns.Add(new DataColumn("BookingId", typeof(string)));
            ChargeDetails.Columns.Add(new DataColumn("ProdId", typeof(string)));
            ChargeDetails.Columns.Add(new DataColumn("PaxType", typeof(string)));
            ChargeDetails.Columns.Add(new DataColumn("BaseFare", typeof(double)));
            ChargeDetails.Columns.Add(new DataColumn("Tax", typeof(double)));
            ChargeDetails.Columns.Add(new DataColumn("Markup", typeof(double)));
            ChargeDetails.Columns.Add(new DataColumn("Gross", typeof(double)));
            ChargeDetails.Columns.Add(new DataColumn("NoOfPax", typeof(int)));
            ChargeDetails.Columns.Add(new DataColumn("ModifiedBy", typeof(int)));
            ChargeDetails.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));

            return ChargeDetails;
        }
        public DataRow AmountDataRow(DataRow dr, int Id, string BookingId, string ProdId, string PaxType, double BaseFare, double Tax, double Markup, double Gross, int NoOfPax, DateTime ModifiedDate, int ModifiedBy)
        {
            dr["Id"] = Id;
            dr["BookingId"] = BookingId;
            dr["ProdId"] = ProdId;
            dr["PaxType"] = PaxType;
            dr["BaseFare"] = BaseFare;
            dr["Tax"] = Tax;
            dr["Markup"] = Markup;
            dr["Gross"] = Gross;
            dr["NoOfPax"] = NoOfPax;
            dr["ModifiedDate"] = ModifiedDate;
            dr["ModifiedBy"] = ModifiedBy;
            return dr;
        }
        #endregion


        #region Create charge Details table
        public DataTable ChgDtlDT()
        {
            DataTable ExtChgDtlDt = new DataTable();
            ExtChgDtlDt.TableName = "EtcChgDtl";
            ExtChgDtlDt.Columns.Add(new DataColumn("BookingId", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ProdId", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Type", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Units", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Nett", typeof(double)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Gross", typeof(double)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ModifiedBy", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Supplier", typeof(string)));
            return ExtChgDtlDt;


        }
        public DataRow ChargeDataRow(DataRow dr, string BookingID, string ProdId, string Type, int Units, double Nett, double Gross, int UserId, string Supplier)
        {
            dr["BookingId"] = BookingID;
            dr["ProdId"] = ProdId;
            dr["Type"] = Type;
            dr["Units"] = Units;
            dr["Nett"] = Nett;
            dr["Gross"] = Gross;
            dr["ModifiedDate"] = DateTime.Now;
            dr["ModifiedBy"] = UserId;
            dr["Supplier"] = Supplier;

            return dr;
        }
        #endregion

        #region Create Payment Mode table
        public DataTable PaymentModeDT()
        {
            DataTable ExtChgDtlDt = new DataTable();
            ExtChgDtlDt.TableName = "PayModeTable";
            ExtChgDtlDt.Columns.Add(new DataColumn("BookingId", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ProdId", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("PaymentMode", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("PaymentRefNo", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ProductType", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Gross", typeof(double)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Amount", typeof(double)));
            ExtChgDtlDt.Columns.Add(new DataColumn("CardType", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Remarks", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ModifiedBy", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Charges", typeof(double)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ChargesType", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("BankName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ChequeDarftNo", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("IssueBank", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("TransactionId", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("AuthorizationCode", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("TotalAmount", typeof(double)));
            return ExtChgDtlDt;


        }
        public DataRow PayModeDataRow(DataRow dr, string BookingID, string ProdId, string PaymentMode, string PaymentRefNo, string ProductType, double Gross, double Amount, int UserId, string CardType, string Remarks
            , double Charges, string ChargesType, string BankName, string ChequeDarftNo, string IssueBank, string TransactionId, string AuthorizationCode, double TotalAmount)
        {
            dr["BookingId"] = BookingID;
            dr["ProdId"] = ProdId;
            dr["PaymentMode"] = PaymentMode;
            dr["PaymentRefNo"] = PaymentRefNo;
            dr["ProductType"] = ProductType;
            dr["Gross"] = Gross;
            dr["Amount"] = Amount;
            dr["CardType"] = CardType;
            dr["Remarks"] = Remarks;
            dr["ModifiedBy"] = UserId;
            dr["ModifiedDate"] = DateTime.Now;


            dr["Charges"] = Charges;
            dr["ChargesType"] = ChargesType;
            dr["BankName"] = BankName;
            dr["ChequeDarftNo"] = ChequeDarftNo;
            dr["IssueBank"] = IssueBank;
            dr["TransactionId"] = TransactionId;
            dr["AuthorizationCode"] = AuthorizationCode;
            dr["TotalAmount"] = TotalAmount;



            return dr;
        }
        #endregion

        #region Create Payment Mode table
        public DataTable EmployeeDT()
        {
            // [EmpCode],[UserName],[Password],[Title],[FirstName],[MiddleName],[LastName],[NickName],[DOB],[Phone],[Mobile],[Email],[CompId],[DeptId]
            // ,[DesigId],[ValidateIP],[IsManager],[IsActive],[IsDeleted],[ModifiedDate],[ModifiedBy],[RoleId],[Email1]


            DataTable ExtChgDtlDt = new DataTable();
            ExtChgDtlDt.TableName = "EmpTable";
            ExtChgDtlDt.Columns.Add(new DataColumn("EmpCode", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("UserName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Password", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Title", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("MiddleName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("LastName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("NickName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("DOB", typeof(DateTime)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Phone", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Mobile", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Email", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("Email1", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("CompId", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("DesigId", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("RoleId", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ValidateIP", typeof(bool)));
            ExtChgDtlDt.Columns.Add(new DataColumn("CompId", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("CompId", typeof(int)));


            ExtChgDtlDt.Columns.Add(new DataColumn("ModifiedBy", typeof(int)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ModifiedDate", typeof(DateTime)));
            ExtChgDtlDt.Columns.Add(new DataColumn("BankName", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("ChequeDarftNo", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("IssueBank", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("TransactionId", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("AuthorizationCode", typeof(string)));
            ExtChgDtlDt.Columns.Add(new DataColumn("TotalAmount", typeof(double)));
            return ExtChgDtlDt;


        }
        public DataRow EmployeeDataRow(DataRow dr, string BookingID, string ProdId, string PaymentMode, string PaymentRefNo, string ProductType, double Gross, double Amount, int UserId, string CardType, string Remarks
            , double Charges, string ChargesType, string BankName, string ChequeDarftNo, string IssueBank, string TransactionId, string AuthorizationCode, double TotalAmount)
        {
            dr["BookingId"] = BookingID;
            dr["ProdId"] = ProdId;
            dr["PaymentMode"] = PaymentMode;
            dr["PaymentRefNo"] = PaymentRefNo;
            dr["ProductType"] = ProductType;
            dr["Gross"] = Gross;
            dr["Amount"] = Amount;
            dr["CardType"] = CardType;
            dr["Remarks"] = Remarks;
            dr["ModifiedBy"] = UserId;
            dr["ModifiedDate"] = DateTime.Now;


            dr["Charges"] = Charges;
            dr["ChargesType"] = ChargesType;
            dr["BankName"] = BankName;
            dr["ChequeDarftNo"] = ChequeDarftNo;
            dr["IssueBank"] = IssueBank;
            dr["TransactionId"] = TransactionId;
            dr["AuthorizationCode"] = AuthorizationCode;
            dr["TotalAmount"] = TotalAmount;



            return dr;
        }
        #endregion
        #endregion





    }
}
