using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class SpeakerService : TableServiceBase<Speaker>
	{
		protected override string TableName
		{
			get { return "Speaker"; }
		}

		public SpeakerService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
