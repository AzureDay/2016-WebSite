using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class PartnerService : TableServiceBase<Partner>
	{
		protected override string TableName
		{
			get { return "Partner"; }
		}

		public PartnerService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
