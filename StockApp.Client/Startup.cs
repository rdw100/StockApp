//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using StockApp.Shared;

//[assembly: FunctionsStartup(typeof(StockApp.Functions.Startup))]

//namespace StockApp.Functions
//{
//    public class Startup : FunctionsStartup
//    {
//        public override void Configure(IFunctionsHostBuilder builder)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Environment.CurrentDirectory)
//                .AddJsonFile("local.settings.json" ?? "host.json", optional: false, reloadOnChange: true)
//                .AddEnvironmentVariables()
//                .Build();

//            builder.Services.AddSingleton<IConfiguration>(configuration);
//            builder.Services.AddHttpClient();
//            builder.Services.AddSingleton<IStockService, MarketStockService>(sp =>
//            {
//                var config = sp.GetRequiredService<IConfiguration>();
//                var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
//                return new MarketStockService(httpClient, config);
//            });
//        }
//    }
//}
