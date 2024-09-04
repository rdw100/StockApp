using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        //services.AddApplicationInsightsTelemetryWorkerService();
        //services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
