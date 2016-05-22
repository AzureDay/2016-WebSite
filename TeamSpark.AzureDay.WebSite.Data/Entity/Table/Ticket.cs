using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Ticket : TableEntity
	{
		[IgnoreProperty]
		public Guid AttendeeId
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}

		public bool IsPayed { get; set; }

		public Ticket()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
