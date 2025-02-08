using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository _repo = new SertifikaRepository();
        public IActionResult Index()
        {
            var sertifikalar = _repo.List();
            return View(sertifikalar);
        }

        public IActionResult SertifikaEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SertifikaEkle(TblSertifikalar p)
        {
            _repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult SertifikaGetir(int id)
        {
            var sertifika = _repo.TFind(x => x.Id == id);
            return View(sertifika);
        }

        [HttpPost]
        public IActionResult SertifikaGetir(TblSertifikalar p)
        {
            var sertifika = _repo.TFind(x => x.Id == p.Id);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Kaynak = p.Kaynak;
            sertifika.Tarih = p.Tarih;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }

        public IActionResult SertifikaSil(int id)
        {
            var sertifika = _repo.TFind(x => x.Id == id);
            _repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}
