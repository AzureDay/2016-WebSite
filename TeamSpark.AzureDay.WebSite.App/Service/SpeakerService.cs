using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class SpeakerService
	{
		public async Task<List<Speaker>> GetSpeakersAsync()
		{
			var speakersTask = DataFactory.SpeakerService.Value.GetByPartitionKeyAsync(Configuration.Year);
			var countriesTask = DataFactory.CountryService.Value.GetByPartitionKeyAsync(Configuration.Year);

			await Task.WhenAll(speakersTask, countriesTask);

			var countries = await countriesTask;

			var speakers = (await speakersTask)
				.OrderBy(s => s.FirstName)
				.ThenBy(s => s.LastName)
				.Select(s =>
				{
					var speaker = Mapper.Map<Speaker>(s);

					speaker.Country = Mapper.Map<Country>(countries.Single(c => c.Id == s.CountryId));

					return speaker;
				})
				.ToList();

			return speakers;
		}
	}
}
