using GifTrackerLabFinal.Interfaces;
using GifTrackerLabFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GifTrackerLabFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGifTrackerService _gifTrackerService;

        public HomeController(ILogger<HomeController> logger, IGifTrackerService gifTrackerService)
        {
            _logger = logger;
            _gifTrackerService = gifTrackerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GifIndex()
        {
            List<GifTracker> gifTrackerList = await _gifTrackerService.GetGif();
            return View(gifTrackerList);
            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}