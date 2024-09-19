using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using StockApp.Api.Services.Interfaces;

namespace StockApp.Api
{
    public class GetQuoteData
    {
        private readonly ILogger<GetQuoteData> _logger;
        private readonly IQuoteService quoteService;

        public GetQuoteData(ILogger<GetQuoteData> logger, IQuoteService iQuoteService)
        {
            _logger = logger;
            quoteService = iQuoteService;
        }

        [Function("GetQuoteData")]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "quote/{symbol}")] 
            HttpRequest req, 
            string symbol,
            FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            if (string.IsNullOrEmpty(symbol))
            {
                return new BadRequestObjectResult("Please pass a stock symbol on the query string.");
            }

            var quote = await quoteService.GetQuote(symbol);
            return new OkObjectResult(quote);
        }
    }
}