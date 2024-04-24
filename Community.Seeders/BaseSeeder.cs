using Community.DBC;

namespace Community.Seeders;

public abstract class BaseSeeder<T> where T : class
{
    protected readonly CommunityDBContext _context;

    protected BaseSeeder(CommunityDBContext context)
    {
        _context = context;
    }

    public abstract void Seed();
}
