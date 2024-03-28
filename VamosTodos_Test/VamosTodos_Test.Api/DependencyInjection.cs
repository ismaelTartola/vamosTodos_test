
using VamosTodos_Test.Api.Middlewares;
using VamosTodos_Test.Api.Common.Mappings;

namespace VamosTodos_Test.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        services.AddExceptionHandler<GlobalErrorHandlingMiddleware>();
        services.AddProblemDetails();

        services.AddControllers();

        return services;
    }
}