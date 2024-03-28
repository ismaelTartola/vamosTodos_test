
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.Application.Bug.Commands.CreateBugCommand;

public sealed record CreateBugCommand(Guid UserId,
    Guid ProjectId,
    string Description) : ICommand<BugDto>
{ }
