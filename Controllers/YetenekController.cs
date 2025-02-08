using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository _repo = new YetenekRepository();
        public IActionResult Index()
        {
            var yetenekler = _repo.List();
            return View(yetenekler);
        }

        public IActionResult YetenekEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YetenekEkle(TblYetenekler item)
        {
            _repo.TAdd(item);
            return RedirectToAction("Index");
        }

        public IActionResult YetenekGetir(int id)
        {
            var yetenek = _repo.TFind(x=> x.Id == id);
            return View(yetenek);
        }

        [HttpPost]
        public IActionResult YetenekGetir(TblYetenekler p)
        {
            var yetenek = _repo.TFind(x => x.Id == p.Id);
            yetenek.Yetenek = p.Yetenek;
            yetenek.Oran = p.Oran;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }

        public IActionResult YetenekSil(int id)
        {
            var yetenek = _repo.TFind(x => x.Id == id);
            _repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
    }
}
