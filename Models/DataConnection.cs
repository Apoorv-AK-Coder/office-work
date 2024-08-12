using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class DataConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetPageTrackerConnection()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetOffLineFareConnection()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetConnectionNewsLetter()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetConnectionMoresand()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetMlWebsite()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetConnectionBlog()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetConnectionHotel()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;

        }
        public static SqlConnection GetConnectionMLWebsites()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }
        public static SqlConnection GetConnectionAirFare()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;

        }
        public static SqlConnection GetConnectionPoints()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            return Con;
        }

    }
}
