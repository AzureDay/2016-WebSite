using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Security;

using System.Threading.Tasks;
using System.Web.Http;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.ApiControllers
{
    public class QuizController : ApiController
    {

        [HttpGet]
        [Route("api/quiz/scores")]
        public async Task<IHttpActionResult> GetAllScores()
        {
            var scoresTask = AppFactory.QuizScoreService.Value.GetAllQuizAsync();
            await Task.WhenAll(scoresTask);
            var model = new List<QuizScore>();
            model = scoresTask.Result.ToList();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("api/quiz/postscore")]
        public async Task<IHttpActionResult> PostScore([FromBody] int score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = RequestContext.Principal.Identity.Name;
            var date = DateTime.Now;
            var data = new QuizScore() { Email = email, Score = score, Date = date };
            var scoresTask = AppFactory.QuizScoreService.Value.InsertAsync(data);

            return Ok();
        }

    }
}
