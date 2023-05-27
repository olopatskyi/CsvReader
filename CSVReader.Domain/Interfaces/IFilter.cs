using CSVReader.Domain.Entities;
using CSVReader.Domain.Models;

namespace CSVReader.Domain.Interfaces;

public interface IFilter<TEntity>
{
    IQueryable<TEntity> ApplyFilter(DataFilter filter, IQueryable<TEntity> query);
}