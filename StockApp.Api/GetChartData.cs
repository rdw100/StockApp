using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockApp.Api.Services.Interfaces;

namespace StockApp.Api;

public class GetChartData
{

    private readonly IChartService chartService;

    public GetChartData(IChartService iChartService)
    {
        chartService = iChartService;
    }

    [Function("GetChartData")]
    public async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "chart/{symbol}")] 
        HttpRequest req, 
        string symbol, 
        FunctionContext executionContext)
    {
        var log = executionContext.GetLogger("GetChartData");
        log.LogInformation("C# HTTP trigger function processed a request.");

        string interval = req.Query["interval"].ToString() ?? "1d";
        string range = req.Query["range"].ToString() ?? "5d";

        if (string.IsNullOrEmpty(symbol))
        {
            return new BadRequestObjectResult("Please pass a stock symbol on the query string.");
        }

        try
        {
            var chartResult = await chartService.GetChartData(symbol, interval, range);

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