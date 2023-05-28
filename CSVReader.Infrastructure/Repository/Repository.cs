using System.Linq.Expressions;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;
using CSVReader.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CSVReader.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> DbSet;
    private readonly DatabaseContext _databaseContext;
    public Repository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        DbSet = databaseContext.Set<TEntity>();
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.Where(expression).AsNoTracking().ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _databaseContext.SaveChangesAsync();
    }
}