
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.Domain.User.Errors;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Domain.User.ValueObjects;

public sealed record FirstName : ValueObject
{    
    public const int MaxLength = 30;

    private FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<FirstName> Create(string value) =>
        Result.Create(value, ValidationErrors.NameValidationErrors.EmptyFirstName)
        .Ensure(x => !string.IsNullOrWhiteSpace(value),
            ValidationErrors.NameValidationErrors.EmptyFirstName)
         .Ensure(x => value.Length <= MaxLength, ValidationErrors.NameValidationErrors.FirstNameMaxLength(MaxLength))
         .Map(x => new FirstName(value));

    public static implicit operator string(FirstName firstname) => firstname?.Value ?? string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}