using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Host
{
	public sealed class ApplicationInsightInitializer : IContextInitializer
	{
		public void Initialize(TelemetryContext context)
		{
			context.Properties["tags"] = Configuration.ApplicationInsightEnvironmentTag;
		}
	}
}