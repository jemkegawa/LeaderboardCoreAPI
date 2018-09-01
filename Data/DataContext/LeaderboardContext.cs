using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace Data.DataContext
{
    public class LeaderboardContext : DbContext
    {
        public LeaderboardContext(DbContextOptions<LeaderboardContext> options)
            : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Score> Scores { get; set; }
        

    }
}
