using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public class QuickAuthToken : TableEntity
	{
		[IgnoreProperty]
		public string Token
		{
			get { return RowKey; }
			set { RowKey = value; }
		}

		public string Email { get; set; }
		public bool IsUsed { get; set; }

		public QuickAuthToken()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
