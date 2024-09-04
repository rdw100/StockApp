using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StockApp.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["MySettings:API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped<IStockService, MarketStockService>();

await builder.Build().RunAsync();
