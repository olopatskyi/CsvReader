using CSVReader.Domain.Interfaces;

namespace CSVReader.Domain.Exceptions;

public class NotFoundException : Exception, IAppException
{
    public NotFoundException(IEnumerable<string> errors)
    {
        Errors = errors;
    }
    
    public int StatusCode => 404;
    
    public IEnumerable<string> Errors { get; private set; }

    public static NotFoundException Default<TEntity>()
    {
        return new NotFoundException(new[] { $"{typeof(TEntity)} not found" });
    }
}