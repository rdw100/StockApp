using StockApp.Api.Services.Interfaces;
using System.Net.Http.Json;

namespace StockApp.Api.Services.Http
{
    public class FreeHttpService : IFreeHttpService
    {

        private readonly HttpClient HttpClient;

        public FreeHttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
        }

        public async Task<HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            HttpResponseMessage response = await HttpClient.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<T> SendAsync<T>(HttpRequestMessage request) where T : new()
        {
            var response = await HttpClient.SendAsync(request);

            var result = new T();
            var statusCodeProperty = typeof(T).GetProperty("StatusCode");
            var statusMessageProperty = typeof(T).GetProperty("StatusMessage");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<T>();
                if (statusCodeProperty != null)
                {
                    statusCodeProperty.SetValue(content, 200);
                }

                if (statusMessageProperty != null)
                {
                    statusMessageProperty.SetValue(content, "OK");
                }

                return content;
            }
            else
            {
                if (statusCodeProperty != null)
                {
                    statusCodeProperty.SetValue(result, (int)response.StatusCode);
                }

                if (statusMessageProperty != null)
                {
                    statusMessageProperty.SetValue(result, response.ReasonPhrase);
                }

                return result;
            }
        }
    }
}