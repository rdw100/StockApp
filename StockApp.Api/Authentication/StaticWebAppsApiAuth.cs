using Microsoft.Azure.Functions.Worker.Http;
using StockApp.Shared.Authentication.Models;
using StockApp.Shared.Authentication.Services;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace StockApp.Api.Authentication
{
    public static class StaticWebAppsApiAuth
    {
        private const string ClientPrincipalHeader = "x-ms-client-principal";

        public static ClaimsPrincipal Parse(HttpRequestData req)
        {
            var clientPrincipal = new ClientPrincipal();

            if (req.Headers.TryGetValues(ClientPrincipalHeader, out IEnumerable<string> headers))
            {
                var header = headers?.FirstOrDefault();
                var decoded = Convert.FromBase64String(header);
                var json = Encoding.UTF8.GetString(decoded);
                clientPrincipal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return AuthenticationHelper.GetClaimsPrincipalFromClientPrincipal(clientPrincipal);
        }
    }
}
