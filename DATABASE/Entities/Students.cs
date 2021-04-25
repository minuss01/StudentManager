namespace DATABASE.Entities
{
    public class Students
    {
        public int Id { get; set; }
        public virtual Group GroupId { get; set; }
        public virtual User UserId { get; set; }
    }
}
