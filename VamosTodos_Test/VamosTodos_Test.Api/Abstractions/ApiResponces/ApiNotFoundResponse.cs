namespace VamosTodos_Test.Presentation.Abstractions.ApiResponces;

public class ApiNotFoundResponse(object result = default!
    , string message = default!
    , string customStatusCode = default!)
    : ApiResponse(404, result, message, customStatusCode)
{
}