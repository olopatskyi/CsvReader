using CSVReader.Domain.Interfaces;

namespace CSVReader.Domain.Exceptions;

public class ForbiddenException : Exception, IAppException
{
    public ForbiddenException(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public int StatusCode => 403;
    
    public IEnumerable<string> Errors { get; private set; }
}