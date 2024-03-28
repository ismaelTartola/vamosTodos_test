
using VamosTodos_Test.Domain.Bug.Errors;
using VamosTodos_Test.Domain.Primitives;
using VamosTodos_Test.SharedKernel.ResultObject;

namespace VamosTodos_Test.Domain.Bug.ValueObjects;

public record BugCreationDate : ValueObject
{
    protected BugCreationDate(DateTime value)
    {
        Value = value;
    }

    public DateTime Value { get; private set; }

    public static Result<BugCreationDate> Create(DateTime value) =>
    Result.Create(value)
        .Ensure(x => value < DateTime.UtcNow, ValidationErrors.BugCreationDateValidationErrors.InvalidBugCreationDateDate)
        .Map(x => new BugCreationDate(value));

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
