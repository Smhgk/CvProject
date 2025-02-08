using CvProject.Models;
using CvProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CvProject.Controllers
{
    public class SosyalMedyaController : Controller
    {
        SosyalMedyaRepository _repo = new SosyalMedyaRepository();
        public IActionResult Index()
        {
            var sosyalMedyalar = _repo.List();
            return View(sosyalMedyalar);
        }

        [HttpPost]
        public IActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
            _repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult SosyalMedyaGetir(int id)
        {
            var sosyalMedya = _repo.TFind(x => x.Id == id);
            return View(sosyalMedya);
        }

        [HttpPost]
        public IActionResult SosyalMedyaGetir(TblSosyalMedya p)
        {
            var sosyalMedya = _repo.TFind(x => x.Id == p.Id);
            sosyalMedya.Ad = p.Ad;
            sosyalMedya.Link = p.Link;
            sosyalMedya.Icon = p.Icon;
            _repo.TUpdate();
            return RedirectToAction("Index");
        }

        public IActionResult SosyalMedyaSil(int id)
        {
            var sosyalMedya = _repo.TFind(x=> x.Id == id);
            _repo.TDelete(sosyalMedya);
            return RedirectToAction("Index");
        }
    }
}
