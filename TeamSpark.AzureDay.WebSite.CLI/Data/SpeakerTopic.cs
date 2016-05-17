using System;
using System.Linq;
using Nito.AsyncEx;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class SpeakerTopic
	{
		internal static void Add()
		{
			Console.WriteLine("Add speaker to topic");


			var speakers = AsyncContext.Run(() => DataFactory.SpeakerService.Value.GetByPartitionKeyAsync(Configuration.Year)).OrderBy(s => s.FirstName).ThenBy(s => s.LastName).ToList();

			for (var i = 0; i < speakers.Count; i++)
			{
				Console.WriteLine("{0}. {1} {2}", i, speakers[i].FirstName, speakers[i].LastName);
			}

			Console.Write("Chose speaker: ");
			var speakerNumber = int.Parse(Console.ReadLine());


			var topics = AsyncContext.Run(() => DataFactory.TopicService.Value.GetByPartitionKeyAsync(Configuration.Year)).OrderBy(t => t.Title).ToList();

			for (var i = 0; i < topics.Count; i++)
			{
				Console.WriteLine("{0}. {1}", i, topics[i].Title);
			}

			Console.Write("Chose topic: ");
			var topicNumber = int.Parse(Console.ReadLine());


			var speakerTopic = new WebSite.Data.Entity.Table.SpeakerTopic
			{
				OrderN = 0,
				SpeakerId = speakers[speakerNumber].Id,
				TopicId = topics[topicNumber].Id
			};

			Console.WriteLine("Working...");
			DataFactory.SpeakerTopicService.Value.InsertAsync(speakerTopic).Wait();
			Console.WriteLine("Done.");
		}
	}
}
