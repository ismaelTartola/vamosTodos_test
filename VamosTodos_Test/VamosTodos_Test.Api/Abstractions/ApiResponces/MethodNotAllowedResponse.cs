using VamosTodos_Test.Presentation.Abstractions.ApiResponces;

namespace VamosTodos_Test.Api.Abstractions.ApiResponces;

public class MethodNotAllowedresponse(object result = default!
, string message = default!
, string customStatusCode = default!)
: ApiResponse(405, result, message, customStatusCode)
{
}
