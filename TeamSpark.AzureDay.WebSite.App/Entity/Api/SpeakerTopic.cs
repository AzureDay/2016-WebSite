using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace TeamSpark.AzureDay.WebSite.App.Entity.Api
{
	public sealed class SpeakerTopic 
	{

        public Guid SpeakerId { get; set; }
      
		public Guid TopicId { get; set; }

		public int OrderN { get; set; }
	}
}
