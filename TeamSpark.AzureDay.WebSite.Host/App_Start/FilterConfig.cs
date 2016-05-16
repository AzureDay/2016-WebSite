using System.Web.Mvc;
using TeamSpark.AzureDay.WebSite.Host.Filter;

namespace TeamSpark.AzureDay.WebSite.Host
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ApplicationInsightHandleErrorAttribute());
        }
    }
}
