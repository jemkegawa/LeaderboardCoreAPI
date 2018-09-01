using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredOn { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
