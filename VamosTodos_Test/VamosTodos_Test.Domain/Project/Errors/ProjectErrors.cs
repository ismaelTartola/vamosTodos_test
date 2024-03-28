
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.Project.Errors;

public class ProjectErrors
{
    public static Error NonExist => Error.NotFound(
       "ProjectErrors.NonExist",
       "Project dosen't exist.");
}
