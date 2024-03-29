
using VamosTodos_Test.Application.Abstractions.Services;
using VamosTodos_Test.Application.Exceptions;
using VamosTodos_Test.Domain.Errors;
using VamosTodos_Test.Application.Abstractions.ApiResponces;
using Microsoft.AspNetCore.Diagnostics;

namespace VamosTodos_Test.Api.Middlewares;

public class GlobalErrorHandlingMiddleware : IExceptionHandler
{
    private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;

    public GlobalErrorHandlingMiddleware(ILogger<GlobalErrorHandlingMiddleware> logger
        , IDateTimeProvider dateTimeProvider)
    {
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError("System Exception {@Exception}, {@Exception.Message}, {@Datetime}"
            , exception.GetType().ToString()
            , exception.Message
            , _dateTimeProvider.UtcNow);

        _logger.LogError(exception, exception.Message);

        ApiResponse response = ParseException(exception);

        httpContext.Response.StatusCode
            = (int)response.StatusCode;

        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }

    private static ApiResponse ParseException(Exception exception) =>
            exception switch
            {
                ValidationException validationException =>
                new ApiBadRequestResponse(validationException.Errors,
                     DomainErrors.General.ValidationError.Description!,
                     DomainErrors.General.ValidationError.Code!),
                _ => new ApiInternalServerErrorResponse(DomainErrors.General.ServerError.Description!,
                    DomainErrors.General.ServerError.Code!)
            };
}