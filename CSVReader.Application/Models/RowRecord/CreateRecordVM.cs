namespace CSVReader.Application.Models.RowRecord;

public class CreateRecordVM
{
    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
    
    public bool Married { get; set; }
    
    public decimal Salary { get; set; }

    public Guid CsvFileId { get; set; }
}