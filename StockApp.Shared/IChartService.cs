namespace StockApp.Shared.Interfaces
{
    public interface IChartService
    {
        Task<ChartResult> GetChartPriceAsync(string symbol, string interval, string range);
    }
}
