using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.App.Abstractions.Services;

public interface IBugService
{
    Task<HttpResponseMessage> GetBugsAll();
	Task<HttpResponseMessage> GetBugsBy(GetBugByRequest request);
	Task<HttpResponseMessage> Insert(CreateBugRequest request);
}
