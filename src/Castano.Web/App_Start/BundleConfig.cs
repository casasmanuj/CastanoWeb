using System.Web;
using System.Web.Optimization;

namespace Castano.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/fontawesome/fontawesome.css",
                "~/Content/magnific.popup/magnific.css",
                "~/Content/bootstrap.datetime/bootstrap.datetime.css",
                "~/Content/jquery.smartWizard/jquery.smartWizard.css",
                "~/Content/jquery.smartWizard/smart_wizard_theme_arrows.css",
                "~/Content/creative/creative.min.css",
                "~/Content/Site.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment/moment.min.js",
                "~/Scripts/moment/es.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment-holiday").Include(
                "~/Scripts/moment-holiday/moment-holiday.min.js",
                "~/Scripts/moment-holiday/moment-holiday.ar.js"));

            bundles.Add(new ScriptBundle("~/bundles/numeral").Include(
                "~/Scripts/numeral/numeral.min.js",
                "~/Scripts/numeral/numeral.es.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-validator").Include(
                        "~/Scripts/bootstrap.validator/bootstrap.validator.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetime").Include(
                        "~/Scripts/bootstrap.datetime/bootstrap.datetime.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-easing").Include(
                        "~/Scripts/jquery.easing/jquery.easing.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-blockUI").Include(
                        "~/Scripts/jquery.blockUI/jquery.blockUI.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-smartwizard").Include(
                        "~/Scripts/jquery.smartwizard/jquery.smartwizard.js"));

            bundles.Add(new ScriptBundle("~/bundles/scrollreveal").Include(
                        "~/Scripts/scrollreveal/scrollreveal.js"));

            bundles.Add(new ScriptBundle("~/bundles/magnific-popup").Include(
                        "~/Scripts/magnific.popup/magnific.popup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/knockout/knockoutjs.js",
                        "~/Scripts/knockout/knockoutjs.mapping.js"));

            bundles.Add(new ScriptBundle("~/bundles/creative").Include(
                        "~/Scripts/creative/creative.js"));


            bundles.Add(new StyleBundle("~/Content/datatablesBs4", "//cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css").Include(
                "~/Content/datatables/datatablesBs4.css"));
            bundles.Add(new StyleBundle("~/Content/datatablesButtonsBs4", "//cdn.datatables.net/buttons/1.6.1/css/buttons.bootstrap4.min.css").Include(
                "~/Content/datatables/datatablesButtonsBs4.css"));
            bundles.Add(new StyleBundle("~/Content/datatablesResponsiveBs4", "//cdn.datatables.net/responsive/2.2.3/css/responsive.bootstrap4.min.css").Include(
                "~/Content/datatables/datatablesResponsiveBs4.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables", "//cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js").Include(
                "~/Scripts/datatables/datatables.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesBs4", "//cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js").Include(
                "~/Scripts/datatables/datatablesBs4.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesButtons", "//cdn.datatables.net/buttons/1.6.1/js/dataTables.buttons.min.js").Include(
                "~/Scripts/datatables/datatablesButtons.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesButtonsBs4", "//cdn.datatables.net/buttons/1.6.1/js/buttons.bootstrap4.min.js").Include(
                "~/Scripts/datatables/datatablesButtonsBs4.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/jszip", "//cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js").Include(
                "~/Scripts/datatables/jszip.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesButtonsHtml5", "//cdn.datatables.net/buttons/1.6.1/js/buttons.html5.min.js").Include(
                "~/Scripts/datatables/datatablesButtonsHtml5.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesButtonsPrint", "//cdn.datatables.net/buttons/1.6.1/js/buttons.print.min.js").Include(
                "~/Scripts/datatables/datatablesButtonsPrint.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesResponsive", "//cdn.datatables.net/responsive/2.2.3/js/dataTables.responsive.min.js").Include(
                "~/Scripts/datatables/datatablesResponsive.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/datatablesResponsiveBs4", "//cdn.datatables.net/responsive/2.2.3/js/responsive.bootstrap4.min.js").Include(
                "~/Scripts/datatables/datatablesResponsiveBs4.js"
            ));
        }
    }
}
