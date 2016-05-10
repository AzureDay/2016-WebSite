using System;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Timetable
	{
		public Topic Topic { get; set; }
		public Room Room { get; set; }
		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }

		public Timetable()
		{
			Topic = new Topic();
			Room = new Room();
		}
	}
}
