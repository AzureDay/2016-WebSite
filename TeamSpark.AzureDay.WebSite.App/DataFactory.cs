﻿using System;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Service.Table;

namespace TeamSpark.AzureDay.WebSite.App
{
	public static class DataFactory
	{
		internal static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService(Configuration.AccountName, Configuration.AccountKey));
		internal static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService(Configuration.AccountName, Configuration.AccountKey));
		internal static readonly Lazy<CountryService> CountryService = new Lazy<CountryService>(() => new CountryService(Configuration.AccountName, Configuration.AccountKey));

		public static async Task InitializeAsync()
		{
			await Task.WhenAll(
				AttendeeService.Value.InitializeAsync(),
				QuickAuthTokenService.Value.InitializeAsync(),
				CountryService.Value.InitializeAsync()
			);
		}
	}
}
