using System.Net.Http.Formatting;
using System.Web.Http;

namespace TeamSpark.AzureDay.WebSite.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Add(new BsonMediaTypeFormatter());
            config.MapHttpAttributeRoutes();
           // config.MessageHandlers.Add(new TokenValidationHandler());
        }
    }
}
