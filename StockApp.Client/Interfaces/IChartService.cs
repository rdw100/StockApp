using StockApp.Client.Models;
using StockApp.Shared.Enums;
using StockApp.Shared.Models;

namespace StockApp.Client.Interfaces
{
    public interface IChartService
    {
        Task<ApiResponse<ChartResult>> GetChartData(
            string symbol,
            StockInterval interval = StockInterval.OneDay,
            StockRange range = StockRange.FiveDays
        );

    }
}
