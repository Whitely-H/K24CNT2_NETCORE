using Microsoft.AspNetCore.Mvc;
using PxcLesson7Models.Models.DataModels;

namespace PxcLesson7Models.Controllers
{
    public class PxcMembersController : Controller
    {
        protected static List<PxcMembers> _members = new List<PxcMembers>
        {
             new PxcMembers
            {
                PxcMembersId = Guid.NewGuid().ToString(),
                PxcUserName = "chungtv",
                PxcPassword = "123456",
                PxcFullName = "Trịnh Văn Chung",
                PxcEmail = "chungtrinhj@example.com"
            },
            new PxcMembers
            {
                PxcMembersId = Guid.NewGuid().ToString(),
                PxcUserName = "tranthibinh",
                PxcPassword = "123456",
                PxcFullName = "Trần Thị Bình",
                PxcEmail = "tranthibinh@example.com"
            },
            new PxcMembers
            {
                PxcMembersId = Guid.NewGuid().ToString(),
                PxcUserName = "levancuong",
                PxcPassword = "123456",
                PxcFullName = "Lê Văn Cường",
                PxcEmail = "levancuong@example.com"
            },
            new PxcMembers
            {
                PxcMembersId = Guid.NewGuid().ToString(),
                PxcUserName = "phamthiduyen",
                PxcPassword = "123456",
                PxcFullName = "Phạm Thị Duyên",
                PxcEmail = "phamthiduyen@example.com"
            },
            new PxcMembers
            {
                PxcMembersId = Guid.NewGuid().ToString(),
                PxcUserName = "hoangminhduc",
                PxcPassword = "123456",
                PxcFullName = "Hoàng Minh Đức",
                PxcEmail = "hoangminhduc@example.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new PxcMembers
            {
                PxcMembersId = Guid.NewGuid().ToString(),
                PxcUserName = "pxcuong",
                PxcPassword = "password1sda",
                PxcFullName = "Phung Xuan Cuong",
                PxcEmail = "12344dfk@gmail.com"
            };
            return View(member);
        }

        public IActionResult GetMembers()
        {
            ViewBag.Members = _members;
            return View();

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PxcMembers member)
        {
            if (ModelState.IsValid)
            {
                member.PxcMembersId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
