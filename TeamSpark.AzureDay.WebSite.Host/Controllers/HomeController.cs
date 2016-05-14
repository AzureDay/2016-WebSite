using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Nito.AsyncEx;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Host.Models.Home;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class HomeController : Controller
	{
		public async Task<ActionResult> Index()
		{
			return View();
		}

		public async Task<ActionResult> Schedule()
		{
			return View();
		}

		public async Task<ActionResult> Redirect([FromUri] string quickAuthToken, [FromUri] string redirectUrl)
		{
			return Redirect(redirectUrl);
		}

		[ChildActionOnly]
		public ActionResult Speakers()
		{
			var model = new SpeakersModel
			{
				SpeakersCollections = new List<List<Speaker>>()
			};

			var speakers = AsyncContext.Run(() => AppFactory.SpeakerService.Value.GetSpeakersAsync());
			var i = 0;
			foreach (var speaker in speakers)
			{
				List<Speaker> list;
				if (i == 0)
				{
					list = new List<Speaker>();
					model.SpeakersCollections.Add(list);
				}
				else
				{
					list = model.SpeakersCollections.Last();
				}

				list.Add(speaker);

				if (i == 3)
				{
					i = 0;
				}
				else
				{
					i++;
				}
			}

			return View("_Speakers", model);
		}
	}
}