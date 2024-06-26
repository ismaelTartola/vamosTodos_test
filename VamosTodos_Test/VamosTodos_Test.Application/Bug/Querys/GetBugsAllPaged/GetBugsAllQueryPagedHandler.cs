﻿
using Microsoft.EntityFrameworkCore;
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Bug.Querys.GetBugsAllPaged;
using VamosTodos_Test.Application.Common.Pagination;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Contracts.User;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsByPaged;


public sealed class GetBugsAllQueryPagedHandler : IQueryHandler<GetBugsAllPagedQuery, PagedList<BugDto>>
{
	private readonly IDbContext _dbContext;

	public GetBugsAllQueryPagedHandler(IDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Maybe<PagedList<BugDto>>> Handle(GetBugsAllPagedQuery request, CancellationToken cancellationToken)
	{
		IQueryable<BugDto> bugsQueryable = from bug in _dbContext.Set<BugEntity>()
										   join user in _dbContext.Set<UserAggregateRoot>().AsNoTracking()
											   on bug.UserId equals user.Id
										   join project in _dbContext.Set<ProjectAggregateRoot>().AsNoTracking()
											   on bug.ProjectId equals project.Id
										   select new BugDto(bug.Id,
											  bug.BugDescription,
											  new UserDto(user.Id, user.FirstName.Value,
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
