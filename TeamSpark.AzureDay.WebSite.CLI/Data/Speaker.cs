using System;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Speaker
	{
		internal static void Add()
		{
			Console.WriteLine("Add speaker");
			var speaker = new WebSite.Data.Entity.Table.Speaker
			{
				Id = Guid.NewGuid()
			};

			Console.Write("First Name: ");
			speaker.FirstName = Console.ReadLine();

			Console.Write("Last Name: ");
			speaker.LastName = Console.ReadLine();

			//Console.Write("Photo URL: ");
			//speaker.PhotoUrl = Console.ReadLine();

			//Console.Write("Bio: ");
			//speaker.Bio = Console.ReadLine();

			Console.Write("Facebook URL: ");
			speaker.FacebookUrl = Console.ReadLine();

			Console.Write("LinkedIn URL: ");
			speaker.LinkedInUrl = Console.ReadLine();

			Console.Write("Google URL: ");
			speaker.GoogleUrl = Console.ReadLine();

			Console.Write("YouTube URL: ");
			speaker.YouTubeUrl = Console.ReadLine();

			Console.Write("Twitter URL: ");
			speaker.TwitterUrl = Console.ReadLine();

			Console.Write("MSDN URL: ");
			speaker.MsdnUrl = Console.ReadLine();

			Console.Write("MVP URL: ");
			speaker.MvpUrl = Console.ReadLine();

			Console.Write("GitHub URL: ");
			speaker.GitHubUrl = Console.ReadLine();

			Console.WriteLine("Working...");
			DataFactory.SpeakerService.Value.InsertAsync(speaker).Wait();
			Console.WriteLine("Done.");
		}
	}
}
