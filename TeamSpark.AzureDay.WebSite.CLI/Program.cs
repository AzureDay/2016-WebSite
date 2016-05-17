using System;
using TeamSpark.AzureDay.WebSite.CLI.Data;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			DataFactory.InitializeAsync().Wait();

			//Speaker.Add();
			//Country.Add();
			//Room.Add();
			//Language.Add();
			//Timetable.Add();
			//SpeakerTopic.Add();
			Partner.Add();

			Console.WriteLine("Press 'enter' to close.");
			Console.ReadLine();
		}
	}
}
