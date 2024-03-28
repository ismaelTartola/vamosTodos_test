
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.Domain.User.Errors;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Domain.User.ValueObjects;

public sealed record LastName : ValueObject
{
    public const int MaxLength = 30;

    private LastName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LastName> Create(string value) =>
        Result.Create(value, ValidationErrors.NameValidationErrors.EmptyLastName)
         .Ensure(x => !string.IsNullOrWhiteSpace(value),
            ValidationErrors.NameValidationErrors.EmptyLastName)
         .Ensure(x => value.Length <= MaxLength, 
            ValidationErrors.NameValidationErrors.LastNameMaxLength(MaxLength))
         .Map(x => new LastName(value));

    public static implicit operator string(LastName firstname) => firstname?.Value ?? string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}