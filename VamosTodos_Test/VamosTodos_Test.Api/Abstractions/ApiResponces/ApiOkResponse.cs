namespace VamosTodos_Test.Presentation.Abstractions.ApiResponces;

public class ApiOkResponse : ApiResponse

{
    public ApiOkResponse(object? result)
        : base(200, result)
    { }
}