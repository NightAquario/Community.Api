using System.Linq.Expressions;

namespace Community.RepositoryInterfaces;

public interface IRepositoryBase<T> : IDisposable where T : class
{
    T GetById(params object[] id);
    Task<IEnumerable<T>> GetAllAsync();
    IQueryable<T> Set(Expression<Func<T, bool>> predicate);
    IQueryable<T> Set();
    void Insert(T entity);
    void Update(T entity);
    void InsertOrUpdate(T entity);
    void Delete(object id);
    void Delete(T entity);
}
