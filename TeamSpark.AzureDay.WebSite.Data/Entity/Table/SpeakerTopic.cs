using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	sealed class SpeakerTopic : TableEntity
	{
		[IgnoreProperty]
		public Guid SpeakerId
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}

		[IgnoreProperty]
		public Guid TopicId
		{
			get { return Guid.Parse(PartitionKey); }
			set { PartitionKey = value.ToString("N"); }
		}

		public int OrderN { get; set; }
	}
}
