
using VamosTodos_Test.App.Shared.Abstractions;
using VamosTodos_Test.App.Shared.Abstractions.Services;

namespace VamosTodos_Test.App.Project;

public sealed class ProjectService : HttpApiService, IProjectService
{
	public ProjectService(IHttpClientFactory factory)
		: base(factory) { }

	public async Task<HttpResponseMessage> GetProjectsAll()
		=> await HttpClient.GetAsync("project/all");
}
