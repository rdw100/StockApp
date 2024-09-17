using Microsoft.Extensions.Options;
using StockApp.Shared.Interfaces;
using System.Net.Http.Json;

namespace StockApp.Shared
{
    public class ChartService : IChartService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly string baseUrl;

        public ChartService(IOptions<ChartServiceOptions> options)
        {
            baseUrl = options.Value.BaseUrl;
        }

        public async Task<ChartResult> GetChartPriceAsync(string symbol, string interval, string range)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            var url = $"{baseUrl}{symbol}?interval={interval}&range={range}";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var chartResult = await response.Content.ReadFromJsonAsync<ChartResult>();
            return chartResult;
        }
    }
}