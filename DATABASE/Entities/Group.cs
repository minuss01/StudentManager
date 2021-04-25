using DATABASE.Enums;

namespace DATABASE.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LevelEnum Level { get; set; }
        public virtual Teacher TeacherId { get; set; }
    }
}
