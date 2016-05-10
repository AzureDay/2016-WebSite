using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	sealed class Timetable : TableEntity
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

		public DateTime TimeStart { get; set; }
		public DateTime TimeEnd { get; set; }
	}
}
