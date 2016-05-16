using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class TimetableService : TableServiceBase<Timetable>
	{
		protected override string TableName
		{
			get { return "Timetable"; }
		}

		public TimetableService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
