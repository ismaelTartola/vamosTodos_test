
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace VamosTodos_Test.App;

public static class DependecyInjection
{
    public static IServiceCollection AddCustomHttplient(this IServiceCollection services)
    {
        services.AddHttpClient("HttpApiService", (serviceProvider, client) =>
        {
            client.BaseAddress = new Uri("https://localhost:7049/");           
        });

        return services;
    }
}
