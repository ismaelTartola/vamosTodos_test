
using Microsoft.EntityFrameworkCore;
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Common.Pagination;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Contracts.User;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsPagedBy;


public sealed class GetBugsByPagedQueryHandler : IQueryHandler<GetBugsByPagedQuery, PagedList<BugDto>>
{
    private readonly IDbContext _dbContext;

    public GetBugsByPagedQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Maybe<PagedList<BugDto>>> Handle(GetBugsByPagedQuery request, CancellationToken cancellationToken)
    {
        IQueryable<BugEntity> queryable = _dbContext.Set<BugEntity>();

        if (request.UserId != Guid.Empty)
        {
            queryable = queryable.Where(x => x.UserId == request.UserId);
        }

        if (request.ProjectId != Guid.Empty)
        {
            queryable = queryable.Where(x => x.ProjectId == request.ProjectId);
        }

        if (request.StartDate != DateTime.MinValue)
        {
            queryable = queryable.Where(x => x.BugCreationDate.Value >= request.StartDate);
        }

        if (request.EndDate != DateTime.MinValue && (request.StartDate != request.EndDate))
        {
            queryable = queryable.Where(x => x.BugCreationDate.Value <= request.EndDate);
        }

        IQueryable<BugDto> bugsQueryable =  from bug in queryable
                            join user in _dbContext.Set<UserAggregateRoot>().AsNoTracking()
                                on bug.UserId equals user.Id
                            join project in _dbContext.Set<ProjectAggregateRoot>().AsNoTracking()
                                on bug.ProjectId equals project.Id
                            select new BugDto(bug.Id,
                               bug.BugDescription, 
                               new  UserDto(user.Id, user.FirstName.Value,
                                    user.LastName.Value),
                                new
                                    ProjectDto(project.Id,
                                    project.ProjectName.Value,
                                    project.ProjectDescription.Value),
                                bug.BugCreationDate.Value);

        if (await bugsQueryable.CountAsync(cancellationToken) == 0)
        {
            return Maybe<PagedList<BugDto>>.None;
        }

        PagedList<BugDto> bugs
           = await PagedList<BugDto>.Create(bugsQueryable,
           request.Page, request.PageSize, cancellationToken);

        return Maybe<PagedList<BugDto>>.From(bugs);
    }
}
