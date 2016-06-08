using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.Api
{
    public class ScheduleController : ApiController
    {
		[HttpGet]
		[Route("api/schedule/selected")]
		//[Authorize]
	    public async Task<List<string>> GetSelectedTopics()
		{
			return new List<string>();
		}

		[HttpPost]
		[Route("api/schedule/{topicId}")]
		//[Authorize]
		public async Task SelectTopic(string topicId)
		{
			
		}

		[HttpDelete]
		[Route("api/schedule/{topicId}")]
		//[Authorize]
		public async Task UnselectTopic(string topicId)
		{

		}
	}
}
