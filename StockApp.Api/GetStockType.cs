using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using StockApp.Shared;

namespace StockApp.Api
{
    public static class GetStockType
    {
        [FunctionName("GetStockType")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stocktype")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var sampleData = new
            {
                timestamp = new[] { 1633046400, 1633132800, 1633219200, 1633305600, 1633392000 },
                close = new[] { 145.09, 144.84, 145.85, 146.92, 147.87 }
            };

            var chartResult = new ChartResult
            {
                Symbol = "AAPL",
                Interval = "1d",
                Range = "5d",
                Data = sampleData
            };

            return new OkObjectResult(chartResult);
        }
    }
}
