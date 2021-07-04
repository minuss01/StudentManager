namespace DATABASE.Entities
{
    public interface IPersonalities
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Street { get; set; }
        string City { get; set; }
        string PostCode { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
    }
}
