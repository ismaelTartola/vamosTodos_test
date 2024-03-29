
using VamosTodos_Test.Application.Abstractions.ApiResponces;

namespace VamosTodos_Test.Application.Contracts.ApiResponces
{
	public class ApiMethodNotAllowedResponse(object result = default!
	, string message = default!
	, string customStatusCode = default!)
	: ApiResponse(405, result, message, customStatusCode)
	{
	}
}
