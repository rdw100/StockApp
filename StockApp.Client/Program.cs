using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Components.Tooltip;
using StockApp.Client;
using StockApp.Client.Interfaces;
using StockApp.Client.Services;
using Swa.Auth.Standard.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMediaQueryService();
builder.Services.AddScoped<IResizeListener, ResizeListener>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["MySettings:API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddStaticWebAppsAuthentication();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddScoped<IChartService, ChartService>();
builder.Services.AddScoped<IWatchlistService, WatchlistService>();
builder.Services.AddSingleton<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<ITooltipService, TooltipService>();
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
