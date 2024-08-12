using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
namespace TravelSite.Models
{
    public class Emailcls
    {
        public string BookingID { get; set; }
        public string EmailBody { get; set; }
        public string DomainName { get; set; }
        public string UserID { get; set; }
        public string EmailPassword { get; set; }
        public string EmailFrom { get; set; }
        public string EmailID { get; set; }
        public string Host { get; set; }
        public string Status { get; set; }
        public string CompanyID { get; set; }
        public int Port { get; set; }
        public string EmailPDF { get; set; }

        public static void SendMail(string to, string subject, string body, string CCEmail, string transectionID = null, string fromEmailAddress = "reservation@faressaver.com")
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            try
            {
                string msg = string.Empty;
                MailAddress fromAddress = new MailAddress(fromEmailAddress);
                message.From = fromAddress;
                message.To.Add(to);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                if (string.IsNullOrEmpty(CCEmail))
                    CCEmail = fromEmailAddress;
                //message.Bcc.Add("natwar_aim@yahoo.com");
                if (!string.IsNullOrEmpty(CCEmail))
                {
                    string[] CCid = CCEmail.Split(';');
                    for (int i = 0; i < CCid.Count(); i++)
                    {
                        message.CC.Add(CCid[i]);
                    }
                }
                smtpClient.Host = "smtp.gmail.com"; //"relay-hosting.secureserver.net"; // "smtp.gmail.com"; // ConfigurationManager.AppSettings["SMTPHost"].ToString();
                smtpClient.Port = 587; // 25;// 587;// Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
                smtpClient.EnableSsl = true; // Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
                smtpClient.UseDefaultCredentials = false; //  Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
                smtpClient.Credentials = new NetworkCredential("reservation@faressaver.com", "Dollarclub$$411");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.ServerCertificateValidationCallback = delegate
                {
                    return true;
                };
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                ReadWriteFile.SaveFile(HttpContext.Current.Server.MapPath("~/App_Data/Response/PNR/" + to + ".txt"), ex.ToString());
                // Log.Log.Error("Exception: " + ex + " || Email: " + to + (string.IsNullOrEmpty(transectionID) ? "" : " || Transaction ID : " + transectionID), Log.Log.GetCurrentNameSpace(), Log.Log.GetCurrentClass(), Log.Log.GetCurrentMethod());

            }
        }

        public static void SendMailWithAttachments(string to, string subject, string body, Attachment file, string transectionID = "")
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string msg = string.Empty;
                MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromEmailAddress"]);
                message.From = fromAddress;
                message.To.Add(to);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                message.Attachments.Add(file);
                smtpClient.Host = ConfigurationManager.AppSettings["SMTPHost"];   //-- Donot change.
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]); //--- Donot change
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);//--- Donot change
                smtpClient.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FromEmailAddress"], ConfigurationManager.AppSettings["EmailPasword"]);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                ServicePointManager.ServerCertificateValidationCallback = delegate
                {
                    return true;
                };
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                // Log.Log.Error("Exception: " + ex + " || Email: " + to + (string.IsNullOrEmpty(transectionID) ? "" : " || Transaction ID : " + transectionID), Log.Log.GetCurrentNameSpace(), Log.Log.GetCurrentClass(), Log.Log.GetCurrentMethod());
            }
        }

        public bool SendEmail_fun(string DisplayName, string MailBody, string Subject, string From, string To, string Bcc, string Host, int Port, string userid, string password, string pdfhtml, string BookingID)
        {
            try
            {
                byte[] pdfBuffer = null;

                //if (!string.IsNullOrEmpty(pdfhtml))
                //{
                //    HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
                //    htmlToPdfConverter.BrowserWidth = 1024;
                //    htmlToPdfConverter.HtmlLoadedTimeout = 120;
                //    htmlToPdfConverter.Document.PageSize = PdfPageSize.A4;
                //    htmlToPdfConverter.Document.PageOrientation = PdfPageOrientation.Portrait;
                //    htmlToPdfConverter.Document.Margins = new PdfMargins(0);
                //    htmlToPdfConverter.WaitBeforeConvert = 2;
                //    string htmlCode = pdfhtml;
                //    string baseUrl = "";
                //    pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, baseUrl);
                //    FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
                //    string sBody = MailBody;
                //    StringReader sr = new StringReader(sBody);
                //}


                //     MailMessage message = new MailMessage();
                //     SmtpClient smtp = new SmtpClient();
                //     message.From = new MailAddress(From, DisplayName);
                //     message.To.Add(new MailAddress(To));
                //     if (!string.IsNullOrEmpty(Bcc))
                //     {
                //         message.Bcc.Add(new MailAddress(Bcc));
                //     }
                //     message.Subject = Subject;
                //     if (!string.IsNullOrEmpty(pdfhtml))
                //     {
                //         message.Attachments.Add(new Attachment(new MemoryStream(pdfBuffer), "E-Ticket-" + BookingID.Replace("REF","") + ".pdf"));
                //     }
                //     message.IsBodyHtml = true; //to make message body as html  
                //     message.Body = MailBody;
                //     smtp.Port = Port;
                //     smtp.Host = Host; //for gmail host  
                //     smtp.EnableSsl = true;
                //     smtp.UseDefaultCredentials = false;
                //     smtp.Credentials = new NetworkCredential(userid, password);
                //     smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //     smtp.Send(message);
                return true;


            }
            catch (Exception ex)
            {

                return false;

            }
        }



        public DataSet GetDetails(string BookingId)
        {
            DataSet ds = new DataSet();

            SqlParameter[] param = new SqlParameter[2];
            try
            {
                using (SqlConnection conection = DataConnection.GetConnection())
                {
                    if (!string.IsNullOrEmpty(BookingId))
                    {
                        param[0] = new SqlParameter("@BookingID", SqlDbType.NVarChar, 50);
                        param[0].Value = BookingId;
                    }
                    param[1] = new SqlParameter("@Counter", SqlDbType.Int);
                    param[1].Value = 1;
                    ds = SqlHelper.ExecuteDataset(conection, CommandType.StoredProcedure, "Usp_Get_Flight_Detail", param);
                }
            }
            catch
            {
                return ds;
            }

            return ds;
        }


    }
}