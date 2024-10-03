using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using StockApp.Client.Authentication.Services;
using StockApp.Client;
using StockApp.Client.Interfaces;
using StockApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["MySettings:API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, UserAuthenticationStateProvider>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IChartService, ChartService>();
builder.Services.AddSingleton<IWatchlistService, WatchlistService>();
builder.Services.AddSingleton<IPortfolioService, PortfolioService>();
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
