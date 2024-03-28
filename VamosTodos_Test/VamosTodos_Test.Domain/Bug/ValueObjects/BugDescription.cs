
using VamosTodos_Test.Domain.Bug.Errors;
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Domain.Bug.ValueObjects;

public record BugDescription : ValueObject
{
    public const int MaxLength = 200;

    public const int MinLength = 10;

    private BugDescription(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<BugDescription> Create(string value) =>
        Result.Create(value, ValidationErrors.BugDescriptionValidationErrors.EmptyBugDescription)
        .Ensure(x => !string.IsNullOrWhiteSpace(value),
            ValidationErrors.BugDescriptionValidationErrors.EmptyBugDescription)
         .Ensure(x => value.Length <= MaxLength,
            ValidationErrors.BugDescriptionValidationErrors.BugDescriptionMaxLength(MaxLength))
          .Ensure(x => value.Length >= MinLength,
            ValidationErrors.BugDescriptionValidationErrors.BugDescriptionMinLength(MinLength))
         .Map(x => new BugDescription(value));

    public static implicit operator string(BugDescription bugDescription) => bugDescription?.Value ?? string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
