
using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.Bug.Errors;

public class ValidationErrors
{
    public class BugDescriptionValidationErrors
    {
        public static Error EmptyBugDescription => Error.Validation(
            "BugDescriptionValidationErrors.EmptyBugDescription",
            "The bug requires a project description.");

        public static Error BugDescriptionMaxLength(int allowedLenght) => Error.Validation(
            "BugDescriptionValidationErrors.BugDescriptionMaxLength",
            $"The value bug description can't be longer than {allowedLenght}.");

        public static Error BugDescriptionMinLength(int allowedLenght) => Error.Validation(
            "BugDescriptionValidationErrors.BugDescriptionMinLength",
            $"The value bug description can't be smaller than {allowedLenght}.");
    }

    public class BugCreationDateValidationErrors
    {
        public static Error InvalidBugCreationDateDate => Error.Validation(
           "BugCreationDateValidationErrors.InvalidBugCreationDateDate",
           "The bug creation date is invalid.");
    }
};