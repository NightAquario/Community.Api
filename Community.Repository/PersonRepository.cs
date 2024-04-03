using Community.DBC;
using Community.DTO;
using Community.RepositoryInterfaces;

namespace Community.Repositories;

internal sealed class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    internal PersonRepository(CommunityDBContext context) : base(context)
    {

    }
}
