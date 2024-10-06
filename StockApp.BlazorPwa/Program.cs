using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using StockApp.BlazorPwa;
using StockApp.BlazorPwa.Interfaces;
using StockApp.BlazorPwa.Services;
using Swa.Auth.Standard.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["MySettings:API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
builder.Services.AddStaticWebAppsAuthentication();
builder.Services.AddScoped<IChartService, ChartService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
