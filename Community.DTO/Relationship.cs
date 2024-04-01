namespace Community.DTO;

public sealed class Relationship
{
    public int FromPersonId { get; set; }
    public Person FromPerson { get; set; } = null!;
    public int ToPersonId { get; set; }
    public Person ToPerson { get; set; } = null!;
    public DateTime CreateDate { get; set; }
    public bool IsActive { get; set; }
    public RelationshipType RelationshipType { get; set; }
}
public enum RelationshipType : byte
{
    Colleague = 0,
    Acquaintance = 1,
    Relative = 2,
    Other = 3,
}
