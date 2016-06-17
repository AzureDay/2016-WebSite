using System;
using System.Threading.Tasks;
using System.Web.Http;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers.ApiControllers
{
    public class QuizController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/quiz/scores")]
        public async Task<IHttpActionResult> GetAllScores()
        {
            var score = await AppFactory.QuizScoreService.Value.GetAllScoresAsync();

            return Ok(score);
        }

        [Authorize]
        [HttpGet]
        [Route("api/quiz/score")]
        public async Task<IHttpActionResult> GetScore()
        {
            var score = await AppFactory.QuizScoreService.Value.GetUserScore(RequestContext.Principal.Identity.Name);

            return Ok(score);
        }

        [Authorize]
        [HttpPost]
        [Route("api/quiz/score")]
        public async Task<IHttpActionResult> PostScore([FromBody] int score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = RequestContext.Principal.Identity.Name;
            var date = DateTime.Now;
            var data = new QuizScore() { Email = email, Score = score, Date = date };
            await AppFactory.QuizScoreService.Value.InsertAsync(data);

            return Ok();
        }
    }
}