using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.App.Entity.Api
{
	public sealed class Topic 
	{

		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Guid LanguageId { get; set; }

	}
}
