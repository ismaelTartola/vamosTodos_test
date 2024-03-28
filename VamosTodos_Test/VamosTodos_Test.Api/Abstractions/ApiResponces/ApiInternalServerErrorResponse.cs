namespace VamosTodos_Test.Presentation.Abstractions.ApiResponces;

public class ApiInternalServerErrorResponse : ApiResponse
{
    public ApiInternalServerErrorResponse(string message = default!, string customStatusCode = default!)
        : base(500, message, customStatusCode) { }
}