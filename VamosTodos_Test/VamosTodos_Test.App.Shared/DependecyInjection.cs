
using Microsoft.Extensions.DependencyInjection;
using VamosTodos_Test.App.Client.User;
using VamosTodos_Test.App.Project;
using VamosTodos_Test.App.Shared.Abstractions.Services;
using VamosTodos_Test.App.Shared.Alert;
using VamosTodos_Test.App.Shared.Bug;

namespace VamosTodos_Test.App.Shared;

public static class DependecyInjection
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddHttpClient("HttpApiService", (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://localhost:7049/");           
        });

		services.AddScoped<IBugService, BugService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IProjectService, ProjectService>();
		services.AddScoped<IAlertService, AlertService>();

		return services;
    }
}
