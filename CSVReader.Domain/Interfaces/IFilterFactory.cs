using CSVReader.Domain.Entities;

namespace CSVReader.Domain.Interfaces;

public interface IFilterFactory<TEntity> where TEntity : BaseEntity
{
    IFilter<TEntity> GetFilter();
}