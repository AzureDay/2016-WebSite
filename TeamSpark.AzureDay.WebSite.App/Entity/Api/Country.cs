using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.App.Entity.Api
{
	public sealed class Country 
	{

		public Guid Id { get; set; }
		public string Title { get; set; }

	}
}
