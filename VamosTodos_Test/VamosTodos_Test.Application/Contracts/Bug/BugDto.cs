
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Contracts.User;

namespace VamosTodos_Test.Application.Contracts.Bug;

public sealed record BugDto(Guid Id,
    string Description,
    UserDto User,
    ProjectDto Project,
    DateTime CreationDate);
