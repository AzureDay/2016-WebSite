using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public sealed class RoomService : TableServiceBase<Room>
	{
		protected override string TableName
		{
			get { return "Room"; }
		}

		public RoomService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
