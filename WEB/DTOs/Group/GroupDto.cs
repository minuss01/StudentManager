using System.ComponentModel;

namespace WEB.DTOs.Group
{
    public class GroupDto
    {
        public int Id { get; set; }

        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("Poziom zaawansowania")]
        public string Level { get; set; }

        [DisplayName("Nauczyciel prowadzący")]
        public string TeacherName { get; set; }
    }
}
