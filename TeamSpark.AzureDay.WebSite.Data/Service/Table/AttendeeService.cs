using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public class AttendeeService : TableServiceBase<Attendee>
	{
		protected override string TableName
		{
			get { return "Attendee"; }
		}

		public AttendeeService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
