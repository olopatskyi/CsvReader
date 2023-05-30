using CSVReader.Application.Models;
using CSVReader.Application.Models.RowRecord;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Models;

namespace CSVReader.Application.Interfaces;

public interface IRecordsService
{
    Task<AppResponse<IEnumerable<RowRecord>>> GetByFileIdAsync(Guid fileId);
    
    Task<AppResponse<RowRecordVM>> GetByIdAsync(Guid id);

    Task<AppResponse> CreateAsync(CreateRecordVM model);

    Task<AppResponse<RowRecordVM>> UpdateAsync(Guid id, UpdateRecordVM model);

    Task<AppResponse> DeleteAsync(Guid id);
}