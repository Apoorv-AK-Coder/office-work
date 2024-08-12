using System.Web;
using System.Web.Optimization;

namespace TravelSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.min.js"
                        ));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));
            BundleTable.EnableOptimizations = true;
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery-1.10.2.js",
                      "~/Scripts/js/jquery-ui-1.11.4.js",
                      "~/Scripts/modernizr-2.8.3.js",
                      "~/Scripts/js/bootstrap.js",
                      "~/Scripts/js/easyresponsivetabs.js",
                      "~/Scripts/js/flight/flight.js",
                      "~/Scripts/js/vendor/jquery.browser.js",
                      "~/Scripts/js/vendor/jquery.alerts.js",
                      "~/Scripts/query.popup.js",
                      "~/Scripts/js/sessionCalc.js",
                      "~/Scripts/pushy.js",
                      "~/js/autocomplete.js"
                      ));

            
            //bundles.Add(new ScriptBundle("~/bundles/result").Include(
            //         "~/Scripts/slider.js",
            //         "~/Scripts/jquery.flexisel.js",
            //         "~/Scripts/scrolltopcontrol.js",
            //         "~/Scripts/clander.js",
            //         "~/Scripts/time.js",
            //         "~/Scripts/jquery-ui-custom.min.js",
            //         "~/Scripts/jquery.cookie.js"
            //         ));


            bundles.Add(new StyleBundle("~/Content/css/main").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/implement-common.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/homepage.css",
                      "~/Content/css/loader.css",
                      "~/Content/css/new-result.css",
                      "~/Content/css/pax-details.css",
                      "~/Content/css/custom-bootstrap-margin-padding.css",
                      "~/Content/css/style.css",
                      "~/Content/css/travel-site.css"
                      ));


        }
    }
}
