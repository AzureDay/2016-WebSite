using System;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Language
	{
		public Guid Id { get; set; }
		public string Title { get; set; }

		public string GetImageUrl()
		{
			throw new NotImplementedException();
		}
	}
}
