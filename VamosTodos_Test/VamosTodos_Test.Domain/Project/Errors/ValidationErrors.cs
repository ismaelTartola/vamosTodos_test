using VamosTodos_Test.SharedKernel.ErrorObject;

namespace VamosTodos_Test.Domain.Project.Errors;

public class ValidationErrors
{
    public class ProjectNameValidationErrors
    {
        public static Error EmptyProjectName => Error.Validation(
            "ProjectNameValidationErrors.EmptyProjectName",
            "The project requires a project name.");

        public static Error ProjectNameMaxLength(int allowedLenght) => Error.Validation(
            "ProjectNameValidationErrors.ProjectNameMaxLength",
            $"The value project name can't be longer than {allowedLenght}.");

        public static Error ProjectNameMinLength(int allowedLenght) => Error.Validation(
            "ProjectNameValidationErrors.ProjectNameMinLength",
            $"The value project name can't be smaller than {allowedLenght}.");
    }

    public class ProjectDescriptionValidationErrors
    {
        public static Error EmptyProjectDescription => Error.Validation(
            "ProjectDescriptionValidationErrors.EmptyProjectDescription",
            "The project requires a project description.");

        public static Error ProjectDescriptionMaxLength(int allowedLenght) => Error.Validation(
            "ProjectDescriptionValidationErrors.ProjectDescriptionMaxLength",
            $"The value project description can't be longer than {allowedLenght}.");

        public static Error ProjectDescriptionMinLength(int allowedLenght) => Error.Validation(
            "ProjectDescriptionValidationErrors.ProjectDescriptionMinLength",
            $"The value project description can't be smaller than {allowedLenght}.");
    }
};