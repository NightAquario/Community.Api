using Community.DBC;
using Community.DTO;
using Community.IRepositories;

namespace Community.Repositories;

internal sealed class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    internal PersonRepository(CommunityDBContext context) : base(context)
    {

    }

    public IEnumerable<Person> GetAllPeopleWithRelationships(int personId)
    {
        var peopleWithRelationships = from person in _context.People
                                      join relation in _context.Relationships
                                      on person.Id equals relation.FromPersonId into personRelations
                                      from pr in personRelations.DefaultIfEmpty()
                                      where (pr.FromPersonId == personId || pr.ToPersonId == personId) && person.Id != personId
                                      select person;

        return peopleWithRelationships;
    }

    public IEnumerable<Person> GetAllPeopleWithRelationships(Person person)
    {
        var peopleWithRelationships = from p in _context.People
                                      join r in _context.Relationships
                                      on p.Id equals r.FromPersonId into personRelations
                                      from pr in personRelations.DefaultIfEmpty()
                                      where (pr.FromPersonId == person.Id || pr.ToPersonId == person.Id) && p.Id != person.Id
                                      select p;

        return peopleWithRelationships;
    }
}
