using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LeaderboardCoreAPI.Controllers.v0
{
    [Produces("application/json")]
    [Route("api/v0/score")]
    public class ScoreController : Controller
    {
        [Route("{id:int}/{personId:int}")]
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
            SampleData.InsertScore(score);

            return CreatedAtRoute($"api/v0/score/{score.Id}", score);
        }
    }
}
