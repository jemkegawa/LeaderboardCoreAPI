using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

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
            var people = SampleData.GetPeople();

            return people;
        }
        
        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            

            return CreatedAtRoute($"api/v0/person/{person.Id}", person);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetPerson(int id)
        {
            var person = SampleData.GetPersonById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
    }
}
