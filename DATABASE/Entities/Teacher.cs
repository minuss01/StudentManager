using DATABASE.Enums;

namespace DATABASE.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public LevelEnum Level { get; set; }
        public double Salary { get; set; }
    }
}
