using DATABASE.Enums;

namespace WEB.DTOs.Student
{
    public class StudentFromFileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public LevelEnum Level { get; set; }
        public int GroupId { get; set; }
    }
}
