using System.Web.Optimization;

namespace TeamSpark.AzureDay.WebSite.Host
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
			//// Use the development version of Modernizr to develop with and learn from. Then, when you're
			//// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
			//            "~/Scripts/modernizr-*"));

			//bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
			//          "~/Scripts/bootstrap.js",
			//          "~/Scripts/respond.js"));

			//bundles.Add(new StyleBundle("~/Content/css").Include(
			//          "~/Content/bootstrap.css",
			//          "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/cdn/theme/css").Include(
				"~/Theme/css/bootstrap.min.css",
				"~/Theme/inc/shortcodes/css/shortcodes.css",
				"~/Theme/css/font-awesome.css",
				"~/Theme/css/animate.css",
				"~/Theme/css/wowslider.css",
				"~/Theme/style.css"));

			bundles.Add(new StyleBundle("~/cdn/jqueryui/css").Include(
				"~/Content/themes/base/all.css"));

			bundles.Add(new ScriptBundle("~/cdn/theme/js").Include(
				//"~/Theme/js/jquery.js",
				//"~/Theme/js/bootstrap.js",
				"~/Theme/js/jquery.fitvids.js",
				"~/Theme/js/jquery.easing.1.3.js",
				"~/Theme/js/common.js",
				"~/Theme/js/flexslider.js",
				"~/Theme/js/flexsliderhome.js",
				"~/Theme/js/carouselrecentportfolio.js",
				"~/Theme/js/carousel.js",
				"~/Theme/js/prettyPhoto.js",
				"~/Theme/js/isotope.js",
				"~/Theme/js/flexslidertestimonials.js",
				"~/Theme/js/testimonial.js"));

			bundles.Add(new ScriptBundle("~/cdn/knockout/js").Include(
				"~/Scripts/knockout-3.4.0.js"));

			bundles.Add(new ScriptBundle("~/cdn/bootstrap/js").Include(
				"~/Scripts/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/cdn/jquery/js").Include(
				"~/Scripts/jquery-1.11.0.min.js"));

			bundles.Add(new ScriptBundle("~/cdn/jqueryui/js").Include(
				"~/Scripts/jquery-ui-1.11.0.min.js"));

			BundleTable.EnableOptimizations = true;
        }
	}
}
