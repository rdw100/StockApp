using StockApp.BlazorPwa.Interfaces;
using StockApp.BlazorPwa.Models;
using StockApp.Shared.Api;
using System.Net.Http.Json;

namespace StockApp.BlazorPwa.Services
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
            "AAPL", "ABNB", "ABMD", "ACGL", "ADBE", "ADI", "ADP", "ADSK", "AEP", "ALGN", "ALXN", "AMAT", "AMGN", "AMZN", "ANSS", "ASML", "ATVI", "AVGO", "BIDU", "BIIB", "BKNG", "BMRN", "CDNS", "CDW", "CERN", "CHKP", "CHTR", "CMCSA", "COST", "CPRT", "CSCO", "CSGP", "CSX", "CTAS", "CTSH", "CTXS", "DOCU", "DXCM", "EA", "EBAY", "EXC", "FAST", "FB", "FISV", "FOX", "FOXA", "GILD", "GOOG", "GOOGL", "IDXX", "ILMN", "INCY", "INTC", "INTU", "ISRG", "JD", "KHC", "KLAC", "LRCX", "LULU", "LUMN", "MAR", "MCHP", "MDLZ", "MELI", "MNST", "MRNA", "MRVL", "MSFT", "MU", "MXIM", "NFLX", "NTES", "NVDA", "NXPI", "OKTA", "ORLY", "PAYX", "PCAR", "PDD", "PEP", "PTON", "PYPL", "QCOM", "REGN", "ROST", "SBUX", "SGEN", "SIRI", "SNPS", "SPLK", "SWKS", "TCOM", "TEAM", "TSLA", "TXN", "VRSK", "VRSN", "VRTX", "WBA", "WDAY", "XEL", "XLNX", "ZM"
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
                return new ApiResponse<QuoteResult>("Network error occurred while fetching stock data.", 503);
            }
            catch (Exception ex)
            {
                // Handle other general errors
                return new ApiResponse<QuoteResult>($"An unexpected error occurred: {ex.Message}", 500);
            }
        }
    }
}