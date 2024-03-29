
namespace VamosTodos_Test.Application.Contracts.Bug;

public sealed record GetBugByRequest(Guid ProjectId, Guid UserId, DateTime StartDate, DateTime EndDate)
{
    public bool InvalidRequest => (ProjectId == Guid.Empty
        && UserId == Guid.Empty
        && StartDate == DateTime.MinValue
        && EndDate == DateTime.MinValue);

    public bool ValidRequest => !InvalidRequest;
}
