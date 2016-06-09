using System;
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

		#region cdn

		public static string CdnEndpointWeb
		{
			get { return ConfigurationManager.AppSettings.Get("CdnEndpointWeb"); }
		}

		public static string CdnEndpointStorage
		{
			get { return ConfigurationManager.AppSettings.Get("CdnEndpointStorage"); }
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

		public static string SendGridFromEmail
		{
			get { return ConfigurationManager.AppSettings.Get("SendGridFromEmail"); }
		}

		public static string SendGridFromName
		{
			get { return ConfigurationManager.AppSettings.Get("SendGridFromName"); }
		}

		#endregion

		#region kaznackey

		public static Guid KaznackeyMerchantId
		{
			get { return Guid.Parse(ConfigurationManager.AppSettings.Get("KaznackeyMerchantId")); }
		}

		public static string KaznackeyMerchantSecreet
		{
			get { return ConfigurationManager.AppSettings.Get("KaznackeyMerchantSecreet"); }
		}

		public static Guid LiqPayMerchantId
		{
			get { return Guid.Parse(ConfigurationManager.AppSettings.Get("LiqPayMerchantId")); }
		}

		public static string LiqPayMerchantSecreet
		{
			get { return ConfigurationManager.AppSettings.Get("LiqPayMerchantSecreet"); }
		}

		#endregion
	}
}
