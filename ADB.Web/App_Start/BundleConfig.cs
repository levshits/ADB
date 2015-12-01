using System.Web.Optimization;

namespace ADB.Web
{
    public class BundleConfig
    {
        public const string SCRIPTS_BUNDLE_JQUERY = "~/bundles/jquery";
        public const string SCRIPTS_BUNDLE_JQUERY_VALIDATE = "~/bundles/jqueryvalidate";
        public const string SCRIPTS_BUNDLE_BOOTSTRAP = "~/bundles/bootstrap";
        public const string SCRIPTS_BUNDLE_ADB_COMMON = "~/bundles/adb.common";
        public const string STYLE_BUNDLE_BOOTSTRAP = "~/styles/bootstrap";
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(SCRIPTS_BUNDLE_JQUERY).Include(
                        "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(SCRIPTS_BUNDLE_JQUERY_VALIDATE).Include(
                        "~/Scripts/jquery.validate/jquery.validate*"));


            bundles.Add(new ScriptBundle(SCRIPTS_BUNDLE_BOOTSTRAP).Include(
                      "~/Scripts/bootstrap/bootstrap.js",
                      "~/Scripts/bootstrap/bootstrap-datepicker.js"));

            bundles.Add(new ScriptBundle(SCRIPTS_BUNDLE_ADB_COMMON).Include(
                      "~/Scripts/ADB/js-common.js"));

            bundles.Add(new StyleBundle(STYLE_BUNDLE_BOOTSTRAP).Include(
                      "~/Content/bootstrap/bootstrap.css", 
                      "~/Content/bootstrap/bootstrap-theme.css",
                      "~/Content/bootstrap/bootstrap-datepicker.css",
                      "~/Content/bootstrap/bootstrap-datepicker3.css"));
        }
    }
}
