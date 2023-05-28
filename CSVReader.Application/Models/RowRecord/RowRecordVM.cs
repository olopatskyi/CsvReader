namespace CSVReader.Application.Models.RowRecord;

public class RowRecordVM
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }
    
    public bool Married { get; set; }
    
    public decimal Salary { get; set; }
}