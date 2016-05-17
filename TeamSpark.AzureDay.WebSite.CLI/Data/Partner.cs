using System;
using TeamSpark.AzureDay.WebSite.Data;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.CLI.Data
{
	internal static class Partner
	{
		internal static void Add()
		{
			Console.WriteLine("Add partner");
			var partner = new WebSite.Data.Entity.Table.Partner
			{
				Id = Guid.NewGuid(),
				OrderN = -1,
				Description = string.Empty
			};

			Console.Write("Partner title: ");
			partner.Title = Console.ReadLine();

			Console.Write("Logo url: ");
			partner.LogoUrl = Console.ReadLine();

			Console.Write("Web url: ");
			partner.WebUrl = Console.ReadLine();

			Console.WriteLine("Partner type:");
			foreach (PartnerType partnerType in Enum.GetValues(typeof(PartnerType)))
			{
				Console.WriteLine("{0} {1}", (int)partnerType, partnerType);
			}
			partner.PartnerTypeId = int.Parse(Console.ReadLine());

			Console.WriteLine("Working...");
			DataFactory.PartnerService.Value.InsertAsync(partner).Wait();
			Console.WriteLine("Done.");
		}
	}
}
