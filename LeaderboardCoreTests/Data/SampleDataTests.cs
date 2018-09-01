using Data;
using Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace LeaderboardCoreTests
{
    public class SampleDataTests
    {
        [Fact]
        public void ShouldReturnSamplePeople()
        {
            var expected = SetupSamplePeople();

            var actual = SampleData.GetPeople();

            Assert.Equal(expected.Count, actual.Count);
        }

        private static List<Person> SetupSamplePeople()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 0,
                    Name = "Jem Kegawa",
                    DisplayName = "Jem",
                    RegisteredOn = DateTime.Parse("2018-03-10 08:22")
                },
                new Person
                {
                    Id = 1,
                    Name = "Ghimno",
                    DisplayName = "Ghimno",
                    RegisteredOn = DateTime.Parse("2018-03-10 08:25")
                },
                new Person
                {
                    Id = 2,
                    Name = "Socket",
                    DisplayName = "",
                    RegisteredOn = DateTime.Parse("2018-03-11 08:30")
                }
            };
        }
    }
}
