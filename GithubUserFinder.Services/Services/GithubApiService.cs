
using GithubUserFinder.Services.DTOs;
using GithubUserFinder.Services.Interfaces;
using Newtonsoft.Json;

namespace GithubUserFinder.Services
{
    public class GithubApiService : IGithubApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string GithubUrl = "https://api.github.com/users/";
        public GithubApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
        }

        public async Task<GithubUserRequestResponseDTO> GetUserAndReposByUsername(string username)
        {
            var requestResponse = new GithubUserRequestResponseDTO();

            var getUserApiUrl = $"{GithubUrl}{username}";
            var response = await _httpClient.GetAsync(getUserApiUrl);

            requestResponse.IsSuccessStatusCode = response.IsSuccessStatusCode;
            requestResponse.StatusCode = response.StatusCode.ToString();

            if (!requestResponse.IsSuccessStatusCode)
            {
                requestResponse.ErrorMessage = GithubApiErrorHandlerService
                                                .GetErrorMessageByStatusCode(requestResponse.StatusCode);
                return requestResponse;
            }

            var content = await response.Content.ReadAsStringAsync();

            requestResponse.GithubUser = JsonConvert.DeserializeObject<GithubUserDTO>(content);

            requestResponse.GithubUser.UserRepositories = await GetTopStargazerReposByUrl(requestResponse.GithubUser.Repos_Url);

            return requestResponse;
        }

        public async Task<List<GithubUserRepositoriesDTO>> GetTopStargazerReposByUrl(string reposUrl)
        {
            var responseRepos = await _httpClient.GetAsync(reposUrl);

            var contentRepos = await responseRepos.Content.ReadAsStringAsync();

            var userRepos = JsonConvert.DeserializeObject<List<GithubUserRepositoriesDTO>>(contentRepos);


            var top5UserRepos = userRepos.OrderByDescending(x => x.Stargazers_Count).Take(5).ToList();

            return top5UserRepos;
        }
    }
}
