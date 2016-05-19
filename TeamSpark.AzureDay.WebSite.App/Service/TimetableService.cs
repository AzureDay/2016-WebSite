using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class TimetableService
	{
		public async Task<List<Timetable>> GetTimetableAsync()
		{
			var roomsTask = DataFactory.RoomService.Value.GetByPartitionKeyAsync(Configuration.Year);
			var topicsTask = DataFactory.TopicService.Value.GetByPartitionKeyAsync(Configuration.Year);
			var languagesTask = DataFactory.LanguageService.Value.GetByPartitionKeyAsync(Configuration.Year);
			var speakersTopicsTask = DataFactory.SpeakerTopicService.Value.GetAllAsync();
			var speakersTask = DataFactory.SpeakerService.Value.GetByPartitionKeyAsync(Configuration.Year);

			await Task.WhenAll(
				roomsTask,
				topicsTask,
				languagesTask,
				speakersTopicsTask,
				speakersTask);

			var rooms = roomsTask.Result
				//.Where(r => r.RoomType != RoomType.CoffeeRoom)
				.Select(t => AppFactory.Mapper.Value.Map<Room>(t))
				.ToList();

			var topics = topicsTask.Result
				.ToList();

			var languages = languagesTask.Result;

			var speakerTopics = speakersTopicsTask.Result;

			var speakers = speakersTask.Result
				.Select(t => AppFactory.Mapper.Value.Map<Speaker>(t))
				.ToList();

			var timetables = new List<Timetable>();

			foreach (var room in rooms)
			{
				var timetablesRoom = await DataFactory.TimetableService.Value.GetByPartitionKeyAsync(room.Id.ToString("N"));

				foreach (var timetableRoom in timetablesRoom)
				{
					var timetable = AppFactory.Mapper.Value.Map<Timetable>(timetableRoom);
					var topic = topics.Single(t => t.Id == timetableRoom.TopicId);
					var language = languages.Single(l => l.Id == topic.LanguageId);
					var topicSpeakers = speakerTopics.Where(ts => ts.TopicId == topic.Id).Select(ts => ts.SpeakerId).ToList();

					timetable.Room = rooms.Single(r => r.Id == timetableRoom.RoomId);
					timetable.Topic = AppFactory.Mapper.Value.Map<Topic>(topic);
					timetable.Topic.Language = AppFactory.Mapper.Value.Map<Language>(language);
					timetable.Topic.Speakers = speakers.Where(s => topicSpeakers.Contains(s.Id)).ToList();

					timetables.Add(timetable);
				}
			}

			return timetables
				.OrderBy(t => t.TimeStartHours)
				.ThenBy(t => t.TimeStartMinutes)
				.ThenBy(t => t.Room.RoomType.ToString())
				.ThenBy(t => t.Room.Title)
				.ToList();
		}
	}
}
