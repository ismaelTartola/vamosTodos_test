using VamosTodos_Test.App.Shared;

namespace VamosTodos_Test.App.Abstractions;

internal class HttpApiService
{
    private readonly IHttpClientFactory _factory;

    public HttpApiService(IHttpClientFactory factory)
    {
        _factory = factory;
        HttpClient = _factory.CreateClient("HttpApiService");
    }

    protected HttpClient HttpClient { get; init; }
}
