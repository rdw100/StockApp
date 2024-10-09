using StockApp.Client.Interfaces;
using StockApp.Shared.Models;

namespace StockApp.Client.Services
{
    /// <summary>
    /// Represents a service for a collection of stocks that an investor holds.
    /// </summary>
    public class PortfolioService : IPortfolioService
    {
        private List<WatchStock> _stocks = new List<WatchStock>();

        public IReadOnlyList<WatchStock> Stocks => _stocks;

        public void AddStock(WatchStock stock)
        {
            _stocks.Add(stock);
        }

        public void RemoveStock(WatchStock stock)
        {
            var stockToRemove = _stocks.FirstOrDefault(s => s.Symbol == stock.Symbol);
            if (stockToRemove != null)
            {
                _stocks.Remove(stockToRemove);
            }
        }

        public bool StockExists(string symbol)
        {
            return _stocks.Exists(s => s.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
        }

        public void ClearPortfolio()
        {
            _stocks.Clear();
        }
    } 
}