using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Attendee : TableEntity
	{
		[IgnoreProperty]
		public string EMail
		{
			get { return RowKey; }
			set { RowKey = value; }
		}

		public byte[] Salt { get; set; }
		public byte[] PasswordHash { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public bool IsConfirmed { get; set; }

		public Attendee()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
