using StockApp.BlazorPwa.Models;
using StockApp.Shared.Api;

namespace StockApp.BlazorPwa.Interfaces
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
