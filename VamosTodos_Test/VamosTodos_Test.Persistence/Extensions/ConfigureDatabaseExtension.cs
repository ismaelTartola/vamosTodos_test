
using VamosTodos_Test.Persistence.OptionsSetup;
using VamosTodos_Test.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

public static class ConfigureDatabaseExtension
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseSettingsOptionsSetup>();

        services.AddDbContext<ApiDbContext>((serviceProvider, dataBaseContextOptionsBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseSettings>>()!.Value;

            //dataBaseContextOptionsBuilder.UseInMemoryDatabase(databaseName: "DDD.Api");

            dataBaseContextOptionsBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerAction.CommandTimeout(databaseOptions.CommandTimeOut);

            });

            dataBaseContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);

            dataBaseContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });


        return services;
    }
}
