using Community.DBC;
using Community.DTO;
using Community.RepositoryInterfaces;

namespace Community.Repositories;

internal sealed class RelationshipRepository : RepositoryBase<Relationship>, IRelationshipRepository
{
    internal RelationshipRepository(CommunityDBContext context) : base(context)
    {

    }
}
