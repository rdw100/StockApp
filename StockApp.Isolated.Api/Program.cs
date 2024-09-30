using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockApp.Api.Services;
using StockApp.Api.Services.Http;
using StockApp.Api.Services.Interfaces;
using StockApp.Shared;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, config) =>
    {
        // Add configuration sources (environment variables, local.settings.json, etc.)
        config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) => 
    {
        services.AddHttpClient();
        services.AddMemoryCache();
        services.Configure<ServiceOptions>(context.Configuration.GetSection("ThirdPartyApi"));
        services.AddSingleton<IFreeHttpService, FreeHttpService>();
        services.AddSingleton<IChartService, ChartService>();
        services.AddSingleton<IQuoteService, QuoteService>();
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

await host.RunAsync();