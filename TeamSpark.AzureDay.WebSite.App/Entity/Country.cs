using System;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Country
	{
		public Guid Id { get; set; }
		public string Title { get; set; }

		public string GetImageUrl()
		{
			return string.Format("https://{0}.blob.core.windows.net/azureday/{1}/countries/{2}.GIF", Configuration.AzureStorageAccountName, Configuration.Year, Id.ToString("N"));
		}
	}
}
