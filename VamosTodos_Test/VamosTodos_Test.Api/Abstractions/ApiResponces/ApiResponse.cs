namespace VamosTodos_Test.Presentation.Abstractions.ApiResponces;

public abstract class ApiResponse
{
    public ApiResponse(int statusCode, object? result, string message = default!, string customStatusCode = default!)
    {
        StatusCode = statusCode;
        Message = message;
        CustomStatusCode = customStatusCode;
        Result = result;
    }

    public int StatusCode { get; }
    public string CustomStatusCode { get; }
    public string Message { get; }
    public object? Result { get; }
}