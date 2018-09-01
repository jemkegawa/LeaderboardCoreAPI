using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public static class SampleData
    {
        public static List<Person> GetPeople()
        {
            return GetSamplePeople();
        }

        private static List<Person> GetSamplePeople()
        {
            var people = new List<Person>();

            people.Add(new Person
            {
                Id = 0,
                Name = "Jem Kegawa",
                DisplayName = "Jem",
                RegisteredOn = DateTime.Parse("2018-03-10 08:22")
            });

            people.Add(new Person
            {
                Id = 1,
                Name = "Ghimno",
                DisplayName = "Ghimno",
                RegisteredOn = DateTime.Parse("2018-03-10 08:25")
            });

            people.Add(new Person
            {
                Id = 2,
                Name = "Socket",
                DisplayName = "",
                RegisteredOn = DateTime.Parse("2018-03-11 08:30")
            });

            return people;
        }

        private static List<Score> GetSampleScores(int personId)
        {
            var scores = new List<Score>();

            scores.Add(new Score
            {
                Id = 0,
                PersonId = personId,
                Name = "Level 1",
                Value = 500
            });

            scores.Add(new Score
            {
                Id = 1,
                PersonId = personId,
                Name = "Level 1",
                Value = 650
            });

            return scores;
        }

        public static Person GetPersonById(int id)
        {
            var people = GetSamplePeople();

            return people.FirstOrDefault(p => p.Id == id);
        }

        public static void InsertPerson(Person person)
        {
            person.Id = -1;
        }

        public static Score GetScoreById(int personId, int id)
        {
            var scores = GetSampleScores(personId);

            return scores.FirstOrDefault(s => s.Id == id);
        }

        public static void InsertScore(Score score)
        {
            score.Id = -1;
        }
    }
}
