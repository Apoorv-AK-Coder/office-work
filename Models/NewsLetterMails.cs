using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSite.Models;

namespace TravelSite.Models
{
   public class NewsLetterMails
   {
       NewsLetter NewsLetterMailsDAL = new NewsLetter();
       public bool InsertNewsLetterMails(string GroupID, string EmailID, string EmailerName, string EmailerContactNum, string EmailerDestCode, string EmailerSourceMedia, string IsSubscribe, string ModifiedBy, string ModifiedOn)
       {
           return NewsLetterMailsDAL.InsertEmailerDetails(GroupID, EmailID, EmailerName, EmailerContactNum, EmailerDestCode, EmailerSourceMedia, IsSubscribe, ModifiedBy, ModifiedOn);

       }

       public bool SubscribeCustomerBAL(string GroupID, string EmailID, string IsSubscribe, string ModifiedBy, string Remark)
       {
           return NewsLetterMailsDAL.SubscribeCustomer(GroupID, EmailID, IsSubscribe, ModifiedBy, Remark);
       }
    }
}
