
using VamosTodos_Test.SharedKernel.ErrorObject;
using VamosTodos_Test.SharedKernel.ResultObject;
using Microsoft.AspNetCore.Mvc;

namespace VamosTodos_Test.Api.Presentation.Extensions;

internal static class ResultExtensions
{
    internal static IResult ToProblemDetails<ResultType>(this Result<ResultType> result)
        where ResultType : class
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        return Results.Problem(
               statusCode: GetStatusCode(result.Error.Type),
               title: GetTitle(result.Error.Type),
               type: GetType(result.Error.Type),
               extensions: new Dictionary<string, object?>
               {
                   { "Errors", new [] { result.Error }  }
               });

        static int GetStatusCode(ErrorType errorType) =>
           errorType switch
           {
               ErrorType.NotFound => StatusCodes.Status404NotFound,
               ErrorType.Validation => StatusCodes.Status400BadRequest,
               ErrorType.Conflict => StatusCodes.Status409Conflict,
               _ => StatusCodes.Status500InternalServerError
           };

        static string GetTitle(ErrorType errorType) =>
           errorType switch
           {
               ErrorType.NotFound => "Not Found",
               ErrorType.Validation => "Bad Request",
               ErrorType.Conflict => "Conflict",
               _ => "Server Failure"
           };

        static string GetType(ErrorType errorType) =>
           errorType switch
           {
               ErrorType.NotFound => "https://tool.ietf.org/html/rfc7231#section-6.5.4",
               ErrorType.Validation => "https://tool.ietf.org/html/rfc7231#section-6.5.1",
               ErrorType.Conflict => "https://tool.ietf.org/html/rfc7231#section-6.5.8",
               _ => "https://tool.ietf.org/html/rfc7231#section-6.6.1"
           };
    }

    internal static IResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException();
        }

        return Results.Problem(
               statusCode: GetStatusCode(result.Error.Type),
               title: GetTitle(result.Error.Type),
               type: GetType(result.Error.Type),
               extensions: new Dictionary<string, object?>
               {
                   { "Errors", new [] { result.Error }  }
               });

        static int GetStatusCode(ErrorType errorType) =>
           errorType switch
           {
               ErrorType.NotFound => StatusCodes.Status404NotFound,
               ErrorType.Validation => StatusCodes.Status400BadRequest,
               ErrorType.Conflict => StatusCodes.Status409Conflict,
               _ => StatusCodes.Status500InternalServerError
           };

        static string GetTitle(ErrorType errorType) =>
           errorType switch
           {
               ErrorType.NotFound => "Not Found",
               ErrorType.Validation => "Bad Request",
               ErrorType.Conflict => "Conflict",
               _ => "Server Failure"
           };

        static string GetType(ErrorType errorType) =>
           errorType switch
           {
               ErrorType.NotFound => "https://tool.ietf.org/html/rfc7231#section-6.5.4",
               ErrorType.Validation => "https://tool.ietf.org/html/rfc7231#section-6.5.1",
               ErrorType.Conflict => "https://tool.ietf.org/html/rfc7231#section-6.5.8",
               _ => "https://tool.ietf.org/html/rfc7231#section-6.6.1"
           };
    }

    internal static async Task<IActionResult> Match(this Task<Result> resultTask
        , Func<IActionResult> onSuccess, Func<Result, IActionResult> onFailure)
    {
        Result result = await resultTask;

        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    internal static async Task<IActionResult> Match<TIn>(this Task<Result<TIn>> resultTask
        , Func<TIn, IActionResult> onSuccess, Func<Result<TIn>, IActionResult> onFailure)
    {
        Result<TIn> result = await resultTask;

        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }
}