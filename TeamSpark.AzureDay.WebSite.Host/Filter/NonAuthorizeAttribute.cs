using System.Web.Mvc;

namespace TeamSpark.AzureDay.WebSite.Host.Filter
{
	public class NonAuthorizeAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Request.IsAuthenticated)
			{
				filterContext.Result = new RedirectResult("~/");
			}

			base.OnActionExecuting(filterContext);
		}
	}
}