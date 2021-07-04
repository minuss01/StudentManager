using System.ComponentModel;

namespace WEB.DTOs.Student
{
    public class StudentDto
    {
        public int Id { get; set; }

        [DisplayName("Imię i nazwisko")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Nr telefonu")]
        public string PhoneNumber { get; set; }

        [DisplayName("Grupa")]
        public string GroupName { get; set; }

        [DisplayName("Poziom zaawansowania")]
        public string Level { get; set; }
    }
}
