using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Http;
using Swa.Auth.Standard.Models;
using Swa.Auth.Standard.Shared;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Swa.Auth.Standard.Api
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

        public static ClaimsPrincipal Parse(HttpRequest req)
        {
            var clientPrincipal = new ClientPrincipal();

            if (req.Headers.TryGetValue(ClientPrincipalHeader, out var header))
            {
                var decoded = Convert.FromBase64String(header.FirstOrDefault());
                var json = Encoding.UTF8.GetString(decoded);
                clientPrincipal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return AuthenticationHelper.GetClaimsPrincipalFromClientPrincipal(clientPrincipal);
        }
    }
}
