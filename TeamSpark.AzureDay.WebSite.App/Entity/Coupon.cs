using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public sealed class Coupon
	{
		public string Code
		{ get; set; }

		public DiscountType DiscountType
		{ get; set; }

		public decimal DiscountAmount
		{ get; set; }

		public bool IsEnabled { get; set; }

		public bool IsInfinite { get; set; }

		public int? CouponsCount { get; set; }
	}
}
