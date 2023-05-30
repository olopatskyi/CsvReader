using Microsoft.AspNetCore.Http;

namespace CSVReader.Application.Models.CsvFile;

public class CreateFileVM
{
    public string Name { get; set; } = null!;

    public bool HasHeaderRecord { get; set; }

    public string Delimiter { get; set; } = null!;

    public IFormFile File { get; set; } = null!;
}