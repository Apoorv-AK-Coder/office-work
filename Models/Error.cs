using System.Web.Mvc;
using System.Web;

namespace TravelSite.Models
{
    public class Error
    {
        public static void RedirectError(string sError)
        {
            SecureQueryString sq = new SecureQueryString();
            sq["error"] = sError;
           
            HttpContext.Current.Response.Redirect("~/error.aspx?q=" + sq + "", false);
        }
    }


    
}
