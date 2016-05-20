using System;
using System.Collections.Generic;
using System.Linq;
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

			var coffeeRoomId = "f05b87486e2e46a9a1d4dedc74087bc8";
			for (var i = 1; i <= 3; i++)
			{
				var topic = new WebSite.Data.Entity.Table.Topic
				{
					Id = Guid.NewGuid(),
					Title = string.Format("Coffee {1}", coffeeRoomId, i),
					Description = "Тема в процессе формирования.",
					LanguageId = Guid.Parse("05cd0801f82c4428bd84ab10e31ec528")
				};

				var timeTable = new WebSite.Data.Entity.Table.Timetable
				{
					RoomId = Guid.Parse(coffeeRoomId),
					TopicId = topic.Id,
					TimeStartHours = i,
					TimeEndHours = i,
					TimeStartMinutes = 0,
					TimeEndMinutes = 0
				};

				DataFactory.TopicService.Value.InsertAsync(topic).Wait();
				DataFactory.TimetableService.Value.InsertAsync(timeTable).Wait();
			}

			// merged
			//for (var i = 1; i <= 3; i++)
			//{
			//	var roomId = "0b67e087498043cfa0a5f32a02d4bdb3";

			//	var topic = new WebSite.Data.Entity.Table.Topic
			//	{
			//		Id = Guid.NewGuid(),
			//		Title = string.Format("Merged {1}", roomId, i),
			//		Description = "Тема в процессе формирования.",
			//		LanguageId = Guid.Parse("05cd0801f82c4428bd84ab10e31ec528")
			//	};

			//	var timeTable = new WebSite.Data.Entity.Table.Timetable
			//	{
			//		RoomId = Guid.Parse(roomId),
			//		TopicId = topic.Id,
			//		TimeStartHours = i,
			//		TimeEndHours = i,
			//		TimeStartMinutes = 0,
			//		TimeEndMinutes = 0
			//	};

			//	DataFactory.TopicService.Value.InsertAsync(topic).Wait();
			//	DataFactory.TimetableService.Value.InsertAsync(timeTable).Wait();
			//}

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

		public static void Move()
		{
			Console.WriteLine("Move timetable");

			var timetablesTask = DataFactory.TimetableService.Value.GetAllAsync();
			timetablesTask.Wait();

			var timetables = timetablesTask.Result;

			var timetablesGroups = timetables
				.OrderBy(t => t.TimeStartHours)
				.ThenBy(t => t.TimeStartMinutes)
				.GroupBy(t => string.Format("{0}:{1}", t.TimeStartHours, t.TimeStartMinutes))
				.ToList();

			var i = 0;
			foreach (var timetablesGroup in timetablesGroups)
			{
				Console.WriteLine("{0}. {1}", i, timetablesGroup.Key);
				i++;
			}
			Console.Write("Chose group: ");
			var index = int.Parse(Console.ReadLine());

			Console.Write("New start hour: ");
			var startHour = int.Parse(Console.ReadLine());
			Console.Write("New start minute: ");
			var startMinute = int.Parse(Console.ReadLine());
			Console.Write("New end hour: ");
			var endHour = int.Parse(Console.ReadLine());
			Console.Write("New end minute: ");
			var endMinute = int.Parse(Console.ReadLine());

			var entities = timetablesGroups[index];
			foreach (var timetable in entities)
			{
				timetable.TimeStartHours = startHour;
				timetable.TimeStartMinutes = startMinute;
				timetable.TimeEndHours = endHour;
				timetable.TimeEndMinutes = endMinute;
				Console.WriteLine("Processing...");
				DataFactory.TimetableService.Value.ReplaceAsync(timetable).Wait();
				Console.WriteLine("Done.");
			}
			Console.WriteLine("Done-done.");
		}
	}
}
