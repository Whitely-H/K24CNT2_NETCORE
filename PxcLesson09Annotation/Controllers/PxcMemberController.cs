using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PxcLesson09Annotation.Models.DataModel;
using PxcLesson09Annotation.Models.DataViewModel;

namespace PxcLesson09Annotation.Controllers
{
    public class PxcMemberController : Controller
    {
        private static List<PxcMember> _pxcMember=new List<PxcMember>();
        // GET: PxcMemberController
        public ActionResult Index()
        {
            return View(_pxcMember);
        }

        // GET: PxcMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PxcMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PxcMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PxcMemberRegister pxcMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                       return View(pxcMember);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PxcMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PxcMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PxcMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PxcMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
