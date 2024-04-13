using Community.DTO;

namespace Community.IServices;

public interface IRelationshipService
{
    Task<Relationship> GetRelationship(int relationshipId);
    Task<IEnumerable<Relationship>> GetRelationships();
    void AddRelationship(Relationship relationship);
    void UpdateRelationship(Relationship relationship);
    void DeleteRelationship(int relationshipId);
}
