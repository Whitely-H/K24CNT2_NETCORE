using Microsoft.AspNetCore.Mvc;
using PxcLesson03.Models;

namespace PxcLesson03.Controllers
{
    [Route("/danh-sach-san-pham")]
    public class PxcProductController : Controller
    {
        private readonly List<pxcproduct> _products = new()
        {
            new pxcproduct { pxcproductId = "P001", pxcproductName = "Laptop Dell XPS 13", YearRelease = 2023, Price = 1299.99 },
            new pxcproduct { pxcproductId = "P002", pxcproductName = "iPhone 15 Pro", YearRelease = 2023, Price = 999.00 },
            new pxcproduct { pxcproductId = "P003", pxcproductName = "Samsung Galaxy S24", YearRelease = 2024, Price = 899.50 },
            new pxcproduct { pxcproductId = "P004", pxcproductName = "Sony WH-1000XM5", YearRelease = 2022, Price = 398.00 },
            new pxcproduct { pxcproductId = "P005", pxcproductName = "iPad Air M1", YearRelease = 2022, Price = 599.00 },
            new pxcproduct { pxcproductId = "P006", pxcproductName = "MacBook Air M2", YearRelease = 2023, Price = 1099.00 },
            new pxcproduct { pxcproductId = "P007", pxcproductName = "Apple Watch Series 9", YearRelease = 2023, Price = 399.00 },
            new pxcproduct { pxcproductId = "P008", pxcproductName = "Logitech MX Master 3S", YearRelease = 2022, Price = 99.99 },
            new pxcproduct { pxcproductId = "P009", pxcproductName = "LG UltraGear OLED Monitor", YearRelease = 2024, Price = 1199.00 },
            new pxcproduct { pxcproductId = "P010", pxcproductName = "Asus ROG Phone 8", YearRelease = 2024, Price = 1099.90 }
        };
        public IActionResult Index()
        {
            return Json(_products);
        }
        //colllection sang view
        [Route("all")]
        public IActionResult PxcGetAllProduct()
        {
            ViewData["products"] = _products;
            return View();
        }
    }
}
