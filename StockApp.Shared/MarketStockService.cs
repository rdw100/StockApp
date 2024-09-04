namespace StockApp.Shared
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    //using Microsoft.Extensions.Configuration;

    public class MarketStockService : IStockService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiRootUrl;
        private HttpClient httpClient;

        public MarketStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            _apiRootUrl = "https://query1.finance.yahoo.com/v8/finance/chart/";
        }

        public string ServiceName => "Market Stock API";

        public async Task<ChartResult> GetStockPriceAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"{_apiRootUrl}{symbol}?interval=1d&range=5d");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ChartResult>();
            return result;
        }
    }
}