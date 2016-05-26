using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class CouponService
	{
		public async Task<Coupon> GetValidCouponByCodeAsync(string code)
		{
			var coupon = await DataFactory.CouponService.Value.GetByKeysAsync(Configuration.Year, code);

			if (coupon == null)
			{
				return null;
			}

			if (!coupon.IsEnabled)
			{
				return null;
			}

			if (!coupon.IsInfinite && coupon.CouponsCount <= 0)
			{
				return null;
			}

			return AppFactory.Mapper.Value.Map<Coupon>(coupon);
		}

		public async Task UseCouponByCodeAsync(string code)
		{
			var coupon = await DataFactory.CouponService.Value.GetByKeysAsync(Configuration.Year, code);

			if (!coupon.IsInfinite)
			{
				coupon.CouponsCount--;
				await DataFactory.CouponService.Value.ReplaceAsync(coupon);
			}
		}

		public decimal GetPriceWithCoupon(decimal price, Coupon coupon)
		{
			var newPrice = price;

			switch (coupon.DiscountType)
			{
				case DiscountType.Amount:
					newPrice = price - coupon.DiscountAmount;
					if (newPrice < 0)
					{
						newPrice = 0;
					}
					break;

				case DiscountType.Percentage:
					newPrice = price * ((100 - coupon.DiscountAmount) / 100);
					break;
			}

			return newPrice;
		}
	}
}
