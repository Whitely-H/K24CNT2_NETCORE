using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhungXuanCuong2410900014_exam.Models;

namespace PhungXuanCuong2410900014_exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult PxcAbout()
        {
            ViewBag.FullName = "Phùng Xuân C??ng";
            ViewBag.StudentId = "2410900014";
            ViewBag.ClassName = "K24CNT2";
            ViewBag.Email = "hutaolmao2@gmail.com";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
