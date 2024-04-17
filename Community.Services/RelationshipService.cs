using Community.DTO;
using Community.IRepositories;
using Community.IServices;

namespace Community.Services;

public sealed class RelationshipService : IRelationshipService
{
    private readonly IUnitOfWork _unitOfWork;

    public RelationshipService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Relationship> GetRelationship(int relationshipId)
    {
        Relationship relationship = _unitOfWork.RelationshipRepository.GetById(relationshipId) ??
            throw new InvalidDataException($"Relationship with Id : {relationshipId} could not be found");

        return Task.FromResult(relationship);
    }

    public Task<IEnumerable<Relationship>> GetRelationships()
    {
        //TODO
        throw new NotImplementedException();
    }

    public void AddRelationship(Relationship relationship)
    {
        if (relationship == null) throw new ArgumentNullException(nameof(relationship));
        _unitOfWork.RelationshipRepository.Insert(relationship);
        _unitOfWork.SaveChanges();
    }

    public void UpdateRelationship(Relationship relationship)
    {
        if (relationship == null) throw new ArgumentNullException(nameof(relationship));
        _unitOfWork.RelationshipRepository.Update(relationship);
        _unitOfWork.SaveChanges();
    }

    public void DeleteRelationship(int relationshipId)
    {
        Relationship relationship = _unitOfWork.RelationshipRepository.GetById(relationshipId);
        relationship.IsActive = false;
        _unitOfWork.RelationshipRepository.Update(relationship);
        _unitOfWork.SaveChanges();
    }

}
