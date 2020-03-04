using System.Web;
using System.Web.Optimization;

namespace Castano.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/css/bootstrap/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/css/fontawesome/fontawesome.css"));

            bundles.Add(new StyleBundle("~/Content/magnific").Include(
                "~/css/magnific-popup/magnific.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap.datetime").Include(
                "~/css/bootstrap.datetime/bootstrap-datetime.css"));

            bundles.Add(new StyleBundle("~/Content/creative").Include(
                "~/css/creative.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/js/moment/moment.min.js",
                "~/js/moment/es.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/js/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap.datetime").Include(
                        "~/js/bootstrap.datetime/bootstrap-datetime.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.easing").Include(
                        "~/js/jquery.easing/jquery-easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollreveal").Include(
                        "~/js/scrollreveal/scrollreveal.js"));

            bundles.Add(new ScriptBundle("~/bundles/magnific.popup").Include(
                        "~/js/magnific-popup/magnific-popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/js/knockout/knockoutjs.js",
                        "~/js/knockout/knockout.handlers.js",
                        "~/js/knockout/knockout.validations.js"));

            bundles.Add(new ScriptBundle("~/bundles/creative").Include(
                        "~/js/creative.js"));
        }
    }
}
