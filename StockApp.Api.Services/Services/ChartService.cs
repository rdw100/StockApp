using Microsoft.Extensions.Options;
using StockApp.Api.Services.Interfaces;
using StockApp.Shared;
using System.Net.Http.Json;

namespace StockApp.Api.Services
{
    public class ChartService : IChartService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly string chartUrl;

        public ChartService(IOptions<ServiceOptions> options)
        {
            chartUrl = options.Value.ChartUrl;
        }

        public async Task<ChartResult> GetChartData(string symbol, string interval, string range)
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            var url = $"{chartUrl}{symbol}?interval={interval}&range={range}";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var chartResult = await response.Content.ReadFromJsonAsync<ChartResult>();
            return chartResult;
        }
    }
}