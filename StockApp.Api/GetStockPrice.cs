using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using StockApp.Shared.Interfaces;

namespace StockApp.Api;

public class GetStockPrice
{

    private readonly IChartService chartService;

    public GetStockPrice(IChartService iChartService)
    {
        chartService = iChartService;
    }

    [Function("GetStockPrice")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stockprice/{symbol}")] 
        HttpRequestData req, 
        string symbol, 
        FunctionContext executionContext)
    {
        var log = executionContext.GetLogger("GetStockPrice");
        log.LogInformation("C# HTTP trigger function processed a request.");

        string interval = req.Query["interval"] ?? "1d";
        string range = req.Query["range"] ?? "5d";

        if (string.IsNullOrEmpty(symbol))
        {
            return new BadRequestObjectResult("Please pass a stock symbol on the query string.");
        }

        try
        {
            var chartResult = await chartService.GetChartPriceAsync(symbol, interval, range);

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