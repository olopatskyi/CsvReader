using CSVReader.Domain.Entities;
using CSVReader.Domain.Models;

namespace CSVReader.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task CreateAsync(TEntity entity);
    
    void Delete(TEntity entity);
    
    void Update(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);
    
    Task<IEnumerable<TEntity>> GetAsync();

    Task SaveAsync();
}