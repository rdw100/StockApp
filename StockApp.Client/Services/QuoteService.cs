using StockApp.Client.Interfaces;
using StockApp.Client.Models;
using StockApp.Shared.Models;
using System.Net.Http.Json;

namespace StockApp.Client.Services
{
    /// <summary>
    /// Accesses service to retrieve key finance data for specified stock symbol(s).
    /// </summary>
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// List of stock symbols to be used for fetching stock quotes.
        /// </summary>
        /// <remarks>
        /// Each symbol represents a publicly traded company (e.g., "AAPL" for Apple Inc., "MSFT" for Microsoft Corporation).
        /// </remarks>
        List<string> IQuoteService.Symbols => new()
        {
            "AAPL", "AMZN", "CDW", "META", "GOOG", "MSFT", "NFLX", "NVDA", "PAYX", "TSLA",
        };

        /// <summary>
        /// Initializes http to accesses service to retrieve key finance data..
        /// </summary>
        /// <param name="httpClient">An instance of HttpClient used to send HTTP requests and receive HTTP responses.</param>
        public QuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves key finance data for specified stock symbol(s).
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Returns key finance data for specified stock symbol(s)</returns>
        public async Task<ApiResponse<QuoteResult>> GetQuoteData(string symbol)
        {
            try
            {
                var apiUrl = $"api/quote/{symbol}";
                var response = await _httpClient.GetAsync(apiUrl);

                // Return success if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    var stockData = await response.Content.ReadFromJsonAsync<QuoteResult>();
                    return new ApiResponse<QuoteResult>(stockData, (int)response.StatusCode);
                }
                else
                {
                    // Handle non-success status codes by returning an error message and the status code
                    var errorMessage = $"Error fetching stock data: {response.ReasonPhrase}";
                    return new ApiResponse<QuoteResult>(errorMessage, (int)response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                // Handle network-related errors
                return new ApiResponse<QuoteResult>($"Network error occurred while fetching stock data:: {e.Message}", 503);
            }
            catch (Exception ex)
            {
                // Handle other general errors
                return new ApiResponse<QuoteResult>($"An unexpected error occurred: {ex.Message}", 500);
            }
        }

        public async Task<ApiResponse<QuoteResult>> GetQuotesData(string[] symbols)
        {
            try
            {
                string symbolQuery = string.Join(",", symbols);
                var apiUrl = $"api/quote/{symbolQuery}";
                var response = await _httpClient.GetAsync(apiUrl);

                // Return success if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    var stockData = await response.Content.ReadFromJsonAsync<QuoteResult>();
                    return new ApiResponse<QuoteResult>(stockData, (int)response.StatusCode);
                }
                else
                {
                    // Handle non-success status codes by returning an error message and the status code
                    var errorMessage = $"Error fetching stock data: {response.ReasonPhrase}";
                    return new ApiResponse<QuoteResult>(errorMessage, (int)response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                // Handle network-related errors
                return new ApiResponse<QuoteResult>($"Network error occurred while fetching stock data: {e.Message}", 503);
            }
            catch (Exception ex)
            {
                // Handle other general errors
                return new ApiResponse<QuoteResult>($"An unexpected error occurred: {ex.Message}", 500);
            }
        }
    }
}