namespace GithubUserFinder.Services.DTOs
{
    public class GithubUserDTO
    {
        public string Login { get; set; }
        public string Location { get; set; }
        public string Avatar_Url { get; set; }
        public string Repos_Url { get; set;}
        public List<GithubUserRepositoriesDTO> UserRepositories { get; set; }
    }
}