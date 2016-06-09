using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Kaznachey.KaznacheyPayment;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Enum;
using TeamSpark.AzureDay.WebSite.Host.Filter;
using TeamSpark.AzureDay.WebSite.Host.Models.Profile;
using TeamSpark.AzureDay.WebSite.Notification;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class ProfileController : Controller
	{
		private readonly string _host = "https://azureday.net";

		[Authorize]
		public async Task<ActionResult> My()
		{
			var email = User.Identity.Name;

			var attendeeTask = AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);
			var ticketTask = AppFactory.TicketService.Value.GetTicketByEmailAsync(email);

			await Task.WhenAll(attendeeTask, ticketTask);

			var attendee = attendeeTask.Result;
			var ticket = ticketTask.Result;

			var model = new MyProfileModel
			{
				Email = attendee.EMail,
				LastName = attendee.LastName,
				FirstName = attendee.FirstName,
				Company = attendee.Company
			};

			model.Tickets = new List<TicketModel>();

			if (ticket == null)
			{
				if (DateTime.UtcNow.Month <= 5 && DateTime.UtcNow.Day <= 31 && DateTime.UtcNow.Year == 2016)
				{
					model.Tickets.Add(new TicketModel
					{
						TicketType = TicketType.EarlyBird,
						TicketName = "Ранняя регистрация",
						TicketNotes = ""
					});
				}
				else
				{
					model.Tickets.Add(new TicketModel
					{
						TicketType = TicketType.Regular,
						TicketName = "Стандартный",
						TicketNotes = ""
					});
				}
				model.Tickets.Add(new TicketModel
				{
					TicketType = TicketType.Educational,
					TicketName = "Студенческий",
					TicketNotes = "Для получения бейджа необходимо предъявить действующий студенческий билет в момент регистрации на конференцию."
				});
			}
			else
			{
				model.PayedTicket = ticket;
			}

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public async Task<ActionResult> My(MyProfileModel model)
		{
			var email = User.Identity.Name;
			var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

			attendee.EMail = email;
			attendee.LastName = model.LastName;
			attendee.FirstName = model.FirstName;
			attendee.Company = model.Company;

			if (!string.IsNullOrEmpty(model.Password))
			{
				var salt = AppFactory.AttendeeService.Value.GenerateSalt();
				var passwordHash = AppFactory.AttendeeService.Value.Hash(model.Password, salt);

				attendee.Salt = salt;
				attendee.PasswordHash = passwordHash;
			}

			await AppFactory.AttendeeService.Value.UpdateProfileAsync(attendee);

			return RedirectToAction("My");
		}

		[NonAuthorize]
		public ActionResult Registration()
		{
			return View(new RegistrationModel());
		}

		[NonAuthorize]
		[HttpPost]
		public async Task<ActionResult> Registration(RegistrationModel model)
		{
			var attendeeExisted = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(model.Email);
			if (attendeeExisted != null)
			{
				model.ErrorMessage = "Пользователь с таким адресом электронной почты уже есть в системе. Если вы забыли пароль, то воспользуйтесь функцией восстановления пароля на странице входа в личный кабинет.";

				model.Password = string.Empty;
				return View(model);
			}

			var salt = AppFactory.AttendeeService.Value.GenerateSalt();
			var passwordHash = AppFactory.AttendeeService.Value.Hash(model.Password, salt);

			var attendee = new Attendee
			{
				EMail = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Company = model.Company,
				Salt = salt,
				PasswordHash = passwordHash
			};
			
			await AppFactory.AttendeeService.Value.RegisterAsync(attendee);

			return RedirectToAction("ConfirmRegistration");
		}

		[NonAuthorize]
		public async Task<ActionResult> ConfirmRegistration(string token)
		{
			if (string.IsNullOrEmpty(token))
			{
				return View("ConfirmEmail");
			}

			var authToken = await AppFactory.QuickAuthTokenService.Value.GetQuickAuthTokenByValueAsync(token, false);

			if (authToken == null)
			{
				return Redirect("~/");
			}

			await AppFactory.AttendeeService.Value.ConfirmRegistrationByTokenAsync(token);

			return View("ConfirmRegistration");
		}

		[NonAuthorize]
		public ActionResult LogIn()
		{
			var model = new LoginModel();
			return View(model);
		}

		[NonAuthorize]
		[HttpPost]
		public async Task<ActionResult> LogIn(LoginModel model)
		{
			var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(model.Email);

			if (attendee == null)
			{
				model.Password = string.Empty;
				model.ErrorMessage = "Неверный email или пароль";
				return View(model);
			}

			if (attendee.IsConfirmed && AppFactory.AttendeeService.Value.IsPasswordValid(attendee, model.Password))
			{
				FormsAuthentication.SetAuthCookie(attendee.EMail, true);
				var url = FormsAuthentication.GetRedirectUrl(attendee.EMail, true);
				return Redirect(url);
			}
			else
			{
				model.Password = string.Empty;
				model.ErrorMessage = "Неверный email или пароль";
				return View(model);
			}
		}

		[Authorize]
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			return Redirect("~/");
		}

		private PayFormModel GetPaymentForm(Ticket ticket)
		{
			KaznacheyPaymentSystem kaznachey;
			int paySystemId;
			switch (ticket.PaymentType.ToLowerInvariant())
			{
				case "kaznackey":
					kaznachey = new KaznacheyPaymentSystem(Configuration.KaznackeyMerchantId, Configuration.KaznackeyMerchantSecreet);
					paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
					break;
				case "liqpay":
					kaznachey = new KaznacheyPaymentSystem(Configuration.LiqPayMerchantId, Configuration.LiqPayMerchantSecreet);
					paySystemId = kaznachey.GetMerchantInformation().PaySystems[3].Id;
					break;
				default:
					kaznachey = new KaznacheyPaymentSystem(Configuration.KaznackeyMerchantId, Configuration.KaznackeyMerchantSecreet);
					paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
					break;
			}

			var paymentRequest = new PaymentRequest(paySystemId);
			paymentRequest.Language = "RU";
			paymentRequest.Currency = "UAH";
			paymentRequest.PaymentDetail = new PaymentDetails
			{
				EMail = ticket.Attendee.EMail,
				MerchantInternalUserId = ticket.Attendee.EMail,
				MerchantInternalPaymentId = string.Format("{0}-{1}", ticket.Attendee.EMail, ticket.TicketType),
				BuyerFirstname = ticket.Attendee.FirstName,
				BuyerLastname = ticket.Attendee.LastName,
				ReturnUrl = string.Format("{0}/profile/my", _host),
				StatusUrl = string.Format("{0}/api/tickets/paymentconfirm", _host)
			};
			paymentRequest.Products = new List<Product>
			{
				new Product
				{
					ProductId = ticket.TicketType.ToString(),
					ProductItemsNum = 1,
					ProductName = string.Format("{0} {1} билет на AzureDay {2} ({3})",
						ticket.Attendee.FirstName,
						ticket.Attendee.LastName,
						Configuration.Year,
						ticket.TicketType.ToDisplayString()),
					ProductPrice = (decimal) ticket.Price
				}
			};

			var form = kaznachey.CreatePayment(paymentRequest).ExternalFormHtml;

			var model = new PayFormModel
			{
				Form = form
			};
			return model;
		}

		[Authorize]
		[HttpPost]
		public async Task<ActionResult> Pay(PayModel model)
		{
			decimal ticketPrice = AppFactory.TicketService.Value.GetTicketPrice(model.TicketType);

			var ticket = new Ticket
			{
				Price = (double)ticketPrice,
				TicketType = model.TicketType,
				PaymentType = model.PaymentType
			};

			if (!string.IsNullOrEmpty(model.PromoCode))
			{
				var coupon = await AppFactory.CouponService.Value.GetValidCouponByCodeAsync(model.PromoCode);
				if (coupon != null)
				{
					ticketPrice = AppFactory.CouponService.Value.GetPriceWithCoupon(ticketPrice, coupon);
					await AppFactory.CouponService.Value.UseCouponByCodeAsync(model.PromoCode);

					ticket.Price = (double)ticketPrice;
					ticket.Coupon = coupon;
				}
			}

			ticket.IsPayed = ticket.Price <= 0;

			if (ticket.Attendee == null)
			{
				var email = User.Identity.Name;
				ticket.Attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);
			}

			await AppFactory.TicketService.Value.AddTicketAsync(ticket);

			if (ticket.IsPayed)
			{
				return RedirectToAction("My");
			}
			else
			{
				if (ticket.Attendee == null)
				{
					var email = User.Identity.Name;
					ticket.Attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);
				}

				var payForm = GetPaymentForm(ticket);

				return View("PayForm", payForm);
			}
		}

		[Authorize]
		public async Task<ActionResult> PayAgain()
		{
			var email = User.Identity.Name;

			var ticketTask = AppFactory.TicketService.Value.GetTicketByEmailAsync(email);
			var attendeeTask = AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

			await Task.WhenAll(ticketTask, attendeeTask);

			var ticket = ticketTask.Result;
			ticket.Attendee = attendeeTask.Result;

			var model = GetPaymentForm(ticket);

			return View("PayForm", model);
		}

		[Authorize]
		public async Task<ActionResult> DeleteTicket()
		{
			var email = User.Identity.Name;

			var ticket = await AppFactory.TicketService.Value.GetTicketByEmailAsync(email);

			await Task.WhenAll(
				AppFactory.TicketService.Value.DeleteTicketAsync(email),
				AppFactory.CouponService.Value.RestoreCouponByCodeAsync(ticket.Coupon == null ? string.Empty : ticket.Coupon.Code)
			);
			
			return RedirectToAction("My");
		}

		[NonAuthorize]
		[HttpPost]
		public async Task<ActionResult> RestorePassword(LoginModel model)
		{
			var user = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(model.Email);

			if (user != null)
			{
				var token = new QuickAuthToken
				{
					Email = user.EMail,
					Token = Guid.NewGuid().ToString("N")
				};

				var notification = new RestorePasswordMessage
				{
					Email = user.EMail,
					FullName = user.FullName,
					Token = token.Token
				};

				await Task.WhenAll(
					AppFactory.QuickAuthTokenService.Value.AddQuickAuthTokenAsync(token),
					NotificationFactory.AttendeeNotificationService.Value.SendRestorePasswordEmailAsync(notification)
				);
			}

			return View();
		}

		//[Authorize]
		//public ActionResult Quiz()
		//{
		//	return View();
		//}

		//[Authorize]
		//public ActionResult Feedback()
		//{
		//	return View();
		//}
	}
}