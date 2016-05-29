using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class SpeakersModel
	{
		public List<List<Speaker>> SpeakersCollections { get; set; }
	}
}