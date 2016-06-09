using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public sealed class Ticket
	{
		public Attendee Attendee { get; set; }

		public bool IsPayed { get; set; }

		public Coupon Coupon { get; set; }

		public TicketType TicketType { get; set; }

		public double Price { get; set; }

		public string PaymentType { get; set; }
	}
}
