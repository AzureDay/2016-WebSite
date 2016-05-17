using System;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Service.Table;

namespace TeamSpark.AzureDay.WebSite.Data
{
	public static class DataFactory
	{
		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() =>
		{
			var service = new AttendeeService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});

		public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() =>
		{
			var service = new QuickAuthTokenService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});

		public static readonly Lazy<CountryService> CountryService = new Lazy<CountryService>(() =>
		{
			var service = new CountryService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});

		public static readonly Lazy<SpeakerService> SpeakerService = new Lazy<SpeakerService>(() =>
		{
			var service = new SpeakerService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
		
		public static readonly Lazy<RoomService> RoomService = new Lazy<RoomService>(() =>
		{
			var service = new RoomService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
		
		public static readonly Lazy<LanguageService> LanguageService = new Lazy<LanguageService>(() =>
		{
			var service = new LanguageService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
		
		public static readonly Lazy<TopicService> TopicService = new Lazy<TopicService>(() =>
		{
			var service = new TopicService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
		
		public static readonly Lazy<TimetableService> TimetableService = new Lazy<TimetableService>(() =>
		{
			var service = new TimetableService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
		
		public static readonly Lazy<SpeakerTopicService> SpeakerTopicService = new Lazy<SpeakerTopicService>(() =>
		{
			var service = new SpeakerTopicService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
		
		public static readonly Lazy<PartnerService> PartnerService = new Lazy<PartnerService>(() =>
		{
			var service = new PartnerService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey);
			service.InitializeAsync().Wait();
			return service;
		});
	}
}
