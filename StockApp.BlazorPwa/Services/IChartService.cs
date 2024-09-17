using StockApp.BlazorPwa.Models;
using StockApp.Shared;

namespace StockApp.BlazorPwa.Interfaces
{
    public interface IChartService
    {
        Task<ApiResponse<ChartResult>> GetChartDataAsync(string symbol, string interval, string range);
    }
}
