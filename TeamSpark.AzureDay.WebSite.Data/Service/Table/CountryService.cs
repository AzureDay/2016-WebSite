using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class CountryService : TableServiceBase<Country>
	{
		protected override string TableName
		{
			get { return "Country"; }
		}

		public CountryService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
