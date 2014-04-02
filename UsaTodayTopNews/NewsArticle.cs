using System;
using Newtonsoft.Json;

namespace UsaTodayTopNews
{
    public class NewsArticle
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("pubDate")]
        public DateTime PublicationDate { get; set; }
    }
}
