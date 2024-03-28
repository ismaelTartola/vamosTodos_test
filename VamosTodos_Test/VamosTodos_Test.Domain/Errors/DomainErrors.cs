
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.Errors;

public class DomainErrors
{
    public class General
    {
        public static Error ServerError => Error.Conflict(
            "Domain.GeneralErrors.ServerError",
            "The server encountered an unrecoverable error.");


        public static Error ValidationError => Error.Validation(
            "Domain.GeneralErrors.ValidationError",
            "The provided data generated a validation error.");

        public static Error InvalidMethodError => Error.Conflict(
            "Domain.GeneralErrors.InvalidMethodError",
            "The endpoind you requested doesn't support the http request type.");
    }
}