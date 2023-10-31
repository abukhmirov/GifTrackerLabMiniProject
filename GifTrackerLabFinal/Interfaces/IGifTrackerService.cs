using GifTrackerLabFinal.Models;

namespace GifTrackerLabFinal.Interfaces
{
    public interface IGifTrackerService
    {
        Task<List<GifTracker>> GetGif(string name, string url, int rating);
    }
}
