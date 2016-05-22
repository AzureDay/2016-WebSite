using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Timetable : TableEntity
	{
		[IgnoreProperty]
		public Guid TopicId
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}

		[IgnoreProperty]
		public Guid RoomId
		{
			get { return Guid.Parse(PartitionKey); }
			set { PartitionKey = value.ToString("N"); }
		}

		public int TimeStartHours { get; set; }
		public int TimeStartMinutes { get; set; }

		public int TimeEndHours { get; set; }
		public int TimeEndMinutes { get; set; }
	}
}
