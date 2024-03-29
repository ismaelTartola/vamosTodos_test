
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using VamosTodos_Test.App.Abstractions.Services;
using VamosTodos_Test.App.Shared;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Contracts.User;

namespace VamosTodos_Test.App.Pages;

public class BugsBase : ComponentBase
{
    [Inject]
    private IBugService BugService { get; set; }

	[Inject]
	private IUserService UserService { get; set; }

	[Inject]
	private IProjectService ProjectService { get; set; }

	[Inject]
    private IAlertService AlertService { get; set; }

    protected List<BugDto>? Bugs { get; set; }

	protected List<UserDto>? Users { get; set; }

	protected List<ProjectDto>? Projects { get; set; }

	protected Guid UserId { get; set; } = Guid.Empty;

	protected Guid ProjectId { get; set; } = Guid.Empty;

	protected string Description { get; set; } = string.Empty;

	protected Guid FilterUserId { get; set; } = Guid.Empty;

	protected Guid FilterProjectId { get; set; } = Guid.Empty;

    protected DateTime FilterStartDate { get; set; } = DateTime.UtcNow;

    protected DateTime FilterEndDate { get; set; } = DateTime.UtcNow;


	protected async override Task OnInitializedAsync()
    {
		await GetBugAll();
		await GetProjectAll();
		await GetUsersAll();
    }

    protected async Task GetBugAll()
    {
		try
		{
			var response = await BugService.GetBugsAll();

			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				UserDto testUser = new UserDto(Guid.Empty, "TestFirstName", "TestLastName");
				ProjectDto testProject = new ProjectDto(Guid.Empty, "TestProject", "This is a test Demo Project");
				BugDto testBug = new BugDto(Guid.Empty, "This is and empty bug. The database has no values.", testUser, testProject, DateTime.UtcNow);
				Bugs = [testBug];
				return;
			}

			if (!response.IsSuccessStatusCode)
				throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");

			GetBugsResponse? responseObject = await response.Content.ReadFromJsonAsync<GetBugsResponse>();

			Bugs = responseObject!.Bugs;
		}
		catch (Exception e)
		{
			AlertService.Error(e.Message);
		}
	}

	protected async Task CreateBug()
	{
        try
		{
			CreateBugRequest request = new(UserId, ProjectId, Description);
			var response = await BugService.Insert(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");

            BugDto? responseObject = await response.Content.ReadFromJsonAsync<BugDto>();

            if (responseObject is not null)
            {
                Bugs.Add(responseObject);
            }            

        }
        catch (Exception ex)
		{
			AlertService.Error(ex.Message);
		}
	}

    protected async Task FilterBugs()
    {        
		try
		{
			GetBugByRequest request
			= new GetBugByRequest(FilterProjectId, FilterUserId, FilterStartDate, FilterEndDate);

			var response = await BugService.GetBugsBy(request);

			if (!response.IsSuccessStatusCode)
				throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");

			GetBugsResponse? responseObject = await response.Content.ReadFromJsonAsync<GetBugsResponse>();

			Bugs = responseObject!.Bugs;

		}
		catch (Exception ex)
		{
			AlertService.Error(ex.Message);
		}
	}

	private async Task GetProjectAll()
	{
		try
		{
			var response = await ProjectService.GetProjectsAll();

			if (!response.IsSuccessStatusCode)
				throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");

			GetProjectsResponse? responseObject = await response.Content.ReadFromJsonAsync<GetProjectsResponse>();

			Projects = responseObject!.Projects;
		}
		catch (Exception e)
		{
			AlertService.Error(e.Message);
		}
	}

	private async Task GetUsersAll()
	{
		try
		{
			var response = await UserService.GetUsersAll();

			if (!response.IsSuccessStatusCode)
				throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");

			GetUsersResponse? responseObject = await response.Content.ReadFromJsonAsync<GetUsersResponse>();

			Users = responseObject!.Users;
		}
		catch (Exception e)
		{
			AlertService.Error(e.Message);
		}
	}
}
