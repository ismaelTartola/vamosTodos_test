using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Abstractions.Services;
using VamosTodos_Test.SharedKernel.ResultObject;
using MediatR;
using Microsoft.Extensions.Logging;

namespace VamosTodos_Test.Application.Behaviours;

internal sealed class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ILoggedRequest
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger
        , IDateTimeProvider dateTimeProvider)
    {
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request {@RequestName}, {@Datetime}"
            , typeof(TRequest)
            , _dateTimeProvider.UtcNow);

        var result = await next();

        if (result.IsFailure)
        {
            _logger.LogError("Request Failure {@RequestName}, {@Datetime}"
            , typeof(TRequest)
            , _dateTimeProvider.UtcNow);
        }

        _logger.LogInformation("Completed request {@RequestName}, {@Datetime}"
            , typeof(TRequest)
            , _dateTimeProvider.UtcNow);

        return result;
    }
}