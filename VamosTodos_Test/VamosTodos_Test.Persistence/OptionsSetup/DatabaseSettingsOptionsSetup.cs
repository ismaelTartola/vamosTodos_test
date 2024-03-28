

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace VamosTodos_Test.Persistence.OptionsSetup;

public class DatabaseSettingsOptionsSetup : IConfigureOptions<DatabaseSettings>
{
    private const string SectionName = "DatabaseSettings";
    private readonly IConfiguration _configuration;

    public DatabaseSettingsOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseSettings options)
    {
        var connectionstring = _configuration.GetConnectionString("Default")!;

        options.ConnectionString = connectionstring;

        _configuration.GetSection(SectionName).Bind(options);
    }
}