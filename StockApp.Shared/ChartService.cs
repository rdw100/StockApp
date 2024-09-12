namespace StockApp.Shared
{
    public class ChartService : IChartService
    {
        public ChartService() { }

        private static readonly HttpClient httpClient = new HttpClient();

        public Task<ChartResult> GetStockPriceAsync(string symbol, string interval, string range)
        {
            throw new NotImplementedException();
        }
    }
}