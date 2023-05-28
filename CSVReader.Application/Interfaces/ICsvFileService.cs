using CSVReader.Application.Models;
using CSVReader.Application.Shared;
using CSVReader.Domain.Models;

namespace CSVReader.Application.Interfaces;

public interface ICsvFileService
{
    Task<AppResponse> CreateAsync(CreateFileVM model);
    
}