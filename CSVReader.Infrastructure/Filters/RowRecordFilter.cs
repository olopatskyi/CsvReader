using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;

namespace CSVReader.Infrastructure.Filters;

public class RowRecordFilter : IFilter<RowRecord>
{
    public IQueryable<RowRecord> ApplyFilter(DataFilter filter, IQueryable<RowRecord> query)
    {
        var filtered = SetFilter(query, filter.FilterBy, filter.FilterValue);
        var sorted = SetSort(filtered, filter.SortBy, filter.OrderBy);

        return sorted;
    }
    
    private IQueryable<RowRecord> SetFilter(IQueryable<RowRecord> query, string property, string value)
    {
        if (string.IsNullOrEmpty(property))
            return query;

        if (!string.IsNullOrEmpty(value))
            return query;

        return property switch
        {
            "name" => query.Where(x => x.Name.Contains(value)),
            "salary" => query.Where(x => x.Salary.ToString().Contains(value)),
            "birthday" => query.Where(x => x.DateOfBirth.Equals(DateTime.Parse(value))),
            "married" => query.Where(x => x.Married == bool.Parse(value)),
            _ => query.Where(x => true)
        };
    }

    private IQueryable<RowRecord> SetSort(IQueryable<RowRecord> query, string sortBy, OrderBy orderBy)
    {
        return sortBy switch
        {
            "name" => orderBy == OrderBy.Ascending ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name),
            "married" => orderBy == OrderBy.Ascending ? query.OrderBy(p => p.Married) : query.OrderByDescending(p => p.Married),
            "birthday" => orderBy == OrderBy.Ascending ? query.OrderBy(p => p.DateOfBirth) : query.OrderByDescending(p => p.DateOfBirth),
            "salary" => orderBy == OrderBy.Ascending ? query.OrderBy(p => p.Salary) : query.OrderByDescending(p => p.Salary),
            _ => query
        };
    }
}