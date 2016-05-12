namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public sealed class Attendee
	{
		public string EMail { get; set; }

		public byte[] Salt { get; set; }
		public byte[] PasswordHash { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public bool IsConfirmed { get; set; }

		public Ticket Ticket { get; set; }

		public Attendee()
		{
			IsConfirmed = false;

			Ticket = new Ticket
			{
				IsPayed = false
			};
		}
	}
}
