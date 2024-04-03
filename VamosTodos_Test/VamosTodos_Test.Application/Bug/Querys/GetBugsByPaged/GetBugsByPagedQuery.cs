
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Common.Pagination;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsPagedBy;

public sealed record GetBugsByPagedQuery : IQuery<PagedList<BugDto>>
{
    public GetBugsByPagedQuery(Guid userId,
        Guid projectId,
        DateTime startDate,
        DateTime endDate,
        int page,
        int pageSize)
    {
        UserId = userId;
        ProjectId = projectId;
        StartDate = startDate;
        EndDate = endDate;
        Page = page;
        PageSize = pageSize;
    }

    public Guid UserId { get; }
    public Guid ProjectId { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public int Page { get; }
    public int PageSize { get; }
}
