using System.Web.Http;

namespace TeamSpark.AzureDay.WebSite.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}
