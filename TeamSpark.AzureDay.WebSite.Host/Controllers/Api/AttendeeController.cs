using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TeamSpark.AzureDay.WebSite.App;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.Api
{
    public class AttendeeController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/attendee/info")]
        public async Task<IHttpActionResult> GetAttendeeByEmail()
        {
            var score = await AppFactory.AppUserService.Value.GetAttendeeByEmailAsync(RequestContext.Principal.Identity.Name);

            return Ok(score);
        }
    }
}
