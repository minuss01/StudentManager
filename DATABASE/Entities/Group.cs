using DATABASE.Enums;
using System.Collections.Generic;

namespace DATABASE.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LevelEnum Level { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual List<Student> Students { get; set; }

    }
}
