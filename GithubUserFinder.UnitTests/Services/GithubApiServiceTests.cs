using GithubUserFinder.Services;
using GithubUserFinder.Services.DTOs;
using System.Net;

namespace GithubUserFinder.UnitTests.Services
{
    public class GithubApiServiceTests
    {
        private HttpClient _httpClient;
        private GithubApiService githubApiService;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
            githubApiService = new GithubApiService(_httpClient);
        }

        [Test]
        [TestCase("GuilhermeMiranda01", true)]
        [TestCase("test123456user", false)]
        public async Task GetUserAndReposByUsername_ShouldReturnOk_ThenNotFound(string username, bool isOkStatusCode)
        {
            var response = await githubApiService.GetUserAndReposByUsername(username);
            if (isOkStatusCode)
            {
                Assert.That(response.StatusCode, Is.EqualTo("OK"));
            }
            else
            {
                Assert.That(response.StatusCode, Is.EqualTo("NotFound"));
            }
        }

    }
}