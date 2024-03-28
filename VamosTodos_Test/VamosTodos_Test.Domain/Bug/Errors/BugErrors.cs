
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.Bug.Errors;

public class BugErrors
{
    public static Error EmptySearch => Error.NotFound(
        "BugErrors.EmptySearch",
        "No bug match the provided search parameters.");
}
