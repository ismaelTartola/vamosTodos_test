
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using VamosTodos_Test.App.Abstractions.Services;
using VamosTodos_Test.App.Shared;
using VamosTodos_Test.Application.Abstractions.Services;
using VamosTodos_Test.Application.Contracts.Bug;
using VamosTodos_Test.Infraestructure.Common;

namespace VamosTodos_Test.App.Pages;

public class BugsBase : ComponentBase
{
    [Inject]
    private IBugService BugService { get; set; }

    [Inject]
    private IAlertService AlertService { get; set; }

    protected List<BugDto>? Bugs { get; set; }

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
    }

    protected async Task GetBugAll()
    {
		try
		{
			var response = await BugService.GetBugsAll();

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
}
