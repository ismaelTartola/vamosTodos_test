
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.User.Errors;

public class UserErrors
{
    public static Error NonExist => Error.NotFound(
        "UserErrors.NonExist",
        "User dosen't exist.");
}