using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Profile
{
	public sealed class PayModel
	{
		public TicketType TicketType { get; set; }
		public string PromoCode { get; set; }
		public string PaymentType { get; set; }
	}
}