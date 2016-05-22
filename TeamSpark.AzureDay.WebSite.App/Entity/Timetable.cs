using System;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Timetable
	{
		public Topic Topic { get; set; }
		public Room Room { get; set; }
		public int TimeStartHours { get; set; }
		public int TimeStartMinutes { get; set; }

		public int TimeEndHours { get; set; }
		public int TimeEndMinutes { get; set; }

		public Timetable()
		{
			Topic = new Topic();
			Room = new Room();
		}
	}
}
