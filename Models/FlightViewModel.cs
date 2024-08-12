using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelSite.Models
{
    public class FlightViewModel
    {       
            public IEnumerable<FlightFare> Asia { get; set; }
            public IEnumerable<FlightFare> Africa { get; set; }
            public IEnumerable<FlightFare> Australia { get; set; }
            public IEnumerable<FlightFare> MiddleEast { get; set; }
            public IEnumerable<FlightFare> America { get; set; }
            public IEnumerable<FlightFare> FarEast { get; set; }
            public IEnumerable<FlightFare> SAmerica { get; set; }
            public IEnumerable<FlightFare> Europe { get; set; }
            public IEnumerable<FlightFare> China { get; set; }
            public IEnumerable<FlightFare> Carri { get; set; } 

    }
}