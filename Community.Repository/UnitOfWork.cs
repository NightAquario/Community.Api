using Community.DBC;
using Community.IRepositories;
using Community.Repositories;

namespace Community.Repositories;

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
        _contactInfoRepository = new Lazy<IContactInfoRepository>(() => new ContactInfoRepository(context));
        _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
        _relationshipRepository = new Lazy<IRelationshipRepository>(() => new RelationshipRepository(context));
    }

    public ICityRepository CityRepository => _cityRepository.Value;
    public IContactInfoRepository ContactInfoRepository => _contactInfoRepository.Value;
    public IPersonRepository PersonRepository => _personRepository.Value;
    public IRelationshipRepository RelationshipRepository => _relationshipRepository.Value;

    public int SaveChanges() =>
        _context.SaveChanges();
    public void BeginTransaction()
    {
        if (_context.Database.CurrentTransaction != null)
        {
            throw new InvalidOperationException("A Transaction is already in progress.");
        }

        _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        try
        {
            _context.Database.CurrentTransaction?.Commit();
        }
        catch
        {
            _context.Database.CurrentTransaction?.Rollback();
            throw;
        }
        finally
        {
            _context.Database.CurrentTransaction?.Dispose();
        }
    }

    public void Dispose() =>
        _context.Dispose();

    public void RollBack()
    {
        try
        {
            _context.Database.CurrentTransaction?.Rollback();
        }
        finally
        {
            _context.Database.CurrentTransaction?.Dispose();
        }
    }

}
