using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class QuickAuthTokenService : TableServiceBase<QuickAuthToken>
	{
		protected override string TableName
		{
			get { return "QuickAuthToken"; }
		}

		public QuickAuthTokenService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
