namespace CSVReader.Application.Models.RowRecord;

public class UpdateRecordVM
{
    public string? Name { get; set; }

    public DateTime? DateOfBirth { get; set; }
    
    public bool? Married { get; set; }
    
    public decimal? Salary { get; set; }
}