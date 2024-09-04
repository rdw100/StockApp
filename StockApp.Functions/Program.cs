using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Shared;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // Register HttpClient and the service
        services.AddHttpClient<IStockService, MarketStockService>();
    })
    .Build();

host.Run();
