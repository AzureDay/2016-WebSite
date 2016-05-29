using TeamSpark.AzureDay.WebSite.Data.Entity.Table;

namespace TeamSpark.AzureDay.WebSite.Data.Service.Table
{
	public class CouponService : TableServiceBase<Coupon>
	{
		protected override string TableName
		{
			get { return "Coupon"; }
		}

		public CouponService(string accountName, string accountKey)
			: base(accountName, accountKey)
		{
		}
	}
}
