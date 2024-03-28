
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.Domain.Project.Errors;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Domain.Project.ValueObjects;

public sealed record ProjectDescription : ValueObject
{
    public const int MaxLength = 200;

    public const int MinLength = 10;

    private ProjectDescription(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<ProjectDescription> Create(string value) =>
        Result.Create(value, ValidationErrors.ProjectDescriptionValidationErrors.EmptyProjectDescription)
        .Ensure(x => !string.IsNullOrWhiteSpace(value),
            ValidationErrors.ProjectDescriptionValidationErrors.EmptyProjectDescription)
         .Ensure(x => value.Length <= MaxLength,
            ValidationErrors.ProjectDescriptionValidationErrors.ProjectDescriptionMaxLength(MaxLength))
          .Ensure(x => value.Length >= MinLength,
            ValidationErrors.ProjectDescriptionValidationErrors.ProjectDescriptionMinLength(MinLength))
         .Map(x => new ProjectDescription(value));

    public static implicit operator string(ProjectDescription projectDescription) => projectDescription?.Value ?? string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
