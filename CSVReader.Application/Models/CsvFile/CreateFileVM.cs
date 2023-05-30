using Microsoft.AspNetCore.Http;

namespace CSVReader.Application.Models.CsvFile;

public class CreateFileVM
{
    public string Name { get; set; }

    public bool HasHeaderRecord { get; set; }

    public string Delimiter { get; set; }
    
    public IFormFile File { get; set; }
}