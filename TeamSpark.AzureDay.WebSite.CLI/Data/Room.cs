using System;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Room
	{
		internal static void Add()
		{
			Console.WriteLine("Add rooms");

			foreach (RoomType roomType in Enum.GetValues(typeof(RoomType)))
			{
				Console.Write("Number of {0} rooms: ", roomType);
				var n = int.Parse(Console.ReadLine());

				for (int i = 1; i <= n; i++)
				{
					var room = new WebSite.Data.Entity.Table.Room
					{
						Id = Guid.NewGuid(),
						RoomType = roomType,
						Title = i.ToString()
					};
					Console.WriteLine("Working {0}...", i);
					DataFactory.RoomService.Value.InsertAsync(room).Wait();
					Console.WriteLine("Done.");
				}
			}
		}
	}
}
