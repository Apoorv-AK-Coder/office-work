using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace TravelSite.Models
{
    public class UserData
    {
        public bool IsUserAuthorized(User ObjUser)
        {
            bool Rval = false;
            if (ObjUser != null)
            {
                DataTable dt = Global.ExecuteSPReturnDT(new object[] {"GetUserLoginDetails"
                                                    ,"@paramLoginID",ObjUser.LoginId
                                                    ,"@paramPassword",ObjUser.Password
                                                    ,"@paramIsActive",ObjUser.Status
                                                    ,"@paramCounter",1                                                    
                 }, DataConnection.GetConnection());

                if (dt != null && dt.Rows.Count > 0)
                {
                    string EncPassword = dt.Rows[0]["Password"].ToString();
                    if (EncPassword == ObjUser.Password)
                    {
                        HttpContext.Current.Session["UserDetail"] = dt;
                        Rval = true;
                    }
                    else
                        Rval = false;
                }
            }
            return Rval;
        }

        public DataTable UserCampaignAuthorized(User ObjUser, int Counter)
        {
            DataTable dt = new DataTable();
            if (ObjUser != null)
            {
                dt = Global.ExecuteSPReturnDT(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.LoginId                                                                                                       
                                                    ,"@Counter",Counter
                 }, DataConnection.GetConnectionPoints());
            }
            return dt;
        }

        public DataTable UserAuthorized(User ObjUser, int Counter)
        {
            DataTable dt = new DataTable();
            if (ObjUser != null)
            {
                dt = Global.ExecuteSPReturnDT(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.LoginId
                                                    ,"@Usr_Password",ObjUser.Password                                                    
                                                    ,"@Counter",Counter
                 }, DataConnection.GetConnectionPoints());
            }
            return dt;
        }
        public DataTable UserAuthorized1(User ObjUser)
        {
            DataTable dt = new DataTable();
            if (ObjUser != null)
            {
                dt = Global.ExecuteSPReturnDT(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.LoginId
                                                    ,"@Usr_Password",ObjUser.Password 
                                                    ,"@Usr_id",ObjUser.UsrId
                                                    ,"@Counter",9
                 }, DataConnection.GetConnectionPoints());
            }
            return dt;
        }
        public int RegisterUser(User ObjUser)
        {
            int Rval = 0;
            if (ObjUser != null)
            {
                try
                {
                    string _CommandText = string.Empty;
                    SqlParameter[] param = new SqlParameter[30];
                    using (SqlConnection connection = DataConnection.GetConnectionPoints())
                    {
                        _CommandText = "Usp_UserDetails";
                        if (!string.IsNullOrEmpty(ObjUser.First_Name))
                        {
                            param[0] = new SqlParameter("@Usr_FName", SqlDbType.VarChar, (50));
                            param[0].Value = ObjUser.First_Name;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.MailId))
                        {
                            param[1] = new SqlParameter("@Usr_EMail", SqlDbType.VarChar, (100));
                            param[1].Value = ObjUser.MailId;
                        }
                        if (!string.IsNullOrEmpty(ObjUser.Password))
                        {
                            param[2] = new SqlParameter("@Usr_Password", SqlDbType.VarChar, (50));
                            param[2].Value = ObjUser.Password;
                        }
                        if (!string.IsNullOrEmpty(ObjUser.Enc_Password))
                        {
                            param[3] = new SqlParameter("@Usr_Enc_Password", SqlDbType.VarChar, (200));
                            param[3].Value = ObjUser.Enc_Password;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.CompanyId))
                        {
                            param[4] = new SqlParameter("@CompanyId", SqlDbType.VarChar, (50));
                            param[4].Value = ObjUser.CompanyId;
                        }


                        param[5] = new SqlParameter("@Status", SqlDbType.Bit);
                        param[5].Value = ObjUser.Status;
                        param[6] = new SqlParameter("@ModifiedDate", SqlDbType.DateTime);
                        param[6].Value = Convert.ToDateTime(ObjUser.ModifiedDate);
                        param[7] = new SqlParameter("@IsVerified", SqlDbType.Bit);
                        param[7].Value = ObjUser.IsVerified;
                        param[8] = new SqlParameter("@LastLogin", SqlDbType.DateTime);
                        param[8].Value = ObjUser.LastLogin;
                        param[9] = new SqlParameter("@ReferredBy", SqlDbType.Int);
                        param[9].Value = ObjUser.ReferredBy;
                        param[10] = new SqlParameter("@Counter", SqlDbType.Int);
                        param[10].Value = 1;
                        param[11] = new SqlParameter("@Usr_CreatedBy", SqlDbType.VarChar, (50));
                        param[11].Value = ObjUser.CreatedBy;
                        param[12] = new SqlParameter("@Usr_Image", SqlDbType.VarChar, (1000));
                        param[12].Value = ObjUser.Image;
                        param[13] = new SqlParameter("@Id", SqlDbType.Int); //
                        param[13].Direction = ParameterDirection.Output;
                        if (!string.IsNullOrEmpty(ObjUser.SourceMedia))
                        {
                            if (ObjUser.SourceMedia.ToLower() == "newsltr")
                            {
                                param[14] = new SqlParameter("@Points", SqlDbType.Int);
                                param[14].Value = 1000;
                            }
                            else
                            {
                                //param[14] = new SqlParameter("@Points", SqlDbType.Int);
                                //param[14].Value = PointRate.Signup;
                            }
                        }
                        else
                        {
                            //param[14] = new SqlParameter("@Points", SqlDbType.Int);
                            //param[14].Value = PointRate.Signup;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.Last_Name))
                        {
                            param[15] = new SqlParameter("@Usr_LName", SqlDbType.VarChar, (50));
                            param[15].Value = ObjUser.Last_Name;
                        }



                        if (!string.IsNullOrEmpty(ObjUser.Gender))
                        {
                            param[16] = new SqlParameter("@Usr_Gender", SqlDbType.VarChar, (50));
                            param[16].Value = ObjUser.Gender;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.Marital))
                        {
                            param[17] = new SqlParameter("@Usr_Marital", SqlDbType.VarChar, (50));
                            param[17].Value = ObjUser.Marital;
                        }


                        if (!string.IsNullOrEmpty(ObjUser.HolidayDestination))
                        {
                            param[18] = new SqlParameter("@Usr_HolidayDest", SqlDbType.VarChar, (1000));
                            param[18].Value = ObjUser.HolidayDestination;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.HolidayBudget))
                        {
                            param[19] = new SqlParameter("@Usr_HolidayBudget", SqlDbType.Money);
                            param[19].Value = ObjUser.HolidayBudget;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.DealInterest))
                        {
                            param[20] = new SqlParameter("@Usr_Deal", SqlDbType.VarChar, (1000));
                            param[20].Value = ObjUser.DealInterest;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.RegionInterest))
                        {
                            param[21] = new SqlParameter("@Usr_Region", SqlDbType.VarChar, (1000));
                            param[21].Value = ObjUser.RegionInterest;
                        }

                        if (!string.IsNullOrEmpty(ObjUser.Frequency))
                        {
                            param[22] = new SqlParameter("@Usr_Frequency", SqlDbType.VarChar, (1000));
                            param[22].Value = ObjUser.Frequency;
                        }
                        if (!string.IsNullOrEmpty(ObjUser.CampaignID))
                        {
                            param[24] = new SqlParameter("@Usr_CampaignID", SqlDbType.VarChar, (50));
                            param[24].Value = ObjUser.CampaignID;
                        }
                        if (!string.IsNullOrEmpty(ObjUser.Origin))
                        {
                            param[25] = new SqlParameter("@Usr_Origin", SqlDbType.VarChar, (50));
                            param[25].Value = ObjUser.Origin;
                        }
                        if (!string.IsNullOrEmpty(ObjUser.Destination))
                        {
                            param[26] = new SqlParameter("@Usr_Destination", SqlDbType.VarChar, (50));
                            param[26].Value = ObjUser.Destination;
                        }
                        Rval = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, _CommandText, param);
                        return Convert.ToInt32(param[13].Value);
                    }
                }
                catch
                {
                    return 0;
                }
            }
            return Rval;
        }
        public bool UpdateUserPassword(User ObjUser)
        {
            bool Rval = false;
            if (ObjUser != null)
            {
                return Rval = Global.ExecuteNonQuery(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.LoginId
                                                    ,"@Usr_Password",ObjUser.Password                                             
                                                    ,"@Usr_Enc_Password",ObjUser.Enc_Password                                                  
                                                    ,"@Counter",8                                                    
                 }, DataConnection.GetConnectionPoints());
            }
            return Rval;
        }
        public string EncryptString(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(string));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;

            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);

            tdes.Clear();

            return System.Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public DataTable ViewBookingDetails(User ObjUser)
        {
            DataTable dt = new DataTable();
            if (ObjUser != null)
            {
                dt = Global.ExecuteSPReturnDT(new object[] {"GET_ViewBookingDetails"
                                                    ,"@paramUserLoginId",ObjUser.LoginId
                                                    ,"@paramBookingType",ObjUser.BookingType
                                                    ,"@paramBookingByCompany",ObjUser.CompanyId                                                                                                      
                 }, DataConnection.GetConnection());
            }
            return dt;
        }
        public bool UpdateUserDetails(User ObjUser)
        {
            bool Rval = false;
            if (ObjUser != null)
            {
                return Rval = Global.ExecuteNonQuery(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.MailId
                                                    ,"@Usr_Password",ObjUser.Password
                                                    ,"@Usr_FName",ObjUser.First_Name
                                                    ,"@Usr_LName",ObjUser.Last_Name
                                                    ,"@Usr_Enc_Password",ObjUser.Enc_Password
                                                    ,"@Usr_DOB",ObjUser.DOB
                                                    ,"@Usr_Mobile",ObjUser.MobileNo
                                                    ,"@Usr_Phone",ObjUser.PhoneNo
                                                    ,"@Usr_FaxNo",ObjUser.FaxNo
                                                    ,"@Usr_Address",ObjUser.Address
                                                    ,"@Usr_City",ObjUser.City                                                    
                                                    ,"@Usr_Country",ObjUser.Country
                                                    ,"@Usr_PinCode",ObjUser.PinCode
                                                    ,"@Usr_Title",ObjUser.Title
                                                    ,"@Usr_Id",ObjUser.UsrId
                                                    ,"@TPlist",ObjUser.TPids
                                                    ,"@NWSlist",ObjUser.NWSids
                                                    ,"@MLlist",ObjUser.MLids
                                                    ,"@UsuallyFlyFrom",ObjUser.UsuallyFlyFrom
                                                    ,"@Usr_IsPromoOffer",ObjUser.IsPromoOffer
                                                    ,"@Usr_IsUpdated",ObjUser.IsUpdated
                                                    ,"@Counter",3
                                                    ,"@Points",PointRate.ProfileUpdate

                                    
                     }, DataConnection.GetConnectionPoints());
            }
            return Rval;
        }

        public bool UpdateCampaignUserDetails(User ObjUser)
        {
            bool Rval = false;
            if (ObjUser != null)
            {
                return Rval = Global.ExecuteNonQuery(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.MailId
                                                 
                                                    ,"@Usr_FName",ObjUser.First_Name
                                                    ,"@Usr_LName",ObjUser.Last_Name                                                  
                                                    ,"@Usr_DOB",ObjUser.DOB                                                   
                                                    ,"@Usr_Mobile",ObjUser.MobileNo
                                                    ,"@Usr_Phone",ObjUser.PhoneNo                                            
                                                    ,"@Counter",11
                                                    ,"@Usr_Gender",ObjUser.Gender
                                                    ,"@Usr_Marital",ObjUser.Marital
                                                    ,"@Usr_HolidayDest",ObjUser.HolidayDestination
                                                    ,"@Usr_HolidayBudget",ObjUser.HolidayBudget
                                                    ,"@Usr_Deal",ObjUser.DealInterest
                                                    ,"@Usr_Region",ObjUser.RegionInterest
                                                    ,"@Usr_Frequency",ObjUser.Frequency
                                                    ,"@Usr_CampaignID",ObjUser.CampaignID
                                                    ,"@Usr_Origin",ObjUser.Origin
                                                    ,"@Usr_Destination",ObjUser.Destination
                                                    ,"@Usr_BookingStatus",ObjUser.BookingStatus
                                                    ,"@Usr_BookingDate",ObjUser.BookingDate
                                                    ,"@Usr_BookingType",ObjUser.BookingType
                                                    ,"@Usr_ProductType",ObjUser.ProductType
                                                    ,"@Usr_Address",ObjUser.Address
                                                    ,"@Usr_City",ObjUser.City
                                                    ,"@Usr_State",ObjUser.State
                                                    ,"@Usr_PinCode",ObjUser.PinCode
                                                    ,"@Usr_Country",ObjUser.Country


                 }, DataConnection.GetConnectionPoints());
            }
            return Rval;
        }

        public bool UpdateCampaignID(User ObjUser)
        {
            bool Rval = false;
            if (ObjUser != null)
            {
                return Rval = Global.ExecuteNonQuery(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_ID",ObjUser.UsrId                                             
                                                     ,"@Counter",13
                                                    ,"@Usr_CampaignID",ObjUser.CampaignID






                 }, DataConnection.GetConnectionPoints());
            }
            return Rval;
        }

        

        public int UploadData(string FirstName, string LastName, string EmailAddress, string VideoText, string ImageText)
        {
            SqlParameter[] param = new SqlParameter[8];
            try
            {
                using (SqlConnection connection = DataConnection.GetConnectionPoints())
                {

                    if (!string.IsNullOrEmpty(FirstName))
                    {
                        param[0] = new SqlParameter("@ParamFirstName", SqlDbType.VarChar, (20));
                        param[0].Value = Convert.ToString(FirstName);
                    }
                    if (!string.IsNullOrEmpty(LastName))
                    {
                        param[1] = new SqlParameter("@ParamlastName", SqlDbType.VarChar, (100));
                        param[1].Value = Convert.ToString(LastName);
                    }
                    if (!string.IsNullOrEmpty(EmailAddress))
                    {
                        param[2] = new SqlParameter("@ParamEmailAddress", SqlDbType.VarChar, (100));
                        param[2].Value = Convert.ToString(EmailAddress);
                    }
                    if (!string.IsNullOrEmpty(VideoText))
                    {
                        param[3] = new SqlParameter("@ParamVideo_Path ", SqlDbType.VarChar, (250));
                        param[3].Value = Convert.ToString(VideoText);
                    }

                    if (!string.IsNullOrEmpty(ImageText))
                    {
                        param[4] = new SqlParameter("@ParamImage_Path ", SqlDbType.VarChar, (250));
                        param[4].Value = Convert.ToString(ImageText);
                    }

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "Usp_GetUpload_Video", param);
                    if (count > 1)
                    {
                        return 1;
                    }

                }
            }


            catch
            {
                return 0;
            }
            return 0;
        }

        public DataSet GetUserProfile(int UsrId)
        {
            DataSet temp = new DataSet();

            temp = Global.ExecuteSPReturnDS(new object[] {"Usp_GetUserProfile"
                                                    ,"@Usr_Id",UsrId                                                                                              
                                                    ,"@Counter",1
                 }, DataConnection.GetConnectionPoints());


            return temp;
        }
        public void UpdateImagePath(int UsrId, string Path)
        {

            Global.ExecuteNonQuery(new object[] {"Usp_GetUserProfile"
                                                    ,"@Usr_Id",UsrId                                                                                              
                                                    ,"@Counter",2
                                                    ,"@Path",Path
                 }, DataConnection.GetConnectionPoints());

        }
        public void UpdateImageGallery(int UsrId, string Path)
        {

            if (UsrId > 0)
            {
                Global.ExecuteNonQuery(new object[] {"Usp_GetUserProfile"
                                                    ,"@Usr_Id",UsrId                                                                                              
                                                    ,"@Counter",4
                                                    ,"@Path",Path
                 }, DataConnection.GetConnectionPoints());
            }
        }
        public void UpdateVideoGallery(int UsrId, string Path)
        {

            if (UsrId > 0)
            {
                Global.ExecuteNonQuery(new object[] {"Usp_GetUserProfile"
                                                    ,"@Usr_Id",UsrId                                                                                              
                                                    ,"@Counter",5
                                                    ,"@Video_Path",Path
                 }, DataConnection.GetConnectionPoints());
            }
        }
        public int InsertBookingPoints(int UserID, string BookingID, int Points, int Credit, int Debit)
        {
            SqlParameter[] param = new SqlParameter[7];
            try
            {
                using (SqlConnection connection = DataConnection.GetConnectionPoints())
                {
                    if (UserID != 0)
                    {
                        param[0] = new SqlParameter("@Usr_Id", SqlDbType.Int);
                        param[0].Value = UserID;
                    }
                    if (!string.IsNullOrEmpty(BookingID))
                    {
                        param[1] = new SqlParameter("@Usr_BookingID", SqlDbType.VarChar, (100));
                        param[1].Value = Convert.ToString(BookingID);
                    }

                    param[2] = new SqlParameter("@Points", SqlDbType.Int);
                    param[2].Value = Convert.ToString(Points);


                    param[3] = new SqlParameter("@Credit", SqlDbType.Int);
                    param[3].Value = Convert.ToString(Credit);

                    param[4] = new SqlParameter("@Debit", SqlDbType.Int);
                    param[4].Value = Convert.ToString(Debit);

                    param[5] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[5].Value = 6;

                    param[6] = new SqlParameter("@Desc", SqlDbType.VarChar, (1000));
                    param[6].Value = "Booking Confirmations Points";



                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "Usp_UserDetails", param);
                    if (count > 0)
                    {
                        return 1;
                    }

                }
            }


            catch
            {
                return 0;
            }
            return 0;
        }

        public int InsertGlobeInsurnce(string BookingID, string prodID, string PolicyName, string CoverType, string AreaName, string Amount, string Duration)
        {
            SqlParameter[] param = new SqlParameter[8];
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {

                    if (!string.IsNullOrEmpty(BookingID))
                    {
                        param[1] = new SqlParameter("@ParamBookingID", SqlDbType.VarChar, (100));
                        param[1].Value = Convert.ToString(BookingID);
                    }
                    if (!string.IsNullOrEmpty(prodID))
                    {
                        param[2] = new SqlParameter("@ParamProdID", SqlDbType.VarChar, (100));
                        param[2].Value = Convert.ToString(prodID);
                    }
                    if (!string.IsNullOrEmpty(PolicyName))
                    {
                        param[3] = new SqlParameter("@ParamPolicyName", SqlDbType.VarChar, (100));
                        param[3].Value = Convert.ToString(PolicyName);
                    }

                    if (!string.IsNullOrEmpty(CoverType))
                    {
                        param[4] = new SqlParameter("@ParamCoverType", SqlDbType.VarChar, (100));
                        param[4].Value = Convert.ToString(CoverType);
                    }
                    if (!string.IsNullOrEmpty(AreaName))
                    {
                        param[5] = new SqlParameter("@ParamAreaName", SqlDbType.VarChar, (100));
                        param[5].Value = Convert.ToString(AreaName);
                    }
                    if (!string.IsNullOrEmpty(Amount))
                    {
                        param[6] = new SqlParameter("@ParamAmount", SqlDbType.Money);
                        param[6].Value = Convert.ToInt32(Amount);
                    }

                    if (!string.IsNullOrEmpty(Duration))
                    {
                        param[7] = new SqlParameter("@ParamDuration", SqlDbType.Int);
                        param[7].Value = Convert.ToInt32(Duration);
                    }

                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "Usp_SaveInsurance", param);
                    if (count > 0)
                    {
                        return 1;
                    }

                }
            }


            catch
            {
                return 0;
            }
            return 0;
        }


        public int InsertPoints(int UserID, string BookingID, int Points, int Credit, int Debit, string Desc)
        {


            SqlParameter[] param = new SqlParameter[7];
            try
            {
                using (SqlConnection connection = DataConnection.GetConnectionPoints())
                {
                    if (UserID != 0)
                    {
                        param[0] = new SqlParameter("@Usr_Id", SqlDbType.Int);
                        param[0].Value = UserID;
                    }
                    if (!string.IsNullOrEmpty(BookingID))
                    {
                        param[1] = new SqlParameter("@Usr_BookingID", SqlDbType.VarChar, (100));
                        param[1].Value = Convert.ToString(BookingID);
                    }

                    param[2] = new SqlParameter("@Points", SqlDbType.Int);
                    param[2].Value = Convert.ToString(Points);


                    param[3] = new SqlParameter("@Credit", SqlDbType.Int);
                    param[3].Value = Convert.ToString(Credit);

                    param[4] = new SqlParameter("@Debit", SqlDbType.Int);
                    param[4].Value = Convert.ToString(Debit);

                    param[5] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[5].Value = 7;
                    param[6] = new SqlParameter("@Desc", SqlDbType.VarChar, (1000));
                    param[6].Value = Desc;
                    int count = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "Usp_UserDetails", param);
                    if (count > 0)
                    {
                        return 1;
                    }

                }
            }


            catch
            {
                return 0;
            }
            return 0;
        }
        public DataTable GetUserDetail(User ObjUser)
        {
            DataTable dt = new DataTable();
            if (ObjUser != null)
            {
                dt = Global.ExecuteSPReturnDT(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",ObjUser.LoginId                                                                                                       
                                                    ,"@Counter",4
                 }, DataConnection.GetConnectionPoints());
            }
            return dt;
        }

        public bool TransferPoints(string userid, string toemail, string points)
        {

            bool Rval = true;
            try
            {
                return Rval = Global.ExecuteNonQuery(new object[] {"Usp_UserDetails"
                                                    ,"@Usr_EMail",toemail
                                                    ,"@Usr_Id",int.Parse(userid)
                                                    ,"@Points",int.Parse(points)
                                                    ,"@Counter",5                                                   
                 }, DataConnection.GetConnectionPoints());
            }
            catch
            {
                return false;
            }
        }
        public bool EarnPoints(int UsrId, int Points, string Desc)
        {
            bool Rval = false;

            return Rval = Global.ExecuteNonQuery(new object[] {"Usp_GetUserProfile"
                                                    ,"@Usr_Id",UsrId                                                                                              
                                                    ,"@Counter",3
                                                    ,"@Points",Points
                                                    ,"@Desc",Desc
                 }, DataConnection.GetConnectionPoints());

        }
        public bool TextReview(int UsrId, string Subject, string Desc, string ReviewType)
        {
            bool Rval = false;
            return Rval = Global.ExecuteNonQuery(new object[] {"Usp_GetUserProfile"
                                                    ,"@Usr_Id",UsrId                                                                                              
                                                    ,"@Counter",6
                                                    ,"@Review_Title",Subject
                                                    ,"@Desc",Desc
                                                    ,"@Review_Type",ReviewType
                 }, DataConnection.GetConnectionPoints());

        }

    }
    public class DOBFields
    {
        #region DOB

        public static List<Title> titleList(string Id)
        {
            List<Title> _title = new List<Title>();
            _title.Add(new Title { ID = null, Value = "Select" });
            _title.Add(new Title { ID = "Mr", Value = "Mr", Selected = Id });
            _title.Add(new Title { ID = "Mstr", Value = "Mstr", Selected = Id });
            _title.Add(new Title { ID = "Mrs", Value = "Mrs", Selected = Id });
            _title.Add(new Title { ID = "Miss", Value = "Miss", Selected = Id });
            _title.Add(new Title { ID = "Dr", Value = "Dr", Selected = Id });

            return _title;
        }
        public static List<Day> DayList()
        {
            List<Day> _ListDay = new System.Collections.Generic.List<Day>();
            _ListDay.Add(new Day { ID = null, Value = "Day" });
            for (int i = 1; i < 32; i++)
            {
                if (i > 0 && i < 10)
                    _ListDay.Add(new Day { ID = "" + "0" + i + "", Value = "" + "0" + i + "" });
                else
                    _ListDay.Add(new Day { ID = "" + i + "", Value = "" + i + "" });
            }
            return _ListDay;
        }
        public static List<Month> MonthList()
        {
            List<Month> _ListMonth = new System.Collections.Generic.List<Month>();
            _ListMonth.Add(new Month { ID = null, Value = "Month" });
            _ListMonth.Add(new Month { ID = "01", Value = "JAN" });
            _ListMonth.Add(new Month { ID = "02", Value = "FEB" });
            _ListMonth.Add(new Month { ID = "03", Value = "MAR" });
            _ListMonth.Add(new Month { ID = "04", Value = "APR" });
            _ListMonth.Add(new Month { ID = "05", Value = "MAY" });
            _ListMonth.Add(new Month { ID = "06", Value = "JUN" });
            _ListMonth.Add(new Month { ID = "07", Value = "JUL" });
            _ListMonth.Add(new Month { ID = "08", Value = "AUG" });
            _ListMonth.Add(new Month { ID = "09", Value = "SEP" });
            _ListMonth.Add(new Month { ID = "10", Value = "OCT" });
            _ListMonth.Add(new Month { ID = "11", Value = "NOV" });
            _ListMonth.Add(new Month { ID = "12", Value = "DEC" });
            return _ListMonth;
        }
        public static List<Year> YearList()
        {
            List<Year> _ListAdultYr = new System.Collections.Generic.List<Year>();
            _ListAdultYr.Add(new Year { ID = null, Value = "Year" });
            for (int i = System.DateTime.Now.Year - 11; i >= System.DateTime.Now.Year - 100; i--)
            {
                _ListAdultYr.Add(new Year { ID = "" + i + "", Value = "" + i + "" });
            }
            return _ListAdultYr;
        }


        #endregion


    }
    public class TravelPreference
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class NwsLetter
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Mailings
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyBooking
    {
        public string BookingID { get; set; }
        public string Name { get; set; }
        public string Dest { get; set; }
        public string BookingStatus { get; set; }
        public string TotalAmount { get; set; }
        public string BookingDate { get; set; }
        public string PNR { get; set; }
        public int SrNo { get; set; }

    }
    public class MyPoint
    {
        public string BookingID { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
        public string Expire { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Desc { get; set; }
        public DateTime EarnDate { get; set; }
    }
    public class MyReview
    {
        public string Title { get; set; }
        public string Review_Desc { get; set; }
        public string Video_Path { get; set; }
        public string Image_Path { get; set; }

    }
}
