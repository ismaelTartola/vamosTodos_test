
namespace VamosTodos_Test.Application.Contracts.Bug;

public sealed record CreateBugRequest(Guid UserId,
    Guid ProjectId,
    string Description);
