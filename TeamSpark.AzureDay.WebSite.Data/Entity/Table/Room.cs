using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	sealed class Room : TableEntity
	{
		[IgnoreProperty]
		public Guid Id
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}
		public string Title { get; set; }

		[IgnoreProperty]
		public RoomType RoomType
		{
			get { return (RoomType)RoomTypeId; }
			set { RoomTypeId = (int)value; }
		}

		public int RoomTypeId { get; set; }

		public Room()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
