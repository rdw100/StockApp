using StockApp.Shared;

namespace StockApp.Api.Services.Interfaces
{
    public interface IChartService
    {
        Task<ChartResult> GetChartData(string symbol, string interval, string range);
    }
}
