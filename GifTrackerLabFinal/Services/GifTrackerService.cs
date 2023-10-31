using GifTrackerLabFinal.Interfaces;
using GifTrackerLabFinal.Models;

using System.Net.Http;
using System.Text.Json;


namespace GifTrackerLabFinal.Services
{
    public class GifTrackerService : IGifTrackerService
    {

        private static readonly HttpClient _httpClient;

        static GifTrackerService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7094")
            };
        }
        public async Task<List<GifTracker>> GetGif()
        {
            string apiEndpoint = "/Gifs";
            var response = await _httpClient.GetAsync(apiEndpoint);
            response.EnsureSuccessStatusCode();
            var gifs = await response.Content.ReadAsStringAsync();
           
            var result = JsonSerializer.Deserialize<List<GifTracker>>(gifs,
    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return result;

        }
    }
}
