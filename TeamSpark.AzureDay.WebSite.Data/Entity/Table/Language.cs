using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Language : TableEntity
	{
		[IgnoreProperty]
		public Guid Id
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}
		public string Title { get; set; }

		public Language()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
