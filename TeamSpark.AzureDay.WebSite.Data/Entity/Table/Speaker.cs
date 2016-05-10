using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	sealed class Speaker : TableEntity
	{
		[IgnoreProperty]
		public Guid Id
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhotoUrl { get; set; }
		public string Bio { get; set; }
		public Guid CountryId { get; set; }

		public Speaker()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
