using System.Configuration;

namespace TeamSpark.AzureDay.WebSite.Config
{
	public static class Configuration
	{
		#region general

		public static string Year
		{
			get { return "2016"; }
		}

		#endregion

		#region storage

		public static string AccountName
		{
			get { return ConfigurationManager.AppSettings.Get("AccountName"); }
		}

		public static string AccountKey
		{
			get { return ConfigurationManager.AppSettings.Get("AccountKey"); }
		}

		#endregion
	}
}
