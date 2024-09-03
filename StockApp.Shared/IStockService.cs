namespace StockApp.Shared
{
    public interface IStockService
    {
        string ServiceName { get; }
        Task<ChartResult> GetStockPriceAsync(string symbol);
    }
}