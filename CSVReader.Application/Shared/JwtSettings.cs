namespace CSVReader.Application.Shared;

public class JwtSettings
{
    public string SecretKey { get; set; }
    
    public string ValidIssuer { get; set; }
    
    public string ValidAudience { get; set; }
}