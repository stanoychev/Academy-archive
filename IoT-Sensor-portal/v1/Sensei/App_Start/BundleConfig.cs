using System.Web;
using System.Web.Optimization;

namespace Sensei
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Theme/bundle/datatablescss").Include(
                "~/Theme/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css",
                "~/Theme/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css",
                "~/Theme/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
                "~/Theme/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css",
                "~/Theme/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css"
            ));

            bundles.Add(new StyleBundle("~/Theme/bundle/css").Include(
                    "~/Theme/vendors/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include(
                    "~/Theme/vendors/nprogress/nprogress.css",
                    "~/Theme/vendors/iCheck/skins/flat/green.css",
                    "~/Theme/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                    "~/Theme/vendors/jqvmap/dist/jqvmap.min.css",
                    "~/Theme/vendors/bootstrap-daterangepicker/daterangepicker.css",
                    "~/Theme/build/css/custom.css")
                .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/recaptcha").Include(
                "~/Scripts/recaptcha.js"));

            bundles.Add(new ScriptBundle("~/Theme/bundle/js").Include(
                "~/Theme/vendors/jquery/dist/jquery.min.js",
                "~/Theme/vendors/bootstrap/dist/js/bootstrap.min.js",
                "~/Theme/vendors/fastclick/lib/fastclick.js",
                "~/Theme/vendors/nprogress/nprogress.js",
                "~/Theme/vendors/Chart.js/dist/Chart.min.js",
                "~/Theme/vendors/gauge.js/dist/gauge.min.js",
                "~/Theme/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                "~/Theme/vendors/iCheck/icheck.min.js",
                "~/Theme/vendors/skycons/skycons.js",
                "~/Theme/vendors/Flot/jquery.flot.js",
                "~/Theme/vendors/Flot/jquery.flot.pie.js",
                "~/Theme/vendors/Flot/jquery.flot.time.js",
                "~/Theme/vendors/Flot/jquery.flot.stack.js",
                "~/Theme/vendors/Flot/jquery.flot.resize.js",
                "~/Theme/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                "~/Theme/vendors/flot-spline/js/jquery.flot.spline.min.js",
                "~/Theme/vendors/flot.curvedlines/curvedLines.js",
                "~/Theme/vendors/DateJS/build/date.js",
                "~/Theme/vendors/jqvmap/dist/jquery.vmap.js",
                "~/Theme/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                "~/Theme/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                "~/Theme/vendors/moment/min/moment.min.js",
                "~/Theme/vendors/bootstrap-daterangepicker/daterangepicker.js",
                "~/Theme/build/js/custom.min.js"));

            bundles.Add(new ScriptBundle("~/Theme/bundle/datatablesjs").Include(
                "~/Theme/vendors/datatables.net/js/jquery.dataTables.min.js",
                "~/Theme/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js",
                "~/Theme/vendors/datatables.net-buttons/js/dataTables.buttons.min.js",
                "~/Theme/vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js",
                "~/Theme/vendors/datatables.net-buttons/js/buttons.flash.min.js",
                "~/Theme/vendors/datatables.net-buttons/js/buttons.html5.min.js",
                "~/Theme/vendors/datatables.net-buttons/js/buttons.print.min.js",
                "~/Theme/vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js",
                "~/Theme/vendors/datatables.net-keytable/js/dataTables.keyTable.min.js",
                "~/Theme/vendors/datatables.net-responsive/js/dataTables.responsive.min.js",
                "~/Theme/vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js",
                "~/Theme/vendors/datatables.net-scroller/js/dataTables.scroller.min.js",
                "~/Theme/vendors/jszip/dist/jszip.min.js",
                "~/Theme/vendors/pdfmake/build/pdfmake.min.js",
                "~/Theme/vendors/pdfmake/build/vfs_fonts.js"));

            bundles.Add(new ScriptBundle("~/bundles/registerNewSensor").Include(
                "~/Scripts/Custom/registerNewSensor.js"));
        }
    }
}
