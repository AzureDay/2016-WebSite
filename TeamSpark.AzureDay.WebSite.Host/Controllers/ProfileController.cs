using System.Threading.Tasks;
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
		public async Task<ActionResult> My()
		{
			var email = User.Identity.Name;
			var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

			var model = new MyProfileModel
			{
				Email = attendee.EMail,
				LastName = attendee.LastName,
				FirstName = attendee.FirstName,
				Company = attendee.Company
			};

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

			await AppFactory.AttendeeService.Value.UpdateProfileAsync(attendee);

			return RedirectToAction("My");
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