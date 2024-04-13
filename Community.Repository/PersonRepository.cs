using Community.DBC;
using Community.DTO;
using Community.IRepositories;

namespace Community.Repositories;

internal sealed class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    internal PersonRepository(CommunityDBContext context) : base(context)
    {

    }

    public IEnumerable<Relationship> GetAllRelationships(int personId)
    {
        var relationships = from person in _context.People
                            join relation in _context.Relationships
                            on person.Id equals relation.FromPersonId into personRelations
                            from pr in personRelations.DefaultIfEmpty()
                            where (pr.FromPersonId == personId || pr.ToPersonId == personId) && person.Id != personId
                            select pr;

        return relationships.ToList();
    }
}
