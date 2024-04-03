using Community.DBC;
using Community.DTO;
using Community.IRepositories;

namespace Community.Repositories;

internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
{
    internal CityRepository(CommunityDBContext context) : base(context)
    {

    }
}
