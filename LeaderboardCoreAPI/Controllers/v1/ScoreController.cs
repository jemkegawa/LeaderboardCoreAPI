using Data;
using Data.DAL;
using Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LeaderboardCoreAPI.Controllers.v0
{
    [Produces("application/json")]
    [Route("api/v1/score")]
    public class ScoreControllerV1 : Controller
    {
        private readonly LeaderboardContext context;
        private PersonDAL personDAL;
        private ScoreDAL scoreDAL;

        public ScoreControllerV1(LeaderboardContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;

            personDAL = new PersonDAL(context);
            scoreDAL = new ScoreDAL(context);
        }

        [Route("{id:int}/{personId:int}", Name = "GetScore")]
        [HttpGet]
        public IActionResult GetScore(int id, int personId)
        {
            var score = SampleData.GetScoreById(personId, id);

            if (score == null)
                return NotFound();

            return Ok(score);
        }

        [Route("")]
        [HttpPost]
        public IActionResult PostScore([FromBody]Score score)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            scoreDAL.AddScore(score);
            
            return CreatedAtRoute(
                routeName: "GetScore",
                routeValues: new { id = score.Id, personId = score.PersonId },
                value: score
                );
        }
    }
}
