using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class LanguageService : TableServiceBase<Language>
	{
		protected override string TableName
		{
			get { return "Language"; }
		}

		public LanguageService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
