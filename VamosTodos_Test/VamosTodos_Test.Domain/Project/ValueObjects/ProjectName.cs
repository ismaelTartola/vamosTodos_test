
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.Domain.Project.Errors;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Domain.Project.ValueObjects;

public sealed record ProjectName : ValueObject
{
    public const int MaxLength = 30;

    public const int MinLength = 6;

    private ProjectName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<ProjectName> Create(string value) =>
        Result.Create(value, ValidationErrors.ProjectNameValidationErrors.EmptyProjectName)
        .Ensure(x => !string.IsNullOrWhiteSpace(value),
            ValidationErrors.ProjectNameValidationErrors.EmptyProjectName)
         .Ensure(x => value.Length <= MaxLength,
            ValidationErrors.ProjectNameValidationErrors.ProjectNameMaxLength(MaxLength))
          .Ensure(x => value.Length >= MinLength,
            ValidationErrors.ProjectNameValidationErrors.ProjectNameMinLength(MinLength))
         .Map(x => new ProjectName(value));

    public static implicit operator string(ProjectName projectName) => projectName?.Value ?? string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
