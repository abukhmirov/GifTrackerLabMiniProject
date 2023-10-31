using GifTrackerLabFinal.Interfaces;
using GifTrackerLabFinal.Models;


namespace GifTrackerLabFinal.Services
{
    public class GifTrackerService : IGifTrackerService
    {
        public Task<List<GifTracker>> GetGif(string name, string url, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
