using StockApp.Shared.Api;

namespace StockApp.Api.Services.Interfaces
{
    /// <summary>
    /// Defines stock quote data service access
    /// </summary>
    public interface IQuoteService
    {
        Task<QuoteResult> GetQuote(string symbol);
    }
}
