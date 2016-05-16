using System;
using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Timetable
	{
		internal static void Add()
		{
			Console.WriteLine("Add timetable");

			var rooms = new List<string>
			{
				"0b67e087498043cfa0a5f32a02d4bdb3", //dev
				"221b1c6fecdd4e218a9ddf84fd1e5c3b", //work
				"748802a3a8a34ebe9945b2a321da438b", //it
				"83d518c5927a4d0488aeb7c1e1f17cda" //ops
			};

			// merged

			for (var i = 1; i <= 3; i++)
			{
				var roomId = "0b67e087498043cfa0a5f32a02d4bdb3";

				var topic = new WebSite.Data.Entity.Table.Topic
				{
					Id = Guid.NewGuid(),
					Title = string.Format("Merged {1}", roomId, i),
					Description = "Тема в процессе формирования.",
					LanguageId = Guid.Parse("05cd0801f82c4428bd84ab10e31ec528")
				};

				var timeTable = new WebSite.Data.Entity.Table.Timetable
				{
					RoomId = Guid.Parse(roomId),
					TopicId = topic.Id,
					TimeStartHours = i,
					TimeEndHours = i,
					TimeStartMinutes = 0,
					TimeEndMinutes = 0
				};

				DataFactory.TopicService.Value.InsertAsync(topic).Wait();
				DataFactory.TimetableService.Value.InsertAsync(timeTable).Wait();
			}

			// regular
			//for (var i = 1; i <= 6; i++)
			//{
			//	foreach (var roomId in rooms)
			//	{
			//		var topic = new WebSite.Data.Entity.Table.Topic
			//		{
			//			Id = Guid.NewGuid(),
			//			Title = string.Format("{0} {1}", roomId, i),
			//			Description = "Тема в процессе формирования.",
			//			LanguageId = Guid.Parse("05cd0801f82c4428bd84ab10e31ec528")
			//		};

			//		var timeTable = new WebSite.Data.Entity.Table.Timetable
			//		{
			//			RoomId = Guid.Parse(roomId),
			//			TopicId = topic.Id,
			//			TimeStartHours = i,
			//			TimeEndHours = i,
			//			TimeStartMinutes = 0,
			//			TimeEndMinutes = 0
			//		};

			//		DataFactory.TopicService.Value.InsertAsync(topic).Wait();
			//		DataFactory.TimetableService.Value.InsertAsync(timeTable).Wait();
			//	}
			//}
		}
	}
}
