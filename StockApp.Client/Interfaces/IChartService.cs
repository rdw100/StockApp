﻿using StockApp.Client.Models;
using StockApp.Shared;

namespace StockApp.Client.Interfaces
{
    public interface IChartService
    {
        Task<ApiResponse<ChartResult>> GetChartData(string symbol, string interval, string range);
    }
}