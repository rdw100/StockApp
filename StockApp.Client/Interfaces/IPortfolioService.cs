using StockApp.Shared;

namespace StockApp.Client.Interfaces
{
    public interface IPortfolioService
    {
        IReadOnlyList<WatchStock> Stocks { get; }

        void AddStock(WatchStock stock);

        void RemoveStock(WatchStock stock);

        bool StockExists(string stockSymbol);

        void ClearPortfolio();
    }
}
