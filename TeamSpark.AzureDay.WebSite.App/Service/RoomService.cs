using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class RoomService
	{
		public async Task<List<Room>> GetAllRoomsAsync()
		{
			var rooms = await DataFactory.RoomService.Value.GetByPartitionKeyAsync(Configuration.Year);

			return rooms
				.OrderBy(r => r.RoomType.ToString())
				.ThenBy(r => r.Title)
				.Select(r => AppFactory.Mapper.Value.Map<Room>(r))
				.ToList();
		}
	}
}
