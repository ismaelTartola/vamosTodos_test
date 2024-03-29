namespace VamosTodos_Test.App.Abstractions.Services;

public interface IUserService
{
	Task<HttpResponseMessage> GetUsersAll();
}
