using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CSVReader.Application.Interfaces;
using CSVReader.Application.Models;
using CSVReader.Application.Shared;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;

namespace CSVReader.Application.Services;

public class CsvFileService : ICsvFileService
{
    private readonly IRepository<CsvFile> _repository;

    public CsvFileService(IRepository<CsvFile> repository)
    {
        _repository = repository;
    }

    public async Task<AppResponse> CreateAsync(CreateFileVM model)
    {
        var records = ReadCsvFile(model);

        var file = new CsvFile()
        {
            Name = model.Name,
            Size = (double)model.File.Length / 1048576,
            RowRecords = records
        };
        
        await _repository.CreateAsync(file);
        await _repository.SaveAsync();

        return new AppResponse()
        {
            StatusCode = 200
        };
    }
    
    private List<RowRecord> ReadCsvFile(CreateFileVM model)
    {
        var records = new List<RowRecord>();
        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = model.HasHeaderRecord,  // Set to true if the CSV file has a header row
            Delimiter = model.Delimiter,         // Set the delimiter character used in the CSV file
        };

        using var reader = new StreamReader(new BufferedStream(model.File.OpenReadStream()));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var record = new RowRecord
        {
            Name = csv.GetField<string>(0) ?? string.Empty,
            DateOfBirth = csv.GetField<DateTime>(1),
            Married = csv.GetField<bool>(2),
            Salary = csv.GetField<decimal>(3)
        };
        while (csv.Read())
        {
            records.Add(record);
        }
        
        return records;
    }
}