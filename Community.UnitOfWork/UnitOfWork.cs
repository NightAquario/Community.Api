using Community.DBC;
using Community.IRepositories;
using Community.Repositories;

namespace Community.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly CommunityDBContext _context;
    private readonly Lazy<ICityRepository> _cityRepository;
    private readonly Lazy<IContactInfoRepository> _contactInfoRepository;
    private readonly Lazy<IPersonRepository> _personRepository;
    private readonly Lazy<IRelationshipRepository> _relationshipRepository;

    public UnitOfWork(CommunityDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
    }

    public ICityRepository CityRepository => _cityRepository.Value;
    public IContactInfoRepository ContactInfoRepository => _contactInfoRepository.Value;
    public IPersonRepository PersonRepository => _personRepository.Value;
    public IRelationshipRepository RelationshipRepository => _relationshipRepository.Value;

    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void RollBack()
    {
        throw new NotImplementedException();
    }

    public int SaveChanges()
    {
        throw new NotImplementedException();
    }
}
