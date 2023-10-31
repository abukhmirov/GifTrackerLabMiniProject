using GifTrackerLabFinal.Interfaces;
using GifTrackerLabFinal.Models;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<bool> CreateGif(string URL, string Name, int Rating)
        {
            string apiEndpoint = "/Gifs";
            var gifData = new
            {

                URL = URL,
                Name = Name,
                Rating = Rating
            };

            string jsonGifData = JsonConvert.SerializeObject(gifData);
            HttpContent content = new StringContent(jsonGifData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(apiEndpoint, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<GifTracker>> GetGif()
        {
            string apiEndpoint = "/Gifs";
            var response = await _httpClient.GetAsync(apiEndpoint);
            response.EnsureSuccessStatusCode();
            var gifs = await response.Content.ReadAsStringAsync();
           
            var result = System.Text.Json.JsonSerializer.Deserialize<List<GifTracker>>(gifs,
    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return result;
        }

        
    }
}
