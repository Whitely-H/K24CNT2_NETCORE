using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PxcLesson08Models.Models;

namespace PxcLesson08Models.Controllers
{
    public class PxcHomeController : Controller
    {
        private readonly ILogger<PxcHomeController> _logger;

        public PxcHomeController(ILogger<PxcHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PxcIndex()
        {
            return View();
        }

        public IActionResult PxcPrivacy()
        {
            return View();
        }
        public IActionResult PxcAbout()
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
