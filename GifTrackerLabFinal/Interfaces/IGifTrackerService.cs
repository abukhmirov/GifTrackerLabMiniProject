using GifTrackerLabFinal.Models;

namespace GifTrackerLabFinal.Interfaces
{
    public interface IGifTrackerService
    {
        Task<List<GifTracker>> GetGif();
        Task<bool> CreateGif( string URL, string Name, int Rating);
    }
}
