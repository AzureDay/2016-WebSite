using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class ScheduleModel
	{
		public List<Room> Rooms { get; set; }

		public List<List<Timetable>> Timetables { get; set; }
	}
}