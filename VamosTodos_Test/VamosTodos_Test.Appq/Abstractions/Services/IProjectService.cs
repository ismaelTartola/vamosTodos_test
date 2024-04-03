namespace VamosTodos_Test.App.Abstractions.Services;

public interface IProjectService
{
	Task<HttpResponseMessage> GetProjectsAll();
}
