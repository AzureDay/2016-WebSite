﻿using System;
using System.Collections.Generic;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Speaker
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhotoUrl { get; set; }
		public string Bio { get; set; }
		public Country Country { get; set; }

		public List<Topic> Topics { get; set; }

		public Speaker()
		{
			Country = new Country();
			Topics = new List<Topic>();
		}
	}
}
