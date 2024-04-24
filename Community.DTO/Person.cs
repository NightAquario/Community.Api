namespace Community.DTO;

public sealed class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public Gender Gender { get; set; }
    public string PersonalCode { get; set; } = null!;
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public City City { get; set; } = null!;
    public byte[] Picture { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }

    public ICollection<ContactInfo> ContactDetails { get; set; } = null!;
    public ICollection<Relationship>? RelationshipsFrom { get; set; }
    public ICollection<Relationship>? RelationshipsTo { get; set; }
}
public enum Gender : byte
{
    Male = 0,
    Female = 1,
    Other = 2
}
