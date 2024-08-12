using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();
            routes.LowercaseUrls = true;
            routes.MapRoute(
                      name: "Default",
                      url: "",
                     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Default10",
             url: "call-us",
               defaults: new { controller = "Enquiry", action = "CallUs", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Default11",
             url: "feedback",
               defaults: new { controller = "Enquiry", action = "feedback", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Default12",
             url: "request-call",
               defaults: new { controller = "Enquiry", action = "requestcall", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                      name: "Default5",
                      url: "privacy-policy/",
                      defaults: new { controller = "Common", action = "Privacypolicy", id = UrlParameter.Optional }
                  );
            routes.MapRoute(
                      name: "Default18",
                      url: "airline-contacts/",
                      defaults: new { controller = "Common", action = "Airlinecontacts", id = UrlParameter.Optional }
                  );
            routes.MapRoute(
                     name: "Default19",
                     url: "onlinecheckin/",
                     defaults: new { controller = "Common", action = "Onlinecheckin", id = UrlParameter.Optional }
                 );

            routes.MapRoute(
                 name: "Default2",
                url: "flights",
                  defaults: new { controller = "Common", action = "Flights", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "Default20",
               url: "hotels/",
                 defaults: new { controller = "Common", action = "Hotels", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default21",
               url: "holiday-enquiry/",
                 defaults: new { controller = "Common", action = "Holidayenquiry", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                  name: "Default3",
                 url: "contact-us/",
                    defaults: new { controller = "Common", action = "Contactus", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                   name: "Default4",
                   url: "about-us/",
                   defaults: new { controller = "Common", action = "Aboutus", id = UrlParameter.Optional }
                 );

            routes.MapRoute(
                    name: "Default6",
                    url: "terms-conditions/",
                    defaults: new { controller = "Common", action = "Termsconditions", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                   name: "Default9",
                   url: "cookie-policy/",
                   defaults: new { controller = "Common", action = "Cookiepolicy", id = UrlParameter.Optional }
               );
            routes.MapRoute(
                  name: "Default7",
                  url: "PassengerDetail/",
                  defaults: new { controller = "PassengerDetails", action = "Passenger", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                 name: "Default8",
                url: "result",
                defaults: new { controller = "result", action = "FlightResult", id = UrlParameter.Optional }
         );
            routes.MapRoute(
               name: "Default1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Destination", action = "Index", id = UrlParameter.Optional }
           );




        }
    }
}
