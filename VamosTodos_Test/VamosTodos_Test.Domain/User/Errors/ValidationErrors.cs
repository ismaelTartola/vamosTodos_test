
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.User.Errors;

public class ValidationErrors
{
   
    public class NameValidationErrors
    {
        public static Error EmptyFirstName => Error.Validation(
            "NameValidationErrors.EmptyFirstName",
            "The user requies a firstname.");

        public static Error EmptyLastName => Error.Validation(
            "NameValidationErrors.EmptyLastName",
            "The user requies a lastname.");

        public static Error FirstNameMaxLength(int allowedLenght) => Error.Validation(
            "NameValidationErrors.FirstnameMaxLength",
            $"The value firstname can't be longer than {allowedLenght}.");

        public static Error LastNameMaxLength(int allowedLenght) => Error.Validation(
            "NameValidationErrors.LastnameMaxLength",
            $"The value lastname can't be longer than {allowedLenght}.");
    }
};