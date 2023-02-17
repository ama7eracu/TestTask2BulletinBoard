namespace BulletinBoard.Domain;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rating { get; set; }
    public string PhoneNumber { get; set; }
}