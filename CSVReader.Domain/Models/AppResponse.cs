using System.Net;

namespace CSVReader.Domain.Models;

public class AppResponse
{
    public int StatusCode { get; set; }
    
    public IEnumerable<AppError>? Errors { get; set; }

    public static AppResponse WithStatusCode(HttpStatusCode statusCode)
    {
        return new AppResponse()
        {
            StatusCode = (int)statusCode,
        };
    }
}

public class AppResponse<TData> : AppResponse
{
    public AppResponse(int statusCode, IEnumerable<AppError>? errors, TData data)
    {
        Data = data;
    }
    
    public TData Data { get; set; }
}