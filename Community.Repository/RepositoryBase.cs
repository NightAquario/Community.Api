﻿using Community.DBC;
using Community.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Community.Repositories;

internal abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly CommunityDBContext _context;
    protected readonly DbSet<T> _dbSet;

    internal RepositoryBase(CommunityDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<T>();
    }

    public T GetById(params object[] id) =>
       _dbSet.Find(id) ?? throw new KeyNotFoundException($"Record with key {id} not found");

    async Task<T> IRepositoryBase<T>.GetAsync(params object[] id) => await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException();

    public IQueryable<T> Set(Expression<Func<T, bool>> predicate) =>
        _dbSet.Where(predicate);

    public async Task<IQueryable<T>> SetAsync() => (IQueryable<T>)await _dbSet.ToListAsync();

    public IQueryable<T> Set() =>
        _dbSet;

    public void Insert(T entity) =>
        _dbSet.Add(entity);

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void InsertOrUpdate(T entity)
    {
        var entry = _context.Entry(entity);
        if (entry == null || entry.State == EntityState.Detached)
        {
            Insert(entity);
        }
        else
        {
            Update(entity);
        }
    }

    public void Delete(object id) =>
        Delete(GetById(id));

    public void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }

        _dbSet.Remove(entity);
    }

    public void Dispose() =>
        _context.Dispose();
}
