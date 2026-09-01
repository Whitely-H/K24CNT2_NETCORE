using Microsoft.AspNetCore.Mvc;
using PxcLesson04Lab.Models;

namespace PxcLesson04Lab.Controllers
{
    public class PxcAccountController : Controller
    {
        private readonly List<PxcAccount> pxcAccounts = new()
        {
            new PxcAccount
            {
                Id = 1,
                Name = "Nguyễn Văn An",
                Email = "an.nguyen@example.com",
                Phone = "0901234567",
                Avatar = "/lib/1.png",
                Address = "123 Lê Lợi, Quận 1, TP. Hồ Chí Minh",
                Bio = "Lập trình viên C# yêu thích công nghệ.",
                Gender = 1, // 1: Nam
                Birtday = new DateTime(1995, 5, 15)
            },
            new PxcAccount
            {
                Id = 2,
                Name = "Trần Thị Bích",
                Email = "bich.tran@example.com",
                Phone = "0912345678",
                Avatar = "/lib/2.png",
                Address = "456 Hoàn Kiếm, Hà Nội",
                Bio = "Chuyên viên thiết kế UI/UX.",
                Gender = 0, // 0: Nữ
                Birtday = new DateTime(1998, 8, 22)
            },
            new PxcAccount
            {
                Id = 3,
                Name = "Lê Hoàng Minh",
                Email = "minh.le@example.com",
                Phone = "0923456789",
                Avatar = "/lib/3.png",
                Address = "789 Nguyễn Văn Linh, Q. Hải Châu, Đà Nẵng",
                Bio = "Quản lý dự án phần mềm.",
                Gender = 1,
                Birtday = new DateTime(1990, 12, 5)
            },
            new PxcAccount
            {
                Id = 4,
                Name = "Phạm Thu Hương",
                Email = "huong.pham@example.com",
                Phone = "0934567890",
                Avatar = "/lib/4.png",
                Address = "101 Thùy Vân, TP. Vũng Tàu",
                Bio = "Đam mê du lịch và nhiếp ảnh.",
                Gender = 0,
                Birtday = new DateTime(2001, 3, 30)
            },
            new PxcAccount
            {
                Id = 5,
                Name = "Vũ Đức Anh",
                Email = "anh.vu@example.com",
                Phone = "0945678901",
                Avatar = "/lib/5.png",
                Address = "202 Trần Hưng Đạo, TP. Cần Thơ",
                Bio = "Kỹ sư dữ liệu và AI.",
                Gender = 1,
                Birtday = new DateTime(1997, 10, 10)
            }
        };

        public IActionResult PxcIndex()
        {
            ViewBag.PxcAccounts = pxcAccounts;
            return View();
        }

     
        [Route("ho-so-cua-toi", Name = "PxcProfile")]
        public IActionResult PxcProfile(int id = 1)
        {
            
            PxcAccount? pxcAccount = pxcAccounts.FirstOrDefault(x => x.Id == id) ?? pxcAccounts.FirstOrDefault();
            ViewBag.PxcAccount = pxcAccount;
            
            return View(pxcAccount);
        }
    }
}