using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Host.Helpers
{
	public static class CdnHelper
	{
		public static string GetCdnWebUrl(string url)
		{
			return string.Format("{0}{1}", Configuration.CdnEndpointWeb, url);
		}

		public static string GetCdnWebStorage(string url)
		{
			return string.Format("{0}{1}", Configuration.CdnEndpointStorage, url);
		}
	}
}