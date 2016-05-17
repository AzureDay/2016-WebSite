using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Partner : TableEntity
	{
		[IgnoreProperty]
		public Guid Id
		{
			get { return Guid.Parse(RowKey); }
			set { RowKey = value.ToString("N"); }
		}
		public string Title { get; set; }
		public string LogoUrl { get; set; }
		public string WebUrl { get; set; }
		public string Description { get; set; }
		public int OrderN { get; set; }

		[IgnoreProperty]
		public PartnerType PartnerType
		{
			get { return (PartnerType)PartnerTypeId; }
			set { PartnerTypeId = (int)value; }
		}

		public int PartnerTypeId { get; set; }

		public Partner()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
