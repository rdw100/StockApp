namespace StockApp.Shared
{
    public interface IChartService
    {
        Task<ChartResult> GetStockPriceAsync(string symbol, string interval, string range);
    }
}
