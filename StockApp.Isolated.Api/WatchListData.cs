using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockApp.Shared.Models;
using Swa.Auth.Standard.Api;

namespace StockApp.Isolated.Api
{
    public class WatchListData
    {
        private readonly ILogger<Watch> _logger;

        public WatchListData(ILogger<Watch> logger)
        {
            _logger = logger;
        }

        private static readonly string EndpointUri = Environment.GetEnvironmentVariable("CosmosDbEndpointUri");
        private static readonly string PrimaryKey = Environment.GetEnvironmentVariable("CosmosDbPrimaryKey");
        private static CosmosClient cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);
        private static Database database = cosmosClient.GetDatabase("WatchlistsDb");
        private static Container container = database.GetContainer("Watchlists");

        [Function("SaveWatchlist")]
        public async Task<IActionResult> SaveWatchlist(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var user = StaticWebAppsApiAuth.Parse(req);

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                var customResponse = new ObjectResult(new { message = "Unauthorized access. Please check your credentials." })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return customResponse;
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            Watch watch = JsonConvert.DeserializeObject<Watch>(requestBody);

            // Ensure the Id is set
            watch.Id = watch?.UserId;

            try
            {
                await container.CreateItemAsync(watch, new PartitionKey(watch.UserId));
                return new OkObjectResult("Watchlist saved successfully.");
            }
            catch (CosmosException ex)
            {
                _logger.LogError($"Cosmos DB error: {ex.Message}");
                return new StatusCodeResult((int)ex.StatusCode);
            }

        }

        [Function("GetWatchlist")]
        public async Task<IActionResult> GetWatchlist(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetWatchlist/{userId}")] HttpRequest req,
        string userId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            
            var user = StaticWebAppsApiAuth.Parse(req);

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                var customResponse = new ObjectResult(new { message = "Unauthorized access. Please check your credentials." })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return customResponse;
            }

            try
            {
                ItemResponse<Watch> response = await container.ReadItemAsync<Watch>(userId, new PartitionKey(userId));
                var watchlist = response.Resource;

                return new OkObjectResult(watchlist);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new NotFoundObjectResult("Watchlist not found.");
            }
        }

        [Function("UpdateWatchlist")]
        public async Task<IActionResult> UpdateWatchlist(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "UpdateWatchlist/{userId}")] HttpRequest req,
        string userId)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var user = StaticWebAppsApiAuth.Parse(req);

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                var customResponse = new ObjectResult(new { message = "Unauthorized access. Please check your credentials." })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
                return customResponse;
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var updatedWatchlist = JsonConvert.DeserializeObject<Watch>(requestBody);
            updatedWatchlist.Id = userId;

            if (updatedWatchlist.WatchList.Count > 5)
            {
                return new BadRequestObjectResult("Watchlist can only contain a maximum of 5 stock symbols.");
            }

            try
            {
                await container.UpsertItemAsync(updatedWatchlist, new PartitionKey(userId));
                return new OkObjectResult("Watchlist updated successfully.");
            }
            catch (CosmosException ex)
            {
                _logger.LogError($"Error updating watchlist for user {userId}: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}