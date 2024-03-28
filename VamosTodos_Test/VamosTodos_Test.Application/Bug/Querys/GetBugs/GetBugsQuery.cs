
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugs;

public sealed class GetBugsQuery : IQuery<GetBugsResponse>
{
    public GetBugsQuery(Guid userId, Guid projectId, DateTime startDate, DateTime endDate)
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
