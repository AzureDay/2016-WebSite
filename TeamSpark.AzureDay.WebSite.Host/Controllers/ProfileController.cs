﻿using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Host.Filter;
using TeamSpark.AzureDay.WebSite.Host.Models.Profile;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class ProfileController : Controller
	{
		[Authorize]
		public ActionResult My()
		{
			return View();
		}

		[NonAuthorize]
		public ActionResult Registration()
		{
			return View();
		}

		[NonAuthorize]
		[HttpPost]
		public async Task<ActionResult> Registration(RegistrationModel model)
		{
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

			return Redirect("~/");
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

		[Authorize]
		public ActionResult Quiz()
		{
			return View();
		}

		[Authorize]
		public ActionResult Feedback()
		{
			return View();
		}
	}
}