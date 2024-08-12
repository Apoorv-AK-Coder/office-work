using TravelSite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TravelSite.Models
{
    public class UserAcess
    {
        public static DataTable IsAuthorizedUser(User ObjUserEL)
        {
            DataTable Dt = Global.ExecuteSPReturnDT(new object[] {"GetUserLoginDetails"
                                                    ,"@paramLoginID",ObjUserEL.LoginId
                                                    ,"@paramPassword",ObjUserEL.Password
                                                    ,"@paramIsActive",1
                                                    ,"@paramCounter",1                                                    
                 }, DataConnection.GetConnection());
            return Dt;
        }

        public static bool RegisterUser(User ObjUserEL)
        {
            bool Rval = Global.ExecuteNonQuery(new object[] {"GetUserLoginDetails"
                                                    ,"@paramLoginID",ObjUserEL.LoginId
                                                    ,"@paramPassword",ObjUserEL.Password
                                                    ,"@paramFirstName",ObjUserEL.First_Name
                                                    ,"@paramLastName",ObjUserEL.Last_Name
                                                    ,"@paramEncPassword",ObjUserEL.Enc_Password
                                                    ,"@paramMailID",ObjUserEL.MailId
                                                    ,"@paramMobileNo",ObjUserEL.MobileNo
                                                    ,"@paramPhoneNo",ObjUserEL.PhoneNo
                                                    ,"@paramFaxNo",ObjUserEL.FaxNo
                                                    ,"@paramAddress",ObjUserEL.Address
                                                    ,"@paramCity",ObjUserEL.City
                                                    ,"@paramState",ObjUserEL.State
                                                    ,"@paramCountry",ObjUserEL.Country
                                                    ,"@paramPinCode",ObjUserEL.PinCode
                                                    ,"@paramCompanyID",ObjUserEL.CompanyId
                                                    ,"@paramIsActive",1 // 
                                                    ,"@paramCounter",2                                                    
                 }, DataConnection.GetConnection());

            return Rval;
        } 

        public static bool UpdateUserPassword(User ObjUserEL)
        {
            bool Rval = Global.ExecuteNonQuery(new object[] {"GetUserLoginDetails"
                                                    ,"@paramLoginID",ObjUserEL.LoginId
                                                    ,"@paramPassword",ObjUserEL.Password                                             
                                                    ,"@paramEncPassword",ObjUserEL.Enc_Password                                                  
                                                    ,"@paramCounter",5                                                    
                 }, DataConnection.GetConnection());
            return Rval;
        }

        public static DataTable ViewBookingDetails(User ObjUserEL)
        {

            DataTable Dt = Global.ExecuteSPReturnDT(new object[] {"GET_ViewBookingDetails"
                                                    ,"@paramUserLoginId",ObjUserEL.LoginId
                                                    ,"@paramBookingType",ObjUserEL.BookingType
                                                    ,"@paramBookingByCompany",ObjUserEL.CompanyId                                                                                                      
                 }, DataConnection.GetConnection());
            return Dt;
        }

        public static bool UpdateUserDetails(User ObjUserEL)
        {
            bool Rval = Global.ExecuteNonQuery(new object[] {"GetUserLoginDetails"
                                                    ,"@paramLoginID",ObjUserEL.LoginId
                                                    ,"@paramPassword",ObjUserEL.Password
                                                    ,"@paramFirstName",ObjUserEL.First_Name
                                                    ,"@paramLastName",ObjUserEL.Last_Name
                                                    ,"@paramEncPassword",ObjUserEL.Enc_Password
                                                    ,"@paramMailID",ObjUserEL.MailId
                                                    ,"@paramMobileNo",ObjUserEL.MobileNo
                                                    ,"@paramPhoneNo",ObjUserEL.PhoneNo
                                                    ,"@paramFaxNo",ObjUserEL.FaxNo
                                                    ,"@paramAddress",ObjUserEL.Address
                                                    ,"@paramCity",ObjUserEL.City
                                                    ,"@paramState",ObjUserEL.State
                                                    ,"@paramCountry",ObjUserEL.Country
                                                    ,"@paramPinCode",ObjUserEL.PinCode
                                                    ,"@paramCompanyID",ObjUserEL.CompanyId
                                                    ,"@paramIsActive",1
                                                    ,"@paramCounter",4                                                   
                 }, DataConnection.GetConnection());
            return Rval;
        }
    }
}
