
using GithubUserFinder.Services.DTOs;

namespace GithubUserFinder.Services.Interfaces
{
    public interface IGithubApiService
    {
        Task<GithubUserRequestResponseDTO> GetUserAndReposByUsername(string username);
        Task<List<GithubUserRepositoriesDTO>> GetTopStargazerReposByUrl(string reposUrl);
    }
}
