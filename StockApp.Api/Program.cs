using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockApp.Api.Services.Interfaces;
using StockApp.Api.Services;
using StockApp.Shared;
using StockApp.Shared.Interfaces;
using StockApp.Api.Services.Http;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHttpClient();
        services.Configure<ServiceOptions>(context.Configuration.GetSection("ThirdPartyApi"));
        services.AddSingleton<IFreeHttpService, FreeHttpService>();
        services.AddSingleton<IChartService, ChartService>();
        services.AddSingleton<IQuoteService, QuoteService>();
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

//await host.RunAsync();
host.Run();