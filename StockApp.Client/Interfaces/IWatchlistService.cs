using StockApp.Shared.Models;

namespace StockApp.Client.Interfaces
{
    public interface IWatchlistService
    {
        Task<Watch> GetWatchlist(string userId);
        Task<bool> UpdateWatchlist(Watch watch);
        Task<bool> SaveWatchlist(Watch watch);
    }
}