using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.ApplicationInsights.Extensibility;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.Host
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
			#region application insight

	        TelemetryConfiguration.Active.InstrumentationKey = Configuration.ApplicationInsightInstrumentationKey;

			#endregion

			#region asp net mvc

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			#endregion

			#region initialize

	        //DataFactory.InitializeAsync().Wait();

	        #endregion
        }
    }
}
