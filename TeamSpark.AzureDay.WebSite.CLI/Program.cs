using System;
using TeamSpark.AzureDay.WebSite.CLI.Data;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			//DataFactory.InitializeAsync().Wait();

			//Speaker.Add();
			Country.Add();

			Console.WriteLine("Press 'enter' to close.");
			Console.ReadLine();
		}
	}
}
