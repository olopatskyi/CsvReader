namespace CSVReader.Domain.Entities;

public class CsvFile : BaseEntity
{
    public string Name { get; set; } = null!;

    public double Size { get; set; }

    public ICollection<RowRecord>? RowRecords { get; set; }
}