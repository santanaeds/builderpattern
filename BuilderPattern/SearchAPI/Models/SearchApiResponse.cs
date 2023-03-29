using System.Text.Json.Serialization;

namespace SearchAPI.Models
{
    public class SearchApiResponse<T>
    {
        [JsonPropertyName("@odata.count")]
        public int ItemsCount { get; set; }
        [JsonPropertyName("value")]
        public List<T> Items { get; set; } = new List<T>();
        [JsonPropertyName("@search.nextPageParameters")]
        public SearchApiRequest NextParameters { get; set; }
    }
}
