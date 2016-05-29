using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public class TicketService : TableServiceBase<Ticket>
	{
		protected override string TableName
		{
			get { return "Ticket"; }
		}

		public TicketService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
