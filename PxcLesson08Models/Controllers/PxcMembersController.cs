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
        [HttpPost]
        public IActionResult PxcCreate(PxcMembers pxcMembers)
        {
            pxcMembers.PxcMembersId= Guid.NewGuid().ToString();
            _members.Add(pxcMembers);

            return RedirectToAction("Index");
            //return view (pxcmembers)
        }
        [HttpGet]
        public IActionResult PxcEdit(string id)
        {
            var members = _members.Where(x=>x.PxcMembersId.Equals(id)).FirstOrDefault();
            return View(members);
        }
        [HttpPost]
        public IActionResult PxcEdit(string id, PxcMembers pxcMembers)
        {
            //var members = _members.Where(x => x.PxcMembersId.Equals(id)).FirstOrDefault();
            for (int i = 0;i< _members.Count; i++)
            {
                if (_members[i].PxcMembersId == id)
                {
                    _members[i].PxcUserName = pxcMembers.PxcUserName;
                    _members[i].PxcPassword = pxcMembers.PxcPassword;
                    _members[i].PxcFullname = pxcMembers.PxcFullname;
                    _members[i].PxcEmail = pxcMembers.PxcEmail;
                    return RedirectToAction("Index");
                }
            }
            return View();
            
            
        }
        [HttpGet]
        public IActionResult PxcDetails(string id)
        {
            var members = _members.Where(x => x.PxcMembersId.Equals(id)).FirstOrDefault();
            return View(members);
        }
        [HttpGet]
        public IActionResult PxcDelete(string id)
        {
            var members = _members.Where(x => x.PxcMembersId.Equals(id)).FirstOrDefault();
            return View(members);
        }
        [HttpPost]
        public IActionResult PxcDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.PxcMembersId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("PxcDelete");
        }
    }
}
