using StockApp.Client.Interfaces;
using StockApp.Shared.Models;
using System.Net.Http.Json;

namespace StockApp.Client.Services
{
    /// <summary>
    /// Represents a dynamic list of stocks that you’re monitoring.
    /// </summary>
    public class WatchlistService : IWatchlistService
    {
        private readonly HttpClient _httpClient;
        //private Watch? _watchList;
        //public IReadOnlyList<WatchList> _watchList;
        //public IReadOnlyList<WatchList> Stocks => _stocks;

        //public WatchlistService(HttpClient httpClient)//, Watch watchlist)
        //{
        //    _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        //    //_watchList = watchlist ?? throw new ArgumentNullException(nameof(watchlist));
        //}

        //public WatchlistService(Watch watchlist)
        //{
        //    _watchList = watchlist ?? throw new ArgumentNullException(nameof(watchlist));
        //}

        public WatchlistService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //public Watch? WatchList => _watchList;

        public async Task<Watch> GetWatchlist(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("User ID cannot be null or empty", nameof(userId));
            }

            var response = await _httpClient.GetFromJsonAsync<Watch>($"api/GetWatchlist/{userId}");
            return response;
        }

        public async Task<bool> UpdateWatchlist(Watch watch)
        {
            //if (string.IsNullOrEmpty(_watchList.UserId))
            //{
            //    throw new ArgumentException("User ID cannot be null or empty", nameof(_watchList.UserId));
            //}

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/UpdateWatchlist/{watch.UserId}", watch);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false; // Handle any errors that occur during the HTTP request
            }
        }

        public async Task<bool> SaveWatchlist(Watch watch)
        {
            //if (string.IsNullOrEmpty(_watchList.UserId))
            //{
            //    throw new ArgumentException("User ID cannot be null or empty", nameof(_watchList.UserId));
            //}

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/SaveWatchlist/", watch);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false; // Handle any errors that occur during the HTTP request
            }
        }

        //public bool AddStock(string stockSymbol)
        //{
        //    if (string.IsNullOrEmpty(stockSymbol))
        //    {
        //        throw new ArgumentException("Stock symbol cannot be null or empty", nameof(stockSymbol));
        //    }

        //    //if (_watchList.WatchList?.Count >= 5)
        //    //{
        //    //    return false; // Watchlist can only contain up to 5 stock symbols.
        //    //}

        //    //if (StockExists(stockSymbol))
        //    //{
        //    //    return false; // Stock already exists in the watchlist.
        //    //}

        //    _watchList.WatchList.Add(stockSymbol);
        //    return true;
        //}

        //public bool RemoveStock(string stockSymbol)
        //{
        //    if (string.IsNullOrEmpty(stockSymbol))
        //    {
        //        throw new ArgumentException("Stock symbol cannot be null or empty", nameof(stockSymbol));
        //    }

        //    return _watchList.WatchList.Remove(stockSymbol);
        //}

        //public bool StockExists(string stockSymbol)
        //{
        //    if (string.IsNullOrEmpty(stockSymbol))
        //    {
        //        throw new ArgumentException("Stock symbol cannot be null or empty", nameof(stockSymbol));
        //    }

        //    return _watchList.WatchList.Contains(stockSymbol);
        //}

        //private List<WatchList> _stocks = new List<WatchList>();

        //public IReadOnlyList<WatchList> Stocks => _stocks;

        ////public void GetStocks(string userId)
        ////{
        ////    _stocks = await Http.GetFromJsonAsync<WatchList>($"api/GetWatchlist/{userId}");

        ////}

        //public void AddStock(string stock)
        //{
        //    if (!string.IsNullOrWhiteSpace(stock) && !StockExists(stock))
        //    {
        //        // Create a new stock with the entered symbol
        //        var newStock = new WatchList
        //        {
        //            Symbols = stock
        //        };

        //        // Add the stock to the portfolio
        //        _stocks.Add(newStock);
        //    }
        //}

        //public void AddStock(WatchList stock)
        //{
        //    _stocks.Add(stock);
        //}

        //public void RemoveStock(WatchStock stock)
        //{
        //    var stockToRemove = _stocks.FirstOrDefault(s => s.Symbol == stock.Symbol);
        //    if (stockToRemove != null)
        //    {
        //        _stocks.Remove(stockToRemove);
        //    }
        //}

        //public bool StockExists(string symbol)
        //{
        //    return _stocks.Exists(s => s.Symbol.Equals(symbol, StringComparison.OrdinalIgnoreCase));
        //}

        //public void ClearPortfolio()
        //{
        //    _stocks.Clear();
        //}
    }
}