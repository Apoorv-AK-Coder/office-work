using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class NewsLetter
    {
        public bool InsertEmailerDetails(string GroupID, string EmailID, string EmailerName, string EmailerContactNum, string EmailerDestCode, string EmailerSourceMedia, string IsSubscribe, string ModifiedBy, string ModifiedOn)
        {
            bool bMod = false;
            int iM = 0;
            bool chExist = CheckRegisterEmailer(EmailID, GroupID);

            if (chExist == false)
            {
                SqlParameter[] param = new SqlParameter[10];
                try
                {

                    param[0] = new SqlParameter("@Emailer_GroupID", SqlDbType.VarChar, 10);
                    param[0].Value = GroupID;
                    param[1] = new SqlParameter("@EMailer_EmailID", SqlDbType.VarChar, 100);
                    param[1].Value = EmailID;
                    param[2] = new SqlParameter("@EMailer_Name", SqlDbType.VarChar, 100);
                    param[2].Value = EmailerName;

                    param[3] = new SqlParameter("@Emailer_ContactNo", SqlDbType.VarChar, 20);
                    param[3].Value = EmailerContactNum;
                    param[4] = new SqlParameter("@Emailer_DestCode", SqlDbType.VarChar, 50);
                    param[4].Value = EmailerDestCode;
                    param[5] = new SqlParameter("@Emailer_SourceMedia", SqlDbType.VarChar, 50);
                    param[5].Value = EmailerSourceMedia;

                    param[6] = new SqlParameter("@EMailer_isSubscrib", SqlDbType.Bit);
                    param[6].Value = Convert.ToBoolean(IsSubscribe);
                    param[7] = new SqlParameter("@EMailer_LastModifiedBy", SqlDbType.VarChar, 50);
                    param[7].Value = ModifiedBy;
                    if (!string.IsNullOrEmpty(ModifiedOn))
                    {
                        param[8] = new SqlParameter("@EMailer_LastModifiedOn", SqlDbType.DateTime);
                        param[8].Value = ModifiedOn;
                    }
                    param[9] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[9].Value = 3;
                    using (SqlConnection connection = DataConnection.GetConnectionNewsLetter())
                    {
                        iM = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "NewsEmailerDetailsModify", param);
                    }

                    if (iM == 1)
                    {
                        bMod = true;
                    }
                    return bMod;
                }
                catch
                {
                    return bMod;
                }

            }
            return bMod;
        }
        public bool CheckRegisterEmailer(string EmailID, string GroupID)
        {
            bool b = true;

            SqlParameter[] param = new SqlParameter[3];
            try
            {
                if (!String.IsNullOrEmpty(GroupID))
                {
                    param[0] = new SqlParameter("@Emailer_GroupID", SqlDbType.VarChar, 10);
                    param[0].Value = GroupID;
                }
                if (!String.IsNullOrEmpty(EmailID))
                {
                    param[1] = new SqlParameter("@EMailer_EmailID", SqlDbType.VarChar, 100);
                    param[1].Value = EmailID;
                }

                param[2] = new SqlParameter("@Counter", SqlDbType.Int);
                param[2].Value = 5;

                using (SqlConnection connection = DataConnection.GetConnectionNewsLetter())
                {
                    object Email = SqlHelper.ExecuteScalar(connection, CommandType.StoredProcedure, "NewsEmailerDetailsModify", param);
                    if (Email == null || Email.ToString() == "")
                    {
                        b = false;
                    }
                }
                return b;
            }
            catch
            {
                return b;
            }
        }

        public bool SubscribeCustomer(string GroupID, string EmailID, string IsSubscribe, string ModifiedBy, string Remark)
        {
            bool bMod = false;

            SqlParameter[] param = new SqlParameter[7];
            try
            {
                param[0] = new SqlParameter("@Emailer_GroupID", SqlDbType.VarChar, 10);
                param[0].Value = GroupID;
                param[1] = new SqlParameter("@EMailer_EmailID", SqlDbType.VarChar, 100);
                param[1].Value = EmailID;
                param[2] = new SqlParameter("@EMailer_isSubscrib", SqlDbType.Bit);
                param[2].Value = Convert.ToBoolean(IsSubscribe);
                param[3] = new SqlParameter("@EMailer_LastModifiedBy", SqlDbType.VarChar, 50);
                param[3].Value = ModifiedBy;
                param[4] = new SqlParameter("@EMailer_Remark", SqlDbType.VarChar, 500);
                param[4].Value = Remark;
                param[5] = new SqlParameter("@Counter", SqlDbType.Int);
                param[5].Value = 2;
                using (SqlConnection connection = DataConnection.GetConnectionNewsLetter())
                {
                    int iM = SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, "NewsEmailerDetailsModify", param);
                    if (iM == 1)
                    {
                        bMod = true;
                    }
                }
                return bMod;
            }
            catch
            {
                return bMod;
            }
        }
    }
}
