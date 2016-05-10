using System;
using System.Web.Mvc;
using System.Web.Security;
using TeamSpark.AzureDay.WebSite.Host.Models.Profile;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class ProfileController : Controller
	{
		public ActionResult My()
		{
			return View();
		}

		public ActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Registration(RegistrationModel model)
		{
			throw new NotImplementedException();
		}

		public ActionResult LogIn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogIn(LoginModel model)
		{
			throw new NotImplementedException();
		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			return Redirect("~/");
		}

		public ActionResult Quiz()
		{
			return View();
		}

		public ActionResult Feedback()
		{
			return View();
		}
	}
}