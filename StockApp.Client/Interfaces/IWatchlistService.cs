using StockApp.Shared;

namespace StockApp.Client.Interfaces
{
    public interface IWatchlistService
    {
        IReadOnlyList<WatchStock> Stocks { get; }

        void AddStock(string stock);

        void AddStock(WatchStock stock);

        void RemoveStock(WatchStock stock);

        bool StockExists(string stockSymbol);

        void ClearPortfolio();
    }
}