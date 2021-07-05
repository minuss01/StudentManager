using DATABASE.Enums;
using System.Collections.Generic;

namespace DATABASE.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public LevelEnum Level { get; set; }
        public double Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public List<Group> Groups { get; set; }
    }
}
