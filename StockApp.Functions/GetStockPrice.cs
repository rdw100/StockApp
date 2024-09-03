using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using StockApp.Shared;
using System.Threading.Tasks;

namespace StockApp.Functions
{
    public class GetStockPrice
    {
        private readonly IStockService _stockService;

        public GetStockPrice(IStockService stockService)
        {
            _stockService = stockService;
        }

        [FunctionName("GetStockPrice")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string symbol = req.Query["symbol"];
            var result = await _stockService.GetStockPriceAsync(symbol);

            return new OkObjectResult(result);
        }
    }
}