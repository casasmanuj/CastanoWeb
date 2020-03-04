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
                "~/Content/bootstrap/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Content/fontawesome/fontawesome.css"));

            bundles.Add(new StyleBundle("~/Content/magnific").Include(
                "~/Content/magnific-popup/magnific.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap.datetime").Include(
                "~/Content/bootstrap-datetime/bootstrap-datetime.css"));

            bundles.Add(new StyleBundle("~/Content/creative").Include(
                "~/Content/creative/creative.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment/moment.min.js",
                "~/Scripts/moment/es.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetime").Include(
                        "~/Scripts/bootstrap-datetime/bootstrap-datetime.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-easing").Include(
                        "~/Scripts/jquery-easing/jquery-easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollreveal").Include(
                        "~/Scripts/scrollreveal/scrollreveal.js"));

            bundles.Add(new ScriptBundle("~/bundles/magnific-popup").Include(
                        "~/Scripts/magnific-popup/magnific-popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout/knockoutjs.js",
                        "~/Scripts/knockout/knockout.handlers.js",
                        "~/Scripts/knockout/knockout.validations.js"));

            bundles.Add(new ScriptBundle("~/bundles/creative").Include(
                        "~/Scripts/creative/creative.js"));
        }
    }
}
