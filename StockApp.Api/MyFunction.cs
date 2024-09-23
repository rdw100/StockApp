using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using System.Security.Claims;

namespace StockApp.Api
{
    public class MyFunction
    {
        [Function("MyFunction")]
        public async Task<HttpResponseData> Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
    FunctionContext executionContext)
        {
            HttpResponseData response;
            var principal = executionContext.GetUserPrincipal();

            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                response = req.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
                await response.WriteStringAsync($"Hello, {principal.Identity.Name}!");
            }

            return response;
        }
    }

    public static class FunctionContextExtensions
    {
        public static ClaimsPrincipal GetUserPrincipal(this FunctionContext context)
        {
            if (context.Items.TryGetValue("User", out var user))
            {
                return user as ClaimsPrincipal;
            }

            return null;
        }
    }
}