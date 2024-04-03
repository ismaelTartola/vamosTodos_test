using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using VamosTodos_Test.App;
using VamosTodos_Test.App.Abstractions.Services;
using VamosTodos_Test.App.Bug;
using VamosTodos_Test.App.Project;
using VamosTodos_Test.App.Shared.Alert;
using VamosTodos_Test.App.User;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<IBugService, BugService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddCustomHttplient();

await builder.Build().RunAsync();
