using System;
using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.App.Entity.Api
{
	public sealed class Speaker 
	{
        public Guid Id { get; set; }

        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhotoUrl { get; set; }
		public string Bio { get; set; }
		public Guid CountryId { get; set; }

		public string FacebookUrl { get; set; }
		public string LinkedInUrl { get; set; }
		public string GoogleUrl { get; set; }
		public string YouTubeUrl { get; set; }
		public string TwitterUrl { get; set; }
		public string MsdnUrl { get; set; }
		public string MvpUrl { get; set; }
		public string GitHubUrl { get; set; }

	}
}
