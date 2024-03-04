
namespace GithubUserFinder.Web.Content
{
    public static class LanguageImageDictionary
    {
        public static readonly IDictionary<string, string> languageImageDict = new Dictionary<string, string>()
            {
                               {"c++","cpp.png"},
                               {"c","c.png"},
                               {"c#","csharp.png"},
                               {"java","java.png"},
                               {"javascript","js.png"},
                               {"typescript","ts.png"},
                               {"ruby","ruby.png"},
                               {"python","python.png"},
                               {"html","html-5.png"},
                               {"css","css-3.png"},
                               {"php","php.png"},
                               {"go","go.png"},
                               {"swift","swift.png"},
                               {"objective-c","objective-c.png"}
            };

        public static string GetLanguageImage(string language)
        {
            if (!String.IsNullOrWhiteSpace(language))
            {
                language = language.ToLower();
                if (languageImageDict.TryGetValue(language, out string image))
                {
                    return image;
                };
            }
            return String.Empty;
        }
    }
}
