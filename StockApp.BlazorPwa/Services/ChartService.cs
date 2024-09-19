using StockApp.BlazorPwa.Interfaces;
using StockApp.BlazorPwa.Models;
using StockApp.Shared;
using System.Net.Http.Json;

namespace StockApp.BlazorPwa.Services
{
    public class ChartService : IChartService
    {
        private readonly HttpClient _httpClient;

        public ChartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<ChartResult>> GetChartData(string symbol, string interval, string range)
        {
            try
            {
                var apiUrl = $"api/chart/{symbol}?interval={interval}&range={range}";
                var response = await _httpClient.GetAsync(apiUrl);

                // Return success if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    var stockData = await response.Content.ReadFromJsonAsync<ChartResult>();
                    return new ApiResponse<ChartResult>(stockData, (int)response.StatusCode);
                }
                else
                {
                    // Handle non-success status codes by returning an error message and the status code
                    var errorMessage = $"Error fetching stock data: {response.ReasonPhrase}";
                    return new ApiResponse<ChartResult>(errorMessage, (int)response.StatusCode);
                }
            }
            catch (HttpRequestException e)
            {
                // Handle network-related errors
                return new ApiResponse<ChartResult>("Network error occurred while fetching stock data.", 503);
            }
            catch (Exception ex)
            {
                // Handle other general errors
                return new ApiResponse<ChartResult>($"An unexpected error occurred: {ex.Message}", 500);
            }
        }
    }
}