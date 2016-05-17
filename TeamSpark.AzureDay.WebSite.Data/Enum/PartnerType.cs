namespace TeamSpark.AzureDay.WebSite.Data.Enum
{
	public enum PartnerType
	{
		VIP = 101,
		Gold = 201,
		Silver = 301,
		Raffle = 401,
		Info = 501,
		Speaker = 601
	}

	public static class PartnerTypeExtension
	{
		public static string ToDisplayString(this PartnerType type)
		{
			switch (type)
			{
				case PartnerType.VIP:
					return "Генеральный партнер";
				case PartnerType.Gold:
					return "Золотые партнеры";
				case PartnerType.Silver:
					return "Серебрянные партнеры";
				case PartnerType.Raffle:
					return "Партнеры по призам";
				case PartnerType.Info:
					return "Информационные партнеры";
				case PartnerType.Speaker:
					return "Партнеры по докладчикам";
				default:
					return string.Empty;
			}
		}
	}
}
