using System.Web.Mvc;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}