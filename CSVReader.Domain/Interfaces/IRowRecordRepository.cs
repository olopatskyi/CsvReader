using CSVReader.Domain.Entities;
using CSVReader.Domain.Models;

namespace CSVReader.Domain.Interfaces;

public interface IRowRecordRepository : IRepository<RowRecord>
{
    Task<IEnumerable<RowRecord>> GetFilteredRecords(DataFilter queryFilter);
}