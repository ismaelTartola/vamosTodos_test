
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsBy;

public sealed record GetBugsByQuery : IQuery<GetBugsResponse>
{
    public GetBugsByQuery(Guid userId, Guid projectId, DateTime startDate, DateTime endDate)
    {
        UserId = userId;
        ProjectId = projectId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Guid UserId { get; }
    public Guid ProjectId { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
}
