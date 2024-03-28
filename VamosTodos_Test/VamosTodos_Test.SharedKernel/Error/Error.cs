
namespace VamosTodos_Test.SharedKernel.ErrorObject;

public record Error
{
    public string Code { get; }
    public string? Description { get; }
    public ErrorType Type { get; }

    private Error(string code, ErrorType type, string? description = null)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public static readonly Error None = new(string.Empty, ErrorType.Failure, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", ErrorType.Failure, "The specified result value is null.");
    public static readonly Error ConditionNotMet = new("Error.ConditionNotMet", ErrorType.Validation, "The specified condition was not met.");

    public static Error NotFound(string code, string description) =>
        new Error(code, ErrorType.NotFound, description);

    public static Error Validation(string code, string description) =>
        new Error(code, ErrorType.Validation, description);

    public static Error Conflict(string code, string description) =>
        new Error(code, ErrorType.Conflict, description);

    public static Error Failure(string code, string description) =>
        new Error(code, ErrorType.Failure, description);
}