using System.Web.Mvc;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class LayoutController : Controller
	{
		[ChildActionOnly]
		public ActionResult Header()
		{
			return View("_Header");
		}

		[ChildActionOnly]
		public ActionResult Banner()
		{
			return View("_Banner");
		}

		[ChildActionOnly]
		public ActionResult Footer()
		{
			return View("_Footer");
		}
	}
}