using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class IndexModel
	{
		public SpeakersModel Speakers { get; set; }
		public PartnersModel Partners { get; set; }
	}
}