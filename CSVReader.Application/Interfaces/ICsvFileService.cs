using CSVReader.Application.Models;
using CSVReader.Application.Models.CsvFile;
using CSVReader.Application.Models.RowRecord;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace CSVReader.Application.Interfaces;

public interface ICsvFileService
{
    Task<AppResponse<IEnumerable<RowRecord>>> GetAsync();
    
    Task<AppResponse<CsvFile>> GetByIdAsync(Guid id);

    Task<AppResponse> CreateAsync(CreateFileVM model);

    Task<AppResponse<CsvFile>> PatchAsync(Guid id, JsonPatchDocument<CsvFile> patchDocument);
    
    Task<AppResponse<RowRecordVM>> UpdateAsync(Guid id,  UpdateFileVM model);

    Task<AppResponse> DeleteAsync(Guid id);
}