
using Microsoft.Extensions.DependencyInjection;
using VamosTodos_Test.Application.Abstractions.Services;
using VamosTodos_Test.Infraestructure.Common;

namespace VamosTodos_Test.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
}