using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	sealed class Topic : TableEntity
	{
		[IgnoreProperty]
		public Guid Id
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}
		public string Title { get; set; }
		public string Description { get; set; }
		public Guid LanguageId { get; set; }

		public Topic()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
