using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class EgitimController : Controller
    {
        EgitimRepository _repo = new EgitimRepository();
        public IActionResult Index()
        {
            var egitimler = _repo.List();
            return View(egitimler);
        }

        public IActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EgitimEkle(TblEgitimler egitim)
        {
            _repo.TAdd(egitim);
            return RedirectToAction("Index");
        }

        public IActionResult EgitimGetir(int id)
        {
            var egitim = _repo.TFind(x=> x.Id == id);
            return View(egitim);
        }

        [HttpPost]
        public IActionResult EgitimGetir(TblEgitimler p)
        {
            var egitim = _repo.TFind(x => x.Id == p.Id);
            egitim.Baslik = p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.Gpa = p.Gpa;
            egitim.Tarih = p.Tarih;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }

        public IActionResult EgitimSil(int id)
        {
            var egitim = _repo.TFind(x => x.Id == id);
            _repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
    }
}
