using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UsaTodayTopNews
{
    public static class UsaTodayApi
    {
        private static string ApiKey = "YOUR_API_KEY";

        public static async Task<List<NewsArticle>> GetTopNews()
        {
            string topNewsUri = "http://api.usatoday.com/open/articles/mobile/topnews?encoding=json&api_key=" + ApiKey;
            HttpClient client = new HttpClient();
            JsonSerializer serializer = new JsonSerializer();

            string json = await client.GetStringAsync(topNewsUri);
            NewsArticleSet articleSet = serializer.Deserialize<NewsArticleSet>(new JsonTextReader(new StringReader(json)));

            return articleSet.stories;
        }
    }
}
