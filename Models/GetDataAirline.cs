using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSite.Models
{
    public class GetDataAirline
    {
       GetSetAirline GetSetAirlineDAL = new GetSetAirline();
        //public DataTable GETAirlineFareImagedata(string Company)
        //{
        //    DataSet ds = GetSetAirlineDAL.GETAirlineFareImage(Company);
        //    return ds.Tables[0];
        //}
        public List<FlightFareAirlineHome> GETAirlineFareImage(AirlinefareRequest AFReq)
        {
            DataTable dt = GetSetAirlineDAL.GETAirlineFareImage(AFReq);
            List<FlightFareAirlineHome> FlightFareAirlineHome = new List<FlightFareAirlineHome>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FlightFareAirlineHome.Add(new FlightFareAirlineHome(dr));
                }
            }
            return FlightFareAirlineHome;
        }
        public List<FlightFareAirline> GetFaresFlightAirline(AirlineRequest AReq)
        {
            DataSet dt = GetSetAirlineDAL.GetFaresFlightAirline(AReq);
            List<FlightFareAirline> FlightFareAirline = new List<FlightFareAirline>();
            if (dt.Tables[0] != null)
            {
                foreach (DataRow dr in dt.Tables[0].Rows)
                {
                    FlightFareAirline.Add(new FlightFareAirline(dr));
                }
            }
            if (dt.Tables[1] != null)
            {
                foreach (DataRow dr in dt.Tables[1].Rows)
                {
                    FlightFareAirline.Add(new FlightFareAirline(dr));
                }
            }
            if (dt.Tables[2] != null)
            {
                foreach (DataRow dr in dt.Tables[2].Rows)
                {
                    FlightFareAirline.Add(new FlightFareAirline(dr));
                }
            }
            return FlightFareAirline;
        }
    }
       
}
