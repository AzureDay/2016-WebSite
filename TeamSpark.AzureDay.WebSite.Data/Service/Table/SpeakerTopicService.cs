using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class SpeakerTopicService : TableServiceBase<SpeakerTopic>
	{
		protected override string TableName
		{
			get { return "SpeakerTopic"; }
		}

		public SpeakerTopicService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
