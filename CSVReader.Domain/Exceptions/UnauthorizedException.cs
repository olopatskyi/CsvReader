using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;

namespace CSVReader.Domain.Exceptions;

public class UnauthorizedException : Exception, IAppException
{
    public UnauthorizedException(IEnumerable<string> errors)
    {
        Errors = errors;
    }

    public int StatusCode => 401;
    
    public IEnumerable<string> Errors { get; private set; }
}