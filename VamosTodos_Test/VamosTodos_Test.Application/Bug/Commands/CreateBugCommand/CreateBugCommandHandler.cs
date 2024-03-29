
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Abstractions.Services;
using VamosTodos_Test.Domain.User.Errors;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.SharedKernel.MaybeObject;
using VamosTodos_Test.SharedKernel.ResultObject;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Bug.ValueObjects;
using VamosTodos_Test.Domain.Project.Errors;
using VamosTodos_Test.Application.Contracts.User;
using VamosTodos_Test.Application.Contracts.Project;

namespace VamosTodos_Test.Application.Bug.Commands.CreateBugCommand;

public sealed class CreateBugCommandHandler : ICommandHandler<CreateBugCommand, BugDto>
{
    private readonly IDateTimeProvider _dateProvider;
    private readonly IBugEntityRepository _bugEntityRepository;
    private readonly IUserAggregateRootRepository _userAggregateRootRepository;
    private readonly IProjectAggregateRootRepository _projectAggregateRootRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBugCommandHandler(IDateTimeProvider dateProvider,
        IBugEntityRepository bugEntityRepository,
        IUnitOfWork unitOfWork,
        IUserAggregateRootRepository userAggregateRootRepository,
        IProjectAggregateRootRepository projectAggregateRootRepository)
    {
        _dateProvider = dateProvider;
        _bugEntityRepository = bugEntityRepository;
        _unitOfWork = unitOfWork;
        _userAggregateRootRepository = userAggregateRootRepository;
        _projectAggregateRootRepository = projectAggregateRootRepository;
    }

    public async Task<Result<BugDto>> Handle(CreateBugCommand request, CancellationToken cancellationToken)
    {
        Result<BugDescription> description = BugDescription.Create(request.Description);
        Result<BugCreationDate> creationDate = BugCreationDate.Create(_dateProvider.UtcNow);

        var firstFailureOrSuccess = Result.FirstFailureOrSuccess(description, creationDate);

        if (firstFailureOrSuccess.IsFailure)
        {
            return await Task.FromResult(Result
                .Failure<BugDto>(firstFailureOrSuccess.Error));
        }

        Maybe<UserAggregateRoot> maybeUser =
            await _userAggregateRootRepository.GetByIdAsync(request.UserId,
            cancellationToken);

        if (maybeUser.HasNoValue)
        {
            return await Task
                .FromResult(Result
                .Failure<BugDto>(UserErrors.NonExist));
        }

        Maybe<ProjectAggregateRoot> maybeProject =
            await _projectAggregateRootRepository.GetByIdAsync(request.ProjectId,
            cancellationToken);

        if (maybeProject.HasNoValue)
        {
            return await Task
                .FromResult(Result
                .Failure<BugDto>(ProjectErrors.NonExist));
        }

        BugEntity newBug = BugEntity.Create(description.Value,
            creationDate.Value, request.UserId, request.ProjectId);

        _bugEntityRepository.Insert(newBug);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        UserDto userDto = new(maybeUser.Value.Id,
            maybeUser.Value.FirstName, maybeUser.Value.LastName);

        ProjectDto projectDto = new(maybeProject.Value.Id,
            maybeProject.Value.ProjectName,
            maybeProject.Value.ProjectDescription);

        BugDto newBugDto = new(newBug.Id,
            newBug.BugDescription.Value, userDto, projectDto, newBug.BugCreationDate.Value);

        return await Task
                  .FromResult(Result
                  .Success(newBugDto));
    }
}
