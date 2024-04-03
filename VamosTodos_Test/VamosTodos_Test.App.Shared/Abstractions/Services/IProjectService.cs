
namespace VamosTodos_Test.App.Shared.Abstractions.Services;

public interface IProjectService
{
	Task<HttpResponseMessage> GetProjectsAll();
}
