using StockApp.Client.Interfaces;
using StockApp.Shared;

namespace StockApp.Client.Services
{
    /// <summary>
    /// Represents a dynamic list of stocks that you’re monitoring.
    /// </summary>
    public class WatchlistService : IWatchlistService
    {
        private List<WatchStock> _stocks = new List<WatchStock>();

        public IReadOnlyList<WatchStock> Stocks => _stocks;

        public void AddStock(string stock)
        {
            if (!string.IsNullOrWhiteSpace(stock) && !StockExists(stock))
            {
                // Create a new stock with the entered symbol
                var newStock = new WatchStock
                {
                    Symbol = stock
                };

                // Add the stock to the portfolio
                _stocks.Add(newStock);
            }
        }

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