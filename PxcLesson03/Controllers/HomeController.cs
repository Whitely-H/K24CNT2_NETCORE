using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PxcLesson03.Models;

namespace PxcLesson03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //public IActionResult GetProducts()
        //{
        //    pxcproduct p = new pxcproduct
        //    {
        //        pxcproductId = 1,
        //        pxcproductName = "Áo Ch?ng Nóng",
        //        YearRelease = 2022,
        //        Price = 2999
        //    };
        //    ViewBag.product = p;
        //    ViewData["productVD"] = p;
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
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
