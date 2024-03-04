using GithubUserFinder.Services.DTOs;
using GithubUserFinder.Services.Interfaces;
using GithubUserFinder.Web.Content;
using Microsoft.AspNetCore.Mvc;



namespace GithubUserFinder.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGithubApiService _githubApiService;
        public HomeController(IGithubApiService githubApiService)
        {
            _githubApiService = githubApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> GetUserByUsername(string username)
        {
            var result = await _githubApiService.GetUserAndReposByUsername(username);
            if (result.GithubUser != null && result.GithubUser.UserRepositories != null)
            {
                foreach (var repo in result.GithubUser.UserRepositories){
                    repo.LanguageImage = LanguageImageDictionary.GetLanguageImage(repo.Language);
                }
            }
            return PartialView("GithubUserPartial", result);
        }
    }
}