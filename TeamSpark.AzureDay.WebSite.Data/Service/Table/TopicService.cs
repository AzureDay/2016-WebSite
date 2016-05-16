using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class TopicService : TableServiceBase<Topic>
	{
		protected override string TableName
		{
			get { return "Topic"; }
		}

		public TopicService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
