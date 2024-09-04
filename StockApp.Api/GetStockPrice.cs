using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using StockApp.Shared;
using System.Net.Http.Json;

public static class GetStockPrice
{
    private static readonly HttpClient _httpClient = new HttpClient();

    [FunctionName("GetStockPrice")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        try
        {
            string apiUrl = "https://query1.finance.yahoo.com/v8/finance/chart/";
            string symbol = req.Query["symbol"];
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            var response = await _httpClient.GetAsync($"{apiUrl}{symbol}?interval=1d&range=5d");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<ChartResult>();
            return new OkObjectResult(result);
        }
        catch (Exception ex)
        {
            log.LogError($"Error fetching AAPL stock data: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }
}
