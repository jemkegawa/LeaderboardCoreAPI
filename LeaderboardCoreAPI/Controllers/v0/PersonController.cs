using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace LeaderboardCoreAPI.Controllers.v0
{
    [Produces("application/json")]
    [Route("api/v0/person")]
    public class PersonController : Controller
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Person> GetAllPeople()
        {
            var people = SampleData.GetSamplePeople();

            return people;
        }
        
        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {

            return Ok();
        }
    }
}
