using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.App.Abstractions.Services;

public interface IBugService
{
    Task<HttpResponseMessage> GetBugsAllPaged(GetBugsAllPagedRequest request);
	Task<HttpResponseMessage> GetBugsByPaged(GetBugByPagedRequest request);
	Task<HttpResponseMessage> Insert(CreateBugRequest request);
}
