using System;
using System.Collections.Generic;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Speaker
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName
		{
			get { return string.Format("{0} {1}", FirstName, LastName); }
		}

		public string PhotoUrl { get; set; }
		public string Bio { get; set; }
		public Country Country { get; set; }

		public string FacebookUrl { get; set; }
		public string LinkedInUrl { get; set; }
		public string GoogleUrl { get; set; }
		public string YouTubeUrl { get; set; }
		public string TwitterUrl { get; set; }
		public string MsdnUrl { get; set; }
		public string MvpUrl { get; set; }
		public string GitHubUrl { get; set; }

		public List<Topic> Topics { get; set; }

		public Speaker()
		{
			Country = new Country();
			Topics = new List<Topic>();
		}
	}
}
