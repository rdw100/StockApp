using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using StockApp.Shared;

public static class GetStockPrice
{
    private static readonly HttpClient httpClient = new HttpClient();

    [Function("GetStockPrice")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stock")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string symbol = req.Query["symbol"];

        if (string.IsNullOrEmpty(symbol))
        {
            return new BadRequestObjectResult("Please pass a stock symbol on the query string.");
        }

        string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d&range=5d";
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        HttpResponseMessage response = await httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return new BadRequestObjectResult("Failed to fetch stock data.");
        }

        string responseBody = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(responseBody);

        var chartResult = new ChartResult
        {
            Symbol = symbol,
            Interval = "1d",
            Range = "5d",
            Data = json
        };

        return new OkObjectResult(chartResult);
    }
}

//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.Extensions.Logging;
//using StockApp.Shared;
//using System.Net.Http.Json;

//public static class GetStockPrice
//{
//    private static readonly HttpClient _httpClient = new HttpClient();

//    [FunctionName("GetStockPrice")]
//    public static async Task<IActionResult> Run(
//        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stock")] HttpRequest req,
//        ILogger log)
//    {
//        try
//        {
//            string apiUrl = "https://query1.finance.yahoo.com/v8/finance/chart/";
//            string symbol = req.Query["symbol"];
//            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
//            var response = await _httpClient.GetAsync($"{apiUrl}{symbol}?interval=1d&range=5d");
//            response.EnsureSuccessStatusCode();
//            var result = await response.Content.ReadFromJsonAsync<ChartResult>();
//            return new OkObjectResult(result);
//        }
//        catch (Exception ex)
//        {
//            log.LogError($"Error fetching AAPL stock data: {ex.Message}");
//            return new StatusCodeResult(500);
//        }
//    }
//}
