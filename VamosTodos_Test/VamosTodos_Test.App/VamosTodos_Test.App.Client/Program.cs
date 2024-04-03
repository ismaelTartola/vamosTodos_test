using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VamosTodos_Test.App.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSharedServices();

await builder.Build().RunAsync();
