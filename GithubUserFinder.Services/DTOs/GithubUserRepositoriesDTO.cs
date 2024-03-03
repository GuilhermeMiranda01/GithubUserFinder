namespace GithubUserFinder.Services.DTOs
{
    public class GithubUserRepositoriesDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Html_Url { get; set; }
        public int Stargazers_Count { get; set; }
        public string? Language { get; set; }
        public string? LanguageImage { get; set; }
    }
}
