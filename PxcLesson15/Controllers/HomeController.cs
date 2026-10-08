using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PxcLesson15.Models;

namespace PxcLesson15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            // Nếu tồn tại cookie thì đọc ra biến ViewBag.userName
            if (Request.Cookies["userName"] != null)
            {
                ViewBag.userName = Request.Cookies["userName"];
            }
            else
            {
                // Nếu chưa tồn tại cookie "userName" thì lưu trữ
                // xuống client trong 1 giờ
                CookieOptions options = new CookieOptions();
                options.Secure = true;
                options.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Append("userName", "Chung Trinh", options);
            }
            return View();
        }
        public IActionResult Login()[cite: 1]
        {
            return View(); [cite: 1]
        }

        // POST: Login[cite: 1]
        [HttpPost]
        [cite: 1]
        public IActionResult Login(string userName, string password)[cite: 1]
        {
            if (userName == "ChungTrinh" && password == "123456a@")[cite: 1]
            {
                // gán dữ liệu cho session có key là userName[cite: 1]
                HttpContext.Session.SetString("userName", userName);[cite: 1]
                return RedirectToAction("Index"); [cite: 1]
}
return View(); [cite: 1]
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
