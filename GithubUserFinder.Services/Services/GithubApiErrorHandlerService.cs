namespace GithubUserFinder.Services
{
    public static class GithubApiErrorHandlerService
    {
        public static string GetErrorMessageByStatusCode(string status)
        {
            string errorMessage;

            switch(status)
            {
                case "NotFound":
                    errorMessage = "User not found.";
                    break;
                case "Forbidden":
                    errorMessage = "For unauthenticated users, the Github API only accepts 60 requests per hour.";
                    break;
                default:
                    errorMessage = "The Github API is currently not accessible.";
                    break;
            }

            return errorMessage;
        }
    }
}
