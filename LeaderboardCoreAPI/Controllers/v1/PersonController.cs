using Data;
using Data.DAL;
using Data.DataContext;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

namespace LeaderboardCoreAPI.Controllers.v0
{
    [Produces("application/json")]
    [Route("api/v1/person")]
    public class PersonControllerV1 : Controller
    {
        private readonly LeaderboardContext context;
        private PersonDAL personDAL;

        public PersonControllerV1(LeaderboardContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;

            personDAL = new PersonDAL(context);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (person.RegisteredOn == DateTime.MinValue)
                person.RegisteredOn = DateTime.Now;
            
            personDAL.AddPerson(person);

            return CreatedAtRoute(
                routeName: "GetPerson",
                routeValues: new { id = person.Id },
                value: person
                );
        }

        [Route("{id:int}", Name = "GetPerson")]
        [HttpGet]
        public IActionResult GetPerson(int id)
        {
            var person = personDAL.GetPersonById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }
    }
}
