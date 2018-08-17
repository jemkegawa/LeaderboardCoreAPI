using Models;
using System;
using System.Collections.Generic;

namespace Data
{
    public static class SampleData
    {
        public static List<Person> GetSamplePeople()
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
    }
}
