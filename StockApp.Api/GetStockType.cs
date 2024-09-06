using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using StockApp.Shared;
using System.Net;
using System.Text.Json;

namespace StockApp.Api
{
    public class GetStockType
    {
        private readonly ILogger _logger;

        public GetStockType(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetStockType>();
        }

        [Function("GetStockType")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stocktype")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            string symbol = req.Query["symbol"];

            var chartResult = new ChartResult
            {
                Symbol = symbol,
                Interval = "1d",
                Range = "1mo",
                Data = new Data
                {
                    Open = new List<long> { 100, 105, 110, 115, 120 },
                    Close = new List<long> { 110, 115, 120, 125, 130 },
                    High = new List<long> { 115, 120, 125, 130, 135 },
                    Low = new List<long> { 95, 100, 105, 110, 115 }
                }
            };

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            response.WriteString(JsonSerializer.Serialize(chartResult));

            return response;
        }
    }

    //public static class GetStockType
    //{
    //    [Function("GetStockType")]
    //    public static async Task<IActionResult> Run(
    //        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "stocktype")] HttpRequest req)//,
    //        //ILogger log)
    //    {
    //        //log.LogInformation("C# HTTP trigger function processed a request.");

    //        var sampleData = new
    //        {
    //            timestamp = new[] { 1633046400, 1633132800, 1633219200, 1633305600, 1633392000 },
    //            close = new[] { 145.09, 144.84, 145.85, 146.92, 147.87 }
    //        };

    //        var chartResult = new ChartResult
    //        {
    //            Symbol = "AAPL",
    //            Interval = "1d",
    //            Range = "5d",
    //            Data = sampleData
    //        };

    //        // Simulate an asynchronous operation
    //        await Task.Delay(10);

    //        return new OkObjectResult(chartResult);
    //    }
    //}
}
