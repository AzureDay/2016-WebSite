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

		public bool HasLanguage
		{
			get { return Topic.Language != null && !string.IsNullOrEmpty(Topic.Language.Title); }
		}

		public Timetable()
		{
			Topic = new Topic();
			Room = new Room();
		}
	}
}
