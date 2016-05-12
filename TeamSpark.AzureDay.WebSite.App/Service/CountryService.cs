using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class CountryService
	{
		public async Task<List<Country>> GetCountriesAsync()
		{
			var countries = await DataFactory.CountryService.Value.GetByPartitionKeyAsync(Config.Configuration.Year);

			return countries
				.Select(c => Mapper.Map<Country>(c))
				.ToList();
		}
	}
}
