namespace Community.IRepositories;

public interface IUnitOfWork : IDisposable
{
    ICityRepository CityRepository { get; }
    IContactInfoRepository ContactInfoRepository { get; }
    IPersonRepository PersonRepository { get; }
    IRelationshipRepository RelationshipRepository { get; }
    int SaveChanges();
    void BeginTransaction();
    void CommitTransaction();
    void RollBack();
}
