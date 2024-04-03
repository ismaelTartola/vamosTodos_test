
namespace VamosTodos_Test.App.Shared.Abstractions;

public class HttpApiService
{
    private readonly IHttpClientFactory _factory;

    public HttpApiService(IHttpClientFactory factory)
    {
        _factory = factory;
        HttpClient = _factory.CreateClient("HttpApiService");
    }

    protected HttpClient HttpClient { get; init; }
}
