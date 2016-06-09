using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Kaznachey.KaznacheyPayment;
using Microsoft.ApplicationInsights;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.Data.Enum;
using TeamSpark.AzureDay.WebSite.Notification;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;

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

		[HttpPost]
		[Route("api/tickets/paymentconfirm")]
		public async Task<string> PaymentConfirm([FromBody]PaymentResponse response)
		{
			var email = response.MerchantInternalUserId;
			var ticket = await AppFactory.TicketService.Value.GetTicketByEmailAsync(email);

			if (ticket != null)
			{
				if (response.ErrorCode != 0)
				{
					var ai = new TelemetryClient();

					var props = new Dictionary<string, string>();
					props.Add("MerchantInternalPaymentId", response.MerchantInternalPaymentId);
					props.Add("MerchantInternalUserId", response.MerchantInternalUserId);
					props.Add("OrderId", response.OrderId.ToString());
					props.Add("ErrorCode", response.ErrorCode.ToString());
					props.Add("DebugMessage", response.DebugMessage);
					props.Add("Sum", response.Sum.ToString("F"));
					props.Add("OrderSum", response.OrderSum.ToString("F"));

					ai.TrackEvent("Payment error", props);

					var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

					var message = new ErrorPaymentModel
					{
						Email = attendee.EMail,
						FullName = attendee.FullName
					};

					await Task.WhenAll(
						AppFactory.TicketService.Value.DeleteTicketAsync(email),
						NotificationFactory.AttendeeNotificationService.Value.SendPaymentErrorEmailAsync(message)
					);
				}
				else
				{
					var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

					var message = new ConfirmPaymentModel
					{
						Email = attendee.EMail,
						FullName = attendee.FullName
					};

					await Task.WhenAll(
						AppFactory.TicketService.Value.SetTicketPayedAsync(email),
						NotificationFactory.AttendeeNotificationService.Value.SendPaymentConfirmationEmailAsync(message)
					);
				}
			}
			else
			{
				var ai = new TelemetryClient();

				var props = new Dictionary<string, string>();
				props.Add("MerchantInternalPaymentId", response.MerchantInternalPaymentId);
				props.Add("MerchantInternalUserId", response.MerchantInternalUserId);
				props.Add("OrderId", response.OrderId.ToString());
				props.Add("ErrorCode", response.ErrorCode.ToString());
				props.Add("DebugMessage", response.DebugMessage);
				props.Add("Sum", response.Sum.ToString("F"));
				props.Add("OrderSum", response.OrderSum.ToString("F"));

				ai.TrackEvent("Unable to find ticket", props);
			}

			return string.Empty;
		}
	}
}
