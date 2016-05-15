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

		#region azure storage

		public static string AzureStorageAccountName
		{
			get { return ConfigurationManager.AppSettings.Get("AzureStorageAccountName"); }
		}

		public static string AzureStorageAccountKey
		{
			get { return ConfigurationManager.AppSettings.Get("AzureStorageAccountKey"); }
		}

		#endregion

		#region application insight

		public static string ApplicationInsightInstrumentationKey
		{
			get { return ConfigurationManager.AppSettings.Get("ApplicationInsightInstrumentationKey"); }
		}

		public static string ApplicationInsightEnvironmentTag
		{
			get { return ConfigurationManager.AppSettings.Get("ApplicationInsightEnvironmentTag"); }
		}

		#endregion

		#region sendgrid

		public static string SendGridApiKey
		{
			get { return ConfigurationManager.AppSettings.Get("SendGridApiKey"); }
		}

		#endregion
	}
}
