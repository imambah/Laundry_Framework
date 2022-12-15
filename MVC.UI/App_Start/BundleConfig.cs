using System.Web;
using System.Web.Optimization;

namespace MVC.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/Js").Include(
                        "~/Content/bower_components/jquery/dist/jquery.min.js",
                        "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/Content/AdminJs").Include(
                        "~/Content/bower_components/jquery/dist/jquery.min.js",
                        "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                        "~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/Content/bower_components/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                        "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/bower_components/raphael/raphael.min.js",
                        "~/Content/bower_components/fastclick/lib/fastclick.js",
                        "~/Content/dist/js/dataTables.checkboxes.min.js",
                        "~/Content/dist/js/adminlte.min.js",
                        "~/Content/dist/js/demo.js",
                        "~/Content/plugins/iCheck/icheck.min.js",
                        "~/Content/plugins/timepicker/bootstrap-timepicker.min.js",
                        "~/Content/bower_components/morris.js/morris.min.js"
                        ));
            //<script src="../../bower_components/morris.js/morris.min.js"></script>

            bundles.Add(new StyleBundle("~/Content/Css").Include(
                        "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                        "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                        "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                        "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                        "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                        "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                        "~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                        "~/Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                        "~/Content/bower_components/morris.js/morris.css",
                        "~/Content/dist/css/dataTables.checkboxes.css",
                        "~/Content/dist/css/AdminLTE.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css",
                        "~/Content/AdminSite.css",
                        "~/Content/plugins/timepicker/bootstrap-timepicker.min.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}
