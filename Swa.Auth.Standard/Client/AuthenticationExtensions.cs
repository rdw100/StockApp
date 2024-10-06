using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Swa.Auth.Standard.Services;

namespace Swa.Auth.Standard.Client
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddStaticWebAppsAuthentication(this IServiceCollection services)
        {
            return services
                .AddAuthorizationCore()
                .AddScoped<AuthenticationStateProvider, UserAuthenticationStateProvider>();
        }
    }
}
