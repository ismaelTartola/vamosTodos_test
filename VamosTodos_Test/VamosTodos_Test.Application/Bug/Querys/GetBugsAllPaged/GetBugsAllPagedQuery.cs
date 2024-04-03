
using VamosTodos_Test.Application.Abstractions.Messaging;
using VamosTodos_Test.Application.Common.Pagination;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.Application.Bug.Querys.GetBugsAllPaged;


public sealed record GetBugsAllPagedQuery(int Page, int PageSize)
	: IQuery<PagedList<BugDto>>
{ }
