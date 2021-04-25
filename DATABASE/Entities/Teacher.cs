using DATABASE.Enums;
using System.Collections.Generic;

namespace DATABASE.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public LevelEnum Level { get; set; }
        public double Salary { get; set; }

        public List<Group> Groups { get; set; }
    }
}
