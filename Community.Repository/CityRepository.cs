using Community.DBC;
using Community.DTO;
using Community.RepositoryInterfaces;

namespace Community.Repositories;

internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    internal CityRepository(CommunityDBContext context) : base(context)
    {

    }
}
