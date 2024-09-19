namespace StockApp.Shared.Interfaces
{
    public interface IChartService
    {
        Task<ChartResult> GetChartData(string symbol, string interval, string range);
    }
}
