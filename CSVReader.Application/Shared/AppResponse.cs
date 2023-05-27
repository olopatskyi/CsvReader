namespace CSVReader.Application.Shared;

public class AppResponse
{
    public int StatusCode { get; set; }
    
    public IEnumerable<AppError>? Errors { get; set; }
}

public class AppResponse<TData> : AppResponse
{
    public AppResponse(int statusCode, IEnumerable<AppError>? errors, TData data)
    {
        Data = data;
    }
    
    public TData Data { get; set; }
}