using System;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Language
	{
		internal static void Add()
		{
			Console.WriteLine("Add Language");
			var language = new WebSite.Data.Entity.Table.Language
			{
				Id = Guid.NewGuid()
			};

			Console.Write("Title: ");
			language.Title = Console.ReadLine();

			Console.WriteLine("Working...");
			DataFactory.LanguageService.Value.InsertAsync(language).Wait();
			Console.WriteLine("Done.");
		}
	}
}
