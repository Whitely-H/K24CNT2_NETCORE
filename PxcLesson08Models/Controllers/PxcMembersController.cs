using Microsoft.AspNetCore.Mvc;
using PxcLesson08Models.Models;

namespace PxcLesson08Models.Controllers
{
    public class PxcMembersController : Controller
    {
       
        private static List<PxcMembers> _members = new List<PxcMembers>()
        {
            new PxcMembers
                {
                    PxcMembersId = Guid.NewGuid().ToString(),
                    PxcUserName = "user01",
                    PxcPassword = "Password123!",
                    PxcFullname = "Phung xxuna cuong",
                    PxcEmail = "nguyenvana@gmail.com"
                },
                new PxcMembers
                {
                    PxcMembersId = Guid.NewGuid().ToString(),
                    PxcUserName = "user02",
                    PxcPassword = "Password123!",
                    PxcFullname = "Trần Thị B",
                    PxcEmail = "tranthib@gmail.com"
                },
                new PxcMembers
                {
                    PxcMembersId = Guid.NewGuid().ToString(),
                    PxcUserName = "user03",
                    PxcPassword = "Password123!",
                    PxcFullname = "Lê Hoàng C",
                    PxcEmail = "lehoangc@gmail.com"
                },
                new PxcMembers
                {
                    PxcMembersId = Guid.NewGuid().ToString(),
                    PxcUserName = "user04",
                    PxcPassword = "Password123!",
                    PxcFullname = "Phạm Minh D",
                    PxcEmail = "phamminhd@gmail.com"
                },
                new PxcMembers
                {
                    PxcMembersId = Guid.NewGuid().ToString(),
                    PxcUserName = "user05",
                    PxcPassword = "Password123!",
                    PxcFullname = "Hoàng Anh E",
                    PxcEmail = "hoanganhe@gmail.com"
                }
        };
        //Get danh sach thanh vien

        public IActionResult Index()
        {
            return View(_members);
        }
        [HttpGet]
        public IActionResult PxcCreate()
        {
            var members = new PxcMembers();
               return View();
        }
    }
}
