using System.Collections.Generic;
using System.ComponentModel;

namespace WEB.DTOs.Teacher
{
    public class TeacherDto
    {
        public int Id { get; set; }

        [DisplayName("Imię i nazwisko")]
        public string FullName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Nr telefonu")]
        public string PhoneNumber { get; set; }

        [DisplayName("Poziom zaawansowania")]
        public string Level { get; set; }

        [DisplayName("Wypłata")]
        public double Salary { get; set; }

        [DisplayName("Grupy")]
        public List<string> Groups { get; set; }
    }
}
