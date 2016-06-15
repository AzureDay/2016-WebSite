using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.App.Entity.Api;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
    public class EventService
    {
        public async Task<List<Room>> GetAllRoomsAsync() => AppFactory.Mapper.Value.Map<List<Room>>(await DataFactory.RoomService.Value.GetByPartitionKeyAsync(Configuration.Year));
        public async Task<List<Topic>> GetAllTopicsAsync() => AppFactory.Mapper.Value.Map<List<Topic>>(await DataFactory.TopicService.Value.GetByPartitionKeyAsync(Configuration.Year));
        public async Task<List<Language>> GetAllLanguagesAsync() => AppFactory.Mapper.Value.Map<List<Language>>(await DataFactory.LanguageService.Value.GetByPartitionKeyAsync(Configuration.Year));
        public async Task<List<SpeakerTopic>> GetAllSpeakerTopicsAsync() => AppFactory.Mapper.Value.Map<List<SpeakerTopic>>(await DataFactory.SpeakerTopicService.Value.GetAllAsync());
        public async Task<List<Speaker>> GetAllSpeakersAsync() => AppFactory.Mapper.Value.Map<List<Speaker>>(await DataFactory.SpeakerService.Value.GetByPartitionKeyAsync(Configuration.Year));
        public async Task<List<Country>> GetAllСountriesAsync() => AppFactory.Mapper.Value.Map<List<Country>>(await DataFactory.CountryService.Value.GetByPartitionKeyAsync(Config.Configuration.Year));
    }
}
