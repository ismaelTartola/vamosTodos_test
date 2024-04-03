
namespace VamosTodos_Test.App.Shared.Abstractions.Services;

public interface IUserService
{
	Task<HttpResponseMessage> GetUsersAll();
}
