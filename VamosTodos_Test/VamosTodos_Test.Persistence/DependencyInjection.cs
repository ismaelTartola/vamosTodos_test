
using VamosTodos_Test.Application.Abstractions.Data;
using Microsoft.Extensions.DependencyInjection;
using VamosTodos_Test.Domain.User;
using VamosTodos_Test.Domain.Project;
using VamosTodos_Test.Domain.Bug;
using VamosTodos_Test.Persistence.User;
using VamosTodos_Test.Persistence.Project;
using VamosTodos_Test.Persistence.Bug;

namespace VamosTodos_Test.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDatabaseConfiguration();

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApiDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApiDbContext>());

        services.AddScoped<IUserAggregateRootRepository, UserAggregateRootRepository>();

        services.AddScoped<IProjectAggregateRootRepository, ProjectAggregateRootRepository>();

        services.AddScoped<IBugEntityRepository, BugEntityRepository>();

        return services;
    }
}