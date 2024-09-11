using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StockApp.Shared;
using System.Net.Http.Json;

namespace StockApp.Api;

public class GetStockPrice
{
    private static readonly HttpClient httpClient = new HttpClient();

    [Function("GetStockPrice")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", 
        Route = "stockprice/{symbol}")] HttpRequestData req, 
        string symbol, 
        FunctionContext executionContext)
    {
        var log = executionContext.GetLogger("GetStockPrice");
        log.LogInformation("C# HTTP trigger function processed a request.");

        string interval = req.Query["interval"] ?? "1d";
        string range = req.Query["range"] ?? "5d";
        var configuration = executionContext.InstanceServices.GetService<IConfiguration>();
        string baseUrl = configuration["BaseUrl"];
        string apiUrl = $"{baseUrl}{symbol}?interval={interval}&range={range}";

        if (string.IsNullOrEmpty(symbol))
        {
            return new BadRequestObjectResult("Please pass a stock symbol on the query string.");
        }

        try
        {
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            //var chartResult = await httpClient.GetFromJsonAsync<ChartResult>(apiUrl);
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            var chartResult = await response.Content.ReadFromJsonAsync<ChartResult>();
            if (chartResult == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(chartResult);
        }
        catch (HttpRequestException ex)
        {
            log.LogError($"Error fetching stock data: {ex.Message}");
            return new StatusCodeResult(500); // Return 500 if something goes wrong
        }
    }
}