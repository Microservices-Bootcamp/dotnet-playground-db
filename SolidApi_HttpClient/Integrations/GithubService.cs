using Microsoft.Net.Http.Headers;
using SolidApi_HttpClient.Integrations;
using SolidApi_HttpClient.Products.Integrations;

namespace SolidApi_HttpClient.Integrations
{
    public class GithubService
    {
        private readonly HttpClient _httpClient;

        public GithubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.github.com");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "sample");
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
        }

        public async Task<IEnumerable<GithubBranch>?> GetBranches()
        {
            const string branchesUrl = "/repos/dotnet/AspNetCore.Docs/branches";
            return await _httpClient.GetFromJsonAsync<IEnumerable<GithubBranch>>(branchesUrl);
        }

    }
}

