namespace CSVReader.Domain.Entities;

public class RowRecord : BaseEntity
{
    public string? Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
    
    public bool Married { get; set; }
    
    public decimal Salary { get; set; }

    public Guid CsvFileId { get; set; }


    public CsvFile CsvFile { get; set; }
}