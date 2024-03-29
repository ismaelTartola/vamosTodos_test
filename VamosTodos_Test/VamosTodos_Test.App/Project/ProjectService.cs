
using VamosTodos_Test.App.Abstractions;
using VamosTodos_Test.App.Abstractions.Services;

namespace VamosTodos_Test.App.Project;

internal sealed class ProjectService : HttpApiService, IProjectService
{
	public ProjectService(IHttpClientFactory factory)
		: base(factory) { }

	public async Task<HttpResponseMessage> GetProjectsAll()
		=> await HttpClient.GetAsync("project/all");
}
