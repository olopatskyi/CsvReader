using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;
using CSVReader.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CSVReader.Infrastructure.Repository;

public class RowRecordRepository : Repository<RowRecord>, IRowRecordRepository
{
    private readonly IFilterFactory<RowRecord> _filterFactory;
    
    public RowRecordRepository(DatabaseContext databaseContext, IFilterFactory<RowRecord> filterFactory) : base(databaseContext)
    {
        _filterFactory = filterFactory;
    }

    public async Task<IEnumerable<RowRecord>> GetFilteredRecords(DataFilter queryFilter)
    {
        var query = DbSet;
        var filter = _filterFactory.GetFilter();

        var filteredQuery = filter.ApplyFilter(queryFilter, query);

        return await filteredQuery.ToListAsync();
    }
}