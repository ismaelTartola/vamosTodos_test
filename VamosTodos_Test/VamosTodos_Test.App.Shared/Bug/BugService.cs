﻿
using System.Text;
using VamosTodos_Test.App.Shared.Abstractions;
using VamosTodos_Test.App.Shared.Abstractions.Services;
using VamosTodos_Test.Application.Contracts.Bug;

namespace VamosTodos_Test.App.Shared.Bug;

public sealed class BugService : HttpApiService, IBugService
{
    public BugService(IHttpClientFactory factory)
        : base(factory) { }

    public async Task<HttpResponseMessage> GetBugsAllPaged(GetBugsAllPagedRequest request) {

		var queryParameters = new Dictionary<string, string>
			{
				{ "page", request.Page.ToString() },
				{ "pagesize", request.PageSize.ToString()}
			};

		var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
		var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

		return await HttpClient.GetAsync($"bug/all?{queryString}");
	} 

	public async Task<HttpResponseMessage> GetBugsByPaged(GetBugByPagedRequest request)
	{
		var queryParameters = new Dictionary<string, string>
			{
				{ "projectid", request.ProjectId.ToString() },
				{ "userid", request.UserId.ToString()},
				{ "startdate", request.StartDate.ToString("yyyy-M-dd")},
				{ "enddate", request.EndDate.ToString("yyyy-M-dd") },
				{ "page", request.Page.ToString() },
				{ "pagesize", request.PageSize.ToString()}
			};
		var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
		var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

		return await HttpClient.GetAsync($"bug?{queryString}");		
	}

	public async Task<HttpResponseMessage> Insert(CreateBugRequest request)
    {
        var queryParameters = new Dictionary<string, string>
            {
                { "userid", request.UserId.ToString() },
                { "projectid",request.ProjectId.ToString()},
                { "description",request.Description}
            };
        var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);
        var queryString = await dictFormUrlEncoded.ReadAsStringAsync();
        HttpContent content = new StringContent(queryString, Encoding.UTF8, "application/json");

        return await HttpClient.PostAsync($"bug/create?{queryString}", content);       
    }
}
