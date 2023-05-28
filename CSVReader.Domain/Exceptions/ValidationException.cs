using CSVReader.Domain.Interfaces;

namespace CSVReader.Domain.Exceptions;

public class ValidationException : Exception, IAppException
{
    public ValidationException(IEnumerable<string> errors)
    {
    }

    public int StatusCode => 400;
    
    public IEnumerable<string> Errors { get; private set; }
}