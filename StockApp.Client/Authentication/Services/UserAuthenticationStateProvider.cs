﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StockApp.Client.Authentication.Models;
using StockApp.Shared.Authentication.Services;
using System.Net.Http.Json;
using System.Security.Claims;

namespace StockApp.Client.Authentication.Services
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
