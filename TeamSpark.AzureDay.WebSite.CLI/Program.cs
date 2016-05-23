﻿using System;
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
			//Timetable.Move();
			//SpeakerTopic.Add();
			//SpeakerTopic.Add();
			//Partner.Add();
			Timetable.Switch();
			
			Console.WriteLine("Press 'enter' to close.");
			Console.ReadLine();
		}
	}
}
