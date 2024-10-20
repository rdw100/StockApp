using Newtonsoft.Json;

namespace StockApp.Shared.Models
{
    public class Watch
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        public List<string> WatchList { get; set; } 
    }
}
