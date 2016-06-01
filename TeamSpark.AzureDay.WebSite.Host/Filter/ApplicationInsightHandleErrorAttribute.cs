using System;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;
using System.Collections.Generic;

namespace TeamSpark.AzureDay.WebSite.Host.Filter
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public class ApplicationInsightHandleErrorAttribute : HandleErrorAttribute
	{
		public override void OnException(ExceptionContext filterContext)
		{
			if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
			{
				//If customError is Off, then AI HTTPModule will report the exception
				if (filterContext.HttpContext.IsCustomErrorEnabled)
				{
					string email;
					try
					{
						email = filterContext.HttpContext.User.Identity.Name;
					}
					catch
					{
						email = "unknown";
					}

					var properties = new Dictionary<string, string>();
					properties.Add("AzureDayUserEmail", email);

					// Note: A single instance of telemetry client is sufficient to track multiple telemetry items.
					var ai = new TelemetryClient();
					ai.TrackException(filterContext.Exception, properties);
				}
			}
			base.OnException(filterContext);
		}
	}
}