using CSVReader.Domain.Interfaces;
using CSVReader.Domain.Models;

namespace CSVReader.Application.Extensions;

public static class ExceptionExtensions
{
    public static AppResponse CreateWithOneMessage(this AppResponse response, IAppException exception)
    {
        return new AppResponse()
        {
            StatusCode = exception.StatusCode,
            Errors = exception.Errors.Select(x => new AppError(null, x))
        };
    }
}