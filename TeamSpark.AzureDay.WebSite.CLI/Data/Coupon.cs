using System;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Coupon
	{
		internal static void Add()
		{
			Console.WriteLine("Add coupon");
			var coupon = new WebSite.Data.Entity.Table.Coupon
			{
				IsEnabled = true
			};

			Console.Write("Code: ");
			coupon.Code = Console.ReadLine().ToLowerInvariant();

			Console.WriteLine("Discount type:");
			foreach (DiscountType discountType in Enum.GetValues(typeof(DiscountType)))
			{
				Console.WriteLine("{0} {1}", (int)discountType, discountType);
			}
			coupon.DiscountTypeId = int.Parse(Console.ReadLine());

			Console.Write("Discount amount: ");
			coupon.DiscountAmountValue = float.Parse(Console.ReadLine());

			Console.Write("Is infinite: ");
			coupon.IsInfinite = bool.Parse(Console.ReadLine());

			if (!coupon.IsInfinite)
			{
				Console.Write("Count: ");
				coupon.CouponsCount = int.Parse(Console.ReadLine());
			}

			Console.WriteLine("Working...");
			DataFactory.CouponService.Value.InsertAsync(coupon).Wait();
			Console.WriteLine("Done.");
		}
	}
}
