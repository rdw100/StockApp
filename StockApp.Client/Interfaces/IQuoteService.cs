using StockApp.Client.Models;
using StockApp.Shared.Api;

namespace StockApp.Client.Interfaces
{
    /// <summary>
    /// Defines stock quote front-end data & services access
    /// </summary>
    public interface IQuoteService
    {
        public List<string> Symbols { get; }
        Task<ApiResponse<QuoteResult>> GetQuoteData(string symbol);
    }
}
