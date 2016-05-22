using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class PartnersModel
	{
		public Dictionary<PartnerType, List<Partner>> PartnersCollection { get; set; }
	}
}