using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class HobiController : Controller
    {
        HobiRepository _repo = new HobiRepository();
        public IActionResult Index()
        {
            var hobiler = _repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public IActionResult Index(TblHobiler p)
        {
            var hobi = _repo.TFind(x => x.Id == p.Id);
            hobi.Aciklama1 = p.Aciklama1;
            hobi.Aciklama2 = p.Aciklama2;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }
    }
}
