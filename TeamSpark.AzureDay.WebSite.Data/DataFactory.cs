using System;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Service.Table;

namespace TeamSpark.AzureDay.WebSite.Data
{
	public static class DataFactory
	{
		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<CountryService> CountryService = new Lazy<CountryService>(() => new CountryService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<SpeakerService> SpeakerService = new Lazy<SpeakerService>(() => new SpeakerService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<RoomService> RoomService = new Lazy<RoomService>(() => new RoomService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<LanguageService> LanguageService = new Lazy<LanguageService>(() => new LanguageService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<TopicService> TopicService = new Lazy<TopicService>(() => new TopicService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<TimetableService> TimetableService = new Lazy<TimetableService>(() => new TimetableService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<SpeakerTopicService> SpeakerTopicService = new Lazy<SpeakerTopicService>(() => new SpeakerTopicService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<PartnerService> PartnerService = new Lazy<PartnerService>(() => new PartnerService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));

		public static async Task InitializeAsync()
		{
			await Task.WhenAll(
				AttendeeService.Value.InitializeAsync(),
				QuickAuthTokenService.Value.InitializeAsync(),
				CountryService.Value.InitializeAsync(),
				SpeakerService.Value.InitializeAsync(),
				RoomService.Value.InitializeAsync(),
				LanguageService.Value.InitializeAsync(),
				TopicService.Value.InitializeAsync(),
				TimetableService.Value.InitializeAsync(),
				SpeakerTopicService.Value.InitializeAsync()
			);
		}
	}
}
