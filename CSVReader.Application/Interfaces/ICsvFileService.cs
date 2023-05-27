using CSVReader.Application.Models;
using CSVReader.Application.Shared;

namespace CSVReader.Application.Interfaces;

public interface ICsvFileService
{
    Task<AppResponse> CreateAsync(CreateFileVM model);
    
}