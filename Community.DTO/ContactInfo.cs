namespace Community.DTO;

public sealed class ContactInfo
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public string Value { get; set; } = null!;
    public ContactType ContactType { get; set; }
    public ContactCategory ContactCategory { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }
}
public enum ContactType : byte
{
    PhoneNumber = 0,
    Email = 1,
}
public enum ContactCategory : byte
{
    Home = 0,
    Work = 1,
    Personal = 2
}
