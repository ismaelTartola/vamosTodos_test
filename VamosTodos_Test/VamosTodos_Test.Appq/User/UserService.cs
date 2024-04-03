
using VamosTodos_Test.App.Abstractions;
using VamosTodos_Test.App.Abstractions.Services;

namespace VamosTodos_Test.App.User;

internal sealed class UserService : HttpApiService, IUserService
{
	public UserService(IHttpClientFactory factory)
		: base(factory) { }

	public async Task<HttpResponseMessage> GetUsersAll()
		=> await HttpClient.GetAsync("user/all");
}

