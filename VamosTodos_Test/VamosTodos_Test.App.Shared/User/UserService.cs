
using VamosTodos_Test.App.Shared.Abstractions;
using VamosTodos_Test.App.Shared.Abstractions.Services;

namespace VamosTodos_Test.App.Client.User;

public sealed class UserService : HttpApiService, IUserService
{
	public UserService(IHttpClientFactory factory)
		: base(factory) { }

	public async Task<HttpResponseMessage> GetUsersAll()
		=> await HttpClient.GetAsync("user/all");
}

