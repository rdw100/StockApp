using System.Text.Json.Serialization;

namespace StockApp.Shared
{
    public class StockResult
    {
        [JsonPropertyName("Symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("Interval")]
        public string Interval { get; set; }

        [JsonPropertyName("Range")]
        public string Range { get; set; }

        [JsonPropertyName("Data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("Open")]
        public List<long> Open { get; set; }

        [JsonPropertyName("Close")]
        public List<long> Close { get; set; }

        [JsonPropertyName("High")]
        public List<long> High { get; set; }

        [JsonPropertyName("Low")]
        public List<long> Low { get; set; }
    }    
}