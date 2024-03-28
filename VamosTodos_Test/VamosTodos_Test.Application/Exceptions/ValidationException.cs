
using VamosTodos_Test.SharedKernel.ErrorObject;
using FluentValidation.Results;

namespace VamosTodos_Test.Application.Exceptions
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation failures has occurred.") =>
            Errors = failures
                .Distinct()
                .Select(failure => Error.Validation(failure.ErrorCode, failure.ErrorMessage))
                .ToArray();

        public IReadOnlyCollection<Error> Errors { get; }
    }
}