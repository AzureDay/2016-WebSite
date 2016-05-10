﻿using System.Web.Http;
using System.Web.Mvc;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Schedule()
		{
			return View();
		}

		public ActionResult Redirect([FromUri] string quickAuthToken, [FromUri] string redirectUrl)
		{
			return Redirect(redirectUrl);
		}
	}
}