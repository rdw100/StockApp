using Microsoft.Extensions.Options;
using StockApp.Api.Services.Interfaces;
using StockApp.Shared;
using StockApp.Shared.Api;

namespace StockApp.Api.Services
{
    /// <summary>
    /// Retrieves key finance data for specified stock symbol(s) with one call.
    /// </summary>
    public class QuoteService : IQuoteService
    {
        private readonly IFreeHttpService freeHttpService;
        private string Cookie;
        private string Crumb;
        private string Quote;

        /// <summary>
        /// Retrieves and caches key finance data for specified stock symbol(s) with a valid cookie and crumb.
        /// </summary>
        /// <param name="options">API configuration with application settings</param>
        /// <param name="iFreeHttpService">A http service service</param>
        public QuoteService(IOptions<ServiceOptions> options, IFreeHttpService iFreeHttpService)
        {
            freeHttpService = iFreeHttpService;
            Cookie = options.Value.CookieUrl;
            Crumb = options.Value.CrumbUrl;
            Quote = options.Value.QuoteUrl;
        }

        /// <summary>
        /// Retrieves key finance data for specified stock symbol(s).
        /// </summary>
        /// <param name="symbol">A comma-separated stock symbols</param>
        /// <returns>Returns key finance data for specified stock symbol(s)</returns>
        /// <remarks>Requests without headers receive 429 (Too Many Requests).</remarks>
        public async Task<QuoteResult> GetQuote(string symbol)
        {
            Cookie = await GetFreeApiCookieAsync();
            Crumb = await GetFreeApiCrumbAsync(Cookie);

            return await GetFreeApiQuoteAsync(symbol, Cookie, Crumb);
        }

        /// <summary>
        /// Obtains a valid cookie. Call requires valid cookie and crumb.
        /// </summary>
        /// <returns>A valid cookie</returns>
        /// <exception cref="HttpRequestException">Cannot get or set cookie</exception>
        private async Task<string> GetFreeApiCookieAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Cookie);
            var response = await freeHttpService.GetAsync(request);

            // Check if the status code is 404 matches
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound
                || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var setCookieHeader = response.Headers.GetValues("Set-Cookie").FirstOrDefault();
                return setCookieHeader?.Split(';').FirstOrDefault();
            }

            throw new HttpRequestException("Unexpected response status code retrieving valid cookie.");
        }

        /// <summary>
        /// Obtains a valid crumb. Call requires valid cookie and crumb.
        /// </summary>
        /// <param name="cookie">A valid cookie</param>
        /// <returns>Returns Crumb used to fetch data.</returns>
        /// <remarks>Crumb is used to diminish CSRF attacks using a random unique token that is validated on the server side. Crumb may be used whenever you want to prevent malicious code to execute system commands, that are performed by HTTP requests.</remarks>
        private async Task<string> GetFreeApiCrumbAsync(string cookie)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Crumb);
            request.Headers.Add("Cookie", cookie);
            var response = await freeHttpService.GetAsync(request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Retrieves key finance data for specified stock symbol(s) using valid crumb and cookie. 
        /// </summary>
        /// <param name="symbol">A comma-separated stock symbols</param>
        /// <param name="cookie">A valid cookie</param>
        /// <param name="crumb">A valid crumb</param>
        /// <returns>Returns key finance data for specified stock symbol(s).</returns>
        private async Task<QuoteResult> GetFreeApiQuoteAsync(string symbol, string cookie, string crumb)
        {
            var url = $"{Quote}?symbols={symbol}&crumb={crumb}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Cookie", cookie);

            var response = await freeHttpService.SendAsync<QuoteResult>(request);
            return response;
        }
    }
}