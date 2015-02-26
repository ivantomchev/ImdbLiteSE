using System.Web;
using System.Web.Optimization;

namespace ImdbLite.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/Chosen/chosen.css",
                      "~/Scripts/fancybox/jquery.fancybox.css",
                      "~/Scripts/fancybox/jquery.fancybox-buttons.css",
                      "~/Scripts/fancybox/jquery.fancybox-thumbs.css",
                      "~/Content/bootstrap.darkly.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                "~/Content/Site.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                      "~/Scripts/fancybox/jquery.fancybox.pack.js",
                      "~/Scripts/fancybox/helpers/jquery.fancybox-buttons.js",
                      "~/Scripts/fancybox/helpers/jquery.fancybox-media.js",
                      "~/Scripts/fancybox/helpers/jquery.fancybox-thumbs.js"));

            bundles.Add(new ScriptBundle("~/bundles/picture-preview").Include(
            "~/Scripts/custom/picture-preview.js"));

            bundles.Add(new ScriptBundle("~/bundles/movies-create-server-side").Include(
            "~/Scripts/custom/movies-create-server-side.js"));

            bundles.Add(new ScriptBundle("~/bundles/movies-delete").Include(
            "~/Scripts/custom/movies-delete.js"));

            bundles.Add(new ScriptBundle("~/bundles/genres-delete").Include(
            "~/Scripts/custom/genres-delete.js"));

            bundles.Add(new ScriptBundle("~/bundles/celebrities-delete").Include(
            "~/Scripts/custom/celebrities-delete.js"));

            bundles.Add(new ScriptBundle("~/bundles/crudCelebrities").Include(
            "~/Scripts/Modal/crudCelebrities.js"));

            bundles.Add(new ScriptBundle("~/bundles/modal").Include(
                        "~/Scripts/Modal/modalform.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/Chosen").Include(
                        "~/Scripts/chosen/chosen.jquery.js"));
        }
    }
}
