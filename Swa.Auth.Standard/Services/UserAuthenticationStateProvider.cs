using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Swa.Auth.Standard.Models;
using Swa.Auth.Standard.Shared;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Swa.Auth.Standard.Services
{
    public class UserAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _client;

        public UserAuthenticationStateProvider(IWebAssemblyHostEnvironment environment)
        {
            _client = new HttpClient { BaseAddress = new Uri(environment.BaseAddress) };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = await _client.GetFromJsonAsync<UserAuthenticationState>("/.auth/me");
            var clientPrincipal = state?.ClientPrincipal;

            var claimsPrincipal = AuthenticationHelper.GetClaimsPrincipalFromClientPrincipal(clientPrincipal);

            return new AuthenticationState(new ClaimsPrincipal(claimsPrincipal));
        }
    }
}
