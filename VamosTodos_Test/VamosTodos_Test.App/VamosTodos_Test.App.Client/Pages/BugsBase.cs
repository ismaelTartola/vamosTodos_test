
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using VamosTodos_Test.App.Client.Shared.Pager;
using VamosTodos_Test.App.Shared.Abstractions.Services;
using VamosTodos_Test.App.Shared.Alert;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Application.Contracts.Project;
using VamosTodos_Test.Application.Contracts.User;

namespace VamosTodos_Test.App.Client.Pages;

public class BugsBase : ComponentBase
{
    [Inject]
    private IBugService BugService { get; set; } = null!;

	[Inject]
	private IUserService UserService { get; set; } = null!;

	[Inject]
	private IProjectService ProjectService { get; set; } = null!;

	[Inject]
    private IAlertService AlertService { get; set; } = null!;

	[Inject]
    public NavigationManager UriHelper { get; set; } = null!;

	[Parameter]
	public int Page { get; set; }

	protected CustomPagedList<BugDto>? Bugs { get; set; } = null;

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
		Page = (Page == 0) ? 1 : Page;

		await GetBugAllPaged();
		await GetProjectAll();
		await GetUsersAll();
	}

    protected async Task GetBugAllPaged()
    {
		try
		{
			GetBugsAllPagedRequest request = new(Page, 3);

			var response = await BugService.GetBugsAllPaged(request);

			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				Bugs = new CustomPagedList<BugDto>(new List<BugDto>(), Page, 3, 0);
				return;
			}

			if (!response.IsSuccessStatusCode)
				throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");
			

			CustomPagedList<BugDto>? responseObject 
				= await response.Content.ReadFromJsonAsync<CustomPagedList<BugDto>>();

			Bugs = responseObject;
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

			await GetBugAllPaged();        

        }
        catch (Exception ex)
		{
			AlertService.Error(ex.Message);
		}
	}

    protected async Task FilterBugsPaged()
    {        
		try
		{
			GetBugByPagedRequest request
			= new GetBugByPagedRequest(FilterProjectId, FilterUserId, FilterStartDate, FilterEndDate, Page, 5);

			var response = await BugService.GetBugsByPaged(request);

			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				Bugs = new CustomPagedList<BugDto>(new List<BugDto>(), Page, 3, 0);
				return;
			}

			if (!response.IsSuccessStatusCode)
				throw new Exception($"{response.StatusCode}: {response.ReasonPhrase}");			

			CustomPagedList<BugDto>? responseObject
				= await response.Content.ReadFromJsonAsync<CustomPagedList<BugDto>>();

			Bugs = responseObject;

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

	protected void PagerPageChanged(int page)
	{
		UriHelper.NavigateTo("/" + page);
	}	

}
