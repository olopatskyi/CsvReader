using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;
using CSVReader.Infrastructure.Filters;

namespace CSVReader.Infrastructure.Factories;

public class RowRecordFactory : IFilterFactory<RowRecord>
{
    public IFilter<RowRecord> GetFilter()
    {
        return new RowRecordFilter();
    }
}