namespace CSVReader.Application.Models.CsvFile;

public class UpdateFileVM
{
    public string Name { get; set; } = null!;

    public bool HasHeaderRecord { get; set; }

    public string Delimiter { get; set; } = null!;
}