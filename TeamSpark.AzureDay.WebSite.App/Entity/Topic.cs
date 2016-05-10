using System;
using System.Collections.Generic;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Topic
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Language Language { get; set; }

		public List<Speaker> Speakers { get; set; }

		public Topic()
		{
			Language = new Language();
			Speakers = new List<Speaker>();
		}
	}
}
