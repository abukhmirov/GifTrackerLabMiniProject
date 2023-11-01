using GifTrackerLabFinal.Models;

namespace GifTrackerLabFinal.Interfaces
{
    public interface IGifTrackerService
    {
        Task<List<GifTracker>> GetGif();
        Task<bool> CreateGif( GifTracker gif);
    }
}
