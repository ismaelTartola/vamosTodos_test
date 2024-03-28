
using FluentValidation;
using VamosTodos_Test.Application.Extensions.FluentValidation;
using VamosTodos_Test.Domain.Bug.Errors;
using VamosTodos_Test.Domain.Bug.ValueObjects;

namespace VamosTodos_Test.Application.Bug.Commands.CreateBugCommand;

public sealed class CreateBugCommandValidator : AbstractValidator<CreateBugCommand>
{
    
    public CreateBugCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithError(ValidationErrors
            .BugDescriptionValidationErrors.EmptyBugDescription)
            .MinimumLength(BugDescription.MinLength)
            .WithError(ValidationErrors.BugDescriptionValidationErrors
            .BugDescriptionMinLength(BugDescription.MinLength))
            .MaximumLength(BugDescription.MaxLength)
            .WithError(ValidationErrors.BugDescriptionValidationErrors
            .BugDescriptionMaxLength(BugDescription.MaxLength));            
    }
}
