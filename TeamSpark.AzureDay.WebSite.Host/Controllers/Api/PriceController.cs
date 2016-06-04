using System.Threading.Tasks;
using System.Web.Http;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.Api
{
    public class PriceController : ApiController
    {
		[HttpGet]
		[Route("api/tickets/price")]
	    public async Task<decimal> GetTicketPrice([FromUri]TicketType ticketType, [FromUri]string promoCode)
		{
			decimal ticketPrice = AppFactory.TicketService.Value.GetTicketPrice(ticketType);

			if (!string.IsNullOrEmpty(promoCode))
			{
				var coupon = await AppFactory.CouponService.Value.GetValidCouponByCodeAsync(promoCode);
				if (coupon != null)
				{
					ticketPrice = AppFactory.CouponService.Value.GetPriceWithCoupon(ticketPrice, coupon);
				}
			}

			return ticketPrice;
		}
    }
}
