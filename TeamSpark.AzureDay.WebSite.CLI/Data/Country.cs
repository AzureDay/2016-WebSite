using System;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Country
	{
		internal static void Add()
		{
			Console.WriteLine("Add speaker");
			var country = new WebSite.Data.Entity.Table.Country
			{
				Id = Guid.NewGuid()
			};

			Console.Write("Title: ");
			country.Title = Console.ReadLine();

			Console.WriteLine("Working...");
			DataFactory.CountryService.Value.InsertAsync(country).Wait();
			Console.WriteLine("Done.");
		}
	}
}
