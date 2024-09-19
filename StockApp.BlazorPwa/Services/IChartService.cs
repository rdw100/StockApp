using StockApp.BlazorPwa.Models;
using StockApp.Shared;

namespace StockApp.BlazorPwa.Interfaces
{
    public interface IChartService
    {
        Task<ApiResponse<ChartResult>> GetChartData(string symbol, string interval, string range);
    }
}
