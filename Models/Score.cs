using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Score
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
