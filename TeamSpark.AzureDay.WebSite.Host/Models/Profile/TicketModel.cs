using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Profile
{
	public sealed class TicketModel
	{
		public TicketType TicketType { get; set; }
		public string TicketName { get; set; }
		public string TicketNotes { get; set; }
	}
}