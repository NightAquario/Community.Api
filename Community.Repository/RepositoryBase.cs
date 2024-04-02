using Community.DBC;
using Microsoft.EntityFrameworkCore;

namespace Community.Repositories;

internal abstract class RepositoryBase<T>
{
    protected readonly CommunityDBContext _context;
    protected readonly DbSet<T> _dbSet;

    internal RepositoryBase(CommunityDBContext context, DbSet<T> dbSet)
    {
        _context = context;
        _dbSet = dbSet;
    }
}
