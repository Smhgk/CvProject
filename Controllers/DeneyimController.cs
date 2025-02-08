using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository _repo = new DeneyimRepository();
        public IActionResult Index()
        {
            var deneyimler = _repo.List();
            return View(deneyimler);
        }

        public IActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeneyimEkle(TblDeneyimler deneyim)
        {
            _repo.TAdd(deneyim);
            return RedirectToAction("Index");
        }

        public IActionResult DeneyimSil(int id)
        {
            var deneyim = _repo.TFind(x => x.Id == id);
            _repo.TDelete(deneyim);
            return RedirectToAction("Index");
        }

        public IActionResult DeneyimGetir(int id)
        {
            var deneyim = _repo.TFind(x => x.Id == id);
            return View(deneyim);
        }

        [HttpPost]
        public IActionResult DeneyimGetir(TblDeneyimler p)
        {
            var deneyim = _repo.TFind(x => x.Id == p.Id);
            deneyim.Baslik = p.Baslik;
            deneyim.AltBaslik = p.AltBaslik;
            deneyim.Tarih = p.Tarih;
            deneyim.Aciklama = p.Aciklama;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }
    }
}
