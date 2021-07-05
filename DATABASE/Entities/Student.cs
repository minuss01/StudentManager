using DATABASE.Enums;

namespace DATABASE.Entities
{
    public class Student : IPersonalities
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public LevelEnum Level { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Group Group { get; set; }
    }
}
