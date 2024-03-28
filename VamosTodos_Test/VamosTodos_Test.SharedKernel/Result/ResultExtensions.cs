
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.SharedKernel.ResultObject;

public static class ResultExtensions
{
    /// <summary>
    /// Ensures that the specified predicate is true, otherwise returns a failure result with the specified error.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="error">The error.</param>
    /// <returns>
    /// The success result if the predicate is true and the current result is a success result, otherwise a failure result.
    /// </returns>
    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Error error)
    {
        if (result.IsFailure)
        {
            return result;
        }

        return result.IsSuccess && predicate(result.Value) ? result : Result.Failure<T>(error);
    }

    /// <summary>
    /// Binds to the result of the function and returns it.
    /// </summary>
    /// <typeparam name="TIn">The result type.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="func">The bind function.</param>
    /// <returns>
    /// The success result with the bound value if the current result is a success result, otherwise a failure result.
    /// </returns>
    public static async Task<Result> Bind<TIn>(this Result<TIn> result, Func<TIn, Task<Result>> func) =>
        result.IsSuccess ? await func(result.Value) : Result.Failure(result.Error);

    public static async Task<Result<TOut>> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<Result<TOut>>> func) =>
        result.IsSuccess ? await func(result.Value) : Result.Failure<TOut>(result.Error);

    /// <summary>
    /// Maps the result value to a new value based on the specified mapping function.
    /// </summary>
    /// <typeparam name="TIn">The result type.</typeparam>
    /// <typeparam name="TOut">The output result type.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="func">The mapping function.</param>
    /// <returns>
    /// The success result with the mapped value if the current result is a success result, otherwise a failure result.
    /// </returns>
    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func) =>
        result.IsSuccess ? func(result.Value) : Result.Failure<TOut>(result.Error);
}