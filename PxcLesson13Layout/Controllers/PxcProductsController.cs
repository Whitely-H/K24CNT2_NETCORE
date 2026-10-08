using Microsoft.AspNetCore.Mvc;

namespace PxcLesson13.Controllers
{
    public class PxcProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string keyword)
        {
            ViewData["keyword"] = keyword;
            return View();
        }

        public IActionResult Hots()
        {

            return View();
        }
        public IActionResult about()
        {
            return View();
        }
    }
}
