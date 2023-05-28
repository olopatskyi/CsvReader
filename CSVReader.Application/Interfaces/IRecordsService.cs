using CSVReader.Application.Models;
using CSVReader.Application.Models.RowRecord;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Models;

namespace CSVReader.Application.Interfaces;

public interface IRecordsService
{
    Task<AppResponse<IEnumerable<RowRecord>>> GetByFileIdAsync(string fileId);
    
    Task<AppResponse<RowRecordVM>> GetByIdAsync(string id);

    Task<AppResponse> CreateAsync(CreateRecordVM model);

    Task<AppResponse<RowRecordVM>> UpdateAsync(string id, UpdateRecordVM model);

    Task<AppResponse> DeleteAsync(string id);
}