
namespace VamosTodos_Test.Application.Contracts.Bug;

public sealed record BugDto(Guid Id,
    string Description,
    UserDto User,
    ProjectDto Project,
    DateTime CreationDate);
