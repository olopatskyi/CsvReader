using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CSVReader.Application.Interfaces;
using CSVReader.Application.Models;
using CSVReader.Domain.Entities;
using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;
using ValidationException = CSVReader.Domain.Exceptions.ValidationException;

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
            HasHeaderRecord = model.HasHeaderRecord,
            Delimiter = model.Delimiter
        };

        using var reader = new StreamReader(new BufferedStream(model.File.OpenReadStream()));
        using var csv = new CsvReader(reader, csvConfiguration);

// Read the header record if it exists
        if (model.HasHeaderRecord)
        {
            csv.Read();
        }

        while (csv.Read())
        {
            var record = new RowRecord();

            // Validate and assign the 'Name' field
            var name = csv.GetField<string>(0);
            if (string.IsNullOrEmpty(name))
            {
                throw new ValidationException(new[] { "Invalid name format" });

            }
            record.Name = name;

            // Validate and assign the 'DateOfBirth' field
            var dateOfBirthString = csv.GetField<string>(1);
            if (!DateTime.TryParse(dateOfBirthString, out DateTime dateOfBirth))
            {
                throw new ValidationException(new[] { "Invalid date format" });
            }
            record.DateOfBirth = dateOfBirth;

            // Validate and assign the 'Married' field
            var marriedString = csv.GetField<string>(2);
            if (!bool.TryParse(marriedString, out bool married))
            {
                throw new ValidationException(new[] { "Invalid married format" });
            }
            record.Married = married;

            // Validate and assign the 'Salary' field
            var salaryString = csv.GetField<string>(3);
            if (!decimal.TryParse(salaryString, out decimal salary))
            {
                throw new ValidationException(new[] { "Invalid salary format" });
            }
            record.Salary = salary;

            records.Add(record);
        }

        return records;
    }
}