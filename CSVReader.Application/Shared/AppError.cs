namespace CSVReader.Application.Shared;

public class AppError
{
    public string? Property { get; set; }
    public IEnumerable<string>? Messages { get; set; }
}