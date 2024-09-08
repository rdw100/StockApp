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
    private static HttpClient _httpClient = new HttpClient();

    [Function("GetStockPrice")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stockprice/{symbol}")] HttpRequestData req, string symbol, FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("GetStockPrice");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        string interval = req.Query["interval"];
        string range = req.Query["range"];
        var configuration = executionContext.InstanceServices.GetService<IConfiguration>();
        string baseUrl = configuration["BaseUrl"];
        string apiUrl = $"{baseUrl}{symbol}?interval={interval}&range={range}";

        try
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

            var chartResult = await _httpClient.GetFromJsonAsync<ChartResult>(apiUrl);

            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await response.WriteAsJsonAsync(chartResult);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogError($"Error fetching stock data: {ex.Message}");
            var errorResponse = req.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
            await errorResponse.WriteStringAsync("Error fetching stock data.");
            return errorResponse;
        }
    }

    //private static readonly HttpClient httpClient = new HttpClient();

    //[Function("GetStockPrice")]
    //public static async Task<IActionResult> Run(
    //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stock")] HttpRequest req,
    //    ILogger log)
    //{
    //    log.LogInformation("C# HTTP trigger function processed a request.");

    //    string symbol = req.Query["symbol"];

    //    if (string.IsNullOrEmpty(symbol))
    //    {
    //        return new BadRequestObjectResult("Please pass a stock symbol on the query string.");
    //    }

    //    string url = $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d&range=5d";
    //    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
    //    HttpResponseMessage response = await httpClient.GetAsync(url);

    //    if (!response.IsSuccessStatusCode)
    //    {
    //        return new BadRequestObjectResult("Failed to fetch stock data.");
    //    }

    //    string responseBody = await response.Content.ReadAsStringAsync();
    //    JObject json = JObject.Parse(responseBody);

    //    var chartResult = new ChartResult
    //    {
    //        Symbol = symbol,
    //        Interval = "1d",
    //        Range = "5d"
    //    };

    //    return new OkObjectResult(chartResult);
    //}
}