using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class PartnerService
	{
		public async Task<List<Partner>> GetPartnersAsync()
		{
			var partners = await DataFactory.PartnerService.Value.GetByPartitionKeyAsync(Config.Configuration.Year);

			return partners
				.OrderBy(p => p.PartnerTypeId)
				.ThenBy(p => p.OrderN)
				.Select(p => AppFactory.Mapper.Value.Map<Partner>(p))
				.ToList();
		}
	}
}
