namespace TeamSpark.AzureDay.WebSite.Data.Enum
{
	public enum TicketType
	{
		EarlyBird = 101,
		Regular = 201,
		Educational = 301
	}

	public static class TicketTypeExtension
	{
		public static string ToDisplayString(this TicketType ticketType)
		{
			switch (ticketType)
			{
				case TicketType.EarlyBird:
					return "Early Bird";
				case TicketType.Educational:
					return "Educational";
				case TicketType.Regular:
					return "Regular";
			}

			return string.Empty;
		}
	}
}
