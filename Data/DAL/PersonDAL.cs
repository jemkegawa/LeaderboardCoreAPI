using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Data.DAL
{
    public interface IPersonDAL
    {
        Person GetPersonById(int personId);
        void AddPerson(Person person);
    }

    public class PersonDAL : IPersonDAL
    {
        private LeaderboardContext _context;
        
        public PersonDAL(LeaderboardContext context)
        {
            _context = context;
        }

        public Person GetPersonById(int personId)
        {
            var person = _context.People
                .Include(p => p.Scores)
                .Where(p => p.Id == personId)
                .FirstOrDefault();

            if (person == null)
                return null;

            return person;
        }

        public void AddPerson(Person person)
        {
            if (person == null)
                return;

            _context.Add<Person>(person);

            _context.SaveChanges();
        }
    }
}
