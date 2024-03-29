
using Microsoft.EntityFrameworkCore;
using VamosTodos_Test.Application.Abstractions.Data;
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Bug.Querys.GetBugsAll;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Contracts.User;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.SharedKernel.MaybeObject;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsBy;


public sealed class GetBugsAllQueryHandler : IQueryHandler<GetBugsAllQuery, GetBugsResponse>
{
	private readonly IDbContext _dbContext;

	public GetBugsAllQueryHandler(IDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Maybe<GetBugsResponse>> Handle(GetBugsAllQuery request, CancellationToken cancellationToken)
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
			return Maybe<GetBugsResponse>.None;
		}

		List<BugDto> response = await bugsQueryable.ToListAsync(cancellationToken);

		return Maybe<GetBugsResponse>.From(new GetBugsResponse(response));
	}
}
