namespace FjRuiYiPack.Web.Services
{
    public static partial class API
    {
        public static class Article
        {
            public static string GetArticles(string baseUrl) => $"{baseUrl}/articles/3/0/4";

            public static string GetArticle(string baseUrl) => $"{baseUrl}/articles/browse";

            public static string GetCategories(string baseUrl) => $"{baseUrl }/categories/3/4/both";
        }
    }
}
